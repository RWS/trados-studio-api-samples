namespace Sdl.SDK.ProjectAutomation.Samples.Examples
{
    using Sdl.Core.Settings;
    using Sdl.ProjectAutomation.FileBased;
    using Sdl.ProjectAutomation.Settings;

    internal class TaskPerfectMatch
    {
        #region "GetPerfectMatchTaskSettings"

        public void GetPerfectMatchTaskSettings(FileBasedProject project)
        {
            #region "PerfectMatchTaskSettings"
            ISettingsBundle settings = project.GetSettings();
            PerfectMatchTaskSettings perfectMatchSettings = settings.GetSettingsGroup<PerfectMatchTaskSettings>();
            #endregion

            #region "MarkAsPerfectMatchAndLock"

            perfectMatchSettings.MarkAsPerfectMatchAndLock.Value = true;
            #endregion


            #region "UpdateTaskSettings"
            project.UpdateSettings(settings);
            #endregion
        }
        #endregion
    }
}

