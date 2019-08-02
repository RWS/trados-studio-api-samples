using Sdl.Desktop.IntegrationApi.Interfaces;
using Sdl.Desktop.IntegrationApi.Notifications.Events;
using Sdl.TranslationStudioAutomation.IntegrationApi;
using System;
using System.Drawing;

namespace Sdl.Notifications.Sample
{
    public class ClearNotificationAction : IStudioNotificationCommand
    {
        private readonly string _groupNotification;
        private readonly Guid _notificationId;

        public ClearNotificationAction(string groupNotificationKey, Guid notificationId)
        {
            _groupNotification = groupNotificationKey;
            _notificationId = notificationId;
        }
              
        public void Execute(object parameter)
        {
            var ea = SdlTradosStudio.Application.GetService<IStudioEventAggregator>();
            ea.Publish(new RemoveStudioNotificationFromGroupEvent(_groupNotification, _notificationId));
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public string CommandText { get; set; }

        public string CommandToolTip { get; set; }

        public Icon CommandIcon { get; set; }



    }
}
