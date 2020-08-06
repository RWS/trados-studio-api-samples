namespace Sdl.SDK.ProjectAutomation.Samples.Examples
{
    using System.Collections.Generic;
    using Sdl.Core.Settings;
    using Sdl.LanguagePlatform.TranslationMemory;
    using Sdl.LanguagePlatform.TranslationMemoryApi;
    using Sdl.ProjectAutomation.FileBased;
    using Sdl.ProjectAutomation.Settings;

    internal class TmSettings
    {
        #region "ConfigureTmSettings"
        public void ConfigureTmSettings(FileBasedProject project)
        {
            #region "GetSettingsBundle"
            ISettingsBundle settings = project.GetSettings();
            TranslationMemorySettings tmSettings = settings.GetSettingsGroup<TranslationMemorySettings>();
            #endregion

            #region "TmSearchSettings"
            tmSettings.TranslationMinimumMatchValue.Value = 80;
            tmSettings.TranslationMaximumResults.Value = 10;
            tmSettings.TranslationFullSearch.Value = true;
            #endregion

            #region "ConcordanceSettings"
            tmSettings.ConcordanceMinimumMatchValue.Value = 30;
            tmSettings.ConcordanceMaximumResults.Value = 50;
            #endregion

            #region "Penalties"
            tmSettings.MissingFormattingPenalty.Value = 0;
            tmSettings.DifferentFormattingPenalty.Value = 0;
            tmSettings.MultipleTranslationsPenalty.Value = 2;
            #endregion

            #region "AutoLocalization"
            tmSettings.NumbersAutoLocalizationEnabled.Value = true;
            tmSettings.DatesAutoLocalizationEnabled.Value = true;
            tmSettings.MeasurementsAutoLocalizationEnabled.Value = true;
            tmSettings.TimesAutoLocalizationEnabled.Value = true;
            #endregion

            #region "DatePatterns"
            tmSettings.ShortDatePattern.Value = "dd.MM.yy";
            #endregion

            #region "FieldUpdate"
            FieldValues fieldValuesCollection = new FieldValues();
            FileBasedTranslationMemory tm = new FileBasedTranslationMemory(@"c:\ProjectFiles\Tms\General En-De.sdltm");
            FieldDefinition field = tm.FieldDefinitions["Type"];
            FieldValue fv = field.CreateValue();
            fv.Name = "Technical documentation";
            fieldValuesCollection.Add(fv);
            tmSettings.ProjectSettings.Value = fieldValuesCollection;
            #endregion

            #region "TmFilterPenalty"
            PicklistItem fieldName = new PicklistItem("Type");
            MultiplePicklistFieldValue fieldValue = new MultiplePicklistFieldValue("Technical documentation");
            fieldValue.Add(fieldName);

            AtomicExpression filter = new AtomicExpression(fieldValue, AtomicExpression.Operator.Equal);
            Filter updateFilter = new Filter(filter, "Filter_name", 1);
            List<Filter> filterList = new List<Filter>();
            filterList.Add(updateFilter);

            tmSettings.Filters.Value = filterList;
            #endregion

            #region "TmHardFilter"
            PicklistItem hardFilterFieldName = new PicklistItem("Type");
            MultiplePicklistFieldValue hardFilterFieldValue = new MultiplePicklistFieldValue("Technical documentation");
            hardFilterFieldValue.Add(hardFilterFieldName);
            AtomicExpression hardFilterExpression = new AtomicExpression(hardFilterFieldValue, AtomicExpression.Operator.Equal);
            tmSettings.HardFilter.Value = hardFilterExpression;
            #endregion

            #region "update"
            project.UpdateSettings(settings);
            #endregion
        }
        #endregion

        #region "GetTmSetup"
        private void GetTmSetup()
        {
            FileBasedTranslationMemory tm = new FileBasedTranslationMemory(@"c:\ProjectFiles\Tms\General En-De.sdltm");
                        
            foreach (FieldDefinition tmField in tm.FieldDefinitions)
            {
                string tmSetup = string.Empty;
                tmSetup += tmField.Name;
                if (tmField.ValueType == FieldValueType.MultiplePicklist ||
                    tmField.ValueType == FieldValueType.SinglePicklist)
                {
                    for (int i = 0; i < tmField.PicklistItems.Count; i++)
                    {
                        tmSetup += tmField.PicklistItems[i].Name;
                    }
                }
            }
        }
        #endregion
    }
}
