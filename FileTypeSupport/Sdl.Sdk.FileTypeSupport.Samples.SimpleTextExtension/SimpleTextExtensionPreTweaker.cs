namespace Sdl.Sdk.FileTypeSupport.Samples.SimpleTextExtension
{
    using System.IO;
    using Sdl.FileTypeSupport.Framework.Core.Utilities.NativeApi;
    using Sdl.FileTypeSupport.Framework.NativeApi;

    public class SimpleTextExtensionPreTweaker : AbstractFilePreTweaker
    {
        public int PreTweakerCallsCount { get; private set; }

        protected override void Tweak(IPersistentFileConversionProperties properties)
        {
            PreTweakerCallsCount += 1;
            File.Copy(properties.OriginalFilePath, properties.InputFilePath);
        }


    }
}
