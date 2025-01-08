using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace RMVC {

    public abstract class RFacade {

        public static bool EnableDebugMode = false;
        public static bool EnableTestMode = false;

        private static bool hasBeenConfigured = false;

        private RCommander? rCommander = null;
        private bool initialised => rCommander != null;

        private DateTime lastProgressUpdateTime = DateTime.MinValue;

        private static RFacade? promoterContext = null;
        private static Type? promoterType = null;
        internal static IRAppShell? AppShell { get; private set; } = null;

        private readonly ConcurrentDictionary<Task, CancellationTokenSource> activeTasks =
           new ConcurrentDictionary<Task, CancellationTokenSource>();

        private readonly Dictionary<Type, RMediator> mediatorsDictionary = new Dictionary<Type, RMediator>();
        private readonly Dictionary<Type, RModel> modelsDictionary = new Dictionary<Type, RModel>();

        private static readonly Dictionary<Type, RFacade> activeContexts = new Dictionary<Type, RFacade>();

        private static readonly HashSet<Type> pendingContexts = new HashSet<Type>();

        public static void Create(Type contextConcreteType, IRAppShell? appShell = null) 
        {
            if (contextConcreteType == null) {
                throw new ArgumentNullException(nameof(contextConcreteType), "The contextConcreteType cannot be null.");
            }

            if (activeContexts.ContainsKey(contextConcreteType)) {
                throw new InvalidOperationException($"Could not instantiate: {contextConcreteType}. It may already have been created.");
            }

            try {
                pendingContexts.Add(contextConcreteType);
                var context = Activator.CreateInstance(contextConcreteType) as RFacade;

                if (context == null) {
                    throw new InvalidOperationException("Failed to create an instance of the context.");
                }

                activeContexts.Add(contextConcreteType, context);

                if (promoterType != null && contextConcreteType.Equals(promoterType)) {
                    promoterContext = context;
                }
                else if (promoterContext == null) {
                    promoterContext = context;
                }

                if (AppShell == null) {
                    AppShell = appShell;
                }

                context.rCommander = new RCommander(context);

                var models = context.RegisterModels();
                foreach (RModel model in models) {
                    context.modelsDictionary.Add(model.GetType(), model);
                    model.rCommander = context.rCommander;
                    model.Initialise();
                }

                var mediators = context.RegisterMediators();
                foreach (RMediator mediator in mediators) {
                    context.mediatorsDictionary.Add(mediator.GetType(), mediator);
                    mediator.rCommander = context.rCommander;
                }

                RCommandBase startupCommand = context.RegisterStartupCommand();

                if (startupCommand != null) {
                    context.ExecuteCommand(startupCommand);
                }

                Log($"Context execution completed: {contextConcreteType?.Name}.");
            }
            catch (Exception ex) {
                pendingContexts.Remove(contextConcreteType);
                Log($"Cannot instantiate Context instance. Error: {ex.Message}");
                throw;
            }
        }

        public static void RegisterView(IRViewContract view) {

            RMediator? foundMediator = null;

            foreach (var context in activeContexts.Values) {
                if (context is null || context.mediatorsDictionary is null)
                    continue;

                foreach (var mediator in context.mediatorsDictionary.Values) {
                    if (mediator.viewBaseType.IsAssignableFrom(view.GetType())) {
                        foundMediator = mediator;

                        // assuming aggressive re-registering can be forgiven:
                        if (mediator.viewBase == view) {
                            return;
                        }
                        break;
                    }
                }
                if (foundMediator != null)
                    break;
            }

            if (foundMediator == null) {
                //Log("Mediator is null: " + view);
                return; // Windows Forms Designer bug.
            }
            foundMediator.UpdateViewBase(view);

            Log("Registered mediator + view: " + foundMediator.GetType().Name + " | " + view.GetType().Name);
        }
        public static void UnregisterView(IRViewContract view) {

            RMediator? foundMediator = null;

            foreach (var context in activeContexts.Values) {
                if (context is null || context.mediatorsDictionary is null)
                    continue;

                foreach (var mediator in context.mediatorsDictionary.Values) {
                    if (mediator.viewBaseType.IsAssignableFrom(view.GetType())) {
                        foundMediator = mediator;
                        if (foundMediator.viewBase == null) {
                            return;
                        }
                    }
                    if (foundMediator != null)
                        break;

                }
                if (foundMediator != null)
                    break;
            }

            if (foundMediator == null) {
                //Log("Mediator is null: " + view);
                return; // Windows Forms Designer bug.
            }
            Log("Unregistered mediator + view: " + foundMediator.GetType().Name + " | " + view.GetType().Name);

        }
        public static void Configure(Type? promoterType = null) {
            if (hasBeenConfigured)
            {
                Error("RContext.Configure(...) should only be called once at the start of the application's life.");
            }
            RFacade.promoterType = promoterType;
            hasBeenConfigured = true;
        }

        public static void Log(object? logMessage) {

            if (!EnableDebugMode)
                return;

            logMessage = "[RMVC] " + logMessage;
            Debug.WriteLine($"{logMessage}");
            Console.WriteLine($"{logMessage}");
        }


        public void AbortAllCommands() {
            foreach (var cancellationSource in activeTasks.Values) {
                cancellationSource.Cancel();
            }
        }

        internal void ExecuteCommand(RCommandBase command) {
            ExecuteCommand(command, null);
        }

        internal void ExecuteCommand(RCommandBase command, RTracker? rTracker = null, double percentCap = 100d) {
            percentCap = RHelper.ClampPercent(percentCap);

            if (command is RCommand syncCommand) {
                // Synchronous execution
                syncCommand.RunInternal(this);
            }
            else if (command is RCommandAsync asyncCommand) {
                // Delegate async command execution
                _ = ExecuteCommandAsync(asyncCommand, rTracker, percentCap);
            }
        }

        internal async Task ExecuteCommandAsync(
            RCommandAsync asyncCommand,
            RTracker? rTracker,
            double percentCap
        ) {

            if (!asyncCommand.hasParent && !activeTasks.IsEmpty && asyncCommand.EnableAutoUpdate) {
                Error("Cannot execute more than one top-level Async Command at a time.");
                return;
            }

            var cancellationTokenSource = rTracker != null ? CancellationTokenSource.CreateLinkedTokenSource(rTracker.Token) : new CancellationTokenSource();

            rTracker ??= new RTracker(asyncCommand, this, percentCap, cancellationTokenSource.Token);

            var task = Task.Run(async () =>
            {
                try {
                    await asyncCommand.RunInternalAsync(rTracker);
                }
                catch (Exception ex) {
                    Log("ERROR CAUGHT in async command: " + ex.ToString());
                    asyncCommand.SetErrorInternal("RContext Async Execution Error.");
                }
            }, cancellationTokenSource.Token);

            // Track only top-level async commands
            if (!asyncCommand.hasParent && !activeTasks.ContainsKey(task)) {

                activeTasks[task] = cancellationTokenSource;
            }

            try {
                await task;
            }
            finally {
                if (!asyncCommand.hasParent && activeTasks.ContainsKey(task)) {
                    HandleTaskComplete(asyncCommand);
                    activeTasks.TryRemove(task, out _);
                    Log($"Active tasks: {activeTasks.Count}");
                }
            }
        }

        protected abstract RCommandBase RegisterStartupCommand();
        protected abstract RMediator[] RegisterMediators();
        protected abstract RModel[] RegisterModels();

        protected static TContext? ContextInstance<TContext>() where TContext : RFacade {
            if (activeContexts.TryGetValue(typeof(TContext), out RFacade? context)) {
                return context as TContext;
            }
            return null;
        }

        protected TMediator? Mediator<TMediator>() where TMediator : RMediator {
            if (mediatorsDictionary.TryGetValue(typeof(TMediator), out RMediator? mediator)) {
                return mediator as TMediator;
            }
            return null;
        }

        protected TModel? Model<TModel>() where TModel : RModel {
            if (modelsDictionary.TryGetValue(typeof(TModel), out RModel? model)) {
                return model as TModel;
            }
            return null;
        }

        protected static RFacade? GetPromoter() {
            return promoterContext;
        }
        private void HandleTaskComplete(RCommandAsync command) {

            command.HandleThreadExit();

            if (!command.hasParent && command.EnableAutoUpdate) {
                command.rTracker?.context.HandleProgressComplete();
            }
        }


        protected RFacade() {
            if (!pendingContexts.Contains(GetType())){
                Fatal("Do not instantiate a Context directly. Use the static Initialise() method.");
            }
            pendingContexts.Remove(GetType());
        }


        private void HandleProgressComplete() {
            if (promoterContext == null) return;
            
            RCommandBase? cmd = promoterContext.RegisterProgressCompleteCommand();
            if (cmd != null) {
                ExecuteCommand(cmd);
            }
        }

        internal void HandleProgressChange(RProgress[] progress) {
            if ((DateTime.Now - lastProgressUpdateTime).TotalMilliseconds < 100)
                return;
            else
                lastProgressUpdateTime = DateTime.Now;

            if (promoterContext == null) return;
            
            RCommandBase? cmd = promoterContext.RegisterProgressUpdateCommand(progress);
            if (cmd != null) {
                ExecuteCommand(cmd);
            }
        }

        virtual protected RCommandBase? RegisterProgressUpdateCommand(RProgress[] progress) {
            return null;
        }

        virtual protected RCommandBase? RegisterProgressCompleteCommand() {
            return null;
        }
        private static void Fatal(string message) {
            throw new Exception(message);
        }
        private static void Error(string message) {
            Log("RMVC - ERROR: " + message);
        }

    }
}
