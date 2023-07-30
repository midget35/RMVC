using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMVC {
    public class RCommander {
        internal RContext Context;
        internal RCommander(RContext context) {
            Context = context;
        }
        public void ExecuteCommand(RCommandBase command) {
            Context.ExecuteCommand(command);
        }
    }
}
