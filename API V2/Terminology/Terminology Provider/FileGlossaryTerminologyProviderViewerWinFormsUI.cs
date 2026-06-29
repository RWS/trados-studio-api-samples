using System;
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

		public event EventHandler TermChanged;
		public event EventHandler<EntryEventArgs> SelectedTermChanged;

		public bool SupportsTerminologyProviderUri(Uri terminologyProviderUri)
		{
			return terminologyProviderUri != null
				&& string.Equals(terminologyProviderUri.Scheme, FileGlossaryTerminologyProvider.UriScheme, StringComparison.OrdinalIgnoreCase);
		}

		public void Initialize(ITerminologyProvider terminologyProvider, string source, string target)
		{
			Initialized = true;
		}

		public void Release()
		{
			_control = null;
			Initialized = false;
			_selectedTerm = null;
		}

		public void JumpToTerm(Entry entry)
		{
			_control?.ShowEntry(entry);
		}

		public void AddTerm(string source, string target)
		{
			// The backing provider is read-only; adding is not supported.
		}

		public bool CanAddTerm => false;

		public void EditTerm(Entry term)
		{
			// The backing provider is read-only; editing is not supported.
		}

		public bool IsEditing => false;

		public void AddAndEditTerm(Entry term, string source, string target)
		{
			// The backing provider is read-only; editing is not supported.
		}

		public void CancelTerm()
		{
			// Nothing to cancel.
		}

		public void SaveTerm()
		{
			// Nothing to save.
		}

		public ITermsView Control
		{
			get
			{
				if (_control == null)
				{
					_control = new FileGlossaryTermsControl();
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
	}
}
