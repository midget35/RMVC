namespace RMVCApp.Sample.Core {
    using global::RMVC;
    using System.Threading.Tasks;

    public class ShowRmvcMessageCmd : RCommandAsync {
        private readonly string message;

        public ShowRmvcMessageCmd(string message) {
            this.message = message;
        }

        protected override bool EnableAutoUpdate => false;

        protected override async Task RunAsync() {
            if (base.AppShell != null) {
                bool result = await base.AppShell.ShowMessageBox("Attention", message, false);
            }
        }
    }
}
