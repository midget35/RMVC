using RMVC;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMVCApp.Sample.Core {
    internal class SetProgressViewCmd : RCommand {
        public SetProgressViewCmd() {
        }

        protected override void Run() {
            if (RMVCAppFacade.Instance != null && RMVCAppFacade.Instance.ProgressModel != null)
                RMVCAppFacade.Instance.ProgressMediator?.SetView(RMVCAppFacade.Instance.ProgressModel.Progress);
        }
    }
}
