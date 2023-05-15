using System;
using System.Collections.Generic;
using Sdl.Desktop.IntegrationApi;
using Sdl.Desktop.IntegrationApi.Extensions;
using Sdl.Desktop.IntegrationApi.Interfaces;
using Sdl.Desktop.IntegrationApi.Notifications.Events;
using Sdl.TranslationStudioAutomation.IntegrationApi;

namespace Sdl.Notifications.Sample
{
	[Action("MyCompleteNotificationAction", Icon = "MyAction_Icon", Name = "MyCompleteNotificationAction_Name", Description = "MyCompleteNotificationAction_Description")]
	[ActionLayout(typeof(MySampleRibbonGroup), 10, DisplayType.Large)]
	public class CompleteNotificationFlowAction : AbstractAction
	{
		private const string NotificationGroupId = "6c46719f-a179-4cd6-952f-3ac56c29f521";

		protected override void Execute()
		{
			var ea = SdlTradosStudio.Application.GetService<IStudioEventAggregator>();

			var notificationGroup = new StudioTestNotificationsGroup(NotificationGroupId)
			{
				Title = "First Group title"
			};

			notificationGroup.Notifications.Add(new StudioTestNotification(Guid.NewGuid())
			{
				Title = "First notification title",
				AlwaysVisibleDetails = new List<string> { "First notification description" }
			});

			notificationGroup.Notifications.Add(new StudioTestNotification(Guid.NewGuid())
			{
				Title = "Second notification title",
				AlwaysVisibleDetails = new List<string> { "Third notification  description", "Forth notification description" }
			});

			// add group notification
			var addTestGroup = new AddStudioGroupNotificationEvent(notificationGroup);
			ea.Publish(addTestGroup);

			// Add 1 Notification to group
			var notification1 = new StudioTestNotification(Guid.NewGuid())
			{
				Title = "Dog title",
				AlwaysVisibleDetails = new List<string> { "AAA", "BBB", "CCC" }
			};
			var addTestNotification = new AddStudioNotificationToGroupEvent(NotificationGroupId, notification1);
			ea.Publish(addTestNotification);

			// show notifications and set focus
			var showNotification = new ShowStudioNotificationsViewEvent(showNotifications: true, setFocus: true);
			ea.Publish(showNotification);
		}
	}
}
