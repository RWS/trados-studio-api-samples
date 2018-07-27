namespace Sdl.SDK.ProjectAutomation.Samples.Examples
{
    using System.Globalization;
    using Sdl.Core.Globalization;
    using Sdl.Core.Settings;
    using Sdl.ProjectAutomation.FileBased;
    using Sdl.ProjectAutomation.Settings;

    internal class TaskSettings
    {
        #region "ConfigureBatchTaskSettings"
        public void ConfigureBatchTaskSettings(FileBasedProject project, string trgLocale, int minMatchValue)
        {
            #region "SetLanguage"
            Language trgLanguage = new Language(CultureInfo.GetCultureInfo(trgLocale));
            #endregion

            #region "TaskSettings"
            ISettingsBundle settings = project.GetSettings(trgLanguage);
            TranslateTaskSettings pretranslateSettings = settings.GetSettingsGroup<TranslateTaskSettings>();
            #endregion

            #region "MinimumMatchScore"
            pretranslateSettings.MinimumMatchScore.Value = minMatchValue;
            #endregion

            #region "UpdateSettings"
            project.UpdateSettings(trgLanguage, settings);
            #endregion
        }
        #endregion
    }
}
