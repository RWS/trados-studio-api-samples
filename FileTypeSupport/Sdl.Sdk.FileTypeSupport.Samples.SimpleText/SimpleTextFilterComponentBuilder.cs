using Sdl.Sdk.FileTypeSupport.Samples.SimpleText.Preview;

namespace Sdl.Sdk.FileTypeSupport.Samples.SimpleText
{
    using System;
    using Sdl.Core.Globalization;
    using Sdl.FileTypeSupport.Framework;
    using Sdl.FileTypeSupport.Framework.IntegrationApi;
    using Sdl.FileTypeSupport.Framework.NativeApi;
    using Sdl.Sdk.FileTypeSupport.Samples.SimpleText.Properties;

    /// <summary>
    /// Define Simple Text filter component builder.
    /// </summary> 
    [FileTypeComponentBuilderAttribute(Id = "SimpleText_FilterComponentBuilderExtension_Id",
                                       Name = "SimpleText_FilterComponentBuilderExtension_Name",
                                       Description = "SimpleText_FilterComponentBuilderExtension_Description")]
    public class SimpleTextFilterComponentBuilder : IFileTypeComponentBuilder
    {
        /// <summary>
        /// Gets or sets file type manager
        /// </summary>
        public IFileTypeManager FileTypeManager { get; set; }

        /// <summary>
        /// Gets or sets Filter Definition
        /// </summary>
        public IFileTypeDefinition FileTypeDefinition { get; set; }

        #region FileTypeInfo
        /// <summary>
        /// Returns a file type information object.
        /// </summary>
        /// <param name="name">The <see cref="IFileTypeDefinition"/> will pass "" as the name for this parameter</param>
        /// <returns>an SimpleText file type information object</returns>
        public virtual IFileTypeInformation BuildFileTypeInformation(string name)
        {
            var info = this.FileTypeManager.BuildFileTypeInformation();

            info.FileTypeDefinitionId = new FileTypeDefinitionId("Simple Text Filter 1.0.0.0");
            info.FileTypeName = new LocalizableString("Simple text files");
            info.FileTypeDocumentName = new LocalizableString("Test text files");
            info.FileTypeDocumentsName = new LocalizableString("Simple text files");
            info.Description = new LocalizableString("This sample filter is used to process simple text files.");
            info.FileDialogWildcardExpression = "*.text";
            info.DefaultFileExtension = "text";
            info.Icon = new IconDescriptor(PluginResources.SimpleTextIcon);
            
            info.WinFormSettingsPageIds = new string[]
            {
                "SimpleText_Settings",
                "QuickInserts_Settings",
            };

            return info;
        }
        #endregion

        #region Sniffer
        /// <summary>
        /// Gets the file sniffer for this component.
        /// </summary>
        /// <param name="name">not used here</param>
        /// <returns>An Simple Text Native Filter Sniffer</returns>
        public virtual INativeFileSniffer BuildFileSniffer(string name)
        {
            return new SimpleTextSniffer();
        }
        #endregion

        #region Extractor
        /// <summary>
        /// Gets the file extractor for this component.
        /// </summary>
        /// <param name="name">not used here</param>
        /// <returns>a FileExtractor containing an Simple Text Parser</returns>
        public virtual IFileExtractor BuildFileExtractor(string name)
        {
            var parser = new SimpleTextParser();
            parser.LockPrdCodes = true;
            var extractor = this.FileTypeManager.BuildFileExtractor(this.FileTypeManager.BuildNativeExtractor(parser), this);
            extractor.AddFileTweaker(new SimpleFilePreTweaker {RequireValidEncoding = false});
            return extractor;
        }
        #endregion

        #region Generator
        /// <summary>
        /// Gets the file generator for this component.
        /// </summary>
        /// <param name="name">not used herer</param>
        /// <returns><c>Null</c> if no file generator is defined</returns>
        public virtual IFileGenerator BuildFileGenerator(string name)
        {
            var writer = new SimpleTextWriter();
            var generator = FileTypeManager.BuildFileGenerator(FileTypeManager.BuildNativeGenerator(writer));
            generator.AddFileTweaker(new SimpleFilePostTweaker());
            return generator;
        }
        #endregion

