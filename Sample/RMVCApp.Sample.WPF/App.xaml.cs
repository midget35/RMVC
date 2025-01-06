using RMVCApp.Sample.Core;
using System.Configuration;
using System.Data;
using System.Windows;

namespace RMVCApp.WPF {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application, IAppShell {
        public void SetAppEnabled(bool doEnable) {
        }

        public Task<bool> ShowMessageBox(string title, string message, bool isYesNo = false) {
            MessageBoxButton buttons = isYesNo ? MessageBoxButton.YesNo : MessageBoxButton.OK;
            MessageBoxResult result = MessageBox.Show(message, title, buttons, MessageBoxImage.Information);
            bool isConfirmed = result == MessageBoxResult.Yes || result == MessageBoxResult.OK;

            return Task.FromResult(isConfirmed);
        }


        protected override void OnStartup(StartupEventArgs e) {
            Context.Create(typeof(Context), this);
            base.OnStartup(e);
        }
    }

}
