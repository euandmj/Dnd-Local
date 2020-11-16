using System;
using System.Windows.Input;

namespace DndL.Gui.Commands
{
    public class DelegateCommand<T>
        : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly Predicate<T> _canExecute;
        private readonly Action<T> _execute;

        public DelegateCommand(Action<T> execute)
            : this(execute, null)
        {
        }

        public DelegateCommand(Action<T> execute, Predicate<T> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecute is null)
                return true;

            return _canExecute(
                parameter is null
                ? default
                : (T)Convert.ChangeType(parameter, typeof(T)));
        }

        public void Execute(object parameter)
        {
            _execute(
                parameter is null
                ? default
                : (T)Convert.ChangeType(parameter, typeof(T)));
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
