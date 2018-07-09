using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Sdl.FileTypeSupport.Framework.NativeApi;
using Sdl.FileTypeSupport.Framework.BilingualApi;

namespace Sdl.Sdk.FilterFramework.Samples.SimpleText
{
    class InternalPreviewWriter : AbstractNativeFileWriter, INativeContentCycleAware
    {
        StreamWriter _preview = null;

        public void SetFileProperties(IFileProperties properties)
        {
            // not used in this implementation
        }

        #region "start output"
        // start the preview output
        public void StartOfInput()
        {
            _preview = new StreamWriter(OutputProperties.OutputFilePath);
            _preview.WriteLine("<html><body>");
        }
        #endregion

        #region "text"
        // output the translatable strings
        public override void Text(ITextProperties textInfo)
        {
            _preview.Write(textInfo.Text);
        }
        #endregion

        #region "para"
        // each paragraph unit should appear in a new line
        // therefore use a DIV element
        public override void ParagraphUnitStart(IParagraphUnitProperties properties)
        {
            _preview.WriteLine("<div>");
        }
        

        public override void ParagraphUnitEnd()
        {
            _preview.Write("</div>");
        }
        #endregion


        #region "segment"
        // enclose each segment in a SPAN tag pair
        public override void SegmentStart(ISegmentPairProperties properties)
        {
            _preview.Write("<span>");
        }

        public override void SegmentEnd()
        {
            _preview.Write("</span>");
        }
        #endregion

        #region "inline tags"
        // output any inline tags,
        // which will also apply the corresponding character formatting
        public override void InlineStartTag(IStartTagProperties tagInfo)
        {
            _preview.Write(tagInfo.TagContent);
        }

        public override void InlineEndTag(IEndTagProperties tagInfo)
        {
            _preview.Write(tagInfo.TagContent);
        }
        #endregion



        #region "end output"
        // end the preview output
        public void EndOfInput()
        {
            _preview.WriteLine("</body></html>");
            _preview.Close();
        }
        #endregion
    }
}