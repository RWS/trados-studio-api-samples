namespace Sdl.SDK.ProjectAutomation.Samples.Examples
{
    using Sdl.Core.Globalization;
    using Sdl.ProjectAutomation.Core;
    using Sdl.ProjectAutomation.FileBased;
    using System;
    using System.Globalization;

    internal class ReturnPackage
    {
        #region "CreatePackage"
        public void CreatePackage(FileBasedProject project)
        {
            #region "FileIds"
            Language targetLang = new Language(CultureInfo.GetCultureInfo("de-DE"));
            ProjectFile[] files = project.GetTargetLanguageFiles(targetLang);
            Guid[] fileIds = files.GetIds();
            #endregion

            #region "ReturnPackage"
            ReturnPackageCreation returnPackage = project.CreateReturnPackage(fileIds, "Return Package Name", "Comment: Everything went fine");
            #endregion

            #region "PackageStatus"
            bool packageIsCreated = false;
            while (!packageIsCreated)
            {
                switch (returnPackage.Status)
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

            if (returnPackage.Status != PackageStatus.Completed)
            {
                throw new Exception("A problem occurred during package creation.");
            }
            #endregion

            #region "SavePackage"
            project.SavePackageAs(returnPackage.PackageId, @"c\temp\return_package.sdlrpx");
            #endregion
        }
        #endregion

        #region "OpenPackage"
        public void OpenPackage(string projectFile, string returnPackageFile)
        {
            #region "OpenProject"
            FileBasedProject project = new FileBasedProject(projectFile);
            #endregion

            #region "ImportPackage"
            ReturnPackageImport import = project.ImportReturnPackage(returnPackageFile);
            #endregion

            #region "CheckImportStatus"
            bool packageIsImported = false;
            while (!packageIsImported)
            {
                switch (import.Status)
                {
                    case PackageStatus.Cancelling:
                    case PackageStatus.InProgress:
                    case PackageStatus.Scheduled:
                    case PackageStatus.NotStarted:
                        packageIsImported = false;
                        break;
                    case PackageStatus.Cancelled:
                    case PackageStatus.Completed:
                    case PackageStatus.Failed:
                    case PackageStatus.Invalid:
                        packageIsImported = true;
                        break;
                    default:
                        break;
                }
            }

            if (import.Status != PackageStatus.Completed)
            {
                throw new Exception("A problem occurred during package import.");
            }
            #endregion
        }
        #endregion
    }
}
