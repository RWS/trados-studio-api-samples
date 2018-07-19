using Sdl.Desktop.IntegrationApi;
using Sdl.Desktop.IntegrationApi.Extensions;
using Sdl.Desktop.IntegrationApi.Interfaces;
using Sdl.Desktop.IntegrationApi.Notifications.Events;
using Sdl.TranslationStudioAutomation.IntegrationApi;
using System;
using System.Collections.Generic;


namespace Sdl.Notifications.Sample
{
    [Action("MyAddGroupNotificationAction", Icon = "MyAction_Icon")]
    [ActionLayout(typeof(MySampleRibbonGroup), 10, DisplayType.Large)]
    public class AddGroupNotificationsAction : AbstractAction
    {
        private const string NOTIFICATION_GROUP_ID = "6c46719f-a179-4cd6-952f-3ac56c29f521";
        private const string NOTIFICATION_GROUP_TITLE = "Test title";

        protected override void Execute()
        {
            IStudioEventAggregator ea = SdlTradosStudio.Application.GetService<IStudioEventAggregator>();

            var notificationGroup = new StudioTestNotificationsGroup(new Guid(NOTIFICATION_GROUP_ID), NOTIFICATION_GROUP_ID)
            {
                Title = NOTIFICATION_GROUP_TITLE
            };

            notificationGroup.Notifications.Add(new StudioTestNotification(new Guid()) { Title = "First G title", AlwaysVisibleDetails = new List<string> { "First G description" } });
            notificationGroup.Notifications.Add(new StudioTestNotification(new Guid()) { Title = "Second G title", AlwaysVisibleDetails = new List<string> { "Third G  description", "Forth G description" } });

            var addTestGroup = new AddStudioGroupNotificationEvent(notificationGroup);

            ea.Publish<AddStudioGroupNotificationEvent>(addTestGroup);

          
        }
    }
}