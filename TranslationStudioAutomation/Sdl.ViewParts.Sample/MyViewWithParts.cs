using Sdl.Desktop.IntegrationApi;
using Sdl.Desktop.IntegrationApi.Extensions;
using Sdl.TranslationStudioAutomation.IntegrationApi.Presentation.DefaultLocations;

namespace Sdl.ViewParts.Sample
{
    [View(
        Id = "MyViewWithViewParts",
        Name = "My View with ViewParts",
        Description = "Sample of a view which allows view parts",
        LocationByType = typeof(TranslationStudioDefaultViews.TradosStudioViewsLocation),
        AllowViewParts = true)]
    class MyViewWithParts : AbstractViewController
    {
        protected override void Initialize(IViewContext context)
        {
        }
    }
}
