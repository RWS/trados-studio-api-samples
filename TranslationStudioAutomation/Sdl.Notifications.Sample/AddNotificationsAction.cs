using Sdl.Desktop.IntegrationApi;
using Sdl.Desktop.IntegrationApi.Extensions;
using Sdl.Desktop.IntegrationApi.Interfaces;
using Sdl.Desktop.IntegrationApi.Notifications.Events;
using Sdl.TranslationStudioAutomation.IntegrationApi;
using System;
using System.Collections.Generic;

namespace Sdl.Notifications.Sample
{
    [Action("MyAddNotificationAction", Icon = "MyAction_Icon")]
    [ActionLayout(typeof(MySampleRibbonGroup), 10, DisplayType.Large)]
    public class AddNotificationsAction : AbstractAction
    {
        private const string NOTIFICATION_GROUP_ID = "6c46719f-a179-4cd6-952f-3ac56c29f521";
        protected override void Execute()
        {
            IStudioEventAggregator ea = SdlTradosStudio.Application.GetService<IStudioEventAggregator>();

            var notification1 = new StudioTestNotification(new Guid()) { Title = "Dog title", AlwaysVisibleDetails = new List<string> { "AAA", "BBB", "CCC" } };
            var addTestGroup1 = new AddStudioNotificationToGroupEvent(NOTIFICATION_GROUP_ID, notification1);

            ea.Publish<AddStudioNotificationToGroupEvent>(addTestGroup1);


            var notification2 = new StudioTestNotification(new Guid()) { Title = "Cat title", AlwaysVisibleDetails = new List<string> { "111"} };
            var addTestGroup2 = new AddStudioNotificationToGroupEvent(NOTIFICATION_GROUP_ID, notification2);

            ea.Publish<AddStudioNotificationToGroupEvent>(addTestGroup2);
        }
    }
}
