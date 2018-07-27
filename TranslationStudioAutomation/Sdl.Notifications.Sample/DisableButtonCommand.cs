using System;
using System.Windows.Input;

namespace Sdl.Notifications.Sample
{
    internal class DisableButtonCommand : ICommand
    {
        private bool _canExecute = true;

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _canExecute;
        }

        public void Execute(object parameter)
        {
            _canExecute = false;
            CanExecuteChanged?.Invoke(this, null);
        }
    }
}