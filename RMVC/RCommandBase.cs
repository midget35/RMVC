namespace RMVC {
    public abstract class RCommandBase : RActor {
        internal RCommandBase() {

        }
        abstract internal void ExecuteCommandInternal(RCommand command);

        protected void ExecuteCommand(RCommand command) {
            ExecuteCommandInternal(command);
        }

    }
}
