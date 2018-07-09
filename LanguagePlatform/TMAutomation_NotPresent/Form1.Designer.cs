namespace Sdl.SDK.LanguagePlatform.TMAutomation
{
    partial class Form1
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
            this.b_Start = new System.Windows.Forms.Button();
            this.tb_Results = new System.Windows.Forms.TextBox();
            this.rb_server = new System.Windows.Forms.RadioButton();
            this.rb_file = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_output = new System.Windows.Forms.TextBox();
            this.b_Browse = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // b_Start
            // 
            this.b_Start.Location = new System.Drawing.Point(314, 320);
            this.b_Start.Name = "b_Start";
            this.b_Start.Size = new System.Drawing.Size(75, 23);
            this.b_Start.TabIndex = 0;
            this.b_Start.Text = "Start";
            this.b_Start.UseVisualStyleBackColor = true;
            this.b_Start.Click += new System.EventHandler(this.b_Start_Click);
            // 
            // tb_Results
            // 
            this.tb_Results.Location = new System.Drawing.Point(13, 112);
            this.tb_Results.Multiline = true;
            this.tb_Results.Name = "tb_Results";
            this.tb_Results.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_Results.Size = new System.Drawing.Size(376, 202);
            this.tb_Results.TabIndex = 1;
            // 
            // rb_server
            // 
            this.rb_server.AutoSize = true;
            this.rb_server.Checked = true;
            this.rb_server.Location = new System.Drawing.Point(13, 13);
            this.rb_server.Name = "rb_server";
            this.rb_server.Size = new System.Drawing.Size(148, 17);
            this.rb_server.TabIndex = 2;
            this.rb_server.TabStop = true;
            this.rb_server.Text = "Run server based TM test";
            this.rb_server.UseVisualStyleBackColor = true;
            // 
            // rb_file
            // 
            this.rb_file.AutoSize = true;
            this.rb_file.Location = new System.Drawing.Point(13, 36);
            this.rb_file.Name = "rb_file";
            this.rb_file.Size = new System.Drawing.Size(132, 17);
            this.rb_file.TabIndex = 3;
            this.rb_file.Text = "Run file based TM test";
            this.rb_file.UseVisualStyleBackColor = true;
            this.rb_file.CheckedChanged += new System.EventHandler(this.rb_file_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Set output folder:";
            // 
            // tb_output
            // 
            this.tb_output.Enabled = false;
            this.tb_output.Location = new System.Drawing.Point(15, 82);
            this.tb_output.Name = "tb_output";
            this.tb_output.Size = new System.Drawing.Size(293, 20);
            this.tb_output.TabIndex = 5;
            // 
            // b_Browse
            // 
            this.b_Browse.Enabled = false;
            this.b_Browse.Location = new System.Drawing.Point(314, 80);
            this.b_Browse.Name = "b_Browse";
            this.b_Browse.Size = new System.Drawing.Size(75, 23);
            this.b_Browse.TabIndex = 6;
            this.b_Browse.Text = "Browse...";
            this.b_Browse.UseVisualStyleBackColor = true;
            this.b_Browse.Click += new System.EventHandler(this.b_Browse_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 349);
            this.Controls.Add(this.b_Browse);
            this.Controls.Add(this.tb_output);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rb_file);
            this.Controls.Add(this.rb_server);
            this.Controls.Add(this.tb_Results);
            this.Controls.Add(this.b_Start);
            this.Name = "Form1";
            this.Text = "TM Automation Sample";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button b_Start;
        private System.Windows.Forms.TextBox tb_Results;
        private System.Windows.Forms.RadioButton rb_server;
        private System.Windows.Forms.RadioButton rb_file;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_output;
        private System.Windows.Forms.Button b_Browse;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}

