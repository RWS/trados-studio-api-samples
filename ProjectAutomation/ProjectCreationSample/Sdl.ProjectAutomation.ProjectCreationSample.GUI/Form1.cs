namespace Sdl.ProjectAutomation.ProjectCreationSample.GUI
{
	using System;
	using System.Globalization;
	using System.IO;
	using System.Windows.Forms;
	using Sdl.ProjectAutomation.ProjectCreationSample.Logic;

	public partial class Form1 : Form
	{
		private ProjectHelperMain _ProjectHelper;

		public ProjectHelperMain ProjectHelper
		{
			get
			{
				if (_ProjectHelper == null)
				{
					_ProjectHelper = new ProjectHelperMain();
				}

				return _ProjectHelper;
			}

			set
			{
				_ProjectHelper = value;
			}
		}

		public Form1()
		{
			InitializeComponent();
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(tb_ProjectName.Text))
			{
				MessageBox.Show("Set the project name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (string.IsNullOrEmpty(tb_InputFolder.Text) || !Directory.Exists(tb_InputFolder.Text))
			{
				MessageBox.Show("Set correct Input Folder path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (string.IsNullOrEmpty(tb_OutputPath.Text))
			{
				MessageBox.Show("Set the project output path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (tb_InputFolder.Text.EndsWith(Path.DirectorySeparatorChar.ToString()))
			{
				tb_InputFolder.Text += Path.DirectorySeparatorChar.ToString();
				Refresh();
			}

			try
			{
				ProjectHelper.CreateProject(GetSettings());
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex?.InnerException.Message);
				return;
			}

			MessageBox.Show("Finished");
		}

		private void Button2_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(tb_PackagePath.Text))
			{
				MessageBox.Show("Set correct Project Package path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (string.IsNullOrEmpty(tb_OutputPath.Text))
			{
				MessageBox.Show("Set the project output path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			try
			{
				ProjectHelper.CreateProjectFromPackage(GetSettings());
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex?.InnerException.Message);
				return;
			}

			MessageBox.Show("Finished");
		}

		private LocalProjectSettings GetSettings()
		{
			LocalProjectSettings settings = new LocalProjectSettings
			{
				ProjectName = tb_ProjectName.Text,
				InputFolder = tb_InputFolder.Text,
				SourceLanguage = ((SelectedLanguage)cb_SourceLangs.SelectedItem).Name,
				TargetLanguage = ((SelectedLanguage)cb_TargetLang.SelectedItem).Name,
				PackagePath = tb_PackagePath.Text,
				OutputPath = tb_OutputPath.Text
			};

			return settings;
		}

		private void B_Browse_Click(object sender, EventArgs e)
		{
			if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
			{
				tb_InputFolder.Text = folderBrowserDialog1.SelectedPath;
			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			foreach (var lang in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
			{
				cb_SourceLangs.Items.Add(new SelectedLanguage(lang.EnglishName, lang.Name));
				cb_TargetLang.Items.Add(new SelectedLanguage(lang.EnglishName, lang.Name));
			}

			cb_SourceLangs.SelectedIndex = 0;
			cb_TargetLang.SelectedIndex = 0;
		}

		private void B_BrowsePackage_Click(object sender, EventArgs e)
		{
			openFileDialog1.Title = "Select Package output path";
			openFileDialog1.Filter = "Project Package *.sdlppx|*.sdlppx";

			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				tb_PackagePath.Text = openFileDialog1.FileName;
			}
		}

		private void B_BrowseOutputPath_Click(object sender, EventArgs e)
		{
			if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
			{
				tb_OutputPath.Text = folderBrowserDialog1.SelectedPath;
			}
		}
	}
}
