using Sdl.FileTypeSupport.Framework.Core.Settings;

namespace Sdl.Sdk.FileTypeSupport.Samples.XMLChecker
{
    /// <summary>
    /// This class controls the plug-in user interface. It controls what happens, for example,
    /// when the user clicks the button in the user interface for resetting the control elements
    /// to their default values. This class is referenced in the file type definition. Without
    /// this reference in the SDLFILETPYE file, the plug-in user interface would not be available
    /// to the end user.
    /// </summary>
    #region "ClassDeclaration"
    [FileTypeSettingsPage(Id = "XMLVerifier_Settings", Name = "Settings_Name", Description = "Settings_Description")]
    class SettingsPage : AbstractFileTypeSettingsPage<SettingsUI, VerifierSettings>
    #endregion
    {
        /// <summary>
        /// Triggered, when the user clicks the button Reset to Defaults button in 
        /// SDL Trados Studio. Restores the default check box state, which should
        /// be Checked (i.e. verification function enabled).
        /// </summary>
        #region "ResetToDefaults"
        public override void ResetToDefaults()
        {
            base.ResetToDefaults();
            Control.UpdateControl();
        }
        #endregion

        /// <summary>
        /// Triggered when the user raises the plug-in UI, whose controls (in this case the check box)
        /// will then be set according to the values stored in the settings bundle.
        /// </summary>
        /// <param name="settingsBundle"></param>
        #region "ReloadSettings"
        public override void Refresh()
        {
            base.Refresh();
            Control.UpdateControl();
        }
        #endregion
    }
}
