// ---------------------------------
// <copyright file="TMImporter.cs" company="SDL International">
// Copyright  2010 All Right Reserved
// </copyright>
// <author>Patrik Mazanek</author>
// <email>pmazanek@sdl.com</email>
// <date>2010-09-27</date>
// ---------------------------------
namespace Sdl.SDK.LanguagePlatform.Samples.BatchImporter
{
    using System;
    using System.Xml;
    using Sdl.LanguagePlatform.TranslationMemory;
    using Sdl.LanguagePlatform.TranslationMemoryApi;

    /// <summary>
    /// Represents functionality for emporting *.tmx files into translation memory.
    /// </summary>
    public class TMImporter
    {
        #region "ImportTmx"

        /// <summary>
        /// This function performs the actual TMX import into the appropriate master TM.
        /// </summary>
        /// <param name="tmxPath">Path to *.tmx file.</param>
        public void Import(string tmxPath)
        {
            #region "CreatePath"
            // Create the path in which the master TMs should be
            // stored (if the path does not exist yet).
            string masterPath = @"c:\MasterTMs\";
            if (!System.IO.Directory.Exists(masterPath))
            {
                System.IO.Directory.CreateDirectory(masterPath);
            }
            #endregion

            #region "GetLanguageDirection"
            // Retrieve the language direction of the current TM
            // by reading the appropriate lang values from the first
            // tu element.
            string srcLang = string.Empty;
            string trgLang = string.Empty;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(tmxPath);

            try
            {
                XmlNode tu = xmlDoc.SelectNodes("tmx/body/tu")[0];
                srcLang = tu.SelectNodes("tuv")[0].Attributes[0].Value;
                trgLang = tu.SelectNodes("tuv")[1].Attributes[0].Value;
            }
            catch
            {
                // TU count is zero, i.e. no TM content to import
                Console.WriteLine(tmxPath + " is empty, no content to import.");
            }
            #endregion

            #region "CheckMasterTmExists"
            // Check whether a master TM with the language direction found in the 
            // current TMX file already exists. If not, then create the TM.
            string translationMemoryPath = string.Format("{0}MasterTM_{1}_{2}.sdltm", masterPath, srcLang, trgLang);
            if (!System.IO.File.Exists(translationMemoryPath))
            {
                TMCreator create = new TMCreator();
                create.CreateMasterTm(srcLang, trgLang, masterPath);
            }
            #endregion

            #region "DoImport"
            // Open the appropriate master TM and do the import.
            FileBasedTranslationMemory tm = new FileBasedTranslationMemory(translationMemoryPath);
            TranslationMemoryImporter importer = new TranslationMemoryImporter(tm.LanguageDirection);
            this.GetImportSettings(importer.ImportSettings);
            importer.Import(tmxPath);
            #endregion
        }
        #endregion

        #region "settings"

        /// <summary>
        ///  Configure the import settings.
        /// </summary>
        /// <param name="importSettings">Group of settings that control way of import.</param>
        private void GetImportSettings(ImportSettings importSettings)
        {
            importSettings.CheckMatchingSublanguages = true;
            importSettings.ExistingFieldsUpdateMode = ImportSettings.FieldUpdateMode.Merge;
            importSettings.ExistingTUsUpdateMode = ImportSettings.TUUpdateMode.Overwrite;
        }
        #endregion
    }
}
