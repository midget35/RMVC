namespace RMVC {
    public abstract class RCommand : RCommandBase {

        protected internal RContext context;
        protected abstract void Run();


        internal void RunInternal(RContext context) {
            this.context = context;
            Run();
        }
        internal override void ExecuteCommandInternal(RCommand command) {
            context.ExecuteCommand(command);
        }

    }
}
