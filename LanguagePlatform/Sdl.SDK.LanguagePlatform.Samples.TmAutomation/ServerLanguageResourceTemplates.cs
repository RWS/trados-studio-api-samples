namespace Sdl.SDK.LanguagePlatform.Samples.TmAutomation
{
    using Sdl.LanguagePlatform.TranslationMemoryApi;
    using System.Globalization;
    using System.Windows.Forms;

    public class ServerLanguageResourceTemplates
    {
        #region "get"
        public void GetTemplates(TranslationProviderServer tmServer)
        {
            #region "LoopTemplates"
            string templateList = string.Empty;
            foreach (ServerBasedLanguageResourcesTemplate template in tmServer.GetLanguageResourcesTemplates(LanguageResourcesTemplateProperties.All))
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
            ServerBasedLanguageResourcesTemplate template = tmServer.GetLanguageResourcesTemplate(templateName, LanguageResourcesTemplateProperties.All);
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
            #region "TemplateProps"
            ServerBasedLanguageResourcesTemplate template = new ServerBasedLanguageResourcesTemplate(tmServer);
            template.Name = "Sample Language Resources Template";
            template.Description = "Language Resources template created through API";
            #endregion

            #region "variables"
            LanguageResourceBundle variables = new LanguageResourceBundle(CultureInfo.GetCultureInfo("en-US"));
            variables.Variables.Add("SDL Trados Studio 2021");
            variables.Variables.Add("SDL MultiTerm 2021");
            #endregion

            #region "abbreviations"
            LanguageResourceBundle abbreviations = new LanguageResourceBundle(CultureInfo.GetCultureInfo("en-US"));
            abbreviations.Abbreviations.Add("hr.");
            abbreviations.Abbreviations.Add("cont.");
            #endregion

            #region "AddResources"
            template.LanguageResourceBundles.Add(variables);
            template.LanguageResourceBundles.Add(abbreviations);
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
