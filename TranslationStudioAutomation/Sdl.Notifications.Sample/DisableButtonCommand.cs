using System;
using System.Windows.Input;

namespace Sdl.Notifications.Sample
{
    internal class DisableButtonCommand : ICommand
    {
        private bool canExecute = true;

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return canExecute;
        }

        public void Execute(object parameter)
        {
            canExecute = false;
            CanExecuteChanged?.Invoke(this, null);
        }
    }
}