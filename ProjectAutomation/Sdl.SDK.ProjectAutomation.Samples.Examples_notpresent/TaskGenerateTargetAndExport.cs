namespace Sdl.SDK.ProjectAutomation.Samples.Examples
{
    using Sdl.Core.Settings;
    using Sdl.ProjectAutomation.FileBased;
    using Sdl.ProjectAutomation.Settings;

    internal class TaskGenerateTargetAndExport
    {
        #region "GetExportTaskSettings"
        public void GetExportTaskSettings(FileBasedProject project)
        {
            #region "ExportTaskSettings"
            ISettingsBundle settings = project.GetSettings();
            ExportFilesSettings exportTaskSettings = settings.GetSettingsGroup<ExportFilesSettings>();
            #endregion

            #region "ExportLocation"
            exportTaskSettings.ExportLocation.Value = @"c:\temp";
            #endregion

            #region "ExportFileVersion"
            exportTaskSettings.ExportFileVersion.Value = ExportFileVersion.Bilingual;
            #endregion

            #region "UpdateSettings"
            project.UpdateSettings(settings);
            #endregion
        }
        #endregion
    }
}
