using Microsoft.Extensions.Logging;
using TradosStudio.API.UI;
using TradosStudio.API.UI.View;

namespace TranslationStudioAutomationPlugin.Views
{
	internal class PluginView : IView
	{
		private IUIControl _contentControl;
		private readonly ILogger<PluginView> _logger;

		/// <summary>
		/// Unique identifier for the view, it must be unique across all views in Trados Studio, it is recommended to use a namespace-like format to ensure uniqueness, for example: "PluginName.ViewName".
		/// </summary>
		public string Id => Constants.PluginViewId;

		/// <summary>
		/// Gets the display name of the plugin view.
		/// </summary>
		public string Name => StringResources.PluginViewName;

		/// <summary>
		/// Gets the description of the plugin view.
		/// </summary>
		public string Description => StringResources.PluginViewDescription;

		/// <summary>
		/// Gets the resource path for the plugin action icon.
		/// </summary>
		public string Icon => $"DummyPlugin.Resources.{nameof(ImageResources.PluginActionIcon)}.ico";

		/// <summary>
		/// Gets a value indicating whether the plugin view is available for use.
		/// </summary>
		public bool Available => true;

		/// <summary>
		/// Gets a value indicating whether the feature is enabled.
		/// </summary>
		public bool Enabled => true;

		public PluginView(ILogger<PluginView> logger)
		{
			// Inject the logger instance this will write directly to the Trados Studio log file
			_logger = logger;
		}
		/// <summary>
		/// Called when the view is shown.
		/// </summary>		
		public void Activate()
		{
			_logger.LogInformation("Demo plugin view activated.");
		}

		/// <summary>
		/// Called when the view is hidden.
		/// </summary>
		/// <returns></returns>		
		public bool Deactivate()
		{
			_logger.LogInformation("Demo plugin view deactivated.");
			return true;
		}

		public void Dispose()
		{
			/// clean up resources if needed
		}

		/// <summary>
		/// Gets the content control for the view.
		/// </summary>
		/// <returns>The content control.</returns>
		public IUIControl GetContentControl()
		{
			if (_contentControl == null)
			{
				_contentControl = new PluginViewUI();
			}
			return _contentControl;
		}

		/// <summary>
		/// Explorer bar control that is diplayed when the view is active.
		/// </summary>
		/// <returns></returns>
		public IUIControl GetExplorerBarControl()
		{
			/// Return the explorer bar control if needed
			return null;
		}

		/// <summary>
		/// Called when the view is intialized.
		/// </summary>
		public void OnInit()
		{
			/// Initialize the view if needed
			_logger.LogInformation("Demo plugin view initialized.");
		}
	}
}
