using Sdl.Desktop.IntegrationApi.Wizard;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Sdl.CustomWizardSteps.Sample.CustomPages
{
    internal class FirstPage : StudioWizardPage
    {
        private readonly FirstPageViewModel _viewModel;
        private readonly Browser _browser;

        public FirstPage(Browser browser)
        {
            _viewModel = new FirstPageViewModel();
            _browser = browser;
        }

        public override string Id => "FirstPage";

        public override string Title => "First page";

        public override string Description => "First page description";

        public override Icon Icon => PluginResources.FirstIcon;

        public override Type ViewType => typeof(FirstPageView);

        public override INotifyPropertyChanged ViewModel => _viewModel;

        public override void ShowHelp()
        {
            _browser.OpenUrl("https://docs.rws.com/");
        }

        public override bool Submit()
        {
            Data[CustomDataKeys.SelectedDate] = _viewModel.CurrentDate;
            return base.Submit();
        }
    }
}
