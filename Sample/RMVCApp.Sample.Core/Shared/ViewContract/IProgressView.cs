using global::RMVC;
using System;

namespace RMVCApp.Sample.Core.Shared {


    public interface IProgressView : IRViewContract {
        event Action? AbortProgressEvt;
        void SetProgress(RProgress[] progress);
        void ResetView();
    }
}
