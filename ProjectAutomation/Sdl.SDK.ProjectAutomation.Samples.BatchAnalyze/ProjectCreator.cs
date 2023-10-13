namespace Sdl.SDK.ProjectAutomation.Samples.BatchAnaylze
{
    using Sdl.Core.Globalization;
    using Sdl.Core.Settings;
    using Sdl.LanguagePlatform.TranslationMemoryApi;
    using Sdl.ProjectAutomation.Core;
    using Sdl.ProjectAutomation.FileBased;
    using Sdl.ProjectAutomation.Settings;
    using System;
    using System.Globalization;
    using System.IO;

    public class ProjectCreator
    {
        #region "ReportId"
        private Guid reportId;
        #endregion

        #region "Create"
        #region "CreateMainFunction"
        /// <summary>
        /// Creates the actual project that is used as a container for
        /// the files to analyze. Triggers all subsequent helper function
        /// in sequence, i.e. adding the source files, the TM, configuring
        /// the task settings, and running the required tasks, 
        /// if required publishing the result to a project server
        /// </summary> 
        public void Create(
            string docFolder,
            string tmFile,
            bool recursion,
            bool reportCrossFileRepetitions,
            bool reportInternalFuzzyMatchLeverage,
            bool keepProjectFiles,
            bool publishToServer)
        #endregion

        {
            #region "RetrieveTmLanguages"

            FileBasedTranslationMemory fileTm = new FileBasedTranslationMemory(tmFile);
            string srcLocale = fileTm.LanguageDirection.SourceLanguage.ToString();
            string trgLocale = fileTm.LanguageDirection.TargetLanguage.ToString();

            #endregion

            #region "newProject"

            FileBasedProject newProject = new FileBasedProject(this.GetProjectInfo(srcLocale, trgLocale));

            #endregion

            #region "CallAddFiles"

            this.AddFiles(newProject, docFolder, recursion);

            #endregion

            if (publishToServer)
            {
                #region "CallAddServerTm"
                this.AddServerTm(newProject, "http://MyTMServerAddress", "/MyOrganizationPath", tmFile, false, "MyUserName", "MyPassword");
                #endregion
            }
            else
            {
                #region "CallAddTm"
                this.AddTm(newProject, tmFile);
                #endregion
            }


            #region "CallConvert"
            this.ConvertFiles(newProject);
            #endregion

            #region "CallGetAnalyzeSettings"
            this.GetAnalyzeSettings(
                newProject,
                trgLocale,
                reportCrossFileRepetitions,
                reportInternalFuzzyMatchLeverage);
            #endregion

            #region "CallRunFileAnalysis"
            this.RunFileAnalysis(newProject, trgLocale);
            #endregion

            #region "GenerateReports"
            this.CreateReports(newProject, docFolder);
            #endregion

            #region "Save"
            newProject.Save();
            #endregion

            #region "PublishToServer"

            newProject.PublishProject(
                new Uri("ps.http://MyProjectServer:80"),
                false,
                "MyUser",
                "MyPassword",
                "/MyOrganizationPath",
                null);
            #endregion

            #region "CallDeleteProject"
            if (!keepProjectFiles)
            {
                newProject.Delete();
            }
            #endregion
        }
        #endregion

        #region "GetProjectInfo"
        #region "GetProjectInfoFunction"
        /// <summary>
        /// Configures the project information, i.e. the project location (folder), the project name,
        /// and the source/target language.
        /// </summary> 
        private ProjectInfo GetProjectInfo(string srcLocale, string trgLocale)
        #endregion
        {
            #region "ProjectInfo"
            ProjectInfo info = new ProjectInfo();
            #endregion

            #region "ProjectName"
            string nameExt = DateTime.Now.ToString();
            nameExt = nameExt.Replace('.', '_');
            nameExt = nameExt.Replace(':', '_');
            nameExt = nameExt.Replace('/', '_');
            nameExt = nameExt.Replace(' ', 'T');
            info.Name = "BatchAnalyzer_" + nameExt;
            #endregion

            #region "ProjectFolder"
            string localProjectFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "Studio 2022",
                "Projects",
                info.Name);

            info.LocalProjectFolder = localProjectFolder;
            #endregion

            #region "SetProjectSourceLanguage"
            Language srcLang = new Language(CultureInfo.GetCultureInfo(srcLocale));
            info.SourceLanguage = srcLang;
            #endregion

            #region "SetProjectTargetLanguage"
            Language[] trgLang = new Language[] { new Language(CultureInfo.GetCultureInfo(trgLocale)) };
            info.TargetLanguages = trgLang;
            #endregion

            #region "ReturnInfo"
            return info;
            #endregion
        }
        #endregion

        #region "Addfolder"
        /// <summary>
        /// Adds the files from the specified folder to the project and sets the file use, e.g. translatable or reference.            
        /// </summary> 
        #region "AddFilesFunction"
        private void AddFiles(FileBasedProject project, string folder, bool recursion)
        #endregion
        {
            #region "AddFolderWithFiles"
            project.AddFolderWithFiles(folder, recursion);
            #endregion

            #region "GetSourceLanguageFiles"
            ProjectFile[] projectFiles = project.GetSourceLanguageFiles();

            AutomaticTask scan = project.RunAutomaticTask(
                projectFiles.GetIds(),
                AutomaticTaskTemplateIds.Scan);
            #endregion
        }
        #endregion

        #region "AddTm"
        /// <summary>
        /// Adds the TM that should be used for the analysis. The project languages are
        /// set according to the TM.
        /// </summary> 
        #region "AddTmFunction"
        private void AddTm(FileBasedProject project, string tmFilePath)
        #endregion
        {
            #region "TranslationProviderConfiguration"
            TranslationProviderConfiguration config = project.GetTranslationProviderConfiguration();
            #endregion

            #region "TranslationProviderCascadeEntry"
            TranslationProviderCascadeEntry tm = new TranslationProviderCascadeEntry(
                tmFilePath,
                true,
                true,
                false);
            config.Entries.Add(tm);

            project.UpdateTranslationProviderConfiguration(config);
            #endregion
        }
        #endregion

        #region "AddServerTm"
        #region "AddServerTmFunction"
        /// <summary>
        /// Add a server TM to be used for anaysis. The project languages are
        /// set according to the TM.
        /// </summary>
        private void AddServerTm(FileBasedProject project, string serverAddress, string organizationPath, string tmName, bool useWindowsSecurity, string username, string password)
        #endregion
        {
            #region "TranslationProviderConfiguration"
            Uri tmAddress = new Uri(string.Format("sdltm.{1}{2}/{3}", serverAddress, organizationPath, tmName));
            TranslationProviderConfiguration config = project.GetTranslationProviderConfiguration();
            #endregion

            #region "TranslationProviderCascadeEntryForServerTM"
            TranslationProviderCascadeEntry tm = new TranslationProviderCascadeEntry
            (
                  new TranslationProviderReference(tmAddress),
                  true,
                  false,
                  false
            );
            config.Entries.Add(tm);
            project.UpdateTranslationProviderConfiguration(config);
            #endregion

            #region "CredentialsForServerTm"
            project.Credentials.AddCredential(new Uri(serverAddress), string.Format("user={0};password={1};type=CustomUser", username, password, useWindowsSecurity ? "WindowsUser" : "CustomUser"));
            project.UpdateTranslationProviderConfiguration(config);
            #endregion
        }
        #endregion

        #region "ConvertAndCopy"
        /// <summary>
        /// Runs the two automatic tasks: Convert translatable files to a translatable format (i.e. SDL XLIFF)
        /// and creates target file copies.
        /// </summary> 
        private void ConvertFiles(FileBasedProject project)
        {
            #region "GetFilesForProcessing"
            ProjectFile[] files = project.GetSourceLanguageFiles();
            #endregion

            #region "RunConversion"
            for (int i = 0; i < project.GetSourceLanguageFiles().Length; i++)
            {
                if (files[i].Role == FileRole.Translatable)
                {
                    Guid[] currentFileId = { files[i].Id };
                    AutomaticTask convertTask = project.RunAutomaticTask(
                        currentFileId,
                        AutomaticTaskTemplateIds.ConvertToTranslatableFormat);

                    #region "CopyToTarget"
                    AutomaticTask copyTask = project.RunAutomaticTask(
                        currentFileId,
                        AutomaticTaskTemplateIds.CopyToTargetLanguages);
                    #endregion
                }
            }
            #endregion
        }
        #endregion

        #region "RunFileAnalysis"
        #region "RunFileAnalysisFunction"
        /// <summary>
        /// Runs the actual analyze files task on the SDL XLIFF target documents.
        /// </summary> 
        private void RunFileAnalysis(FileBasedProject project, string trgLocale)
        #endregion
        {
            #region "GetTargetLanguageFiles"
            ProjectFile[] targetFiles = project.GetTargetLanguageFiles(new Language(CultureInfo.GetCultureInfo(trgLocale)));
            #endregion

            #region "RunAnalysis"
            AutomaticTask analyzeTask = project.RunAutomaticTask(
                targetFiles.GetIds(),
                AutomaticTaskTemplateIds.AnalyzeFiles);
            #endregion

            #region "SetTaskId"
            this.reportId = analyzeTask.Reports[0].Id;
            #endregion
        }
        #endregion

        #region "GetAnalyzeSettings"
        #region "GetAnalyzeSettingsFunction"
        /// <summary>
        /// Configures the analyze task file settings, i.e. in our implementation
        /// report cross-file repetitions and report the internal fuzzy match leverage.
        /// </summary> 
        private void GetAnalyzeSettings(
            FileBasedProject project,
            string trgLocale,
            bool reportCrossFileRepetitions,
            bool reportInternalFuzzyMatchLeverage)
        #endregion
        {
            #region "trgLanguage"
            Language trgLanguage = new Language(CultureInfo.GetCultureInfo(trgLocale));
            #endregion

            #region "ISettingsBundle"
            ISettingsBundle settings = project.GetSettings(trgLanguage);
            AnalysisTaskSettings analyzeSettings = settings.GetSettingsGroup<AnalysisTaskSettings>();
            #endregion

            #region "ConfigureSettings"
            analyzeSettings.ReportCrossFileRepetitions.Value = reportCrossFileRepetitions;
            analyzeSettings.ReportInternalFuzzyMatchLeverage.Value = reportInternalFuzzyMatchLeverage;
            #endregion

            #region "UpdateSettings"
            project.UpdateSettings(trgLanguage, settings);
            #endregion
        }
        #endregion

        #region "CreateReports"
        /// <summary>
        /// Retrieves the results of the analyze files tasks and generates a standard
        /// report in Microsoft Excel format as well as a report in a custom XML format.
        /// </summary> 
        private void CreateReports(FileBasedProject project, string path)
        {
            #region "CreateStandardReport"
            project.SaveTaskReportAs(this.reportId, path + "/AnalyzeTaskReport.xls", ReportFormat.Excel);
            #endregion

            #region "Statistics"
            ProjectStatistics projectStats = project.GetProjectStatistics();
            TargetLanguageStatistics[] targetStats = projectStats.TargetLanguageStatistics;
            AnalysisStatistics analysisStats = targetStats[0].AnalysisStatistics;
            #endregion

            #region "WriteData"
            string result = "Analysis result for all files:\n\n";

            result += "\nPerfect matches\n";
            result += "Segments: " + analysisStats.Perfect.Segments.ToString() + "\n";
            result += "Words: " + analysisStats.Perfect.Words.ToString() + "\n";
            result += "Characters: " + analysisStats.Perfect.Characters.ToString() + "\n";
            result += "Tags: " + analysisStats.Perfect.Tags.ToString() + "\n";
            result += "Placeables: " + analysisStats.Perfect.Placeables.ToString() + "\n";

            result += "\nContext matches\n";
            result += "Segments: " + analysisStats.InContextExact.Segments.ToString() + "\n";
            result += "Words: " + analysisStats.InContextExact.Words.ToString() + "\n";
            result += "Characters: " + analysisStats.InContextExact.Characters.ToString() + "\n";
            result += "Tags: " + analysisStats.InContextExact.Tags.ToString() + "\n";
            result += "Placeables: " + analysisStats.InContextExact.Placeables.ToString() + "\n";

            #region "Exact"
            result += "\nExact matches\n";
            result += "Segments: " + analysisStats.Exact.Segments.ToString() + "\n";
            result += "Words: " + analysisStats.Exact.Words.ToString() + "\n";
            result += "Characters: " + analysisStats.Exact.Characters.ToString() + "\n";
            result += "Tags: " + analysisStats.Exact.Tags.ToString() + "\n";
            result += "Placeables: " + analysisStats.Exact.Placeables.ToString() + "\n";
            #endregion

            #region "Fuzzy"
            for (int i = 0; i < analysisStats.Fuzzy.Length; i++)
            {
                string rangeMax = analysisStats.Fuzzy[i].Band.MaximumMatchValue.ToString();
                string rangeMin = analysisStats.Fuzzy[i].Band.MinimumMatchValue.ToString();

                result += "\nFuzzy matches " + rangeMax + "% to " + rangeMin + "%\n";
                result += "Segments: " + analysisStats.Fuzzy[i].Segments.ToString() + "\n";
                result += "Words: " + analysisStats.Fuzzy[i].Words.ToString() + "\n";
                result += "Characters: " + analysisStats.Fuzzy[i].Characters.ToString() + "\n";
                result += "Tags: " + analysisStats.Fuzzy[i].Tags.ToString() + "\n";
                result += "Placeables: " + analysisStats.Fuzzy[i].Placeables.ToString() + "\n";
            }
            #endregion

            result += "\nRepetitions\n";
            result += "Segments: " + analysisStats.Repetitions.Segments.ToString() + "\n";
            result += "Words: " + analysisStats.Repetitions.Words.ToString() + "\n";
            result += "Characters: " + analysisStats.Repetitions.Characters.ToString() + "\n";
            result += "Tags: " + analysisStats.Repetitions.Tags.ToString() + "\n";
            result += "Placeables: " + analysisStats.Repetitions.Placeables.ToString() + "\n";

            result += "\nNew segments\n";
            result += "Segments: " + analysisStats.New.Segments.ToString() + "\n";
            result += "Words: " + analysisStats.New.Words.ToString() + "\n";
            result += "Characters: " + analysisStats.New.Characters.ToString() + "\n";
            result += "Tags: " + analysisStats.New.Tags.ToString() + "\n";
            result += "Placeables: " + analysisStats.New.Placeables.ToString() + "\n";

            result += "\nTotal\n";
            result += "Segments: " + analysisStats.Total.Segments.ToString() + "\n";
            result += "Words: " + analysisStats.Total.Words.ToString() + "\n";
            result += "Characters: " + analysisStats.Total.Characters.ToString() + "\n";
            result += "Tags: " + analysisStats.Total.Tags.ToString() + "\n";
            result += "Placeables: " + analysisStats.Total.Placeables.ToString() + "\n";

            Console.Write(result);

            #endregion
        }
        #endregion
    }
}
