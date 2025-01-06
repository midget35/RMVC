namespace RMVC {
    public abstract class RCommandExecutorBase : RActor {
        internal RCommander? rCommander;

        protected RCommandExecutorBase() {
        }
        protected void ExecuteCommand(RCommandBase command) {
            rCommander?.Context.ExecuteCommand(command);
        }
    }
}
