namespace Sdl.Sdk.FileTypeSupport.Samples.SimpleText.WinUI
{
    partial class SettingsUIExtended
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
            this.txt_PrdCodePrefix = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_LockPrdCodes = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_PrdCodePrefix);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cb_LockPrdCodes);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(370, 308);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lock content";
            // 
            // txt_PrdCodePrefix
            // 
            this.txt_PrdCodePrefix.Location = new System.Drawing.Point(117, 63);
            this.txt_PrdCodePrefix.Name = "txt_PrdCodePrefix";
            this.txt_PrdCodePrefix.Size = new System.Drawing.Size(174, 20);
            this.txt_PrdCodePrefix.TabIndex = 2;
            this.txt_PrdCodePrefix.TextChanged += new System.EventHandler(this.Txt_PrdCodePrefix_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Product code prefix:";
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
            this.cb_LockPrdCodes.CheckedChanged += new System.EventHandler(this.Cb_LockPrdCodes_CheckedChanged);
            // 
            // SettingsUIExtended
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "SettingsUIExtended";
            this.Size = new System.Drawing.Size(392, 332);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cb_LockPrdCodes;
        private System.Windows.Forms.TextBox txt_PrdCodePrefix;
        private System.Windows.Forms.Label label1;
    }
}
