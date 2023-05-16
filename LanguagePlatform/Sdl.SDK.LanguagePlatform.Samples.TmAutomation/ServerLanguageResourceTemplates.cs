using System.Windows.Forms;
using Sdl.Core.Globalization;
using Sdl.LanguagePlatform.TranslationMemoryApi;

namespace Sdl.SDK.LanguagePlatform.Samples.TmAutomation
{
	public class ServerLanguageResourceTemplates
	{
		#region "get"
		public void GetTemplates(TranslationProviderServer tmServer)
		{
			#region "LoopTemplates"
			string templateList = string.Empty;
			foreach (ServerBasedLanguageResourcesTemplate template in tmServer.GetLanguageResourcesTemplates())
			#endregion
			{
				#region "info"
				templateList += "Template name: " + template.Name + "\n";
				templateList += "Description: " + template.Description + "\n";
				#endregion
				#region "VarCount"
				LanguageResourceBundle bundle = template.LanguageResourceBundles[0];
				templateList += "Number of variables in template: " + bundle.Variables.Count.ToString() + "\n\n";
				#endregion
			}

			MessageBox.Show(templateList, "Available language resources remplates");
		}
		#endregion

		#region "GetTmsForTemplate"
		public void GetTmsForTemplate(TranslationProviderServer tmServer, string templateName)
		{
			#region "SelectTemplate"
			ServerBasedLanguageResourcesTemplate template = tmServer.GetLanguageResourcesTemplate(templateName);
			#endregion

			#region "LoopTms"
			string tmList = string.Empty;
			foreach (ServerBasedTranslationMemory tm in template.TranslationMemories)
			{
				tmList += tm.Name + "\n";
			}

			MessageBox.Show(tmList);
			#endregion
		}
		#endregion

		#region "CreateTemplate"
		public void CreateTemplate(TranslationProviderServer tmServer)
		{
			ServerBasedLanguageResourcesTemplate template = new ServerBasedLanguageResourcesTemplate(tmServer);
			template.Name = "Sample Language Resources Template";
			template.Description = "Language Resources template created through API";

			// "variables"
			LanguageResourceBundle variables = new LanguageResourceBundle(new CultureCode("en-US"));
			variables.Variables.Add("SDL Trados Studio 2022");
			variables.Variables.Add("SDL MultiTerm 2022");

			// "abbreviations"
			LanguageResourceBundle abbreviations = new LanguageResourceBundle(new CultureCode("en-US"));
			abbreviations.Abbreviations.Add("hr.");
			abbreviations.Abbreviations.Add("cont.");

			// "AddResources"
			template.LanguageResourceBundles.Add(variables);
			template.LanguageResourceBundles.Add(abbreviations);

			// save
			template.Save();
			MessageBox.Show("Unsaved changes? " + template.IsDirty.ToString());

			//delete
			template.Delete();
		}
		#endregion
	}
}
