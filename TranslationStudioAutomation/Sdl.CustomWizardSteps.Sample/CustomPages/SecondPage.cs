using Sdl.Desktop.IntegrationApi.Wizard;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Sdl.CustomWizardSteps.Sample.CustomPages
{
    internal class SecondPage : StudioWizardPage
    {
        private readonly SecondPageViewModel _viewModel;

        public SecondPage()
        {
            _viewModel = new SecondPageViewModel();
        }

        public override string Id => "SecondPage";

        public override string Title => "Second page";

        public override string Description => "Second page description";

        public override Icon Icon => PluginResources.SecondIcon;

        public override string HelpId => null;

        public override Type ViewType => typeof(SecondPageView);

        public override INotifyPropertyChanged ViewModel => _viewModel;

        public override void OnShow()
        {
            base.OnShow();

            _viewModel.SelectedDate = (DateTime)Data[CustomDataKeys.SelectedDate];
        }
    }
}
