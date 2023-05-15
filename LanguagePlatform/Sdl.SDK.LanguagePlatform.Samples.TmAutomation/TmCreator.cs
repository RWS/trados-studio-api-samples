using Sdl.Core.Globalization;
using Sdl.LanguagePlatform.Core.Tokenization;
using Sdl.LanguagePlatform.TranslationMemory;
using Sdl.LanguagePlatform.TranslationMemoryApi;

namespace Sdl.SDK.LanguagePlatform.Samples.TmAutomation
{
	public class TMCreator
	{
		#region "create TM"
		public void CreateFileBasedTM(string tmPath)
		{
			FileBasedTranslationMemory tm = new FileBasedTranslationMemory(
				tmPath,
				"This is a sample TM",
				new CultureCode("en-US"),
				new CultureCode("de-DE"),
				GetFuzzyIndexes(),
				GetRecognizers(),
				TokenizerFlags.BreakOnHyphen | TokenizerFlags.BreakOnDash,
				WordCountFlags.BreakOnHyphen | WordCountFlags.BreakOnDash | WordCountFlags.BreakOnTag
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
