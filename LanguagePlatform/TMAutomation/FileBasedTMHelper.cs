using Sdl.FileTypeSupport.Framework.Integration;
using Sdl.LanguagePlatform.Core;
using Sdl.LanguagePlatform.Core.Tokenization;
using Sdl.LanguagePlatform.TranslationMemory;
using Sdl.LanguagePlatform.TranslationMemoryApi;
using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using static Sdl.LanguagePlatform.TranslationMemory.ImportSettings;

namespace Sdl.SDK.LanguagePlatform.TMAutomation
{
    class FileBasedTMHelper
    {
        private TextBox _output;

        public FileBasedTMHelper(TextBox tb)
        {
            _output = tb;
        }

        /// <summary>
        /// Open password protected TM.
        /// </summary>
        /// <param name="tmPath"></param>
        public void OpenProtectedTM(string tmPath)
        {
            try
            {
                FileBasedTranslationMemory tm = new FileBasedTranslationMemory(tmPath, "sdksample");
                WriteResult("Protected TM was opened successfully.\r\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Set admin and maintenance password
        /// </summary>
        /// <param name="tmPath"></param>
        public void SetTMPassword(string tmPath)
        {
            FileBasedTranslationMemory tm = new FileBasedTranslationMemory(tmPath);
            tm.SetAdministratorPassword("sdksample");
            tm.SetMaintenancePassword("sdksample");
            tm.Save();
            WriteResult("Admin and maintenance password are set.\r\n");
        }

        /// <summary>
        /// Add and delete TU.
        /// </summary>
        /// <param name="tmPath"></param>
        public void DeleteTU(string tmPath)
        {
            FileBasedTranslationMemory tm = new FileBasedTranslationMemory(tmPath);
            tm.LanguageDirection.AddTranslationUnit(
                GetNewTU("My new TU", "Meine neue TU", tm.LanguageDirection.SourceLanguage, tm.LanguageDirection.TargetLanguage),
                GetImportSettings());
            WriteResult("New TU added.\r\n");

            WriteResult("Started TM iteration...\r\n");

            PersistentObjectToken tuId = IterateTM(tm, "My new TU");
            tm.LanguageDirection.DeleteTranslationUnit(tuId);
            WriteResult("TU found and deleted.\r\n");
        }

        /// <summary>
        /// Iterate whole TM and return id of TU with identical source as tuSourceText
        /// </summary>
        /// <param name="tm"></param>
        /// <param name="tuSourceText"></param>
        /// <returns></returns>
        private PersistentObjectToken IterateTM(FileBasedTranslationMemory tm, string tuSourceText)
        {
            PersistentObjectToken tuID = null;
            RegularIterator tmIterator = new RegularIterator(1);
            TranslationUnit[] returnedTMs = tm.LanguageDirection.GetTranslationUnits(ref tmIterator);
            while (returnedTMs.Count() > 0)
            {
                foreach (TranslationUnit item in returnedTMs)
                {
                    if (item.SourceSegment.ToPlain() == "My new TU")
                    {
                        tuID = item.ResourceId;
                        break;
                    }
                }
                returnedTMs = tm.LanguageDirection.GetTranslationUnits(ref tmIterator);
            }

            return tuID;
        }

        /// <summary>
        /// Change target segment content of existing TU
        /// </summary>
        /// <param name="tmPath"></param>
        /// <param name="searchedText"></param>
        /// <param name="newTarget"></param>
        public void AdaptTU(string tmPath, string searchedText, string newTarget)
        {
            FileBasedTranslationMemory tm = new FileBasedTranslationMemory(tmPath);
            SearchResults results = tm.LanguageDirection.SearchText(GetSearchSettings(), searchedText);
            foreach (SearchResult item in results)
            {
                if (item.ScoringResult.Match == 100)
                {
                    item.MemoryTranslationUnit.TargetSegment.Clear();//remove existing target segment content
                    item.MemoryTranslationUnit.TargetSegment.Add(newTarget);
                    item.MemoryTranslationUnit.SystemFields.UseCount++;


                    MultiplePicklistFieldValue picklistValue = new MultiplePicklistFieldValue("Sample field");
                    picklistValue.Add("yes");
                    item.MemoryTranslationUnit.FieldValues.Add(picklistValue);

                    MultipleStringFieldValue stringValue = new MultipleStringFieldValue("Sample text field");
                    stringValue.Add("new item");
                    stringValue.Add("new project");
                    item.MemoryTranslationUnit.FieldValues.Add(stringValue);

                    WriteResult("TU found and changed.");
                    break;
                }
            }
        }

        /// <summary>
        /// Add a new TU into the specified TM
        /// </summary>
        /// <param name="tmPath"></param>
        public void AddTU(string tmPath)
        {
            FileBasedTranslationMemory tm = new FileBasedTranslationMemory(tmPath);
            tm.LanguageDirection.AddTranslationUnit(
                GetNewTU("TU to be deleted", "Eine TU fuer ...", tm.LanguageDirection.SourceLanguage, tm.LanguageDirection.TargetLanguage),
                GetImportSettings());
            WriteResult("New TU added.\r\n");
        }

        /// <summary>
        /// Create a new import settigns object
        /// </summary>
        /// <returns></returns>
        private ImportSettings GetImportSettings()
        {
            ImportSettings settings = new ImportSettings
            {
                CheckMatchingSublanguages = true,
                ExistingFieldsUpdateMode = FieldUpdateMode.Merge
            };

            return settings;
        }

        /// <summary>
        /// Create a new TranslationUnit object
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <param name="sourceCulture"></param>
        /// <param name="targetCulture"></param>
        /// <returns></returns>
        private TranslationUnit GetNewTU(string source, string target, CultureInfo sourceCulture, CultureInfo targetCulture)
        {
            TranslationUnit tu = new TranslationUnit
            {
                SourceSegment = new Segment(sourceCulture),
                TargetSegment = new Segment(targetCulture)
            };

            tu.SourceSegment.Add(source);
            tu.TargetSegment.Add(target);

            MultiplePicklistFieldValue picklistValue = new MultiplePicklistFieldValue("Sample field");
            picklistValue.Add("yes");

            tu.FieldValues.Add(picklistValue);

            MultipleStringFieldValue stringValue = new MultipleStringFieldValue("Sample text field");
            stringValue.Add("new item");
            stringValue.Add("new project");

            tu.FieldValues.Add(stringValue);

            //add structure context info
            tu.StructureContexts = new string[] { "H" };

            return tu;
        }

        /// <summary>
        /// Search for specific text
        /// </summary>
        /// <param name="tmPath"></param>
        public void SearchForTU(string tmPath, string searchedText)
        {
            FileBasedTranslationMemory tm = new FileBasedTranslationMemory(tmPath);
            SearchResults results = tm.LanguageDirection.SearchText(GetSearchSettings(), searchedText);
            foreach (SearchResult item in results)
            {
                WriteResult("TU found: " + item.MemoryTranslationUnit.TargetSegment.ToPlain() + " - " + item.ScoringResult.Match + "% match.");
            }
        }

        /// <summary>
        /// Create a new search settigns object
        /// </summary>
        /// <returns></returns>
        private SearchSettings GetSearchSettings()
        {
            SearchSettings settings = new SearchSettings
            {
                MinScore = 70
            };
            return settings;
        }

        /// <summary>
        /// Export specified TM into the tmx file
        /// </summary>
        /// <param name="tmPath"></param>
        /// <param name="exportFilePath"></param>
        public void ExportTMXFile(string tmPath, string exportFilePath)
        {
            FileBasedTranslationMemory tm = new FileBasedTranslationMemory(tmPath);

            TranslationMemoryExporter exporter = new TranslationMemoryExporter(tm.LanguageDirection);

            exporter.FilterExpression = GetExportFilter();

            exporter.BatchExported += new EventHandler<BatchExportedEventArgs>(Exporter_BatchExported);

            exporter.ChunkSize = 1; //sets the import size after which the BatchExported event is launched

            exporter.Export(exportFilePath, true);
        }

        /// <summary>
        /// Export event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Exporter_BatchExported(object sender, BatchExportedEventArgs e)
        {
            WriteResult(e.TotalProcessed + " TU(s) exported.\r\n");
            e.Cancel = false;
        }

        /// <summary>
        /// Imports a single tmx file into specified file based TM
        /// </summary>
        /// <param name="tmPath"></param>
        /// <param name="tmxFile"></param>
        public void ImportTMXFile(string tmPath, string tmxFile)
        {
            FileBasedTranslationMemory tm = new FileBasedTranslationMemory(tmPath);

            TranslationMemoryImporter importer = new TranslationMemoryImporter(tm.LanguageDirection);

            importer.BatchImported += new EventHandler<BatchImportedEventArgs>(Importer_BatchImported);

            importer.ChunkSize = 1; //sets the import size after which the BatchImported event is launched

            AdaptImportSettigns(importer.ImportSettings);

            importer.Import(tmxFile);
        }

        /// <summary>
        /// Imports a single tmx file into specified file based TM
        /// </summary>
        /// <param name="tmPath"></param>
        /// <param name="tmxFile"></param>
        public void ImportSDLXLIFFFile(string tmPath, string sdlxliffFile)
        {
            FileBasedTranslationMemory tm = new FileBasedTranslationMemory(tmPath);
            TranslationMemoryImporter importer = new TranslationMemoryImporter(tm.LanguageDirection);
            //Set up the Poco Filter Manager with default list of filters
            importer.FileTypeManager = new PocoFilterManager(true);
            importer.BatchImported += new EventHandler<BatchImportedEventArgs>(Importer_BatchImported);
            importer.ChunkSize = 1; //sets the import size after which the BatchImported event is launched
            AdaptImportSettigns(importer.ImportSettings);
            importer.Import(sdlxliffFile);
        }


        /// <summary>
        /// Import event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Importer_BatchImported(object sender, BatchImportedEventArgs e)
        {
            WriteResult(e.Statistics.AddedTranslationUnits + " TU(s) were imported.\r\n");
            e.Cancel = false;
        }

        /// <summary>
        /// Change default import settigns
        /// </summary>
        /// <param name="importSettings"></param>
        private void AdaptImportSettigns(ImportSettings importSettings)
        {
            importSettings.CheckMatchingSublanguages = true;
            importSettings.ExistingTUsUpdateMode = TUUpdateMode.Overwrite;
            //set behavior of existing field values during import
            importSettings.ExistingFieldsUpdateMode = ImportSettings.FieldUpdateMode.Merge;
            //set behavior of new fields during import
            importSettings.NewFields = ImportSettings.NewFieldsOption.AddToSetup;
            //create a field (now using field already existing in the TM setup)            
            //set the field value object
            MultipleStringFieldValue cruVal = new MultipleStringFieldValue("Sample text field");
            //add new value (this time we use multiple string field value
            cruVal.Add("Added during import");
            //create field values object
            FieldValues fields = new FieldValues();
            //add the field value
            fields.Add(cruVal);
            //set the field values to the import settigns
            importSettings.ProjectSettings = fields;
        }

        public delegate void WriteResultDelegate(string progress);

        public void WriteResult(string progress)
        {
            //If not on UI thread
            if (_output.InvokeRequired)
            {
                _output.Invoke(new WriteResultDelegate(WriteResult), new object[] { progress });
            }
            else
            {
                //Do work here - called on UI thread
                _output.Text += progress;
                _output.Refresh();
            };
        }


        /// <summary>
        /// Create a new file based TM on specified path
        /// </summary>
        /// <param name="tmPath"></param>
        public void CreateNewFileBasedTM(string tmPath)
        {
            //create a new TM
            FileBasedTranslationMemory tm = new FileBasedTranslationMemory(tmPath,
                "A sample created as example of using TM API.",
                CultureInfo.GetCultureInfo("en-US"),
                CultureInfo.GetCultureInfo("de-DE"),
                GetFuzzyIndexes(),
                GetRecognizers(),
                TokenizerFlags.BreakOnHyphen | TokenizerFlags.BreakOnDash,
                WordCountFlags.BreakOnHyphen | WordCountFlags.BreakOnDash | WordCountFlags.BreakOnTag);

            WriteResult("TM " + tmPath + " created.\r\n");

            //start changing the default properties
            tm.Copyright = "SDK Sample";

            tm.ExpirationDate = DateTime.Now.AddDays(2); //will expire in 2 days 

            AdaptFields(tm.FieldDefinitions);

            AdaptLanguageResourceBundles(tm.LanguageResourceBundles);

            //save all changes
            tm.Save();
        }

        /// <summary>
        /// Adapt language resource bundle, add a new abbreviations
        /// </summary>
        /// <param name="languageResourceBundleCollection"></param>
        private void AdaptLanguageResourceBundles(LanguageResourceBundleCollection languageResourceBundleCollection)
        {
            //we can either create a bundle from scratch or use DefaultLanguageResourceProvider which allows us to access the default list
            DefaultLanguageResourceProvider defaultProvider = new DefaultLanguageResourceProvider();
            //as working with file based TM, we will create a bundle for source language
            LanguageResourceBundle bundle = defaultProvider.GetDefaultLanguageResources(CultureInfo.GetCultureInfo("en-US"));
            bundle.Abbreviations.Add("SDK");
            bundle.Abbreviations.Add("SDL");

            languageResourceBundleCollection.Add(bundle);

            WriteResult("A custom abbreviations added\r\n");
        }

        private FilterExpression GetExportFilter()
        {
            PicklistItem i1 = new PicklistItem("Sample field");
            MultiplePicklistFieldValue v1 = new MultiplePicklistFieldValue("yes");
            v1.Add(i1);
            AtomicExpression e1 = new AtomicExpression(v1, AtomicExpression.Operator.Contains);

            MultipleStringFieldValue v2 = new MultipleStringFieldValue("Sample text field");
            v2.Add("new item");
            AtomicExpression e2 = new AtomicExpression(v2, AtomicExpression.Operator.Contains);

            ComposedExpression filter = new ComposedExpression(e1, ComposedExpression.Operator.Or, e2);

            return filter;
        }

        /// <summary>
        /// Add a new TM field
        /// </summary>
        /// <param name="fieldDefinitionCollection"></param>
        private void AdaptFields(FieldDefinitionCollection fieldDefinitionCollection)
        {
            FieldDefinition field1 = new FieldDefinition();
            field1.Name = "Sample field";
            field1.ValueType = FieldValueType.MultiplePicklist;
            field1.PicklistItems.Add("yes");
            field1.PicklistItems.Add("no");

            fieldDefinitionCollection.Add(field1);

            FieldDefinition field2 = new FieldDefinition();
            field2.Name = "Sample text field";
            field2.ValueType = FieldValueType.MultipleString;

            fieldDefinitionCollection.Add(field2);

            WriteResult("A new field definition added\r\n");
        }

        /// <summary>
        /// Create a new fuzzy indexes object
        /// </summary>
        /// <returns></returns>
        private FuzzyIndexes GetFuzzyIndexes()
        {
            return FuzzyIndexes.SourceWordBased | FuzzyIndexes.TargetWordBased | FuzzyIndexes.SourceCharacterBased;
        }


        /// <summary>
        /// Create a new Recognizers object
        /// </summary>
        /// <returns></returns>
        private BuiltinRecognizers GetRecognizers()
        {
            return BuiltinRecognizers.RecognizeAll;
        }
    }
}
