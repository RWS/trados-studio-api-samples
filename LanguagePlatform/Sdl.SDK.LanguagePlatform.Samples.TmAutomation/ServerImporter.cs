namespace Sdl.SDK.LanguagePlatform.Samples.TmAutomation
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Windows.Forms;
    using Sdl.LanguagePlatform.TranslationMemory;
    using Sdl.LanguagePlatform.TranslationMemoryApi;

    public class ServerImporter
    {
        public void ImportTmx(TranslationProviderServer tmServer, string orgName, string tmName, string importFilePath)
        {
            if (!orgName.StartsWith("/")) orgName = "/" + orgName;
            if (!orgName.EndsWith("/")) orgName += "/";
            #region "OpenTm"
            ServerBasedTranslationMemory tm = tmServer.GetTranslationMemory(
                orgName + tmName, TranslationMemoryProperties.All);
            #endregion

            #region "importer"
            ScheduledServerTranslationMemoryImport importer = new ScheduledServerTranslationMemoryImport(
                GetLanguageDirection(tm, CultureInfo.GetCultureInfo("en-US"), CultureInfo.GetCultureInfo("de-DE")));
            #endregion

            #region "params"
            importer.ChunkSize = 25;
            importer.ContinueOnError = true;
            importer.Source = new FileInfo(importFilePath);
            GetImportSettings(importer.ImportSettings);
            #endregion

            #region "upload"
            
            importer.Queue();
            #endregion

            #region "wait"
            bool continueWaiting = true;
            while (continueWaiting)
            {
                switch (importer.Status)
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
                        importer.Refresh(); 
                        break;
                    default:
                        continueWaiting = false;
                        break;
                }
            }
            #endregion

            #region "completed"
            if (importer.Status == ScheduledOperationStatus.Completed)
            {
                MessageBox.Show("Import successfuly finished.");
            }
            else if (importer.Status == ScheduledOperationStatus.Error)
            {
                MessageBox.Show(importer.ErrorMessage);
            }
            else
            {
                MessageBox.Show("Import didn't finish.");
            }
            #endregion
        }

        #region "settings"
        private void GetImportSettings(Sdl.LanguagePlatform.TranslationMemory.ImportSettings importSettings)
        {
            if (importSettings == null)
            {
                importSettings = new ImportSettings();
            }

            importSettings.CheckMatchingSublanguages = true;
            importSettings.ExistingTUsUpdateMode = ImportSettings.TUUpdateMode.Overwrite;
        }
        #endregion

        #region "LanguageDirection"
        private ServerBasedTranslationMemoryLanguageDirection GetLanguageDirection(ServerBasedTranslationMemory tm, CultureInfo source, CultureInfo target)
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

        #region "event"
        private void importer_Uploaded(object sender, FileTransferEventArgs e)
        {
            MessageBox.Show("Transferred - " + e.BytesTransferred.ToString() + " out of " + e.TotalBytes.ToString() + " bytes\r\n");
            e.Cancel = false;
        }
        #endregion
    }
}
