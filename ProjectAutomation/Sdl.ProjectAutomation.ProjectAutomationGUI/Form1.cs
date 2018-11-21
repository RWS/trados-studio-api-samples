namespace Sdl.ProjectAutomation.ProjectAutomationGUI
{
    using Sdl.ProjectAutomation.ProjectAutomationSample;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;

    public partial class Form1 : Form
    {
        private ProjectHelperMain _ProjectHelper;

        private Dictionary<string, List<string>> _projectFiles;

        public ProjectHelperMain ProjectHelper
        {
            get
            {
                if (this._ProjectHelper == null)
                {
                    this._ProjectHelper = new ProjectHelperMain();
                }

                return this._ProjectHelper;
            }

            set
            {
                this._ProjectHelper = value;
            }
        }

        public Form1()
        {
            _projectFiles = new Dictionary<string, List<string>>();
            this.InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.tb_ProjectName.Text))
            {
                MessageBox.Show("Set the project name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (String.IsNullOrEmpty(this.tb_InputFolder.Text) ||
                !Directory.Exists(this.tb_InputFolder.Text))
            {
                MessageBox.Show("Set correct the input folder path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (String.IsNullOrEmpty(this.tb_MasterTMPath.Text))
            {
                MessageBox.Show("Set the Master TM path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (String.IsNullOrEmpty(this.tb_Termbase.Text))
            {
                MessageBox.Show("Set the termbase path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (String.IsNullOrEmpty(this.tb_PackagePath.Text))
            {
                MessageBox.Show("Set the package output path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this.tb_InputFolder.Text.EndsWith(Path.DirectorySeparatorChar.ToString()))
            {
                this.tb_InputFolder.Text += Path.DirectorySeparatorChar.ToString();
                this.Refresh();
            }

            var newProject = this.ProjectHelper.CreateProject(this.GetSettings());
            if (newProject != null)
            {
                var address = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).ToString() +
                              Path.DirectorySeparatorChar + @"Studio 2011\Projects\" + this.tb_ProjectName.Text + @"\" + this.tb_ProjectName.Text + ".sdlproj";
                cb_ExistingProjects.Items.Add(new ComboboxItem
                {
                    Text = this.tb_ProjectName.Text,
                    Value = address
                });

                var files = newProject.GetSourceLanguageFiles().ToList();
                var fileNames = new List<string>();
                foreach (var file in files)
                {
                    fileNames.Add(file.Name);
                }

                fileNames = fileNames.Where(f => f.EndsWith(".sdlxliff")).Distinct().ToList();
                if (!_projectFiles.ContainsKey(this.tb_ProjectName.Text))
                {
                    _projectFiles.Add(this.tb_ProjectName.Text, fileNames);
                }
            }

            MessageBox.Show("Finished");
        }

        private LocalProjectSettings GetSettings()
        {
            LocalProjectSettings settings = new LocalProjectSettings();
            settings.ProjectName = this.tb_ProjectName.Text;
            settings.InputFolder = this.tb_InputFolder.Text;
            settings.SourceLanguage = ((SelectedLanguage)this.cb_SourceLangs.SelectedItem).Name;
            settings.TargetLanguage = ((SelectedLanguage)this.cb_TargetLang.SelectedItem).Name;
            settings.PathToMasterTM = tb_MasterTMPath.Text;
            settings.TermbasePath = tb_Termbase.Text;
            settings.PackageOutputPath = tb_PackagePath.Text;
            settings.PreviousVersionPath = tb_PreviousPath.Text;

            return settings;
        }

        private void b_Browse_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.tb_InputFolder.Text = this.folderBrowserDialog1.SelectedPath;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (var lang in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            {
                this.cb_SourceLangs.Items.Add(new SelectedLanguage(lang.EnglishName, lang.Name));
                this.cb_TargetLang.Items.Add(new SelectedLanguage(lang.EnglishName, lang.Name));
            }

            this.cb_SourceLangs.SelectedIndex = 0;
            this.cb_TargetLang.SelectedIndex = 0;
        }

        private void b_BrowseTM_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.Title = "Select Master TM";
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                tb_MasterTMPath.Text = this.openFileDialog1.FileName;
            }
        }

        private void b_BrowseTermbase_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.Title = "Select Termbase";
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.tb_Termbase.Text = this.openFileDialog1.FileName;
            }
        }

        private void b_BrowsePackage_Click(object sender, EventArgs e)
        {
            this.saveFileDialog1.Title = "Select Package output path";
            this.saveFileDialog1.Filter = "Project Package *.sdlppx|*.sdlppx";
            if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.tb_PackagePath.Text = this.saveFileDialog1.FileName;
            }
        }


        private void b_BrowsePreviousPath_Click(object sender, EventArgs e)
        {
            this.saveFileDialog1.Title = "Select Directory Containing Previous Translated Documents";
            this.saveFileDialog1.Filter = "Project Package *.sdlppx|*.sdlppx";
            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.tb_PreviousPath.Text = this.folderBrowserDialog1.SelectedPath;
            }
        }

        private void b_Delete_Click(object sender, EventArgs e)
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

            this.ProjectHelper.DeleteProject(projectPath);

            cb_ExistingProjects.Items.RemoveAt(cb_ExistingProjects.SelectedIndex);
            cb_ExistingProjectFiles.Items.Clear();
            b_DeleteFiles.Enabled = false;

            MessageBox.Show("Successfully deleted project.");
        }

        private void b_DeleteFiles_Click(object sender, EventArgs e)
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

            this.ProjectHelper.DeleteFilesAndDependencies(projectPath, fileName);
            cb_ExistingProjectFiles.Items.Clear();

            if (_projectFiles.ContainsKey(projectName))
            {
                var tempList = _projectFiles[projectName];
                tempList.Remove(fileName);
                _projectFiles[projectName] = tempList;
            }

            MessageBox.Show("Successfully deleted project.");
        }

        private void cb_ExistingProjects_SelectedIndexChanged(object sender, EventArgs e)
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
