using System;
using Sdl.Core.Globalization;
using Sdl.Core.Globalization.LanguageRegistry;
using Sdl.LanguagePlatform.TranslationMemoryApi;

namespace Sdl.SDK.LanguagePlatform.Samples.TmAutomation
{
	public class ServerTmCreator
	{
		#region "create"
		public void Create(TranslationProviderServer tmServer, string organizationPath, string containerName, string tmName)
		{
			#region "CheckExists"
			foreach (ServerBasedTranslationMemory item in tmServer.GetTranslationMemories())
			{
				if (item.Name == tmName)
				{
					throw new Exception("TM with that name already exists.");
				}
			}
			#endregion

			#region "TM"
			ServerBasedTranslationMemory newTM = new ServerBasedTranslationMemory(tmServer);
			newTM.Name = tmName;
			newTM.Description = "Programmatically created sample TM";
			newTM.Copyright = "(c) 2010 SDL International";
			#endregion

			string containerPath = organizationPath;
			if (!containerPath.EndsWith("/"))
			{
				containerPath += "/";
			}

			#region "container"
			containerPath += containerName;
			TranslationMemoryContainer container = tmServer.GetContainer(containerPath);
			newTM.Container = container;
			#endregion

			#region "LanguageDirection"
			CreateLanguageDirections(newTM.LanguageDirections, "en-US", "de-DE");
			#endregion

			#region "org"
			newTM.ParentResourceGroupPath = organizationPath;
			#endregion

			string templatePath = organizationPath;
			if (!templatePath.EndsWith("/"))
			{
				templatePath += "/";
			}

			#region "templates"
			string sampleFieldTemplateName = "MyFieldTemplate";
			foreach (ServerBasedFieldsTemplate template in tmServer.GetFieldsTemplates())
			{
				if (template.Name == sampleFieldTemplateName)
				{
					newTM.FieldsTemplate = tmServer.GetFieldsTemplate(
						templatePath + sampleFieldTemplateName);
					break;
				}
			}

			string sampleLanguageResourcesTemplateName = "MyLanguageResourcesTemplate";
			foreach (ServerBasedLanguageResourcesTemplate template in tmServer.GetLanguageResourcesTemplates())
			{
				if (template.Name == sampleLanguageResourcesTemplateName)
				{
					newTM.LanguageResourcesTemplate = tmServer.GetLanguageResourcesTemplate(
						templatePath + sampleLanguageResourcesTemplateName);
					break;
				}
			}
			#endregion

			newTM.Save();
		}
		#endregion

		#region "languages"
		private void CreateLanguageDirections(ServerBasedTranslationMemoryLanguageDirectionCollection directionsCollection, string sourceLanguage, string targetLanguage)
		{
			ServerBasedTranslationMemoryLanguageDirection direction = new ServerBasedTranslationMemoryLanguageDirection();
			direction.SourceLanguage = GetCultureCode(sourceLanguage);
			direction.TargetLanguage = GetCultureCode(targetLanguage);

			directionsCollection.Add(direction);
		}

		// Studio has it's internal language registry to ensure that our application is OS independent 
		private CultureCode GetCultureCode(string cultureIsoCode)
		{
			try
			{
				// Language registry contains all the languages that are supported in Studio				
				var language = LanguageRegistryApi.Instance.GetLanguage(cultureIsoCode);
				return new CultureCode(language.CultureInfo);
			}
			catch (UnsupportedLanguageException)
			{
				// In case the language is not supported an exception is thrown
				return null;
			}
		}
		#endregion

		#region "DeleteTm"
		public void DeleteTm(TranslationProviderServer tmServer, string organizationPath, string tmName)
		{
			string tmPath = organizationPath;
			if (!tmPath.EndsWith("/"))
			{
				tmPath += "/";
			}

			ServerBasedTranslationMemory tm = tmServer.GetTranslationMemory(tmPath + tmName, TranslationMemoryProperties.All);
			tm.Delete();
		}
		#endregion
	}
}