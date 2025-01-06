namespace RMVC {
    internal class RCommander {
        internal RContext Context;
        internal RCommander(RContext context) {
            Context = context;
        }
        public void ExecuteCommand(RCommandBase command) {
            Context.ExecuteCommand(command);
        }
    }
}
