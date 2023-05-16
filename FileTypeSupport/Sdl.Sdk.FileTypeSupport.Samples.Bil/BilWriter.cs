using System.Xml;
using Sdl.Core.Globalization;
using Sdl.FileTypeSupport.Framework.BilingualApi;
using Sdl.FileTypeSupport.Framework.NativeApi;

namespace Sdl.Sdk.FileTypeSupport.Samples.Bil
{
	internal class BilWriter : AbstractBilingualFileTypeComponent, IBilingualWriter, INativeOutputSettingsAware
	{
		#region "global"
		private IPersistentFileConversionProperties _originalFileProperties;
		private INativeOutputFileProperties _nativeFileProperties;
		private XmlDocument _targetFile;
		private BilTextExtractor _textExtractor;
		#endregion

		#region "INativeOutputSettingsAware members"
		public void GetProposedOutputFileInfo(IPersistentFileConversionProperties fileProperties, IOutputFileInfo proposedFileInfo)
		{
			_originalFileProperties = fileProperties;
		}

		public void SetOutputProperties(INativeOutputFileProperties properties)
		{
			_nativeFileProperties = properties;
		}
		#endregion

		#region "IBilingualWriter members"

		#region "load file"
		public void SetFileProperties(IFileProperties fileInfo)
		{
			_targetFile = new XmlDocument();
			_targetFile.Load(_originalFileProperties.OriginalFilePath);
		}

		#region "initialize"
		public void Initialize(IDocumentProperties documentInfo)
		{
			_textExtractor = new BilTextExtractor();
		}
		#endregion

		#endregion

		#region "paragraphs"
		public void ProcessParagraphUnit(IParagraphUnit paragraphUnit)
		{
			string unitId = paragraphUnit.Properties.Contexts.Contexts[1].GetMetaData("UnitID");
			XmlNode xmlUnit = _targetFile.SelectSingleNode("//unit[@id='" + unitId + "']");

			// call helper function to generate the paragraph unit
			CreateParagraphUnit(paragraphUnit, xmlUnit);
			// call helper function to consolidate all comments
			UpdateComments(paragraphUnit, xmlUnit);
		}
		#endregion

		#region "helper functions"

		#region "create paragraph"
		private void CreateParagraphUnit(IParagraphUnit paragraphUnit, XmlNode xmlUnit)
		{
			XmlNode source = xmlUnit.SelectSingleNode("source");
			XmlNode target = xmlUnit.SelectSingleNode("target");

			// iterate all segment pairs
			foreach (ISegmentPair segmentPair in paragraphUnit.SegmentPairs)
			{
				source.InnerXml = _textExtractor.GetPlainText(segmentPair.Source);
				target.InnerXml = _textExtractor.GetPlainText(segmentPair.Target);
				// update unit status
				xmlUnit.SelectSingleNode("./@status").Value = UpdateStatus(segmentPair.Properties.ConfirmationLevel);
			}
		}
		#endregion

		#region "confirmation level"
		private string UpdateStatus(ConfirmationLevel unitLevel)
		{
			string status;
			switch (unitLevel)
			{
				case ConfirmationLevel.Translated:
					status = "exact";
					break;
				case ConfirmationLevel.Draft:
					status = "fuzzy";
					break;
				case ConfirmationLevel.Unspecified:
					status = "new";
					break;
				default:
					status = "new";
					break;
			}

			return status;
		}
		#endregion

		#region "update comments"
		private void UpdateComments(IParagraphUnit paragraphUnit, XmlNode unitNode)
		{
			#region "clear"
			// clear the original comments
			XmlNodeList comments = unitNode.SelectNodes("comment");
			foreach (XmlNode item in comments)
			{
				((XmlElement)unitNode).RemoveChild(item);
			}
			#endregion

			// loop through the comments in the SDLXLIFF paragraph units (if available)
			// these comments were added from the original BIL file 
			// during parsing (i.e. forward conversion)
			#region "original comments"
			int commentID = 1;
			if (paragraphUnit.Properties.Comments != null)
			{
				for (int i = 0; i < paragraphUnit.Properties.Comments.Count; i++)
				{
					IComment actualComment = paragraphUnit.Properties.Comments.GetItem(i);
					AddComment(unitNode, actualComment.Text, commentID);
					commentID++;
				}
			}
			#endregion

			// generate the consolidated list of comments from the original 
			// BIL file and any comments added by the translator in the SDLXLIFF file
			#region "tranlator comments"
			foreach (ISegmentPair segmentPair in paragraphUnit.SegmentPairs)
			{
				foreach (string comment in _textExtractor.GetSegmentComment(segmentPair.Target))
				{
					AddComment(unitNode, comment, commentID);
					commentID++;
				}
			}
			#endregion
		}
		#endregion

		#region "add comment"
		private void AddComment(XmlNode xmlUnit, string commentText, int commentID)
		{
			XmlElement commentElement = _targetFile.CreateElement("comment");
			XmlAttribute commentIdAttrib = _targetFile.CreateAttribute("id");
			commentIdAttrib.Value = commentID.ToString();
			commentElement.Attributes.Append(commentIdAttrib);
			commentElement.InnerText = commentText;
			xmlUnit.AppendChild(commentElement);
		}
		#endregion

		#region "save file and complete"
		public void FileComplete()
		{
			_targetFile.Save(_nativeFileProperties.OutputFilePath);
			_targetFile = null;
		}

		public void Complete()
		{

		}
		#endregion
		#endregion

		#endregion

		#region IDisposable implementation

		public void Dispose()
		{
			//don't need to dispose of anthing
		}

		#endregion
	}
}
