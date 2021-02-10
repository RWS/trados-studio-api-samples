using Sdl.Desktop.IntegrationApi;
using Sdl.Desktop.IntegrationApi.Extensions;
using Sdl.Desktop.IntegrationApi.Interfaces;
using System;
using System.Windows.Forms;

namespace Sdl.Logging.Sample
{
    [Action("MyAddLoggingAction", Icon = "MyAction_Icon", Name = "MyAddLoggingAction_Name", Description = "MyAddLoggingAction_Description")]
    [ActionLayout(typeof(MySampleRibbonGroup), 10, DisplayType.Large)]
    public class AddToLogAction : AbstractAction
    {
        private readonly IPluginLog _pluginLog;

        public AddToLogAction(IPluginLoggerFactory loggerFactory)
        {
            _pluginLog = loggerFactory.GetLogger(nameof(AddToLogAction));
        }

        protected override void Execute()
        {
            // To change the overall logging level you can manually edit SDLTradosStudio.exe.config
            // Simply set <level value="INFO" /> from the <root> element of the <log4net> section to
            // one of the available levels (listed from lowest to highest priority): 
            // ALL (lowest priority), DEBUG, INFO, WARN, ERROR, FATAL, OFF (highest priority).
            // Logs with a lower priority level than the one specified in the config will not be 
            // written to the log file.

            _pluginLog.Debug("This is a debug message ! ");

            _pluginLog.Info("This is an info message ! ");

            _pluginLog.Warn("This is a warning message ! ");

            _pluginLog.Error("This is an error message ! ");

            _pluginLog.Fatal("This is a fatal message ! ");

            try
            {
                FailingMethod();
            }
            catch (NotImplementedException ex)
            {
                _pluginLog.Error("Logging exception", ex);
            }

            MessageBox.Show("We generated some logs. Check the log file");
        }

        private void FailingMethod()
        {
            throw new NotImplementedException("This will be logged with stack trace");
        }
    }
}
