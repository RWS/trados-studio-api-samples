namespace Sdl.ProjectAutomation.ProjectCreationSample.GUI
{
    public partial class Form1
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
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tb_ProjectName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_InputFolder = new System.Windows.Forms.TextBox();
            this.b_Browse = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_SourceLangs = new System.Windows.Forms.ComboBox();
            this.cb_TargetLang = new System.Windows.Forms.ComboBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.b_BrowsePackage = new System.Windows.Forms.Button();
            this.tb_PackagePath = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.b_BrowseOutputPath = new System.Windows.Forms.Button();
            this.tb_OutputPath = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(350, 176);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Create";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // tb_ProjectName
            // 
            this.tb_ProjectName.Location = new System.Drawing.Point(113, 6);
            this.tb_ProjectName.Name = "tb_ProjectName";
            this.tb_ProjectName.Size = new System.Drawing.Size(319, 20);
            this.tb_ProjectName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Project Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Input Folder:";
            // 
            // tb_InputFolder
            // 
            this.tb_InputFolder.Location = new System.Drawing.Point(113, 30);
            this.tb_InputFolder.Name = "tb_InputFolder";
            this.tb_InputFolder.Size = new System.Drawing.Size(238, 20);
            this.tb_InputFolder.TabIndex = 4;
            // 
            // b_Browse
            // 
            this.b_Browse.Location = new System.Drawing.Point(357, 30);
            this.b_Browse.Name = "b_Browse";
            this.b_Browse.Size = new System.Drawing.Size(75, 23);
            this.b_Browse.TabIndex = 5;
            this.b_Browse.Text = "Browse...";
            this.b_Browse.UseVisualStyleBackColor = true;
            this.b_Browse.Click += new System.EventHandler(this.B_Browse_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Source Language:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Target Language:";
            // 
            // cb_SourceLangs
            // 
            this.cb_SourceLangs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_SourceLangs.FormattingEnabled = true;
            this.cb_SourceLangs.Location = new System.Drawing.Point(113, 84);
            this.cb_SourceLangs.Name = "cb_SourceLangs";
            this.cb_SourceLangs.Size = new System.Drawing.Size(319, 21);
            this.cb_SourceLangs.Sorted = true;
            this.cb_SourceLangs.TabIndex = 11;
            // 
            // cb_TargetLang
            // 
            this.cb_TargetLang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_TargetLang.FormattingEnabled = true;
            this.cb_TargetLang.Location = new System.Drawing.Point(113, 111);
            this.cb_TargetLang.Name = "cb_TargetLang";
            this.cb_TargetLang.Size = new System.Drawing.Size(319, 21);
            this.cb_TargetLang.Sorted = true;
            this.cb_TargetLang.TabIndex = 12;
            // 
            // b_BrowsePackage
            // 
            this.b_BrowsePackage.Location = new System.Drawing.Point(357, 57);
            this.b_BrowsePackage.Name = "b_BrowsePackage";
            this.b_BrowsePackage.Size = new System.Drawing.Size(75, 23);
            this.b_BrowsePackage.TabIndex = 8;
            this.b_BrowsePackage.Text = "Browse...";
            this.b_BrowsePackage.UseVisualStyleBackColor = true;
            this.b_BrowsePackage.Click += new System.EventHandler(this.B_BrowsePackage_Click);
            // 
            // tb_PackagePath
            // 
            this.tb_PackagePath.Location = new System.Drawing.Point(113, 57);
            this.tb_PackagePath.Name = "tb_PackagePath";
            this.tb_PackagePath.Size = new System.Drawing.Size(238, 20);
            this.tb_PackagePath.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Package path:";
            // 
            // b_BrowsePreviousPath
            // 
            this.b_BrowseOutputPath.Location = new System.Drawing.Point(357, 135);
            this.b_BrowseOutputPath.Name = "b_BrowseOutputPath";
            this.b_BrowseOutputPath.Size = new System.Drawing.Size(75, 23);
            this.b_BrowseOutputPath.TabIndex = 15;
            this.b_BrowseOutputPath.Text = "Browse...";
            this.b_BrowseOutputPath.UseVisualStyleBackColor = true;
            this.b_BrowseOutputPath.Click += new System.EventHandler(this.B_BrowseOutputPath_Click);
            // 
            // tb_PreviousPath
            // 
            this.tb_OutputPath.Location = new System.Drawing.Point(113, 137);
            this.tb_OutputPath.Name = "tb_OutputPath";
            this.tb_OutputPath.Size = new System.Drawing.Size(238, 20);
            this.tb_OutputPath.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 140);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Output Folder";
            //
            // button2
            //
            this.button2.Location = new System.Drawing.Point(230, 176);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 23);
            this.button2.TabIndex = 16;
            this.button2.Text = "Create from package";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 207);
            this.Controls.Add(this.b_BrowseOutputPath);
            this.Controls.Add(this.tb_OutputPath);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.b_BrowsePackage);
            this.Controls.Add(this.tb_PackagePath);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cb_TargetLang);
            this.Controls.Add(this.cb_SourceLangs);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.b_Browse);
            this.Controls.Add(this.tb_InputFolder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_ProjectName);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tb_ProjectName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_InputFolder;
        private System.Windows.Forms.Button b_Browse;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_SourceLangs;
        private System.Windows.Forms.ComboBox cb_TargetLang;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button b_BrowsePackage;
        private System.Windows.Forms.TextBox tb_PackagePath;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button b_BrowseOutputPath;
        private System.Windows.Forms.TextBox tb_OutputPath;
        private System.Windows.Forms.Label label8;
    }
}

