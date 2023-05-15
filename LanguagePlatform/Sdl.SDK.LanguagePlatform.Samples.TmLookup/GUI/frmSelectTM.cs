using System;
using System.Windows.Forms;
using Sdl.Core.Globalization.LanguageRegistry;

namespace Sdl.SDK.LanguagePlatform.Samples.TmLookup
{
	public partial class frmSelectTM : Form
	{
		public frmSelectTM()
		{
			InitializeComponent();
		}

		#region "cancel"
		private void BtnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}
		#endregion

		#region "connect"
		// By clicking the Connect button you establish a connection with the TM
		// Server. This will fill populate the dropdown list with the names of the
		// server TMs and enable the list, which is by default disabled.
		// Moreover, the OK button gets enabled.
		private void BtnConnect_Click(object sender, EventArgs e)
		{
			Connector connection = new Connector();
			connection.Connect(txtServerUri.Text, txtUserName.Text,
				txtPassword.Text, comboServerTMs);

			btnOK.Enabled = true;
		}
		#endregion

		#region "ok"
		// By clicking OK the user connects the server-based TM
		// through the Connector class.
		// The TM language directions are propagated into the corresponding list of the frmLookup form.
		private void BtnOK_Click(object sender, EventArgs e)
		{
			// Establish a connection to the TM Server.
			Connector connect = new Connector();

			connect.SelectServerTm(comboServerTMs.Text, txtServerUri.Text,
					txtUserName.Text, txtPassword.Text);

			// Enter the TM URI and TM name into the main application form.
			frmLookup lookupFrm = new frmLookup();
			lookupFrm.txtTmPath.Text = Connector.ServerTM.Uri.ToString();

			// Loop throught the available language directions of the selected TM and fill them
			// into the corresponding list in the main application form.
			lookupFrm.comboLanguagePairs.Items.Clear();
			for (int i = 0; i < Connector.ServerTM.LanguageDirections.Count; i++)
			{
				var srcLang = LanguageRegistryApi.Instance.GetLanguage(Connector.FileTm.LanguageDirection.SourceLanguage);
				var trgLang = LanguageRegistryApi.Instance.GetLanguage(Connector.FileTm.LanguageDirection.TargetLanguage);
				lookupFrm.comboLanguagePairs.Items.Add(srcLang.DisplayName + " -> " + trgLang.DisplayName);
			}

			// Select the first available language direction.
			var currentSrcLang = LanguageRegistryApi.Instance.GetLanguage(Connector.FileTm.LanguageDirection.SourceLanguage);
			var currentTrgLang = LanguageRegistryApi.Instance.GetLanguage(Connector.FileTm.LanguageDirection.TargetLanguage);
			lookupFrm.comboLanguagePairs.Text = currentSrcLang.DisplayName + " -> " + currentTrgLang.DisplayName;

			lookupFrm.Show();
			Close();
		}
		#endregion
	}
}
