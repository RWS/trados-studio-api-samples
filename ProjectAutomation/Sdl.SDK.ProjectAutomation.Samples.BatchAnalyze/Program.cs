namespace Sdl.SDK.ProjectAutomation.Samples.BatchAnaylze
{
    using Sdl.TranslationStudioAutomation.Licensing;
    using System;
	using System.IO;

	public class Program
	{
		public static void Main(string[] args)
		{
			bool processSubFolders = false;
			bool reportCrossFileRepetitions = false;
			bool reportInternalFuzzyMatchLeverage = false;
			bool keepProjectFiles = false;
			bool publishToServer = false;

			if (args.Length < 2)
			{
				Console.WriteLine("Usage:");
				Console.WriteLine("Sdl.SDK.ProjectAutomation.Samples.BatchAnalyze.exe <source> <tm> [/c] [/i] [/k] [/s]");
				Console.WriteLine("<source> Path to a folder that contains the source files to process.");
				Console.WriteLine("<tm> Path to a TM file or server TM name");
				Console.WriteLine("/c   cross-file repetitions should be reported");
				Console.WriteLine("/i   internal fuzzy match leverage should be reported");
				Console.WriteLine("/k   keep project files");
				Console.WriteLine("/s   sub-folders should be processed");
				Console.WriteLine("/p   publish to a server");
				return;
			}

			if (!string.IsNullOrEmpty(args[0]) && !Directory.Exists(args[0])
				&& !string.IsNullOrEmpty(args[1]))
			{
				Console.WriteLine("Please specify a valid input directory and a valid TM. Press ENTER to exit.");
				return;
			}

			string mainPath = args[0];
			string tmFile = args[1];

			for (int i = 2; i < args.Length; ++i)
			{
				switch (args[i])
				{
					case "/c":
						reportCrossFileRepetitions = true;
						break;
					case "/i":
						reportInternalFuzzyMatchLeverage = true;
						break;
					case "/k":
						keepProjectFiles = true;
						break;
					case "/s":
						processSubFolders = true;
						break;
					case "/p":
						publishToServer = true;
						break;
				}
			}

			if (!publishToServer && !File.Exists(args[1]))
			{
				Console.WriteLine("Please specify a valid file TM. Press ENTER to exit.");
				return;
			}

			try
			{
				ProjectCreator process = new ProjectCreator();
				process.Create(
					mainPath,
					tmFile,
					processSubFolders,
					reportCrossFileRepetitions,
					reportInternalFuzzyMatchLeverage,
					keepProjectFiles, publishToServer);

				Console.WriteLine();
				Console.WriteLine("Analyze files report created successfully. Press ENTER to exit.");
				Console.ReadLine();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				Console.ReadLine();
			}
			finally 
			{
                LicenseManager.ReleaseLicense();
            }
		}
	}
}