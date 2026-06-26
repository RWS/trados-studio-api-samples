using System;
using System.Collections.Generic;
using System.Windows;
using TradosStudio.API.UI;
using TradosStudio.API.UI.Action;

namespace TranslationStudioAutomationPlugin.Actions
{
	/// <summary>
	/// Meta data for the plugin action, it is used to define the unique identifier, display name and description of the action
	/// </summary>
	internal class PluginActionMetaData : IActionMetaData
	{
		/// <summary>
		/// The unique identifier for the action, it must be unique across all actions in Trados Studio, it is recommended to use a namespace-like format to ensure uniqueness, for example: "PluginName.ActionName".
		/// </summary>
		public string Id => Constants.PluginActionId;

		/// <summary>
		/// The name of the category where the action will be displayed in hte Keyboard Shortcuts settings.
		/// </summary>
		public string Category => StringResources.ActionCategory;

		/// <summary>
		/// The text that is displayed on the ribbon for this action, it can be a string or a resource reference, it is recommended to use a resource reference for localization purposes.
		/// </summary>
		public string Text => StringResources.PluginActionName;

		/// <summary>
		/// Tooltip text displayed when the user hovers over the action, it can be a string or a resource reference, it is recommended to use a resource reference for localization purposes.
		/// </summary>
		public string TooltipText => StringResources.PluginActionTooltip;

		/// <summary>
		/// Specifies the icon for the action.
		/// </summary>
		public string Icon { get; } = $"TranslationStudioAutomationPlugin.Resources.{nameof(ImageResources.PluginActionIcon)}.ico";

		/// <summary>
		/// Specifies the size of the action, it is recommended to use Default for most actions, 
		/// <see cref="ActionSize"/> enumeration for more details
		/// </summary>
		public ActionSize Size => ActionSize.Default;

		/// <summary>
		/// Specifies when the action will be visible 
		/// <see cref="TradosStudio.API.UI.TargetSiteType"/> enumeration for more details
		/// </summary>
		public TargetSiteType TargetSiteType => TargetSiteType.Window;

		/// <summary>
		/// If TargetSiteType is View or ViewPart, this is the id of the view or view part where the action will be displayed.
		/// If TargetSiteType is not View or ViewPart, this property is ignored.
		/// </summary>
		public string TargetSiteId => string.Empty;

		/// <summary>
		/// Specifies the actual class to use for the action, it must implement the IAction interface, otherwise the action will not be executed when the user clicks on it.
		/// </summary>
		public Type ActionType => typeof(PluginAction);

		/// <summary>
		/// Locations where the action will be displayed, it is a collection of IActionLocation,
		/// it must contain at least one location, otherwise the action will not be displayed anywhere in Trados Studio.
		/// </summary>
		public IEnumerable<IActionLocation> Locations { get; } = new List<IActionLocation>()
		{
			new RibbonGroupLocation(Constants.PluginRibbonGroupId),
			new ContextMenuLocation(ActionLocationTargets.FilesContextMenu)
		};

		/// <summary>
		/// Specifies the shortcut keys for the action, it is a combination of Keys enumeration values, 
		/// for example: Keys.Control | Keys.L, it is recommended to use a unique combination of keys that does not conflict
		/// with existing shortcuts in Trados Studio.
		/// </summary>
		public Keys ShortcutKeys => Keys.Control | Keys.L;
	}

	internal class PluginAction : ActionBase, IAction
	{
		/// <summary>
		/// Execution logic for the action, this method is called when the action is executed.		
		/// </summary>		
		public void Execute()
		{
			MessageBox.Show(StringResources.PluginActionExecutedMessage, StringResources.PluginActionExecutedTitle, MessageBoxButton.OK, MessageBoxImage.Information);
		}

		/// <summary>
		/// Is called when the action is initialized.
		/// </summary>
		public void OnInit()
		{
			/// add initialization logic here if needed
		}
	}
}
