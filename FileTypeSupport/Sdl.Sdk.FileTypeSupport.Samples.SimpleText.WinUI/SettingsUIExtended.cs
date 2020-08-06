using Sdl.FileTypeSupport.Framework.Core.Settings;
using System;
using System.Windows.Forms;

namespace Sdl.Sdk.FileTypeSupport.Samples.SimpleText.WinUI
{
    /// <summary>
    /// Implements the user interface for the file type definition.
    /// </summary>
    #region "ClassDeclaration"
    public partial class SettingsUIExtended : UserControl, IFileTypeSettingsAware<UserSettingsExtended>
    #endregion
    {
        /// <summary>
        /// Create a settings object based on the UserSettings class. 
        /// </summary>
        #region "SettingsObject"
        private UserSettingsExtended _userSettings;
        #endregion

        /// <summary>
        /// Initalize the user interface control by setting it to the
        /// setting value stored in the settings bundle.
        /// </summary>
        #region "Initialize"
        public SettingsUIExtended()
        {
            InitializeComponent();
        }
        #endregion


        /// <summary>
        /// Reset the user interface control to its default value, which is
        /// checked, i.e. the product lock option should be enabled
        /// by default.
        /// </summary>
        #region "UpdateControl"
        public void UpdateControl()
        {
            cb_LockPrdCodes.Checked = _userSettings.LockPrdCodes;
            txt_PrdCodePrefix.Text = _userSettings.PrdCodesPrefix;
        }
        #endregion

        /// <summary>
        /// Save the settings based on the value of the the check box.
        /// The setting is saved through the UserSettings class, which
        /// handles the plug-in settings bundle.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region "SaveSetting"
        private void Cb_LockPrdCodes_CheckedChanged(object sender, EventArgs e)
        {
            _userSettings.LockPrdCodes = cb_LockPrdCodes.Checked;

            if (cb_LockPrdCodes.Checked)
                txt_PrdCodePrefix.Enabled = true;
            else
                txt_PrdCodePrefix.Enabled = false;
        }
        #endregion

        #region "SaveTextBox"
        private void Txt_PrdCodePrefix_TextChanged(object sender, EventArgs e)
        {
            _userSettings.PrdCodesPrefix = txt_PrdCodePrefix.Text;
        }
        #endregion

        /// <summary>
        /// Implementation of <code>IFileTypeSettingsAware</code> allowing the Filter Framework
        /// to pass through the user settings so that we can initialize the UI.
        /// </summary>
        #region "ApplySettings"
        public UserSettingsExtended Settings
        {
            get
            {
                return _userSettings;
            }
            set
            {
                _userSettings = value;
                UpdateControl();
            }
        }
        #endregion
    }
}
