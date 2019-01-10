using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sdl.LanguagePlatform.TranslationMemoryApi;
using Sdl.Enterprise2.Studio.Platform.Client.IdentityModel;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using Sdl.LanguagePlatform.TranslationMemory;

namespace Sdl.SDK.LanguagePlatform.TMAutomation
{
    class ServerBasedTMHelper
    {
        private TextBox _output;
        private TranslationProviderServer _server;
        private UserManagerClient _userManager;
        private string _parentOrganizationPath;

        public string ParentOrganizationPath
        {
            get { return _parentOrganizationPath; }
            set { _parentOrganizationPath = value; }
        }

        private TranslationProviderServer TMServer
        {
            get 
            {
                if (_server == null)
                {
                    ConnectToServer();
                }
                return _server;
            }
            set
            {
                _server = value;
            }
        }
        
        public ServerBasedTMHelper(TextBox tb)
        {
            _output = tb;
        }

        public void DeleteLanguageTemplate()
        {
            ServerBasedLanguageResourcesTemplate template =
                TMServer.GetLanguageResourcesTemplate(ParentOrganizationPath + "/APISampleTemplate", LanguageResourcesTemplateProperties.None);
            
            if (template != null)
            {
                template.Delete();
                WriteResult("Template deleted\r\n");
            }
        }

        public void DeleteContainer()
        {
            TranslationMemoryContainer container = TMServer.GetContainer(ParentOrganizationPath + "/APITest", ContainerProperties.None);
            if (container != null)
            {
                container.Delete(true);
                WriteResult("Container deleted\r\n");
            }
        }

        public void DeleteTM()
        {
            ServerBasedTranslationMemory tm = TMServer.GetTranslationMemory(ParentOrganizationPath + "/APISampleTest", TranslationMemoryProperties.None);
            if (tm != null)
            {
                tm.Delete();
                WriteResult("TM deleted\r\n");
            }
        }

        public void ImportTMX(string importFilePath)
        {
            ServerBasedTranslationMemory tm = TMServer.GetTranslationMemory(ParentOrganizationPath + "/APISampleTest", TranslationMemoryProperties.All);
            ScheduledServerTranslationMemoryImport importer =
                new ScheduledServerTranslationMemoryImport(
                    GetLanguageDirection(tm, CultureInfo.GetCultureInfo("en-US"), CultureInfo.GetCultureInfo("de-DE")));
            importer.ChunkSize = 25; //25 is minimum
            importer.ContinueOnError = true;
            importer.Source = new FileInfo(importFilePath);
            AdaptImportSettigns(importer.ImportSettings);
            
            //add the import into the queue
            importer.Queue();
            
            //Wait until the import is finished
            bool continueWaiting = true;
            while (continueWaiting)
            {
                switch (importer.Status)
                {
                    case ScheduledOperationStatus.Abort:
                    case ScheduledOperationStatus.Aborted:
                    case ScheduledOperationStatus.Cancel:
                    case ScheduledOperationStatus.Cancelled:
                    case ScheduledOperationStatus.Completed:
                    case ScheduledOperationStatus.Error:
                        continueWaiting = false;
                        break;
                    case ScheduledOperationStatus.Aborting:
                    case ScheduledOperationStatus.Allocated:
                    case ScheduledOperationStatus.Cancelling:
                    case ScheduledOperationStatus.NotSet:
                    case ScheduledOperationStatus.Queued:
                    case ScheduledOperationStatus.Recovered:
                    case ScheduledOperationStatus.Recovering:
                    case ScheduledOperationStatus.Recovery:
                        continueWaiting = true;
                        importer.Refresh(); //refresh the state of the import
                        break;
                    default:
                        continueWaiting = false;
                        break;
                }
            }

            if (importer.Status == ScheduledOperationStatus.Completed)
            {
                WriteResult("Import successfuly finished.\r\n");
            }
            else if (importer.Status == ScheduledOperationStatus.Error)
            {
                WriteResult(importer.ErrorMessage);
            }
            else
            {
                WriteResult("Import didn't finish.\r\n");
            }
        }

        /// <summary>
        /// Change the default import settigns
        /// </summary>
        /// <param name="importSettings"></param>
        private void AdaptImportSettigns(Sdl.LanguagePlatform.TranslationMemory.ImportSettings importSettings)
        {
            if (importSettings == null)
            {
                importSettings = new ImportSettings();
            }
            importSettings.CheckMatchingSublanguages = true;
        }

        private ServerBasedTranslationMemoryLanguageDirection GetLanguageDirection(ServerBasedTranslationMemory tm, CultureInfo source, CultureInfo target)
        {
            foreach (ServerBasedTranslationMemoryLanguageDirection item in tm.LanguageDirections)
            {
                if (item.SourceLanguage == source && item.TargetLanguage == target)
                {
                    return item;
                }
            }

            throw new Exception("Requested direction doesn't exist.");
        }

        public void CreateNewTM()
        { 
            //Create a new testing container first
            TranslationMemoryContainer container = CreateContainer("APITest");

            //Test if TM already exists
            if (TMAlreadyExists("APISampleTest"))
            {
                throw new Exception("TM already exists!");
            }

            ServerBasedTranslationMemory newTM = new ServerBasedTranslationMemory(TMServer);
            newTM.Container = container;
            newTM.Name = "APISampleTest";
            newTM.Description = "A sample created as example of using TM API.";
            CreateLanguageDirections(newTM.LanguageDirections);
            newTM.LanguageResourcesTemplate = CreateLanguageResouceTemplate();
            newTM.ParentResourceGroupPath = ParentOrganizationPath;
            newTM.Save();

            WriteResult("TM APISampleTest was created\r\n");
        }

