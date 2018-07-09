namespace Sdl.SDK.ProjectAutomation.Samples.Examples
{
    using Sdl.Core.Settings;
    using Sdl.ProjectAutomation.FileBased;
    using Sdl.ProjectAutomation.Settings;

    internal class TaskPretranslate
    {
        #region "GetPretranslateTaskSettings"
        public void GetPretranslateTaskSettings(FileBasedProject project)
        {
            #region "PetranslateTaskSettings"
            ISettingsBundle settings = project.GetSettings();
            TranslateTaskSettings pretranslateSettings = settings.GetSettingsGroup<TranslateTaskSettings>();
            #endregion

            #region "MinimumScore"
            pretranslateSettings.MinimumMatchScore.Value = 95;
            #endregion

            #region "ExactMatches"
            pretranslateSettings.ConfirmAfterApplyingExactMatch.Value = true;
            pretranslateSettings.LockExactMatchSegments.Value = false;
            #endregion

            #region "ContextMatches"
            pretranslateSettings.ConfirmAfterApplyingInContextExactMatch.Value = true;
            pretranslateSettings.LockContextMatchSegments.Value = true;
            #endregion

            #region "NoMatch"
            pretranslateSettings.NoTranslationMemoryMatchFoundAction.Value = NoTranslationMemoryMatchFoundAction.CopySourceToTarget;
            #endregion

            #region "TranslationOverwrite"
            pretranslateSettings.TranslationOverwriteMode.Value = TranslationUpdateMode.OverwriteExistingTranslation;
            #endregion

            #region "UpdateTaskSettings"
            project.UpdateSettings(settings);
            #endregion
        }
        #endregion
    }
}
