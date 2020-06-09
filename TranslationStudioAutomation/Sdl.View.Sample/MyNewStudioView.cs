using Sdl.Desktop.IntegrationApi;
using Sdl.Desktop.IntegrationApi.Extensions;
using Sdl.Desktop.IntegrationApi.Interfaces;
using Sdl.TranslationStudioAutomation.IntegrationApi.Presentation.DefaultLocations;
using System;
using System.Windows.Forms;

namespace Sdl.View.Sample
{
    [View(
        Id = "MyView",
        Name = "My New View",
        Description = "This is an implemention of My View",
        LocationByType = typeof(TranslationStudioDefaultViews.TradosStudioViewsLocation))]
    class MyNewStudioView : AbstractViewController
    {
        protected override IUIControl GetContentControl()
        {
            return _viewContent.Value;
        }

        protected override void Initialize(IViewContext context)
        {
            //bind the activation and deactivation events of the view.
            ActivationChanged += OnActivationChanged;
        }

        private void OnActivationChanged(object sender, ActivationChangedEventArgs e)
        {
            if (e.Active)
            {
                //active a view watch when the view became active
                StudioTracking.Instance.GetViewWatch<MyNewStudioView>()
                              .Start();
            }
            else
            {
                //stop the attached view watch when the view became deactivated.
                StudioTracking.Instance.GetViewWatch<MyNewStudioView>()
                              .Stop();

                //show a message box with the time spent by the user on this view.
                MessageBox.Show(string.Format("You've been using the view for {0}",
                                              StudioTracking.Instance.GetViewWatch<MyNewStudioView>().Elapsed));
            }
        }

        private readonly Lazy<MyNewViewContent> _viewContent = new Lazy<MyNewViewContent>();
    }
}