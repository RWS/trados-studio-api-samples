using Sdl.Core.Globalization;
using Sdl.LanguagePlatform.Core;
using Sdl.LanguagePlatform.TranslationMemory;
using Sdl.LanguagePlatform.TranslationMemoryApi;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Sdl.Sdk.LanguagePlatform.Samples.ListProvider
{
    public class ListTranslationProviderLanguageDirection : ITranslationProviderLanguageDirection
    {
        #region "PrivateMembers"
        private ListTranslationProvider _provider;
        private LanguagePair _languageDirection;
        private ListTranslationOptions _options;
        private ListTranslationProviderElementVisitor _visitor;
        private Dictionary<string, string> _listOfTranslations;
        #endregion

        #region "ITranslationProviderLanguageDirection Members"

        /// <summary>
        /// Instantiates the variables and fills the list file content into
        /// a Dictionary collection object.
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="languages"></param>
        #region "ListTranslationProviderLanguageDirection"
        public ListTranslationProviderLanguageDirection(ListTranslationProvider provider, LanguagePair languages)
        {
            #region "Instantiate"
            _provider = provider;
            _languageDirection = languages;
            _options = _provider.Options;
            _visitor = new ListTranslationProviderElementVisitor(_options);
            _listOfTranslations = new Dictionary<string, string>();
            #endregion

            #region "CompileCollection"
            // Load the content of the specified list file and fill it
            // into the multiple identical sources are not allowed
            using (StreamReader sourceFile = new StreamReader(_options.ListFileName))
            {
                sourceFile.ReadLine(); // Skip the first line as it contains the language direction.

                char fileDelimiter = Convert.ToChar(_options.Delimiter);
                while (!sourceFile.EndOfStream)
                {
                    string[] currentPair = sourceFile.ReadLine().Split(fileDelimiter);
                    if (currentPair.Count<string>() != 2)
                    {
                        // The current line does not contain a proper source/target segment pair.
                        continue;
                    }

                    // Add the source/target segment pair to the collection
                    // after checking that the current source segment does not
                    // already exist in the Dictionary.
                    if (!_listOfTranslations.ContainsKey(currentPair[0]))
                    {
                        _listOfTranslations.Add(currentPair[0], currentPair[1]);
                    }
                }
                sourceFile.Close();
            }
            #endregion
        }

        #endregion

        public System.Globalization.CultureInfo SourceLanguage
        {
            get { return _languageDirection.SourceCulture; }
        }

        public System.Globalization.CultureInfo TargetLanguage
        {
            get { return _languageDirection.TargetCulture; }
        }

        public ITranslationProvider TranslationProvider
        {
            get { return _provider; }
        }

        /// <summary>
        /// Performs the actual search by looping through the
        /// delimited segment pairs contained in the text file.
        /// Depending on the search mode, a segment lookup (with exact matching) or a source / target
        /// concordance search is done.
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="segment"></param>
        /// <returns></returns>
        #region "SearchSegment"
        public SearchResults SearchSegment(SearchSettings settings, Segment segment)
        {
            // Loop through segment elements to 'filter out' e.g. tags in order to 
            // make certain that only plain text information is retrieved for
            // this simplified implementation.            
            #region "SegmentElements"
            _visitor.Reset();
            foreach (var element in segment.Elements)
            {
                element.AcceptSegmentElementVisitor(_visitor);
            }
            #endregion

            #region "SearchResultsObject"
            SearchResults results = new SearchResults();
            results.SourceSegment = segment.Duplicate();
            #endregion


            // Look up the currently selected segment in the collection (normal segment lookup).
            #region "SegmentLookup"
            if (settings.Mode == SearchMode.NormalSearch &&
                _listOfTranslations.ContainsKey(_visitor.PlainText))
            {
                Segment translation = new Segment(_languageDirection.TargetCulture);
                translation.Add(_listOfTranslations[_visitor.PlainText]);
                results.Add(CreateSearchResult(segment, translation, _visitor.PlainText, segment.HasTags));
            }
            #endregion

            // Source concordance search
            // In this implementation the concordance search should be case-insensitive,
            // therefore ToLower() is applied.
            #region "SourceConcordanceSearch"
            if (settings.Mode == SearchMode.ConcordanceSearch)
            {
                foreach (var item in _listOfTranslations.Keys)
                {
                    if (item.ToLower().Contains(_visitor.PlainText.ToLower()))
                    {
                        Segment translation = new Segment(_languageDirection.TargetCulture);
                        translation.Add(_listOfTranslations[item]);
                        results.Add(CreateSearchResult(segment, translation, item, false));
                    }
                }
            }
            #endregion

            // Target concordance search
            // In this implementation the concordance search should be case-insensitive,
            // therefore ToLower() is applied.
            #region "TargetConcordanceSearch"
            if (settings.Mode == SearchMode.TargetConcordanceSearch)
            {
                foreach (var item in _listOfTranslations.Keys)
                {
                    if (_listOfTranslations[item].ToLower().Contains(_visitor.PlainText.ToLower()))
                    {
                        Segment translation = new Segment(_languageDirection.TargetCulture);
                        translation.Add(_listOfTranslations[item]);
                        results.Add(CreateSearchResult(segment, translation, item, false));
                    }
                }
            }
            #endregion

            #region "Close"
            return results;
            #endregion
        }
        #endregion


        /// <summary>
        /// Creates the translation unit as it is later shown in the Translation Results
        /// window of SDL Trados Studio. This member also determines the match score
        /// (in our implementation always 100%, as only exact matches are supported)
        /// as well as the confirmation level, i.e. Translated.
        /// </summary>
        /// <param name="searchSegment"></param>
        /// <param name="translation"></param>
        /// <param name="sourceSegment"></param>
        /// <returns></returns>
        #region "CreateSearchResult"
        private SearchResult CreateSearchResult(Segment searchSegment, Segment translation,
            string sourceSegment, bool formattingPenalty)
        {
            #region "TranslationUnit"
            TranslationUnit tu = new TranslationUnit();
            Segment orgSegment = new Segment();
            orgSegment.Add(sourceSegment);
            tu.SourceSegment = orgSegment;
            tu.TargetSegment = translation;
            #endregion

            tu.ResourceId = new PersistentObjectToken(tu.GetHashCode(), Guid.Empty);

            #region "TuProperties"
            int score = 100;
            tu.Origin = TranslationUnitOrigin.TM;


            SearchResult searchResult = new SearchResult(tu);
            searchResult.ScoringResult = new ScoringResult();
            searchResult.ScoringResult.BaseScore = score;

            if (formattingPenalty)
            {
                #region "Draft"
                tu.ConfirmationLevel = ConfirmationLevel.Draft;
                #endregion

                #region "FormattingPenalty"
                Penalty penalty = new Penalty(PenaltyType.TagMismatch, 1);
                searchResult.ScoringResult.ApplyPenalty(penalty);
                #endregion
            }
            else
            {
                tu.ConfirmationLevel = ConfirmationLevel.Translated;
            }
            #endregion

            return searchResult;
        }
        #endregion


        public bool CanReverseLanguageDirection
        {
            get { return false; }
        }

        public SearchResults[] SearchSegments(SearchSettings settings, Segment[] segments)
        {
            SearchResults[] results = new SearchResults[segments.Length];
            for (int p = 0; p < segments.Length; ++p)
            {
                results[p] = SearchSegment(settings, segments[p]);
            }
            return results;
        }

        public SearchResults[] SearchSegmentsMasked(SearchSettings settings, Segment[] segments, bool[] mask)
        {
            if (segments == null)
            {
                throw new ArgumentNullException("segments in SearchSegmentsMasked");
            }
            if (mask == null || mask.Length != segments.Length)
            {
                throw new ArgumentException("mask in SearchSegmentsMasked");
            }

            SearchResults[] results = new SearchResults[segments.Length];
            for (int p = 0; p < segments.Length; ++p)
            {
                if (mask[p])
                {
                    results[p] = SearchSegment(settings, segments[p]);
                }
                else
                {
                    results[p] = null;
                }
            }

            return results;
        }

        public SearchResults SearchText(SearchSettings settings, string segment)
        {
            Segment s = new Sdl.LanguagePlatform.Core.Segment(_languageDirection.SourceCulture);
            s.Add(segment);
            return SearchSegment(settings, s);
        }

        public SearchResults SearchTranslationUnit(SearchSettings settings, TranslationUnit translationUnit)
        {
            return SearchSegment(settings, translationUnit.SourceSegment);
        }

        public SearchResults[] SearchTranslationUnits(SearchSettings settings, TranslationUnit[] translationUnits)
        {
            SearchResults[] results = new SearchResults[translationUnits.Length];
            for (int p = 0; p < translationUnits.Length; ++p)
            {
                results[p] = SearchSegment(settings, translationUnits[p].SourceSegment);
            }
            return results;
        }

        public SearchResults[] SearchTranslationUnitsMasked(SearchSettings settings, TranslationUnit[] translationUnits, bool[] mask)
        {
            List<SearchResults> results = new List<SearchResults>();

            int i = 0;
            foreach (var tu in translationUnits)
            {
                if (mask == null || mask[i])
                {
                    var result = SearchTranslationUnit(settings, tu);
                    results.Add(result);
                }
                else
                {
                    results.Add(null);
                }
                i++;
            }

            return results.ToArray();
        }



        #region "NotForThisImplementation"
        /// <summary>
        /// Not required for this implementation.
        /// </summary>
        /// <param name="translationUnits"></param>
        /// <param name="settings"></param>
        /// <param name="mask"></param>
        /// <returns></returns>
        public ImportResult[] AddTranslationUnitsMasked(TranslationUnit[] translationUnits, ImportSettings settings, bool[] mask)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not required for this implementation.
        /// </summary>
        /// <param name="translationUnit"></param>
        /// <returns></returns>
        public ImportResult UpdateTranslationUnit(TranslationUnit translationUnit)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not required for this implementation.
        /// </summary>
        /// <param name="translationUnits"></param>
        /// <returns></returns>
        public ImportResult[] UpdateTranslationUnits(TranslationUnit[] translationUnits)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Not required for this implementation.
        /// </summary>
        /// <param name="translationUnits"></param>
        /// <param name="previousTranslationHashes"></param>
        /// <param name="settings"></param>
        /// <param name="mask"></param>
        /// <returns></returns>
        public ImportResult[] AddOrUpdateTranslationUnitsMasked(TranslationUnit[] translationUnits, int[] previousTranslationHashes, ImportSettings settings, bool[] mask)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not required for this implementation.
        /// </summary>
        /// <param name="translationUnit"></param>
        /// <param name="settings"></param>
        /// <returns></returns>
        public ImportResult AddTranslationUnit(TranslationUnit translationUnit, ImportSettings settings)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not required for this implementation.
        /// </summary>
        /// <param name="translationUnits"></param>
        /// <param name="settings"></param>
        /// <returns></returns>
        public ImportResult[] AddTranslationUnits(TranslationUnit[] translationUnits, ImportSettings settings)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not required for this implementation.
        /// </summary>
        /// <param name="translationUnits"></param>
        /// <param name="previousTranslationHashes"></param>
        /// <param name="settings"></param>
        /// <returns></returns>
        public ImportResult[] AddOrUpdateTranslationUnits(TranslationUnit[] translationUnits, int[] previousTranslationHashes, ImportSettings settings)
        {
            throw new NotImplementedException();
        }
        #endregion

        #endregion
    }
}
