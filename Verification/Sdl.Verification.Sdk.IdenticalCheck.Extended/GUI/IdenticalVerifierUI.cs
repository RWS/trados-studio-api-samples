using System.Windows.Forms;

namespace Sdl.Verification.Sdk.IdenticalCheck.Extended
{
    public partial class IdenticalVerifierUI : UserControl
    {
        #region "text field control"
        /// <summary>
        /// Data binding for the text field control
        /// </summary>
        public string ContextToCheck
        {
            get
            {
                return txt_Context.Text;
            }
            set
            {
                txt_Context.Text = value;
            }
        }
        #endregion

        #region "check box control"
        public bool ConsiderTags
        {
            get
            {
                return cb_ConsiderTags.Checked;
            }
            set
            {
                cb_ConsiderTags.Checked = value;
            }

        }
        #endregion


        public IdenticalVerifierUI()
        {
            InitializeComponent();
        }
    }
}
