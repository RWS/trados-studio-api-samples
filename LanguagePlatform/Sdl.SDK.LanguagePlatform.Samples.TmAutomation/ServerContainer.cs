namespace Sdl.SDK.LanguagePlatform.Samples.TmAutomation
{
    using System;
    using System.Collections.ObjectModel;
    using Sdl.LanguagePlatform.TranslationMemoryApi;

    public class ServerContainer
    {
        #region "CreateSimple"
        public void Create(TranslationProviderServer tmServer)
        {
            TranslationMemoryContainer container = new TranslationMemoryContainer(tmServer);

            DatabaseServer dbServ = tmServer.GetDatabaseServer("DB01", GetDbServProperties());
            container.DatabaseServer = dbServ;
            container.DatabaseName = "DbName";
            container.Name = "NiceName";
            container.Save();
        }
        #endregion

        #region "props"
        private DatabaseServerProperties GetDbServProperties()
        {
            DatabaseServerProperties props = new DatabaseServerProperties();

            return props;
        }
        #endregion

        #region "CreateAdvanced"
        public void CreateAdvanced(TranslationProviderServer tmServer, string organization, string newContainerName)
        {
            #region "count"
            ReadOnlyCollection<DatabaseServer> dbs = tmServer.GetDatabaseServers(DatabaseServerProperties.Containers);
            if (dbs.Count == 0)
            {
                throw new Exception("No DB server registered.");
            }
            #endregion

            #region "CheckExists"
            foreach (TranslationMemoryContainer item in dbs[0].Containers)
            {
                if (item.Name == newContainerName)
                {
                    throw new Exception("Container with that name already exists.");
                }
            }
            #endregion

            #region "CreateContainer"
            TranslationMemoryContainer container = new TranslationMemoryContainer(tmServer);
            container.DatabaseServer = dbs[0];
            container.DatabaseName = newContainerName + "DB";
            container.Name = newContainerName;
            container.ParentResourceGroupPath = organization;
            container.Save();
            #endregion

            #region "CheckCreated"
            if (!dbs[0].Containers.Contains(container))
            {
                throw new Exception("Container was not created.");
            }
            #endregion
        }
        #endregion

        #region "DeleteContainer"
        public void DeleteContainer(TranslationProviderServer tmServer, string organization, string containerName)
        {
            if (!organization.EndsWith("/")) 
                organization += "/";
            TranslationMemoryContainer container = tmServer.GetContainer(organization + containerName, ContainerProperties.None);
            container.Delete(false);
        }
        #endregion
    }
}
