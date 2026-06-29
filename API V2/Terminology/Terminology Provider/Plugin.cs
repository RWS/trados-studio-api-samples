using TradosStudio.API;
using TradosStudio.API.TranslationResources.Terminology;

namespace FileGlossaryTerminologyProvider
{
	public class Plugin : IPlugin
	{
		public void Initialize()
		{
		}

		public void RegisterTypes(IContainer container)
		{
			// Register the factory that creates providers for "fileglossary://" URIs.
			container.AppendCollection<ITerminologyProviderFactory, FileGlossaryTerminologyProviderFactory>();

			// Register the WinForms settings UI so the provider appears in the
			// "Add Terminology Provider" dialog with browse/create/edit behaviours.
			container.AppendCollection<ITerminologyProviderWinFormsUI, FileGlossaryTerminologyProviderWinFormsUI>();

			// Register the viewer UI so the provider shows term details in the
			// Termbase Viewer window inside the Editor View.
			container.AppendCollection<ITerminologyProviderViewerWinFormsUI, FileGlossaryTerminologyProviderViewerWinFormsUI>();
		}
	}
}
