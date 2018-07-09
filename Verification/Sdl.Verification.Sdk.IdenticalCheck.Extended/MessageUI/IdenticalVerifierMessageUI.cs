using System;
using System.Windows.Forms;

using Sdl.DesktopEditor.BasicControls;
using Sdl.FileTypeSupport.Framework.BilingualApi;
using Sdl.FileTypeSupport.Framework.IntegrationApi;
using Sdl.Verification.Api;

namespace Sdl.Verification.Sdk.IdenticalCheck.Extended.MessageUI
{
    public partial class IdenticalVerifierMessageUI : UserControl, ISuggestionProvider
    {
        #region Create Edit Controls
        /// <summary>
        /// Source segment edit control
        /// </summary>
        private readonly BasicSegmentEditControl _originalSegment = new BasicSegmentEditControl();

        /// <summary>
        /// Target segment edit control
        /// </summary>
        private readonly BasicSegmentEditControl _suggestedSegment = new BasicSegmentEditControl();
        #endregion

        private Suggestion _suggestion;

        #region Constructor
        public IdenticalVerifierMessageUI(MessageEventArgs messageEventArgs, ISegment originalSegment)
        {
            InitializeComponent();

            #region Get ExtendedMessage Data
            IdenticalVerifierMessageData messageData = (IdenticalVerifierMessageData)messageEventArgs.ExtendedData;
            this.tb_ErrorDetails.Text = messageData.ErrorDetails;
            _suggestion = new Suggestion(messageEventArgs.FromLocation, messageEventArgs.UptoLocation, 
                messageData.ReplacementSuggestion.Clone() as IAbstractMarkupData);
            #endregion

            _originalSegment.Dock = DockStyle.Fill;
            _originalSegment.IsReadOnly = true;
            _originalSegment.ReplaceDocumentSegment(originalSegment.Clone() as ISegment);
            panel_Original.Controls.Add(_originalSegment);
        }
        #endregion

        #region ISuggestionProvider
        public Suggestion GetSuggestion()
        {
            return _suggestion;
        }

        public bool HasSuggestion()
        {
            return true;
        }

        public event EventHandler SuggestionChanged;
        #endregion
    }
}
