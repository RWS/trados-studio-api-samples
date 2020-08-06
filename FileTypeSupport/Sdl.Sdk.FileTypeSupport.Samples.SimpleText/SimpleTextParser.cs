using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using Sdl.FileTypeSupport.Framework.BilingualApi;
using Sdl.FileTypeSupport.Framework.Core.Utilities.Formatting;
using Sdl.FileTypeSupport.Framework.Formatting;
using Sdl.FileTypeSupport.Framework.IntegrationApi;
using Sdl.FileTypeSupport.Framework.NativeApi;

namespace Sdl.Sdk.FileTypeSupport.Samples.SimpleText
{
    public class SimpleTextParser : AbstractNativeFileParser, INativeContentCycleAware, ISettingsAware
    {
        #region "global settings"
        IPersistentFileConversionProperties _fileConversionProperties;
        StreamReader _reader = null;

        FormattingGroup _fBold;
        #endregion

        #region "INativeContentCycleAware members"
        // through the properties object you can retrieve important information
        // on the native input file such as the original file name and path
        public void SetFileProperties(IFileProperties properties)
        {
            _fileConversionProperties = properties.FileConversionProperties;
        }

        public void StartOfInput()
        {
        }
        
        public void EndOfInput()
        {
        }
        #endregion

        #region "members of AbstractNativeFileParser"

        #region "before parsing"
        protected override void BeforeParsing()
        {
            // set progress reporter to the beginning
            OnProgress(0);

            // open the native input file for reading
            _reader = new StreamReader(_fileConversionProperties.OriginalFilePath);
        }
        #endregion

        #region "during parsing"
        protected override bool DuringParsing()
        {
            // iterate through all lines in the input file
            while (!_reader.EndOfStream)
            {
                ProcessLine(_reader.ReadLine());
            }
            return false;
        }
        #endregion

        #region "after parsing"
        protected override void AfterParsing()
        {
            //close original file
            _reader.Close();
            _reader.Dispose();
            _reader = null;
            //set progres report to 100%
            OnProgress(100);
        }
        #endregion

        #endregion

        #region "process line"
        // determines whether a given line is
        // translatable or not
        // if not, a structure tag is output
        // otherwise, the translatable text is exposed
        private void ProcessLine(string sLine)
        {
            if (sLine.StartsWith("[") && sLine.EndsWith("]"))
            {
                WriteStructureTag(sLine);
                WriteContext(sLine);
            }
            else if (sLine.StartsWith("Prd-Code") && LockPrdCodes==true)
            {
                WriteLockedContent(sLine);

            } 
            else
            {
                WriteText(ProcessFormatting(sLine));
            }
        }
        #endregion

        #region "text"
        // output translatable text
        private void WriteText(string TextContent)
        {
            ITextProperties textProperties = PropertiesFactory.CreateTextProperties(TextContent);
            Output.Text(textProperties);
        }
        #endregion

        #region "lock"
        // protect text from being altered during translation 
        // by locking it
        private void WriteLockedContent(string LockedContent)
        {
            //create opening tag for locked content
            ILockedContentProperties Lockedprops = PropertiesFactory.CreateLockedContentProperties(LockTypeFlags.Manual);
            Output.LockedContentStart(Lockedprops);

            //create text inside of locked content
            ITextProperties textProps = PropertiesFactory.CreateTextProperties(LockedContent);
            Output.Text(textProps);

            //close locked content
            Output.LockedContentEnd();
        }
        #endregion

        #region "structure"
        // output non-translatable text as structure tag
        private void WriteStructureTag(string TagContent)
        {
            IStructureTagProperties structureTagProperties = PropertiesFactory.CreateStructureTagProperties(TagContent);
            structureTagProperties.DisplayText = TagContent;
            Output.StructureTag(structureTagProperties);
        }
        #endregion

        #region "context"
        // output context information, not required, but useful
        // information for the translator
        private void WriteContext(string ContextContent)
        {
            IContextProperties contextProperties = PropertiesFactory.CreateContextProperties();
            IContextInfo contextInfo = PropertiesFactory.CreateContextInfo(ContextContent);
            contextInfo.DisplayCode = "EL";
            contextInfo.DisplayName = "Element";
            contextInfo.Description = ContextContent;
            contextInfo.DisplayColor = Color.Beige;
            contextProperties.Contexts.Add(contextInfo);
            Output.ChangeContext(contextProperties);
        }
        #endregion

        #region "process formatting"
        // this function uses regular expressions to identify
        // what is 'normal' translatable content and which strings
        // need to be marked up as inline tags, e.g. <b>
        private string ProcessFormatting(string sLine)
        {
            int LastPosition = 0;
            // search for opening and closing <b> tags
            Regex rx = new Regex(@"\<.*?\>", RegexOptions.Compiled);
            MatchCollection rxMatches = rx.Matches(sLine);

            foreach (Match rxMatch in rxMatches)
            {
                if (LastPosition != rxMatch.Index)
                {
                    WriteText(sLine.Substring(LastPosition, rxMatch.Index - LastPosition));
                }

                bool IsOpening = rxMatch.Value.Contains("/") ? false : true;
                WriteInlineTag(rxMatch.Value, IsOpening);  

                LastPosition = rxMatch.Index + rxMatch.Length;
            }
            return sLine.Substring(LastPosition, sLine.Length - LastPosition);
        }
        #endregion

        #region "write inline tag"
        // this function outputs an opening or a closing <b> tag
        // and applies bold character formatting to the strings
        // that the tags enclose
        private void WriteInlineTag(string tagContent, bool isStart)
        {
            _fBold = new FormattingGroup();
            _fBold.Add(new Bold(true));

            if (isStart)
            {
                IStartTagProperties startTag = PropertiesFactory.CreateStartTagProperties(tagContent);
                startTag.DisplayText = "b";
                startTag.TagContent = tagContent;
                startTag.Formatting = _fBold;
                startTag.CanHide = true;
                Output.InlineStartTag(startTag);
            }
            else
            {
                IEndTagProperties endTag = PropertiesFactory.CreateEndTagProperties(tagContent);
                endTag.DisplayText = "b";
                endTag.TagContent = tagContent;
                endTag.CanHide = true;
                Output.InlineEndTag(endTag);
            }
        }
        #endregion

        #region "filter settings"
        public bool LockPrdCodes
        {
            get;
            set;
        }
        #endregion
        
        #region ISettingsAware Members

        #region "InitializeSettings"
        public void InitializeSettings(Sdl.Core.Settings.ISettingsBundle settingsBundle, string configurationId)
        {
            UserSettings _userSettings = new UserSettings();
            _userSettings.PopulateFromSettingsBundle(settingsBundle, configurationId);
            LockPrdCodes = _userSettings.LockPrdCodes;
        }

        #endregion
        #endregion
    }
}
