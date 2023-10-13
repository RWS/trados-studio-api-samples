using Sdl.TranslationStudioAutomation.Licensing;
using System;

namespace Sdl.SDK.ProjectAutomation.Samples.Examples
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine(@"Before you start:
    1. Copy the files from the folder SampleFiles located in this repo
    2. Paste them in C:\ so you will have C:\ProjectFiles with those files inside ( C:\ProjectFiles\Documents,  C:\ProjectFiles\Tms etc)
    3. Make sure that 'Documents\Studio 2022\Projects\My First Project' is empty
            ");
                Console.WriteLine("Press Enter to start...");
                Console.ReadLine();

                ProjectCreator proj = new ProjectCreator();
                var projectPath = proj.CreateProject();

                Console.WriteLine("Steps have run succesfully");

                // Delete project
                Console.WriteLine("Do you want to delete the newly created project? (y/n)");
                var deleteProject = Console.ReadLine();
                if (!string.IsNullOrEmpty(deleteProject) && deleteProject.ToLower() == "y")
                {
                    var deletedSuccesfully = proj.DeleteProject(projectPath);
                    Console.WriteLine(deletedSuccesfully
                        ? "Project has been deleted succesfully"
                        : "Error in deleteing the project");
                }
                else
                {
                    // delete file in project
                    Console.WriteLine("Do you want to the file 'Configuration.doc' from the project? (y/n)");
                    var deleteFileInProject = Console.ReadLine();
                    if (!string.IsNullOrEmpty(deleteFileInProject) && deleteFileInProject.ToLower() == "y")
                    {
                        var deletedSuccesfully = proj.DeleteFileAndDependencies(projectPath, "Configuration.doc");
                        Console.WriteLine(deletedSuccesfully
                            ? "File 'Configuration.doc' has been deleted succesfully"
                            : "Error in deleteing the file 'Configuration.doc'");
                    }
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
            }
            finally
            {
                LicenseManager.ReleaseLicense();
            }
        }
    }
}
