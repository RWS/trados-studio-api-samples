using System;
using Sdl.LanguagePlatform.TranslationMemoryApi;

namespace Sdl.SDK.LanguagePlatform.Samples.TmAutomation
{
	/// <summary>
	/// Functionality to provide server connection operations.
	/// </summary>
	public class ServerConnector
	{
		private readonly string _serverUri = "http://testserver.test.corp/";
		private readonly string _organizationPath = "/My Organisation/My SubOrganization/";
		private readonly string _temporaryTranslationMemory = "TestTm1";
		private readonly string _existingTranslationMemory = "My TM En-De";
		private readonly string _userName = "username";
		private readonly string _password = "password";
		private readonly string _importFileName = @"c:\temp\sample.tmx";
		private readonly string _exportFileName = @"c:\temp\sampleExport.tmx";
		private readonly string _existingContainer = "My TM Container";
		private readonly string _temporaryContainer = "TestContainer1";

		#region "connect"
		/// <summary>
		/// Connects to TranslationProviderServer.
		/// </summary>
		public TranslationProviderServer Connect()
		{
			return new TranslationProviderServer(GetUri(), false, _userName, _password);
		}
		#endregion

		#region "uri"
		/// <summary>
		/// Gets adress of a test server to connect to.
		/// </summary>
		/// <returns>Adress of the test server.</returns>
		private Uri GetUri()
		{
			return new Uri(_serverUri);
		}
		#endregion

		/// <summary>
		/// Tests connection to TranslationProviderServer.
		/// </summary>
		public void Test(TranslationProviderServer tmServer)
		{
			#region "license"
			ServerLicensing license = new ServerLicensing();
			license.GetLicensingInformation(tmServer);
			#endregion

			#region "dbservers"
			ServerDBServers dbServ = new ServerDBServers();
			dbServ.GetDBServers(tmServer);
			#endregion

			#region "containers"
			ServerContainers containers = new ServerContainers();
			containers.GetDBContainers(tmServer);
			#endregion

			#region "CreateContainer"
			ServerContainer newContainer = new ServerContainer();
			newContainer.CreateAdvanced(tmServer, _organizationPath, _temporaryContainer);
			#endregion

			#region "DeleteContainer"
			newContainer.DeleteContainer(tmServer, _organizationPath, _temporaryContainer);
			#endregion

			#region "CreateTm"
			ServerTmCreator newTm = new ServerTmCreator();
			newTm.Create(tmServer, _organizationPath, _existingContainer, _temporaryTranslationMemory);
			#endregion

			#region "DeleteTm"
			newTm.DeleteTm(tmServer, _organizationPath, _temporaryTranslationMemory);
			#endregion

			#region "export"
			ServerExporter export = new ServerExporter();
			export.ExportToTmx(tmServer, _organizationPath, _existingTranslationMemory, _exportFileName);
			#endregion

			#region "import"
			ServerImporter import = new ServerImporter();
			import.ImportTmx(tmServer, _organizationPath, _existingTranslationMemory, _importFileName);
			#endregion
		}
	}
}
