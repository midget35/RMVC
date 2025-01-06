using RMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMVCApp.Sample.Core {
    internal class SetWeatherViewCmd : RCommand {
        protected override void Run() {
            Context.Instance?.WeatherMediator?.SetView(
                Context.Instance?.WeatherModel?.forecasts ?? null
            );
        }
    }
}
