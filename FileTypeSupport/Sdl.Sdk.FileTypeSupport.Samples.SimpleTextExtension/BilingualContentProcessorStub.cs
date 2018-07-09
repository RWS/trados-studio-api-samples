namespace Sdl.Sdk.FileTypeSupport.Samples.SimpleTextExtension
{
    using System.Collections.Generic;
    using Sdl.FileTypeSupport.Framework.BilingualApi;
    using Sdl.FileTypeSupport.Framework.NativeApi;
    
    public class BilingualContentProcessorStub : AbstractBilingualContentProcessor, ISharedObjectsAware, INativeOutputSettingsAware
	{
		#region Data Members

		List<IParagraphUnit> _paragraphUnits = new List<IParagraphUnit>();

		public List<IParagraphUnit> ParagraphUnits
		{
			get
			{
				return _paragraphUnits;
			}
			set
			{
				_paragraphUnits = value;
			}
		}

		public IDocumentProperties LastDocumentProperties;
		public IFileProperties LastFileProperties;
		public IParagraphUnit LastStructureParagraphUnit;
		public IParagraphUnit LastLocalizableParagraphUnit;
		public IParagraphUnit PreviousLocalizableParagraphUnit;

		#endregion

		#region IBilingualContentHandler Members

		public override void Initialize(IDocumentProperties documentInfo)
		{
			base.Initialize(documentInfo);
		}


		public override void Complete()
		{
			base.Complete();
		}


		public override void SetFileProperties(IFileProperties fileInfo)
		{
			base.SetFileProperties(fileInfo);
		}


		public override void FileComplete()
		{
			base.FileComplete();
		}


		public override void ProcessParagraphUnit(IParagraphUnit paragraphUnit)
		{
			base.ProcessParagraphUnit(paragraphUnit);
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

		#region ISharedObjectsAware Members

		public void SetSharedObjects(ISharedObjects sharedObjects)
		{
		}

		#endregion

	}
}
