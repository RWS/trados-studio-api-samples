namespace Sdl.SDK.LanguagePlatform.Samples.TmAutomation
{
    using System.Globalization;
    using Sdl.LanguagePlatform.Core;
    using Sdl.LanguagePlatform.TranslationMemoryApi;

    public class TMLanguageResource
    {
        public void AddResource(string tmPath)
        {
            #region "open"
            FileBasedTranslationMemory tm = new FileBasedTranslationMemory(tmPath);
            #endregion

            #region "default"
            DefaultLanguageResourceProvider defaultBundle = new DefaultLanguageResourceProvider();
            #endregion

            #region "newBundle"
            LanguageResourceBundle newBundle = defaultBundle.GetDefaultLanguageResources(CultureInfo.GetCultureInfo("en-US"));
            #endregion

            #region "abbreviations"
            newBundle.Abbreviations = new Wordlist();
            newBundle.Abbreviations.Add("hr.");
            newBundle.Abbreviations.Add("cont.");
            #endregion

            #region "variables"
            newBundle.Variables = new Wordlist();
            newBundle.Variables.Add("Mac OSX");
            newBundle.Variables.Add("Microsoft Windows 7");
            newBundle.Variables.Add("Suse Linux");

            tm.LanguageResourceBundles.Add(newBundle);
            tm.Save();
            #endregion
        }
    }
}
