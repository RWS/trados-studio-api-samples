using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Sdl.CustomWizardSteps.Sample
{
    internal class Browser
    {
        internal void OpenUrl(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch (Win32Exception winEx) // noBrowser
            {
                Debug.WriteLine(winEx.Message);
            }
            catch (Exception ex)  // other
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
