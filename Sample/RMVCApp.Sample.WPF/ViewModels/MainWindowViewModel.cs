using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RMVCApp.WPF.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged, IViewLifecycleAware {
        private object? _currentViewModel;
        public object? CurrentViewModel {
            get => _currentViewModel;
            set { _currentViewModel = value; OnPropertyChanged(); }
        }

        public ICommand NavigateHomeCommand { get; }
        public ICommand NavigateCounterCommand { get; }
        public ICommand NavigateWeatherCommand { get; }

        public MainWindowViewModel() {
            NavigateHomeCommand = new RelayCommand(NavigateHome);
            NavigateCounterCommand = new RelayCommand(NavigateCounter);
            NavigateWeatherCommand = new RelayCommand(NavigateWeather);

            CurrentViewModel = new HomeViewModel();
        }

        private void NavigateHome() => CurrentViewModel = new HomeViewModel();
        private void NavigateCounter() => CurrentViewModel = new CounterViewModel();
        private void NavigateWeather() => CurrentViewModel = new WeatherViewModel();


        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void OnInitialised() {

        }

        public void OnDisposed() {

        }
    }
}
