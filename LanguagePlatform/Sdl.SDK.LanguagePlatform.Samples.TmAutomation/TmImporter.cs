﻿using System;
using System.Windows.Forms;
using Sdl.Core.Globalization;
using Sdl.LanguagePlatform.TranslationMemory;
using Sdl.LanguagePlatform.TranslationMemoryApi;

namespace Sdl.SDK.LanguagePlatform.Samples.TmAutomation
{
	public class TMImporter
	{
		#region "import"
		public void ImportTMXFile(string tmPath, string importFilePath)
		{
			#region "CreateImporter"
			FileBasedTranslationMemory tm = new FileBasedTranslationMemory(tmPath);
			TranslationMemoryImporter importer = new TranslationMemoryImporter(tm.LanguageDirection);
			#endregion

			#region "chunk"
			importer.ChunkSize = 20;
			#endregion

			#region "GetSettings"
			GetImportSettings(importer.ImportSettings);
			#endregion

			#region "FireEvent"
			importer.BatchImported += new EventHandler<BatchImportedEventArgs>(Importer_BatchImported);
			#endregion

			#region "execute"
			importer.Import(importFilePath);
			#endregion
		}
		#endregion

		#region "event"
		private void Importer_BatchImported(object sender, BatchImportedEventArgs e)
		{
			string info;
			ImportStatistics stats = e.Statistics;

			info = "Total read: " + stats.TotalRead + "\n";
			info += "Total imported: " + stats.TotalImported + "\n";
			info += "TUs added: " + stats.AddedTranslationUnits + "\n";
			info += "TUs discarded: " + stats.DiscardedTranslationUnits + "\n";
			info += "TUs merged: " + stats.MergedTranslationUnits + "\n";
			info += "Errors: " + stats.Errors + "\n";

			MessageBox.Show(info, "Import statistics of current chunk");
			e.Cancel = false;
		}
		#endregion

		#region "settings"
		private void GetImportSettings(ImportSettings importSettings)
		{
			#region "sublanguages"
			importSettings.CheckMatchingSublanguages = false;
			#endregion

			#region "update"
			importSettings.ExistingFieldsUpdateMode = ImportSettings.FieldUpdateMode.Merge;
			#endregion

			#region "ConfirmationLevels"
			ConfirmationLevel[] levels = { ConfirmationLevel.ApprovedTranslation, ConfirmationLevel.Translated };
			importSettings.ConfirmationLevels = levels;
			#endregion

			#region "InvalidPath"
			importSettings.InvalidTranslationUnitsExportPath = @"c:\temp\invalid.tmx";
			#endregion

			#region "overwrite"
			importSettings.ExistingTUsUpdateMode = ImportSettings.TUUpdateMode.Overwrite;
			#endregion

			#region "PlainText"
			importSettings.PlainText = false;
			importSettings.TagCountLimit = 10;
			#endregion

			#region "UsageCount"
			importSettings.IncrementUsageCount = true;
			#endregion
		}
		#endregion
	}
}
