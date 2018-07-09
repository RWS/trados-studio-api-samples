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

        #region "PropFuzzy"
        // Property for setting the minimum fuzzy match value
        // that should be used during the search.
        public static int MinFuzzy
        {
            get;
            set;
        }
        #endregion

        #region "PropMaxHits"
        // Property for setting the maximum amount of hits to return
        // from the TM.
        public static int MaxHits
        {
            get;
            set;
        }
        #endregion


        #region "fuzziness"
        private void trackFuzzy_Scroll(object sender, EventArgs e)
        {
            this.lblFuzzyValue.Text = this.trackFuzzy.Value.ToString();
        }
        #endregion

        #region "cancel"
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        #endregion

        #region "ok"
        // Apply the setting values from the form.
        private void btnOK_Click(object sender, EventArgs e)
        {
            MaxHits = Convert.ToInt32(this.txtMaxHits.Text.ToString());
            MinFuzzy = this.trackFuzzy.Value;

            this.Hide();
        }
        #endregion

        #region "default"
        // Reset the control elements to the corresponding default values.
        private void btnDefaults_Click(object sender, EventArgs e)
        {
            this.trackFuzzy.Value = 70;
            this.lblFuzzyValue.Text = "70";
            this.txtMaxHits.Text = "30";
        }
        #endregion

        private void frmSettings_Load(object sender, EventArgs e)
        {
        }

    }
}
