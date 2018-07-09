namespace Sdl.Verification.Sdk.IdenticalCheck.Extended.MessageUI
{
    partial class IdenticalVerifierMessageUI
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel_Original = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_ErrorDetails = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panel_Original
            // 
            this.panel_Original.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_Original.Location = new System.Drawing.Point(4, 20);
            this.panel_Original.Name = "panel_Original";
            this.panel_Original.Size = new System.Drawing.Size(383, 87);
            this.panel_Original.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Target segment:";
            // 
            // tb_ErrorDetails
            // 
            this.tb_ErrorDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_ErrorDetails.Location = new System.Drawing.Point(3, 134);
            this.tb_ErrorDetails.Multiline = true;
            this.tb_ErrorDetails.Name = "tb_ErrorDetails";
            this.tb_ErrorDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_ErrorDetails.Size = new System.Drawing.Size(383, 138);
            this.tb_ErrorDetails.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Error details:";
            // 
            // IdenticalVerifierMessageUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_ErrorDetails);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel_Original);
            this.MinimumSize = new System.Drawing.Size(392, 275);
            this.Name = "IdenticalVerifierMessageUI";
            this.Size = new System.Drawing.Size(392, 275);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_Original;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_ErrorDetails;
        private System.Windows.Forms.Label label2;
    }
}
