namespace Sdl.PackagesOperations.Sample
{
    partial class PackagesControl
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
            this.buttonOpenPackage = new System.Windows.Forms.Button();
            this.labelPackagePath = new System.Windows.Forms.Label();
            this.textBoxPackagePath = new System.Windows.Forms.TextBox();
            this.createReturnPackageBtn = new System.Windows.Forms.Button();
            this.labelReturnData = new System.Windows.Forms.Label();
            this.textBoxJobName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonOpenProjectWizard = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonClear = new System.Windows.Forms.Button();
            this.labelIconPath = new System.Windows.Forms.Label();
            this.labelProjectType = new System.Windows.Forms.Label();
            this.textBoxProjectType = new System.Windows.Forms.TextBox();
            this.textBoxIconPath = new System.Windows.Forms.TextBox();
            this.buttonBrowseIcon = new System.Windows.Forms.Button();
            this.buttonBrowsePackagePath = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.labelProjectName = new System.Windows.Forms.Label();
            this.labelFile = new System.Windows.Forms.Label();
            this.textBoxProjectName = new System.Windows.Forms.TextBox();
            this.textBoxFile = new System.Windows.Forms.TextBox();
            this.buttonBrowseProjectFile = new System.Windows.Forms.Button();
            this.buttonClearProjectData = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOpenPackage
            // 
            this.buttonOpenPackage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOpenPackage.Location = new System.Drawing.Point(271, 81);
            this.buttonOpenPackage.Name = "buttonOpenPackage";
            this.buttonOpenPackage.Size = new System.Drawing.Size(143, 23);
            this.buttonOpenPackage.TabIndex = 0;
            this.buttonOpenPackage.Text = "Open Package";
            this.buttonOpenPackage.UseVisualStyleBackColor = true;
            this.buttonOpenPackage.Click += new System.EventHandler(this.OpenPackage);
            // 
            // labelPackagePath
            // 
            this.labelPackagePath.AutoSize = true;
            this.labelPackagePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPackagePath.Location = new System.Drawing.Point(3, 52);
            this.labelPackagePath.Name = "labelPackagePath";
            this.labelPackagePath.Size = new System.Drawing.Size(80, 26);
            this.labelPackagePath.TabIndex = 3;
            this.labelPackagePath.Text = "Package path";
            this.labelPackagePath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxPackagePath
            // 
            this.textBoxPackagePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxPackagePath.Location = new System.Drawing.Point(89, 55);
            this.textBoxPackagePath.Name = "textBoxPackagePath";
            this.textBoxPackagePath.Size = new System.Drawing.Size(325, 20);
            this.textBoxPackagePath.TabIndex = 2;
            // 
            // createReturnPackageBtn
            // 
            this.createReturnPackageBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.createReturnPackageBtn.Location = new System.Drawing.Point(271, 164);
            this.createReturnPackageBtn.Name = "createReturnPackageBtn";
            this.createReturnPackageBtn.Size = new System.Drawing.Size(143, 23);
            this.createReturnPackageBtn.TabIndex = 3;
            this.createReturnPackageBtn.Text = "Create Return Package";
            this.createReturnPackageBtn.UseVisualStyleBackColor = true;
            this.createReturnPackageBtn.Click += new System.EventHandler(this.CreateReturnPackageBtn_Click);
            // 
            // labelReturnData
            // 
            this.labelReturnData.AutoSize = true;
            this.labelReturnData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelReturnData.Location = new System.Drawing.Point(3, 135);
            this.labelReturnData.Name = "labelReturnData";
            this.labelReturnData.Size = new System.Drawing.Size(80, 26);
            this.labelReturnData.TabIndex = 4;
            this.labelReturnData.Text = "Job Name:";
            // 
            // textBoxJobName
            // 
            this.textBoxJobName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxJobName.Location = new System.Drawing.Point(89, 138);
            this.textBoxJobName.Name = "textBoxJobName";
            this.textBoxJobName.Size = new System.Drawing.Size(325, 20);
            this.textBoxJobName.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel2);
            this.groupBox2.Location = new System.Drawing.Point(473, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(436, 206);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Project Flow";
            // 
            // buttonOpenProjectWizard
            // 
            this.buttonOpenProjectWizard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOpenProjectWizard.Location = new System.Drawing.Point(248, 55);
            this.buttonOpenProjectWizard.Name = "buttonOpenProjectWizard";
            this.buttonOpenProjectWizard.Size = new System.Drawing.Size(143, 23);
            this.buttonOpenProjectWizard.TabIndex = 11;
            this.buttonOpenProjectWizard.Text = "Open Project Wizard";
            this.buttonOpenProjectWizard.UseVisualStyleBackColor = true;
            this.buttonOpenProjectWizard.Click += new System.EventHandler(this.ButtonOpenProjectWizard_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tableLayoutPanel1);
            this.groupBox3.Location = new System.Drawing.Point(6, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(459, 209);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Package Flows";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.createReturnPackageBtn, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.textBoxJobName, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.buttonClear, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelReturnData, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelIconPath, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelPackagePath, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBoxPackagePath, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelProjectType, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxProjectType, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxIconPath, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonOpenPackage, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonBrowseIcon, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonBrowsePackagePath, 2, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(453, 190);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // buttonClear
            // 
            this.buttonClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClear.Location = new System.Drawing.Point(3, 81);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(80, 23);
            this.buttonClear.TabIndex = 10;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.ButtonClear_Click);
            // 
            // labelIconPath
            // 
            this.labelIconPath.AutoSize = true;
            this.labelIconPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelIconPath.Location = new System.Drawing.Point(3, 0);
            this.labelIconPath.Name = "labelIconPath";
            this.labelIconPath.Size = new System.Drawing.Size(80, 26);
            this.labelIconPath.TabIndex = 4;
            this.labelIconPath.Text = "Icon path";
            this.labelIconPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelProjectType
            // 
            this.labelProjectType.AutoSize = true;
            this.labelProjectType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelProjectType.Location = new System.Drawing.Point(3, 26);
            this.labelProjectType.Name = "labelProjectType";
            this.labelProjectType.Size = new System.Drawing.Size(80, 26);
            this.labelProjectType.TabIndex = 5;
            this.labelProjectType.Text = "Project Type";
            this.labelProjectType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxProjectType
            // 
            this.textBoxProjectType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxProjectType.Location = new System.Drawing.Point(89, 29);
            this.textBoxProjectType.Name = "textBoxProjectType";
            this.textBoxProjectType.Size = new System.Drawing.Size(325, 20);
            this.textBoxProjectType.TabIndex = 6;
            // 
            // textBoxIconPath
            // 
            this.textBoxIconPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxIconPath.Location = new System.Drawing.Point(89, 3);
            this.textBoxIconPath.Name = "textBoxIconPath";
            this.textBoxIconPath.Size = new System.Drawing.Size(325, 20);
            this.textBoxIconPath.TabIndex = 7;
            // 
            // buttonBrowseIcon
            // 
            this.buttonBrowseIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowseIcon.Location = new System.Drawing.Point(420, 3);
            this.buttonBrowseIcon.Name = "buttonBrowseIcon";
            this.buttonBrowseIcon.Size = new System.Drawing.Size(30, 20);
            this.buttonBrowseIcon.TabIndex = 8;
            this.buttonBrowseIcon.Text = "...";
            this.buttonBrowseIcon.UseVisualStyleBackColor = true;
            this.buttonBrowseIcon.Click += new System.EventHandler(this.ButtonBrowseIcon_Click);
            // 
            // buttonBrowsePackagePath
            // 
            this.buttonBrowsePackagePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowsePackagePath.Location = new System.Drawing.Point(420, 55);
            this.buttonBrowsePackagePath.Name = "buttonBrowsePackagePath";
            this.buttonBrowsePackagePath.Size = new System.Drawing.Size(30, 20);
            this.buttonBrowsePackagePath.TabIndex = 9;
            this.buttonBrowsePackagePath.Text = "...";
            this.buttonBrowsePackagePath.UseVisualStyleBackColor = true;
            this.buttonBrowsePackagePath.Click += new System.EventHandler(this.ButtonBrowsePackagePath_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.buttonClearProjectData, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.textBoxProjectName, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelProjectName, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonOpenProjectWizard, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.labelFile, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.textBoxFile, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.buttonBrowseProjectFile, 2, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(430, 187);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Location = new System.Drawing.Point(397, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(8, 11);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // labelProjectName
            // 
            this.labelProjectName.AutoSize = true;
            this.labelProjectName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelProjectName.Location = new System.Drawing.Point(3, 0);
            this.labelProjectName.Name = "labelProjectName";
            this.labelProjectName.Size = new System.Drawing.Size(80, 26);
            this.labelProjectName.TabIndex = 11;
            this.labelProjectName.Text = "Project Name";
            this.labelProjectName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelFile
            // 
            this.labelFile.AutoSize = true;
            this.labelFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelFile.Location = new System.Drawing.Point(3, 26);
            this.labelFile.Name = "labelFile";
            this.labelFile.Size = new System.Drawing.Size(80, 26);
            this.labelFile.TabIndex = 12;
            this.labelFile.Text = "File";
            this.labelFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxProjectName
            // 
            this.textBoxProjectName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxProjectName.Location = new System.Drawing.Point(89, 3);
            this.textBoxProjectName.Name = "textBoxProjectName";
            this.textBoxProjectName.Size = new System.Drawing.Size(302, 20);
            this.textBoxProjectName.TabIndex = 11;
            // 
            // textBoxFile
            // 
            this.textBoxFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxFile.Location = new System.Drawing.Point(89, 29);
            this.textBoxFile.Name = "textBoxFile";
            this.textBoxFile.Size = new System.Drawing.Size(302, 20);
            this.textBoxFile.TabIndex = 13;
            // 
            // buttonBrowseProjectFile
            // 
            this.buttonBrowseProjectFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowseProjectFile.Location = new System.Drawing.Point(397, 29);
            this.buttonBrowseProjectFile.Name = "buttonBrowseProjectFile";
            this.buttonBrowseProjectFile.Size = new System.Drawing.Size(30, 20);
            this.buttonBrowseProjectFile.TabIndex = 14;
            this.buttonBrowseProjectFile.Text = "...";
            this.buttonBrowseProjectFile.UseVisualStyleBackColor = true;
            this.buttonBrowseProjectFile.Click += new System.EventHandler(this.ButtonBrowseProjectFile_Click);
            // 
            // buttonClearProjectData
            // 
            this.buttonClearProjectData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClearProjectData.Location = new System.Drawing.Point(3, 55);
            this.buttonClearProjectData.Name = "buttonClearProjectData";
            this.buttonClearProjectData.Size = new System.Drawing.Size(80, 23);
            this.buttonClearProjectData.TabIndex = 15;
            this.buttonClearProjectData.Text = "Clear";
            this.buttonClearProjectData.UseVisualStyleBackColor = true;
            this.buttonClearProjectData.Click += new System.EventHandler(this.ButtonClearProjectData_Click);
            // 
            // PackagesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Name = "PackagesControl";
            this.Size = new System.Drawing.Size(912, 216);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOpenPackage;
        private System.Windows.Forms.Label labelPackagePath;
        private System.Windows.Forms.TextBox textBoxPackagePath;
        private System.Windows.Forms.Button createReturnPackageBtn;
        private System.Windows.Forms.Label labelReturnData;
        private System.Windows.Forms.TextBox textBoxJobName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelIconPath;
        private System.Windows.Forms.Label labelProjectType;
        private System.Windows.Forms.TextBox textBoxProjectType;
        private System.Windows.Forms.TextBox textBoxIconPath;
        private System.Windows.Forms.Button buttonBrowseIcon;
        private System.Windows.Forms.Button buttonBrowsePackagePath;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonOpenProjectWizard;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox textBoxProjectName;
        private System.Windows.Forms.Label labelProjectName;
        private System.Windows.Forms.Label labelFile;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox textBoxFile;
        private System.Windows.Forms.Button buttonBrowseProjectFile;
        private System.Windows.Forms.Button buttonClearProjectData;
    }
}
