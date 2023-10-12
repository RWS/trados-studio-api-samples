using Sdl.Desktop.IntegrationApi;
using Sdl.Desktop.IntegrationApi.Extensions;
using Sdl.TranslationStudioAutomation.Licensing;
using System;
using System.Windows.Forms;

namespace Sdl.License.Sample
{
    #region License action   

    [Action("MyLicenseAction", Icon = "LicenseIcon")]
    [ActionLayout(typeof(MySampleRibbonGroup), 10, DisplayType.Large)]
    [Shortcut(Keys.Alt | Keys.F8)]
    public class MyLicenseAction : AbstractAction
    {
        protected override void Execute()
        {
            if (!LicenseChecker.IsFeatureLicensed(StudioFeature.AllowSupportingApplications))
            {
                //If the installed version of SDL Trados Studio does not support access by OpenExchange 
                //applications display an error message and quit
                MessageBox.Show(PluginResources.LicenseErrorMessage,
                                PluginResources.Title,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            else
            {
                var form = new ShowStudioVersion();
                form.ShowDialog();
            }
        }
    }

    #endregion

}
