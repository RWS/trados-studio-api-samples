using Sdl.Desktop.IntegrationApi.Interfaces;
using System;
using System.Collections.ObjectModel;

namespace Sdl.Notifications.Sample
{
    internal class StudioTestNotificationsGroup : IStudioGroupNotification
    {
        private Guid guid;
        private string _key;

        ObservableCollection<IStudioNotification> _notifications;
        public StudioTestNotificationsGroup(Guid guid, string key)
        {
            this.guid = guid;
            _key = key;
            _notifications = new ObservableCollection<IStudioNotification>();
        }

        public string Title { get; set; }

        public IStudioNotificationCommand Action { get => null; set { } }

        public bool IsActionVisible { get => false; set { } }

        public string Key => _key;

        public ObservableCollection<IStudioNotification> Notifications { get => _notifications; set { } }
    }
}
