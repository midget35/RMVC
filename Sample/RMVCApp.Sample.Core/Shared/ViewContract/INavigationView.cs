using RMVC;
using System;

namespace RMVCApp.Sample.Core.Shared {
    public interface INavigationView : IRViewContract
    {
        event Action? ShowHomeViewEvt;
        event Action? ShowCounterViewEvt;
        event Action? ShowWeatherViewEvt;
    }
}
