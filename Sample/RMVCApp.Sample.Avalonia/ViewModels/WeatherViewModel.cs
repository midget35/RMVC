using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System;
using RMVCApp.Sample.Core.Shared;
using RMVCApp.Sample.Core;

namespace RMVCApp.Avalonia.ViewModels {
    public partial class WeatherViewModel : ViewModelBase, IWeatherView {
        [ObservableProperty]
        private ObservableCollection<WeatherForecastDTO> _forecasts;

        public WeatherViewModel() {
            
        }

        public void SetView(WeatherForecastDTO[]? forecasts) {
            if (forecasts == null) forecasts = Array.Empty<WeatherForecastDTO>();
            Forecasts = new ObservableCollection<WeatherForecastDTO>(forecasts);
        }

        protected internal override void OnViewDisposed() {
            Context.UnregisterView(this);
        }

        protected internal override void OnViewInitialized() {
            Context.RegisterView(this);
        }
    }
}
