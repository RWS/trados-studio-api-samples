using System;
using Sdl.FileTypeSupport.Framework.BilingualApi;
using Sdl.FileTypeSupport.Framework.NativeApi;
using Sdl.FileTypeSupport.Framework.Formatting;
using System.Xml;
using System.Drawing;
using Sdl.FileTypeSupport.Framework.Core.Utilities.NativeApi;
using Sdl.Core.Globalization;
using Sdl.FileTypeSupport.Framework.IntegrationApi;
using Sdl.FileTypeSupport.Framework.Core.Utilities.Formatting;


namespace Sdl.Sdk.FileTypeSupport.Samples.Bil
{
    class BilParser : AbstractBilingualFileTypeComponent, IBilingualParser, INativeContentCycleAware, ISettingsAware
    {
        #region "global"
        private IPersistentFileConversionProperties _fileProperties;
        private XmlDocument _document;
        public event EventHandler<ProgressEventArgs> Progress;
        #endregion

        #region "native content"
        #region "set file properties"
        public void SetFileProperties(IFileProperties properties)
        {
            _fileProperties = properties.FileConversionProperties;

            Output.Initialize(DocumentProperties);

            IFileProperties fileInfo = ItemFactory.CreateFileProperties();
            fileInfo.FileConversionProperties = _fileProperties;
            Output.SetFileProperties(fileInfo);
        }
        #endregion

        #region "open file"
        public void StartOfInput()
        {
            OnProgress(0);
            _document = new XmlDocument();
            _document.Load(_fileProperties.OriginalFilePath);
        }
        #endregion

        #region "close file"
        public void EndOfInput()
        {
            // done with the file
            Output.FileComplete();
            // done with the document
            Output.Complete();

            OnProgress(100);
            _document = null;
        }
        #endregion
        #endregion

        #region "progress"
        protected virtual void OnProgress(byte percent)
        {
            Progress?.Invoke(this, new ProgressEventArgs(percent));
        }
        #endregion

        #region "bilingual parser members"
        public IDocumentProperties DocumentProperties
        {
            get;
            set;
        }

        public IBilingualContentHandler Output
        {
            get;
            set;
        }
        #endregion

        #region "parse"
        public bool ParseNext()
        {
            // variables for the progress report
            int totalUnitCount = _document.SelectNodes("//unit").Count;
            int currentUnitCount = 0;
            foreach (XmlNode item in _document.SelectNodes("//unit"))
            {
                Output.ProcessParagraphUnit(CreateParagraphUnit(item));

                // update the progress report   
                currentUnitCount++;
                OnProgress(Convert.ToByte(Math.Round(100 * ((decimal)currentUnitCount / totalUnitCount), 0)));
            }

            return false;
        }
        #endregion

        #region "create paragraph units"
        // helper function for creating paragraph units
        private IParagraphUnit CreateParagraphUnit(XmlNode xmlUnit)
        {
            // create paragraph unit object
            IParagraphUnit paragraphUnit = ItemFactory.CreateParagraphUnit(LockTypeFlags.Unlocked);
            

            // create segment pair object
            ISegmentPairProperties segmentPairProperties = ItemFactory.CreateSegmentPairProperties();  
            // assign the appropriate confirmation level to the segment pair            
            segmentPairProperties.ConfirmationLevel=CreateConfirmationLevel(xmlUnit.Attributes["status"].Value);
            
            // add source segment to paragraph unit
            ISegment srcSegment = CreateSegment(xmlUnit.SelectSingleNode("source/seg"), segmentPairProperties);            
            paragraphUnit.Source.Add(srcSegment);

            // add target segment to paragraph unit if available
            if(xmlUnit.SelectSingleNode("target/seg") != null)            
            {
                ISegment trgSegment = CreateSegment(xmlUnit.SelectSingleNode("target/seg"), segmentPairProperties);
                paragraphUnit.Target.Add(trgSegment);
            }

            #region "context"
            // create paragraph unit context
            string id = xmlUnit.SelectSingleNode("./@id").InnerText;
            if(xmlUnit.SelectSingleNode("type/@spec")!=null)
            {
                string spec = xmlUnit.SelectSingleNode("type/@spec").InnerText;
                
                paragraphUnit.Properties.Contexts=CreateContext(spec, id);
            } else {
                paragraphUnit.Properties.Contexts = CreateContext("Paragraph", id);
            }
            #endregion

            #region "comments"
            // extract comment (if applicable)
            if(xmlUnit.SelectSingleNode("comment")!=null)
            {
                paragraphUnit.Properties.Comments = CreateComment(xmlUnit.SelectSingleNode("comment").InnerText);
            }
            #endregion

            return paragraphUnit;
        }
        #endregion

