namespace Sdl.Sdk.FileTypeSupport.Samples.SimpleTextExtension
{
    using Sdl.Core.Globalization;
    using Sdl.Core.Settings;
    using Sdl.FileTypeSupport.Framework.NativeApi;

    public class SimpleTextExtensionFileSniffer : AbstractNativeFileTypeComponent, INativeFileSniffer
    {
        #region INativeFileSniffer Members

        public SniffInfo Sniff(string nativeFilePath, Language language,
            Codepage suggestedCodepage, INativeTextLocationMessageReporter messageReporter, ISettingsGroup settingsGroup)
        {
            var sniffer = new Sdl.Sdk.FileTypeSupport.Samples.SimpleText.SimpleTextSniffer();
            return sniffer.Sniff(nativeFilePath, language, suggestedCodepage, messageReporter, settingsGroup);
        }

        #endregion
    }
}
