using Sdl.TranslationStudioAutomation.Licensing;
using System.Windows.Forms;


namespace Sdl.SDK.TranslationStudioAutomation
{
	public partial class ShowStudioVersion : Form
	{
		public ShowStudioVersion()
		{
			InitializeComponent();

			#region "ShowEdition"

			editionTextBox.Text = LicenseChecker.CurrentEdition.ToString();
			
			#endregion
		}
	}
}

    