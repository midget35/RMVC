using Avalonia;
using Avalonia.Controls;
using RMVCApp.Avalonia.ViewModels;

namespace RMVCApp.Avalonia.Views {
    public abstract class UserControlBase : UserControl {
        public UserControlBase() {

            this.AttachedToVisualTree += OnAttachedToVisualTree;
            this.DetachedFromVisualTree += OnDetachedFromVisualTree;
        }

        private void OnAttachedToVisualTree(object? sender, VisualTreeAttachmentEventArgs e) {
            if (DataContext as ViewModelBase != null) {
                ((ViewModelBase)DataContext).OnViewInitialized();
            }
        }

        private void OnDetachedFromVisualTree(object? sender, VisualTreeAttachmentEventArgs e) {
            if (DataContext as ViewModelBase != null) {
                ((ViewModelBase)DataContext).OnViewDisposed();
            }
        }
    }
}
