using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Sdl.Core.Globalization;
using Sdl.Desktop.IntegrationApi.Interfaces;
using Sdl.FileTypeSupport.Framework.BilingualApi;
using Sdl.FileTypeSupport.Framework.NativeApi;
using Sdl.TranslationStudioAutomation.IntegrationApi;
using Sdl.TranslationStudioAutomation.IntegrationApi.Actions;

namespace Sdl.EditorOperations.Sample
{
	public partial class MyEditorViewPartControl : UserControl, IUIControl
	{
		public MyEditorViewPartControl()
		{
			_editorController = GetEditorController();
			InitializeComponent();
			InitializeDocumentListTab();
			InitializeTrackingEventsTab();
			InitializeSelectionsTab();
			InitializeIntegrationTestsTab();
		}

		#region GetEditorController

		private EditorController GetEditorController()
		{
			return SdlTradosStudio.Application.GetController<EditorController>();
		}

		#endregion

		#region DocumentsListView

		private void InitializeDocumentListTab()
		{
			_editorController.Opened += (s, e) => RepopulateDocumentList();
			_editorController.Closed += (s, e) => RepopulateDocumentList();
			_editorController.ActiveDocumentChanged += (s, e) => ActiveDocument = e.Document;
		}

		private void RepopulateDocumentList()
		{
			DocumentsList.Items.Clear();
			foreach (var document in _editorController.GetDocuments())
			{
				string documentName = document.Files.Count() > 1 ? "Multiple merged files" : document.Files.First().Name;
				ListViewItem item = DocumentsList.Items.Add(documentName);
				item.SubItems.Add(document.SegmentPairs.Count().ToString());
				item.Tag = document;
				item.SubItems.Add(document.Project.GetProjectInfo().SourceLanguage.DisplayName);
				item.SubItems.Add(document.Project.GetProjectInfo().TargetLanguages[0].DisplayName);
			}

			ActiveDocument = _editorController.ActiveDocument;
		}

		private void OpenUsingStudioActionButton_Click(object sender, EventArgs e)
		{
			SdlTradosStudio.Application.ExecuteAction<OpenDocumentAction>();
		}

		private void DocumentsList_ItemActivate(object sender, EventArgs e)
		{
			_editorController.Activate(DocumentsList.SelectedItems[0].Tag as IStudioDocument);

			//keep the focus on the list items.
			_editorController.Activate();
			DocumentsList.Focus();
		}

		private IStudioDocument ActiveDocument
		{
			set
			{
				for (var i = 0; i < DocumentsList.Items.Count; i++)
				{
					var item = DocumentsList.Items[i];
					item.Selected = item.Tag as IStudioDocument == value;
				}
			}
		}


		#endregion

		#region SaveCloseReplaceAll

		private void SaveAllButton_Click(object sender, EventArgs e)
		{
			SdlTradosStudio.Application.ExecuteAction<SaveAllDocumentsAction>();
		}

		private void CloseAllDocumentsButton_Click(object sender, EventArgs e)
		{
			_editorController.GetDocuments()
							.ToList()
							.ForEach(_editorController.Close);
		}

		private void ReplaceAllButton_Click(object sender, EventArgs e)
		{
			_editorController.Activate();

			if (_editorController.ActiveDocument == null)
			{
				MessageBox.Show("There is no document loaded in the editor");
				return;
			}

			IEnumerable<IStudioDocument> searchDocumentList =
				FindReplaceAllButton.Checked
					? _editorController.GetDocuments()
					: new List<IStudioDocument> { _editorController.ActiveDocument };

			string findText = FindText.Text;
			string replaceWith = ReplaceText.Text;
			if (string.IsNullOrEmpty(findText))
			{
				MessageBox.Show("Please provide a text to search.");
				return;
			}

			foreach (var doc in searchDocumentList)
			{
				//traverse in an updatable mode the segment pairs and perform replace
				doc.ProcessSegmentPairs("Find and replace",
					(segPair, eventArg) =>
					{
						foreach (IAbstractMarkupData markupData in segPair.Target)
						{
							var text = markupData as IText;
							if (text != null)
							{
								text.Properties.Text =
									text.Properties.Text.Replace(findText,
																	replaceWith);
							}
						}
					});
			}
		}

