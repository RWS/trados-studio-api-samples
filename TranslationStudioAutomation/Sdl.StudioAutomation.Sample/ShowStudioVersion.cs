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

			switch (LicenseChecker.CurrentEdition)
			{
				case StudioEdition.WorkGroup:
					this.editionTextBox.Text = "WorkGroup";
					break;
				case StudioEdition.Professional:
					this.editionTextBox.Text = "Professional";
					break;
				case StudioEdition.Freelance:
					this.editionTextBox.Text = "Freelance";
					break;
			}
			#endregion
		}
	}
}
