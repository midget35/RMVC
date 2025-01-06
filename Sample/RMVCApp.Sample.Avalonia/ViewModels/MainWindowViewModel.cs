using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MsBox.Avalonia;
using MsBox.Avalonia.Dto;
using MsBox.Avalonia.Enums;
using MsBox.Avalonia.Models;
using RMVCApp.Sample.Core;
using RMVCApp.Sample.Core.Shared;
using System.Diagnostics;

namespace RMVCApp.Avalonia.ViewModels {
    public partial class MainWindowViewModel : ViewModelBase, IMainView {
        [ObservableProperty]
        private object? _currentView;

        public MainWindowViewModel() {
            NavigateToHome();
        }

        // Property to get the app name from the system
        public string AppName => Application.Current?.Name ?? "Demo App";

        [RelayCommand]
        private void NavigateToHome() {
            CurrentView = new HomeViewModel();
        }

        [RelayCommand]
        private void NavigateToCounter() {
            CurrentView = new CounterViewModel();
        }

        [RelayCommand]
        private void NavigateToWeather() {
            CurrentView = new WeatherViewModel();
        }

        public void SetAppEnabled(bool doEnable) {

        }
        public void ShowView(Enums.ViewEnum viewEnum) {

        }


        protected internal override void OnViewDisposed() {
            Context.UnregisterView(this);
        }

        protected internal override void OnViewInitialized() {

            Context.RegisterView(this);
        }





        public bool ShowMessageBox(string? title, string message, bool isYesNo) {
            Debug.WriteLine("RMVC SHOW DIALOG....");

            var messageBox = MessageBoxManager.GetMessageBoxCustom(new MessageBoxCustomParams {
                ContentTitle = title ?? "Confirm",
                ContentMessage = message,
                ButtonDefinitions = new[]
                {
                    new ButtonDefinition { Name = "Yes" },
                    new ButtonDefinition { Name = "No" }
                },
                Icon = Icon.Question,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            });

            var desktop = (IClassicDesktopStyleApplicationLifetime)Application.Current.ApplicationLifetime;

            var result = messageBox.ShowWindowDialogAsync(desktop.MainWindow).GetAwaiter().GetResult();

            return result == "Yes";
        }
    }
}
