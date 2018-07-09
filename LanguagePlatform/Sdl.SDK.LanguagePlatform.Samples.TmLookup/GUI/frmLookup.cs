using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sdl.SDK.LanguagePlatform.Samples.TmLookup
{
    public partial class frmLookup : Form
    {
        private frmSettings settings = new frmSettings();

        #region "initialize"
        // Initialize form with default search settings.
        public frmLookup()
        {
            InitializeComponent();
            frmSettings.MaxHits = 30;
            frmSettings.MinFuzzy = 70;
        }
        #endregion
        
        #region "close"
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion 

        #region "menu"
        private void searchOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settings.Show();
        }
        #endregion

        #region "ExecuteSearch"
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                #region "SearchObject"
                Search search = new Search();
                #endregion

                #region "SourceOrTarget"
                // Determine whether to do the concordance search in the
                // source or in the target language;
                bool searchTarget;
                if (this.comboIndex.Text == "Target")
                    searchTarget = true;
                else
                    searchTarget = false;
                #endregion

                #region "FillHitlist"
                // Fill the search result into the rich text box.
                this.lblHitCount.Text = search.DoConcordanceSearch(this.txtSearch.Text, searchTarget,
                    comboLanguagePairs.SelectedIndex);
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show("No TM selected." + ex.Message);
            }
        }
        #endregion 

        #region "btnSelectTm_Click"
        private void btnSelectTm_Click(object sender, EventArgs e)
        {
            contextMenuTm.Show(btnSelectTm, new Point(0, 20));
        }
        #endregion

        #region "SelectFileTm"
        private void selectFileTMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Raise open file dialog.
            this.openFileDialog.Title = "Select Translation Memory File";
            this.openFileDialog.Filter = "Translation memories (*.sdltm)|*.sdltm";

            // Check whether an *.sdltm file was selected
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Create a new connector object to connect to the file TM
                Connector fileConnect = new Connector();
                fileConnect.SelectFileTm(this.openFileDialog.FileName);
                this.txtTmPath.Text = this.openFileDialog.FileName;

                // File TMs have only one language direction, which is filled into the 
                // language pair list.
                string srcLang = Connector.FileTm.LanguageDirection.SourceLanguage.DisplayName.ToString();
                string trgLang = Connector.FileTm.LanguageDirection.TargetLanguage.DisplayName.ToString();

                this.comboLanguagePairs.Items.Clear();
                this.comboLanguagePairs.Text = srcLang + " -> " + trgLang;
            }
        }
        #endregion

        #region "RaiseServerTmForm"
        private void selectServerTMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSelectTM selectTm = new frmSelectTM();
            selectTm.Show();
        }
        #endregion

        private void groupBoxTm_Enter(object sender, EventArgs e)
        {
        }

        private void frmLookup_Load(object sender, EventArgs e)
        {
        }

    }
}
