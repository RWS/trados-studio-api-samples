using TradosStudio.API.UI;

namespace TranslationStudioAutomationPlugin.Actions
{
	/// <summary>
	/// Defines a ribbon group that will be added to the ribbon in Trados Studio, 
	/// it must implement the IRibbonGroup interface and be registered in the plugin's RegisterTypes method, 
	/// otherwise it will not be added to the ribbon.
	/// </summary>
	internal class PluginRibbonGroup : IRibbonGroup
	{
		/// <summary>
		/// The unique identifier for the ribbon group, it must be unique across all ribbon groups in Trados Studio
		/// </summary>
		public string Id => Constants.PluginRibbonGroupId;

		/// <summary>
		/// Text displayed on the ribbon for this group, it can be a string or a resource reference, 
		/// it is recommended to use a resource reference for localization purposes.
		/// </summary>
		public string DisplayName => StringResources.PluginRibbonGroup_Text;

		/// <summary>
		/// In case the <see cref="TradosStudio.API.UI.TargetSiteType"/> is View or ViewPart, this is the id of the view or view part
		/// </summary>
		public string TargetSiteId => string.Empty;

		/// <summary>   
		/// See <see cref="TradosStudio.API.UI.TargetSiteType"/> for more details, it defines where the ribbon group will be displayed in Trados Studio.
		/// </summary>
		public TargetSiteType TargetSiteType => TargetSiteType.Window;

		/// <summary>
		/// Defines the ribbon tabs where this group will be displayed, it is a collection of ribbon tab ids, it must contain at least one ribbon tab id.
		/// </summary>
		public RibbonTabs Locations => RibbonTabs.HomeTab;
	}
}
