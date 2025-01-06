using RMVC;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMVCApp.Sample.Core {
    internal class SetProgressViewCmd : RCommand {
        public SetProgressViewCmd() {
        }

        protected override void Run() {
            if (Context.Instance != null && Context.Instance.ProgressModel != null)
                Context.Instance.ProgressMediator?.SetView(Context.Instance.ProgressModel.Progress);
        }
    }
}
