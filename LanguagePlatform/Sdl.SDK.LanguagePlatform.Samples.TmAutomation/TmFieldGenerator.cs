using Sdl.LanguagePlatform.TranslationMemory;
using Sdl.LanguagePlatform.TranslationMemoryApi;

namespace Sdl.SDK.LanguagePlatform.Samples.TmAutomation
{
	public class TMFieldGenerator
	{
		public void AddFields(string tmPath)
		{
			#region "listField"
			FileBasedTranslationMemory tm = new FileBasedTranslationMemory(tmPath);

			FieldDefinition listField = new FieldDefinition
			{
				Name = "Customer",
				ValueType = FieldValueType.MultiplePicklist
			};
			listField.PicklistItems.Add("SDL");
			listField.PicklistItems.Add("Microsoft");
			#endregion

			#region "textField"
			FieldDefinition textField = new FieldDefinition
			{
				Name = "Project id",
				ValueType = FieldValueType.MultipleString
			};
			#endregion

			#region "add"
			tm.FieldDefinitions.Add(listField);
			tm.FieldDefinitions.Add(textField);
			#endregion

			tm.Save();
		}
	}
}
