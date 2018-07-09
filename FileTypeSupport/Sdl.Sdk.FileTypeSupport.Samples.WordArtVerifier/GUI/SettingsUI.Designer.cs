namespace Sdl.Sdk.FileTypeSupport.Samples.WordArtVerifier
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_MaxWordCount = new System.Windows.Forms.TextBox();
            this.cb_CheckWordArt = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_MaxWordCount);
            this.groupBox1.Controls.Add(this.cb_CheckWordArt);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(329, 338);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "WordArt Verifier";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Maximum number of words in WordArt objects:";
            // 
            // txt_MaxWordCount
            // 
            this.txt_MaxWordCount.Location = new System.Drawing.Point(237, 69);
            this.txt_MaxWordCount.Name = "txt_MaxWordCount";
            this.txt_MaxWordCount.Size = new System.Drawing.Size(42, 20);
            this.txt_MaxWordCount.TabIndex = 1;
            this.txt_MaxWordCount.Text = "3";
            this.txt_MaxWordCount.TextChanged += new System.EventHandler(this.txt_MaxWordCount_TextChanged);
            // 
            // cb_CheckWordArt
            // 
            this.cb_CheckWordArt.AutoSize = true;
            this.cb_CheckWordArt.Checked = true;
            this.cb_CheckWordArt.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_CheckWordArt.Location = new System.Drawing.Point(6, 30);
            this.cb_CheckWordArt.Name = "cb_CheckWordArt";
            this.cb_CheckWordArt.Size = new System.Drawing.Size(155, 17);
            this.cb_CheckWordArt.TabIndex = 0;
            this.cb_CheckWordArt.Text = "Enable WordArt verification";
            this.cb_CheckWordArt.UseVisualStyleBackColor = true;
            this.cb_CheckWordArt.CheckedChanged += new System.EventHandler(this.cb_CheckWordArt_CheckedChanged);
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
        private System.Windows.Forms.CheckBox cb_CheckWordArt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_MaxWordCount;
    }
}
