using TradosStudio.API;
using TradosStudio.API.UI;
using TradosStudio.API.UI.Action;
using TradosStudio.API.UI.View;
using TranslationStudioAutomationPlugin.Actions;
using TranslationStudioAutomationPlugin.Views;

namespace TranslationStudioAutomationPlugin
{
	/// <summary>
	/// This is the entry point for the plugin, it must be public and implement the IPlugin interface, otherwise the plugin will not be loaded by Trados Studio.
	/// </summary>
	public class Plugin : IPlugin
	{
		/// <summary>
		/// First method called by Trados Studio when loading the plugin, it is used to initialize the plugin and register any services or components that the plugin needs to function.
		/// </summary>
		public void Initialize()
		{
			// add intiailization logic here if needed
		}

		/// <summary>
		/// This method is called by Trados Studio to register the types in the dependecy injection container.
		/// </summary>
		/// <param name="container"></param>		
		public void RegisterTypes(IContainer container)
		{
			// register ribbon group
			container.AppendCollection<IRibbonGroup, PluginRibbonGroup>();

			// register action
			container.AppendCollection<IActionMetaData, PluginActionMetaData>();

			// register view 
			container.AppendCollection<IView, PluginView>();

			// register view part
			container.AppendCollection<IViewPartMetaData, ProjectsViewPartMetaData>();
			container.AppendCollection<IViewPartMetaData, DocumentsViewPartMetaData>();

			container.AppendCollection<IViewPart, ProjectsViewPart>();
			container.AppendCollection<IViewPart, DocumentsViewPart>();
		}
	}
}
