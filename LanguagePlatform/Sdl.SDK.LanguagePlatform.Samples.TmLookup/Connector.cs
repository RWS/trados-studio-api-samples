using Sdl.LanguagePlatform.TranslationMemoryApi;
using System;
using System.Windows.Forms;

namespace Sdl.SDK.LanguagePlatform.Samples.TmLookup
{
    class Connector
    {
        #region "FileOrServer"
        /// <summary>
        /// Property to flag whether a file or server TM should be used for the search
        /// </summary> 
        public static bool Server
        {
            get;
            set;
        }
        #endregion

        #region "fileTM"
        /// <summary>
        /// The file TM object
        /// </summary> 
        public static FileBasedTranslationMemory FileTm
        {
            get;
            set;
        }
        #endregion

        #region "SelectFileTm"
        /// <summary>
        /// Select the file TM using the file name and path chosen by the user through the GUI.
        /// </summary>
        public void SelectFileTm(string tmPath)
        {
            FileTm = new FileBasedTranslationMemory(tmPath);
            Server = false;
        }
        #endregion

        #region "serverTM"
        /// <summary>
        /// The server TM object
        /// </summary>
        public static ServerBasedTranslationMemory ServerTM
        {
            get;
            set;
        }
        #endregion

        #region "connect"
        /// <summary>
        /// Establishing a connection to the TM Server.
        /// This connection is primarily needed for populating the 
        /// TM dropdown list with the TM names.
        /// </summary>
        public void Connect(string serverUri, string userName, string password, ComboBox tmList)
        {
            try
            {
                var tmServer = new TranslationProviderServer(GetUri(serverUri), false, userName, password);
                foreach (ServerBasedTranslationMemory item in tmServer.GetTranslationMemories())
                {
                    //Resolve path to the TM inclusive name of the organization(s)
                    string tmPath = item.ParentResourceGroupPath == "/" ? "" : item.ParentResourceGroupPath;
                    tmList.Items.Add(tmPath + "/" + item.Name);
                }

                if (tmList.Items.Count > 0)
                {
                    tmList.Enabled = true;
                    tmList.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        #endregion

        #region "Uri"
        /// <summary>
        /// Returns the address of the TM Server.
        /// </summary>
        private Uri GetUri(string uri)
        {
            return new Uri(uri);
        }
        #endregion

        #region "SelectServerTm"
        /// <summary>
        /// Selects the particular server TM as chosen by the user through the dropdown list.
        /// </summary>
        public void SelectServerTm(string tmName, string uri, string userName, string password)
        {
            var tmServer = new TranslationProviderServer(GetUri(uri), false, userName, password);
            ServerTM = tmServer.GetTranslationMemory(tmName,
                TranslationMemoryProperties.None);
            Server = true;
        }
        #endregion
    }
}
