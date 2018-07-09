using Sdl.Core.Settings;
using Sdl.FileTypeSupport.Framework.BilingualApi;
using Sdl.FileTypeSupport.Framework.IntegrationApi;
using Sdl.FileTypeSupport.Framework.NativeApi;
using System;


namespace Sdl.Sdk.FileTypeSupport.Samples.WordArtVerifier
{
    class VerifierMain : IBilingualVerifier, ISettingsAware
    {
        /// <summary>
        /// These properties provide access to the two plug-in settings.
        /// </summary>
        #region UI settings representation        

        public bool CheckWordArt
        {
            get;
            set;
        }

        public int MaxWordCount
        {
            get;
            set;
        }
        #endregion

        /// <summary>
        /// Initializes the plug-in settings, so that they can be used during the actual verification.
        /// </summary>
        /// <param name="settingsBundle"></param>
        /// <param name="configurationId"></param>
        #region "InitializeSettings"       
        public void InitializeSettings(ISettingsBundle settingsBundle, string configurationId)
        {
            VerifierSettings _settings = new VerifierSettings();
            _settings.PopulateFromSettingsBundle(settingsBundle, "Word 2007 v 2.0.0.0 WordArt Verifier");
            CheckWordArt = _settings.CheckWordArt;
            MaxWordCount = _settings.MaxWordCount;
        }
        #endregion

        #region "IBilingualFilterComponent Members"
        /// <summary>
        /// Provides access to the message reporter, which is responsible for 
        /// outputting any messages in the user interface of SDL Trados Studio
        /// /// </summary>
        #region "messagereporter"
        public IBilingualContentMessageReporter MessageReporter
        {
            get;
            set;
        }
        #endregion

        /// <summary>
        /// Not required in this implementation. Provides access to elements
        /// such as tags, placeholders, etc.
        /// </summary>
        #region "itemfactory"
        public IDocumentItemFactory ItemFactory
        {
            get;
            set;
        }
        #endregion
        #endregion


        #region "IBilingualContentHandler Members"
        /// <summary>
        /// These members of the IBilingualContentHandler interface are not used in this
        /// implementation.
        /// </summary>
        public void Complete()
        {
            // Controls what happens when the whole verification process is complete.
        }

        public void FileComplete()
        {
            // Controls what happens when the whole verification process for one single file is complete.
        }

        public void SetFileProperties(IFileProperties fileInfo)
        {
            // A bilingual document can potentially be a master document that contains
            // a number of single (smaller) bilingual documents.
            // The File Info object can be used to access properties of particular bilingual file 
            // in a bilingual document, such as the file type definition id, the creation tool.
            // This information can be different from biligual file to bilingual file, as
            // each single bilingual file might have been created using different
            // file types, e.g. one bilingual file was derived from a PPT document,
            // another one from a DOC file.
            // This is not required for this implementation.

        }
        #endregion

        #region "InitializeMethod"
        public void Initialize(IDocumentProperties documentInfo)
        {
            // Through the document properties you can access information that is
            // common to ALL bilingual files in a master bilingual document, e.g. the
            // source/target language, the repetition/source count, etc.
            // This is not required for this implementation.
        }
        #endregion

        /// <summary>
        /// This method implements the actual verification logic.
        /// If CheckWordArt is true, the method loops through all segment pairs, and 
        /// determines whether they have any context information. If true, and if 
        /// the display code equals 'WA' (WordArt), a separate helper function is called
        /// to check the word count.
        /// </summary>
        /// <param name="paragraphUnit"></param>
        #region process paragraph unit
        public void ProcessParagraphUnit(IParagraphUnit paragraphUnit)
        {
            if (!CheckWordArt)
            {
                return;
            }

            foreach (ISegmentPair segmentPair in paragraphUnit.SegmentPairs)
            {
                // Four conditions have to be met before the word count check is done:
                // 1. The current segment needs to have context information (i.e. context count > 0)
                // 2. The display code of the first context information unit is 'TAG'
                // 3. The context description contains the string 'wordart'
                // 4. The target segment is not empty
                if (paragraphUnit.Properties.Contexts.Contexts.Count > 0 &&
                    paragraphUnit.Properties.Contexts.Contexts[0].DisplayCode == "TAG" &&
                    paragraphUnit.Properties.Contexts.Contexts[0].Description.Contains("wordart") &&
                    segmentPair.Target.ToString() != "")
                {
                    {
                        CheckWordCount(segmentPair.Target);
                    }
                }
            }
        }
        #endregion

        /// <summary>
        /// Helper function that counts the words in the current target segment.
        /// If the word count (i.e. number of spaces + 1) exceeds the maximum count
        /// that was set through the properties, a message should be added to the 
        /// Messages window of SDL Trados Studio.
        /// </summary>
        /// <param name="targetSegment"></param>
		#region output message
        private void CheckWordCount(ISegment targetSegment)
        {
            int pos = 0, count = 0;
            char c = ' ';

            while ((pos = targetSegment.ToString().IndexOf(c, pos)) != -1)
            {
                count++;
                pos++;
            }
            count++;

            if (count > MaxWordCount)
            {
                MessageReporter.ReportMessage(this, Resources.Plugin_Name, ErrorLevel.Warning,
                    String.Format(Resources.MsgWordCountExceeded, count, MaxWordCount),
                    new TextLocation(new Location(targetSegment, true), 0),
                    new TextLocation(new Location(targetSegment, false), targetSegment.ToString().Length - 1));
            }
        }
        #endregion
    }
}
