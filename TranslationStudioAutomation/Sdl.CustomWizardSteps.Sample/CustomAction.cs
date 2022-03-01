using Microsoft.Win32;
using Sdl.CustomWizardSteps.Sample.CustomPages;
using Sdl.Desktop.IntegrationApi;
using Sdl.Desktop.IntegrationApi.Extensions;
using Sdl.Desktop.IntegrationApi.Interfaces;
using Sdl.Desktop.IntegrationApi.Wizard;
using Sdl.TranslationStudioAutomation.IntegrationApi.Actions;
using Sdl.TranslationStudioAutomation.IntegrationApi.Events;
using Sdl.TranslationStudioAutomation.IntegrationApi.Presentation.DefaultLocations;
using System;
using System.Collections.Generic;
using System.Windows;

namespace Sdl.PackagesOperations.Sample
{
    [Action(
        Id = "CustomAction",
        Name = "Custom Open Package",
        Description = "Starts the customized open package wizard",
        Icon = "CustomActionIcon"
    )]
    [ActionLayout(typeof(MySampleRibbonGroup), 10, DisplayType.Large)]
    public class MyCustomAction : AbstractAction
    {
        private readonly AbstractApplication _app;
        private readonly IStudioEventAggregator _eventAggregator;

        public MyCustomAction()
        {
            _app = new StudioApplication();
            _eventAggregator = _app.GetService<IStudioEventAggregator>();
        }

        protected override void Execute()
        {
            try
            {
                var fileDialog = new OpenFileDialog { Filter = "SDL packages (*.sdlppx)|*.sdlppx|SDL return packages (*.sdlrpx)|*.sdlrpx|World Server packages (*.wsxz)|*.wsxz" };
                if (fileDialog.ShowDialog() != true)
                {
                    return;
                }
                var filePath = fileDialog.FileName;

                var initialWizardSteps = new List<StudioWizardPage>
                {
                    new FirstPage(),
                    new SecondPage()
                };

                _eventAggregator.Publish(
                    new OpenProjectPackageEvent(
                        packageFilePath: filePath, job: null, iconPath: null, projectOrigin: null,
                        firstPages: initialWizardSteps));
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }

    [RibbonGroup("MySampleRibbonGroup")]
    [RibbonGroupLayout(LocationByType = typeof(TranslationStudioDefaultRibbonTabs.HomeRibbonTabLocation))]
    class MySampleRibbonGroup : AbstractRibbonGroup
    {
    }
}
