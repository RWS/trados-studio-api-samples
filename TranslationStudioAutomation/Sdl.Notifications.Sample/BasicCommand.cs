using Sdl.Desktop.IntegrationApi.Interfaces;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sdl.Notifications.Sample
{
    internal class BasicCommand : IStudioNotificationCommand
    {
        public string CommandText { get; set; }
        public string CommandToolTip { get; set; }
        public Icon CommandIcon { get; set; }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            MessageBox.Show("I was clicked");
        }
    }
}