        private bool TMAlreadyExists(string tmName)
        {
            foreach (ServerBasedTranslationMemory item in TMServer.GetTranslationMemories(TranslationMemoryProperties.None))
            {
                if(item.Name == tmName)
                {
                    return true;
                }
            }
            return false;
        }

        private ServerBasedLanguageResourcesTemplate CreateLanguageResouceTemplate()
        {
            //check if the template already exists
            foreach (var item in TMServer.GetLanguageResourcesTemplates(LanguageResourcesTemplateProperties.None))
            {
                if (item.Name == "APISampleTemplate")
                {
                    return item;
                }
            }
            
            //our template doesn't work so create new one
            ServerBasedLanguageResourcesTemplate template = new ServerBasedLanguageResourcesTemplate(TMServer);
            template.Name = "APISampleTemplate";
            template.LanguageResourceBundles.Add(CreateDefaultBundle(CultureInfo.GetCultureInfo("en-US")));
            template.LanguageResourceBundles.Add(CreateDefaultBundle(CultureInfo.GetCultureInfo("de-DE")));
            template.ParentResourceGroupPath = ParentOrganizationPath;
            template.Save();

            return template;
        }

        private LanguageResourceBundle CreateDefaultBundle(CultureInfo cultureInfo)
        {
            //we can either create a bundle from scratch or use DefaultLanguageResourceProvider which allows us to access the default list
            DefaultLanguageResourceProvider defaultProvider = new DefaultLanguageResourceProvider();
            //as working with file based TM, we will create a bundle for source language
            LanguageResourceBundle bundle = defaultProvider.GetDefaultLanguageResources(cultureInfo);
            bundle.Abbreviations = new Sdl.LanguagePlatform.Core.Wordlist();
            bundle.Abbreviations.Add("SDL");
            return bundle;
        }

        private void CreateLanguageDirections(ServerBasedTranslationMemoryLanguageDirectionCollection directionsCollection)
        {
            ServerBasedTranslationMemoryLanguageDirection direction = new ServerBasedTranslationMemoryLanguageDirection();
            direction.SourceLanguage = CultureInfo.GetCultureInfo("en-US");
            direction.TargetLanguage = CultureInfo.GetCultureInfo("de-DE");

            directionsCollection.Add(direction);
        }

        private TranslationMemoryContainer CreateContainer(string newContainerName)
        {

            ReadOnlyCollection<DatabaseServer> dbs = TMServer.GetDatabaseServers(DatabaseServerProperties.Containers);
            if (dbs.Count == 0)
            {
                throw new Exception("No DB server registered.");
            }
            
            //pick first DB server and check if the new container name already exists
            foreach (var cnt in dbs[0].Containers)
            {
                if (cnt.Name == newContainerName)
                {
                    //container exists so let use it
                    return cnt;
                }
            }
            //set a parent organization variable, all operations will be performed in this organization
            ParentOrganizationPath = dbs[0].ParentResourceGroupPath;

            //now create a new container and add to the server
            TranslationMemoryContainer container = new TranslationMemoryContainer(TMServer);
            container.DatabaseServer = dbs[0];
            container.DatabaseName = newContainerName + "DB";
            container.Name = newContainerName;
            container.ParentResourceGroupPath = ParentOrganizationPath;
            container.Save();

            //now verify that the container was created sucessfully
            if (TMServer.GetContainer(ParentOrganizationPath + "/" + container.Name, ContainerProperties.None) == null)
            {
                throw new Exception("Container wasn't created.");
            }
            
            WriteResult("Container " + newContainerName + " was created successfully.\r\n");
            
            return container;
        }

        /// <summary>
        /// List all DB server on current TM server, but only access the basic properties
        /// </summary>
        public void GetAllDBServers()
        {
            foreach (DatabaseServer item in TMServer.GetDatabaseServers(DatabaseServerProperties.None))
            {
                WriteResult(item.Name + "\r\n");      
            } 
        }


        /// <summary>
        /// List all containers on current TM server, but only access the basic properties
        /// </summary>
        public void GetAllContainers()
        {
            foreach (TranslationMemoryContainer item in TMServer.GetContainers(ContainerProperties.None))
            {
                WriteResult(item.Name + " in DB " + item.DatabaseName + "\r\n");
            } 
        }

        /// <summary>
        /// List all TMs on the current TM server, but only access the basic properties
        /// </summary>
        public void GetAllTMs()
        {
            foreach (ServerBasedTranslationMemory item in TMServer.GetTranslationMemories(TranslationMemoryProperties.None))
            {
                //now I will access a contain property of the TM - as I specified TranslationMemoryProperties.None the sever will be called again
                //this can be avoided by calling TranslationMemoryProperties.Container directly
                WriteResult(item.Name+ " in container " + item.Container.Name + "\r\n");
            }
        }

        public delegate void WriteResultDelegate(string progress);

        public void WriteResult(string progress)
        {
            //If not on UI thread
            if (_output.InvokeRequired)
            {
                _output.Invoke(new WriteResultDelegate(WriteResult), new object[] { progress });
            }
            else
            {
                //Do work here - called on UI thread
                _output.Text += progress;
                _output.Refresh();
            };
        }

        /// <summary>
        /// Connect to a TM server
        /// </summary>
        private void ConnectToServer()
        {
            _server = new TranslationProviderServer(GetUri(),false,"sa","sa");
        }

        private Uri GetUri()
        {
            string address = @"http://perftest05.development.sheffield.sdl.corp:80"; // http://SERVERNAME:PORT
            return new Uri(address);
        }
    }
}

