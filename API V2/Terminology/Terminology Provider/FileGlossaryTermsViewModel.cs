using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TradosStudio.API.TranslationResources.Terminology.Entries;

namespace FileGlossaryTerminologyProvider
{
	/// <summary>
	/// Drives <see cref="FileGlossaryTermsControl"/>.
	/// Exposes an observable <see cref="Languages"/> list and an <see cref="IsEditing"/> flag;
	/// the view responds to property-change notifications to toggle the edit column.
	/// </summary>
	internal class FileGlossaryTermsViewModel : INotifyPropertyChanged
	{
		private bool _isEditing;
		private Entry _editingEntry;

		public ObservableCollection<LanguageViewModel> Languages { get; } =
			new ObservableCollection<LanguageViewModel>();

		/// <summary>Flat, sorted list of every source-language term in the glossary, shown in the left panel.</summary>
		public ObservableCollection<string> AllSourceTerms { get; } = new ObservableCollection<string>();

		/// <summary>
		/// Replaces <see cref="AllSourceTerms"/> with the pre-fetched <paramref name="terms"/> list.
		/// Called by <see cref="FileGlossaryTerminologyProviderViewerWinFormsUI"/> after any glossary mutation.
		/// </summary>
		public void SetAllSourceTerms(IEnumerable<string> terms)
		{
			AllSourceTerms.Clear();
			if (terms == null)
			{
				return;
			}

			foreach (var term in terms)
			{
				AllSourceTerms.Add(term);
			}
		}

		public bool IsEditing
		{
			get => _isEditing;
			private set
			{
				_isEditing = value;
				OnPropertyChanged();
				foreach (var lang in Languages)
				{
					lang.IsEditing = value;
				}
			}
		}

		public void ShowEntry(Entry entry)
		{
			_editingEntry = null;
			IsEditing = false;
			RebuildLanguages(entry);
		}

		public void EnterEditMode(Entry entry)
		{
			if (entry?.Languages != null)
			{
				foreach (var lang in entry.Languages)
				{
					if (lang.Terms == null)
					{
						lang.Terms = new List<EntryTerm>();
					}
				}
			}

			_editingEntry = entry;
			IsEditing = true;
			RebuildLanguages(entry);
		}

		public void ExitEditMode()
		{
			var entry = _editingEntry;
			_editingEntry = null;
			IsEditing = false;
			RebuildLanguages(entry);
		}

		public Entry GetEditedEntry() => _editingEntry;

		private void RebuildLanguages(Entry entry)
		{
			Languages.Clear();

			if (entry?.Languages == null)
			{
				return;
			}

			foreach (var lang in entry.Languages)
			{
				Languages.Add(new LanguageViewModel(lang, _isEditing));
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChanged([CallerMemberName] string propertyName = null)
			=> PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}

	/// <summary>
	/// Represents one language block inside the terms control.
	/// Exposes an observable <see cref="Terms"/> list and an <see cref="AddTermCommand"/>
	/// that appends a new empty term to both the model and the collection.
	/// <see cref="IsEditing"/> is propagated from <see cref="FileGlossaryTermsViewModel.IsEditing"/>
	/// so that the XAML DataTriggers can toggle read-only vs. editable templates.
	/// </summary>
	internal class LanguageViewModel : INotifyPropertyChanged
	{
		private readonly EntryLanguage _language;
		private bool _isEditing;

		public LanguageViewModel(EntryLanguage language, bool isEditing = false)
		{
			_language = language;
			_isEditing = isEditing;
			Terms = new ObservableCollection<TermViewModel>(
				(language.Terms ?? Enumerable.Empty<EntryTerm>()).Select(t => new TermViewModel(t)));
			AddTermCommand = new RelayCommand(AddTerm);
		}

		public string Header =>
			string.IsNullOrEmpty(_language.Name) ? _language.LanguageIsoCode : _language.Name;

		public string LanguageIsoCode => _language.LanguageIsoCode;

		public bool IsEditing
		{
			get => _isEditing;
			set { _isEditing = value; OnPropertyChanged(); }
		}

		public ObservableCollection<TermViewModel> Terms { get; }

		public ICommand AddTermCommand { get; }

		private void AddTerm()
		{
			var newTerm = new EntryTerm
			{
				Value = string.Empty,
				ParentLanguage = _language,
				Fields = new List<EntryField>(),
				Transactions = new List<EntryTransaction>()
			};
			_language.Terms.Add(newTerm);
			Terms.Add(new TermViewModel(newTerm));
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChanged([CallerMemberName] string propertyName = null)
			=> PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}

	/// <summary>
	/// Wraps a single <see cref="EntryTerm"/> and writes edits back to the model immediately
	/// so that <see cref="FileGlossaryTermsViewModel.GetEditedEntry"/> always reflects current input.
	/// </summary>
	internal class TermViewModel : INotifyPropertyChanged
	{
		private readonly EntryTerm _term;

		public TermViewModel(EntryTerm term) => _term = term;

		public string Value
		{
			get => _term.Value;
			set { _term.Value = value; OnPropertyChanged(); }
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChanged([CallerMemberName] string propertyName = null)
			=> PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
