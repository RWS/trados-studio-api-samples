using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sdl.Sdk.FilterFramework.Samples.IdenticalCheck
{
    public partial class IdenticalCheckUI : UserControl
    {
        #region text field control
        /// <summary>
        /// Data binding for the text field control
        /// </summary>
        public string ContextToCheck
        {
            get
            {
                return this.txt_Context.Text;
            }
            set
            {
                txt_Context.Text = value;
            }
        }
        #endregion

        public IdenticalCheckUI()
        {
            InitializeComponent();
        }
    }
}
