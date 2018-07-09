namespace Sdl.Sdk.FileTypeSupport.Samples.SimpleTextExtension
{
    using Sdl.FileTypeSupport.Framework.Core.Utilities.NativeApi;
    using Sdl.FileTypeSupport.Framework.NativeApi;

    public class SimpleTextExtensionPostTweaker : AbstractFilePostTweaker
    {
        public int PostTweakerCallsCount { get; private set; }

        protected override void Tweak(INativeOutputFileProperties properties)
        {
            PostTweakerCallsCount += 1;
            //File.Copy(properties..OriginalFilePath, properties.InputFilePath);
        }
    }
}
