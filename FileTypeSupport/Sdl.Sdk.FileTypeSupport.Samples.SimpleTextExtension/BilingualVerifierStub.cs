namespace Sdl.Sdk.FileTypeSupport.Samples.SimpleTextExtension
{
    using Sdl.Core.Settings;
    using Sdl.FileTypeSupport.Framework.BilingualApi;
    using Sdl.FileTypeSupport.Framework.NativeApi;
    using Sdl.FileTypeSupport.Framework.IntegrationApi;

    public class BilingualVerifierStub : AbstractBilingualFileTypeComponent, IBilingualVerifier, ISharedObjectsAware, ISettingsAware
    {

        #region IBilingualContentHandler Members

        public void Initialize(IDocumentProperties documentInfo)
        {
        }

        public void Complete()
        {
        }

        public void SetFileProperties(IFileProperties fileInfo)
        {
        }

        public void FileComplete()
        {
        }

        public void ProcessParagraphUnit(IParagraphUnit paragraphUnit)
        {
        }

        #endregion

        #region ISharedObjectAware Members

        public void SetSharedObjects(ISharedObjects sharedObjects)
        {
        }

        #endregion

        #region ISettingsAware Members

        public void InitializeSettings(ISettingsBundle settingsBundle, string configurationId)
        {
        }

        #endregion
    }
}
