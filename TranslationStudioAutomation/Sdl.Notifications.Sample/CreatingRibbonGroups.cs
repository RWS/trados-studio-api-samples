using Sdl.Desktop.IntegrationApi;
using Sdl.Desktop.IntegrationApi.Extensions;
using Sdl.TranslationStudioAutomation.IntegrationApi.Presentation.DefaultLocations;

namespace Sdl.Notifications.Sample
{
	[RibbonGroup("MyNotificationsSampleRibbonGroup")]
	[RibbonGroupLayout(LocationByType = typeof(TranslationStudioDefaultRibbonTabs.HomeRibbonTabLocation))]
	class MySampleRibbonGroup : AbstractRibbonGroup
	{
	}
}
