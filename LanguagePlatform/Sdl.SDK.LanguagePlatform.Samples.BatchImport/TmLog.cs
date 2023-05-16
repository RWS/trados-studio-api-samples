using System.IO;
using Sdl.LanguagePlatform.TranslationMemoryApi;

namespace Sdl.SDK.LanguagePlatform.Samples.BatchImporter
{
	/// <summary>
	/// Represents file logging functionality.
	/// </summary>
	public class TMLog
	{
		/// <summary>
		/// This function is used to create a log file after
		/// the import operation has finished. The log file
		/// shows which master TMs have been created in the process
		/// as well as the total TU count for each master TM.
		/// </summary>
		/// <param name="translationMemoryPath">Path to translation memory.</param>
		public void CreateLogFile(string translationMemoryPath)
		{
			TextWriter log = new StreamWriter(translationMemoryPath + @"\log.txt");

			string[] translationMemoryFiles = Directory.GetFiles(@"c:\MasterTMs");
			foreach (string file in translationMemoryFiles)
			{
				log.WriteLine(file);
				FileBasedTranslationMemory tm = new FileBasedTranslationMemory(file);
				log.WriteLine("TU Count: " + tm.GetTranslationUnitCount().ToString());
				log.WriteLine();
			}

			log.Close();
		}
	}
}
