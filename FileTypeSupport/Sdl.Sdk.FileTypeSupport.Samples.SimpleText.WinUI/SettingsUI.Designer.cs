namespace Sdl.Sdk.FileTypeSupport.Samples.SimpleText.WinUI
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
            this.cb_LockPrdCodes = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_LockPrdCodes);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(370, 308);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lock content";
            // 
            // cb_LockPrdCodes
            // 
            this.cb_LockPrdCodes.AutoSize = true;
            this.cb_LockPrdCodes.Checked = true;
            this.cb_LockPrdCodes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_LockPrdCodes.Location = new System.Drawing.Point(12, 34);
            this.cb_LockPrdCodes.Name = "cb_LockPrdCodes";
            this.cb_LockPrdCodes.Size = new System.Drawing.Size(121, 17);
            this.cb_LockPrdCodes.TabIndex = 0;
            this.cb_LockPrdCodes.Text = "Lock product codes";
            this.cb_LockPrdCodes.UseVisualStyleBackColor = true;
            this.cb_LockPrdCodes.CheckedChanged += new System.EventHandler(this.cb_LockPrdCodes_CheckedChanged);
            // 
            // SettingsUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "SettingsUI";
            this.Size = new System.Drawing.Size(392, 332);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cb_LockPrdCodes;
    }
}
