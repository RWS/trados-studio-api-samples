using Sdl.Core.Globalization;
using Sdl.Core.Settings;
using Sdl.FileTypeSupport.Framework.NativeApi;
using System.IO;

namespace Sdl.Sdk.FileTypeSupport.Samples.SimpleText
{
    // the file sniffer component determines whether a given file
    // can be processed by the filter or not
    public class SimpleTextSniffer : INativeFileSniffer
    {
        public SniffInfo Sniff(string nativeFilePath, Language suggestedSourceLanguage, Codepage suggestedCodepage,
            INativeTextLocationMessageReporter messageReporter, ISettingsGroup settingsGroup)
        {
            SniffInfo fileInfo = new SniffInfo();

            using (StreamReader _reader = new StreamReader(nativeFilePath))
            {
                if (_reader.ReadLine().StartsWith("[Version="))
                {
                    fileInfo.IsSupported = true;
                }
                else
                {
                    fileInfo.IsSupported = false;
                    messageReporter.ReportMessage(this, nativeFilePath,
                                                  ErrorLevel.Error, StringResources.Sniffer_Message,
                                                  StringResources.Sniffer_Location);
                }
            }

            return fileInfo;
        }
    }
}
