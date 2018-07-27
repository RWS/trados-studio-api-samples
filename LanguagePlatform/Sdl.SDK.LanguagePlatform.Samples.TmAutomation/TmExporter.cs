

namespace Sdl.SDK.LanguagePlatform.Samples.TmAutomation
{
    using System;
    using System.Windows.Forms;
    using Sdl.LanguagePlatform.TranslationMemory;
    using Sdl.LanguagePlatform.TranslationMemoryApi;

    public class TMExporter
    {
        #region "export"
        public void ExportTMXFile(string tmPath, string exportFilePath)
        {
            #region "open"
            FileBasedTranslationMemory tm = new FileBasedTranslationMemory(tmPath);

            TranslationMemoryExporter exporter = new TranslationMemoryExporter(tm.LanguageDirection);
            #endregion

            #region "chunk"
            exporter.ChunkSize = 20;

            #endregion

            #region "FireEvent"
            exporter.BatchExported += new EventHandler<BatchExportedEventArgs>(this.exporter_BatchExported);
            #endregion

            #region "execute"
            exporter.Export(exportFilePath, true);
            #endregion
        }
        #endregion

        #region "event"
        private void exporter_BatchExported(object sender, BatchExportedEventArgs e)
        {
            string info;
            info = "Total TUs processed: " + e.TotalProcessed + "\n";
            info += "Total TUs exported: " + e.TotalExported + "\n";

            MessageBox.Show(info, "Export statistics for batch");
            e.Cancel = false;
        }
        #endregion

        #region "RunFilteredExport"
        public void RunFilteredExport(string tmPath, string exportFilePath)
        {
            #region "OpenForFilter"
            FileBasedTranslationMemory tm = new FileBasedTranslationMemory(tmPath);
            TranslationMemoryExporter exporter = new TranslationMemoryExporter(tm.LanguageDirection);
            #endregion

            #region "FilterDefinition"
            exporter.FilterExpression = this.GetFilterSimple();
            #endregion

            #region "DoFilteredExport"
            exporter.BatchExported += new EventHandler<BatchExportedEventArgs>(this.exporter_BatchExported);
            exporter.Export(exportFilePath, true);
            #endregion
        }
        #endregion

        #region "GetFilterSimple"
        private FilterExpression GetFilterSimple()
        {
            #region "SimpleCriterion"
            PicklistItem fieldName = new PicklistItem("Customer");
            MultiplePicklistFieldValue fieldValue = new MultiplePicklistFieldValue("Microsoft");
            fieldValue.Add(fieldName);
            #endregion

            #region "SimpleFilter"
            AtomicExpression filter = new AtomicExpression(fieldValue, AtomicExpression.Operator.Equal);
            return filter;
            #endregion
        }
        #endregion

        #region "GetFilterAdvanced"
        private FilterExpression GetFilterAdvanced()
        {
            #region "AdvancedCriterion1"
            PicklistItem fieldName1 = new PicklistItem("Customer");
            MultiplePicklistFieldValue fieldValue1 = new MultiplePicklistFieldValue("Microsoft");
            fieldValue1.Add(fieldName1);
            AtomicExpression expression1 = new AtomicExpression(fieldValue1, AtomicExpression.Operator.Equal);
            #endregion

            #region "AdvancedCriterion2"
            MultipleStringFieldValue fieldName2 = new MultipleStringFieldValue("Project id");
            fieldName2.Add("2010");
            AtomicExpression expression2 = new AtomicExpression(fieldName2, AtomicExpression.Operator.Contains);
            #endregion

            #region "AdvancedFilter"
            ComposedExpression filter = new ComposedExpression(expression1, ComposedExpression.Operator.Or, expression2);
            return filter;
            #endregion
        }
        #endregion
    }
}
