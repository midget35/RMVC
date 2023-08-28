using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace RMVC {
    public abstract class RModel : RMediator {
        public RModel(RCommander rCommander) : base(rCommander) {

        }
    }
}
