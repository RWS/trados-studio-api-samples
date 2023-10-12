using Sdl.TranslationStudioAutomation.Licensing;

namespace Sdl.ProjectAutomation.ProjectOperations.Logic
{
    public class LicenseHelper
    {
        public static void ReleaseLicense()
        {
            // Project Automation API requires a Studio license (Product key, network license or subscription).
            // The license is automatically initialized with the first call into the API.
            // At application closing, we need to gracefully release the license.
            // Failing to release the license will block the license on the current machine for up to 30 minutes.
            LicenseManager.ReleaseLicense();
        }
    }
}