		#endregion

		#region TrackingDocumentsEvents

		private void InitializeTrackingEventsTab()
		{
			_editorController.ActiveDocumentChanged +=
				(sender, args) =>
				AddListViewEvent("Active document changed", args.Document != null ? args.Document.Files.First().Name : string.Empty);

			_editorController.Saving += (sender, args) => AddListViewEvent("Document saving", args.Document.Files.First().Name);
			_editorController.Saved += (sender, args) => AddListViewEvent("Document saved", args.Document.Files.First().Name);
			_editorController.SaveFailed += (sender, args) => AddListViewEvent("Document save failed", args.Document.Files.First().Name);

			_editorController.Closing += (sender, args) =>
				AddListViewEvent("Document closing", args.Document != null ? args.Document.Files.First().Name : string.Empty);
			_editorController.Closed += (sender, args) =>
				AddListViewEvent("Document closed", args.Document != null ? args.Document.Files.First().Name : string.Empty);
			_editorController.Opening += (sender, args) =>
				AddListViewEvent("Document opening", args.Document != null ? args.Document.Files.First().Name : string.Empty);
			_editorController.Opened += (sender, args) =>
			{
				//bind document events.
				InitializeDocumentTrackingEvents(args.Document);

				AddListViewEvent("Document opened",
								 args.Document != null
									 ? args.Document.Files.First().Name
									 : string.Empty);
			};
		}

		private void InitializeDocumentTrackingEvents(IStudioDocument doc)
		{
			doc.ActiveSegmentChanged += (o, eventArgs) => AddListViewEvent("ActiveSegmentChanged");
			doc.ContentChanged +=
				(sender, args) => AddListViewEvent("Document changed", args.Segments.First().ToString());

			doc.ActiveFileChanged += (o, eventArgs) => AddListViewEvent("Active file changed");
			doc.ActiveFilePropertiesChanged += (o, eventArgs) => AddListViewEvent("Active file properties changed");


			doc.Selection.Changed +=
				(o, eventArgs) => AddListViewEvent("Document selection changed", doc.Selection.Current.ToString());
			doc.Selection.Source.Changed +=
				(o, eventArgs) =>
				AddListViewEvent("Source selection changed.", doc.Selection.Source.ToString());
			doc.Selection.Target.Changed +=
				(o, eventArgs) =>
				AddListViewEvent("Target selection changed.", doc.Selection.Target.ToString());
		}

		private void AddListViewEvent(string eventName, string eventMetadata = "")
		{
			var item = new ListViewItem(EventsListView.Items.Count.ToString());
			item.SubItems.Add(eventName);
			item.SubItems.Add(eventMetadata);
			EventsListView.Items.Insert(0, item);
		}

		#endregion

		#region HandlingSelections

		private void InitializeSelectionsTab()
		{
			_editorController.Opened += (sender, args) =>
			{
				args.Document.Selection.Changed +=
					(o, eventArgs) =>
					CurrentSelectionTextBox.Text = args.Document.Selection.Current.ToString();
			};
		}

		private void ReplaceSelectionButton_Click(object sender, EventArgs e)
		{
			var doc = _editorController.ActiveDocument;
			if (doc.Selection.Current is SourceSelection)
			{
				MessageBox.Show("The replace of a source selection is not available.");
				return;
			}

			doc.Selection.Target.Replace(ReplaceSelectionTextBox.Text, "Manual selection replacement");
			doc.Selection.Target.Collapse();
		}

		#endregion

		#region IntegrationTests

