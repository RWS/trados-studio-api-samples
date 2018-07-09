using Sdl.Core.Settings;

using Sdl.Verification.Api;

namespace Sdl.Verification.Sdk.IdenticalCheck.Extended
{
    /// <summary>
    /// This is the extension class that displays and controls the plug-in user interface,
    /// in which the verification setting(s) can be specified. This class is responsible for
    /// e.g. saving the setting(s) configured in the UI, for resetting the values to their defaults,
    /// and for properly disposing of the UI control.
    /// </summary>
    #region "Declaration"
    [GlobalVerifierSettingsPage(
    Id = "Identical Settings Definition ID",
    Name = "Context to check",
    Description = "The display code of the context for which the length check should be performed.",
    HelpTopic = "")]
    #endregion
    class IdenticalVerifierUIPage : AbstractSettingsPage
    {
        #region "PrivateMembers"
        private IdenticalVerifierUI _Control;
        private IdenticalVerifierSettings _ControlSettings;
        #endregion

        #region "control"
        // Return the UI control.
        #region "GetControl"
        public override object GetControl()
        {
            _ControlSettings = ((ISettingsBundle)DataSource).GetSettingsGroup<IdenticalVerifierSettings>();
            _ControlSettings.BeginEdit();
            if (_Control == null)
            {
                _Control = new IdenticalVerifierUI();
            }

            return _Control;
        }
        #endregion


        // Load data from the settings into the UI control.
        #region "OnActivate"
        public override void OnActivate()
        {
            _Control.ContextToCheck = _ControlSettings.CheckContext;
            _Control.ConsiderTags = _ControlSettings.ConsiderTags;
        }
        #endregion



        // Reset the values on the UI control.
        #region "ResetToDefaults"
        public override void ResetToDefaults()
        {
            _ControlSettings.CheckContext.Reset();
            _Control.ContextToCheck = _ControlSettings.CheckContext;
            _Control.ConsiderTags = _ControlSettings.ConsiderTags;
        }
        #endregion


        public override bool ValidateInput()
        {
            return _Control.ValidateChildren();
        }


        // Save the values from the UI into settings class.
        #region "Save"
        public override void Save()
        {
            _ControlSettings.CheckContext.Value = _Control.ContextToCheck;
            _ControlSettings.ConsiderTags.Value = _Control.ConsiderTags;
        }
        #endregion


        // Call EndEdit after all changes have been saved in the Save() call.
        #region "AfterSave"
        public override void AfterSave()
        {
            _ControlSettings.EndEdit();
        }
        #endregion


        // Cancel any pending changes.
        #region "Cancel"
        public override void Cancel()
        {
            _ControlSettings.CancelEdit();
        }
        #endregion

        // Properly dispose of the control.
        #region "Dispose"
        public override void Dispose()
        {
            _Control.Dispose();
        }
        #endregion

        #endregion
    }
}
