using RMVC;

namespace RMVCApp.Sample.Core {
    internal class SetCounterViewCmd : RCommand {
        protected override void Run() {
            Context.Instance?.CounterMediator?.SetView(
                Context.Instance?.CounterModel?.CounterCount ?? 0
            );
        }
    }
}