		private void InitializeIntegrationTestsTab()
		{
			_editorController.ActiveDocumentChanged += (sender, args) =>
			{
				if (_editorController.ActiveDocument == null)
				{
					return;
				}

				availableValueLabel.Text = _editorController.ActiveDocument.IsTranslationProviderAvailable.ToString();
				_editorController.ActiveDocument.ActiveSegmentChanged -= ActiveDocument_ActiveSegmentChanged;
				_editorController.ActiveDocument.ActiveSegmentChanged += ActiveDocument_ActiveSegmentChanged;
				_editorController.ActiveDocument.ActiveSegmentContentIsReady -= ActiveDocument_ActiveSegmentContentIsReady;
				_editorController.ActiveDocument.ActiveSegmentContentIsReady += ActiveDocument_ActiveSegmentContentIsReady;
			};
		}

		private void ReverseLockedButton_Click(object sender, EventArgs e)
		{
			_editorController.ActiveDocument.ProcessSegmentPairs("Reverse Locked",
				(segPair, eventArg) =>
				{
					foreach (var it in segPair.Source)
					{
						segPair.Target.Add(it.Clone() as IAbstractMarkupData);
					}

					segPair.Target.Properties.IsLocked = !segPair.Target.Properties.IsLocked;
				});
		}

		private void TranslateActiveSegmentButton_Click(object sender, EventArgs e)
		{
			_editorController.ActiveDocument.TryTranslateActiveSegment();
		}

		private void ActiveDocument_ActiveSegmentContentIsReady(object sender, EventArgs e)
		{
			activeSegmentValueLabel.Text = bool.TrueString;
		}

		private void ActiveDocument_ActiveSegmentChanged(object sender, EventArgs e)
		{
			activeSegmentValueLabel.Text = bool.FalseString;
		}

		private int _commentsCount;
		private readonly EditorController _editorController;

		private void AddCommentToSegmentButton_Click(object sender, EventArgs e)
		{
			_editorController.ActiveDocument.AddCommentOnSegment(_editorController.ActiveDocument.ActiveSegmentPair,
				string.Format("Comment {0}", ++_commentsCount), Severity.Low);
		}

		private void UpdateCommentOnSegmentButton_Click(object sender, EventArgs e)
		{
			var c = _editorController.ActiveDocument.GetCommentsFromSegment(_editorController.ActiveDocument.ActiveSegmentPair);

			_editorController.ActiveDocument.UpdateCommentOnSegment(_editorController.ActiveDocument.ActiveSegmentPair,
				c.ElementAt(0), string.Format("U Comment {0}", ++_commentsCount), Severity.Medium);
		}

		private void DeleteCommentOnSegmentButton_Click(object sender, EventArgs e)
		{
			var c = _editorController.ActiveDocument.GetCommentsFromSegment(_editorController.ActiveDocument.ActiveSegmentPair);
			_editorController.ActiveDocument.DeleteCommentOnSegment(_editorController.ActiveDocument.ActiveSegmentPair, c.ElementAt(0));
		}

		private void DeleteAllCommentsOnSegmentButton_Click(object sender, EventArgs e)
		{
			_editorController.ActiveDocument.DeleteAllCommentsOnSegment(_editorController.ActiveDocument.ActiveSegmentPair);
		}

		private void SetTranslatedConfirmationLevelOnSegmentButton_Click(object sender, EventArgs e)
		{
			_editorController.ActiveDocument.SegmentsConfirmationLevelChanged += ActiveDocument_SegmentsConfirmationLevelChanged;
			_editorController.ActiveDocument.ChangeConfirmationLevelOnSegment(_editorController.ActiveDocument.ActiveSegmentPair, ConfirmationLevel.Translated);
		}

		private void ActiveDocument_SegmentsConfirmationLevelChanged(object sender, EventArgs e)
		{
			_editorController.ActiveDocument.SegmentsConfirmationLevelChanged -= ActiveDocument_SegmentsConfirmationLevelChanged;
		}

		private void SetTranslationOriginOnSegmentButton_Click(object sender, EventArgs e)
		{
			_editorController.ActiveDocument.SegmentsTranslationOriginChanged += ActiveDocument_SegmentsTranslationOriginChanged;
			_editorController.ActiveDocument.ChangeTranslationOriginOnSegment(_editorController.ActiveDocument.ActiveSegmentPair, "test");
		}

