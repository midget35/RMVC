using CommunityToolkit.Mvvm.ComponentModel;
using System;

namespace RMVCApp.Avalonia.ViewModels {
    public abstract class ViewModelBase : ObservableObject {
        public ViewModelBase() {
        }

        protected internal abstract void OnViewDisposed();
        protected internal abstract void OnViewInitialized();
    }
}
