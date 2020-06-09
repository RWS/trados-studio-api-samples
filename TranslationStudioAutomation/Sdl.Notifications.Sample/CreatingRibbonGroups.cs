using Sdl.Desktop.IntegrationApi;
using Sdl.Desktop.IntegrationApi.Extensions;
using Sdl.TranslationStudioAutomation.IntegrationApi.Presentation.DefaultLocations;

namespace Sdl.Notifications.Sample
{
    [RibbonGroup("MyNotificationsSampleRibbonGroup", Icon = "MyAction_Icon", Name = "MyNotificationsSampleRibbonGroup_Name", Description = "MyNotificationsSampleRibbonGroup_Description")]
    [RibbonGroupLayout(LocationByType = typeof(TranslationStudioDefaultRibbonTabs.HomeRibbonTabLocation))]
    internal class MySampleRibbonGroup : AbstractRibbonGroup
    {
    }
}
