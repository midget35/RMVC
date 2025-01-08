namespace RMVC {
    internal class RCommander {
        internal RFacade Context;
        internal RCommander(RFacade context) {
            Context = context;
        }
        public void ExecuteCommand(RCommandBase command) {
            Context.ExecuteCommand(command);
        }
    }
}
