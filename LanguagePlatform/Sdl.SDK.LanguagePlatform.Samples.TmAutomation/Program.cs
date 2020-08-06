// ---------------------------------
// <copyright file="Program.cs" company="SDL International">
// Copyright  2020 All Right Reserved
// </copyright>
// <author>Patrik Mazanek</author>
// <email>pmazanek@sdl.com</email>
// <date>2010-09-27</date>
// ---------------------------------
using Sdl.LanguagePlatform.TranslationMemory;
using Sdl.LanguagePlatform.TranslationMemoryApi;

namespace Sdl.SDK.LanguagePlatform.Samples.TmAutomation
{
    /// <summary>
    /// Main entrance point to the application.
    /// </summary>
    public class Program
    {
        #region main
        /// <summary>
        /// Main entrance point to the application.
        /// </summary>
        /// <param name="args">String arguments passed as console parameters.</param>
        public static void Main(string[] args)
        {
            const string _translationMemoryFilePath = @"c:\temp\sample.sdltm";
            const string _importFilePath = @"c:\temp\sample.tmx";
            const string _exportFilePath = @"c:\temp\TmExport.tmx";

            #region "Create TM"
            TMCreator objCreate = new TMCreator();
            objCreate.CreateFileBasedTM(_translationMemoryFilePath);
            #endregion

            #region "fields"
            TMFieldGenerator objFieldGenerator = new TMFieldGenerator();
            objFieldGenerator.AddFields(_translationMemoryFilePath);
            #endregion

            #region "LanguageResource"
            TMLanguageResource objResource = new TMLanguageResource();
            objResource.AddResource(_translationMemoryFilePath);
            #endregion

            #region "getinfo"
            TMProperties objProps = new TMProperties();
            objProps.GetAndSetProperties(_translationMemoryFilePath);
            #endregion

            #region "import"
            TMImporter objTmImport = new TMImporter();
            objTmImport.ImportTMXFile(_translationMemoryFilePath, _importFilePath);
            #endregion

            #region "export"
            TMExporter objTmExport = new TMExporter();
            objTmExport.ExportTMXFile(_translationMemoryFilePath, _exportFilePath);
            objTmExport.RunFilteredExport(_translationMemoryFilePath, _exportFilePath);
            #endregion

            #region "passwords"
            TMProtector objProtect = new TMProtector();
            objProtect.AssignPasswords(_translationMemoryFilePath);
            #endregion

            #region "lookup"
            TMLookup search = new TMLookup();
            search.SearchForText(_translationMemoryFilePath, "To run the Spelling Checker:", SearchMode.NormalSearch);
            #endregion

            #region "tuning"
            TMTuner tuning = new TMTuner();
            tuning.TuneTm(_translationMemoryFilePath);
            #endregion

            #region "update"
            TMUpdater update = new TMUpdater();
            update.AddTu(_translationMemoryFilePath);
            update.AddTuExtended(_translationMemoryFilePath);
            update.EditTu(_translationMemoryFilePath);
            update.DeleteTu(_translationMemoryFilePath);
            #endregion

            #region "iterator"
            TMIterator it = new TMIterator();
            it.Iterate(_translationMemoryFilePath);
            #endregion

            #region "connect"
            ServerConnector objConnect = new ServerConnector();
            TranslationProviderServer tmServer = objConnect.Connect();
            objConnect.Test(tmServer);
            #endregion
        }
        #endregion
    }
}
