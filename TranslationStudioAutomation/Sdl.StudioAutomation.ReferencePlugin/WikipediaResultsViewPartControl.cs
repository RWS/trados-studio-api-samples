using Sdl.Desktop.IntegrationApi.Interfaces;
using System.Windows.Forms;

namespace StudioIntegrationApiSample
{
    public partial class WikipediaResultsViewPartControl : UserControl, IUIControl
    {

        public WikipediaResultsViewPartControl()
        {
            InitializeComponent();
        }

        public void Navigate(string url)
        {
            _webBrowser.Navigate(url);
        }
    }
}
