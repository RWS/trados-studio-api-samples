using System;
using System.Text;
using System.Windows.Forms;

namespace Sdl.SDK.LanguagePlatform.TMAutomation
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            ShowException(e.ExceptionObject as Exception);
        }

        private static void ShowException(Exception ex)
        {
            if (ex != null)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(ex.Message);
                sb.AppendLine(ex.Source);
                sb.AppendLine(ex.StackTrace);

                MessageBox.Show(sb.ToString(), "Error", MessageBoxButtons.OK);
            }
        }
    }
}
