using Sdl.ProjectAutomation.Core;
using Sdl.ProjectAutomation.FileBased;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace StudioIntegrationApiSample
{
    class ProjectCreator
    {
        public event ProgressChangedEventHandler ProgressChanged;
        public event EventHandler<ProjectMessageEventArgs> MessageReported;
        private double _currentProgress;

        public ProjectCreator(List<ProjectRequest> requests, ProjectTemplateInfo projectTemplate)
        {
            Requests = requests;
            ProjectTemplate = projectTemplate;
            SuccessfulRequests = new List<Tuple<ProjectRequest, FileBasedProject>>();
        }

        List<ProjectRequest> Requests
        {
            get; set;
        }

        public List<Tuple<ProjectRequest, FileBasedProject>> SuccessfulRequests
        {
            get;
            private set;
        }

        ProjectTemplateInfo ProjectTemplate
        {
            get;
            set;
        }

        public void Execute()
        {
            _currentProgress = 0;
            foreach (ProjectRequest request in Requests)
            {
                CreateProject(request);
                _currentProgress += 100.0 / Requests.Count;
                OnProgressChanged(_currentProgress);
            }

            OnProgressChanged(100);
        }

        private void CreateProject(ProjectRequest request)
        {
            ProjectInfo projectInfo = new ProjectInfo
            {
                Name = request.Name,
                LocalProjectFolder = GetProjectFolderPath(request.Name)
            };
            FileBasedProject project = new FileBasedProject(projectInfo, new ProjectTemplateReference(ProjectTemplate.Uri));

            OnMessageReported(project, string.Format("Creating project {0}", request.Name));

            ProjectFile[] projectFiles = project.AddFiles(request.Files.ToArray());
            project.RunAutomaticTask(projectFiles.GetIds(), AutomaticTaskTemplateIds.Scan);
            TaskSequence taskSequence = project.RunDefaultTaskSequence(projectFiles.GetIds(),
                (sender, e)
                    =>
                {
                    OnProgressChanged(_currentProgress + (double)e.PercentComplete / Requests.Count);
                }
                , (sender, e)
                =>
                {
                    OnMessageReported(project, e.Message);
                });

            project.Save();

            if (taskSequence.Status == TaskStatus.Completed)
            {
                SuccessfulRequests.Add(Tuple.Create(request, project));
                OnMessageReported(project, string.Format("Project {0} created successfully.", request.Name));                
            }
            else
            {
                OnMessageReported(project, string.Format("Project {0} creation failed.", request.Name));                
            }
        }

        private string GetProjectFolderPath(string name)
        {
            string rootFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Studio 2022\\Projects");
            string folder;
            int num = 1;
            do
            {
                num++;
            }
            while (Directory.Exists(folder = Path.Combine(rootFolder, name + "-" + num)));
            return folder;
        }

        private void OnProgressChanged(double progress)
        {
            ProgressChanged?.Invoke(this, new ProgressChangedEventArgs((int)progress, null));
        }

        private void OnMessageReported(FileBasedProject project, string message)
        {
            MessageReported?.Invoke(this, new ProjectMessageEventArgs { Project = project, Message = message });
        }

        private void OnMessageReported(FileBasedProject project, ExecutionMessage executionMessage)
        {
            MessageReported?.Invoke(this, new ProjectMessageEventArgs { Project = project, Message = executionMessage.Level + ": " + executionMessage.Message });
        }
    }

    class ProjectMessageEventArgs : EventArgs
    {
        public FileBasedProject Project { get; set; }

        public string Message { get; set; }
    }

}
