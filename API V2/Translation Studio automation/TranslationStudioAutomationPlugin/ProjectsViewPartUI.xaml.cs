using System.Windows.Controls;
using TradosStudio.API.UI;

namespace TranslationStudioAutomationPlugin
{
	/// <summary>
	/// Interaction logic for ProjectsViewPartUI.xaml
	/// </summary>
	public partial class ProjectsViewPartUI : UserControl, IUIControl
	{
		public ProjectsViewPartUI()
		{
			InitializeComponent();
		}

		public void Dispose()
		{
		}
	}
}
