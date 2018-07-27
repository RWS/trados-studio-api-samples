namespace Sdl.SDK.ProjectAutomation.Samples.Examples
{
    using System;
    using System.Globalization;
    using Sdl.Core.Globalization;
    using Sdl.ProjectAutomation.Core;
    using Sdl.ProjectAutomation.FileBased;

    internal class ProjectPackage
    {
        #region "CreatePackage"
        public void CreatePackage(FileBasedProject project, string packageFile)
        {
            #region "CreateManualTask"
            ProjectFile[] packageFiles = project.GetTargetLanguageFiles(new Language(CultureInfo.GetCultureInfo("de-DE")));
            ManualTask newTask = project.CreateManualTask(
                "Translate",
                "Fred",
                DateTime.Now.AddDays(3), 
                packageFiles.GetIds());
            #endregion

            #region "CreateProjectPackage"
            ProjectPackageCreation projectPackage = project.CreateProjectPackage(
                newTask.Id,
                "Sample Package",
                "Please hurry up, this is job is urgent!", 
                this.GetPackageOptions());
            #endregion

            #region "PackageStatus"
            bool packageIsCreated = false;
            while (!packageIsCreated)
            {
                switch (projectPackage.Status)
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

            if (projectPackage.Status != PackageStatus.Completed)
            {
                throw new Exception("A problem occurred during package creation.");
            }

            #endregion

            #region "SavePackage"
            project.SavePackageAs(projectPackage.PackageId, packageFile);
            #endregion
        }
        #endregion

        #region "GetPackageOptions"
        private ProjectPackageCreationOptions GetPackageOptions()
        {
            #region "ProjectPackageCreationOptions"
            ProjectPackageCreationOptions options = new ProjectPackageCreationOptions();
            #endregion

            #region "IncludeRessources"
            options.IncludeAutoSuggestDictionaries = false;
            options.IncludeMainTranslationMemories = false;
            options.RemoveServerBasedTranslationMemories = false;
            options.IncludeTermbases = true;
            #endregion

            #region "RemoveAutomatedTranslationProviders"
            options.RemoveAutomatedTranslationProviders = true;
            #endregion

            #region "RecomputeAnalysisStatistics"
            options.RecomputeAnalysisStatistics = true;
            options.ProjectTranslationMemoryOptions = ProjectTranslationMemoryPackageOptions.CreateNew;
            #endregion

            #region "ReturnOptions"
            return options;
            #endregion
        }
        #endregion

        #region "CheckEvents"

        #endregion
    }
}
