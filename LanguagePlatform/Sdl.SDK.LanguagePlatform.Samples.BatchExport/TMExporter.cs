using System;
using System.Globalization;
using Sdl.LanguagePlatform.TranslationMemoryApi;

namespace Sdl.SDK.LanguagePlatform.Samples.BatchExport
{
	/// <summary>
	/// Represents functionality for exporting *.tmx files.
	/// </summary>
	public class TMExporter
	{
		/// <summary>
		/// Represents current export progress in presents.
		/// </summary>
		private int exportProgress = 0;

		/// <summary>
		/// This function performs the actual export operation.
		/// *.sdltm files are exported to *.tmx format.
		/// </summary>
		/// <param name="translationMemoryPath">FileBasedTranslationMemory to export into.</param>
		public void Export(string translationMemoryPath)
		{
			exportProgress = 0;
			FileBasedTranslationMemory tm = new FileBasedTranslationMemory(translationMemoryPath);
			TranslationMemoryExporter exporter = new TranslationMemoryExporter(tm.LanguageDirection);

			// set event handler
			exporter.BatchExported += new EventHandler<BatchExportedEventArgs>(Exporter_BatchExported);

			// The *.tmx export files have the same name as the original
			// *.sdltm files, including the language direction retrieved
			// from the file TM, e.g. "en-US_de-DE".
			string exportString = string.Format(
				CultureInfo.CurrentCulture,
				"{0}_{1}_{2}.tmx",
				translationMemoryPath,
				tm.LanguageDirection.SourceLanguage,
				tm.LanguageDirection.TargetLanguage);
			exporter.Export(exportString, true);

			Console.Write("Translation Units exported: {0} \n", exportProgress);
		}

		/// <summary>
		/// Updates the console with current export progress
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">Object containing current progress value and related info.</param>
		private void Exporter_BatchExported(object sender, BatchExportedEventArgs e)
		{
			exportProgress = e.TotalExported;
		}
	}
}