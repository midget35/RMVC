using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace RMVC {
    public abstract class RMediator : RActor, INotifyPropertyChanged {
        public event PropertyChangedEventHandler? PropertyChanged;
        private RCommander _rCommander;
        public RMediator(RCommander rCommander) {
            _rCommander = rCommander;
        }
        protected void ExecuteCommand(RCommandBase command) {
            _rCommander.Context.ExecuteCommand(command);
        }
        protected void OnPropertyChanged([CallerMemberName] string? name = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
