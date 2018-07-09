namespace Sdl.SDK.ProjectAutomation.Samples.Examples
{
    using System.Globalization;
    using Sdl.Core.Globalization;
    using Sdl.ProjectAutomation.Core;
    using Sdl.ProjectAutomation.FileBased;

    internal class TaskTranslationCount
    {
        #region "RunTranslationCount"
        public void RunTranslationCount(FileBasedProject project, string trgLocale)
        {
            ProjectFile[] deFiles = project.GetTargetLanguageFiles(new Language(CultureInfo.GetCultureInfo(trgLocale)));

            AutomaticTask translationCountTask = project.RunAutomaticTask(
                deFiles.GetIds(),
                AutomaticTaskTemplateIds.TranslationCount);
        }
        #endregion
    }
}
