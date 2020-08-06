// ---------------------------------
// <copyright file="TMIterator.cs" company="SDL International">
// Copyright  2020 All Right Reserved
// </copyright>
// <author>Kostiantyn Lukianets</author>
// <email>klukianets@sdl.com</email>
// <date>2010-09-27</date>
// ---------------------------------
namespace Sdl.SDK.LanguagePlatform.Samples.BatchExport
{
    using System;
    using System.IO;

    /// <summary>
    /// Represents functionality for importing *.tmx files into FileBasedTranslationMemory.
    /// </summary>
    public class TMIterator
    {
        #region "Constants"

        /// <summary>
        /// Determines how deep in the sub-folder structure
        /// the application should go.
        /// </summary>
        public const int Depth = 10;

        /// <summary>
        /// Determines current level of recursion when iterating thru subfolders.
        /// </summary>
        public const int RecursionLevel = 1;

        #endregion

        #region "Function"

        /// <summary>
        /// This function is used to iterate through the main folder and
        /// (if applicable) the subfolders to look for *.sdltm files to export.
        /// </summary>
        /// <param name="sourceDirectory">Directory to iterate thru.</param>
        /// <param name="processSubFolders">True if recursive teration thru subfolders is required.</param>
        public void ProcessDirectory(string sourceDirectory, bool processSubFolders)
        #endregion
        {
            #region "Scan"
            // Loop until the recursion level has reached the
            // maximum folder depth.
            if (RecursionLevel <= Depth)
            #endregion
            {
                #region "ProcessFiles"

                // Retrieve the TMX import file names found in the given folder.
                string[] fileEntries = Directory.GetFiles(sourceDirectory, "*.sdltm");
                foreach (string fileName in fileEntries)
                {
                    Console.WriteLine("Exporting " + fileName);
                    TMExporter exportTm = new TMExporter();
                    exportTm.Export(fileName);
                }

                #endregion

                #region "Recursion"

                // Self-recursion to loop through the folder structure until
                // the folder depth has reached the recursion level value.
                if (processSubFolders)
                {
                    string[] subdirEntries = Directory.GetDirectories(sourceDirectory);
                    foreach (string subdir in subdirEntries)
                    {
                        if ((File.GetAttributes(subdir) & FileAttributes.ReparsePoint) != FileAttributes.ReparsePoint)
                        {
                            ProcessDirectory(subdir, processSubFolders);
                        }
                    }
                }

                #endregion
            }
        }
    }
}
