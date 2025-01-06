using RMVC;

namespace RMVCApp.Sample.Core.Shared {
    public interface IWeatherView : IRViewContract {
        void SetView(WeatherForecastDTO[]? Forecasts);
    }
}
