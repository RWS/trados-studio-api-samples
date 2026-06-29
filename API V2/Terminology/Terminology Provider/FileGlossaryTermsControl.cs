using System.Collections.Generic;
using System.Windows.Controls;
using TradosStudio.API.TranslationResources.Terminology;
using TradosStudio.API.TranslationResources.Terminology.Entries;

namespace FileGlossaryTerminologyProvider
{
	/// <summary>
	/// WPF control displayed in the Trados Studio Termbase Viewer window.
	/// The left column always shows the source-language terms (read-only).
	/// The right column always shows all languages; it switches between a read-only
	/// TextBlock view and an editable TextBox view based on <see cref="IsEditing"/>.
	/// UI is defined in <c>FileGlossaryTermsControl.xaml</c>; logic lives in
	/// <see cref="FileGlossaryTermsViewModel"/>.
	/// </summary>
	public partial class FileGlossaryTermsControl : UserControl, ITermsView
	{
		private readonly FileGlossaryTermsViewModel _viewModel;

		public bool IsEditing => _viewModel.IsEditing;

		/// <summary>
		/// Replaces the flat list of source-language terms shown in the left panel.
		/// Called by <see cref="FileGlossaryTerminologyProviderViewerWinFormsUI"/> after
		/// any glossary mutation or on initial load.
		/// </summary>
		internal void SetAllSourceTerms(IEnumerable<string> terms) => _viewModel.SetAllSourceTerms(terms);

		public FileGlossaryTermsControl()
		{
			_viewModel = new FileGlossaryTermsViewModel();
			InitializeComponent();
			DataContext = _viewModel;
		}

		/// <summary>Displays <paramref name="entry"/> in read-only mode.</summary>
		internal void ShowEntry(Entry entry) => _viewModel.ShowEntry(entry);

		/// <summary>Switches the control into edit mode for <paramref name="entry"/>.</summary>
		internal void EnterEditMode(Entry entry) => _viewModel.EnterEditMode(entry);

		/// <summary>Exits edit mode and reverts to the read-only view.</summary>
		internal void ExitEditMode() => _viewModel.ExitEditMode();

		/// <summary>Returns the entry with values currently shown in the edit-mode text boxes.</summary>
		internal Entry GetEditedEntry() => _viewModel.GetEditedEntry();
	}
}
