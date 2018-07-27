namespace Sdl.SDK.ProjectAutomation.Samples.Examples
{
    using Sdl.Core.Settings;
    using Sdl.ProjectAutomation.FileBased;
    using Sdl.ProjectAutomation.Settings;

    internal class TaskAnalyze
    {
        #region "GetAnalyzeTaskSettings"
        public void GetAnalyzeTaskSettings(FileBasedProject project)
        {
            #region "AnalysisTaskSettings"
            ISettingsBundle settings = project.GetSettings();
            AnalysisTaskSettings analyseSettings = settings.GetSettingsGroup<AnalysisTaskSettings>();
            #endregion

            #region "ReportCrossFileRepetitions"
            analyseSettings.ReportCrossFileRepetitions.Value = true;
            #endregion

            #region "ReportInternalFuzzyMatchLeverage"
            analyseSettings.ReportInternalFuzzyMatchLeverage.Value = true;
            #endregion

            #region "ExportFrequentSettings"
            analyseSettings.ExportFrequentSegments.Value = true;
            analyseSettings.FrequentSegmentsNoOfOccurrences.Value = 5;
            #endregion

            #region "ExportUnknownSegments"
            analyseSettings.ExportUnknownSegments.Value = true;
            analyseSettings.UnknownSegmentsMaximumMatchValue.Value = 50;
            #endregion

            #region "UpdateAnalyzeSettings"
            project.UpdateSettings(settings);
            #endregion
        }
        #endregion

        #region "GetAnalyzeStats"

        public void GetAnalyzeStats(FileBasedProject project)
        {
            return;
        }

        #endregion
    }
}
