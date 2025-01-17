using RMVCApp.Sample.Core;
using RMVCApp.Sample.Core.Shared;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace RMVCApp.WPF.ViewModels
{
    public class CounterViewModel : INotifyPropertyChanged, IViewLifecycleAware, ICounterView {
        private int _count;
        public int Count {
            get => _count;
            set { _count = value; OnPropertyChanged(); }
        }

        public ICommand IncrementCommand { get; }

        public CounterViewModel() {
            IncrementCommand = new RelayCommand(() => {
                Count++;
                SetCounterEvt?.Invoke(Count);
            });
        }
        public event Action<int>? SetCounterEvt;
        public event PropertyChangedEventHandler? PropertyChanged;

        public void SetCounter(int count) {
            Count = count;
        }
        public void OnInitialised() {
            RMVCAppFacade.RegisterActor(this);
        }

        public void OnDisposed() {
            RMVCAppFacade.UnregisterActor(this);
        }
        protected void OnPropertyChanged([CallerMemberName] string? name = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
