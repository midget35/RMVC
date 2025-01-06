using global::RMVC;
using System;
using System.Threading.Tasks;

namespace RMVCApp.Sample.Core {

    internal static class RMVCAppConstants {
        public static int GetRandomUpdateDelayMilliseconds() {
            Random random = new Random();
            //return random.Next(100, 1001);
            //return random.Next(100, 1001);
            return 500;
        }
    }

    internal class RunProgressTestCmd : RCommandAsync {
        protected override bool EnableAutoUpdate => true;
        protected override async Task RunAsync() {
            await base.ExecuteCommandAsync(new RunProgressWorker1Cmd("Worker 1a"), 50);
            if (base.ErrorOrAbort)
                return;

            await base.ExecuteCommandAsync(new RunProgressWorker1Cmd("Worker 1b"), 50);
        }
    }

    internal class RunProgressWorker1Cmd : RCommandAsync {
        public RunProgressWorker1Cmd(string title) {
            base.SetProgress(title);
        }
        protected override bool EnableAutoUpdate => true;

        private readonly int totalParts = 3;
        protected override async Task RunAsync() {
            for (int i = 0; i < totalParts; i++) {
                await base.ExecuteCommandAsync(new RunProgressWorker2Cmd("Worker 2"), 100 / totalParts);

                if (base.ErrorOrAbort)
                    return;

                var part = i + 1;
                base.SetProgress(part, totalParts, $"Worker 1: {part}/{totalParts}.");
            }
        }
    }

    internal class RunProgressWorker2Cmd : RCommandAsync {
        public RunProgressWorker2Cmd(string title) {
            base.SetProgress(title);
        }
        protected override bool EnableAutoUpdate => true;

        private readonly int totalParts = 3;
        protected override async Task RunAsync() {
            for (int i = 0; i < totalParts; i++) {
                await base.ExecuteCommandAsync(new RunProgressWorker3Cmd("Worker 3"), 100 / totalParts);

                if (base.ErrorOrAbort)
                    return;

                var part = i + 1;
                base.SetProgress(part, totalParts, $"Worker 2: {part}/{totalParts}.");
            }
        }
    }

    internal class RunProgressWorker3Cmd : RCommandAsync {
        public RunProgressWorker3Cmd(string title) {
            base.SetProgress(title);
        }
        protected override bool EnableAutoUpdate => true;
        private readonly int totalParts = 3;
        protected override async Task RunAsync() {
            for (int i = 0; i < totalParts; i++) {

                await Task.Delay(RMVCAppConstants.GetRandomUpdateDelayMilliseconds());

                if (base.ErrorOrAbort)
                    return;

                var part = i + 1;
                base.SetProgress(part, totalParts, $"Worker 3: {part}/{totalParts}.");
            }
        }
    }
}
