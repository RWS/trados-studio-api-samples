using Sdl.DesktopEditor.EditorApi;
using Sdl.FileTypeSupport.Framework.BilingualApi;
using Sdl.FileTypeSupport.Framework.IntegrationApi;
using Sdl.Verification.Api;
using System;
using System.Windows.Forms;

namespace Sdl.Verification.Sdk.EditAndApplyChanges.MessageUI
{
    /// <summary>
    /// QACheckerMessageControlPlugIn class represents a QA checker message control plug-in
    /// responsible for creating QA checker message controls
    /// </summary>
    [MessageControlPlugIn]
    public class CustomMessageControlPlugIn : IMessageControlPlugIn
    {
        /// <summary>
        /// Determines whether the message control plug-in supports the given message.
        /// </summary>
        /// <param name="messageEventArgs">message</param>
        /// <returns>whether supports message</returns>
        public bool SupportsMessage(MessageEventArgs messageEventArgs)
        {
            return messageEventArgs.ExtendedData != null &&
                   messageEventArgs.ExtendedData.GetType().Equals(typeof(CustomMessageData));
        }

        /// <summary>
        /// Creates the message control for the given message.
        /// </summary>
        /// <param name="messageControlContainer">message control container</param>
        /// <param name="messageEventArgs">message</param>
        /// <param name="bilingualDocument">bilingual document</param>
        /// <param name="sourceSegment">source segment</param>
        /// <param name="targetSegment">target segment</param>
        /// <returns>message control</returns>
        public UserControl CreateMessageControl(IMessageControlContainer messageControlContainer, MessageEventArgs messageEventArgs, IBilingualDocument bilingualDocument, ISegment sourceSegment, ISegment targetSegment)
        {
            if (!SupportsMessage(messageEventArgs))
            {
                throw new ArgumentException("messageEventArgs is not supported by this message control plug-in", nameof(messageEventArgs));
            }

            return new CustomMessageControl(messageEventArgs, bilingualDocument, sourceSegment, targetSegment);
        }
    }
}