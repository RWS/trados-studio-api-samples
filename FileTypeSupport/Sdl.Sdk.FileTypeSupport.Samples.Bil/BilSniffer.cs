using Sdl.Core.Globalization;
using Sdl.Core.Settings;
using Sdl.FileTypeSupport.Framework.NativeApi;
using System.Xml;

namespace Sdl.Sdk.FileTypeSupport.Samples.Bil
{
    class BilSniffer : INativeFileSniffer
    {
        #region "constants"
        static string _BilingualDocument = "bilingualdocument";
        static string _SourceLanguage = "source-language";
        static string _TargetLanguage = "target-language";
        #endregion

        #region "sniff"
        public SniffInfo Sniff(string nativeFilePath, Language suggestedSourceLanguage,
            Codepage suggestedCodepage, INativeTextLocationMessageReporter messageReporter,
            ISettingsGroup settingsGroup)
        {
            SniffInfo info = new SniffInfo();

            if (System.IO.File.Exists(nativeFilePath))
            {
                // call method to check if file is supported
                info.IsSupported = IsFileSupported(nativeFilePath);
                // call method to determine the file language pair
                GetFileLanguages(ref info, nativeFilePath);
            }
            else
            {
                info.IsSupported = false;
            }

            return info;
        }
        #endregion

        #region "issupported"
        // determine whether a given file is supported based on the
        // root element
        private bool IsFileSupported(string nativeFilePath)
        {
            bool result = false;
            XmlDocument doc = new XmlDocument();
            doc.Load(nativeFilePath);
            if (doc.DocumentElement.Name == _BilingualDocument)
            {
                result = true;
            }

            return result;
        }
        #endregion

        #region "get languages"
        // retrieve the source and target language
        // from the file header
        private void GetFileLanguages(ref SniffInfo info, string nativeFilePath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(nativeFilePath);
            if (doc.DocumentElement.HasAttributes)
            {
                XmlAttribute source = doc.DocumentElement.Attributes[_SourceLanguage];
                if (source != null)
                {
                    info.DetectedSourceLanguage =
                        new Sdl.FileTypeSupport.Framework.Pair<Language, DetectionLevel>(new Language(source.Value),
                            DetectionLevel.Certain);
                }

                XmlAttribute target = doc.DocumentElement.Attributes[_TargetLanguage];
                if (target != null)
                {
                    info.DetectedTargetLanguage =
                        new Sdl.FileTypeSupport.Framework.Pair<Language, DetectionLevel>(new Language(target.Value),
                            DetectionLevel.Certain);
                }
            }
        }
        #endregion
    }
}
