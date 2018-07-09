using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sdl.ViewParts.Sample
{
    public partial class MyProjectViewPartControl : UserControl
    {
        public MyProjectViewPartControl()
        {
            InitializeComponent();
        }

        private void MyProjectViewPartControl_Load(object sender, EventArgs e)
        {            
        }

        public int SelectedProjectsCount
        {
            get { return _selectedProjectsCount; }
            set
            {
                _selectedProjectsCount = value;
                SelectedProjectsCountLabel.Text = value.ToString();
            }
        }

        public string CurrentProject
        {
            get { return _currentProject; }
            set { 
                _currentProject = value;
                CurrentProjectLabel.Text = string.IsNullOrEmpty(value) ? "none" : value;
            }
        }

        private int _projectCount;
        private int _selectedProjectsCount;
        private string _currentProject;
    }
}