        #region "confirmation level"
        private ConfirmationLevel CreateConfirmationLevel(string BilStatus)
        {
            ConfirmationLevel sdlxliffLevel;
            switch (BilStatus)
            {
                case "new":
                    sdlxliffLevel = ConfirmationLevel.Unspecified;
                    break;
                case "fuzzy":
                    sdlxliffLevel = ConfirmationLevel.Draft;
                    break;
                case "exact":
                    sdlxliffLevel = ConfirmationLevel.Translated;
                    break;
                default:
                    sdlxliffLevel = ConfirmationLevel.Unspecified;
                    break;
            }

            return sdlxliffLevel;
        }
        #endregion

        #region "create segment"
        // helper function for creating segment objects
        private ISegment CreateSegment(XmlNode segNode, ISegmentPairProperties pair)
        {
            ISegment segment = ItemFactory.CreateSegment(pair);

            foreach (XmlNode item in segNode.ChildNodes)
            {
                if (item.NodeType == XmlNodeType.Text)
                {
                    segment.Add(CreateText(item.InnerText));
                }

                if (item.NodeType == XmlNodeType.Element)
                {
                    segment.Add(CreateTagPair(item));
                }
            }
            return segment;
        }
        #endregion

        #region "create text"
        private IText CreateText(string segText)
        {
            ITextProperties textProperties = PropertiesFactory.CreateTextProperties(segText);
            IText textContent = ItemFactory.CreateText(textProperties);

            return textContent;
        }
        #endregion

        #region "process context"
        private IContextProperties CreateContext(string spec, string unitID)
        {
            // context info for type information, e.g. heading, paragraph, etc.
            IContextProperties contextProperties = PropertiesFactory.CreateContextProperties();
            IContextInfo contextInfo = PropertiesFactory.CreateContextInfo(StandardContextTypes.Paragraph);
            contextInfo.Purpose = ContextPurpose.Information;

            // add unit id as metadata
            IContextInfo contextId = PropertiesFactory.CreateContextInfo("UnitId");
            contextId.SetMetaData("UnitID", unitID);

            switch (spec)
            {
                case "Heading":
                    contextInfo = PropertiesFactory.CreateContextInfo(StandardContextTypes.Topic);
                    contextInfo.DisplayColor = Color.Green;
                    break;
                case "Box":
                    contextInfo = PropertiesFactory.CreateContextInfo(StandardContextTypes.TextBox);
                    contextInfo.DisplayColor = Color.Gold;
                    break;
                case "Paragraph":
                    contextInfo = PropertiesFactory.CreateContextInfo(StandardContextTypes.Paragraph);
                    contextInfo.DisplayColor = Color.Silver;
                    break;
                default:
                    break;
            }

            contextProperties.Contexts.Add(contextInfo);
            contextProperties.Contexts.Add(contextId);

            return contextProperties;
        }
        #endregion

        #region "create tagpair"
        private ITagPair CreateTagPair(XmlNode item)
        {
            // create the start and the end tag
            IStartTagProperties startTag = PropertiesFactory.CreateStartTagProperties(item.Name);
            #region "formatting"
            // apply character formatting to the start tag
            IFormattingGroup formattingGroup = PropertiesFactory.FormattingItemFactory.CreateFormatting();
            startTag.Formatting = new FormattingGroup();
            switch (item.Name)
            {
                case "b":
                    formattingGroup.Add(new Bold(true));
                    break;
                case "i":
                    formattingGroup.Add(new Italic(true));
                    break;
                case "u":
                    formattingGroup.Add(new Underline(true));
                    break;
                default:
                    break;
            }
            startTag.Formatting = formattingGroup;
            #endregion

            startTag.DisplayText=item.Name;
            startTag.CanHide = true;
            IEndTagProperties endTag = PropertiesFactory.CreateEndTagProperties(item.Name);
            endTag.DisplayText=item.Name;
            endTag.CanHide = true;

            // create a tag pair out of the start and the end tag
            ITagPair tagPair = ItemFactory.CreateTagPair(startTag, endTag);

            // add text enclosed in the tag pair
            tagPair.Add(CreateText(item.InnerText));

            return tagPair;
        }
        #endregion

        #region "create comment"
        private ICommentProperties CreateComment(string commentText)
        {
            ICommentProperties commentProperties = PropertiesFactory.CreateCommentProperties();
            IComment comment = PropertiesFactory.CreateComment(commentText, "SDK Sample", Severity.Medium);
            commentProperties.Add(comment);

            return commentProperties;
        }
        #endregion

        #region ISettingsAware Members

        public void InitializeSettings(Sdl.Core.Settings.ISettingsBundle settingsBundle, string configurationId)
        {
            //loading of filter settings
        }

        #endregion

        #region IDispose Implementation

        public void Dispose()
        {
            _document = null;
        }

        #endregion
    }
}