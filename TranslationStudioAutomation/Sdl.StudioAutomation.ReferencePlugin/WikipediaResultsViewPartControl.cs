using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StudioIntegrationApiSample
{
    public partial class WikipediaResultsViewPartControl : UserControl
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
