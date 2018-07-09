namespace Sdl.SDK.ProjectAutomation.Samples.Examples
{
    using Sdl.Core.Settings;
    using Sdl.ProjectAutomation.FileBased;
    using Sdl.ProjectAutomation.Settings;

    internal class TaskUpdateTm
    {
        #region "GetUpdateTmTaskSettings"
        public void GetUpdateTmTaskSettings(FileBasedProject project)
        {
            #region "UpdateTmTaskSettings"
            ISettingsBundle settings = project.GetSettings();
            TranslationMemoryUpdateTaskSettings updateTmSettings = settings.GetSettingsGroup<TranslationMemoryUpdateTaskSettings>();
            #endregion

            #region "NewTranslations"
            updateTmSettings.AlwaysAddNewTranslation.Value = true;
            #endregion

            #region "Status"
            updateTmSettings.UpdateWithApprovedSignOffSegments.Value = true;
            updateTmSettings.UpdateWithApprovedTranslationSegments.Value = true;
            updateTmSettings.UpdateWithTranslatedSegments.Value = true;

            updateTmSettings.UpdateWithDraftSegments.Value = false;
            updateTmSettings.UpdateWithRejectedSignOffSegments.Value = false;
            updateTmSettings.UpdateWithRejectedTranslationSegments.Value = false;
            updateTmSettings.UpdateWithUnspecifiedSegments.Value = false;
            #endregion

            #region "UpdateTaskSettings"
            project.UpdateSettings(settings);
            #endregion
        }
        #endregion
    }
}
