using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Sdl.FileTypeSupport.Framework.BilingualApi;
using Sdl.ProjectAutomation.Core;
using Sdl.ProjectAutomation.FileBased;
using Sdl.TranslationStudioAutomation.IntegrationApi;
using Sdl.TranslationStudioAutomation.IntegrationApi.Actions;
using Sdl.Desktop.IntegrationApi;

namespace Sdl.ProjectsOperations.Sample
{
    public partial class MyProjectsViewPartControl : UserControl
    {
        public MyProjectsViewPartControl()
        {
            InitializeComponent();
            ProjectsController projectsController = GetProjectsController();
            projectsController.ProjectsChanged += (sender, args) => RepopulateProjectsList();
            projectsController.SelectedProjectsChanged += OnSelectedProjectsChanged;
            projectsController.CurrentProjectChanging2 += OnCurrentProjectChanging2;
        }

        private ProjectsController GetProjectsController()
        {
            return SdlTradosStudio.Application.GetController<ProjectsController>();
        }

        private bool preventSelectionChanged;
        private FileBasedProject currentProject;

        private void RepopulateProjectsList()
        {
            preventSelectionChanged = true;
            ProjectsController projectsController = GetProjectsController();            
            ProjectsListView.Items.Clear();            
            foreach (var project in projectsController.GetProjects())
            {
                var item = new ListViewItem(project.GetProjectInfo().Name)
                               {
                                   Tag = project,
                                   Selected = projectsController.SelectedProjects.Contains(project),                                   
                                   Font = (project == currentProject ? new System.Drawing.Font(Font.FontFamily, Font.Size, System.Drawing.FontStyle.Bold): new System.Drawing.Font(Font.FontFamily, Font.Size))
                               };

                item.SubItems.Add(project.GetTargetLanguageFiles().Count().ToString());
                ProjectsListView.Items.Add(item);
            }
            preventSelectionChanged = false;
        }       

        private void ProjectsListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (preventSelectionChanged)
                return;

            var selectedProjects = new List<FileBasedProject>();
            for (int i=0; i < ProjectsListView.SelectedItems.Count; i++)
            {
                selectedProjects.Add(ProjectsListView.SelectedItems[i].Tag as FileBasedProject);
            }

            GetProjectsController().SelectedProjects = selectedProjects;
        }

        private void OnSelectedProjectsChanged(object sender, EventArgs eventArgs)
        {
            preventSelectionChanged = true;
            ProjectsListView.SelectedItems.Clear();

            foreach (var project in GetProjectsController().SelectedProjects)
            {
                ListViewItem projectItem = FindItem(project);
                if (projectItem != null)
                {
                    projectItem.Selected = true;
                }
            }

            preventSelectionChanged = false;
        }

        private void OnCurrentProjectChanging2(object sender, CurrentProjectCancelEventArgs eventArgs)
        {
            preventSelectionChanged = true;

            ListViewItem projectItem = FindItem(eventArgs.NewCurrentProject);
            if (projectItem != null)
            {                
                currentProject = eventArgs.NewCurrentProject;
            }

            preventSelectionChanged = false;
        }

        private void ProjectsListView_ItemActivate(object sender, EventArgs e)
        {
            var selectedItem = ProjectsListView.SelectedItems[0];
            GetProjectsController().Open(selectedItem.Tag as FileBasedProject);
        }     

        private void AddProjectButton_Click(object sender, EventArgs e)
        {
            SdlTradosStudio.Application.ExecuteAction<AddProjectAction>();
        }

        private void SetDueDateButton_Click(object sender, EventArgs e)
        {
            SetDueDateForSelectedProjects(dueDateCalendar.SelectionRange.Start);            
        }

        private void ClearDueDateButton_Click(object sender, EventArgs e)
        {
            SetDueDateForSelectedProjects(null);
        }
        
        private void SetDueDateForSelectedProjects(DateTime? dueDate)
        {
            bool hasChangedProjects = false;
            for (int i = 0; i < ProjectsListView.SelectedItems.Count; i++)
            {
                var project = (FileBasedProject)ProjectsListView.SelectedItems[i].Tag;
                ProjectInfo projectInfo = project.GetProjectInfo();
                projectInfo.DueDate = dueDate;
                project.UpdateProject(projectInfo);
                project.Save();                
                hasChangedProjects = true;
            }

            if (hasChangedProjects)
            {
                GetProjectsController().RefreshProjects();
            }                        
        }

        private ListViewItem FindItem(FileBasedProject project)
        {
            for (var i = 0; i < ProjectsListView.Items.Count; i++)
            {
                if (ProjectsListView.Items[i].Tag == project)
                {
                    return ProjectsListView.Items[i];
                }
            }

            return null;
        }

        private void MarkAsCompleted_Click(object sender, EventArgs e)
        {
            bool hasChangedProjects = false;
            for (int i = 0; i < ProjectsListView.SelectedItems.Count; i++)
            {
                var project = (FileBasedProject)ProjectsListView.SelectedItems[i].Tag;
                project.Complete();
                project.Save();
                hasChangedProjects = true;
            }

            if (hasChangedProjects)
            {
                GetProjectsController().RefreshProjects();
            }
        }
    }
}
