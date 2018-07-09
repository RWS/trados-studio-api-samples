namespace Sdl.ProjectAutomation.ProjectAutomationGUI
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Windows.Forms;
    using Sdl.ProjectAutomation.ProjectAutomationSample;

    public partial class Form1 : Form
    {
        private ProjectHelperMain _ProjectHelper;

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

            this.ProjectHelper.CreateProject(this.GetSettings());

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
    }
}
