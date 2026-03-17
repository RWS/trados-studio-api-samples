using System;
using System.Windows.Forms;
using Sdl.SDK.LanguagePlatform.Samples.BatchImporter;

namespace Sdl.SDK.LanguagePlatform.Samples.TmLookup
{
	internal static class Program
	{
		[STAThread]
		private static void Main()
		{
			// Register the assembly resolver to be able to find Trados Studio assemblies
			// not needed if the application is run from a folder where Studio is installed
			// or if all the required assemblies are copied to the application folder
			StudioAssemblyResolver.Register();

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new frmLookup());
		}
	}
}
