using Sdl.Desktop.IntegrationApi;
using Sdl.Desktop.IntegrationApi.Extensions;
using Sdl.Desktop.IntegrationApi.Interfaces;
using Sdl.Desktop.IntegrationApi.Notifications.Events;
using Sdl.TranslationStudioAutomation.IntegrationApi;
using System;

namespace Sdl.Notifications.Sample
{
    [Action("MyShowNotificationAction", Icon = "MyAction_Icon")]
    [ActionLayout(typeof(MySampleRibbonGroup), 10, DisplayType.Large)]
    public class ShowNotificationsAction : AbstractAction
    {
        protected override void Execute()
        {
            IStudioEventAggregator ea = SdlTradosStudio.Application.GetService<IStudioEventAggregator>();

            var showNotification = new ShowStudioNotificationsViewEvent(true, true);

            ea.Publish<ShowStudioNotificationsViewEvent>(showNotification);
        }
    }
}
