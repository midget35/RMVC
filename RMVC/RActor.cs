using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace RMVC {
    public abstract class RActor {
        public string Name { get { return GetType().Name; } }
        internal RActor() { }
        
    }
}
