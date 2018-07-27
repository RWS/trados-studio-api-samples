using Sdl.Core.Settings;

namespace Sdl.Verification.Sdk.IdenticalCheck
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

        // Return the value of the setting.
        public Setting<string> CheckContext
        {
            get { return GetSetting<string>(CheckContext_Setting); }
        }
        #endregion

        /// <summary>
        /// Return the default value of the setting property, i.e the context display code,
        /// which by default is H (i.e. headline).
        /// </summary>
        /// <param name="settingId"></param>
        /// <returns></returns>
        #region "default"
        protected override object GetDefaultValue(string settingId)
        {
            switch (settingId)
            {
                case "CheckContext":
                    return (string)"H";
                default:
                    return base.GetDefaultValue(settingId);
            }
        }
        #endregion
    }
}
