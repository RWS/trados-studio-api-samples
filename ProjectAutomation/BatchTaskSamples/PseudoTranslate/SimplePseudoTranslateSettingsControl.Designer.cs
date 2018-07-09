namespace Sdl.SDK.BatchTasks.Samples.PseudoTranslation
{
    partial class SimplePseudoTranslateSettingsControl
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonRandomText = new System.Windows.Forms.RadioButton();
            this.radioButtonCopySource = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxAppendStart = new System.Windows.Forms.TextBox();
            this.textBoxAppendEnd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButtonDraft = new System.Windows.Forms.RadioButton();
            this.radioButtonNoChange = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.61394F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.38606F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBoxAppendStart, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxAppendEnd, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(373, 341);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox1, 2);
            this.groupBox1.Controls.Add(this.radioButtonRandomText);
            this.groupBox1.Controls.Add(this.radioButtonCopySource);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(367, 46);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Target content";
            // 
            // radioButtonRandomText
            // 
            this.radioButtonRandomText.AutoSize = true;
            this.radioButtonRandomText.Location = new System.Drawing.Point(193, 20);
            this.radioButtonRandomText.Name = "radioButtonRandomText";
            this.radioButtonRandomText.Size = new System.Drawing.Size(89, 17);
            this.radioButtonRandomText.TabIndex = 1;
            this.radioButtonRandomText.Text = "Random Text";
            this.radioButtonRandomText.UseVisualStyleBackColor = true;
            // 
            // radioButtonCopySource
            // 
            this.radioButtonCopySource.AutoSize = true;
            this.radioButtonCopySource.Checked = true;
            this.radioButtonCopySource.Location = new System.Drawing.Point(7, 20);
            this.radioButtonCopySource.Name = "radioButtonCopySource";
            this.radioButtonCopySource.Size = new System.Drawing.Size(86, 17);
            this.radioButtonCopySource.TabIndex = 0;
            this.radioButtonCopySource.TabStop = true;
            this.radioButtonCopySource.Text = "Copy Source";
            this.radioButtonCopySource.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "Append end:";
            // 
            // textBoxAppendStart
            // 
            this.textBoxAppendStart.Location = new System.Drawing.Point(105, 55);
            this.textBoxAppendStart.Name = "textBoxAppendStart";
            this.textBoxAppendStart.Size = new System.Drawing.Size(243, 20);
            this.textBoxAppendStart.TabIndex = 3;
            // 
            // textBoxAppendEnd
            // 
            this.textBoxAppendEnd.Location = new System.Drawing.Point(105, 81);
            this.textBoxAppendEnd.Name = "textBoxAppendEnd";
            this.textBoxAppendEnd.Size = new System.Drawing.Size(243, 20);
            this.textBoxAppendEnd.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Append start:";
            // 
            // groupBox2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox2, 2);
            this.groupBox2.Controls.Add(this.radioButtonNoChange);
            this.groupBox2.Controls.Add(this.radioButtonDraft);
            this.groupBox2.Location = new System.Drawing.Point(3, 107);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(367, 48);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Change confirmation level after target updated";
            // 
            // radioButtonDraft
            // 
            this.radioButtonDraft.AutoSize = true;
            this.radioButtonDraft.Location = new System.Drawing.Point(11, 20);
            this.radioButtonDraft.Name = "radioButtonDraft";
            this.radioButtonDraft.Size = new System.Drawing.Size(62, 17);
            this.radioButtonDraft.TabIndex = 0;
            this.radioButtonDraft.TabStop = true;
            this.radioButtonDraft.Text = "To draft";
            this.radioButtonDraft.UseVisualStyleBackColor = true;
            // 
            // radioButtonNoChange
            // 
            this.radioButtonNoChange.AutoSize = true;
            this.radioButtonNoChange.Location = new System.Drawing.Point(183, 20);
            this.radioButtonNoChange.Name = "radioButtonNoChange";
            this.radioButtonNoChange.Size = new System.Drawing.Size(74, 17);
            this.radioButtonNoChange.TabIndex = 1;
            this.radioButtonNoChange.TabStop = true;
            this.radioButtonNoChange.Text = "Keep as is";
            this.radioButtonNoChange.UseVisualStyleBackColor = true;
            // 
            // SimplePseudoTranslateSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SimplePseudoTranslateSettingsControl";
            this.Size = new System.Drawing.Size(373, 341);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonRandomText;
        private System.Windows.Forms.RadioButton radioButtonCopySource;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxAppendStart;
        private System.Windows.Forms.TextBox textBoxAppendEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButtonNoChange;
        private System.Windows.Forms.RadioButton radioButtonDraft;
    }
}