        #region Preview
        /// <summary>
        /// Gets the different sets of previews supported for this component.
        /// </summary>
        /// <param name="name">not used here</param>
        /// <returns>not implemented</returns>
        public virtual IPreviewSetsFactory BuildPreviewSetsFactory(string name)
        {
            IPreviewSetsFactory previewFactory = FileTypeManager.BuildPreviewSetsFactory();

            #region ExternalPreview
            IPreviewSet externalPreviewSet = previewFactory.CreatePreviewSet();
            externalPreviewSet.Id = new PreviewSetId("ExternalPreview");
            externalPreviewSet.Name = new LocalizableString(Resources.ExternalPreview_Name);

            IApplicationPreviewType sourceAppPreviewType = previewFactory.CreatePreviewType<IApplicationPreviewType>() as IApplicationPreviewType;

            if (sourceAppPreviewType != null)
            {
                sourceAppPreviewType.SourceGeneratorId = new GeneratorId("DefaultPreview");
                sourceAppPreviewType.SingleFilePreviewApplicationId = new PreviewApplicationId("ExternalPreview");
                externalPreviewSet.Source = sourceAppPreviewType;
            }

            IApplicationPreviewType targetAppPreviewType = previewFactory.CreatePreviewType<IApplicationPreviewType>() as IApplicationPreviewType;
            if (targetAppPreviewType != null)
            {
                targetAppPreviewType.TargetGeneratorId = new GeneratorId("DefaultPreview");
                targetAppPreviewType.SingleFilePreviewApplicationId = new PreviewApplicationId("ExternalPreview");
                externalPreviewSet.Target = targetAppPreviewType;
            }

            previewFactory.GetPreviewSets(null).Add(externalPreviewSet);
            #endregion

            #region InternalStaticPreview
            IPreviewSet internalStaticPreviewSet = previewFactory.CreatePreviewSet();
            internalStaticPreviewSet.Id = new PreviewSetId("InternalStaticPreview");
            internalStaticPreviewSet.Name = new LocalizableString(Resources.InternalStaticPreview_Name);

            IControlPreviewType sourceControlPreviewType1 = previewFactory.CreatePreviewType<IControlPreviewType>() as IControlPreviewType;
            if (sourceControlPreviewType1 != null)
            {
                sourceControlPreviewType1.SourceGeneratorId = new GeneratorId("StaticPreview");
                sourceControlPreviewType1.SingleFilePreviewControlId = new PreviewControlId("InternalNavigablePreview");
                internalStaticPreviewSet.Source = sourceControlPreviewType1;
            }

            IControlPreviewType targetControlPreviewType1 = previewFactory.CreatePreviewType<IControlPreviewType>() as IControlPreviewType;
            if (targetControlPreviewType1 != null)
            {
                targetControlPreviewType1.TargetGeneratorId = new GeneratorId("StaticPreview");
                targetControlPreviewType1.SingleFilePreviewControlId = new PreviewControlId("InternalNavigablePreview");
                internalStaticPreviewSet.Target = targetControlPreviewType1;
            }
            previewFactory.GetPreviewSets(null).Add(internalStaticPreviewSet);
            #endregion

            #region InternalRealtimePreview
            IPreviewSet internalRealPreviewSet = previewFactory.CreatePreviewSet();
            internalRealPreviewSet.Id = new PreviewSetId("InternalRealTimePreview");
            internalRealPreviewSet.Name = new LocalizableString(Resources.InternalRealTimeNavigablePreview_Name);

            IControlPreviewType sourceControlPreviewType2 = previewFactory.CreatePreviewType<IControlPreviewType>() as IControlPreviewType;
            if (sourceControlPreviewType2 != null)
            {
                sourceControlPreviewType2.SourceGeneratorId = new GeneratorId("RealTimePreview");
                sourceControlPreviewType2.SingleFilePreviewControlId = new PreviewControlId("InternalNavigablePreview");
                internalRealPreviewSet.Source = sourceControlPreviewType2;
            }

            IControlPreviewType targetControlPreviewType2 = previewFactory.CreatePreviewType<IControlPreviewType>() as IControlPreviewType;
            if (targetControlPreviewType2 != null)
            {
                targetControlPreviewType2.TargetGeneratorId = new GeneratorId("RealTimePreview");
                targetControlPreviewType2.SingleFilePreviewControlId = new PreviewControlId("InternalNavigablePreview");
                internalRealPreviewSet.Target = targetControlPreviewType2;
            }
            previewFactory.GetPreviewSets(null).Add(internalRealPreviewSet);
            #endregion



            return previewFactory;
        }


