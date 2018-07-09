namespace Sdl.SDK.LanguagePlatform.Samples.TmAutomation
{
    using System.Windows.Forms;
    using Sdl.LanguagePlatform.TranslationMemoryApi;

    public class TMTuner
    {
        public void TuneTm(string tmPath)
        {
            #region "tune"
            FileBasedTranslationMemory tm = new FileBasedTranslationMemory(tmPath);

            tm.RecomputeFuzzyIndexStatistics();
            tm.Save();
            #endregion

            #region "stats"
            string stats;
            stats = "Fuzzy index last recomputed at: " + tm.FuzzyIndexStatisticsRecomputedAt.Value.ToString();
            stats += "; Fuzzy index needs to be recomuted: " + tm.ShouldRecomputeFuzzyIndexStatistics().ToString();

            MessageBox.Show(stats);
            #endregion
        }
    }
}
