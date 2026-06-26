using System.Windows.Controls;
using TradosStudio.API.UI;

namespace TranslationStudioAutomationPlugin
{
	/// <summary>
	/// Interaction logic for DocumentsViewPart.xaml
	/// </summary>
	public partial class DocumentsViewPartUI : UserControl, IUIControl
	{
		public DocumentsViewPartUI()
		{
			InitializeComponent();
		}

		public void Dispose()
		{
		}
	}
}
