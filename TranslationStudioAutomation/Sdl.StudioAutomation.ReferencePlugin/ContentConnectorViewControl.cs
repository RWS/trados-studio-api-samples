using Sdl.Desktop.IntegrationApi.Interfaces;
using Sdl.ProjectAutomation.Core;
using System;
using System.IO;
using System.Windows.Forms;

namespace StudioIntegrationApiSample
{
    public partial class ContentConnectorViewControl : UserControl, IUIControl
    {
        ContentConnectorViewController _controller;

        public ContentConnectorViewControl()
        {
            InitializeComponent();

            _projectsListBox.SelectedIndexChanged += new EventHandler(_projectsListBox_SelectedIndexChanged);
        }

        internal ContentConnectorViewController Controller
        {
            get
            {
                return _controller;
            }
            set
            {
                _controller = value;

                if (_controller != null)
                {
                    _controller.ProjectRequestsChanged += new EventHandler(_controller_ProjectRequestsChanged);
                }

                _progressBar.DataBindings.Add("Value", _controller, "PercentComplete");

                LoadProjectTemplates();
                LoadProjectRequests();
            }
        }

        public void ClearMessages()
        {
            _resultsTextBox.Text = string.Empty;
        }

        public void ReportMessage(string message)
        {

            _resultsTextBox.AppendText("\r\n" + message);
        }

        private void LoadProjectTemplates()
        {
            _projectTemplatesComboBox.Items.Clear();

            if (_controller.ProjectRequests != null)
            {
                foreach (ProjectTemplateInfo projectTemplate in _controller.ProjectTemplates)
                {
                    _projectTemplatesComboBox.Items.Add(projectTemplate);
                }

                if (_projectTemplatesComboBox.Items.Count > 0)
                {
                    _projectTemplatesComboBox.SelectedIndex = 0;
                }
            }
        }

        private void LoadProjectRequests()
        {
            _projectsListBox.Items.Clear();

            if (_controller.ProjectRequests != null)
            {
                foreach (ProjectRequest projectRequest in _controller.ProjectRequests)
                {
                    _projectsListBox.Items.Add(projectRequest);
                }

                if (_projectsListBox.Items.Count > 0)
                {
                    _projectsListBox.SelectedIndex = 0;
                }
            }

            LoadFileList();
        }

        private void LoadFileList()
        {
            _filesListView.Items.Clear();

            ProjectRequest selectedProject = _projectsListBox.SelectedItem as ProjectRequest;
            if (selectedProject != null)
            {
                foreach (string file in selectedProject.Files)
                {
                    string fileName = Path.GetFileName(file);
                    _filesListView.Items.Add(fileName);
                }
            }
        }

        void _controller_ProjectRequestsChanged(object sender, EventArgs e)
        {
            LoadProjectRequests();
        }

        void _projectsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadFileList();
        }

        private void _projectTemplatesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controller.SelectedProjectTemplate = _projectTemplatesComboBox.SelectedItem as ProjectTemplateInfo;
        }
    }
}
