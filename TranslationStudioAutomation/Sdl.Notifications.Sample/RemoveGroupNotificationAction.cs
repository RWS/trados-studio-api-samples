using Sdl.Desktop.IntegrationApi;
using Sdl.Desktop.IntegrationApi.Extensions;
using Sdl.Desktop.IntegrationApi.Interfaces;
using Sdl.Desktop.IntegrationApi.Notifications.Events;
using Sdl.TranslationStudioAutomation.IntegrationApi;
using System;
using System.Collections.Generic;

namespace Sdl.Notifications.Sample
{
    [Action("MyRemoveGroupNotificationAction", Icon = "MyAction_Icon")]
    [ActionLayout(typeof(MySampleRibbonGroup), 10, DisplayType.Large)]
    public class RemoveGroupNotificationAction : AbstractAction
    {
        private const string NOTIFICATION_GROUP_ID = "6c46719f-a179-4cd6-952f-3ac56c29f521";

        protected override void Execute()
        {
            IStudioEventAggregator ea = SdlTradosStudio.Application.GetService<IStudioEventAggregator>();

            var notificationGroup = new StudioTestNotificationsGroup(NOTIFICATION_GROUP_ID)
            {
                Title = "First Group title"
            };

            notificationGroup.Notifications.Add(new StudioTestNotification(new Guid())
            {
                Title = "First notification title",
                AlwaysVisibleDetails = new List<string> { "First notification description" }
            });
            notificationGroup.Notifications.Add(new StudioTestNotification(new Guid())
            {
                Title = "Second notification title",
                AlwaysVisibleDetails = new List<string> { "Third notification  description", "Forth notification description" }
            });

            // add group notification
            var addTestGroup = new AddStudioGroupNotificationEvent(notificationGroup);
            ea.Publish(addTestGroup);

            // remove group notification
            var removeTestGroup = new RemoveStudioGroupNotificationEvent(NOTIFICATION_GROUP_ID);
            ea.Publish(removeTestGroup);
        }
    }
}
