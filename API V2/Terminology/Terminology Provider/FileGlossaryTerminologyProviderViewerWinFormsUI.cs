using System;
using System.Collections.Generic;
using System.Linq;
using TradosStudio.API.TranslationResources.Terminology;
using TradosStudio.API.TranslationResources.Terminology.Entries;

namespace FileGlossaryTerminologyProvider
{
	/// <summary>
	/// WinForms viewer UI for the file glossary provider. Displays term details in the
	/// Trados Studio Termbase Viewer window inside the Editor View.
	/// Registered with the plugin container in <see cref="Plugin.RegisterTypes"/>.
	/// </summary>
	public class FileGlossaryTerminologyProviderViewerWinFormsUI : ITerminologyProviderViewerWinFormsUI
	{
		private FileGlossaryTermsControl _control;
		private Entry _selectedTerm;
		private FileGlossaryTerminologyProvider _provider;
		private string _sourceIso;
		private string _targetIso;
		private string _sourceLangName;
		private string _targetLangName;

		public event EventHandler TermChanged;
		public event EventHandler<EntryEventArgs> SelectedTermChanged;

		public bool SupportsTerminologyProviderUri(Uri terminologyProviderUri)
		{
			return terminologyProviderUri != null
				&& string.Equals(terminologyProviderUri.Scheme, FileGlossaryTerminologyProvider.UriScheme, StringComparison.OrdinalIgnoreCase);
		}

		public void Initialize(ITerminologyProvider terminologyProvider, string source, string target)
		{
			_provider = terminologyProvider as FileGlossaryTerminologyProvider;
			_sourceIso = source;
			_targetIso = target;

			if (_provider != null)
			{
				var languages = _provider.GetLanguages();
				_sourceLangName = languages.FirstOrDefault(l => string.Equals(l.LanguageIsoCode, source, StringComparison.OrdinalIgnoreCase))?.Name ?? source;
				_targetLangName = languages.FirstOrDefault(l => string.Equals(l.LanguageIsoCode, target, StringComparison.OrdinalIgnoreCase))?.Name ?? target;
			}

			Initialized = true;
		}

		public void Release()
		{
			_control = null;
			_provider = null;
			Initialized = false;
			_selectedTerm = null;
		}

		public void JumpToTerm(Entry entry)
		{
			_control?.ShowEntry(entry);
		}

		public void AddTerm(string source, string target)
		{
			_provider?.AddOrUpdateEntry(source, _sourceIso, _sourceLangName, target, _targetIso, _targetLangName);
			RefreshSourceTerms();
			TermChanged?.Invoke(this, EventArgs.Empty);
		}

		public bool CanAddTerm => _provider != null;

		public void EditTerm(Entry term)
		{
			_control?.EnterEditMode(term);
		}

		public bool IsEditing => _control?.IsEditing ?? false;

		public void AddAndEditTerm(Entry term, string source, string target)
		{
			if (_provider == null)
			{
				return;
			}

			_control?.EnterEditMode(BuildDraftEntry(source, target));
		}

		public void CancelTerm()
		{
			_control?.ExitEditMode();
		}

		public void SaveTerm()
		{
			if (_control == null || !_control.IsEditing)
			{
				return;
			}

			var edited = _control.GetEditedEntry();
			if (edited != null)
			{
				_provider?.UpdateEntry(edited);
				RefreshSourceTerms();
				TermChanged?.Invoke(this, EventArgs.Empty);
			}

			_control.ExitEditMode();
		}

		public ITermsView Control
		{
			get
			{
				if (_control == null)
				{
					_control = new FileGlossaryTermsControl();
					RefreshSourceTerms();
				}

				return _control;
			}
		}

		public bool Initialized { get; private set; }

		public Entry SelectedTerm
		{
			get => _selectedTerm;
			set
			{
				_selectedTerm = value;
				_control?.ShowEntry(value);
				SelectedTermChanged?.Invoke(this, new EntryEventArgs(value));
			}
		}

		private void RefreshSourceTerms()
		{
			if (_control == null || _provider == null || string.IsNullOrEmpty(_sourceIso))
			{
				return;
			}

			_control.SetAllSourceTerms(_provider.GetAllSourceTerms(_sourceIso));
		}

		private Entry BuildDraftEntry(string sourceTerm, string targetTerm)
		{
			var entry = new Entry
			{
				Id = 0,
				Fields = new List<EntryField>(),
				Transactions = new List<EntryTransaction>(),
				Languages = new List<EntryLanguage>()
			};

			if (!string.IsNullOrEmpty(_sourceIso))
			{
				var sourceLang = new EntryLanguage
				{
					Name = _sourceLangName,
					LanguageIsoCode = _sourceIso,
					ParentEntry = entry,
					Fields = new List<EntryField>(),
					Terms = new List<EntryTerm>()
				};
				if (!string.IsNullOrWhiteSpace(sourceTerm))
				{
					sourceLang.Terms.Add(new EntryTerm { Value = sourceTerm, ParentLanguage = sourceLang, Fields = new List<EntryField>(), Transactions = new List<EntryTransaction>() });
				}

				entry.Languages.Add(sourceLang);
			}

			if (!string.IsNullOrEmpty(_targetIso))
			{
				var targetLang = new EntryLanguage
				{
					Name = _targetLangName,
					LanguageIsoCode = _targetIso,
					ParentEntry = entry,
					Fields = new List<EntryField>(),
					Terms = new List<EntryTerm>()
				};
				if (!string.IsNullOrWhiteSpace(targetTerm))
				{
					targetLang.Terms.Add(new EntryTerm { Value = targetTerm, ParentLanguage = targetLang, Fields = new List<EntryField>(), Transactions = new List<EntryTransaction>() });
				}

				entry.Languages.Add(targetLang);
			}

			return entry;
		}
	}
}
