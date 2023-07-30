using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMVC {
    public interface IRPromoter {
        void SetProgressUpdate(RProgress[] progress);
        void SetProgressComplete();
    }
}
