using RMVCApp.Sample.Core;
using RMVCApp.Sample.Core.Shared;
using System.Windows.Input;

namespace RMVCApp.WPF.ViewModels {
    public class HomeViewModel : IViewLifecycleAware, IHomeView {
        public ICommand RmvcTestCommand { get; }
        public ICommand RmvcProgressTestCommand { get; }

        public HomeViewModel() {
            RmvcTestCommand = new RelayCommand(OnRmvcMessageTest);
            RmvcProgressTestCommand = new RelayCommand(OnRmvcProgressTest);
        }

        public event Action<string>? ShowRmvcMessageEvt;
        public event Action? RunRmvcProgressTestEvt;

        private void OnRmvcMessageTest() {
            ShowRmvcMessageEvt?.Invoke("Hello from RMVC.");
        }
        private void OnRmvcProgressTest() {
            RunRmvcProgressTestEvt?.Invoke();
        }

        public void OnInitialised() {
            RMVCAppFacade.RegisterActor(this);
        }

        public void OnDisposed() {
            RMVCAppFacade.UnregisterActor(this);
        }

        public void SetView() {

        }
    }
}
