using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Threading;

namespace RMVC {

    public abstract class RContext : IRPromoter {

        public static bool EnableDebugMode = false;
        public static bool EnableTestMode = false;
        private static long PROGRESS_FLOOD_MS = 200;

        private Stopwatch progressStopwatch;
        private RCommander _rCommander = null;
        private static bool _configured = false;

        private static IRShell _shell = null;
        private static IRPromoter _promoter = null;
        private static Type _promoterType = null;


        private static readonly Dictionary<BackgroundWorker, RCommandAsync> _processes =
            new Dictionary<BackgroundWorker, RCommandAsync>();

        private static readonly Dictionary<Type, RContext> _contexts = new Dictionary<Type, RContext>();

        private static readonly HashSet<Type> _pendingContexts = new HashSet<Type>();

        public static void Configure(IRShell appShell, Type promoterType = null) {
            if (_configured)
            {
                Error("RContext.Configure(...) should only be called once at the start of the application's life.");
            }
            _promoterType = promoterType;
            _shell = appShell;
            _configured = true;
        }

        protected static RContext GetContext(Type contextType) {
            if (!_contexts.ContainsKey(contextType)) {
                Error("RContext instance not found: "+contextType.Name);
                return null;
            }
            return _contexts[contextType];
        }
        protected static IRShell GetShell() {
            return _shell;
        }
        protected static IRPromoter GetPromoter() {
            return _promoter;
        }

        protected abstract RCommandBase Run(object mainViewObj, RCommander rCommander);

        public static void Execute(object mainView, Type contextConcreteType) {
            RContext context;

            if (contextConcreteType == null) {
                Fatal("The contextConcreteType cannot be null.");
            }
            else if (_contexts.ContainsKey(contextConcreteType)) {
                Fatal("Could not instantiate: " + contextConcreteType + ". It may already have been created.");
            }
            try {
                _pendingContexts.Add(contextConcreteType);
                context = Activator.CreateInstance(contextConcreteType) as RContext;
                _contexts.Add(contextConcreteType, context);

                if (_promoterType != null && contextConcreteType.Equals(_promoterType))
                    _promoter = context;

                else if (_promoter == null)
                    _promoter = context;

            }
            catch(Exception) {
                _pendingContexts.Remove(contextConcreteType);
                Error("Cannot instantiate Context instance. Ensure Context super class does not have constructor parameters.");
                return;
            }
            context._rCommander = new RCommander(context);
            RCommandBase startupCommand =
                context.Run(mainView, context._rCommander);

            if (startupCommand != null)
                context.ExecuteCommand(startupCommand);
        }

        /// <summary>
        /// Called through reflection
        /// </summary>
        protected RContext() {
            if (!_pendingContexts.Contains(GetType())){
                Fatal("Do not instantiate a Context directly. Use the static Initialise() method.");
            }
            _pendingContexts.Remove(GetType());
            progressStopwatch = new Stopwatch();
            progressStopwatch.Start();
        }

        public abstract void SetProgressUpdate(RProgress[] progress);

        public abstract void SetProgressComplete();
        
        public static void AbortAllCommands() {
            foreach (var item in _processes) {
                item.Value.Abort();
            }
        }

        public static void PrintDebug() {
            Debug.WriteLine(typeof(RContext) + "TODO: Debug print");
        }

        internal protected void ExecuteCommand(RCommandBase command) {
            ExecuteCommand(command, null);
        }
        internal void ExecuteCommand(
            RCommandBase command
            , RTracker rTracker
            , double percentCap = 100d
        ) {
            percentCap = RHelper.ClampPercent(percentCap);
            // Simple:
            if (command is RCommand) {
                ((RCommand)command).RunInternal(this);
            }
            // Async:
            else if (command is RCommandAsync) {
                BackgroundWorker thread =null;
                Thread debugThread = null;
                RCommandAsync async = command as RCommandAsync;

                bool createNewThread = rTracker == null;
                
                if (createNewThread && (EnableDebugMode || EnableTestMode)) {
                    debugThread = new Thread(() => {
                        async.RunInternal(new RTracker(async, this, percentCap));
                    });
                    debugThread.Start();
                    debugThread.Join();
                }
                else if (createNewThread) {

                    thread = new BackgroundWorker();
                    thread.DoWork += (sender, e) => {
                        try {
                            async.RunInternal(new RTracker(async, this, percentCap));
                        }
                        catch (Exception ex) {
                            Debug.WriteLine("ERROR CAUGHT c: " + ex.ToString());
                            async.SetErrorInternal("RContext Threading Error.");
                        }
                    };
                    _processes.Add(thread, async);
                    //Debug.WriteLine("     --- Process added: " + async.Name + ". Total: " + _processes.Count);

                    thread.RunWorkerCompleted += OnThreadCompleted;
                    thread.RunWorkerAsync();
                }
                else {
                    async.RunInternal(rTracker.CreateChild(async, percentCap));
                }
            }
        }// end ExecuteCommand()
        private static void OnThreadCompleted(object sender, RunWorkerCompletedEventArgs e) {
            BackgroundWorker thread = sender as BackgroundWorker;
            thread.RunWorkerCompleted -= OnThreadCompleted;

            RCommandAsync cmd = _processes[thread];

            _processes.Remove(thread);
            //Debug.WriteLine("     --- Process removed: " + cmd.Name + ". Total: " + _processes.Count);
            HandleThreadComplete(cmd);
        }
        private static void HandleThreadComplete(RCommandAsync command) {
            if (command.hasParent == false) {
                command.HandleThreadExit();
                command.rTracker.context.HandleProgressComplete();
            }
        }

        private void HandleProgressComplete() {
            SetProgressComplete();
        }
        internal void HandleProgressChange(RProgress[] progress) {
            //Debug.WriteLine("prog: "+DateTime.Now + " > "+progressStopwatch.ElapsedMilliseconds);
            //if (progressStopwatch.ElapsedMilliseconds < PROGRESS_FLOOD_MS)
            //    return;
            //else
            //    progressStopwatch.Restart();
            SetProgressUpdate(progress);
        }
        
        private static void Fatal(string message) {
            throw new Exception(message);
        }
        private static void Error(string message) {
            Debug.WriteLine("RMVC - ERROR: " + message);
        }
        //internal static void Warning(string message) {
        //    Debug.WriteLine("RMVC -  WARNING: " + message);
        //}
        //internal static void Log(string message) {
        //    if (EnableDebug)
        //        Debug.WriteLine("RMVC - LOG: " + message);
        //}
    }
}
