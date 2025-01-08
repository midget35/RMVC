using RMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMVCApp.Sample.Core {
    internal class SetWeatherViewCmd : RCommand {
        protected override void Run() {
            RMVCAppFacade.Instance?.WeatherMediator?.SetView(
                RMVCAppFacade.Instance?.WeatherModel?.forecasts ?? null
            );
        }
    }
}
