namespace Sdl.ProjectAutomation.ProjectOperations.GUI
{
	using System;
	using System.Collections.Generic;
	using System.Globalization;
	using System.IO;
	using System.Linq;
	using System.Windows.Forms;
	using Sdl.ProjectAutomation.ProjectOperations.Logic;

	public partial class Form1 : Form
	{
		private ProjectHelperMain _ProjectHelper;

		private readonly Dictionary<string, List<string>> _projectFiles;

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
			_projectFiles = new Dictionary<string, List<string>>();
			InitializeComponent();
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(tb_ProjectName.Text))
			{
				MessageBox.Show("Set the project name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (string.IsNullOrEmpty(tb_InputFolder.Text) ||
				!Directory.Exists(tb_InputFolder.Text))
			{
				MessageBox.Show("Set correct the input folder path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (string.IsNullOrEmpty(tb_MasterTMPath.Text))
			{
				MessageBox.Show("Set the Master TM path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (string.IsNullOrEmpty(tb_Termbase.Text))
			{
				MessageBox.Show("Set the termbase path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (string.IsNullOrEmpty(tb_PackagePath.Text))
			{
				MessageBox.Show("Set the package output path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (tb_InputFolder.Text.EndsWith(Path.DirectorySeparatorChar.ToString()))
			{
				tb_InputFolder.Text += Path.DirectorySeparatorChar.ToString();
				Refresh();
			}

			var newProject = ProjectHelper.CreateProject(GetSettings());
			if (newProject != null)
			{
				var address = ProjectHelper.ProjectsPath + tb_ProjectName.Text + @"\" + tb_ProjectName.Text + ".sdlproj";
				cb_ExistingProjects.Items.Add(new ComboboxItem
				{
					Text = tb_ProjectName.Text,
					Value = address
				});

				var files = newProject.GetSourceLanguageFiles().ToList();
				var fileNames = new List<string>();
				foreach (var file in files)
				{
					fileNames.Add(file.Name);
				}

				fileNames = fileNames.Where(f => f.EndsWith(".sdlxliff")).Distinct().ToList();
				if (!_projectFiles.ContainsKey(tb_ProjectName.Text))
				{
					_projectFiles.Add(tb_ProjectName.Text, fileNames);
				}
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
				PathToMasterTM = tb_MasterTMPath.Text,
				TermbasePath = tb_Termbase.Text,
				PackageOutputPath = tb_PackagePath.Text,
				PreviousVersionPath = tb_PreviousPath.Text
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

		private void B_BrowseTM_Click(object sender, EventArgs e)
		{
			openFileDialog1.Title = "Select Master TM";
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				tb_MasterTMPath.Text = openFileDialog1.FileName;
			}
		}

		private void B_BrowseTermbase_Click(object sender, EventArgs e)
		{
			openFileDialog1.Title = "Select Termbase";
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				tb_Termbase.Text = openFileDialog1.FileName;
			}
		}

		private void B_BrowsePackage_Click(object sender, EventArgs e)
		{
			saveFileDialog1.Title = "Select Package output path";
			saveFileDialog1.Filter = "Project Package *.sdlppx|*.sdlppx";
			if (saveFileDialog1.ShowDialog() == DialogResult.OK)
			{
				tb_PackagePath.Text = saveFileDialog1.FileName;
			}
		}


		private void B_BrowsePreviousPath_Click(object sender, EventArgs e)
		{
			saveFileDialog1.Title = "Select Directory Containing Previous Translated Documents";
			saveFileDialog1.Filter = "Project Package *.sdlppx|*.sdlppx";
			if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
			{
				tb_PreviousPath.Text = folderBrowserDialog1.SelectedPath;
			}
		}

		private void B_Delete_Click(object sender, EventArgs e)
		{
			string projectPath = null;
			if (cb_ExistingProjects.SelectedItem is ComboboxItem)
			{
				projectPath = ((ComboboxItem)cb_ExistingProjects.SelectedItem).Value;
			}

			if (string.IsNullOrEmpty(projectPath))
			{
				MessageBox.Show("Please select a project to delete.", "Error", MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				return;
			}

			ProjectHelper.DeleteProject(projectPath);

			cb_ExistingProjects.Items.RemoveAt(cb_ExistingProjects.SelectedIndex);
			cb_ExistingProjectFiles.Items.Clear();
			b_DeleteFiles.Enabled = false;

			MessageBox.Show("Successfully deleted project.");
		}

		private void B_DeleteFiles_Click(object sender, EventArgs e)
		{
			// get project name
			string projectPath = null;
			string projectName = null;
			if (cb_ExistingProjects.SelectedItem is ComboboxItem)
			{
				projectPath = ((ComboboxItem)cb_ExistingProjects.SelectedItem).Value;
				projectName = ((ComboboxItem)cb_ExistingProjects.SelectedItem).Text;
			}

			if (string.IsNullOrEmpty(projectPath))
			{
				return;
			}

			// get file name
			string fileName = null;
			if (cb_ExistingProjectFiles.SelectedItem is ComboboxItem)
			{
				fileName = ((ComboboxItem)cb_ExistingProjectFiles.SelectedItem).Value;
			}

			if (string.IsNullOrEmpty(fileName))
			{
				MessageBox.Show("Please select a file to delete.", "Error", MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				return;
			}

			ProjectHelper.DeleteFilesAndDependencies(projectPath, fileName);
			cb_ExistingProjectFiles.Items.Clear();

			if (_projectFiles.ContainsKey(projectName))
			{
				var tempList = _projectFiles[projectName];
				tempList.Remove(fileName);
				_projectFiles[projectName] = tempList;
			}

			MessageBox.Show("Successfully deleted project.");
		}

		private void Cb_ExistingProjects_SelectedIndexChanged(object sender, EventArgs e)
		{
			string projectPath = null;
			string projectName = null;
			if (cb_ExistingProjects.SelectedItem is ComboboxItem)
			{
				projectPath = ((ComboboxItem)cb_ExistingProjects.SelectedItem).Value;
				projectName = ((ComboboxItem)cb_ExistingProjects.SelectedItem).Text;
			}

			if (string.IsNullOrEmpty(projectPath))
			{
				return;
			}

			cb_ExistingProjectFiles.Items.Clear();
			var files = (_projectFiles.ContainsKey(projectName)) ? _projectFiles[projectName] : new List<string>();
			foreach (var file in files)
			{
				cb_ExistingProjectFiles.Items.Add(
					(new ComboboxItem
					{
						Text = file,
						Value = file
					}));
			}

			if (cb_ExistingProjectFiles.Items.Count > 0)
			{
				b_DeleteFiles.Enabled = true;
			}
		}
	}
}
