using System;
using System.Windows.Input;

namespace Sdl.Notifications.Sample
{
    internal class BasicCommand : ICommand
    {
        private readonly Action action;

        public BasicCommand(Action action)
        {
            this.action = action;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            action();
        }
    }
}