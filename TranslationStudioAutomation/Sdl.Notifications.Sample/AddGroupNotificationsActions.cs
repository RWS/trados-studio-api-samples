using Sdl.Desktop.IntegrationApi;
using Sdl.Desktop.IntegrationApi.Extensions;
using Sdl.Desktop.IntegrationApi.Interfaces;
using Sdl.Desktop.IntegrationApi.Notifications.Events;
using Sdl.TranslationStudioAutomation.IntegrationApi;
using System;
using System.Collections.Generic;

namespace Sdl.Notifications.Sample
{
    [Action("MyAddGroupNotificationAction", Icon = "MyAction_Icon", Name = "MyAddGroupNotificationAction_Name", Description = "MyAddGroupNotificationAction_Description")]
    [ActionLayout(typeof(MySampleRibbonGroup), 10, DisplayType.Large)]
    public class AddGroupNotificationsAction : AbstractAction
    {
        private const string NotificationGroupId = "6c46719f-a179-4cd6-952f-3ac56c29f521";
        private const string NotificationGroupTitle = "Sample Group Notification";

        protected override void Execute()
        {
            var ea = SdlTradosStudio.Application.GetService<IStudioEventAggregator>();

            var notificationGroup = new StudioTestNotificationsGroup(NotificationGroupId)
            {
                Title = NotificationGroupTitle,
                IsActionVisible = true,
                Action = new BasicCommand()
                {
                    CommandIcon = ImageResources.MyAction
                }
            };

            var notificationId = Guid.NewGuid();
            var completeNotification = new StudioTestNotification(notificationId)
            {
                Title = "Sample Notification Title",
                AlwaysVisibleDetails = new List<string> { "This is a sample notification that has all the elements of a notification visible" },
                OtherDetails = new List<string> { "Use this section to display additional details within a notifcation.", "These details can be seen / hidden as per user needs" },
                AllowsUserToDismiss = true,
                ClearNotificationAction = new ClearNotificationAction(NotificationGroupId, notificationId),
                IsExpanderVisible = true,
                IsLinkVisible = true,
                LinkAction = new OpenLinkCommand("https://appstore.sdl.com/language/developers/sdk.html")
                {
                    CommandText = "Learn more on the Studio 2019 SDK",
                    CommandToolTip = "Learn more on the Studio 2019 SDK"
                },
                IsActionVisible = true,
                Action = new BasicCommand()
                {
                    CommandText = "Click me!",
                    CommandToolTip = "Click me!",
                    CommandIcon = ImageResources.MyAction
                }
            };


            notificationGroup.Notifications.Add(completeNotification);

            var addTestGroup = new AddStudioGroupNotificationEvent(notificationGroup);

            ea.Publish(addTestGroup);
        }
    }
}