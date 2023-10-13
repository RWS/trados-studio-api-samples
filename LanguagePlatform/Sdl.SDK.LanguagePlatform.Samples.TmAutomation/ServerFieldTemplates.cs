using System;
using System.Text;
using System.Windows.Forms;
using Sdl.LanguagePlatform.TranslationMemory;
using Sdl.LanguagePlatform.TranslationMemoryApi;

namespace Sdl.SDK.LanguagePlatform.Samples.TmAutomation
{
	public class ServerFieldTemplates
	{
		#region "get"
		public void GetFieldTemplates(TranslationProviderServer tmServer)
		{
			#region "LoopTemplates"
			StringBuilder templateList = new StringBuilder();

			foreach (ServerBasedFieldsTemplate template in tmServer.GetFieldsTemplates())
			#endregion
			{
				#region "GeneralTemplateInfo"
				templateList.AppendFormat("Template name: {0}\n", template.Name);
				templateList.AppendFormat("Template description: {0}\n", template.Description);
				#endregion

				#region "fields"
				templateList.AppendLine("Fields: ");
				foreach (FieldDefinition def in template.FieldDefinitions)
				{
					templateList.AppendFormat("{0}({1})", def.Name, def.ValueType.ToString());
				}

				templateList.AppendLine(string.Empty);
				#endregion
			}

			MessageBox.Show(templateList.ToString(), "Template List");
		}
		#endregion

		#region "GetTms"
		public void GetTmsForTemplate(TranslationProviderServer tmServer, string templateName)
        {
            #region "GetTemplate"
            ServerBasedFieldsTemplate template = tmServer.GetFieldsTemplate(templateName);
            #endregion

            #region "TmLoop"
            StringBuilder tmList = new StringBuilder();
            PagedTranslationMemories pagedTms = GetTmsWithTemplate(template, tmServer);
            foreach (ServerBasedTranslationMemory tm in pagedTms.TranslationMemories)
            {
                tmList.AppendLine(tm.Name);
            }

            MessageBox.Show(tmList.ToString());
            #endregion
        }

        private static PagedTranslationMemories GetTmsWithTemplate(ServerBasedFieldsTemplate template, TranslationProviderServer tmServer)
        {
            return tmServer.GetTranslationMemoriesByQuery(new TranslationMemoryQuery { FieldTemplateIds = new Guid[] { template.Id } });
        }
        #endregion

        #region "create"
        public void CreateTemplate(TranslationProviderServer tmServer)
		{
			#region "CreateTemplate"
			ServerBasedFieldsTemplate template = new ServerBasedFieldsTemplate(tmServer);
			template.Name = "Sample Template";
			template.Description = "Fields template created by API";
			#endregion

			#region "AddTextField"
			FieldDefinition projField = new FieldDefinition("Project id", FieldValueType.MultipleString);
			#endregion

			#region "AddListField"
			FieldDefinition clientField = new FieldDefinition("Client", FieldValueType.MultiplePicklist);
			clientField.PicklistItems.Add("Microsoft");
			clientField.PicklistItems.Add("SAP");
			#endregion

			#region "AddFieldsToTemplate"
			template.FieldDefinitions.Add(projField);
			template.FieldDefinitions.Add(clientField);
			#endregion

			#region "save"
			template.Save();
			MessageBox.Show("Unsaved changes? " + template.IsDirty.ToString());
			#endregion

			#region "delete"
			template.Delete();
			#endregion
		}
		#endregion
	}
}
