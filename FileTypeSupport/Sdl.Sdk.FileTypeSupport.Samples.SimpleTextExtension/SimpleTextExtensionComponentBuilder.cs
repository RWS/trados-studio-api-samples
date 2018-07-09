namespace Sdl.Sdk.FileTypeSupport.Samples.SimpleTextExtension
{
    using Sdl.Core.Globalization;
    using Sdl.FileTypeSupport.Framework;
    using Sdl.FileTypeSupport.Framework.IntegrationApi;
    using Sdl.FileTypeSupport.Framework.NativeApi;

    [FileTypeComponentBuilderExtensionAttribute(Id = "SimpleTextFilterExtension_Id",
                                       Name = "SimpleTextFilterExtension_Name",
                                       Description = "SimpleTextFilterExtension_Description",
                                       OriginalFileType = "Simple Text Filter 1.0.0.0")]
    public sealed class SimpleTextExtensionComponentBuilder : IFileTypeComponentBuilderAdapter
    {
        public IFileTypeInformation BuildFileTypeInformation(string name)
        {
            var info = Original.BuildFileTypeInformation(name);

            info.FileTypeDefinitionId = new FileTypeDefinitionId("SimpleTextExtension 1.0.0.0");
            info.FileTypeName = new LocalizableString("SimpleTextExtension");
            //info.FileTypeDocumentName = new LocalizableString("SimpleTextExtension");
            //info.FileTypeDocumentsName = new LocalizableString("SimpleTextExtensions");
            //info.Description = new LocalizableString("Simple Extension Filter");
            //info.FileDialogWildcardExpression = "*.txtExtension";
            //info.DefaultFileExtension = "txtExtension";

            return info;
        }

        public INativeFileSniffer BuildFileSniffer(string name)
        {
            return Original.BuildFileSniffer(name);
        }

        #region BuildFileExtractor
        public IFileExtractor BuildFileExtractor(string name)
        {
            // remember to call the original component builder method
            var extractor = Original.BuildFileExtractor(name);

            // add a pre tweaker
            extractor.AddFileTweaker(new SimpleTextExtensionPreTweaker { RequireValidEncoding = false });

            // add a native content processor
            if (extractor.NativeExtractor != null)
            {
                extractor.NativeExtractor.AddProcessor(new NativeContentProcessorStub());
            }

            // add a bilingual content processor
            extractor.AddBilingualProcessor(new BilingualContentProcessorStub());

            return extractor;
        }
        #endregion

        public IFileGenerator BuildFileGenerator(string name)
        {
            // remember to call the base class method
            var generator = Original.BuildFileGenerator(name);

            // add a post tweaker
            generator.AddFileTweaker(new SimpleTextExtensionPostTweaker() { RequireValidEncoding = false });

            // add a native processor to the generator
            if (generator.NativeGenerator != null)
            {
                generator.NativeGenerator.AddProcessor(new NativeContentProcessorStub());
            }

            // add a bilingual content processor
            generator.AddBilingualProcessor(new BilingualContentProcessorStub());

            return generator;
        }

        public IVerifierCollection BuildVerifierCollection(string name)
        {
            // remember to call the base class method
            var verifierCollection = Original.BuildVerifierCollection(name);
            verifierCollection.NativeVerifiers.Add(new NativeVerifierStub());
            verifierCollection.BilingualVerifiers.Add(new BilingualVerifierStub());
            return verifierCollection;
        }

        public IBilingualDocumentGenerator BuildBilingualGenerator(string name)
        {
            return Original.BuildBilingualGenerator(name);
        }

        public IPreviewSetsFactory BuildPreviewSetsFactory(string name)
        {
            return Original.BuildPreviewSetsFactory(name);
        }

        public IAbstractPreviewApplication BuildPreviewApplication(string name)
        {
            return Original.BuildPreviewApplication(name);
        }

        public IAbstractPreviewControl BuildPreviewControl(string name)
        {
            return Original.BuildPreviewControl(name);
        }

        public IFileTypeComponentBuilder Original { get; set; }

        public IAbstractGenerator BuildAbstractGenerator(string name)
        {
            return Original.BuildAbstractGenerator(name);
        }

        public IAdditionalGeneratorsInfo BuildAdditionalGeneratorsInfo(string name)
        {
            return Original.BuildAdditionalGeneratorsInfo(name);
        }

        public IQuickTagsFactory BuildQuickTagsFactory(string name)
        {
            return Original.BuildQuickTagsFactory(name);
        }

        public IFileTypeManager FileTypeManager { get; set; }

        public IFileTypeDefinition FileTypeDefinition { get; set; }
    }
}
