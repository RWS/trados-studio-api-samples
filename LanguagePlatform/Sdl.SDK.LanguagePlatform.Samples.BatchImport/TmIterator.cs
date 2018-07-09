// ---------------------------------
// <copyright file="TMIterator.cs" company="SDL International">
// Copyright  2010 All Right Reserved
// </copyright>
// <author>Patrik Mazanek</author>
// <email>pmazanek@sdl.com</email>
// <date>2010-09-27</date>
// ---------------------------------
namespace Sdl.SDK.LanguagePlatform.Samples.BatchImporter
{
    using System;
    using System.IO;

    /// <summary>
    /// Represents class able to iterate thru disk directory tree.
    /// </summary>
    public class TMIterator
    {
        #region "constants"
        
        /// <summary>
        /// Determines how deep in the sub-folder structure the application should go.
        /// </summary>
        public const int Depth = 10;

        /// <summary>
        /// Determines current recursion level.
        /// </summary>
        private const int RecursionLevel = 1;
        #endregion

        #region "function"

        /// <summary>
        /// This function is used to iterate through the main folder and (if applicable) the subfolders to look for *.tmx import files.
        /// </summary>
        /// <param name="sourceDirectory">Directory to search in.</param>
        /// <param name="processSubFolders">True if subfolder processing required.</param>
        public void ProcessDir(string sourceDirectory, bool processSubFolders)
        #endregion
        {
            #region "scan"
            // Loop until the recursion level has reached the
            // maximum folder depth.
            if (RecursionLevel <= Depth)
            #endregion
            {
                #region "ProcessFiles"
                // Retrieve the names of the files found in the given folder.
                string[] fileEntries = Directory.GetFiles(sourceDirectory);
                foreach (string fileName in fileEntries)
                {
                    // Only process file if it is a TMX import file.
                    if (fileName.ToLower().EndsWith(".tmx"))
                    {
                        Console.WriteLine("Importing " + fileName);
                        TMImporter importTmx = new TMImporter();
                        importTmx.Import(fileName);
                    }
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
                            this.ProcessDir(subdir, processSubFolders);
                        }
                    }
                }
                #endregion
            }
        }
    }
}
