using Sdl.FileTypeSupport.Framework.BilingualApi;

namespace Sdl.Sdk.FileTypeSupport.Samples.SimpleTextExtension
{
    using Sdl.FileTypeSupport.Framework.NativeApi;

    public class NativeContentProcessorStub : AbstractNativeExtractionGenerationContentProcessor,
        INativeContentCycleAware, ISharedObjectsAware, INativeOutputSettingsAware
    {
        #region AbstractNativeExtractionGenerationContentProcessor Members

        public override IAbstractNativeContentHandler Output
        {
            get
            {
                return base.Output;
            }
            set
            {
                base.Output = value;
            }
        }


        public override void CustomInfo(ICustomInfoProperties info)
        {
            base.CustomInfo(info);
        }


        public override void InlineStartTag(IStartTagProperties tag)
        {
            base.InlineStartTag(tag);
        }


        public override void InlineEndTag(IEndTagProperties tag)
        {
            base.InlineEndTag(tag);
        }


        public override void InlinePlaceholderTag(IPlaceholderTagProperties tag)
        {
            base.InlinePlaceholderTag(tag);
        }

        #endregion

        #region INativeContentCycleAware Members


        public void SetFileProperties(IFileProperties properties)
        {
        }


        public void StartOfInput()
        {
        }


        public void EndOfInput()
        {
        }

        #endregion

        #region INativeOutputSettingsAware Members

        public void SetOutputProperties(INativeOutputFileProperties properties)
        {
        }


        public void GetProposedOutputFileInfo(IPersistentFileConversionProperties fileProperties,
            IOutputFileInfo proposedFileInfo)
        {
        }

        #endregion

        #region ISharedObjectsAware Members

        public void SetSharedObjects(ISharedObjects sharedObjects)
        {
        }

        #endregion
    }
}
