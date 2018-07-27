namespace Sdl.SDK.LanguagePlatform.Samples.TmAutomation
{
    using System.Globalization;
    using Sdl.LanguagePlatform.Core.Tokenization;
    using Sdl.LanguagePlatform.TranslationMemory;
    using Sdl.LanguagePlatform.TranslationMemoryApi;

    public class TMCreator
    {
        #region "create TM"
        public void CreateFileBasedTM(string tmPath)
        {
            FileBasedTranslationMemory tm = new FileBasedTranslationMemory(
                tmPath,
                "This is a sample TM",
                CultureInfo.GetCultureInfo("en-US"),
                CultureInfo.GetCultureInfo("de-DE"),
                this.GetFuzzyIndexes(),
                this.GetRecognizers(),
                TokenizerFlags.AllFlags,
                WordCountFlags.AllFlags
                );

            tm.LanguageResourceBundles.Clear();

            tm.Save();
        }
        #endregion

        #region "get fuzzy indexes"
        private FuzzyIndexes GetFuzzyIndexes()
        {
            return FuzzyIndexes.SourceCharacterBased |
                FuzzyIndexes.SourceWordBased |
                FuzzyIndexes.TargetCharacterBased |
                FuzzyIndexes.TargetWordBased;
        }
        #endregion

        #region "get recognizers"
        private BuiltinRecognizers GetRecognizers()
        {
            return BuiltinRecognizers.RecognizeAcronyms |
                BuiltinRecognizers.RecognizeDates |
                BuiltinRecognizers.RecognizeNumbers |
                BuiltinRecognizers.RecognizeTimes |
                BuiltinRecognizers.RecognizeVariables |
                BuiltinRecognizers.RecognizeMeasurements;
        }
        #endregion
    }
}
