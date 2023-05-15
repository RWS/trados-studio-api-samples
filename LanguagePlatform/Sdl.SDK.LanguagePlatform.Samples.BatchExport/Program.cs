namespace Sdl.SDK.LanguagePlatform.Samples.BatchExport
{
	using System;
	using System.IO;

	/// <summary>
	/// Main class of the program and entrance point.
	/// </summary>
	public class Program
	{
		/// <summary>
		/// Main entrance point of the program.
		/// </summary>
		/// <param name="args">Contain string parameters that are passed via the command line.</param>
		public static void Main(string[] args)
		{
			bool processSubFolders = false;

			if (args.Length != 2)
			{
				Console.WriteLine("Usage:");
				Console.WriteLine("Sdl.SDK.LanguagePlatform.Samples.BatchExport.exe source /y");
				Console.WriteLine("source   path to input folder");
				Console.WriteLine("/y   should process subfolders");
				Console.WriteLine("This application uses a hard-coded recursion level of up to 10 sub-folders.");
				return;
			}

			if (!string.IsNullOrEmpty(args[0]) && !Directory.Exists(args[0]))
			{
				Console.WriteLine("Specify valid input directory. Press ENTER to exit.");
				return;
			}

			string mainPath = args[0];

			if (!string.IsNullOrEmpty(args[1]) && args[1] == "/y")
			{
				processSubFolders = true;
			}

			try
			{
				TMIterator it = new TMIterator();
				it.ProcessDirectory(mainPath, processSubFolders);
				Console.WriteLine();
				Console.WriteLine("Batch export finished. Press ENTER to exit.");
				Console.ReadLine();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				Console.WriteLine("Press ENTER to exit.");
				Console.ReadLine();
			}
		}
	}
}