using Sdl.TranslationStudioAutomation.Licensing;
using System.Windows.Forms;


namespace Sdl.License.Sample
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

    