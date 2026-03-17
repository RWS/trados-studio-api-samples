using System;
using System.IO;
using System.Linq;
using Sdl.LanguagePlatform.Core;
using Sdl.LanguagePlatform.TranslationMemoryApi;

namespace Sdl.Sdk.LanguagePlatform.Samples.ListProvider
{
	public class ListTranslationProvider : ITranslationProvider
	{
		///<summary>
		/// This string needs to be a unique value.
		/// This is the string that precedes the plug-in URI.
		///</summary>    
		public static readonly string ListTranslationProviderScheme = "listprovider";

		#region "ListTranslationOptions"
		public ListTranslationOptions Options
		{
			get;
			set;
		}

		public ListTranslationProvider(ListTranslationOptions options)
		{
			Options = options;
		}
		#endregion

		#region "ITranslationProvider Members"
		public ITranslationProviderLanguageDirection GetLanguageDirection(LanguagePair languageDirection)
		{
			return new ListTranslationProviderLanguageDirection(this, languageDirection);
		}

		public bool IsReadOnly
		{
			get { return true; }
		}

		public void LoadState(string translationProviderState)
		{
		}

		public string Name
		{
			get { return PluginResources.Plugin_NiceName; }
		}

		public void RefreshStatusInfo()
		{

		}

		public string SerializeState()
		{
			// Save settings
			return null;
		}

		public ProviderStatusInfo StatusInfo
		{
			get { return new ProviderStatusInfo(true, PluginResources.Plugin_NiceName); }
		}

		#region "SupportsConcordanceSearch"
		public bool SupportsConcordanceSearch
		{
			get { return true; }
		}
		#endregion

		/// <summary>
		/// Determines the language direction of the delimited list file by
		/// reading the first line. Based upon this information it is determined
		/// whether the plug-in supports the language pair that was selected by
		/// the user.
		/// </summary>
		#region "SupportsLanguageDirection"
		public bool SupportsLanguageDirection(LanguagePair languageDirection)
		{
			string firstLine = "";
			#region "ReadFirstLine"
			using (StreamReader listFile = new StreamReader(Options.ListFileName))
			{
				firstLine = listFile.ReadLine();
				listFile.Close();
			}
			#endregion

			// Check whether the first line of the text file indicates
			// the language direction, e.g. en-US;de-DE.
			// If the first line cannot be split at the delimiter, the delimited list
			// file should not be accepted as translation provider.
			#region "FirstLineCheck"
			string[] langs = firstLine.Split(Convert.ToChar(Options.Delimiter));
			if (langs.Count<string>() != 2)
			{
				return false;
			}

			#endregion

			// This implementation will not be case-sensitive, therefore
			// we use the ToLower() method when comparing the language direction
			// of the delimited file to the language direction that was
			// selected in SDL Trados Studio.
			#region "CompareLanguages"
			if (langs[0].ToLower() == languageDirection.SourceCultureName.ToLower()
				&& langs[1].ToLower() == languageDirection.TargetCultureName.ToLower())
			{
				// The provider supports the selected language direction.
				return true;
			}
			else
			{
				// The provider does not support the selected language direction.
				return false;
			}
			#endregion
		}
		#endregion

		#region "SupportsSearchForTranslationUnits"
		public bool SupportsSearchForTranslationUnits
		{
			get { return true; }
		}
		#endregion

		#region "SupportsSourceTargetConcordanceSearch"
		public bool SupportsSourceConcordanceSearch
		{
			get { return true; }
		}

		public bool SupportsTargetConcordanceSearch
		{
			get { return true; }
		}
		#endregion

		#region "SupportsUpdate"
		public bool SupportsUpdate
		{
			get { return false; }
		}
		#endregion

		public TranslationMethod TranslationMethod
		{
			get { return ListTranslationOptions.ProviderTranslationMethod; }
		}

		#region "Uri"
		public Uri Uri
		{
			get { return Options.Uri; }
		}
		#endregion

		#endregion
	}
}

