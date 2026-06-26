using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Microsoft.Win32;
using TradosStudio.API;
using TradosStudio.API.Editor;
using TradosStudio.API.Editor.Events;
using TradosStudio.API.UI;
using TradosStudio.API.UI.View;

namespace TranslationStudioAutomationPlugin
{
	/// <summary>
	/// Meta data for the DocumentsViewPart, it is used to define the unique identifier, display name and description of the view part
	/// </summary>
	internal class DocumentsViewPartMetaData : IViewPartMetaData
	{
		/// <summary>
		/// The unique identifier for the view part, it must be unique across all view parts in Trados Studio, it is recommended to use a namespace-like format to ensure uniqueness, for example: "PluginName.ViewPartName".
		/// </summary>
		public string Id => Constants.DocumentsViewPartId;

		/// <summary>
		/// The text that is displayed on the ribbon for this view part, it can be a string or a resource reference, it is recommended to use a resource reference for localization purposes.
		/// </summary>
		public string Title => StringResources.DocumentsViewPartTitle;

		/// <summary>
		/// The description of the view part, it can be a string or a resource reference, it is recommended to use a resource reference for localization purposes.
		/// </summary>
		public string Description => StringResources.DocumentsViewPartDescription;

		/// <summary>
		/// Specifies the icon for the view part, it can be a string or a resource reference, it is recommended to use a resource reference for localization purposes.
		/// </summary>
		public string Icon => $"TranslationStudioAutomationPlugin.Resources.{nameof(ImageResources.PluginActionIcon)}.ico";

		/// <summary>
		/// Specifies the target view where this view part will be displayed.
		/// </summary>
		public ITargetView TargetView => DefaultTargetViews.EditorView;

		/// <summary>
		/// Specifies the actual class to use for the view part, it must implement the IViewPart interface.
		/// </summary>
		public Type ViewPartType => typeof(DocumentsViewPart);

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

	internal class DocumentsViewPart : ViewPartBase, IViewPart
	{
		private readonly IDocumentsRegistry _documentsRegistry;
		private readonly IEventAggregator _eventAggregator;
		private IUIControl _control;

		/// <summary>
		/// Initializes a new instance of the DocumentsViewPart class with the specified documents registry and event aggregator.
		/// </summary>
		/// <param name="documentsRegistry">The documents registry to use for managing documents.</param>
		/// <param name="eventAggregator">The event aggregator to use for publishing and subscribing to events.</param>
		public DocumentsViewPart(
			IDocumentsRegistry documentsRegistry,
			IEventAggregator eventAggregator)
		{
			_documentsRegistry = documentsRegistry;
			_eventAggregator = eventAggregator;
			OpenCommand = new RelayCommand(OnOpenClick);
			SaveCommand = new RelayCommand(OnSaveClick);
			CloseCommand = new RelayCommand(OnCloseClick);
			ActivateCommand = new RelayCommand(OnActivateClick);
			SaveAsCommand = new RelayCommand(OnSaveAsClick);
			SaveTargetAsCommand = new RelayCommand(OnSaveTargetAsClick);
			SaveSourceAsCommand = new RelayCommand(OnSaveSourceAsClick);
			Documents = new ObservableCollection<string>();
		}

		private ObservableCollection<string> _documents;
		private string _selectedDocument;

		private void OnOpenClick()
		{
			var openFileDialog = new OpenFileDialog
			{
				Filter = "All files (*.*)|*.*",
				Multiselect = false
			};
			if (openFileDialog.ShowDialog() == true)
			{
				_ = _documentsRegistry.Open(openFileDialog.FileName);
			}
		}

		private void OnSaveClick()
		{
			_documentsRegistry.Save(SelectedDocument);
		}

		private void OnCloseClick()
		{
			_documentsRegistry.Close(SelectedDocument);
		}

		private void OnActivateClick()
		{
			_ = _documentsRegistry.ActivateDocument(SelectedDocument);
		}

		private void OnSaveAsClick()
		{
			_documentsRegistry.SaveAs(SelectedDocument);
		}

		private void OnSaveTargetAsClick()
		{
			_documentsRegistry.SaveTargetAs(SelectedDocument);
		}

		private void OnSaveSourceAsClick()
		{
			_documentsRegistry.SaveSourceAs(SelectedDocument);
		}

		public ObservableCollection<string> Documents
		{
			get => _documents;
			set
			{
				_documents = value;
				OnPropertyChanged(nameof(Documents));
			}
		}

		public string SelectedDocument
		{
			get => _selectedDocument;
			set
			{
				_selectedDocument = value;
				OnPropertyChanged(nameof(SelectedDocument));
				OnPropertyChanged(nameof(SelectedDocumentNotAlreadyActive));
				OnPropertyChanged(nameof(HasSelectedDocument));
			}
		}

		public bool SelectedDocumentNotAlreadyActive => SelectedDocument != _documentsRegistry.GetActiveDocument();
		public bool HasSelectedDocument => SelectedDocument != null;
		public ICommand OpenCommand { get; set; }
		public ICommand SaveCommand { get; set; }
		public ICommand CloseCommand { get; set; }
		public ICommand ActivateCommand { get; set; }
		public ICommand SaveAsCommand { get; set; }
		public ICommand SaveTargetAsCommand { get; set; }
		public ICommand SaveSourceAsCommand { get; set; }

		public IUIControl GetControl()
		{
			if (_control == null)
			{
				_control = new DocumentsViewPartUI()
				{
					DataContext = this
				};
			}
			return _control;
		}

		public void OnActivate()
		{
			Documents = new ObservableCollection<string>(_documentsRegistry.GetDocuments());
			if (SelectedDocument == null && Documents.Any())
			{
				SelectedDocument = Documents.FirstOrDefault();
			}
		}

		public bool OnDeactivate()
		{
			return true;
		}

		public void OnDispose()
		{
			_control?.Dispose();
		}

		public bool OnHide()
		{
			return true;
		}

		public void OnInit()
		{
			_ = _eventAggregator.GetEvent<DocumentOpenedEvent>().Subscribe(OnDocumentOpened);
			_ = _eventAggregator.GetEvent<DocumentClosedEvent>().Subscribe(OnDocumentClosed);
			_ = _eventAggregator.GetEvent<DocumentActiveChangedEvent>().Subscribe(OnActiveDocumentChanged);
		}

		private void OnActiveDocumentChanged(DocumentActiveChangedEvent e)
		{
			if (string.IsNullOrEmpty(e.CurrentActiveDocumentId))
			{
				SelectedDocument = null;

				return;
			}
			SelectedDocument = e.CurrentActiveDocumentId;
		}

		private void OnDocumentClosed(DocumentClosedEvent e)
		{
			if (Documents.Contains(e.DocumentId))
			{
				_ = Documents.Remove(e.DocumentId);
			}

			if (SelectedDocument == e.DocumentId)
			{
				SelectedDocument = Documents.FirstOrDefault();
			}
		}

		private void OnDocumentOpened(DocumentOpenedEvent e)
		{
			Documents.Add(e.DocumentId);
		}

		public bool OnRemove()
		{
			return true;
		}

		public void OnShow()
		{
		}
	}
}
