using System;
using System.Collections.Generic;
using System.ComponentModel;
using TradosStudio.API.Projects;

namespace TranslationStudioAutomationPlugin
{
	internal class ProjectViewModel : INotifyPropertyChanged
	{
		private Guid _id;
		private Uri _uri;
		private string _name;
		private string _description;
		private DateTime _createdAt;
		private DateTime? _dueDate;
		private string _sourceLanguage;
		private IEnumerable<string> _targetLanguages;
		private string _localProjectFolder;
		private string _createdBy;
		private string _projectOrigin;
		private bool _isNotCompleted;
		private bool _isActive;

		public IProject Project { get; set; }

		public Guid Id { get => _id; set { _id = value; OnPropertyChanged(nameof(Id)); } }

		public Uri Uri { get => _uri; set { _uri = value; OnPropertyChanged(nameof(Uri)); } }

		public string Name { get => _name; set { _name = value; OnPropertyChanged(nameof(Name)); } }

		public string Description { get => _description; set { _description = value; OnPropertyChanged(nameof(Description)); } }

		public DateTime CreatedAt { get => _createdAt; set { _createdAt = value; OnPropertyChanged(nameof(CreatedAt)); } }

		public DateTime? DueDate { get => _dueDate; set { _dueDate = value; OnPropertyChanged(nameof(DueDate)); } }

		public string SourceLanguage { get => _sourceLanguage; set { _sourceLanguage = value; OnPropertyChanged(nameof(SourceLanguage)); } }

		public IEnumerable<string> TargetLanguages { get => _targetLanguages; set { _targetLanguages = value; OnPropertyChanged(nameof(TargetLanguages)); } }

		public string LocalProjectFolder { get => _localProjectFolder; set { _localProjectFolder = value; OnPropertyChanged(nameof(LocalProjectFolder)); } }

		public string CreatedBy { get => _createdBy; set { _createdBy = value; OnPropertyChanged(nameof(CreatedBy)); } }

		public string ProjectOrigin { get => _projectOrigin; set { _projectOrigin = value; OnPropertyChanged(nameof(ProjectOrigin)); } }

		public bool IsNotActive { get => _isActive; set { _isActive = value; OnPropertyChanged(nameof(IsNotActive)); } }

		public bool IsNotCompleted { get => _isNotCompleted; set { _isNotCompleted = value; OnPropertyChanged(nameof(IsNotCompleted)); } }

		public event PropertyChangedEventHandler PropertyChanged;

		public void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
