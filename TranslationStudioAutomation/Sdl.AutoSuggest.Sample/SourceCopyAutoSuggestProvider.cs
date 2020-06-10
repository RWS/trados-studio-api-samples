using Sdl.FileTypeSupport.Framework.BilingualApi;
using Sdl.TranslationStudioAutomation.IntegrationApi.AutoSuggest;
using Sdl.TranslationStudioAutomation.IntegrationApi.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Sdl.AutoSuggest.Sample
{
	[AutoSuggestProvider(Id = "SourceCopyAutoSuggestProvider", Name = "AutoSuggest provider for copying the source words")]
	public class SourceCopyAutoSuggestProvider : AbstractAutoSuggestProvider
	{
		private List<string> _segmentWordSuggestCandidates;

		public SourceCopyAutoSuggestProvider()
		{
			// Set the default icon for the suggestions from this provider
			Icon = new Icon(SystemIcons.Exclamation, 16, 16);
		}

		#region AutoSuggestProvider Implementation
		/// <summary>
		/// This function is not necessary for this sample. It just shows in case you need dictionary or some other language specific action, you can do it here.
		/// </summary>
		protected override void OnActiveDocumentChanged()
		{
			if (ActiveDocument != null)
			{
				var sourceLanguage = ActiveDocument.Project.GetProjectInfo().SourceLanguage;
				var targetLanguage = ActiveDocument.Files.First().Language;

				System.Diagnostics.Debug.WriteLine("SourceCopyAutoSuggestProvider Language pair: {0}->{1}", sourceLanguage.DisplayName, targetLanguage.DisplayName);

				// in case you need prepare the dictionary for this language pair, do it here
			}
			else
			{
				_segmentWordSuggestCandidates = null;
			}

			System.Diagnostics.Debug.WriteLine("OnActiveDocumentChanged  {0}", ActiveDocument != null);
		}

		// when user goes to a segment, we want to prepare the AutoSuggest Candidate first. 
		// when it takes long, for performance reason, the execution might be done in a separate thread.
		protected override void OnActiveSegmentChanged()
		{
			if (Settings.Enabled)
			{
				PrepareSegmentSuggestCandiates();
			}
			else
			{
				_segmentWordSuggestCandidates = null;
			}
			System.Diagnostics.Debug.WriteLine("OnActiveSegmentChanged  {0}", ActiveSegmentPair != null);
		}

		/// <summary>
		/// We only provide the AutoSuggest when the candidate is available. The user might have the change from disabled to enabled, we need preapre the candidate.
		/// </summary>
		protected override void OnSettingsChanged()
		{
			if (Settings.Enabled)
			{
				PrepareSegmentSuggestCandiates();
			}
			else
			{
				_segmentWordSuggestCandidates = null;
			}
		}

		protected override IEnumerable<AbstractAutoSuggestResult> GetSuggestions(AbstractEditingContext context)
		{
			if (Settings.Enabled)
			{
				string suffix = context.GetAllPrefixes().First();
				if (!string.IsNullOrEmpty(suffix) && _segmentWordSuggestCandidates != null && _segmentWordSuggestCandidates.Count > 0)
				{
					return _segmentWordSuggestCandidates
						.Where(item => item.StartsWith(suffix, Settings.CaseSensitive ? StringComparison.InvariantCulture : StringComparison.InvariantCultureIgnoreCase))
						.Select(item =>
							{
								var result = new AutoSuggestTextResult(context, item);
								result.Priority = Settings.Priority;

								// Set different icon for suggestions starting with "a". For the rest set the default provider icon
								result.Icon = result.Text.StartsWith("a") ? new Icon(SystemIcons.Question, 16, 16) : Icon;

								return result;
							});
				}

			}
			return null;
		}

		#endregion

		private void PrepareSegmentSuggestCandiates()
		{
			if (ActiveSegmentPair != null)
			{
				var stringBuilder = new StringBuilder();
				foreach (var item in ActiveSegmentPair.Source.AllSubItems)
				{
					var text = item as IText;
					if (text != null)
					{
						stringBuilder.Append(text.Properties.Text);
					}
				}

				// Split the sentence to words in a naive way, in practice a better way is needed to to tokenize the sentence.
				// As a sample we will show the source words in the AutoSuggest, in practice, translation to the target language are needed
				_segmentWordSuggestCandidates = Regex.Split(stringBuilder.ToString(), @"\W+").ToList();

				System.Diagnostics.Debug.WriteLine("PrepareSegmentSuggestCandiates: {0}", stringBuilder.ToString());
				System.Diagnostics.Debug.WriteLine("{0}", _segmentWordSuggestCandidates == null);
			}
		}
	}
}
