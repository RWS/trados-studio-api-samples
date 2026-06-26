using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using TradosStudio.API;
using TradosStudio.API.ProjectManagement;
using TradosStudio.API.ProjectManagement.Events;
using TradosStudio.API.Projects;
using TradosStudio.API.UI;
using TradosStudio.API.UI.View;


namespace TranslationStudioAutomationPlugin
{
	/// <summary>
	/// Meta data for the ProjectsViewPart, it is used to define the unique identifier, display name and description of the view part
	/// </summary>
	internal class ProjectsViewPartMetaData : IViewPartMetaData
	{
		/// <summary>
		/// The unique identifier for the view part, it must be unique across all view parts in Trados Studio, it is recommended to use a namespace-like format to ensure uniqueness, for example: "PluginName.ViewPartName".
		/// </summary>
		public string Id => Constants.ProjectsViewPartId;

		/// <summary>
		/// The text that is displayed on the ribbon for this view part, it can be a string or a resource reference, it is recommended to use a resource reference for localization purposes.
		/// </summary>
		public string Title => StringResources.ProjectsViewTitle;

		/// <summary>
		/// The description of the view part, it can be a string or a resource reference, it is recommended to use a resource reference for localization purposes.
		/// </summary>
		public string Description => StringResources.ProjectsViewDescription;

		/// <summary>
		/// Specifies the target view where this view part will be displayed.
		/// </summary>
		public ITargetView TargetView => DefaultTargetViews.ProjectsView;

		/// <summary>
		/// Specifies the icon for the view part, it can be a string or a resource reference, it is recommended to use a resource reference for localization purposes.
		/// </summary>
		public string Icon => $"TranslationStudioAutomationPlugin.Resources.{nameof(ImageResources.PluginActionIcon)}.ico";

		/// <summary>
		/// Specifies the actual class to use for the view part, it must implement the IViewPart interface.
		/// </summary>
		public Type ViewPartType => typeof(ProjectsViewPart);

		/// <summary>
		/// Specifies the layout of the view part, it is a collection of ViewPartLayoutInfo objects that define the layout of the view part in the target view.
		/// </summary>
		public IEnumerable<ViewPartLayoutInfo> Layouts => new List<ViewPartLayoutInfo>()
		{
			new ViewPartLayoutInfo()
			{
				Dock = DockType.Bottom,
				Width = 300,
				Height = 300,
				Visible = true,
				Pinned = true,
			}
		};
	}

	internal class ProjectsViewPart : ViewPartBase, IViewPart
	{
		private ProjectsViewPartUI _projectsViewPartUI;
		private readonly IEventAggregator _eventAggregator;
		private readonly IProjectsRegistry _projectsRegistry;
		private readonly IProjectsRepository _projectsRepository;

		public ICommand ActivateProjectCommand { get; set; }

		public ICommand OpenProjectCommand { get; set; }

		public ICommand DeleteProjectCommand { get; set; }

		public ProjectViewModel SelectedProject { get; set; }

		/// <summary>
		/// Initializes a new instance of the ProjectsViewPart class with the specified event aggregator, projects registry, and projects repository.
		/// </summary>
		/// <param name="eventAggregator">The event aggregator used for subscribing to events.</param>
		/// <param name="projectsRegistry">The projects registry used for managing projects.</param>
		/// <param name="projectsRepository">The projects repository used for persisting project data.</param>
		public ProjectsViewPart(IEventAggregator eventAggregator, IProjectsRegistry projectsRegistry, IProjectsRepository projectsRepository)
		{
			Available = true;

			ActivateProjectCommand = new RelayCommand(ActivateProjectClick);
			OpenProjectCommand = new RelayCommand(OpenProjectClick);
			DeleteProjectCommand = new RelayCommand(DeleteProjectClick);
			_eventAggregator = eventAggregator;
			_projectsRegistry = projectsRegistry;
			_projectsRepository = projectsRepository;
			SelectedProject = new ProjectViewModel();
			_ = _eventAggregator.GetEvent<SelectedProjectsChangedEvent>().Subscribe(OnSelectedProjectChanged);
		}

		private void OpenProjectClick()
		{
			_projectsRegistry.OpenProject(SelectedProject.Id);
		}

		private void ActivateProjectClick()
		{
			_projectsRegistry.SetActiveProject(SelectedProject.Id);
		}

		private void DeleteProjectClick()
		{
			_projectsRepository.DeleteProject(SelectedProject.Project);
		}

		public IUIControl GetControl()
		{
			if (_projectsViewPartUI == null)
			{
				_projectsViewPartUI = new ProjectsViewPartUI()
				{
					DataContext = this
				};
			}
			return _projectsViewPartUI;
		}

		public void OnActivate()
		{
		}

		public bool OnDeactivate()
		{
			return true;
		}

		public void OnDispose()
		{
		}

		public bool OnHide()
		{
			return true;
		}

		public bool OnRemove()
		{
			return true;
		}

		public void OnShow()
		{
		}

		public void OnInit()
		{
		}

		private void OnSelectedProjectChanged(SelectedProjectsChangedEvent e)
		{
			if (!e.Projects.Any())
			{
				return;
			}

			var project = e.Projects.FirstOrDefault();
			SelectedProject.Id = project.Id;
			SelectedProject.Name = project.Name;
			SelectedProject.Description = project.Description;
			SelectedProject.CreatedAt = project.CreatedAt;
			SelectedProject.DueDate = project.DueDate;
			SelectedProject.SourceLanguage = project.SourceLanguage;
			SelectedProject.TargetLanguages = project.TargetLanguages;
			SelectedProject.LocalProjectFolder = project.LocalProjectFolder;
			SelectedProject.CreatedBy = project.CreatedBy;
			SelectedProject.ProjectOrigin = project.ProjectOrigin;
			SelectedProject.IsNotCompleted = !project.IsCompleted;
			SelectedProject.IsNotActive = _projectsRegistry.GetActiveProject().Id != SelectedProject.Id;
			SelectedProject.Project = project;
		}
	}
}
