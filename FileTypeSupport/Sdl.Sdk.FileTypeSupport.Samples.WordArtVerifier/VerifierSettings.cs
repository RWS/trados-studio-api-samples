using Sdl.Core.Settings;
using Sdl.FileTypeSupport.Framework.Core.Settings;

namespace Sdl.Sdk.FileTypeSupport.Samples.WordArtVerifier
{
    /// <summary>
    /// This class is used to actually store the settings to the settings bundle, which
    /// is physically saved in an *.sdlproj or in an *.sdltpl file.
    /// </summary>
    public class VerifierSettings : FileTypeSettingsBase
    {
        #region "Properties"
        bool _checkWordArt;
        int _maxWordCount;

        public bool CheckWordArt
        {
            get { return _checkWordArt; }
            set
            {
                _checkWordArt = value;
                OnPropertyChanged("CheckWordArt");
            }
        }

        public int MaxWordCount
        {
            get { return _maxWordCount; }
            set
            {
                _maxWordCount = value;
                OnPropertyChanged("MaxWordCount");
            }
        }
        #endregion


        #region "Constructor"
        public VerifierSettings()
        {
            ResetToDefaults();
        }
        #endregion

        #region "OverrideMethods"

        /// <summary>
        /// Define the default value, which is Enabled (i.e. true), as the verification function should
        /// be active by default, and 3 for the default maximum word count.
        /// </summary>
        #region "ResetToDefaults"
        public override void ResetToDefaults()
        {
            CheckWordArt = true;
            MaxWordCount = 3;
        }
        #endregion


        /// <summary>
        /// This method is used to load the setting from the settings bundle,
        /// which is physically stored in an XML-compliant *.sdlproj or *.sdltpl file.
        /// </summary>
        /// <param name="settingsBundle"></param>
        /// <param name="configurationId"></param>
        #region "PopulateFromSettingsBundle"
        public override void PopulateFromSettingsBundle(ISettingsBundle settingsBundle, string configurationId)
        {
            ISettingsGroup settingsGroup = settingsBundle.GetSettingsGroup(configurationId);
            ResetToDefaults();
            CheckWordArt = GetSettingFromSettingsGroup(settingsGroup, "CheckWordArt", CheckWordArt);
            MaxWordCount = GetSettingFromSettingsGroup(settingsGroup, "MaxWordCount", MaxWordCount);
        }
        #endregion


        /// <summary>
        /// This method is used to store the settings as configured in the plug-in UI
        /// in the settings bundle, which means that the settings are physically written
        /// into the XML-compliant *.sdlproj or *.sdltpl file.
        /// </summary>
        /// <param name="settingsBundle"></param>
        /// <param name="configurationId"></param>
        #region "SaveToSettingsBundle"
        public override void SaveToSettingsBundle(ISettingsBundle settingsBundle, string configurationId)
        {
            ISettingsGroup settingsGroup = settingsBundle.GetSettingsGroup(configurationId);
            var defaults = new VerifierSettings();
            UpdateSettingInSettingsGroup(settingsGroup, "CheckWordArt", CheckWordArt, defaults.CheckWordArt);
            UpdateSettingInSettingsGroup(settingsGroup, "MaxWordCount", MaxWordCount, defaults.MaxWordCount);
        }
        #endregion

        #endregion
    }
}
