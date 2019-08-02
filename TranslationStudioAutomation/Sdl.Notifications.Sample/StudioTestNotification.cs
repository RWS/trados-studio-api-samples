using Sdl.Desktop.IntegrationApi.Interfaces;
using System;
using System.Collections.Generic;

namespace Sdl.Notifications.Sample
{
    public class StudioTestNotification : IStudioNotification
    {
        public StudioTestNotification(Guid guid)
        {
            Id = guid;
        }

        public Guid Id { get; set; }

        public string Title { get; set; }

        public IStudioNotificationCommand LinkAction { get; set; }

        public bool IsExpanderVisible { get; set; }

        public bool IsLinkVisible { get; set; }

        public List<string> AlwaysVisibleDetails { get; set; }

        public List<string> OtherDetails { get; set; }

        public IStudioNotificationCommand Action { get; set; }

        public bool IsActionVisible { get; set; }

        public bool AllowsUserToDismiss { get; set; }

        public IStudioNotificationCommand ClearNotificationAction { get; set; }
    }
}
