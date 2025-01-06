using RMVC;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMVCApp.Sample.Core {
    internal class SetCounterValueCmd : RCommand {
        private readonly int counterCount;

        public SetCounterValueCmd(int counterCount) {
            this.counterCount = counterCount;
        }

        protected override void Run() {
            if (Context.Instance?.CounterModel != null) {
                Context.Instance.CounterModel.CounterCount = counterCount;
            }
        }
    }
}
