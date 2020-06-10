using Sdl.Core.Settings;

namespace Sdl.Verification.Sdk.IdenticalCheck.Extended
{
    /// <summary>
    /// This class is used for reading and writing the plug-in setting(s) value(s).
    /// The settings are physically stored in an (XML-compliant) *.sdlproj file, which
    /// is generated for each project that is created in SDL Trados Studio or for 
    /// each file that is opened and translated.
    /// </summary>
    class IdenticalVerifierSettings : SettingsGroup
    {
        #region "setting"
        // Define the setting constant.
        private const string CheckContext_Setting = "CheckContext";
        private const string ConsiderTags_Setting = "ConsiderTags";

        // Return the value of the setting.
        public Setting<string> CheckContext
        {
            get { return GetSetting<string>(CheckContext_Setting); }
        }

        public Setting<bool> ConsiderTags
        {
            get { return GetSetting<bool>(ConsiderTags_Setting); }
        }
        #endregion

        /// <summary>
        /// Return the default value of the setting property, i.e the context display code,
        /// which by default is H (i.e. headline). The default value for considering tags should be true.
        /// </summary>
        /// <param name="settingId"></param>
        /// <returns></returns>
        #region "default"
        protected override object GetDefaultValue(string settingId)
        {
            switch (settingId)
            {
                case CheckContext_Setting:
                    return "H";
                case ConsiderTags_Setting:
                    return true;
                default:
                    return base.GetDefaultValue(settingId);
            }
        }
        #endregion
    }
}
