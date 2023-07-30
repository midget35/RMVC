using System;
using System.Collections.Generic;
using System.Text;

namespace RMVC {
    public abstract class RCommandBase : RActor {
        internal RCommandBase() {

        }
        protected void ExecuteCommand(RCommand command) {
            ExecuteCommandInternal(command);
        }
        abstract internal void ExecuteCommandInternal(RCommand command);

    }
}