		private void ActiveDocument_SegmentsTranslationOriginChanged(object sender, EventArgs e)
		{
			_editorController.ActiveDocument.SegmentsTranslationOriginChanged += ActiveDocument_SegmentsTranslationOriginChanged;
		}

		private void GetSegmentPairsButton_Click(object sender, EventArgs e)
		{
			GetSegmentPairsValueLabel.ResetText();

			var activeParagraphProperties =
				_editorController.ActiveDocument.ActiveSegmentPair.GetParagraphUnitProperties();

			var segmentPairs = _editorController.ActiveDocument.GetSegmentPairsFromParagraph(activeParagraphProperties.ParagraphUnitId).ToList();

			foreach (var segmentPair in segmentPairs)
			{
				GetSegmentPairsValueLabel.Text += segmentPair.Properties.Id;

				if (segmentPairs.Last() != segmentPair)
				{
					GetSegmentPairsValueLabel.Text += ", ";
				}
			}
		}

		private void ProcessSegmentPairButton_Click(object sender, EventArgs e)
		{
			var segmentPair = _editorController.ActiveDocument.ActiveSegmentPair;

			_editorController.ActiveDocument.ProcessSegmentPair(segmentPair, "Update segment content",
				(segPair, eventArg) =>
				{
					foreach (var markupData in segPair.Target)
					{
						var text = markupData as IText;
						if (text != null)
						{
							text.Properties.Text = "Segment processed";
							UpdateStatusTextBox.Text = "Segment content updated successfully through single segment processing.";
						}
					}
				});
		}

		private void UpdateSegmentPairButton_Click(object sender, EventArgs e)
		{
			var segmentPair = _editorController.ActiveDocument.ActiveSegmentPair;

			foreach (var markupData in segmentPair.Target)
			{
				var text = markupData as IText;
				if (text != null)
				{
					text.Properties.Text = "Segment directly updated";
					UpdateStatusTextBox.Text = "Segment content updated successfully through direct update.";
				}
			}
			_editorController.ActiveDocument.UpdateSegmentPair(segmentPair);
		}

		private void ProcessSegmentPropertiesButton_Click(object sender, EventArgs e)
		{
			_editorController.ActiveDocument.ProcessSegmentPair(_editorController.ActiveDocument.ActiveSegmentPair, "Update segment properties",
				(segPair, eventArg) =>
				{
					segPair.Properties.IsLocked = !segPair.Properties.IsLocked;
					UpdateStatusTextBox.Text = "Segment properties updated successfully through single segment processing.";
				});
		}

		private void UpdateSegmentPropertiesButton_Click(object sender, EventArgs e)
		{
			var segmentPair = _editorController.ActiveDocument.ActiveSegmentPair;

			segmentPair.Properties.IsLocked = !segmentPair.Properties.IsLocked;

			_editorController.ActiveDocument.UpdateSegmentPairProperties(_editorController.ActiveDocument.ActiveSegmentPair, segmentPair.Properties);
			UpdateStatusTextBox.Text = "Segment properties updated successfully through direct properties update.";
		}

		private void UpdateParagraphPropertiesButton_Click(object sender, EventArgs e)
		{
			var segmentPair = _editorController.ActiveDocument.ActiveSegmentPair;
			var paragraphProperties = segmentPair.GetParagraphUnitProperties();

			var newComment = _editorController.ActiveDocument.PropertiesFactory.CreateComment("Test Comment", "Test author",
				Severity.High);

			if (paragraphProperties.Comments == null)
			{
				paragraphProperties.Comments = _editorController.ActiveDocument.PropertiesFactory.CreateCommentProperties();
			}

			if (paragraphProperties.Comments.Comments.All(x => x.Text != newComment.Text))
			{
				paragraphProperties.Comments.Add(newComment);
			}

			_editorController.ActiveDocument.UpdateParagraphUnitProperties(paragraphProperties);
			UpdateStatusTextBox.Text =
				"Paragraph properties updated successfully through direct properties update. Comment added.";
		}

		#endregion
	}
}
