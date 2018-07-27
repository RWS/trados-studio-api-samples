namespace Sdl.ProjectAutomation.ProjectAutomationSample
{
    using Sdl.Core.Globalization;
    using Sdl.Core.Settings;
    using Sdl.ProjectApi.Settings;
    using Sdl.ProjectAutomation.Core;
    using Sdl.ProjectAutomation.FileBased;
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class ProjectHelperMain
    {
        /// <summary>
        /// Create basic project from scratch, not using templates
        /// </summary>
        public void CreateProject(LocalProjectSettings settings)
        {
            try
            {
                ////Create new project object
                FileBasedProject createdProject = new FileBasedProject(
                    this.GetProjectInfo(
                    settings.ProjectName,
                        new Language(settings.SourceLanguage),
                        new Language[] { new Language(settings.TargetLanguage) }));

                ////Add files
                createdProject.AddFolderWithFiles(settings.InputFolder, true);


                ////Add TM's which will be used in the project
                this.AddMasterTM(createdProject, settings.PathToMasterTM);

                ////Adapt some project settings
                this.AdaptProjectSettings(createdProject);

                ////Add termbase
                this.AddTermbase(createdProject, settings.TermbasePath, settings.SourceLanguage, settings.TargetLanguage);

                ////Start the tasks
                this.RunTasks(createdProject, settings);

                ////Create project package to be sent to translator
                this.CreateProjectPackage(createdProject, new Language(settings.TargetLanguage), settings.PackageOutputPath);

                ////missing - getting translated files.
                createdProject.Save();
                ////project is saved but not listed in Studio, this is by design.
            }
            catch (Exception ex)
            {
                throw new Exception("Problem during project creation", ex);
            }
        }

        //Output the project as a package
        private void CreateProjectPackage(FileBasedProject createdProject, Language targetLanguage, string packageOutputPath)
        {
            // at first create a manual task which will be added into the package
            ManualTask translate = createdProject.CreateManualTask(
                "Translate",
                "API translator",
                DateTime.Now.AddDays(7),
                this.GetTaskFiles(createdProject, targetLanguage));

            // As last parameter of previous method you can suply array of TaskFileInfo(s), example here, or just array of Guids
            // which you can get by using createdProject.GetTargetLanguageFiles(targetLanguage).GetIds(); we should document this option

            // create a project package
            ProjectPackageCreation package = createdProject.CreateProjectPackage(
                translate.Id,
                "mypackage",
                "A package created by the API",
                this.GetPackageOption());

            bool packageIsCreated = false;
            while (!packageIsCreated)
            {
                switch (package.Status)
                {
                    case PackageStatus.Cancelling:
                    case PackageStatus.InProgress:
                    case PackageStatus.Scheduled:
                    case PackageStatus.NotStarted:
                        packageIsCreated = false;
                        break;
                    case PackageStatus.Cancelled:
                    case PackageStatus.Completed:
                    case PackageStatus.Failed:
                    case PackageStatus.Invalid:
                        packageIsCreated = true;
                        break;
                    default:
                        break;
                }
            }

            if (package.Status != PackageStatus.Completed)
            {
                throw new Exception("Problem during package creation");
            }

            // Save the package as a file
            createdProject.SavePackageAs(package.PackageId, packageOutputPath);
        }

        /// <summary>
        /// Set options for project package.
        /// </summary>
        /// <returns>Object of a type ProjectPackageCreationOptions.</returns>
        private ProjectPackageCreationOptions GetPackageOption()
        {
            ProjectPackageCreationOptions options = new ProjectPackageCreationOptions();
            options.IncludeAutoSuggestDictionaries = false;
            options.IncludeMainTranslationMemories = false;
            options.RemoveServerBasedTranslationMemories = false;
            options.IncludeTermbases = true;
            options.ProjectTranslationMemoryOptions = ProjectTranslationMemoryPackageOptions.UseExisting;
            options.RecomputeAnalysisStatistics = false;
            options.RemoveAutomatedTranslationProviders = true;
            return options;
        }


        private TaskFileInfo[] GetTaskFiles(FileBasedProject createdProject, Language targetLanguage)
        {
            List<TaskFileInfo> files = new List<TaskFileInfo>();
            foreach (var item in createdProject.GetTargetLanguageFiles(targetLanguage))
            {
                TaskFileInfo fileInfo = new TaskFileInfo();
                fileInfo.ProjectFileId = item.Id;
                fileInfo.ReadOnly = false;
                files.Add(fileInfo);
            }

            return files.ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="createdProject">A project you have created</param>
        /// <param name="settings">Settings containing initial input parameters</param>
        private void RunTasks(FileBasedProject createdProject, LocalProjectSettings settings)
        {
            Language targetLanguage = new Language(settings.TargetLanguage);
            List<TaskStatusEventArgs> taskStatusEventArgsList = new List<TaskStatusEventArgs>();
            List<MessageEventArgs> messageEventArgsList = new List<MessageEventArgs>();

            // set up  perfect match
            ProjectFile[] projectFiles = createdProject.GetSourceLanguageFiles();
            createdProject.AddBilingualReferenceFiles(GetBilingualFileMappings(new Language[] { targetLanguage }, projectFiles, settings.PreviousVersionPath));

            // scan files
            AutomaticTask automaticTask = this.RunTasks(
                createdProject,
                projectFiles,
                AutomaticTaskTemplateIds.Scan,
                taskStatusEventArgsList,
                messageEventArgsList);

            this.CheckEvents(taskStatusEventArgsList, messageEventArgsList);

            // convert files
            automaticTask = this.RunTasks(
                createdProject,
                projectFiles,
                AutomaticTaskTemplateIds.ConvertToTranslatableFormat,
                taskStatusEventArgsList,
                messageEventArgsList);

            this.CheckEvents(taskStatusEventArgsList, messageEventArgsList);

            // copy files to target languages
            automaticTask = this.RunTasks(
                createdProject,
                projectFiles,
                AutomaticTaskTemplateIds.CopyToTargetLanguages,
                taskStatusEventArgsList,
                messageEventArgsList);

            this.CheckEvents(taskStatusEventArgsList, messageEventArgsList);

            // from now on use target language files
            projectFiles = createdProject.GetTargetLanguageFiles(targetLanguage);

            // Apply Perfect Match
            automaticTask = this.RunTasks(
                createdProject,
                projectFiles,
                AutomaticTaskTemplateIds.PerfectMatch,
                taskStatusEventArgsList,
                messageEventArgsList);

            this.CheckEvents(taskStatusEventArgsList, messageEventArgsList);

            // analyze files
            automaticTask = this.RunTasks(
                createdProject,
                projectFiles,
                AutomaticTaskTemplateIds.AnalyzeFiles,
                taskStatusEventArgsList,
                messageEventArgsList);

            this.CheckEvents(taskStatusEventArgsList, messageEventArgsList);

            // translate files
            automaticTask = this.RunTasks(
                createdProject,
                projectFiles,
                AutomaticTaskTemplateIds.PreTranslateFiles,
                taskStatusEventArgsList,
                messageEventArgsList);

            this.CheckEvents(taskStatusEventArgsList, messageEventArgsList);

            // populate project TM
            automaticTask = this.RunTasks(
                createdProject,
                projectFiles,
                AutomaticTaskTemplateIds.PopulateProjectTranslationMemories,
                taskStatusEventArgsList,
                messageEventArgsList);

            this.CheckEvents(taskStatusEventArgsList, messageEventArgsList);
        }

        /// <summary>
        /// Demonstrates calling a task sequence 
        /// </summary>
        /// <param name="createdProject">project</param>
        /// <param name="settings">user project settings</param>
        private void RunTasksSequence(FileBasedProject createdProject, LocalProjectSettings settings)
        {
            Language targetLanguage = new Language(settings.TargetLanguage);
            List<TaskStatusEventArgs> taskStatusEventArgsList = new List<TaskStatusEventArgs>();
            List<MessageEventArgs> messageEventArgsList = new List<MessageEventArgs>();

            ProjectFile[] projectFiles = createdProject.GetSourceLanguageFiles();

            createdProject.AddBilingualReferenceFiles(GetBilingualFileMappings(new Language[] { targetLanguage }, projectFiles, settings.PreviousVersionPath));

            TaskSequence taskSequence = createdProject.RunAutomaticTasks(projectFiles.GetIds(), TaskSequences.Prepare);
            createdProject.Save();
        }


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
        /// <param name="TargetLanguages">An array of target languages</param>
        /// <param name="TranslatableFiles">An array of project files </param>
        /// <param name="PreviousProjectPath">The root directory of the previous SDL Studio Project</param>
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



        private void CheckEvents(List<TaskStatusEventArgs> taskStatusEventArgsList, List<MessageEventArgs> messageEventArgsList)
        {
            // task statuses and messages can be iterated and any problems can be reported
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
                    case TaskStatus.Failed:
                        break;
                    case TaskStatus.Invalid:
                        break;
                    case TaskStatus.Rejected:
                        break;
                    case TaskStatus.Started:
                        break;
                    default:
                        break;
                }
            }

            // at the end clear task statuses and messages
            taskStatusEventArgsList.Clear();
            messageEventArgsList.Clear();
        }

        private AutomaticTask RunTasks(
            FileBasedProject createdProject,
            ProjectFile[] projectFiles,
            string taskIDToRun,
            List<TaskStatusEventArgs> taskStatusEventArgsList,
            List<MessageEventArgs> messageEventArgsList)
        {
            AutomaticTask task = createdProject.RunAutomaticTask(
                projectFiles.GetIds(),
                taskIDToRun,
                (sender, taskStatusArgs) =>
                {
                    taskStatusEventArgsList.Add(taskStatusArgs);
                },
                (sender, messageArgs) =>
                {
                    messageEventArgsList.Add(messageArgs);
                });

            return task;
        }

        private void AddTermbase(FileBasedProject createdProject, string pathToTermbase, string sourceLang, string targetLang)
        {
            // need to be tested
            TermbaseConfiguration termbaseConfiguration = createdProject.GetTermbaseConfiguration();
            termbaseConfiguration.Termbases.Add(new LocalTermbase(pathToTermbase));

            // change default option - as the options are bit inconsistent please add this to the documentation
            termbaseConfiguration.TermRecognitionOptions.MinimumMatchValue = 60;

            termbaseConfiguration.LanguageIndexes.Add(new TermbaseLanguageIndex(new Language(sourceLang), "Source"));
            termbaseConfiguration.LanguageIndexes.Add(new TermbaseLanguageIndex(new Language(targetLang), "Target"));

            createdProject.UpdateTermbaseConfiguration(termbaseConfiguration);
        }

        /// <summary>
        /// Use project settings bundle to adapt specific project settings. For more details see Sdl.ProjectAutomation.Settings
        /// </summary>
        private void AdaptProjectSettings(FileBasedProject createdProject)
        {
            // Adapting translate task settings
            ISettingsBundle settings = createdProject.GetSettings();
            TranslateTaskSettings translateSettings = settings.GetSettingsGroup<TranslateTaskSettings>();
            translateSettings.NoTranslationMemoryMatchFoundAction.Value = NoTranslationMemoryMatchFoundAction.CopySourceToTarget;

            AnalysisTaskSettings analyzeSettings = settings.GetSettingsGroup<AnalysisTaskSettings>();
            analyzeSettings.ExportFrequentSegments.Value = true;

            createdProject.UpdateSettings(settings);

            // Note the most complicated settings are TranslationMemorySettings, to adapt some part of these you need to use TM API
            // for example for filters. The documentation should mention this fact and describe how user can get a TM API (link to website)
            // We should not add such examples into ProjectAutomation API as it would add to many dependencies.
        }

        private void AddMasterTM(FileBasedProject createdProject, string pathToTM)
        {
            TranslationProviderConfiguration config = createdProject.GetTranslationProviderConfiguration();
            config.Entries.Add(this.GetTranslationProviderCascadeEntry(pathToTM));
            createdProject.UpdateTranslationProviderConfiguration(config);
        }

        private TranslationProviderCascadeEntry GetTranslationProviderCascadeEntry(string pathToTM)
        {
            return new TranslationProviderCascadeEntry(pathToTM, true, true, true);
        }

        private ProjectInfo GetProjectInfo(string projectName, Language sourceLang, Language[] targetLangs)
        {
            ProjectInfo newProjectInfo = new ProjectInfo()
            {
                Name = projectName,
                CreatedBy = "API automation",
                Description = "Project created by API",
                DueDate = DateTime.Now.AddDays(7),
                SourceLanguage = sourceLang,
                TargetLanguages = targetLangs,
                LocalProjectFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).ToString() +
                Path.DirectorySeparatorChar + @"Studio 2011\Projects\" + projectName
            };

            return newProjectInfo;
        }
    }
}
