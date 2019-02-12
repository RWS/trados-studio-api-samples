using Sdl.Desktop.IntegrationApi;
using Sdl.Desktop.IntegrationApi.Interfaces;
using Sdl.TranslationStudioAutomation.IntegrationApi.Actions;
using Sdl.TranslationStudioAutomation.IntegrationApi.Events;
using System;
using System.Windows.Forms;

namespace Sdl.PackagesOperations.Sample
{
    public partial class PackagesControl : UserControl
    {
        private AbstractApplication _app;
        public PackagesControl()
        {
            InitializeComponent();
            _app = new StudioApplication();
        }

        private void openPackageBtn_Click(object sender, EventArgs e)
        {
            _app.ExecuteAction<OpenPackageAction>();
        }

        private void openSpecificPackageBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (System.IO.File.Exists(packagePathTxt.Text))
                {
                    _app.GetService<IStudioEventAggregator>()
                        .Publish(new OpenProjectPackageEvent(packagePathTxt.Text));
                }
                else
                {
                    throw new Exception("Package file doesn't exist!");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void createReturnPackageBtn_Click(object sender, EventArgs e)
        {
            //create the Job object
            IRelayJob publishJob = new PublishJob("ID: " + packageIDTxt.Text);
            _app.GetService<IStudioEventAggregator>().Publish(new CreateReturnPackageEvent("Id", publishJob));
        }
    }
}
