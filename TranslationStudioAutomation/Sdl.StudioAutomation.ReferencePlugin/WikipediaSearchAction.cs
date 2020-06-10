using Sdl.Desktop.IntegrationApi;
using Sdl.Desktop.IntegrationApi.Extensions;
using Sdl.TranslationStudioAutomation.IntegrationApi;
using Sdl.TranslationStudioAutomation.IntegrationApi.Presentation.DefaultLocations;
using System;
using System.Windows.Forms;

namespace StudioIntegrationApiSample
{
    [RibbonGroup("WikipediaRibbonGroup", "Wikipedia", ContextByType = typeof(EditorController))]
    [RibbonGroupLayout(LocationByType = typeof(TranslationStudioDefaultRibbonTabs.EditorAdvancedRibbonTabLocation))]
    class WikipediaRibbonGroup : AbstractRibbonGroup
    {
    }

    [Action("WikipediaSearchAction", typeof(EditorController), Name = "WikipediaSearchAction_Name", Description = "WikipediaSearchAction_Description", Icon = "Wikipedia_Icon")]
    [ActionLayout(typeof(WikipediaRibbonGroup), 1, DisplayType.Large)]
    [ActionLayout(typeof(TranslationStudioDefaultContextMenus.EditorDocumentContextMenuLocation), 1, DisplayType.Large)]
    [Shortcut(Keys.Alt | Keys.F8)]
    public class WikipediaSearchAction : AbstractViewControllerAction<EditorController>
    {
        public override void Initialize()
        {
        }

        protected override void Execute()
        {
            EditorController editorController = SdlTradosStudio.Application.GetController<EditorController>();
            WikipediaResultsViewPartController wikiPediaController = SdlTradosStudio.Application.GetController<WikipediaResultsViewPartController>();

            var doc = editorController.ActiveDocument;

            if (doc == null)
            {
                return;
            }

            string selectedText =
                doc.FocusedDocumentContent == FocusedDocumentContent.Source
                    ? doc.Selection.Source.ToString()
                    : doc.Selection.Target.ToString();

            if (!string.IsNullOrEmpty(selectedText))
            {
                wikiPediaController.Lookup(selectedText);
                wikiPediaController.Show();
            }
        }
    }
}
