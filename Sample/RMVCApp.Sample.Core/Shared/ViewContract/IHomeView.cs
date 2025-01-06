
using RMVC;
using System;

namespace RMVCApp.Sample.Core.Shared {
    public interface IHomeView : IRViewContract {
        event Action<string>? ShowRmvcMessageEvt;
        event Action? RunRmvcProgressTestEvt;
        void SetView();
    }
}
