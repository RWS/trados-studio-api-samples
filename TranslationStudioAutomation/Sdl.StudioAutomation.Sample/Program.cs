using Sdl.TranslationStudioAutomation.Licensing;
using System;
using System.Windows.Forms;

namespace Sdl.SDK.TranslationStudioAutomation
{
    static class Program
    {
        #region "Main"
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!LicenseChecker.IsFeatureLicensed(StudioFeature.AllowSupportingApplications))
            {
                //If the installed version of SDL Trados Studio does not support access by OpenExchange 
                //applications display an error message and quit
                MessageBox.Show(Properties.Resources.LicenseErrorMessage,
                                Properties.Resources.Title,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            else
            {

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new ShowStudioVersion());
            }
        }
        #endregion
    }
}
