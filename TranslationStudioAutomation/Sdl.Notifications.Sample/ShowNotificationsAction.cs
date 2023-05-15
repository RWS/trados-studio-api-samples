using Sdl.Desktop.IntegrationApi;
using Sdl.Desktop.IntegrationApi.Extensions;
using Sdl.Desktop.IntegrationApi.Interfaces;
using Sdl.Desktop.IntegrationApi.Notifications.Events;
using Sdl.TranslationStudioAutomation.IntegrationApi;

namespace Sdl.Notifications.Sample
{
	[Action("MyShowNotificationAction", Icon = "MyAction_Icon", Name = "MyShowNotificationAction_Name", Description = "MyShowNotificationAction_Description")]
	[ActionLayout(typeof(MySampleRibbonGroup), 10, DisplayType.Large)]
	public class ShowNotificationsAction : AbstractAction
	{
		protected override void Execute()
		{
			var ea = SdlTradosStudio.Application.GetService<IStudioEventAggregator>();

			var showNotification = new ShowStudioNotificationsViewEvent(true, true);

			ea.Publish(showNotification);
		}
	}
}