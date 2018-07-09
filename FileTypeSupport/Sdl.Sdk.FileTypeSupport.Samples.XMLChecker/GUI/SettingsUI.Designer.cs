namespace Sdl.Sdk.FileTypeSupport.Samples.XMLChecker
{
    partial class SettingsUI
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cb_Enable = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_Enable);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(329, 338);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "XML Length Verification";
            // 
            // cb_Enable
            // 
            this.cb_Enable.AutoSize = true;
            this.cb_Enable.Checked = true;
            this.cb_Enable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_Enable.Location = new System.Drawing.Point(6, 19);
            this.cb_Enable.Name = "cb_Enable";
            this.cb_Enable.Size = new System.Drawing.Size(113, 17);
            this.cb_Enable.TabIndex = 0;
            this.cb_Enable.Text = "&Enable verification";
            this.cb_Enable.UseVisualStyleBackColor = true;
            this.cb_Enable.CheckedChanged += new System.EventHandler(this.cb_Enable_CheckedChanged);
            // 
            // SettingsUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "SettingsUI";
            this.Size = new System.Drawing.Size(329, 338);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cb_Enable;
    }
}
