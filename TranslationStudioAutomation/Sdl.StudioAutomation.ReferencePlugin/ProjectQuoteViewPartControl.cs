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
    public partial class ProjectQuoteViewPartControl : UserControl
    {
        private ProjectQuoteViewPartController _controller;

        public ProjectQuoteViewPartControl()
        {
            InitializeComponent();

            _dataGridView.CellFormatting += new DataGridViewCellFormattingEventHandler(_dataGridView_CellFormatting);
        }

        public ProjectQuoteViewPartController Controller
        {
            get
            {
                return _controller;
            }
            set
            {
                _controller = value;

                _dataGridView.DataSource = _controller.QuoteItems;
            }
        }

        void _dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex > 0)
            {
                double price = (double)_controller.QuoteItems.Rows[e.RowIndex][e.ColumnIndex];
                e.Value = String.Format("£{0:N1}", price);
            }
        }
    }
}
