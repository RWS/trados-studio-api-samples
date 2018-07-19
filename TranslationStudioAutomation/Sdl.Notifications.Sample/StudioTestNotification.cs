using Sdl.Desktop.IntegrationApi.Interfaces;
using System;
using System.Collections.Generic;

namespace Sdl.Notifications.Sample
{
    class StudioTestNotification : IStudioNotification
    {
        private Guid guid;

        public StudioTestNotification(Guid guid)
        {
            this.guid = guid;
        }

        public Guid Id => new Guid();

        public string Title { get; set; }

        public IStudioNotificationCommand LinkAction { get => null; set { } }

        public bool IsExpanderVisible { get => false; set { } }

        public bool IsLinkVisible { get => false; set { } }

        public List<string> AlwaysVisibleDetails { get; set; }

        public List<string> OtherDetails { get; set; }

        public IStudioNotificationCommand Action { get => null; set { } }

        public bool IsActionVisible { get => false; set { } }
    }
}
