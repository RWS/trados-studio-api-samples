using Sdl.Desktop.IntegrationApi.Interfaces;
using System.Collections.ObjectModel;

namespace Sdl.Notifications.Sample
{
    internal class StudioTestNotificationsGroup : IStudioGroupNotification
    {
        private readonly ObservableCollection<IStudioNotification> _notifications;

        public StudioTestNotificationsGroup(string key)
        {
            Key = key;
            _notifications = new ObservableCollection<IStudioNotification>();
        }

        public string Title { get; set; }

        public IStudioNotificationCommand Action { get => null; set { } }

        public bool IsActionVisible { get => false; set { } }

        public string Key { get; }

        public ObservableCollection<IStudioNotification> Notifications { get => _notifications; set { } }
    }
}
