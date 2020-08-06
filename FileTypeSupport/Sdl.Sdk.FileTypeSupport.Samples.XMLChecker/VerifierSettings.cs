using Sdl.Core.Settings;
using Sdl.FileTypeSupport.Framework.Core.Settings;

namespace Sdl.Sdk.FileTypeSupport.Samples.XMLChecker
{
    /// <summary>
    /// This class is used to actually store the settings to the settings bundle, which
    /// is physically saved in an *.sdlproj or in an *.sdltpl file.
    /// </summary>
    public class VerifierSettings : FileTypeSettingsBase
    {
        #region "Properties"
        bool _enable;

        public bool Enable
        {
            get { return _enable; }
            set
            {
                _enable = value;
                OnPropertyChanged(nameof(Enable));
            }
        }
        #endregion "Properties"

        #region "Constructor"
        public VerifierSettings()
        {
            ResetToDefaults();
        }
        #endregion "Constructor"

        #region "OverrideMethods"

        /// <summary>
        /// Define the default value, which is Enabled, as the verification function should
        /// be active by default.
        /// </summary>
        #region "ResetToDefaults"
        public override void ResetToDefaults()
        {
            Enable = true;
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
            Enable = GetSettingFromSettingsGroup(settingsGroup, "Enable", Enable);
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
            UpdateSettingInSettingsGroup(settingsGroup, "Enable", Enable, defaults.Enable);
        }
        #endregion

        #endregion "OverrideMethods"
    }
}
