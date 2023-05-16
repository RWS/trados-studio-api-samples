using System;
using System.Windows.Forms;
using Sdl.Desktop.IntegrationApi.Interfaces;

namespace Sdl.ViewParts.Sample
{
	public partial class MyProjectViewPartControl : UserControl, IUIControl
	{
		public MyProjectViewPartControl()
		{
			InitializeComponent();
		}

		private void MyProjectViewPartControl_Load(object sender, EventArgs e)
		{
			// add loading logic here
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
			set
			{
				_currentProject = value;
				CurrentProjectLabel.Text = string.IsNullOrEmpty(value) ? "none" : value;
			}
		}

		private int _selectedProjectsCount;
		private string _currentProject;
	}
}
