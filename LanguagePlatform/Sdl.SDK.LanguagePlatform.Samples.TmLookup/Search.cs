using Sdl.LanguagePlatform.TranslationMemory;

namespace Sdl.SDK.LanguagePlatform.Samples.TmLookup
{
    class Search
    {
        #region "search"
        /// <summary>
        /// This function performs the actual concordance search operation.
        /// </summary>
        public string DoConcordanceSearch(string searchText, bool target, int langDirIndex)
        {
            #region "execute"
            /// Do the search in either a file- or server-based TM.
            SearchResults results;
            if (Connector.Server)
            {
                results = Connector.ServerTM.LanguageDirections[langDirIndex].SearchText(GetSearchSettings(target), searchText);
            }
            else
            {
                results = Connector.FileTm.LanguageDirection.SearchText(GetSearchSettings(target), searchText);
            }
            #endregion

            #region "StartHitlist"
            /// Build up the string that holds the hit list result.
            string hitlist = "Hit count: " + results.Count.ToString() + "\n\n";
            #endregion

            #region "result"
            foreach (SearchResult result in results)
            {
                hitlist += GetTuInformation(result);
            }
            #endregion

            #region "CloseHitlist"
            return hitlist;
            #endregion
        }
        #endregion

        #region "TuInfo"
        /// <summary>
        /// This function returns further information on the given translation unit (TU).
        /// </summary>
        private string GetTuInformation(SearchResult tuResult)
        {
            string tuInfo;

            #region "score"
            /// The matching score
            tuInfo = "\nScore: " + tuResult.ScoringResult.Match.ToString() + "%\n";
            #endregion

            #region "segments"
            /// The source and target segments
            tuInfo += "Source: " + tuResult.MemoryTranslationUnit.SourceSegment.ToPlain() + "\n";
            tuInfo += "Target: " + tuResult.MemoryTranslationUnit.TargetSegment.ToPlain() + "\n";
            #endregion

            #region "date"
            /// The TU creation date.
            tuInfo += "Creation date: " + tuResult.MemoryTranslationUnit.SystemFields.CreationDate + "\n";
            #endregion

            #region "fields"
            /// Any field values (e.g. Customer, Project id, etc. associated with the
            /// given TU.
            foreach (FieldValue field in tuResult.MemoryTranslationUnit.FieldValues)
            {
                tuInfo += field.Name + ": " + field.ToString();
            }
            tuInfo += "\n";
            #endregion

            return tuInfo;
        }
        #endregion

        #region "settings"
        /// <summary>
        /// Configure the settings that should be applied for the search, i.e.
        /// minimum match value, maximum hit count, and whether the concordance
        /// search should be done in the source or in the target language.
        /// </summary>
        private SearchSettings GetSearchSettings(bool target)
        {
            SearchSettings settings = new SearchSettings();

            settings.MaxResults = frmSettings.MaxHits;
            settings.MinScore = frmSettings.MinFuzzy;

            if (target)
                settings.Mode = SearchMode.TargetConcordanceSearch;
            else
                settings.Mode = SearchMode.ConcordanceSearch;

            return settings;
        }
        #endregion
    }
}