        /// <summary>
        /// Creates a new instance of the preview application with the specified name.
        /// Right now only allows to build expternal preview application.
        /// </summary>
        /// <param name="name">Preview application name</param>
        /// <returns>External preview application</returns>
        public virtual IAbstractPreviewApplication BuildPreviewApplication(string name)
        {
            if (name == "PreviewApplication_ExternalPreview")
            {
                // GenericExteralPreviewApplication genericExteralPreviewApplication = new GenericExteralPreviewApplication();
                // genericExteralPreviewApplication.ApplicationPath = @"c:\Windows\System32\notepad.exe";
                // return genericExteralPreviewApplication;
            }

            return null;
        }

        #region DefinePreviewController
        /// <summary>
        /// Creates a new instance of the preview control with the specified name.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Should only be called from the main thread, as controls must always be
        /// instantiated on the same thread as the application message pump.
        /// </para>
        /// </remarks>
        /// <param name="name">not used here</param>
        /// <returns>not implemented</returns>
        public virtual IAbstractPreviewControl BuildPreviewControl(string name)
        {
            if (name == "PreviewControl_InternalStaticPreviewControl")
            {
                return new InternalPreviewController();
            }
            else if (name == "PreviewControl_InternalNavigablePreview")
            {
                return new InternalPreviewController();
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region DefinePreviewWriter
        /// <summary>
        /// Gets a native or bilingual document generator of the type
        /// defined for the specified name.
        /// </summary>
        /// <param name="name">Abstract generator name</param>
        /// <returns>not generator for default preview</returns>
        public virtual IAbstractGenerator BuildAbstractGenerator(string name)
        {
            if (name == "Generator_DefaultPreview")
            {
                return FileTypeManager.BuildFileGenerator(FileTypeManager.BuildNativeGenerator(new SimpleTextWriter()));
            }
            if (name == "Generator_StaticPreview")
            {
                return FileTypeManager.BuildFileGenerator(FileTypeManager.BuildNativeGenerator(new SimpleTextWriter()));
            }
            if (name == "Generator_RealTimePreview")
            {
                return FileTypeManager.BuildFileGenerator(FileTypeManager.BuildNativeGenerator(new InternalPreviewWriter()));
            }

            return null;
        }
        #endregion
        #endregion

        /// <summary>
        /// The the additional generator information for this file type
        /// </summary>
        /// <param name="name">not used here</param>
        /// <returns>not implemented</returns>
        public IAdditionalGeneratorsInfo BuildAdditionalGeneratorsInfo(string name)
        {
            return null;
        }

        #region QuickTags
        /// <summary>
        /// Gets the QuickTags object for this component.
        /// </summary>
        /// <param name="name">not used here</param>
        /// <returns>a Quick tags factory</returns>
        public virtual IQuickTagsFactory BuildQuickTagsFactory(string name)
        {
            IQuickTagsFactory quickTags = FileTypeManager.BuildQuickTagsFactory();
            quickTags.GetQuickTags(null).SetStandardQuickTags(QuickInsertBuilder.BuildStandardQuickTags());
            return quickTags;
        }
        #endregion

        /// <summary>
        /// Gets the verifier list of this component.
        /// </summary>
        /// <param name="name">not used here</param>
        /// <returns>a verifier collection</returns>
        /// <remarks> The verifier list is an optional component for a file type.</remarks>
        public virtual IVerifierCollection BuildVerifierCollection(string name)
        {
            return null;
        }



        /// <summary>
        /// Gets the bilingual writer components for this component (if any).
        /// </summary>
        /// <param name="name">not used here</param>
        /// <returns><c>null</c> if no bilingual generator is defined</returns>
        public virtual IBilingualDocumentGenerator BuildBilingualGenerator(string name)
        {
            return null;
        }
    }
}