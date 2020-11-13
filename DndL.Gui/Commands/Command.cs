using System;
using System.Windows.Input;

namespace DndL.Gui.Commands
{
    public class Command
        : ICommand
    {
        private readonly Func<object, bool> _canExecute;
        private readonly Action<object> _execute;


        public Command(Action<object> exe, Func<object, bool> canExe = null)
        {
            _execute = exe ?? throw new ArgumentNullException(nameof(exe));
            _canExecute = canExe;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object param)
            => _canExecute == null || _canExecute(param);

        public void Execute(object param) => _execute(param);
    }
}