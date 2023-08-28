using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMVC {
    public interface IRShell {
        void SetAppEnabled(bool doEnable);

        REnum.RMessageBoxResult ShowMessageBox(
            string title, string message, REnum.RMessageBoxType type, REnum.RMessageBoxIcon icon
        );
    }
}
