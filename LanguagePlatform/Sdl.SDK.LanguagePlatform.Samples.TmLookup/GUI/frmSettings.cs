using System;
using System.Windows.Forms;

namespace Sdl.SDK.LanguagePlatform.Samples.TmLookup
{
	public partial class frmSettings : Form
	{
		public frmSettings()
		{
			InitializeComponent();
		}

		// Property for setting the minimum fuzzy match value
		// that should be used during the search.
		public static int MinFuzzy
		{
			get;
			set;
		}

		// Property for setting the maximum amount of hits to return
		// from the TM.
		public static int MaxHits
		{
			get;
			set;
		}

		private void TrackFuzzy_Scroll(object sender, EventArgs e)
		{
			lblFuzzyValue.Text = trackFuzzy.Value.ToString();
		}

		private void BtnCancel_Click(object sender, EventArgs e)
		{
			Hide();
		}

		// Apply the setting values from the form.
		private void BtnOK_Click(object sender, EventArgs e)
		{
			MaxHits = Convert.ToInt32(txtMaxHits.Text.ToString());
			MinFuzzy = trackFuzzy.Value;

			Hide();
		}

		// Reset the control elements to the corresponding default values.
		private void BtnDefaults_Click(object sender, EventArgs e)
		{
			trackFuzzy.Value = 70;
			lblFuzzyValue.Text = "70";
			txtMaxHits.Text = "30";
		}
	}
}
