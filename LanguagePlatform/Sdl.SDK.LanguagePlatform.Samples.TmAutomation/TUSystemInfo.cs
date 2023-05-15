using System.Windows.Forms;
using Sdl.LanguagePlatform.TranslationMemory;
using Sdl.LanguagePlatform.TranslationMemoryApi;

namespace Sdl.SDK.LanguagePlatform.Samples.TmAutomation
{
	public class TUSystemInfo
	{
		#region "GetInfo"
		public void GetInfo(string tmPath)
		{
			#region "open"
			FileBasedTranslationMemory tm = new FileBasedTranslationMemory(tmPath);

			SearchResults results = tm.LanguageDirection.SearchText(GetSearchSettings(), "A dialog box will open.");
			#endregion

			#region "output"
			string tuInfo = string.Empty;
			foreach (SearchResult item in results)
			{
				if (item.ScoringResult.Match == 100)
				{
					TranslationUnit tu = item.MemoryTranslationUnit;
					SystemFields sysFields = tu.SystemFields;

					tuInfo = "Creation date: " + sysFields.CreationUser + "\n";
					tuInfo += "Creation user: " + sysFields.CreationUser + "\n";
					tuInfo += "Change date: " + sysFields.ChangeDate + "\n";
					tuInfo += "Change user: " + sysFields.ChangeUser + "\n";
					tuInfo += "Usage count: " + sysFields.UseCount + "\n";
					tuInfo += "Last used on: " + sysFields.UseDate + "\n";
					tuInfo += "Last used by: " + sysFields.UseUser + "\n";
					break;
				}
			}

			MessageBox.Show(tuInfo, "TU Information");
			#endregion
		}
		#endregion

		#region "settings"
		private SearchSettings GetSearchSettings()
		{
			SearchSettings settings = new SearchSettings
			{
				MinScore = 100
			};
			return settings;
		}
		#endregion
	}
}

