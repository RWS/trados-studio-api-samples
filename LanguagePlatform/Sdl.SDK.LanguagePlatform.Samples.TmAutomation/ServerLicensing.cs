using System.Windows.Forms;
using Sdl.LanguagePlatform.TranslationMemoryApi;

namespace Sdl.SDK.LanguagePlatform.Samples.TmAutomation
{
	public class ServerLicensing
	{
		public void GetLicensingInformation(TranslationProviderServer tmServer)
		{
			string licInfo = string.Empty;
			LicensingStatusInformation info;
			info = tmServer.GetLicensingStatusInformation();

			licInfo += "Max. concurrent users: " + info.MaxConcurrentUsers.ToString();
			licInfo += "Max. TU count: " + info.MaxTranslationUnitCount.ToString();
			licInfo += "Current TU count: " + info.CurrentTranslationUnitCount.ToString();

			MessageBox.Show(licInfo, "Licensing Information");
		}
	}
}
