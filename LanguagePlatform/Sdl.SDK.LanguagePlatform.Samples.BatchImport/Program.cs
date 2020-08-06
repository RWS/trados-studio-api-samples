// ---------------------------------
// <copyright file="Program.cs" company="SDL International">
// Copyright  2020 All Right Reserved
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
    /// Main class of the program.
    /// </summary>
    public class Program
    {
        #region "main"

        /// <summary>
        /// Main entrance point of the application.
        /// </summary>
        /// <param name="args">String arguments passed via command line.</param>
        public static void Main(string[] args)
        {
            bool processSubFolders = false;

            if (args.Length != 2)
            {
                Console.WriteLine("Usage:");
                Console.WriteLine("Sdl.SDK.LanguagePlatform.Samples.BatchImport.exe source /ps");
                Console.WriteLine("source path to input folder");
                Console.WriteLine("/ps   should process subfolders");
                Console.WriteLine("This application uses a hard-coded recursion level of up to 10 sub-folders.");
                Console.WriteLine("The master TMs are created in a hard-coded location, i.e.: c:\\MasterTMs");
                return;
            }

            if (!string.IsNullOrEmpty(args[0]) && !Directory.Exists(args[0]))
            {
                Console.WriteLine("Specify a valid input directory. Press ENTER to exit.");
                return;
            }

            string mainPath = args[0];

            if (!string.IsNullOrEmpty(args[1]) && args[1] == "/ps")
            {
                processSubFolders = true;
            }

            try
            {
                TMIterator it = new TMIterator();
                it.ProcessDir(mainPath, processSubFolders);
                Console.WriteLine();
                Console.WriteLine("Batch import finished. Press ENTER to exit.");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Press ENTER to exit.");
                Console.ReadLine();
            }
        }

        #endregion
    }
}
