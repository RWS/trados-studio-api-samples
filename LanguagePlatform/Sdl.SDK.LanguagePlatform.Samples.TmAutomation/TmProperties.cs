using System;
using System.Windows.Forms;
using Sdl.LanguagePlatform.TranslationMemoryApi;

namespace Sdl.SDK.LanguagePlatform.Samples.TmAutomation
{
	public class TMProperties
	{
		public void GetAndSetProperties(string tmPath)
		{
			FileBasedTranslationMemory tm = new FileBasedTranslationMemory(tmPath);

			#region "set"
			tm.Description = "This is the TM description.";
			tm.Copyright = "(c) 2010 SDL International";
			tm.ExpirationDate = DateTime.Now.AddDays(7);
			#endregion

			#region "get"
			string tmInfo;
			tmInfo = "TU count: " + tm.GetTranslationUnitCount().ToString();
			tmInfo += "; Password-protected: " + tm.IsProtected.ToString();
			tmInfo += "; Expires on: " + tm.ExpirationDate.ToString();
			MessageBox.Show(tmInfo);
			#endregion
		}
	}
}
