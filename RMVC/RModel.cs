using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace RMVC {
    public abstract class RModel : RActor {
        private RCommander _rCommander;
        public RModel(RCommander rCommander) {
            _rCommander = rCommander;
        }

        protected void ExecuteCommand(RCommandBase command) {
            _rCommander.Context.ExecuteCommand(command);
        }
    }
}
