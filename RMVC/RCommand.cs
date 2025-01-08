namespace RMVC {
    public abstract class RCommand : RCommandBase {

        protected internal RFacade context;
        protected abstract void Run();


        internal void RunInternal(RFacade context) {
            this.context = context;
            Run();
        }
        internal override void ExecuteCommandInternal(RCommand command) {
            context.ExecuteCommand(command);
        }

    }
}
