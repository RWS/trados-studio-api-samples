﻿using System;
using System.IO;
using System.Windows.Forms;
using Sdl.Core.Globalization;
using Sdl.LanguagePlatform.TranslationMemoryApi;

namespace Sdl.SDK.LanguagePlatform.Samples.TmAutomation
{
	public class ServerExporter
	{
		public void ExportToTmx(TranslationProviderServer tmServer, string orgName, string tmName, string exportFilePath)
		{
			#region "OpenTm"
			if (!orgName.StartsWith("/"))
			{
				orgName = "/" + orgName;
			}

			if (!orgName.EndsWith("/"))
			{
				orgName += "/";
			}

			ServerBasedTranslationMemory tm = tmServer.GetTranslationMemory(
				orgName + tmName, TranslationMemoryProperties.All);
			#endregion

			#region "exporter"
			ScheduledServerTranslationMemoryExport exporter = new ScheduledServerTranslationMemoryExport(
				GetLanguageDirection(tm, new CultureCode("en-US"), new CultureCode("de-DE")));
			#endregion

			#region "settings"
			exporter.ChunkSize = 25;
			exporter.ContinueOnError = true;
			#endregion

			#region "wait"
			exporter.Queue();
			exporter.Refresh();

			bool continueWaiting = true;
			while (continueWaiting)
			{
				switch (exporter.Status)
				{
					case ScheduledOperationStatus.Abort:
					case ScheduledOperationStatus.Aborted:
					case ScheduledOperationStatus.Cancel:
					case ScheduledOperationStatus.Cancelled:
					case ScheduledOperationStatus.Completed:
					case ScheduledOperationStatus.Error:
						continueWaiting = false;
						break;
					case ScheduledOperationStatus.Aborting:
					case ScheduledOperationStatus.Allocated:
					case ScheduledOperationStatus.Cancelling:
					case ScheduledOperationStatus.NotSet:
					case ScheduledOperationStatus.Queued:
					case ScheduledOperationStatus.Recovered:
					case ScheduledOperationStatus.Recovering:
					case ScheduledOperationStatus.Recovery:
						continueWaiting = true;
						exporter.Refresh();
						break;
					default:
						continueWaiting = false;
						break;
				}
			}
			#endregion

			#region "completed"
			if (exporter.Status == ScheduledOperationStatus.Completed)
			{
				using (Stream outputStream = new FileStream(exportFilePath, FileMode.Create))
				{
					var result = exporter.DownloadExport(outputStream);
					if (result)
					{
						MessageBox.Show("Export successfuly finished.");
					}
				}

			}
			else if (exporter.Status == ScheduledOperationStatus.Error)
			{
				MessageBox.Show(exporter.ErrorMessage);
			}
			else
			{
				MessageBox.Show("Export did not finish.");
			}
			#endregion
		}

		#region "LanguageDirection"
		private ServerBasedTranslationMemoryLanguageDirection GetLanguageDirection(ServerBasedTranslationMemory tm, CultureCode source, CultureCode target)
		{
			foreach (ServerBasedTranslationMemoryLanguageDirection item in tm.LanguageDirections)
			{
				if (item.SourceLanguage == source && item.TargetLanguage == target)
				{
					return item;
				}
			}

			throw new Exception("Requested direction doesn't exist.");
		}
		#endregion
	}
}
