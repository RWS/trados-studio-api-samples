using Sdl.LanguagePlatform.TranslationMemoryApi;
using System;

namespace Sdl.Sdk.LanguagePlatform.Samples.ListProvider
{
    /// <summary>
    /// This class is used to hold the provider plug-in settings. 
    /// All settings are automatically stored in a URI.
    /// </summary>
    public class ListTranslationOptions
    {
        #region "TranslationMethod"
        public static readonly TranslationMethod ProviderTranslationMethod = TranslationMethod.Other;
        #endregion

        #region "TranslationProviderUriBuilder"
        TranslationProviderUriBuilder _uriBuilder;

        public ListTranslationOptions()
        {
            _uriBuilder = new TranslationProviderUriBuilder(ListTranslationProvider.ListTranslationProviderScheme);
        }

        public ListTranslationOptions(Uri uri)
        {
            _uriBuilder = new TranslationProviderUriBuilder(uri);
        }
        #endregion

        /// <summary>
        /// Set and retrieve the name and path of the delimited list file.
        /// </summary>
        #region "ListFileName"
        public string ListFileName
        {
            get { return GetStringParameter("listfile"); }
            set { SetStringParameter("listfile", value); }
        }
        #endregion

        /// <summary>
        /// Set and retrieve the delimiter character.
        /// </summary>
        #region "Delimiter"
        public string Delimiter
        {
            get { return GetStringParameter("delimiter"); }
            set { SetStringParameter("delimiter", value); }
        }
        #endregion

        #region "SetStringParameter"
        private void SetStringParameter(string p, string value)
        {
            _uriBuilder[p] = value;
        }
        #endregion

        #region "GetStringParameter"
        private string GetStringParameter(string p)
        {
            string paramString = _uriBuilder[p];
            return paramString;
        }
        #endregion


        #region "Uri"
        public Uri Uri
        {
            get
            {
                return _uriBuilder.Uri;
            }
        }
        #endregion
    }
}
