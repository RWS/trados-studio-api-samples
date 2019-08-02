using Sdl.Desktop.IntegrationApi;
using Sdl.Desktop.IntegrationApi.Extensions;
using Sdl.Desktop.IntegrationApi.Interfaces;
using Sdl.Desktop.IntegrationApi.Notifications.Events;
using Sdl.TranslationStudioAutomation.IntegrationApi;
using System;
using System.Collections.Generic;

namespace Sdl.Notifications.Sample
{
    [Action("AddNotificationOrCreateGroup", Icon = "MyAction_Icon", Name = "AddNotificationOrCreateGroup_Name", Description = "AddNotificationOrCreateGroup_Description")]
    [ActionLayout(typeof(MySampleRibbonGroup), 10, DisplayType.Large)]
    public class AddNotificationOrCreateGroup : AbstractAction
    {
        private const string NotificationGroupId = "6c46719f-a179-4cd6-952f-3ac56c29f521";
        private const string NotificationGroupTitle = "Sample Group Notification";

        protected override void Execute()
        {
            //create a unique identifier for the notification
            var notificationId = Guid.NewGuid();
            //create an instance of IStudioNotification
            var completeNotification = new StudioTestNotification(notificationId)
            {
                Title = "Another Sample Notification Title",
                AlwaysVisibleDetails = new List<string> { "This is a sample notification that will be added to an existing group or that will create a new one in case the group does not exist." },
                AllowsUserToDismiss = true,
                ClearNotificationAction = new ClearNotificationAction(NotificationGroupId, notificationId),
                IsExpanderVisible = false,
                IsLinkVisible = true,
                LinkAction = new OpenLinkCommand("https://appstore.sdl.com/language/developers/sdk.html")
                {
                    CommandText = "Learn more on the Studio 2019 SDK",
                    CommandToolTip = "Learn more on the Studio 2019 SDK"
                },
                IsActionVisible = false
            };

            //create an instance of the event
            var addTestGroup = new AddStudioNotificationOrCreateGroupEvent(NotificationGroupId, completeNotification, NotificationGroupTitle);
            //publish the event via the Event Aggregator
            var ea = SdlTradosStudio.Application.GetService<IStudioEventAggregator>();
            ea.Publish(addTestGroup);
        }
    }
}