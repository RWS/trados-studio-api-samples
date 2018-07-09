namespace Sdl.SDK.LanguagePlatform.Samples.TmAutomation
{
    using System;
    using System.Globalization;
    using Sdl.LanguagePlatform.TranslationMemoryApi;

    public class ServerTmCreator
    {
        #region "create"
        public void Create(TranslationProviderServer tmServer, string organizationPath, string containerName, string tmName)
        {
            #region "CheckExists"
            foreach (ServerBasedTranslationMemory item in tmServer.GetTranslationMemories(TranslationMemoryProperties.None))
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
                containerPath += "/";

            #region "container"
            containerPath += containerName;
            TranslationMemoryContainer container = tmServer.GetContainer(containerPath, this.GetContainerProperties());
            newTM.Container = container;
            #endregion

            #region "LanguageDirection"
            this.CreateLanguageDirections(newTM.LanguageDirections);
            #endregion

            #region "org"
            newTM.ParentResourceGroupPath = organizationPath;
            #endregion

            string templatePath = organizationPath;
            if (!templatePath.EndsWith("/"))
                templatePath += "/";

            #region "templates"
            string sampleFieldTemplateName = "MyFieldTemplate";
            foreach (ServerBasedFieldsTemplate template in tmServer.GetFieldsTemplates(FieldsTemplateProperties.All))
            {
                if (template.Name == sampleFieldTemplateName)
                {
                    newTM.FieldsTemplate = tmServer.GetFieldsTemplate(
                        templatePath + sampleFieldTemplateName, FieldsTemplateProperties.Fields);
                    break;
                }
            }

            string sampleLanguageResourcesTemplateName = "MyLanguageResourcesTemplate";
            foreach (ServerBasedLanguageResourcesTemplate template in tmServer.GetLanguageResourcesTemplates(
                LanguageResourcesTemplateProperties.LanguageResources))
            {
                if (template.Name == sampleLanguageResourcesTemplateName)
                {
                    newTM.LanguageResourcesTemplate = tmServer.GetLanguageResourcesTemplate(
                        templatePath + sampleLanguageResourcesTemplateName, LanguageResourcesTemplateProperties.None);
                    break;
                }
            }
            #endregion


            newTM.Save();
        }
        #endregion

        #region "ContainerProps"
        private ContainerProperties GetContainerProperties()
        {
            ContainerProperties props = new ContainerProperties();

            return props;
        }
        #endregion

        #region "languages"
        private void CreateLanguageDirections(ServerBasedTranslationMemoryLanguageDirectionCollection directionsCollection)
        {
            ServerBasedTranslationMemoryLanguageDirection direction = new ServerBasedTranslationMemoryLanguageDirection();
            direction.SourceLanguage = CultureInfo.GetCultureInfo("en-US");
            direction.TargetLanguage = CultureInfo.GetCultureInfo("de-DE");

            directionsCollection.Add(direction);
        }
        #endregion

        #region "DeleteTm"
        public void DeleteTm(TranslationProviderServer tmServer, string organizationPath, string tmName)
        {
            string tmPath = organizationPath;
            if (!tmPath.EndsWith("/"))
                tmPath += "/";

            ServerBasedTranslationMemory tm = tmServer.GetTranslationMemory(tmPath + tmName, TranslationMemoryProperties.All);
            tm.Delete();
        }
        #endregion
    }
}