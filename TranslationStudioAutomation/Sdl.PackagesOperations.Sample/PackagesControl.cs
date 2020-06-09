using Sdl.Desktop.IntegrationApi;
using Sdl.Desktop.IntegrationApi.Interfaces;
using Sdl.TranslationStudioAutomation.IntegrationApi;
using Sdl.TranslationStudioAutomation.IntegrationApi.Actions;
using Sdl.TranslationStudioAutomation.IntegrationApi.Events;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Sdl.PackagesOperations.Sample
{
    public partial class PackagesControl : UserControl, IUIControl
    {
        private readonly AbstractApplication _app;
        private readonly IStudioEventAggregator _eventAggregator;

        public PackagesControl()
        {
            InitializeComponent();
            _app = new StudioApplication();
            _eventAggregator = _app.GetService<IStudioEventAggregator>();
        }

        private void openPackage(object sender, EventArgs e)
        {
            try
            {
                if (System.IO.File.Exists(textBoxPackagePath.Text))
                {
                    var publishJob = new SampleJob() { JobName = "Sample" };
                    if (System.IO.File.Exists(textBoxIconPath.Text) && !string.IsNullOrWhiteSpace(textBoxProjectType.Text))
                    {
                        _eventAggregator.Publish(new OpenProjectPackageEvent(textBoxPackagePath.Text, publishJob, textBoxIconPath.Text, textBoxProjectType.Text));
                        return;
                    }

                    _eventAggregator.Publish(new OpenProjectPackageEvent(textBoxPackagePath.Text, publishJob));
                    return;
                }
                _app.ExecuteAction<OpenPackageAction>();

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void createReturnPackageBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxJobName.Text))
            {
                return;
            }

            //create the Job object
            var publishJob = new SampleJob() { JobName = textBoxJobName.Text };
            var currentProject = SdlTradosStudio.Application.GetController<ProjectsController>().CurrentProject;
            if (currentProject != null)
            {
                var selectedProject = currentProject.GetProjectInfo().Id.ToString();
                _eventAggregator.Publish(new CreateReturnPackageEvent(selectedProject, publishJob));
            }
        }

        private void ButtonBrowseIcon_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog
            {
                Title = "Browse for icon",
                DefaultExt = "ico",
                Filter = "Icon (*.ico)|*.ico"
            };
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxIconPath.Text = fileDialog.FileName;
            }

        }

        private void ButtonBrowsePackagePath_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog
            {
                Title = "Browse for package",
                DefaultExt = "ico",
                Filter = "SDL Trados Studio packages (*.sdlppx;*.sdlrpx,)|*.sdlppx;*.sdlrpx"
            };
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxPackagePath.Text = fileDialog.FileName;
            }
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            textBoxPackagePath.Clear();
            textBoxIconPath.Clear();
            textBoxProjectType.Clear();
        }

        private void ButtonOpenProjectWizard_Click(object sender, EventArgs e)
        {
            ProjectWizardData wizardData = null;
            if (!string.IsNullOrWhiteSpace(textBoxProjectName.Text) || !string.IsNullOrWhiteSpace(textBoxFile.Text))
            {
                wizardData = new ProjectWizardData()
                {
                    ProjectName = textBoxProjectName.Text,
                    Content = new List<string>() { textBoxFile.Text }
                };
            }

            _eventAggregator.Publish(new OpenNewProjectWizardEvent(wizardData));
        }

        private void buttonBrowseProjectFile_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog
            {
                Title = "Browse for file"

            };
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxFile.Text = fileDialog.FileName;
            }
        }

        private void ButtonClearProjectData_Click(object sender, EventArgs e)
        {
            textBoxFile.Clear();
            textBoxProjectName.Clear();
        }
    }
}
