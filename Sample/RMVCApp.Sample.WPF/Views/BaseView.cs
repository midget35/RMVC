using System.Windows;
using System.Windows.Controls;
using RMVCApp.WPF.ViewModels;

namespace RMVCApp.WPF.Views {
    public class BaseView : UserControl {
        public BaseView() {
            Loaded += OnViewLoaded;
            Unloaded += OnViewUnloaded;
        }

        private void OnViewLoaded(object sender, RoutedEventArgs e) {
            if (DataContext is IViewLifecycleAware lifecycleAware) {
                lifecycleAware.OnInitialised();
            }
        }

        private void OnViewUnloaded(object sender, RoutedEventArgs e) {
            if (DataContext is IViewLifecycleAware lifecycleAware) {
                lifecycleAware.OnDisposed();
            }
        }
    }
}
