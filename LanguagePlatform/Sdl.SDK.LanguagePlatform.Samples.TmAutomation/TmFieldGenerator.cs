namespace Sdl.SDK.LanguagePlatform.Samples.TmAutomation
{
    using Sdl.LanguagePlatform.TranslationMemory;
    using Sdl.LanguagePlatform.TranslationMemoryApi;

    public class TMFieldGenerator
    {
        #region "AddFields"
        public void AddFields(string tmPath)
        {
            #region "listField"
            FileBasedTranslationMemory tm = new FileBasedTranslationMemory(tmPath);

            FieldDefinition listField = new FieldDefinition();
            listField.Name = "Customer";
            listField.ValueType = FieldValueType.MultiplePicklist;
            listField.PicklistItems.Add("SDL");
            listField.PicklistItems.Add("Microsoft");
            #endregion

            #region "textField"
            FieldDefinition textField = new FieldDefinition();
            textField.Name = "Project id";
            textField.ValueType = FieldValueType.MultipleString;
            #endregion

            #region "add"
            tm.FieldDefinitions.Add(listField);
            tm.FieldDefinitions.Add(textField);
            #endregion

            tm.Save();
        }
        #endregion
    }
}
