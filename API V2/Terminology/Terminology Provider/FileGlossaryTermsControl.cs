using System.Windows;
using System.Windows.Controls;
using TradosStudio.API.TranslationResources.Terminology;
using TradosStudio.API.TranslationResources.Terminology.Entries;

namespace FileGlossaryTerminologyProvider
{
	/// <summary>
	/// WPF control displayed in the Trados Studio Termbase Viewer window.
	/// Shows the languages and terms of the currently selected <see cref="Entry"/>.
	/// </summary>
	public class FileGlossaryTermsControl : UserControl, ITermsView
	{
		private readonly StackPanel _stackPanel;

		public FileGlossaryTermsControl()
		{
			_stackPanel = new StackPanel { Margin = new Thickness(4) };

			Content = new ScrollViewer
			{
				Content = _stackPanel,
				VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
				HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled
			};
		}

		internal void ShowEntry(Entry entry)
		{
			_stackPanel.Children.Clear();

			if (entry == null || entry.Languages == null)
				return;

			foreach (var lang in entry.Languages)
			{
				var header = string.IsNullOrEmpty(lang.Name) ? lang.LanguageIsoCode : lang.Name;

				_stackPanel.Children.Add(new TextBlock
				{
					Text = header,
					FontWeight = FontWeights.Bold,
					Margin = new Thickness(0, 4, 0, 2)
				});

				if (lang.Terms != null)
				{
					foreach (var term in lang.Terms)
					{
						_stackPanel.Children.Add(new TextBlock
						{
							Text = term.Value,
							Margin = new Thickness(8, 0, 0, 2)
						});
					}
				}
			}
		}
	}
}
