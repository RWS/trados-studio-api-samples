using Sdl.FileTypeSupport.Framework.BilingualApi;
using Sdl.Verification.Api;
using Sdl.FileTypeSupport.Framework.IntegrationApi;

namespace Sdl.Verification.Sdk.IdenticalCheck.Extended.MessageUI
{
    public class IdenticalVerifierMessageData : ExtendedMessageEventData, IVerificationCustomMessageData
    {
        public IdenticalVerifierMessageData(string errorDetails, ISegment replacementSuggestion, string sourceSegment, string targetSegment)
        {
            MessageType = "Sdl.Verification.Sdk.IdenticalCheck.MessageUI, Error_NotIdentical";
            ErrorDetails = errorDetails;
            ReplacementSuggestion = replacementSuggestion;
            TargetSegmentPlainText = targetSegment;
            SourceSegmentPlainText = sourceSegment;
        }

        /// <summary>
        /// Information which will be displayed in our custom UI.
        /// </summary>
        public string ErrorDetails { get; private set; }

        /// <summary>
        /// Suggestion which will be used in the custom UI for target segment replacement.
        /// </summary>
        public ISegment ReplacementSuggestion { get; private set; }

        /// <summary>
        /// Information which will be displayed in our custom UI.
        /// </summary>
        public string DetailedDescription { get; private set; }

        /// <summary>
        /// Information which will be displayed in our custom UI.
        /// </summary>
        public string SourceSegmentPlainText { get; set; }

        /// <summary>
        /// Information which will be displayed in our custom UI.
        /// </summary>
        public string TargetSegmentPlainText { get; set; }
    }
}