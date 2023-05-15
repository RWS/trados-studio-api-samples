using Sdl.Core.Globalization;
using Sdl.Core.Globalization.LanguageRegistry;
using Sdl.LanguagePlatform.Core.Tokenization;
using Sdl.LanguagePlatform.TranslationMemory;
using Sdl.LanguagePlatform.TranslationMemoryApi;

namespace Sdl.SDK.LanguagePlatform.Samples.TmAutomation
{
	public class TMCreator
	{
		public void CreateFileBasedTM(string tmPath)
		{
			FileBasedTranslationMemory tm = new FileBasedTranslationMemory(
				tmPath,
				"This is a sample TM",
				GetCultureCode("en-US"),
				GetCultureCode("de-DE"),
				GetFuzzyIndexes(),
				GetRecognizers(),
				TokenizerFlags.BreakOnHyphen | TokenizerFlags.BreakOnDash,
				WordCountFlags.BreakOnHyphen | WordCountFlags.BreakOnDash | WordCountFlags.BreakOnTag
				);

			tm.LanguageResourceBundles.Clear();

			tm.Save();
		}

		// Studio has it's internal language registry to ensure that our application is OS independent 
		private CultureCode GetCultureCode(string cultureIsoCode)
		{
			try
			{
				// Language registry contains all the languages that are supported in Studio				
				var language = LanguageRegistryApi.Instance.GetLanguage(cultureIsoCode);
				return new CultureCode(language.CultureInfo);
			}
			catch (UnsupportedLanguageException)
			{
				// In case the language is not supported an exception is thrown
				return null;
			}
		}

		private FuzzyIndexes GetFuzzyIndexes()
		{
			return FuzzyIndexes.SourceCharacterBased |
				FuzzyIndexes.SourceWordBased |
				FuzzyIndexes.TargetCharacterBased |
				FuzzyIndexes.TargetWordBased;
		}

		private BuiltinRecognizers GetRecognizers()
		{
			return BuiltinRecognizers.RecognizeAcronyms |
				BuiltinRecognizers.RecognizeDates |
				BuiltinRecognizers.RecognizeNumbers |
				BuiltinRecognizers.RecognizeTimes |
				BuiltinRecognizers.RecognizeVariables |
				BuiltinRecognizers.RecognizeMeasurements;
		}
	}
}
