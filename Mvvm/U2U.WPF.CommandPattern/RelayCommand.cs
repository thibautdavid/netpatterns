using System;
using System.Windows.Input;

namespace U2U.WPF.CommandPattern
{
    public class RelayCommand : ICommand
    {
        public string DisplayName { get; private set; }
        private Action _execute;
        private Func<bool> _canExecute;

        public RelayCommand(string displayName, Action execute, Func<bool> canExecute)
        {
            DisplayName = displayName;
            _canExecute = canExecute;
            _execute = execute;
        }

        public RelayCommand(string displayName, Action execute)
            : this(displayName, execute, () => true)
        {

        }
        public bool CanExecute(object parameter)
        {
            return _canExecute();
        }

        public void Execute(object parameter)
        {
            _execute();
        }

        public event EventHandler CanExecuteChanged;
    }
}
