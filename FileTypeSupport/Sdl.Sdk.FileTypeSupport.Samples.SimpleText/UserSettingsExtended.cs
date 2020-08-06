using Sdl.FileTypeSupport.Framework.Core.Settings;
using Sdl.Core.Settings;

namespace Sdl.Sdk.FileTypeSupport.Samples.SimpleText
{
    /// <summary>
    /// This class is used to actually store the settings to the settings bundle, which
    /// is physically saved in an *.sdlproj or in an *.sdltpl file.
    /// </summary>
    public class UserSettingsExtended : FileTypeSettingsBase
    {
        #region "Properties"
        private const string SettingsLockPrdCodes = "LockPrdCodes";
        private const string SettingsPrdCodesPrefix = "PrdCodesPrefix";

        private const bool DefaultLockPrdCodes = true;
        private const string DefaultPrdCodePrefix = "Prd-Code";

        private bool _lockPrdCodes;
        private string _prdCodesPrefix;

        public bool LockPrdCodes
        {
            get { return _lockPrdCodes; }
            set
            {
                _lockPrdCodes = value;
                OnPropertyChanged(nameof(LockPrdCodes));
            }
        }

        public string PrdCodesPrefix
        {
            get { return _prdCodesPrefix; }
            set
            {
                _prdCodesPrefix = value;
                OnPropertyChanged(nameof(PrdCodesPrefix));
            }
        }
        #endregion

        #region "Constructor"
        public UserSettingsExtended()
        {
            ResetToDefaults();
        }
        #endregion

        /// <summary>
        /// Define the default value, which is Enabled, as the product code strings should
        /// not be exposed to translation by default.
        /// </summary>
        #region "ResetToDefaults"
        public override sealed void ResetToDefaults()
        {
            LockPrdCodes = DefaultLockPrdCodes;
            PrdCodesPrefix = DefaultPrdCodePrefix;
        }
        #endregion

        /// <summary>
        /// This method is used to load the setting from the settings bundle,
        /// which is physically stored in an XML-compliant *.sdlproj or *.sdltpl file.
        /// </summary>
        /// <param name="settingsBundle"></param>
        /// <param name="configurationId"></param>
        #region "PopulateFromSettingsBundle"
        public override void PopulateFromSettingsBundle(ISettingsBundle settingsBundle, string filterDefinitionId)
        {
            ISettingsGroup settingsGroup = settingsBundle.GetSettingsGroup(filterDefinitionId);
            LockPrdCodes = GetSettingFromSettingsGroup(settingsGroup, SettingsLockPrdCodes, DefaultLockPrdCodes);
            PrdCodesPrefix = GetSettingFromSettingsGroup(settingsGroup, SettingsPrdCodesPrefix, DefaultPrdCodePrefix);
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
        public override void SaveToSettingsBundle(ISettingsBundle settingsBundle, string filterDefinitionId)
        {
            ISettingsGroup settingsGroup = settingsBundle.GetSettingsGroup(filterDefinitionId);
            UpdateSettingInSettingsGroup(settingsGroup, SettingsLockPrdCodes, LockPrdCodes, DefaultLockPrdCodes);
            UpdateSettingInSettingsGroup(settingsGroup, SettingsPrdCodesPrefix, PrdCodesPrefix, DefaultPrdCodePrefix);
        }
        #endregion
    }
}
