using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RMVC {
    internal static class RHelper {
        internal static double ClampPercent(double d) {
            return Math.Max(0, Math.Min(d, 100));
        }
    }
}
