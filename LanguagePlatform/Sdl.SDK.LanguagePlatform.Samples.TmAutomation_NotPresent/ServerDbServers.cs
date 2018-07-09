namespace Sdl.SDK.LanguagePlatform.Samples.TmAutomation
{
    using System.Windows.Forms;
    using Sdl.LanguagePlatform.TranslationMemoryApi;

    public class ServerDBServers
    {
        #region "get"
        public void GetDBServers(TranslationProviderServer tmServer)
        {
            string serverInfo = string.Empty;

            foreach (DatabaseServer dbServer in tmServer.GetDatabaseServers(DatabaseServerProperties.None))
            {
                serverInfo += "Server name: " + dbServer.ServerName + "\n";
                serverInfo += "Friendly server name: " + dbServer.Name + "\n";
                serverInfo += "Server description: " + dbServer.Description + "\n";
                serverInfo += "Server type: " + dbServer.ServerType + "\n\n";
            }

            MessageBox.Show(serverInfo, "Container Information");
        }
        #endregion
    }
}
