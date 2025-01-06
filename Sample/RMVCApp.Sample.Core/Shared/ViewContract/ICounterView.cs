using RMVC;
using System;

namespace RMVCApp.Sample.Core.Shared {
    public interface ICounterView : IRViewContract {
        event Action<int>? SetCounterEvt;
        void SetCounter(int count);
    }
}
