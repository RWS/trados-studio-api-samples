using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sdl.Desktop.IntegrationApi;
using Sdl.Desktop.IntegrationApi.Extensions;
using Sdl.TranslationStudioAutomation.IntegrationApi;
using System.Web;

namespace StudioIntegrationApiSample
{
    [ViewPart(
       Id = "WikipediaResultsViewPart",
       Name = "Wikipedia",
       Description = "Wikipedia Results",
       Icon = "Wikipedia_Icon")]
    [ViewPartLayout(Dock = DockType.Bottom, LocationByType = typeof(EditorController))]
    class WikipediaResultsViewPartController : AbstractViewPartController
    {
        protected override System.Windows.Forms.Control GetContentControl()
        {
            return _control.Value;
        }
                

        private readonly Lazy<WikipediaResultsViewPartControl> _control = new Lazy<WikipediaResultsViewPartControl>(() => new WikipediaResultsViewPartControl());

        public void Lookup(string query)
        {
            string url = String.Format("http://en.wikipedia.org/w/index.php?search={0}", HttpUtility.UrlEncode(query));

            _control.Value.Navigate(url);
        }


        protected override void Initialize()
        {
        }
    }
}
