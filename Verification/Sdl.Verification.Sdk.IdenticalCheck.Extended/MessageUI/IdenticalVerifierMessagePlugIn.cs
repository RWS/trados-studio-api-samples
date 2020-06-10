using System;
using System.Windows.Forms;
using Sdl.DesktopEditor.EditorApi;
using Sdl.FileTypeSupport.Framework.BilingualApi;
using Sdl.FileTypeSupport.Framework.IntegrationApi;
using Sdl.Verification.Api;

namespace Sdl.Verification.Sdk.IdenticalCheck.Extended.MessageUI
{
    [MessageControlPlugIn]
    public class IdenticalVerifierMessagePlugIn : IMessageControlPlugIn
    {
        #region SupportsMessage
        public bool SupportsMessage(MessageEventArgs messageEventArgs)
        {
            return messageEventArgs.ExtendedData != null &&
                   messageEventArgs.ExtendedData.GetType().Equals(typeof(IdenticalVerifierMessageData));
        }
        #endregion

        #region CreateMessageControl
        public UserControl CreateMessageControl(IMessageControlContainer messageControlContainer, MessageEventArgs messageEventArgs, 
            IBilingualDocument bilingualDocument, ISegment sourceSegment, ISegment targetSegment)
        {
            if (!SupportsMessage(messageEventArgs))
            {
                throw new ArgumentException("messageEventArgs is not supported by this message control plug-in", nameof(messageEventArgs));
            }

            return new IdenticalVerifierMessageUI(messageEventArgs, targetSegment);
        }
        #endregion
    }
}