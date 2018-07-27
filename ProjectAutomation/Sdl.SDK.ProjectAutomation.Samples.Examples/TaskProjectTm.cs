namespace Sdl.SDK.ProjectAutomation.Samples.Examples
{
    using Sdl.Core.Settings;
    using Sdl.ProjectAutomation.FileBased;
    using Sdl.ProjectAutomation.Settings;

    internal class TaskProjectTm
    {
        #region "GetProjectTmTaskSettings"
        public void GetProjectTmTaskSettings(FileBasedProject project)
        {
            #region "TaskSettings"
            ISettingsBundle settings = project.GetSettings();
            ProjectTranslationMemoryTaskSettings projectTmSettings = settings.GetSettingsGroup<ProjectTranslationMemoryTaskSettings>();            
            #endregion

            #region "ProjectTmSettings"
            projectTmSettings.CreateServerBasedProjectTranslationMemories.Value = true;
            projectTmSettings.ServerConnectionUri.Value = string.Empty;
            projectTmSettings.TranslationMemoryContainerName.Value = "TMCont";
            #endregion

            #region "UpdateTaskSettings"
            project.UpdateSettings(settings);
            #endregion
        }
        #endregion
    }
}
