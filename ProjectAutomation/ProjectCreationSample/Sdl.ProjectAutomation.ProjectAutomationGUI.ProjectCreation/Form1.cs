namespace Sdl.ProjectAutomation.ProjectAutomationGUI
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Windows.Forms;
    using Sdl.ProjectAutomation.ProjectAutomationSample.ProjectCreation;

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

            if (String.IsNullOrEmpty(this.tb_InputFolder.Text) || !Directory.Exists(this.tb_InputFolder.Text))
            {
                MessageBox.Show("Set correct Input Folder path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (String.IsNullOrEmpty(this.tb_OutputPath.Text))
            {
                MessageBox.Show("Set the project output path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this.tb_InputFolder.Text.EndsWith(Path.DirectorySeparatorChar.ToString()))
            {
                this.tb_InputFolder.Text += Path.DirectorySeparatorChar.ToString();
                this.Refresh();
            }

            try
            {
                this.ProjectHelper.CreateProject(this.GetSettings());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex?.InnerException.Message);
                return;
            }

            MessageBox.Show("Finished");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.tb_PackagePath.Text))
            {
                MessageBox.Show("Set correct Project Package path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (String.IsNullOrEmpty(this.tb_OutputPath.Text))
            {
                MessageBox.Show("Set the project output path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                this.ProjectHelper.CreateProjectFromPackage(this.GetSettings());
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
            LocalProjectSettings settings = new LocalProjectSettings();
            settings.ProjectName = this.tb_ProjectName.Text;
            settings.InputFolder = this.tb_InputFolder.Text;
            settings.SourceLanguage = ((SelectedLanguage)this.cb_SourceLangs.SelectedItem).Name;
            settings.TargetLanguage = ((SelectedLanguage)this.cb_TargetLang.SelectedItem).Name;
            settings.PackagePath = tb_PackagePath.Text;
            settings.OutputPath = tb_OutputPath.Text;
       
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

        private void b_BrowsePackage_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.Title = "Select Package output path";
            this.openFileDialog1.Filter = "Project Package *.sdlppx|*.sdlppx";

            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.tb_PackagePath.Text = this.openFileDialog1.FileName;// .SelectedPath;
            }
        }

       
        private void b_BrowseOutputPath_Click(object sender, EventArgs e)
        {            
            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.tb_OutputPath.Text = this.folderBrowserDialog1.SelectedPath;
            }
        }
    }
}
