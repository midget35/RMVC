using RMVC;
using static RMVCApp.Sample.Core.Shared.Enums;

namespace RMVCApp.Sample.Core.Shared {
    public interface IMainView : IRViewContract {
        void ShowView(ViewEnum viewEnum);
    }
}
