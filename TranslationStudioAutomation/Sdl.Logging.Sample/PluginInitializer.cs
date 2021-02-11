using Sdl.Desktop.IntegrationApi;
using Sdl.Desktop.IntegrationApi.Extensions;
using Sdl.Desktop.IntegrationApi.Interfaces;

namespace Sdl.Logging.Sample
{
    [ApplicationInitializer]
    public class PluginInitializer : IApplicationInitializer
    {
        private readonly IPluginLog _log;

        public PluginInitializer(IPluginLoggerFactory loggerFactory)
        {
            _log = loggerFactory.GetLogger(nameof(PluginInitializer));
        }

        public void Execute()
        {
            _log.Info("Plugin initialized !");
        }
    }
}
