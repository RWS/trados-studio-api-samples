using System;
using System.Windows.Forms;

namespace Sdl.Sdk.LanguagePlatform.Samples.ListProvider
{
    public partial class ListProviderConfDialog : Form
    {
        #region "ListProviderConfDialog"
        public ListProviderConfDialog(ListTranslationOptions options)
        {
            Options = options;
            InitializeComponent();
            UpdateDialog();
        }

        public ListTranslationOptions Options
        {
            get;
            set;
        }
        #endregion

        #region "UpdateDialog"
        private void UpdateDialog()
        {
            txt_ListFile.Text = Options.ListFileName;
            combo_delimiter.Text = Options.Delimiter;
        }
        #endregion

        #region "Browse"
        private void Btn_Browse_Click(object sender, EventArgs e)
        {
            this.dlg_OpenFile.ShowDialog();
            string fileName = dlg_OpenFile.FileName;

            if (fileName != "")
            {
                txt_ListFile.Text = fileName;
            }
        }
        #endregion

        #region "OK"
        private void Bnt_OK_Click(object sender, EventArgs e)
        {
            Options.Delimiter = this.combo_delimiter.Text;
            Options.ListFileName = this.txt_ListFile.Text;
        }
        #endregion

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
        }
    }
}
