namespace Sdl.SDK.LanguagePlatform.Samples.TmLookup
{
    partial class frmLookup
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLookup));
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.comboIndex = new System.Windows.Forms.ComboBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblHitCount = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboLanguagePairs = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBoxSearch = new System.Windows.Forms.GroupBox();
            this.groupBoxTm = new System.Windows.Forms.GroupBox();
            this.btnSelectTm = new System.Windows.Forms.Button();
            this.contextMenuTm = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectFileTMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectServerTMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtTmPath = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip.SuspendLayout();
            this.groupBoxSearch.SuspendLayout();
            this.groupBoxTm.SuspendLayout();
            this.contextMenuTm.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(515, 19);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(50, 39);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Go";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(9, 21);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(499, 37);
            this.txtSearch.TabIndex = 1;
            // 
            // comboIndex
            // 
            this.comboIndex.FormattingEnabled = true;
            this.comboIndex.Items.AddRange(new object[] {
            "Source",
            "Target"});
            this.comboIndex.Location = new System.Drawing.Point(499, 68);
            this.comboIndex.Name = "comboIndex";
            this.comboIndex.Size = new System.Drawing.Size(66, 21);
            this.comboIndex.TabIndex = 3;
            this.comboIndex.Text = "Source";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(606, 24);
            this.menuStrip.TabIndex = 4;
            this.menuStrip.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchOptionsToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // searchOptionsToolStripMenuItem
            // 
            this.searchOptionsToolStripMenuItem.Name = "searchOptionsToolStripMenuItem";
            this.searchOptionsToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.searchOptionsToolStripMenuItem.Text = "Search Options";
            this.searchOptionsToolStripMenuItem.Click += new System.EventHandler(this.SearchOptionsToolStripMenuItem_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(537, 427);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(57, 25);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // lblHitCount
            // 
            this.lblHitCount.Location = new System.Drawing.Point(16, 185);
            this.lblHitCount.Name = "lblHitCount";
            this.lblHitCount.Size = new System.Drawing.Size(578, 236);
            this.lblHitCount.TabIndex = 6;
            this.lblHitCount.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(438, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Search in:";
            // 
            // comboLanguagePairs
            // 
            this.comboLanguagePairs.FormattingEnabled = true;
            this.comboLanguagePairs.Location = new System.Drawing.Point(90, 68);
            this.comboLanguagePairs.Name = "comboLanguagePairs";
            this.comboLanguagePairs.Size = new System.Drawing.Size(342, 21);
            this.comboLanguagePairs.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Language pair:";
            // 
            // groupBoxSearch
            // 
            this.groupBoxSearch.Controls.Add(this.txtSearch);
            this.groupBoxSearch.Controls.Add(this.label1);
            this.groupBoxSearch.Controls.Add(this.btnSearch);
            this.groupBoxSearch.Controls.Add(this.comboIndex);
            this.groupBoxSearch.Controls.Add(this.label2);
            this.groupBoxSearch.Controls.Add(this.comboLanguagePairs);
            this.groupBoxSearch.Location = new System.Drawing.Point(16, 79);
            this.groupBoxSearch.Name = "groupBoxSearch";
            this.groupBoxSearch.Size = new System.Drawing.Size(573, 100);
            this.groupBoxSearch.TabIndex = 11;
            this.groupBoxSearch.TabStop = false;
            this.groupBoxSearch.Text = "Search";
            // 
            // groupBoxTm
            // 
            this.groupBoxTm.Controls.Add(this.btnSelectTm);
            this.groupBoxTm.Controls.Add(this.txtTmPath);
            this.groupBoxTm.Location = new System.Drawing.Point(18, 27);
            this.groupBoxTm.Name = "groupBoxTm";
            this.groupBoxTm.Size = new System.Drawing.Size(571, 48);
            this.groupBoxTm.TabIndex = 13;
            this.groupBoxTm.TabStop = false;
            this.groupBoxTm.Text = "Select Translation Memory";
            // 
            // btnSelectTm
            // 
            this.btnSelectTm.ContextMenuStrip = this.contextMenuTm;
            this.btnSelectTm.Location = new System.Drawing.Point(480, 17);
            this.btnSelectTm.Name = "btnSelectTm";
            this.btnSelectTm.Size = new System.Drawing.Size(83, 23);
            this.btnSelectTm.TabIndex = 1;
            this.btnSelectTm.Text = "Select TM >";
            this.btnSelectTm.UseVisualStyleBackColor = true;
            this.btnSelectTm.Click += new System.EventHandler(this.BtnSelectTm_Click);
            // 
            // contextMenuTm
            // 
            this.contextMenuTm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectFileTMToolStripMenuItem,
            this.selectServerTMToolStripMenuItem});
            this.contextMenuTm.Name = "contextMenuTm";
            this.contextMenuTm.Size = new System.Drawing.Size(176, 48);
            // 
            // selectFileTMToolStripMenuItem
            // 
            this.selectFileTMToolStripMenuItem.Name = "selectFileTMToolStripMenuItem";
            this.selectFileTMToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.selectFileTMToolStripMenuItem.Text = "Select File TM";
            this.selectFileTMToolStripMenuItem.Click += new System.EventHandler(this.SelectFileTMToolStripMenuItem_Click);
            // 
            // selectServerTMToolStripMenuItem
            // 
            this.selectServerTMToolStripMenuItem.Name = "selectServerTMToolStripMenuItem";
            this.selectServerTMToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.selectServerTMToolStripMenuItem.Text = "Select Server TM";
            this.selectServerTMToolStripMenuItem.Click += new System.EventHandler(this.SelectServerTMToolStripMenuItem_Click);
            // 
            // txtTmPath
            // 
            this.txtTmPath.Enabled = false;
            this.txtTmPath.Location = new System.Drawing.Point(9, 19);
            this.txtTmPath.Name = "txtTmPath";
            this.txtTmPath.Size = new System.Drawing.Size(465, 20);
            this.txtTmPath.TabIndex = 0;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // frmLookup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 464);
            this.Controls.Add(this.groupBoxTm);
            this.Controls.Add(this.groupBoxSearch);
            this.Controls.Add(this.lblHitCount);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "frmLookup";
            this.Text = "TM Lookup";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.groupBoxSearch.ResumeLayout(false);
            this.groupBoxSearch.PerformLayout();
            this.groupBoxTm.ResumeLayout(false);
            this.groupBoxTm.PerformLayout();
            this.contextMenuTm.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox comboIndex;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchOptionsToolStripMenuItem;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.RichTextBox lblHitCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBoxTm;
        private System.Windows.Forms.Button btnSelectTm;
        public System.Windows.Forms.ComboBox comboLanguagePairs;
        public System.Windows.Forms.GroupBox groupBoxSearch;
        private System.Windows.Forms.ContextMenuStrip contextMenuTm;
        private System.Windows.Forms.ToolStripMenuItem selectFileTMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectServerTMToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        public System.Windows.Forms.TextBox txtTmPath;
    }
}

