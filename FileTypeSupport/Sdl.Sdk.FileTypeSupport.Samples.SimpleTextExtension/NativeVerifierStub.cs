using System;

namespace Sdl.Sdk.FileTypeSupport.Samples.SimpleTextExtension
{
    using Sdl.Core.Settings;
    using Sdl.FileTypeSupport.Framework.IntegrationApi;
    using Sdl.FileTypeSupport.Framework.NativeApi;

    public class NativeVerifierStub : AbstractNativeFileTypeComponent, INativeFileVerifier, ISharedObjectsAware, ISettingsAware
    {
        #region INativeVerifier Members
        public void Verify()
        {
        }

        #endregion

        #region ISettingsAware Members

        public void InitializeSettings(ISettingsBundle settingsBundle, string configurationId)
        {
        }

        #endregion

        #region INativeOutputSettingsAware Members

        public void SetOutputProperties(INativeOutputFileProperties properties)
        {
        }

        public void GetProposedOutputFileInfo(IPersistentFileConversionProperties fileProperties, IOutputFileInfo proposedFileInfo)
        {
        }

        #endregion

        public new INativeTextLocationMessageReporter MessageReporter
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public void SetSharedObjects(ISharedObjects sharedObjects)
        {
        }
    }
}
