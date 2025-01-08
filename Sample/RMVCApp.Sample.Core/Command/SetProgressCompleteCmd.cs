using RMVC;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace RMVCApp.Sample.Core {
    internal class SetProgressCompleteCmd : RCommand {
        protected override void Run() {

            base.ExecuteCommand(new ShowViewCmd(Shared.Enums.ViewEnum.None));
            RMVCAppFacade.Instance?.ProgressMediator?.ResetView();
        }
    }
}
