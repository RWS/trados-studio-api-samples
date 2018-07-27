namespace Sdl.SDK.LanguagePlatform.Samples.TmAutomation
{
    using System.Windows.Forms;
    using Sdl.Core.Globalization;
    using Sdl.LanguagePlatform.Core;
    using Sdl.LanguagePlatform.TranslationMemory;
    using Sdl.LanguagePlatform.TranslationMemoryApi;

    public class TMUpdater
    {
        #region "add"
        public void AddTu(string tmPath)
        {
            #region "open"
            FileBasedTranslationMemory tm = new FileBasedTranslationMemory(tmPath);

            TranslationUnit tu = new TranslationUnit();
            #endregion

            #region "segments"
            tu.SourceSegment = new Segment(tm.LanguageDirection.SourceLanguage);
            tu.TargetSegment = new Segment(tm.LanguageDirection.TargetLanguage);

            tu.SourceSegment.Add("A dialog box will open.");
            tu.TargetSegment.Add("Es öffnet sich ein Dialogfenster.");
            #endregion

            #region "AddField"
            MultiplePicklistFieldValue value = new MultiplePicklistFieldValue("Customer");
            value.Add("Microsoft");
            tu.FieldValues.Add(value);
            #endregion

            #region "ConfirmationLevel"
            tu.ConfirmationLevel = ConfirmationLevel.ApprovedTranslation;
            #endregion

            #region "format"
            tu.Format = TranslationUnitFormat.SDLTradosStudio2009;
            #endregion

            #region "origin"
            tu.Origin = TranslationUnitOrigin.TM;
            #endregion

            #region "StuctureContext"
            tu.StructureContexts = new string[] { "H" };
            #endregion

            #region "AddTu"
            tm.LanguageDirection.AddTranslationUnit(tu, this.GetImportSettings());
            tm.Save();
            MessageBox.Show("TU has been added successfully.");
            #endregion
        }
        #endregion

        #region "AddExtended"
        public void AddTuExtended(string tmPath)
        {
            #region "OpenExtended"
            FileBasedTranslationMemory tm = new FileBasedTranslationMemory(tmPath);
            TranslationUnit tu = new TranslationUnit();
            #endregion

            #region "SegmentsExtended"
            tu.SourceSegment = new Segment(tm.LanguageDirection.SourceLanguage);
            tu.TargetSegment = new Segment(tm.LanguageDirection.TargetLanguage);
            #endregion

            #region "elements"
            SegmentElement srcElement = this.GetSourceElement();
            SegmentElement trgElement = this.GetTargetElement();
            tu.SourceSegment.Add(srcElement);
            tu.TargetSegment.Add(trgElement);
            #endregion

            #region "AddTuExtended"
            tm.LanguageDirection.AddTranslationUnit(tu, this.GetImportSettings());
            tm.Save();
            MessageBox.Show("TU has been added successfully.");
            #endregion
        }
        #endregion

        #region "CreateSourceElement"
        private SegmentElement GetSourceElement()
        {
            SegmentElement element = null;

            return element;
        }
        #endregion

        #region "CreateTargetElement"
        private SegmentElement GetTargetElement()
        {
            SegmentElement element = null;

            return element;
        }
        #endregion

        #region "ImportSettings"
        private ImportSettings GetImportSettings()
        {
            ImportSettings settings = new ImportSettings();
            settings.CheckMatchingSublanguages = true;
            settings.ExistingFieldsUpdateMode = ImportSettings.FieldUpdateMode.Merge;

            return settings;
        }
        #endregion

        #region "edit"
        public void EditTu(string tmPath)
        {
            FileBasedTranslationMemory tm = new FileBasedTranslationMemory(tmPath);

            SearchResults results = tm.LanguageDirection.SearchText(this.GetSearchSettings(), "A dialog box will open.");
            foreach (SearchResult item in results)
            {
                if (item.ScoringResult.Match == 100)
                {
                    item.MemoryTranslationUnit.TargetSegment.Clear();
                    item.MemoryTranslationUnit.TargetSegment.Add("Ein Dialogfeld wird geöffnet.");
                    item.MemoryTranslationUnit.SystemFields.UseCount++;
                    break;
                }
            }

            tm.Save();
        }
        #endregion

        #region "SearchSettings"
        private SearchSettings GetSearchSettings()
        {
            SearchSettings settings = new SearchSettings();
            settings.MinScore = 100;
            return settings;
        }
        #endregion

        public void DeleteTu(string tmPath)
        {
            #region "delete"
            FileBasedTranslationMemory tm = new FileBasedTranslationMemory(tmPath);

            SearchResults results = tm.LanguageDirection.SearchText(this.GetSearchSettings(), "A dialog box will open.");
            foreach (SearchResult item in results)
            {
                if (item.ScoringResult.Match == 100)
                {
                    PersistentObjectToken tuId = item.MemoryTranslationUnit.ResourceId;
                    tm.LanguageDirection.DeleteTranslationUnit(tuId);
                    break;
                }
            }
            #endregion

            #region "DeleteAll"
            tm.LanguageDirection.DeleteAllTranslationUnits();
            #endregion
        }
    }
}
