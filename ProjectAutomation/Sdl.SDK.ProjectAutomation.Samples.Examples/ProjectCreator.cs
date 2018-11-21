namespace Sdl.SDK.ProjectAutomation.Samples.Examples
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;
    using Sdl.Core.Globalization;
    using Sdl.ProjectAutomation.Core;
    using Sdl.ProjectAutomation.FileBased;
    using Sdl.LanguagePlatform.TranslationMemoryApi;
    using System.Linq;

    internal class ProjectCreator
    {
        public string CreateProject()
        {
            #region "ProjectSetupInformation"
            ProjectInfo info = this.GetProjectInfo();
            #endregion

            #region "newProject"
            FileBasedProject newProject = new FileBasedProject(info);
            #endregion

            #region "AddFiles"
            ProjectFile[] files = newProject.AddFiles(this.AddProjectFiles(@"c:\ProjectFiles\Documents\"));
            #endregion            

            #region "SetUpPerfectMatch"
            newProject.AddBilingualReferenceFiles(GetBilingualFileMappings(info.TargetLanguages, files, @"c:\ProjectFiles\PreviousProjectFiles"));
            #endregion

            #region "ScanFiles"
            AutomaticTask scanFiles = newProject.RunAutomaticTask(
                newProject.GetSourceLanguageFiles().GetIds(),
                AutomaticTaskTemplateIds.Scan);
            #endregion

            #region "CallSetFileRole"
            this.SetFileRole(newProject, "brochure.pdf", FileRole.Reference);
            this.SetFileRole(newProject, "options.jpg", FileRole.Localizable);
            #endregion

            #region "Tms"
            this.AddMasterTMs(newProject, @"c:\ProjectFiles\TMs\");
            #endregion

            #region "Termbase"
            this.AddTermbase(newProject, @"c:\ProjectFiles\Termbase\Software.sdltb");
            #endregion

            #region "PrepareProject"
            this.PrepareFiles(newProject);
            #endregion

            ////ProjectFile[] files = newProject.GetSourceLanguageFiles();
            ////UpdateFile(newProject, files[0].Id, @"c:\update\sample01.doc");

            #region "SaveProject"
            newProject.Save();
            #endregion

            ProjectPackage pack = new ProjectPackage();
            pack.CreatePackage(newProject, @"c:\ProjectFiles\project_package.sdlppx");

            TmSettings set = new TmSettings();
            set.ConfigureTmSettings(newProject);

            newProject.Save();

            this.GetProjectStatistics(newProject);

            return newProject.FilePath;
        }

        #region "CompleteProject"
        public void CompleteProject()
        {
            FileBasedProject project = new FileBasedProject(GetProjectInfo());
            project.Complete();
        }
        #endregion

        #region "GetProjectInfo"
        public ProjectInfo GetProjectInfo()
        {
            #region "InfoObject"
            ProjectInfo info = new ProjectInfo();
            #endregion

            #region "GeneralInfo"
            info.Name = "My First Project";
            info.Description = "This is a programmatically created project.";
            info.DueDate = DateTime.Now.AddDays(3);
            #endregion

            #region "ProjectFolder"
            string localProjectFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).ToString() +
                Path.DirectorySeparatorChar + @"Studio 2011\Projects\" + info.Name;

            info.LocalProjectFolder = localProjectFolder;
            #endregion

            #region "SourceLanguage"
            Language srcLang = new Language(CultureInfo.GetCultureInfo("en-US"));
            info.SourceLanguage = srcLang;
            #endregion

            #region "TargetLanguages"
            Language[] trgLangs = new Language[] { new Language(CultureInfo.GetCultureInfo("de-DE")), new Language(CultureInfo.GetCultureInfo("fr-FR")), new Language(CultureInfo.GetCultureInfo("en-US")) };
            info.TargetLanguages = trgLangs;
            #endregion

            #region "ReturnInfo"
            return info;
            #endregion
        }
        #endregion

        #region "AddProjectFiles"
        public string[] AddProjectFiles(string path)
        {
            string[] projectFiles =
            {
                path + "brochure.pdf",
                path + "Configuration.doc",
                path + "New_Features.ppt",
                path + "options.jpg"
            };

            return projectFiles;
        }
        #endregion

        #region "PerfectMatchSamples"
        public void SetUpPerfectMatch(FileBasedProject project)
        {
            #region "ScanPreviousProject"

            ProjectInfo info = this.GetProjectInfo();
            ProjectFile[] files = project.AddFiles(this.AddProjectFiles(@"c:\ProjectFiles\Documents\"));


            //Using a helper function to return an array of BilingualFileMappings which are added to the project 
            project.AddBilingualReferenceFiles(GetBilingualFileMappings(info.TargetLanguages, files, @"c:\ProjectFiles\PreviousProjectFiles"));

            //Assigning one or more reference files manually
            project.AddBilingualReferenceFiles(
                  new BilingualFileMapping[] {
                     new BilingualFileMapping(files[0].Id, new Language("fr-FE"), @"c:\ProjectFiles\PreviousProjectFiles\fr-FR\mydocument.docx.sdlxliff"),
                     new BilingualFileMapping(files[0].Id, new Language("de-DE"), @"c:\ProjectFiles\PreviousProjectFiles\de-DE\mydocument.docx.sdlxliff"),
                     new BilingualFileMapping(files[1].Id, new Language("fr-FE"), @"c:\ProjectFiles\PreviousProjectFiles\fr-FR\myotherdocument.docx.sdlxliff"),
                  });


            #endregion

            Guid FileIdFromOriginalSourceFile = files[0].Id;
            Guid FileIdOfTargetFile = files[0].Id;

            #region "AddBilingualReferenceFile"

            //Add a single reference file using a BilingualFileMapping Object
            project.AddBilingualReferenceFile(new BilingualFileMapping(FileIdFromOriginalSourceFile, new Language("fr-FR"), @"c:\ProjectFiles\PreviousProjectFiles\fr-FR\mydocument.docx.sdlxliff"));

            #endregion
        }


        #endregion


        #region "SetFileRole"
        private void SetFileRole(FileBasedProject project, string fileName, FileRole role)
        {
            ProjectFile[] files = project.GetSourceLanguageFiles();
            for (int i = 0; i < files.Length; i++)
            {
                if (files[i].Name == fileName.ToLower())
                {
                    Guid[] fileId = { files[i].Id };
                    project.SetFileRole(fileId, role);
                    break;
                }
            }
        }
        #endregion

        #region "AddTms"
        public void AddMasterTMs(FileBasedProject project, string path)
        {
            #region "TranslationProviderConfiguration"
            Language trgLangDe = new Language(CultureInfo.GetCultureInfo("de-DE"));
            Language trgLangFr = new Language(CultureInfo.GetCultureInfo("fr-FR"));

            TranslationProviderConfiguration tmConfigEnDe = project.GetTranslationProviderConfiguration(trgLangDe);
            TranslationProviderConfiguration tmConfigEnFr = project.GetTranslationProviderConfiguration(trgLangFr);
            #endregion

            #region "ConfigureTms"
            TranslationProviderCascadeEntry[] tmEntriesEnDe =
            {
                new TranslationProviderCascadeEntry(path + "Software En-De.sdltm", true, true, true, 0),
                new TranslationProviderCascadeEntry(path + "General En-De.sdltm", true, true, true, 2),
            };

            TranslationProviderCascadeEntry[] tmEntriesEnFr =
            {
                new TranslationProviderCascadeEntry(path + "Software En-Fr.sdltm", true, true, true, 0),
                new TranslationProviderCascadeEntry(path + "General En-Fr.sdltm", true, true, true, 2)
            };
            #endregion

            #region "AddTmsAndUpdate"
            for (int i = 0; i < tmEntriesEnDe.Length; i++)
            {
                tmConfigEnDe.Entries.Add(tmEntriesEnDe[i]);
            }

            for (int i = 0; i < tmEntriesEnFr.Length; i++)
            {
                tmConfigEnDe.Entries.Add(tmEntriesEnFr[i]);
            }

            project.UpdateTranslationProviderConfiguration(trgLangDe, tmConfigEnDe);
            project.UpdateTranslationProviderConfiguration(trgLangFr, tmConfigEnFr);
            #endregion
        }
        #endregion

        #region "AddFileBasedTMWithPassword"

        public void AddFileBasedTMWithPassword(FileBasedProject project, string pathIncludingFileName, string password)
        {
            Uri uri = new Uri(String.Concat("sdltm.file://", pathIncludingFileName));

            TranslationProviderConfiguration tmConfig = project.GetTranslationProviderConfiguration();
            tmConfig.Entries.Add
            (
                new TranslationProviderCascadeEntry
                (
                    new TranslationProviderReference(uri), true, true, true, 0
                )
            );

            project.Credentials.AddCredential(uri, password);
            project.UpdateTranslationProviderConfiguration(tmConfig);
        }
        #endregion

        #region "AddServerBasedTM"
        private void AddServerBasedTM(FileBasedProject project, Uri uri, string path, string tmname)
        {

            TranslationProviderConfiguration tmConfig = project.GetTranslationProviderConfiguration();
            tmConfig.Entries.Add
            (
                new TranslationProviderCascadeEntry
                (
                    new TranslationProviderReference(new Uri(String.Format("{0}{1}/{2}", uri, path, tmname))),
                    true,
                    true,
                    true,
                    0
                )
            );

            //The credentials for a server based TM are keyed to the server address without path or tm name
            project.Credentials.AddCredential(uri, "user=myuser;password=mypassword;type=CustomUser");
            project.UpdateTranslationProviderConfiguration(tmConfig);
        }
        #endregion

        #region "AddBeglobalCommunityMT"
        public void AddBeglobalCommunityMT(FileBasedProject project)
        {
            TranslationProviderConfiguration tmConfig = project.GetTranslationProviderConfiguration();

            Uri BeGlobalCommunityUri = new Uri("beglobalcommunity://");
            tmConfig.Entries.Add
            (
                new TranslationProviderCascadeEntry
                (
                    new TranslationProviderReference(BeGlobalCommunityUri), false, true, true, 0
                )

            );

            project.UpdateTranslationProviderConfiguration(tmConfig);

        }
        #endregion

        #region "AddGoogleMT"
        public void AddGoogleMT(FileBasedProject project, string apiKey)
        {
            Uri GoogleUri = new Uri("googlemt://");

            TranslationProviderConfiguration tmConfig = project.GetTranslationProviderConfiguration();

            tmConfig.Entries.Add
            (
                new TranslationProviderCascadeEntry
                (
                    new TranslationProviderReference(GoogleUri), false, true, true, 0
                )
            );

            //Add the Google Api key. To get an Api Key you will need to sign up with Google for the 
            //Google Translate API V2 service.
            project.Credentials.AddCredential(GoogleUri, apiKey);

            project.UpdateTranslationProviderConfiguration(tmConfig);
        }
        #endregion

        #region "AddBeglobalEnterpriseMT"
        public void AddBeglobalEnterpriseMT(FileBasedProject project, string host, string port, string accountid, string apiKey, string touchpointId, string userId)
        {
            Uri uri = new Uri(String.Format(@"languageweavermt.https://{0}-{1}@{2}:{3}/aspmodel=REST&touchpointId={4}", accountid, userId, host, port, touchpointId));

            TranslationProviderConfiguration tmConfig = project.GetTranslationProviderConfiguration();
            tmConfig.Entries.Add
            (
                new TranslationProviderCascadeEntry
                (
                    new TranslationProviderReference(uri), false, true, true, 0
                )
            );

            project.Credentials.AddCredential(uri, apiKey);
            project.UpdateTranslationProviderConfiguration(tmConfig);
        }
        #endregion

        #region "AddTermbase"
        public void AddTermbase(FileBasedProject project, string termbaseFileName)
        {
            #region "TbConfig"
            TermbaseConfiguration termbaseConfig = project.GetTermbaseConfiguration();
            #endregion

            #region "AddTb"
            Termbase tb = new LocalTermbase(termbaseFileName);
            termbaseConfig.Termbases.Add(tb);
            #endregion

            #region "TermRecOptions"
            TermRecognitionOptions options = termbaseConfig.TermRecognitionOptions;
            options.MinimumMatchValue = 50;
            options.SearchDepth = 200;
            options.ShowWithNoAvailableTranslation = true;
            options.SearchOrder = TermbaseSearchOrder.Hierarchical;
            #endregion

            #region "ProjectLanguagesAndTbIndexes"
            string[] termbaseIndex = { "English", "German", "French" };

            Language projSourceLang = new Language(CultureInfo.GetCultureInfo("en-US"));
            Language projTargetLang1 = new Language(CultureInfo.GetCultureInfo("de-DE"));
            Language projTargetLang2 = new Language(CultureInfo.GetCultureInfo("fr-FR"));
            #endregion

            #region "TermbaseLanguageIndex"
            termbaseConfig.LanguageIndexes.Add(new TermbaseLanguageIndex(projSourceLang, termbaseIndex[0]));
            termbaseConfig.LanguageIndexes.Add(new TermbaseLanguageIndex(projTargetLang1, termbaseIndex[1]));
            termbaseConfig.LanguageIndexes.Add(new TermbaseLanguageIndex(projTargetLang2, termbaseIndex[2]));
            #endregion

            #region "UpdateTermbaseConfiguration"
            project.UpdateTermbaseConfiguration(termbaseConfig);
            #endregion
        }
        #endregion

        public void PrepareFilesSimplified(FileBasedProject project)
        {
            #region "GetSourceLanguageFiles"
            ProjectFile[] sourceFiles = project.GetSourceLanguageFiles();
            #endregion

            #region "ProcessSourceFiles"
            for (int i = 0; i < sourceFiles.Length; i++)
            {
                if (sourceFiles[i].Role == FileRole.Translatable)
                {
                    Guid[] fileId = { sourceFiles[i].Id };
                    AutomaticTask convertTask = project.RunAutomaticTask(
                        fileId,
                        AutomaticTaskTemplateIds.ConvertToTranslatableFormat);

                    AutomaticTask copyTask = project.RunAutomaticTask(
                        fileId,
                        AutomaticTaskTemplateIds.CopyToTargetLanguages);
                }
            }
            #endregion

            #region "ProcessTargetFiles"
            this.ProcessTargetLanguageFiles(project, "de-DE");
            this.ProcessTargetLanguageFiles(project, "fr-FR");
            #endregion
        }

        #region "PrepareFilesEnhanced"
        public void PrepareFiles(FileBasedProject project)
        {
            #region "EventArgs"
            List<TaskStatusEventArgs> taskStatusEventArgsList = new List<TaskStatusEventArgs>();
            List<MessageEventArgs> messageEventArgsList = new List<MessageEventArgs>();
            #endregion

            ProjectFile[] sourceFiles = project.GetSourceLanguageFiles();

            for (int i = 0; i < sourceFiles.Length; i++)
            {
                if (sourceFiles[i].Role == FileRole.Translatable)
                {
                    Guid[] fileId = { sourceFiles[i].Id };
                    AutomaticTask convertTask = project.RunAutomaticTask(
                        fileId,
                        AutomaticTaskTemplateIds.ConvertToTranslatableFormat);
                    this.CheckEvents(taskStatusEventArgsList, messageEventArgsList);

                    AutomaticTask copyTask = project.RunAutomaticTask(
                        fileId,
                        AutomaticTaskTemplateIds.CopyToTargetLanguages);
                    this.CheckEvents(taskStatusEventArgsList, messageEventArgsList);
                }
            }

            this.ProcessTargetLanguageFilesExtended(project, "de-DE");
            this.ProcessTargetLanguageFilesExtended(project, "fr-FR");
        }
        #endregion

        #region "ProcessTargetLanguageFiles"
        public void ProcessTargetLanguageFiles(FileBasedProject project, string locale)
        {
            #region "PerfectMatchSetupAndTask"
            Language targetLanguage = new Language(CultureInfo.GetCultureInfo(locale));

            ProjectFile[] targetFiles = project.GetTargetLanguageFiles(targetLanguage);

            project.AddBilingualReferenceFiles(GetBilingualFileMappings(new Language[] { targetLanguage }, targetFiles, @"c:\ProjectFiles\PreviousProjectFiles"));

            AutomaticTask perfectMatchTask = project.RunAutomaticTask(
            targetFiles.GetIds(),
            AutomaticTaskTemplateIds.PerfectMatch);
            #endregion

            AutomaticTask analzyeTask = project.RunAutomaticTask(
                targetFiles.GetIds(),
                AutomaticTaskTemplateIds.AnalyzeFiles);

            AutomaticTask translateTask = project.RunAutomaticTask(
                targetFiles.GetIds(),
                AutomaticTaskTemplateIds.PreTranslateFiles);

            AutomaticTask projectTmTask = project.RunAutomaticTask(
                targetFiles.GetIds(),
                AutomaticTaskTemplateIds.PopulateProjectTranslationMemories);
        }
        #endregion

        #region "ProcessTargetLanguageFilesEnhanced"
        public void ProcessTargetLanguageFilesExtended(FileBasedProject project, string locale)
        {
            List<TaskStatusEventArgs> taskStatusEventArgsList = new List<TaskStatusEventArgs>();
            List<MessageEventArgs> messageEventArgsList = new List<MessageEventArgs>();

            ProjectFile[] targetFiles = project.GetTargetLanguageFiles(new Language(CultureInfo.GetCultureInfo(locale)));

            AutomaticTask analyzeTask = project.RunAutomaticTask(
                targetFiles.GetIds(),
                AutomaticTaskTemplateIds.AnalyzeFiles);
            this.CheckEvents(taskStatusEventArgsList, messageEventArgsList);

            #region "SaveAnalysisReport"
            Guid reportId = analyzeTask.Reports[0].Id;
            project.SaveTaskReportAs(reportId, @"C:\ProjectFiles\Analysis_report.xls", ReportFormat.Excel);
            #endregion

            AutomaticTask translateTask = project.RunAutomaticTask(
                targetFiles.GetIds(),
                AutomaticTaskTemplateIds.PreTranslateFiles);
            this.CheckEvents(taskStatusEventArgsList, messageEventArgsList);

            AutomaticTask projectTmTask = project.RunAutomaticTask(
                targetFiles.GetIds(),
                AutomaticTaskTemplateIds.PopulateProjectTranslationMemories);
            this.CheckEvents(taskStatusEventArgsList, messageEventArgsList);
        }
        #endregion

        #region "CheckEventsFunction"
        private void CheckEvents(List<TaskStatusEventArgs> taskStatusEventArgsList, List<MessageEventArgs> messageEventArgsList)
        {
            // loop through the available statuses and messages
            foreach (var item in taskStatusEventArgsList)
            {
                switch (item.Status)
                {
                    case TaskStatus.Assigned:
                        break;
                    case TaskStatus.Cancelled:
                        break;
                    case TaskStatus.Cancelling:
                        break;
                    case TaskStatus.Completed:
                        break;
                    case TaskStatus.Created:
                        break;
                    case TaskStatus.Invalid:
                        break;
                    case TaskStatus.Rejected:
                        break;
                    case TaskStatus.Started:
                        break;
                    case TaskStatus.Failed:
                        break;
                    default:
                        break;
                }
            }

            // at the end clear task statuses and messages
            taskStatusEventArgsList.Clear();
            messageEventArgsList.Clear();
        }
        #endregion

        #region "CreateBasedOnPreviousProject"
        public void CreateBasedOnPreviousProject()
        {
            #region "RefProject"
            string refProjFile = @"C:\temp\RefProject.sdlproj";
            ProjectReference refProject = new ProjectReference(refProjFile);
            #endregion

            #region "UpdateProject"
            FileBasedProject updateProject = new FileBasedProject(this.GetUpdateProjectInfo(), refProject);

            updateProject.Save();
            #endregion
        }
        #endregion

        #region "GetUpdateProjectInfo"
        public ProjectInfo GetUpdateProjectInfo()
        {
            #region "UpdateProjectInfo"
            ProjectInfo info = new ProjectInfo();

            info.Name = "My update project";
            info.DueDate = DateTime.Now.AddDays(3);

            string localProjectFolder = string.Format(
                CultureInfo.CurrentCulture,
                "{0){1}Studio 2011{1}Projects{1}{2}",
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).ToString(),
                Path.DirectorySeparatorChar,
                info.Name);
            info.LocalProjectFolder = localProjectFolder;

            return info;
            #endregion
        }
        #endregion

        #region "CreateBasedOnTemplate"
        public void CreateBasedOnTemplate()
        {
            #region "GetTemplate"
            string templateFile = @"c:\temp\project_template.sdltpl";
            ProjectTemplateReference template = new ProjectTemplateReference(templateFile);
            #endregion

            #region "TemplateBasedProject"
            FileBasedProject newProject = new FileBasedProject(this.GetInfoForTemplateProject(), template);
            newProject.Save();
            #endregion
        }
        #endregion

        #region "GetInfoForTemplateProject"
        public ProjectInfo GetInfoForTemplateProject()
        {
            #region "TemplateProjectInfo"
            ProjectInfo info = new ProjectInfo();

            info.Name = "Project based on Template";
            info.DueDate = DateTime.Now.AddDays(3);
            string localProjectFolder = string.Format(
                CultureInfo.CurrentCulture,
                "{0){1}Studio 2011{1}Projects{1}{2}",
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).ToString(),
                Path.DirectorySeparatorChar,
                info.Name);
            info.LocalProjectFolder = localProjectFolder;

            return info;
            #endregion
        }
        #endregion

        #region Delete 
        public bool DeleteProject(string projectPath)
        {
            bool deletedSuccesfully;
            try
            {
                var project = new FileBasedProject(projectPath);
                project.Delete();
                deletedSuccesfully = true;
            }
            catch (Exception)
            {
                deletedSuccesfully = false;
            }

            return deletedSuccesfully;
        }

        public bool DeleteFileAndDependencies(string projectPath, string filePath)
        {
            bool deletedSuccesfully;
            try
            {
                var project = new FileBasedProject(projectPath);
                project.DeleteFilesAndDependencies(filePath);
                deletedSuccesfully = true;
            }
            catch (Exception)
            {
                deletedSuccesfully = false;
            }

            return deletedSuccesfully;
        }

        
        #endregion

        #region "MergeFiles"
        private void MergeFiles(FileBasedProject project)
        {
            ProjectFile[] files = project.GetSourceLanguageFiles();
            Guid[] fileIds = files.GetIds();

            string masterFileName = "Master_File.sdlxliff";
            string pathInProject = string.Empty;
            project.CreateMergedProjectFile(masterFileName, pathInProject, fileIds);
        }
        #endregion

        #region "GetProjectStatistics"
        public void GetProjectStatistics(FileBasedProject project)
        {
            #region "GetProjectStatistics"
            ProjectStatistics projStats = project.GetProjectStatistics();
            #endregion

            #region "TargetLanguageStatistics"
            TargetLanguageStatistics[] targetStats = projStats.TargetLanguageStatistics;
            #endregion

            #region "trgInfo"
            StringBuilder trgInfo = new StringBuilder();
            for (int i = 0; i < targetStats.Length; i++)
            {
                ConfirmationStatistics confirmationStats = targetStats[i].ConfirmationStatistics;

                Language trgLang = new Language(CultureInfo.GetCultureInfo("en-US"));
                Guid[] ids = project.GetTargetLanguageFiles(trgLang).GetIds();
                project.RunAutomaticTask(ids, AutomaticTaskTemplateIds.TranslationCount);

                trgInfo.Append("\nConfirmation statistics for: " + targetStats[i].TargetLanguage.DisplayName + "\n");
                trgInfo.Append("Total word count: " + confirmationStats.Total.Words.ToString() + "\n");
                trgInfo.Append("Words with untranslated status: " + confirmationStats[ConfirmationLevel.Unspecified].Words.ToString() + "\n");
                trgInfo.Append("Words with draft status: " + confirmationStats[ConfirmationLevel.Draft].Words.ToString() + "\n");
                trgInfo.Append("Words with translated status: " + confirmationStats[ConfirmationLevel.Translated].Words.ToString() + "\n");
            }

            MessageBox.Show(trgInfo.ToString());
            #endregion
        }
        #endregion

        #region "UpdateFile"
        #region "UpdateFileFunction"
        private void UpdateFile(FileBasedProject project, Guid fileId, string newFileName)
        #endregion
        {
            #region "GetFileProperties"
            string fileInfo;
            ProjectFile thisFile = project.GetFile(fileId);
            fileInfo = "File name: " + thisFile.Name + "\n";
            fileInfo += "File usage: " + thisFile.Role.ToString() + "\n";
            fileInfo += "Belongs to project with the id: " + thisFile.ProjectId.ToString() + "\n";
            fileInfo += "Language: " + thisFile.Language.DisplayName + "\n";
            fileInfo += "Stored in folder: " + thisFile.LocalFilePath + "\n";
            fileInfo += "Unique file id: " + thisFile.Id.ToString() + "\n";
            MessageBox.Show(fileInfo);
            #endregion

            #region "AddNewFileVersion"
            project.AddNewFileVersion(fileId, newFileName);
            #endregion

            #region "ReRunTasks"
            Guid[] fileIds = { fileId };

            project.RunAutomaticTask(fileIds, AutomaticTaskTemplateIds.ConvertToTranslatableFormat);
            project.RunAutomaticTask(fileIds, AutomaticTaskTemplateIds.CopyToTargetLanguages);
            #endregion
        }
        #endregion

        #region "AssignBilingualReferenceFiles"

        /// <summary>
        /// Simple mapping routine to associate bilingual files in a previous project with the file in the current project
        /// Looks for a bilingual file with the same name in the relevant language directories 
        /// </summary>
        /// <remarks>
        ///  This routine is provided as a basic example of mapping previous documents to current documents. If a more complicated mapping 
        ///  is required (perhaps different versions have a version number in the filename) then you can build in your own rules to do this. 
        ///  
        /// Example: 
        ///     languages = { "fr-FR", "de-DE" }
        ///     files = { "file1.docx", "file2.docx" }
        ///     PreviousProjectPath = "C:\Projects\MyOldProject"
        ///     
        /// This routine will look for and associate the following files as bilingual reference files if present
        ///     "c:\Projects\MyOldProject\fr-FR\file1.docx.sdlxliff"     
        ///     "c:\Projects\MyOldProject\fr-FR\file2.docx.sdlxliff"
        ///     "c:\Projects\MyOldProject\de-DE\file1.docx.sdlxliff"
        ///     "c:\Projects\MyOldProject\de-DE\file2.docx.sdlxliff"
        /// </remarks>
        /// <param name="targetLanguages">An array of target languages</param>
        /// <param name="translatableFiles">An array of project files </param>
        /// <param name="previousProjectPath">The root directory of the previous SDL Studio Project</param>
        public BilingualFileMapping[] GetBilingualFileMappings(Language[] targetLanguages, ProjectFile[] translatableFiles, string previousProjectPath)
        {
            List<BilingualFileMapping> mappings = new List<BilingualFileMapping>();
            foreach (Language language in targetLanguages)
            {
                string searchPath = Path.Combine(previousProjectPath, language.IsoAbbreviation);
                foreach (ProjectFile file in translatableFiles)
                {
                    string previousFile = String.Concat(Path.Combine(searchPath, file.Name), (file.Name.EndsWith(".sdlxliff") ? "" : ".sdlxliff"));
                    if (File.Exists(previousFile))
                    {
                        BilingualFileMapping mapping = new BilingualFileMapping()
                        {
                            BilingualFilePath = previousFile,
                            Language = language,
                            FileId = file.Id
                        };
                        mappings.Add(mapping);
                    }
                }
            }
            return mappings.ToArray();
        }

        #endregion

        #region "RunPrepareWithPerfectMatch
        public void RunPrepareWithPerfectMatch()
        {

            ProjectInfo info = this.GetProjectInfo();

            //Create the project
            FileBasedProject newProject = new FileBasedProject(info);

            //Add project files
            ProjectFile[] files = newProject.AddFiles(this.AddProjectFiles(@"c:\ProjectFiles\Documents\"));

            //Perfect Match Setup - Use the helper function to look for files in a previous project that match files in this project
            newProject.AddBilingualReferenceFiles(GetBilingualFileMappings(info.TargetLanguages, files, @"c:\ProjectFiles\PreviousProjectFiles"));

            //Add Translation memory
            this.AddMasterTMs(newProject, @"c:\ProjectFiles\TMs\");

            //Run the prepare task sequence (Scan, ConvertToTranslatableFormat, WordCount, CopyToTargetLanguages, PerfectMatch, AnalyzeFiles, PreTranslateFiles, PopulateProjectTranslationMemories)
            TaskSequence taskSequence = newProject.RunAutomaticTasks(files.GetIds(), TaskSequences.Prepare);
        }
        #endregion

        void SetUpGroupShareCredentialsWithCustomLogin(FileBasedProject project)
        {
            #region "SetUpGroupShareCredentialsWithCustomLogin"

            Uri projectServer = new Uri("http://myServerAddress:80");
            project.Credentials.AddCredential(projectServer, "user=myUser;password=myPassword;type=CustomUser");
            #endregion

        }

        void SetUpGroupShareCredentialsWithWindowsLogin(FileBasedProject project)
        {
            #region "SetUpGroupShareCredentialsWithWindowsLogin"

            Uri projectServer = new Uri("http://myServerAddress:80");
            project.Credentials.AddCredential(projectServer, "type=WindowsUser");
            #endregion
        }

        void PublishToGroupShare(FileBasedProject project, bool cancelledByUser)
        {
            #region "PublishToGroupShare"
            project.PublishProject(
                new Uri("http://myServerAddress:80"),
                true,
                "MyUserName",
                "MyPassword",
                "/MyOrganization",
                 (obj, evt) =>
                 {
                     Console.WriteLine(evt.StatusMessage + " " + evt.PercentComplete + "% complete");

                     if (cancelledByUser)
                     {
                         evt.Cancel = true;
                     }
                 });
            #endregion

        }

        void OpenFromExistingWorkspace()
        {
            #region "OpenFromExistingWorkspace"

            FileBasedProject project = new FileBasedProject(@"c:\MyProjectDirectory\MyProjectFile.sdlproj", false, "MyUserName", "MyPassword");

            #endregion
        }

        ServerProjectInfo[] ViewProjectsOnServer()
        {

            #region "ViewProjectsOnServer"
            Uri serverAddress = new Uri("http://myServerAddress:80");
            string organizationPath = "/LocationOnServerToStartListFrom";

            ProjectServer server = new ProjectServer(serverAddress, false, "MyUser", "MyPassword");
            ServerProjectInfo[] projects = server.GetServerProjects(organizationPath, true, false);

            #endregion

            return projects;
        }

        ServerProjectInfo ViewProjectByQualifiedName()
        {

            #region "ViewProjectByQualifiedName"
            Uri serverAddress = new Uri("http://myServerAddress:80");

            ProjectServer server = new ProjectServer(serverAddress, false, "MyUser", "MyPassword");
            ServerProjectInfo project = server.GetServerProject("/MyOrganization/MyProject");

            #endregion

            return project;
        }


        #region "SetupServerProjectWorkspace"
        FileBasedProject SetupServerProjectLocalCopy(Guid projectId, string locationOfLocalCopy)
        {
            Uri serverAddress = new Uri("http://myServerAddress:80");

            ProjectServer server = new ProjectServer(serverAddress, false, "MyUser", "MyPassword");
            FileBasedProject project = server.OpenProject(projectId, locationOfLocalCopy);
            return project;
        }
        #endregion


        void LookForAProjectAndCreateWorkSpace()
        {

            #region "LookForAProjectAndCreateWorkSpace"

            string rootLocalProjectLocation = @"C:\Projects\";

            Uri serverAddress = new Uri("http://myServerAddress:80");

            ProjectServer server = new ProjectServer(serverAddress, false, "MyUser", "MyPassword");
            ServerProjectInfo projectInfo = server.GetServerProject("/MyOrganizationName/MyProjectName");

            FileBasedProject project;

            if (projectInfo != null)
            {
                project = server.OpenProject(projectInfo.ProjectId, rootLocalProjectLocation + projectInfo.Name);
            }

            #endregion
        }




        void DownloadFileVersion(FileBasedProject project, Guid fileId, bool cancelledByUser)
        {
            #region "DownloadLatestFileVersion"
            project.DownloadLatestServerVersion(fileId, (obj, evt) =>
                {
                    Console.WriteLine("{0}, {1} of {2} bytes transfered", evt.Filename, evt.FileBytesTransferred, evt.FileTotalBytes);

                    if (cancelledByUser)
                    {
                        evt.Cancel = true;
                    }
                },
                false);

            #endregion
        }

        void DownloadSpecificServerVersion(FileBasedProject project, Guid fileId, bool cancelledByUser)
        {
            #region "DownloadSpecificServerVersion"

            project.DownloadSpecificServerVersion(fileId, 1, @"c:\files", (obj, evt) =>
             {
                 Console.WriteLine("{0}, {1} of {2} bytes transfered", evt.Filename, evt.FileBytesTransferred, evt.FileTotalBytes);

                 if (cancelledByUser)
                 {
                     evt.Cancel = true;
                 }
             });

            #endregion
        }

        #region "ShowServerFileHistory"
        private void ShowServerFileHistory(FileBasedProject project, Guid fileId)
        {
            ProjectFileVersion[] fileVersions = project.GetProjectFileVersionHistory(fileId);

            foreach (ProjectFileVersion fileVersion in fileVersions)
            {
                Console.WriteLine("Version {0}: {1}, Created By: {2}, Created At: {3}",
                                  fileVersion.VersionNumber,
                                  fileVersion.FileName,
                                  fileVersion.CreatedBy,
                                  fileVersion.CreatedAt
                    );
            }
        }
        #endregion

        void CheckOutFiles(FileBasedProject project, Guid[] fileIds, bool cancelledByUser)
        {
            #region "CheckOutFiles"
            project.CheckoutFiles(fileIds, false,
                (obj, evt) =>
            {
                Console.WriteLine(evt.StatusMessage + " " + evt.PercentComplete + "% complete");

                if (cancelledByUser)
                {
                    evt.Cancel = true;
                }
            });
            #endregion

        }

        void CheckInFiles(FileBasedProject project, Guid[] fileIds)
        {
            #region "CheckInFiles"

            project.CheckinFiles(fileIds, "Checkout overridden to auto-translate file", null);

            #endregion
        }

        void UnCheckoutFiles(FileBasedProject project, Guid[] fileIds)
        {
            #region "UnCheckoutFiles"

            project.UndoCheckoutFiles(fileIds);

            #endregion
        }


        void UploadAndCheckInFiles(FileBasedProject project, Guid[] fileIds, bool cancelledByUser)
        {
            #region "UploadAndCheckInFilesWithEventHandler"
            project.CheckinFiles(fileIds, "This is where you add a check in comment",
                (obj, evt) => Console.WriteLine(evt.StatusMessage + " " + evt.PercentComplete + "% complete"));
            #endregion

            #region "UploadAndCheckInFilesWithNullEventHandler"
            project.CheckinFiles(fileIds, "This is where you add a check in comment",
                (obj, evt) => Console.WriteLine(evt.StatusMessage + " " + evt.PercentComplete + "% complete"));
            #endregion

            #region "UploadAndCheckInFilesWithEventHandlerAndCancelation"
            project.CheckinFiles(fileIds, "This is where you add a check in comment",
                 (obj, evt) =>
                 {
                     Console.WriteLine(evt.StatusMessage + " " + evt.PercentComplete + "% complete");

                     if (cancelledByUser)
                     {
                         evt.Cancel = true;
                     }
                 });
            #endregion

            #region "UploadAndCheckInNewSourceFiles"

            Guid[] sourceFileIds = project.GetSourceLanguageFiles()
                .Where(file => file.LocalFileState == LocalFileState.New)
                .GetIds();

            project.CheckinFiles(sourceFileIds, "New Source Files",
                 (obj, evt) =>
                 {
                     Console.WriteLine(evt.StatusMessage + " " + evt.PercentComplete + "% complete");

                     if (cancelledByUser)
                     {
                         evt.Cancel = true;
                     }
                 });
            #endregion

            #region "UploadAndCheckInNewTargetFiles"

            Guid[] targetFileIds = project.GetSourceLanguageFiles()
                .Where(file => file.LocalFileState == LocalFileState.New)
                .GetIds();

            project.CheckinFiles(targetFileIds, "New Target Files",
                 (obj, evt) =>
                 {
                     Console.WriteLine(evt.StatusMessage + " " + evt.PercentComplete + "% complete");

                     if (cancelledByUser)
                     {
                         evt.Cancel = true;
                     }
                 });
            #endregion

        }

        void DeleteProjectFromServer(Guid projectId)
        {
            #region "DeleteProjectFromServer"
            Uri serverAddress = new Uri("http://myServerAddress:80");

            ProjectServer server = new ProjectServer(serverAddress, false, "MyUser", "MyPassword");
            server.DeleteProject(projectId);

            #endregion
        }

        #region "ServerPuttingItAllTogether"
        void ServerPuttingItAllTogether()
        {
            const string tmServerPrefix = "sdltm.";

            string localcopylocation = @"C:\Projects\";
            string serverName = "http://myServerAddress:80";
            Uri serverAddress = new Uri(serverName);
            string organizationPath = "/MyOrganizationPath";

            ProjectServer server = new ProjectServer(serverAddress, false, "MyUser", "MyPassword");
            ServerProjectInfo projectInfo = server.GetServerProject("/MyOrganization/MyProject");

            FileBasedProject project;

            if (projectInfo != null)
            {

                project = server.OpenProject(projectInfo.ProjectId, localcopylocation + projectInfo.Name);

                ProjectFile[] sourceFiles = project.GetSourceLanguageFiles();
                project.UndoCheckoutFiles(sourceFiles.GetIds());

                //Add a server based translation provider
                Uri tmAddress = new Uri(String.Format("{0}{1}{2}/{3}", tmServerPrefix, serverAddress, organizationPath, "UnitTestTm"));
                TranslationProviderConfiguration tmConfig = project.GetTranslationProviderConfiguration();
                tmConfig.Entries.Add
                (
                    new TranslationProviderCascadeEntry
                    (
                              new TranslationProviderReference(tmAddress),
                              true,
                              true,
                              true,
                              0
                    )
                );

                //The credentials for a server based TM are keyed to the server address without path or tm name
                project.Credentials.AddCredential(serverAddress, "user=sa;password=sa;type=CustomUser");
                project.UpdateTranslationProviderConfiguration(tmConfig);

                List<TaskStatusEventArgs> taskStatusEventArgsList = new List<TaskStatusEventArgs>();
                List<MessageEventArgs> messageEventArgsList = new List<MessageEventArgs>();

                // Run tasks for source files to create target files
                AutomaticTask scanTask = project.RunAutomaticTask(
                    sourceFiles.GetIds(),
                    AutomaticTaskTemplateIds.Scan,
                    (sender, taskStatusArgs) => taskStatusEventArgsList.Add(taskStatusArgs),
                    (sender, messageArgs) => messageEventArgsList.Add(messageArgs));

                AutomaticTask convertTask = project.RunAutomaticTask(
                    sourceFiles.GetIds(),
                    AutomaticTaskTemplateIds.ConvertToTranslatableFormat,
                    (sender, taskStatusArgs) => taskStatusEventArgsList.Add(taskStatusArgs),
                    (sender, messageArgs) => messageEventArgsList.Add(messageArgs));

                AutomaticTask copyToTargetTask = project.RunAutomaticTask(
                    sourceFiles.GetIds(),
                    AutomaticTaskTemplateIds.CopyToTargetLanguages,
                    (sender, taskStatusArgs) => taskStatusEventArgsList.Add(taskStatusArgs),
                    (sender, messageArgs) => messageEventArgsList.Add(messageArgs));

                // Run tasks for target files
                ProjectFile[] targetFiles = project.GetTargetLanguageFiles();

                AutomaticTask perfectMatchTask = project.RunAutomaticTask(
                   targetFiles.GetIds(),
                   AutomaticTaskTemplateIds.PerfectMatch,
                   (sender, taskStatusArgs) => taskStatusEventArgsList.Add(taskStatusArgs),
                   (sender, messageArgs) => messageEventArgsList.Add(messageArgs));

                AutomaticTask analyseTask = project.RunAutomaticTask(
                   targetFiles.GetIds(),
                   AutomaticTaskTemplateIds.AnalyzeFiles,
                   (sender, taskStatusArgs) => taskStatusEventArgsList.Add(taskStatusArgs),
                   (sender, messageArgs) => messageEventArgsList.Add(messageArgs));

                AutomaticTask preTranslateTask = project.RunAutomaticTask(
                  targetFiles.GetIds(),
                  AutomaticTaskTemplateIds.PreTranslateFiles,
                  (sender, taskStatusArgs) => taskStatusEventArgsList.Add(taskStatusArgs),
                  (sender, messageArgs) => messageEventArgsList.Add(messageArgs));

                AutomaticTask populateProjTmTask = project.RunAutomaticTask(
                   targetFiles.GetIds(),
                   AutomaticTaskTemplateIds.PopulateProjectTranslationMemories,
                   (sender, taskStatusArgs) => taskStatusEventArgsList.Add(taskStatusArgs),
                   (sender, messageArgs) => messageEventArgsList.Add(messageArgs));

                //Check in the new target files
                targetFiles = project.GetTargetLanguageFiles();
                project.CheckinFiles(targetFiles.GetIds(), "Target Files Created and Pre-translated", null);

                //Save the project back to disk
                project.Save();
            }
        }
        #endregion

        #region "DownloadAllLatest"
        void DownloadAllLatest(FileBasedProject project, Guid[] fileIds, bool overrideWorkspaceVersion)
        {
            //Make sure we are syncronized with the server
            project.SynchronizeServerProjectData();

            foreach (Guid fileId in fileIds)
            {
                ProjectFile file = project.GetFile(fileId);

                // We only need to download files that are missing from the workspace, out of date and 
                //modified files if we have chosen to override the file with the server version
                if (file.LocalFileState == LocalFileState.Missing
                    || (file.LocalFileState == LocalFileState.Modified && overrideWorkspaceVersion)
                    || (file.LocalFileState == LocalFileState.OutOfDate)
                    )
                {
                    //If the file directory does not exist in the local workspace then create it
                    string fileLocation = Path.GetDirectoryName(file.LocalFilePath);
                    if (!Directory.Exists(fileLocation))
                    {
                        Directory.CreateDirectory(fileLocation);
                    }

                    //Download the file passing in a null as the event handler therefore ignoring progress and cancelation.
                    project.DownloadLatestServerVersion(file.Id, null, false);
                }
            }
        }
        #endregion

        void SynchronizeProject(FileBasedProject project)
        {
            #region "SynchronizeProject"
            project.SynchronizeServerProjectData();
            #endregion

        }
    }

}
