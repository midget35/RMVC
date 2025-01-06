using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMVCApp.WPF.ViewModels
{
    public interface IViewLifecycleAware {
        void OnInitialised();
        void OnDisposed();
    }
}
