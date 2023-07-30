using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace RMVC {
    internal class RTracker {
        internal string Id { get; private set; }
        internal bool Abort { get { return _abort; } set { ApplyAbort(value); } }
        internal string ErrorMessage { get; private set; } = string.Empty;
        internal bool Error { get { return _error; } }

        internal bool ErrorOrAbort { get { return _error || _abort; } }

        internal RCommandAsync _command;
        internal RContext context;
        private double _cap;

        private RTracker _parent;
        private RTracker _child;

        private double _localPercent;

        private string _title;
        private string _text;
        private bool _abort;
        private bool _error;
        internal RTracker(RCommandAsync command, RContext context, double cap) {
            Id = Guid.NewGuid().ToString();

            _cap        = cap;
            _parent     = null;
            _child      = null;
            _localPercent = 0d;
            _command    = command;
            this.context     = context;

            _text = null;
            _title = null;
            _abort = false;
            _error = false;
        }
        internal RProgress[] GetProgressReport() {
            List<RProgress> list = new List<RProgress>();
            RTracker[] rTrackerSet = GetAllRTrackersFlat();
            RTracker rTracker;
            for (int i = 0; i < rTrackerSet.Length; i++) {
                rTracker = rTrackerSet[i];
                if (i != 0 && rTracker._localPercent == 0) continue;
                list.Add(
                    new RProgress(
                        ToInt(rTracker._localPercent)
                        , rTracker._text
                        , rTracker._title
                        , rTracker.Id
                    )
                );
            }
            return list.ToArray();
        }
        internal void SetProgressTitle(string title) {
            _title = title;
            SendProgress();
        }
        internal void SetProgress(string text) {
            if (!string.IsNullOrWhiteSpace(text))
                _text = text;
            SendProgress();
        }
        internal void SetProgress(double percentComplete, string text = null) {
            percentComplete = RHelper.ClampPercent(percentComplete);
            if (percentComplete <= _localPercent) return;

            if (!string.IsNullOrWhiteSpace(text))
                _text = text;

            UpdatePercent(percentComplete - _localPercent);
        }
        internal void SetProgress(int percentComplete, string text = null) {
            percentComplete = SanitizePercent(percentComplete);
            if (percentComplete <= _localPercent) return;

            if (!string.IsNullOrWhiteSpace(text))
                _text = text;

            UpdatePercent(percentComplete - _localPercent);

        }
        internal void SetProgress(int step, int total, string text = null) {
            
            double adjusted = GetPercent(step, total);

            if (adjusted <= _localPercent) return;
            
            if (!string.IsNullOrWhiteSpace(text))
                _text = text;

            UpdatePercent(adjusted - _localPercent);
        }



        internal void SetError(string errorMessage) {
            if (string.IsNullOrWhiteSpace(errorMessage))
                errorMessage = "Unspecified Error.";

            _error = true;
            ErrorMessage = errorMessage;
            RTracker[] arr = GetAllRTrackersFlat();

            foreach (RTracker item in arr) {
                item._error = true;
                item.ErrorMessage = ErrorMessage;
            }
        }
        internal RTracker CreateChild(RCommandAsync command, double percentCap) {
            
            _child = new RTracker(command, context, percentCap * (_cap / 100d));
            _child._parent = this;

            return _child;
        }
        private void ApplyAbort(bool abort) {
            if (!abort) return;
            RTracker[] arr = GetAllRTrackersFlat();

            foreach (RTracker item in arr) {
                item._abort = abort;
            }
        }
        
        private RTracker[] GetAllRTrackersFlat() {
            List<RTracker> list = new List<RTracker>();
            RTracker rootRTracker = GetRootRTracker();
            list.Add(rootRTracker);

            RTracker child = rootRTracker._child;
            while(child != null) {
                list.Add(child);
                child = child._child;
            }
            return list.ToArray();
        }
        private void SendProgress() {
            if (_parent != null) {
                _parent.SendProgress();
                return;
            }
            context.HandleProgressChange(GetProgressReport());
        }
        private void UpdatePercent(double localPercentIncrement) {
            _localPercent += localPercentIncrement;
            if (_parent != null) {
                _parent.UpdatePercent(localPercentIncrement * (_cap / 100d));
            }
            else SendProgress();
        }
        private uint GetPercent(int current, int total) {
            int percent = (int)((current / (double)total) * 100);
            if (percent > 100) percent = 100;
            else if (percent < 0) percent = 0;
            return (uint)percent;
        }
        private int SanitizePercent(int percent) {
            if (percent > 100) return 100;
            else if (percent < 0) return 0;
            else return percent;
        }
        private RTracker GetBaseRTracker() {
            if (_child == null) return this;
            else return _child.GetBaseRTracker();
        }
        private RTracker GetRootRTracker() {
            if (_parent == null) return this;
            else return _parent.GetRootRTracker();
        }
        private int ToInt(double val) {
            return Convert.ToInt32(val);
        }
    }
}
