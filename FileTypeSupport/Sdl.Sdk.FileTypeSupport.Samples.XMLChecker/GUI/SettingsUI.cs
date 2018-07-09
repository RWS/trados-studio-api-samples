using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sdl.FileTypeSupport.Framework.Core.Settings;

namespace Sdl.Sdk.FileTypeSupport.Samples.XMLChecker
{
    /// <summary>
    /// Implements the user interface through which the verification plug-in can be enabled or disabled.
    /// </summary>
    #region ClassDeclaration
    public partial class SettingsUI : UserControl, IFileTypeSettingsAware<VerifierSettings>
    #endregion
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
            cb_Enable.Checked = _settings.Enable;
        }
        #endregion

        /// <summary>
        /// Save the settings based on the value of the the check box.
        /// The setting is saved through the VerifierSettings class, which
        /// handles the plug-in settings bundle.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region "SaveSetting"
        private void cb_Enable_CheckedChanged(object sender, EventArgs e)
        {
            _settings.Enable = cb_Enable.Checked;
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
