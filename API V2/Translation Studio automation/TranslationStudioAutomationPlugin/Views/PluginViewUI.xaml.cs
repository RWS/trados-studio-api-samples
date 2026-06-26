using System.Windows.Controls;
using TradosStudio.API.UI;

namespace TranslationStudioAutomationPlugin.Views
{
	/// <summary>
	/// Interaction logic for PluginViewUI.xaml
	/// </summary>
	public partial class PluginViewUI : UserControl, IUIControl
	{
		public PluginViewUI()
		{
			InitializeComponent();
		}

		public void Dispose()
		{
			/// clean up resources if needed
		}
	}
}
