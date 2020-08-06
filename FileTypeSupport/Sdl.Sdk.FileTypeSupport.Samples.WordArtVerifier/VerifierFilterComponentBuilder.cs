using Sdl.FileTypeSupport.Framework.IntegrationApi;
using System.Collections.Generic;

namespace Sdl.Sdk.FileTypeSupport.Samples.WordArtVerifier
{
    #region Attributes
    [FileTypeComponentBuilderExtension(
        Id = "Word2007_FilterComponentBuilderExtension_WordArtVerifier_Id",
        Name = "Word2007_FilterComponentBuilderExtension_WordArtVerifier_Name",
        Description = "Word2007_FilterComponentBuilderExtension_WordArtVerifier_Description",
        OriginalFileType = "WordprocessingML v. 2")]
    #endregion
    public class VerifierFilterComponentBuilder : IFileTypeComponentBuilderAdapter
    {
        #region BuildFileTypeInformation
        public IFileTypeInformation BuildFileTypeInformation(string name)
        {
            var fileTypeInformation = Original.BuildFileTypeInformation(name);
            // add "WordArtVerifier_Settings" to existing WinFormSettingsPageIds
            var winFormSettingsPageIds = new List<string>(fileTypeInformation.WinFormSettingsPageIds)
            {
                "WordArtVerifier_Settings"
            };
            fileTypeInformation.WinFormSettingsPageIds = winFormSettingsPageIds.ToArray();

            return fileTypeInformation;

        }
        #endregion

        #region BuildVerifierCollection
        public IVerifierCollection BuildVerifierCollection(string name)
        {
            IVerifierCollection verifierCollection = Original.BuildVerifierCollection(name);
            verifierCollection.BilingualVerifiers.Add(new VerifierMain());
            return verifierCollection;
        }
        #endregion

        public IFileTypeComponentBuilder Original { get; set; }

        public IAbstractGenerator BuildAbstractGenerator(string name)
        {
            return Original.BuildAbstractGenerator(name);
        }

        public IAdditionalGeneratorsInfo BuildAdditionalGeneratorsInfo(string name)
        {
            return Original.BuildAdditionalGeneratorsInfo(name);
        }

        public IBilingualDocumentGenerator BuildBilingualGenerator(string name)
        {
            return Original.BuildBilingualGenerator(name);
        }

        public IFileExtractor BuildFileExtractor(string name)
        {
            return Original.BuildFileExtractor(name);
        }

        public IFileGenerator BuildFileGenerator(string name)
        {
            return Original.BuildFileGenerator(name);
        }

        public Sdl.FileTypeSupport.Framework.NativeApi.INativeFileSniffer BuildFileSniffer(string name)
        {
            return Original.BuildFileSniffer(name);
        }

        public IAbstractPreviewApplication BuildPreviewApplication(string name)
        {
            return Original.BuildPreviewApplication(name);
        }

        public IAbstractPreviewControl BuildPreviewControl(string name)
        {
            return Original.BuildPreviewControl(name);
        }

        public IPreviewSetsFactory BuildPreviewSetsFactory(string name)
        {
            return Original.BuildPreviewSetsFactory(name);
        }

        public IQuickTagsFactory BuildQuickTagsFactory(string name)
        {
            return Original.BuildQuickTagsFactory(name);
        }

        public IFileTypeManager FileTypeManager { get; set; }

        public IFileTypeDefinition FileTypeDefinition { get; set; }
    }
}