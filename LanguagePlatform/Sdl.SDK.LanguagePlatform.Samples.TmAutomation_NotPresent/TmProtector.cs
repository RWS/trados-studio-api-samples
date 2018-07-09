namespace Sdl.SDK.LanguagePlatform.Samples.TmAutomation
{
    using System;
    using System.Windows.Forms;
    using Sdl.LanguagePlatform.TranslationMemoryApi;

    public class TMProtector
    {
        #region "assign"
        public void AssignPasswords(string tmPath)
        {
            FileBasedTranslationMemory tm = new FileBasedTranslationMemory(tmPath);

            tm.SetAdministratorPassword("super");
            tm.SetMaintenancePassword("maintain");
            tm.SetReadWritePassword("translator");
            tm.SetReadOnlyPassword("guest");
            tm.Save();

            this.OpenProtectedTm(tmPath, "super");
        }
        #endregion

        #region "openTMwithPW"
        private void OpenProtectedTm(string tmPath, string password)
        {
            try
            {
                FileBasedTranslationMemory tm = new FileBasedTranslationMemory(tmPath, password);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
    }
}
