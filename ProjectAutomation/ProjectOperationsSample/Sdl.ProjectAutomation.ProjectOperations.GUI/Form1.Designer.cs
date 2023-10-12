namespace Sdl.ProjectAutomation.ProjectOperations.GUI
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
            this.label5 = new System.Windows.Forms.Label();
            this.tb_MasterTMPath = new System.Windows.Forms.TextBox();
            this.b_BrowseTM = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.b_BrowseTermbase = new System.Windows.Forms.Button();
            this.tb_Termbase = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.b_BrowsePackage = new System.Windows.Forms.Button();
            this.tb_PackagePath = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.b_BrowsePreviousPath = new System.Windows.Forms.Button();
            this.tb_PreviousPath = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cb_ExistingProjects = new System.Windows.Forms.ComboBox();
            this.b_Delete = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.cb_ExistingProjectFiles = new System.Windows.Forms.ComboBox();
            this.b_DeleteFiles = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(276, 224);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // tb_ProjectName
            // 
            this.tb_ProjectName.Location = new System.Drawing.Point(92, 6);
            this.tb_ProjectName.Name = "tb_ProjectName";
            this.tb_ProjectName.Size = new System.Drawing.Size(340, 20);
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
            this.tb_InputFolder.Location = new System.Drawing.Point(92, 30);
            this.tb_InputFolder.Name = "tb_InputFolder";
            this.tb_InputFolder.Size = new System.Drawing.Size(259, 20);
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
            this.label3.Location = new System.Drawing.Point(12, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Source Language:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Target Language:";
            // 
            // cb_SourceLangs
            // 
            this.cb_SourceLangs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_SourceLangs.FormattingEnabled = true;
            this.cb_SourceLangs.Location = new System.Drawing.Point(113, 57);
            this.cb_SourceLangs.Name = "cb_SourceLangs";
            this.cb_SourceLangs.Size = new System.Drawing.Size(319, 21);
            this.cb_SourceLangs.Sorted = true;
            this.cb_SourceLangs.TabIndex = 8;
            // 
            // cb_TargetLang
            // 
            this.cb_TargetLang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_TargetLang.FormattingEnabled = true;
            this.cb_TargetLang.Location = new System.Drawing.Point(113, 84);
            this.cb_TargetLang.Name = "cb_TargetLang";
            this.cb_TargetLang.Size = new System.Drawing.Size(319, 21);
            this.cb_TargetLang.Sorted = true;
            this.cb_TargetLang.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Master TM:";
            // 
            // tb_MasterTMPath
            // 
            this.tb_MasterTMPath.Location = new System.Drawing.Point(113, 111);
            this.tb_MasterTMPath.Name = "tb_MasterTMPath";
            this.tb_MasterTMPath.Size = new System.Drawing.Size(238, 20);
            this.tb_MasterTMPath.TabIndex = 11;
            // 
            // b_BrowseTM
            // 
            this.b_BrowseTM.Location = new System.Drawing.Point(357, 109);
            this.b_BrowseTM.Name = "b_BrowseTM";
            this.b_BrowseTM.Size = new System.Drawing.Size(75, 23);
            this.b_BrowseTM.TabIndex = 12;
            this.b_BrowseTM.Text = "Browse...";
            this.b_BrowseTM.UseVisualStyleBackColor = true;
            this.b_BrowseTM.Click += new System.EventHandler(this.B_BrowseTM_Click);
            // 
            // b_BrowseTermbase
            // 
            this.b_BrowseTermbase.Location = new System.Drawing.Point(357, 135);
            this.b_BrowseTermbase.Name = "b_BrowseTermbase";
            this.b_BrowseTermbase.Size = new System.Drawing.Size(75, 23);
            this.b_BrowseTermbase.TabIndex = 15;
            this.b_BrowseTermbase.Text = "Browse...";
            this.b_BrowseTermbase.UseVisualStyleBackColor = true;
            this.b_BrowseTermbase.Click += new System.EventHandler(this.B_BrowseTermbase_Click);
            // 
            // tb_Termbase
            // 
            this.tb_Termbase.Location = new System.Drawing.Point(113, 137);
            this.tb_Termbase.Name = "tb_Termbase";
            this.tb_Termbase.Size = new System.Drawing.Size(238, 20);
            this.tb_Termbase.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Termbase:";
            // 
            // b_BrowsePackage
            // 
            this.b_BrowsePackage.Location = new System.Drawing.Point(357, 160);
            this.b_BrowsePackage.Name = "b_BrowsePackage";
            this.b_BrowsePackage.Size = new System.Drawing.Size(75, 23);
            this.b_BrowsePackage.TabIndex = 18;
            this.b_BrowsePackage.Text = "Browse...";
            this.b_BrowsePackage.UseVisualStyleBackColor = true;
            this.b_BrowsePackage.Click += new System.EventHandler(this.B_BrowsePackage_Click);
            // 
            // tb_PackagePath
            // 
            this.tb_PackagePath.Location = new System.Drawing.Point(113, 162);
            this.tb_PackagePath.Name = "tb_PackagePath";
            this.tb_PackagePath.Size = new System.Drawing.Size(238, 20);
            this.tb_PackagePath.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 165);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Package path:";
            // 
            // b_BrowsePreviousPath
            // 
            this.b_BrowsePreviousPath.Location = new System.Drawing.Point(357, 185);
            this.b_BrowsePreviousPath.Name = "b_BrowsePreviousPath";
            this.b_BrowsePreviousPath.Size = new System.Drawing.Size(75, 23);
            this.b_BrowsePreviousPath.TabIndex = 21;
            this.b_BrowsePreviousPath.Text = "Browse...";
            this.b_BrowsePreviousPath.UseVisualStyleBackColor = true;
            this.b_BrowsePreviousPath.Click += new System.EventHandler(this.B_BrowsePreviousPath_Click);
            // 
            // tb_PreviousPath
            // 
            this.tb_PreviousPath.Location = new System.Drawing.Point(113, 187);
            this.tb_PreviousPath.Name = "tb_PreviousPath";
            this.tb_PreviousPath.Size = new System.Drawing.Size(238, 20);
            this.tb_PreviousPath.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 190);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Previous Path";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 276);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Project to delete";
            // 
            // cb_ExistingProjects
            // 
            this.cb_ExistingProjects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ExistingProjects.FormattingEnabled = true;
            this.cb_ExistingProjects.Location = new System.Drawing.Point(116, 268);
            this.cb_ExistingProjects.Name = "cb_ExistingProjects";
            this.cb_ExistingProjects.Size = new System.Drawing.Size(192, 21);
            this.cb_ExistingProjects.Sorted = true;
            this.cb_ExistingProjects.TabIndex = 23;
            this.cb_ExistingProjects.SelectedIndexChanged += new System.EventHandler(this.Cb_ExistingProjects_SelectedIndexChanged);
            // 
            // b_Delete
            // 
            this.b_Delete.BackColor = System.Drawing.Color.Red;
            this.b_Delete.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.b_Delete.Location = new System.Drawing.Point(314, 267);
            this.b_Delete.Name = "b_Delete";
            this.b_Delete.Size = new System.Drawing.Size(121, 22);
            this.b_Delete.TabIndex = 24;
            this.b_Delete.Text = "Delete Project\r\n";
            this.b_Delete.UseVisualStyleBackColor = false;
            this.b_Delete.Click += new System.EventHandler(this.B_Delete_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 314);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "File to delete";
            // 
            // cb_ExistingProjectFiles
            // 
            this.cb_ExistingProjectFiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ExistingProjectFiles.FormattingEnabled = true;
            this.cb_ExistingProjectFiles.Location = new System.Drawing.Point(116, 311);
            this.cb_ExistingProjectFiles.Name = "cb_ExistingProjectFiles";
            this.cb_ExistingProjectFiles.Size = new System.Drawing.Size(192, 21);
            this.cb_ExistingProjectFiles.Sorted = true;
            this.cb_ExistingProjectFiles.TabIndex = 26;
            // 
            // b_DeleteFiles
            // 
            this.b_DeleteFiles.BackColor = System.Drawing.Color.Red;
            this.b_DeleteFiles.Enabled = false;
            this.b_DeleteFiles.ForeColor = System.Drawing.SystemColors.Control;
            this.b_DeleteFiles.Location = new System.Drawing.Point(317, 311);
            this.b_DeleteFiles.Name = "b_DeleteFiles";
            this.b_DeleteFiles.Size = new System.Drawing.Size(118, 21);
            this.b_DeleteFiles.TabIndex = 27;
            this.b_DeleteFiles.Text = "Delete Project File";
            this.b_DeleteFiles.UseVisualStyleBackColor = false;
            this.b_DeleteFiles.Click += new System.EventHandler(this.B_DeleteFiles_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 387);
            this.Controls.Add(this.b_DeleteFiles);
            this.Controls.Add(this.cb_ExistingProjectFiles);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.b_Delete);
            this.Controls.Add(this.cb_ExistingProjects);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.b_BrowsePreviousPath);
            this.Controls.Add(this.tb_PreviousPath);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.b_BrowsePackage);
            this.Controls.Add(this.tb_PackagePath);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.b_BrowseTermbase);
            this.Controls.Add(this.tb_Termbase);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.b_BrowseTM);
            this.Controls.Add(this.tb_MasterTMPath);
            this.Controls.Add(this.label5);
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
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_MasterTMPath;
        private System.Windows.Forms.Button b_BrowseTM;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button b_BrowseTermbase;
        private System.Windows.Forms.TextBox tb_Termbase;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button b_BrowsePackage;
        private System.Windows.Forms.TextBox tb_PackagePath;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button b_BrowsePreviousPath;
        private System.Windows.Forms.TextBox tb_PreviousPath;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cb_ExistingProjects;
        private System.Windows.Forms.Button b_Delete;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cb_ExistingProjectFiles;
        private System.Windows.Forms.Button b_DeleteFiles;
    }
}

