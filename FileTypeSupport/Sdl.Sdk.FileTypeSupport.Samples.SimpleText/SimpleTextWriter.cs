using System.IO;
using Sdl.FileTypeSupport.Framework.BilingualApi;
using Sdl.FileTypeSupport.Framework.NativeApi;

namespace Sdl.Sdk.FileTypeSupport.Samples.SimpleText
{
    class SimpleTextWriter : AbstractNativeFileWriter, INativeContentCycleAware
    {
        private IPersistentFileConversionProperties _conversionProperties;
        StreamWriter _targetFile = null;

        #region "members of INativecontentCycleAware member"
        public void SetFileProperties(IFileProperties properties)
        {
            _conversionProperties = properties.FileConversionProperties;
        }

        #region "output file"
        // create the output text file
        public void StartOfInput()
        {
            _targetFile = new StreamWriter(OutputProperties.OutputFilePath);
        }
        #endregion

        #region "close"
        public void EndOfInput()
        {
            _targetFile.Close();
            _targetFile.Dispose();
            _targetFile = null;
        }
        #endregion
        #endregion

        #region "text and tags"
        // iterate through the bilingual file
        // and add translatable text content and the content of
        // any structure and inline tags to the target output file
        public override void StructureTag(IStructureTagProperties tagInfo)
        {
            _targetFile.WriteLine(tagInfo.TagContent);
        }

        public override void Text(ITextProperties textInfo)
        {
            _targetFile.Write(textInfo.Text);
        }


        public override void InlineStartTag(IStartTagProperties tagInfo)
        {
            _targetFile.Write(tagInfo.TagContent);
        }

        public override void InlineEndTag(IEndTagProperties tagInfo)
        {
            _targetFile.Write(tagInfo.TagContent);
        }

        // make sure a line break is inserted after each end of a segment
        public override void SegmentEnd()
        {
            _targetFile.WriteLine();
        }
        #endregion
    }
}
