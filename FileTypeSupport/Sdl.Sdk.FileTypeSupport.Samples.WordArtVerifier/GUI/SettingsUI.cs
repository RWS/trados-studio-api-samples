using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sdl.FileTypeSupport.Framework.Core.Settings;


namespace Sdl.Sdk.FileTypeSupport.Samples.WordArtVerifier
{
    /// <summary>
    /// Implements theuUser interface through which the settings of the verification plug-in 
    /// are configured, i.e. the maximum word count and enabling / disabling the verification.
    /// </summary>
    public partial class SettingsUI : UserControl, IFileTypeSettingsAware<VerifierSettings>
    {
        /// <summary>
        /// Create a settings object based on the VerifierSettings class. 
        /// </summary>
        #region "SettingsObject"
        VerifierSettings _settings;
        #endregion

        /// <summary>
        /// Initalize the user interface control by setting it to the
        /// setting value stored in the settings bundle.
        /// </summary>
        public SettingsUI()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Reset the user interface control to its default value, which is
        /// checked, i.e. the verification functionality should be enabled
        /// by default.
        /// </summary>
        #region "UpdateControl"
        public void UpdateControl()
        {
            cb_CheckWordArt.Checked = _settings.CheckWordArt;
            txt_MaxWordCount.Text = _settings.MaxWordCount.ToString();
        }
        #endregion


        /// <summary>
        /// Save the settings based on the value of the check box.
        /// The setting is saved through the VerifierSettings class, which
        /// handles the plug-in settings bundle.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region "SaveSettingEnabled"
        private void cb_CheckWordArt_CheckedChanged(object sender, EventArgs e)
        {
            _settings.CheckWordArt = cb_CheckWordArt.Checked;
        }
        #endregion

        /// <summary>
        /// Save the settings based on the value of the maximum word count text field.
        /// Note that the word count is a string value, which needs to be converted to an integer.
        /// The setting is saved through the VerifierSettings class, which
        /// handles the plug-in settings bundle.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region "SaveSettingMaxCount"
        private void txt_MaxWordCount_TextChanged(object sender, EventArgs e)
        {
            int tempvalue = 0;
            Int32.TryParse(txt_MaxWordCount.Text, out tempvalue);
            if (tempvalue > 0)
            {
                _settings.MaxWordCount = tempvalue;
            }
        }
        #endregion

        #region "Initialize"
        public VerifierSettings Settings
        {
            get
            {
                return _settings;
            }
            set
            {
                _settings = value;
                UpdateControl();
            }
        }
        #endregion
    }
}
