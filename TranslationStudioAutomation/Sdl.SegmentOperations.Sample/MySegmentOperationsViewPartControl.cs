using Sdl.Desktop.IntegrationApi.Interfaces;
using Sdl.FileTypeSupport.Framework.BilingualApi;
using Sdl.LanguagePlatform.Core.EditDistance;
using Sdl.TranslationStudioAutomation.IntegrationApi;
using System.Linq;
using System.Windows.Forms;

namespace Sdl.SegmentOperations.Sample
{
    public partial class MySegmentOperationsViewPartControl : UserControl, IUIControl
    {
        private readonly EditorController _editorController;
        private IStudioDocument _activeDocument;
        private ISegment _previousSegment;
        private ISegment _currentSegment;

        public MySegmentOperationsViewPartControl()
        {
            _editorController = SdlTradosStudio.Application.GetController<EditorController>();
            _activeDocument = _editorController.ActiveDocument;
            InitializeComponent();

            if (_activeDocument != null)
            {

            }
            _editorController.ActiveDocumentChanged += _editorController_ActiveDocumentChanged;
        }

        private void _editorController_ActiveDocumentChanged(object sender, DocumentEventArgs e)
        {
            if (_activeDocument != null)
            {
                _activeDocument.ActiveSegmentChanged -= _activeDocument_ActiveSegmentChanged;
            }
            _activeDocument = _editorController.ActiveDocument;

            if (_activeDocument != null)
            {
                _activeDocument.ActiveSegmentChanged += _activeDocument_ActiveSegmentChanged;
            }
        }

        private void _activeDocument_ActiveSegmentChanged(object sender, System.EventArgs e)
        {
            _previousSegment = _currentSegment;
            _currentSegment = _activeDocument.ActiveSegmentPair?.Target;

            if (_currentSegment != null)
            {
                _currentSegmentIdLabel.Text = $"Current segment: {_currentSegment.Properties.Id.Id}";
            }
            else
            {
                _currentSegmentIdLabel.Text = "null";
            }

            if (_previousSegment != null)
            {
                _previousSegmentIdLabel.Text = $"Previous segment: {_previousSegment.Properties.Id.Id}";
            }
            else
            {
                _previousSegmentIdLabel.Text = "null";
            }
            if (_currentSegment != null && _previousSegment != null)
            {
                var cultureInfo = _editorController.ActiveDocument.ActiveFile.Language;
                // use default config
                var computeParams = new EditDistanceComputeParams();
                var distanceTask = TranslationStudioAutomation.IntegrationApi.SegmentOperations.GetEditDistanceAsync(_currentSegment, _previousSegment, cultureInfo, computeParams);
                distanceTask.Wait();
                var editDistance = distanceTask.Result;

                _distanceLabel.Text = $"Distance: {editDistance.Distance}";
                _scoreLabel.Text = $"Score: {editDistance.Score}";

                var wordCountTask = TranslationStudioAutomation.IntegrationApi.SegmentOperations.GetWordCountAsync(_currentSegment, cultureInfo);
                wordCountTask.Wait();
                var wordCount = wordCountTask.Result;

                _wordsCountLabel.Text = $"Word Count: {wordCount.Words}";
            }
            else
            {
                _distanceLabel.Text = "Distance: 0";
                _scoreLabel.Text = "Score: 0";
                _wordsCountLabel.Text = "Words: 0";
            }
        }
    }
}
