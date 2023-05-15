using System;
using System.Drawing;
using System.Windows.Forms;
using Sdl.Core.Globalization.LanguageRegistry;

namespace Sdl.SDK.LanguagePlatform.Samples.TmLookup
{
	public partial class frmLookup : Form
	{
		private readonly frmSettings settings = new frmSettings();

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
		private void BtnClose_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
		#endregion

		#region "menu"
		private void SearchOptionsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			settings.Show();
		}
		#endregion

		#region "ExecuteSearch"
		private void BtnSearch_Click(object sender, EventArgs e)
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
				if (comboIndex.Text == "Target")
				{
					searchTarget = true;
				}
				else
				{
					searchTarget = false;
				}
				#endregion

				#region "FillHitlist"
				// Fill the search result into the rich text box.
				lblHitCount.Text = search.DoConcordanceSearch(txtSearch.Text, searchTarget,
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
		private void BtnSelectTm_Click(object sender, EventArgs e)
		{
			contextMenuTm.Show(btnSelectTm, new Point(0, 20));
		}
		#endregion

		#region "SelectFileTm"
		private void SelectFileTMToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Raise open file dialog.
			openFileDialog.Title = "Select Translation Memory File";
			openFileDialog.Filter = "Translation memories (*.sdltm)|*.sdltm";

			// Check whether an *.sdltm file was selected
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				// Create a new connector object to connect to the file TM
				Connector fileConnect = new Connector();
				fileConnect.SelectFileTm(openFileDialog.FileName);
				txtTmPath.Text = openFileDialog.FileName;

				// File TMs have only one language direction, which is filled into the 
				// language pair list.
				var srcLang = LanguageRegistryApi.Instance.GetLanguage(Connector.FileTm.LanguageDirection.SourceLanguage);
				var trgLang = LanguageRegistryApi.Instance.GetLanguage(Connector.FileTm.LanguageDirection.TargetLanguage);

				comboLanguagePairs.Items.Clear();
				comboLanguagePairs.Text = srcLang.DisplayName + " -> " + trgLang.DisplayName;
			}
		}
		#endregion

		#region "RaiseServerTmForm"
		private void SelectServerTMToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmSelectTM selectTm = new frmSelectTM();
			selectTm.Show();
		}
		#endregion
	}
}
