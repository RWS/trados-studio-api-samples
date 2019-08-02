using Sdl.Desktop.IntegrationApi.Interfaces;
using System;
using System.Drawing;

namespace Sdl.Notifications.Sample
{
    internal class OpenLinkCommand : IStudioNotificationCommand
    {
        private readonly string _uri;

        public OpenLinkCommand(string uri)
        {
            _uri = uri.Trim();
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            System.Diagnostics.Process.Start(_uri);
        }


        public event EventHandler CanExecuteChanged;

        public string CommandText { get; set; }
        public string CommandToolTip { get; set; }
        public Icon CommandIcon { get; set; }

    }
}
