using System;
using System.Text;
using System.Windows.Forms;
using Sdl.SDK.LanguagePlatform.Samples.BatchImporter;

namespace Sdl.SDK.LanguagePlatform.TMAutomation
{
	internal static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		private static void Main()
		{
			// Register the assembly resolver to be able to find Trados Studio assemblies
			// not needed if the application is run from a folder where Studio is installed
			// or if all the required assemblies are copied to the application folder
			StudioAssemblyResolver.Register();

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

		private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
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
