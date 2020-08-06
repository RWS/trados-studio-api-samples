using Sdl.FileTypeSupport.Framework.BilingualApi;
using Sdl.FileTypeSupport.Framework.NativeApi;
using System.IO;

namespace Sdl.Sdk.FileTypeSupport.Samples.SimpleText.Preview
{
    class InternalPreviewWriter : AbstractNativeFileWriter, INativeContentCycleAware
    {
        StreamWriter _preview = null;
        string _paragraphUnitId = string.Empty;

        public void SetFileProperties(IFileProperties properties)
        {
            // not used in this implementation
        }

        #region "start output"
        // start the preview output
        public void StartOfInput()
        {
            _preview = new StreamWriter(OutputProperties.OutputFilePath);
            _preview.WriteLine(GetHTMLStart());
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
        #region "para start"
        // each paragraph unit should appear in a new line
        // therefore use a DIV element
        public override void ParagraphUnitStart(IParagraphUnitProperties properties)
        {
            _preview.WriteLine("<div>");
            _paragraphUnitId = properties.ParagraphUnitId.Id;
        }
        #endregion


        public override void ParagraphUnitEnd()
        {
            _preview.Write("</div>");
        }
        #endregion

        #region "segment"
        // enclose each segment in a SPAN tag pair
        public override void SegmentStart(ISegmentPairProperties properties)
        {
            _preview.Write("<span id=\"" + properties.Id.Id + "\" onClick=\"window.external.SelectSegment('" + _paragraphUnitId + "','" + properties.Id.Id + "')\" >");
        }
        #endregion

        public override void SegmentEnd()
        {
            _preview.Write("</span>");
        }

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

        #region "html start"
        // write the HTML header, which contains CSS styles
        // and JavaScript functions, which can be called from the
        // preview viewer control
        private string GetHTMLStart()
        {
            string header = "<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.01 Transitional//EN\">\n";
            header += "<html>\n";
            header += "<head>\n";
            header += "<meta http-equiv=\"content-type\" content=\"text/html; charset=utf-8\">\n";
            header += "<title>" + "Preview" + "</title>\n";

            header += "<style type=\"text/css\">\n";
            header += "<!--\n";
            header += "body{color:grey; font-size:10pt;font-family: @Arial Unicode MS;}\n";
            header += "span{color:black;cursor: hand;}\n";

            //real-time preview related styles
            header += ".activesegment{color:red;background-color: silver;cursor: hand;}\n";
            header += ".normal{color:black;background-color: white;cursor: hand;}\n";
            header += "//-->\n";
            header += "</style>\n";

            //real-time preview related JavaScript functions
            header += "<script type=\"text/javascript\">\n";
            header += "<!--\n";
            header += "function setActiveStyle(objDivID)\n";
            header += "{\n";
            header += "document.getElementById(objDivID).className = 'activesegment';\n";
            header += "}\n";
            header += "function setNormalStyle(objDivID)\n";
            header += "{\n";
            header += "document.getElementById(objDivID).className = 'normal';\n";
            header += "}\n";
            header += "//-->\n";
            header += "</script>\n";

            header += "</head>\n";
            header += "<body>\n";
            return header;
        }
        #endregion
    }
}
