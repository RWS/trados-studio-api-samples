using Sdl.Desktop.IntegrationApi;
using Sdl.Desktop.IntegrationApi.Extensions;
using Sdl.Desktop.IntegrationApi.Interfaces;
using Sdl.Desktop.IntegrationApi.Notifications.Events;
using Sdl.TranslationStudioAutomation.IntegrationApi;
using Sdl.TranslationStudioAutomation.IntegrationApi.Presentation.DefaultLocations;
using System;
using System.Windows.Forms;

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
            var ea = SdlTradosStudio.Application.GetService<IStudioEventAggregator>();
            ea.GetEvent<StudioWindowCreatedNotificationEvent>().Subscribe(OnStudioWindowCreated);
        }

        private void OnStudioWindowCreated(StudioWindowCreatedNotificationEvent e)
        {
            MessageBox.Show("Studio was loaded");
        }
    }
}
