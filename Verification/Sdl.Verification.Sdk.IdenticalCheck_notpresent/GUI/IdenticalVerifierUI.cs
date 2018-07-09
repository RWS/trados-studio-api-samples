using System.Windows.Forms;

namespace Sdl.Verification.Sdk.IdenticalCheck
{
    public partial class IdenticalVerifierUI : UserControl
    {
        #region text field control
        // Data binding for the text field control
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

        public IdenticalVerifierUI()
        {
            InitializeComponent();
        }
    }
}
