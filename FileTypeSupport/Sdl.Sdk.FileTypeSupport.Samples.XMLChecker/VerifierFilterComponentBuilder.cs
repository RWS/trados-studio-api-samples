using Sdl.FileTypeSupport.Framework.IntegrationApi;
using System.Collections.Generic;

namespace Sdl.Sdk.FileTypeSupport.Samples.XMLChecker
{
    #region Attributes
    [FileTypeComponentBuilderExtension(
        Id = "XML_FilterComponentBuilderExtension_Verifier_Id",
        Name = "XML_FilterComponentBuilderExtension_Verifier_Name",
        Description = "XML_FilterComponentBuilderExtension_Verifier_Description",
        OriginalFileType = "XML: Any v 2.0.0.0")]
    #endregion
    public class VerifierFilterComponentBuilder : IFileTypeComponentBuilderAdapter
    {
        #region BuildFileTypeInformation
        public IFileTypeInformation BuildFileTypeInformation(string name)
        {
            var fileTypeInformation = Original.BuildFileTypeInformation(name);
            // add "XMLVerifier_Settings" to existing WinFormSettingsPageIds
            var winFormSettingsPageIds = new List<string>(fileTypeInformation.WinFormSettingsPageIds)
            {
                "XMLVerifier_Settings"
            };
            fileTypeInformation.WinFormSettingsPageIds = winFormSettingsPageIds.ToArray();
            return fileTypeInformation;
        }
        #endregion

        #region BuildVerifierCollection
        public IVerifierCollection BuildVerifierCollection(string name)
        {
            var verifierCollection = Original.BuildVerifierCollection(name);
            verifierCollection.NativeVerifiers.Add(new XMLCheckerMain());
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