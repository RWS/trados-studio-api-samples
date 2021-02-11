using Sdl.Desktop.IntegrationApi;
using Sdl.Desktop.IntegrationApi.Extensions;
using Sdl.TranslationStudioAutomation.IntegrationApi.Presentation.DefaultLocations;

namespace Sdl.Logging.Sample
{
    [RibbonGroup("MyLoggingSampleRibbonGroup", Icon = "MyAction_Icon", Name = "MyLoggingSampleRibbonGroup_Name", Description = "MyLoggingSampleRibbonGroup_Description")]
    [RibbonGroupLayout(LocationByType = typeof(TranslationStudioDefaultRibbonTabs.HomeRibbonTabLocation))]
    internal class MySampleRibbonGroup : AbstractRibbonGroup
    {
    }
}
