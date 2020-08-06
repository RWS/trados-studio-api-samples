namespace Sdl.Sdk.LanguagePlatform.Samples.ListProvider
{
    partial class ListProviderConfDialog
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListProviderConfDialog));
            this.txt_ListFile = new System.Windows.Forms.TextBox();
            this.btn_Browse = new System.Windows.Forms.Button();
            this.dlg_OpenFile = new System.Windows.Forms.OpenFileDialog();
            this.bnt_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.combo_delimiter = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_ListFile
            // 
            this.txt_ListFile.Location = new System.Drawing.Point(6, 28);
            this.txt_ListFile.Name = "txt_ListFile";
            this.txt_ListFile.Size = new System.Drawing.Size(327, 20);
            this.txt_ListFile.TabIndex = 0;
            // 
            // btn_Browse
            // 
            this.btn_Browse.Location = new System.Drawing.Point(339, 28);
            this.btn_Browse.Name = "btn_Browse";
            this.btn_Browse.Size = new System.Drawing.Size(36, 23);
            this.btn_Browse.TabIndex = 1;
            this.btn_Browse.Text = "...";
            this.btn_Browse.UseVisualStyleBackColor = true;
            this.btn_Browse.Click += new System.EventHandler(this.Btn_Browse_Click);
            // 
            // dlg_OpenFile
            // 
            this.dlg_OpenFile.Filter = "Delimited list files (*.txt)|*.txt";
            // 
            // bnt_OK
            // 
            this.bnt_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bnt_OK.Location = new System.Drawing.Point(247, 133);
            this.bnt_OK.Name = "bnt_OK";
            this.bnt_OK.Size = new System.Drawing.Size(75, 23);
            this.bnt_OK.TabIndex = 3;
            this.bnt_OK.Text = "&OK";
            this.bnt_OK.UseVisualStyleBackColor = true;
            this.bnt_OK.Click += new System.EventHandler(this.Bnt_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(328, 133);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 4;
            this.btn_Cancel.Text = "&Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_ListFile);
            this.groupBox1.Controls.Add(this.btn_Browse);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(391, 69);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Delimited text file";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Delimiter character";
            // 
            // combo_delimiter
            // 
            this.combo_delimiter.FormattingEnabled = true;
            this.combo_delimiter.Items.AddRange(new object[] {
            ";",
            ":",
            "=",
            "\\t"});
            this.combo_delimiter.Location = new System.Drawing.Point(116, 89);
            this.combo_delimiter.Name = "combo_delimiter";
            this.combo_delimiter.Size = new System.Drawing.Size(43, 21);
            this.combo_delimiter.TabIndex = 7;
            this.combo_delimiter.Text = ";";
            // 
            // ListProviderConfDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 166);
            this.Controls.Add(this.combo_delimiter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.bnt_OK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ListProviderConfDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Delimited List Provider Options";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btn_Browse;
        private System.Windows.Forms.OpenFileDialog dlg_OpenFile;
        private System.Windows.Forms.Button bnt_OK;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_ListFile;
        private System.Windows.Forms.ComboBox combo_delimiter;
    }
}