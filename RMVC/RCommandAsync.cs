using System;
using System.Diagnostics;

namespace RMVC {

    public abstract class RCommandAsync : RCommandBase {

        public RCommandAsync() {

        }
        protected abstract void Run();
        protected virtual string GetTitle() { return GetType().Name; }

        internal RTracker? rTracker { get; private set; } = null;
        private bool completeHandled = false;
        internal bool hasParent { get; private set; } = false;

        internal void RunInternal(
            RTracker rTracker
        ) {
            this.rTracker = rTracker;
            rTracker.SetProgressTitle(GetTitle());
            Run();
        }
        internal void Abort() {
            rTracker.Abort = true;
        }

        protected void ExecuteCommandAsync(
            RCommandAsync command
            , double percentCap = 100
        ) {
            command.hasParent = true;
            rTracker.context.ExecuteCommand(command, rTracker, percentCap);
        }
        internal override void ExecuteCommandInternal(RCommand command) {
            rTracker.context.ExecuteCommand(command);
        }
        protected virtual void OnCommandExit(bool success) { }
        internal void HandleThreadExit() {
            if (completeHandled) return;
            else completeHandled = true;

            OnCommandExit(!rTracker.ErrorOrAbort);
        }

        internal void SetErrorInternal(string errorMessage) {
            rTracker.SetError(errorMessage);
            HandleThreadExit();
        }
        protected void SetProgress(int parts, int total, string message = null) {
            rTracker.SetProgress(parts, total, message);
        }
        protected void SetProgress(double percent, string message = null) {
            rTracker.SetProgress(percent, message);
        }
        protected void SetProgress(int percent, string message = null) {
            rTracker.SetProgress(percent, message);
        }
        protected void SetProgress(string message) {
            rTracker.SetProgress(message);
        }

        protected void SetError(string errorMessage = null) {
            rTracker.SetError(errorMessage);
        }

        protected double GetPercent(int parts, int totalParts) {
            return RHelper.ClampPercent((double)parts / totalParts * 100);
        }
        protected double GetPercent(int totalParts) {
            return RHelper.ClampPercent((double)totalParts / 10d);
        }

        protected string ErrorMessage { get { return rTracker.ErrorMessage; } }
        protected bool ErrorOrAbort { get { return rTracker.ErrorOrAbort; } }
    }
}
