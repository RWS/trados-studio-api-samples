using Sdl.Core.Settings;
using Sdl.FileTypeSupport.Framework.IntegrationApi;
using Sdl.FileTypeSupport.Framework.NativeApi;
using System.Diagnostics;
using System.Xml;

namespace Sdl.Sdk.FileTypeSupport.Samples.XMLChecker
{
    /// <summary>
    /// This class implements the verification logic. Depending on whether the 
    /// verification plug-in is enabled or not, a verification will be performed
    /// when the user of SDL Trados Studio presses F8 or invokes the menu command
    /// Tools -> Verify.
    /// This class is referenced in the file type definition.
    /// </summary>
    class XMLCheckerMain : INativeFileVerifier, ISettingsAware
    {
        #region "_outputFileProperties"
        private INativeOutputFileProperties _outputFileProperties;
        #endregion

        #region "UISettingsRepresentation"
        public bool Enabled
        {
            get;
            set;
        }
        #endregion

        /// <summary>
        /// Initializes the plug-in settings, so that they can be used during the actual verification.
        /// </summary>
        /// <param name="settingsBundle"></param>
        /// <param name="configurationId"></param>
        #region "InitializeSettings"
        public void InitializeSettings(ISettingsBundle settingsBundle, string configurationId)
        {
            VerifierSettings _settings = new VerifierSettings();
            _settings.PopulateFromSettingsBundle(settingsBundle, "Length Check XML v 1.0.0.0");
            Enabled = _settings.Enable;
        }
        #endregion

        #region "message reporter"
        public INativeTextLocationMessageReporter MessageReporter
        {
            get;
            set;
        }
        #endregion

        /// <summary>
        /// This method implements the main verification logic.
        /// First, the XML document is loaded into a DOM object.
        /// Then, the method loops through all the 'displaytext' elements, and
        /// checks for the presence of a 'maxlength' attribute, which indicates
        /// the maximum length in characters. If the target segment text exceeds the
        /// length limit specified by the attribute, an error message will be reported.
        /// Any length limit violations will be reported through the message reporter,
        /// which will fill the Messages window of SDL Trados Studio with the error
        /// messages that will be displayed to the end user.
        /// </summary>
        #region "verification logic"
        public void Verify()
        {
            if (!Enabled)
            {
                return;
            }
            Debugger.Launch();
            XmlDocument doc = new XmlDocument();
            doc.Load(_outputFileProperties.OutputFilePath);
            foreach (XmlNode item in doc.SelectNodes("//displaytext"))
            {
                // if has a max length attribute
                XmlAttribute maxlengthAttribute = item.Attributes["maxlength"];
                if ((maxlengthAttribute != null) && (!string.IsNullOrEmpty(maxlengthAttribute.Value)))
                {
                    // if can parse max length and display text length greater than max length
                    int lengthLimit;
                    if (int.TryParse(maxlengthAttribute.Value, out lengthLimit) && (item.InnerText.Length > lengthLimit))
                    {
                        // report problem
                        MessageReporter.ReportMessage(this, StringResources.VerifierName, ErrorLevel.Error,
                            string.Format(StringResources.ErrorText, item.InnerText.Length.ToString(), lengthLimit.ToString()),
                            string.Format(StringResources.LocationDescription, item.InnerText));
                    }
                }
            }
        }
        #endregion

        #region "INativeOutputSettingsAware Members"
        public void GetProposedOutputFileInfo(IPersistentFileConversionProperties fileProperties, IOutputFileInfo proposedFileInfo)
        {
            // Not required for this implementation
        }

        /// <summary>
        /// Provides information on output file.
        /// </summary>
        /// <param name="properties"></param>
        public void SetOutputProperties(INativeOutputFileProperties properties)
        {
            _outputFileProperties = properties;
        }
        #endregion
    }
}
