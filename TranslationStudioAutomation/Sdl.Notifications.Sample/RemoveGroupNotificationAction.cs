using System;
using System.Collections.Generic;
using Sdl.Desktop.IntegrationApi;
using Sdl.Desktop.IntegrationApi.Extensions;
using Sdl.Desktop.IntegrationApi.Interfaces;
using Sdl.Desktop.IntegrationApi.Notifications.Events;
using Sdl.TranslationStudioAutomation.IntegrationApi;

namespace Sdl.Notifications.Sample
{
	[Action("MyRemoveGroupNotificationAction", Icon = "MyAction_Icon", Name = "MyRemoveGroupNotificationAction_Name", Description = "MyRemoveGroupNotificationAction_Description")]
	[ActionLayout(typeof(MySampleRibbonGroup), 10, DisplayType.Large)]
	public class RemoveGroupNotificationAction : AbstractAction
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

			// remove group notification
			var removeTestGroup = new RemoveStudioGroupNotificationEvent(NotificationGroupId);
			ea.Publish(removeTestGroup);
		}
	}
}
