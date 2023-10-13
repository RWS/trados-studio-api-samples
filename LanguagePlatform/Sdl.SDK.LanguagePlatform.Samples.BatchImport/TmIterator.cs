using System;
using System.IO;

namespace Sdl.SDK.LanguagePlatform.Samples.BatchImporter
{
    /// <summary>
    /// Represents class able to iterate thru disk directory tree.
    /// </summary>
    public class TMIterator
    {
        /// <summary>
        /// Determines how deep in the sub-folder structure the application should go.
        /// </summary>
        public const int Depth = 10;

        /// <summary>
        /// This function is used to iterate through the main folder and (if applicable) the subfolders to look for *.tmx import files.
        /// </summary>
        /// <param name="sourceDirectory">Directory to search in.</param>
        /// <param name="processSubFolders">True if subfolder processing required.</param>
        /// <param name="recursionLevel">Determines current level of recursion when iterating through subfolders.</param>
        public void ProcessDir(string sourceDirectory, bool processSubFolders, int recursionLevel = 1)
        {
            #region "scan"
            // Loop until the recursion level has reached the
            // maximum folder depth.
            if (recursionLevel <= Depth)
            #endregion
            {
                #region "ProcessFiles"
                // Retrieve the TMX import file names found in the given folder.
                string[] fileEntries = Directory.GetFiles(sourceDirectory, "*.tmx");
                foreach (string fileName in fileEntries)
                {
                    Console.WriteLine("Importing " + fileName);
                    TMImporter importTmx = new TMImporter();
                    importTmx.Import(fileName);
                }
                #endregion

                #region "recursion"
                // Self-recursion to loop through the folder structure until
                // the folder depth has reached the recursion level value.
                if (processSubFolders)
                {
                    string[] subdirEntries = Directory.GetDirectories(sourceDirectory);
                    foreach (string subdir in subdirEntries)
                    {
                        if ((File.GetAttributes(subdir) & FileAttributes.ReparsePoint) != FileAttributes.ReparsePoint)
                        {
                            ProcessDir(subdir, processSubFolders, recursionLevel + 1);
                        }
                    }
                }
                #endregion
            }
        }
    }
}