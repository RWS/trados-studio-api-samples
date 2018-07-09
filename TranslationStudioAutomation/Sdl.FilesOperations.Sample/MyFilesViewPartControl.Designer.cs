namespace Sdl.FilesOperations.Sample
{
    partial class MyFilesViewPartControl
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
            this.FilesListView = new System.Windows.Forms.ListView();
            this.FileNameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.WordCountColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OpenFileButton = new System.Windows.Forms.Button();
            this.AddFileButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FilesListView
            // 
            this.FilesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FileNameColumn,
            this.WordCountColumn});
            this.FilesListView.Dock = System.Windows.Forms.DockStyle.Left;
            this.FilesListView.FullRowSelect = true;
            this.FilesListView.GridLines = true;
            this.FilesListView.HideSelection = false;
            this.FilesListView.Location = new System.Drawing.Point(0, 0);
            this.FilesListView.Name = "FilesListView";
            this.FilesListView.Size = new System.Drawing.Size(340, 200);
            this.FilesListView.TabIndex = 1;
            this.FilesListView.UseCompatibleStateImageBehavior = false;
            this.FilesListView.View = System.Windows.Forms.View.Details;
            this.FilesListView.ItemActivate += new System.EventHandler(this.FilesListView_ItemActivate);
            this.FilesListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.FilesListView_ItemSelectionChanged);
            // 
            // FileNameColumn
            // 
            this.FileNameColumn.Text = "Name";
            this.FileNameColumn.Width = 180;
            // 
            // WordCountColumn
            // 
            this.WordCountColumn.Text = "Words Count";
            this.WordCountColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.WordCountColumn.Width = 100;
            // 
            // OpenFileButton
            // 
            this.OpenFileButton.Enabled = false;
            this.OpenFileButton.Location = new System.Drawing.Point(346, 32);
            this.OpenFileButton.Name = "OpenFileButton";
            this.OpenFileButton.Size = new System.Drawing.Size(102, 23);
            this.OpenFileButton.TabIndex = 2;
            this.OpenFileButton.Text = "Open";
            this.OpenFileButton.UseVisualStyleBackColor = true;
            this.OpenFileButton.Click += new System.EventHandler(this.OpenFileButton_Click);
            // 
            // AddFileButton
            // 
            this.AddFileButton.Location = new System.Drawing.Point(346, 3);
            this.AddFileButton.Name = "AddFileButton";
            this.AddFileButton.Size = new System.Drawing.Size(102, 23);
            this.AddFileButton.TabIndex = 3;
            this.AddFileButton.Text = "Add project files";
            this.AddFileButton.UseVisualStyleBackColor = true;
            this.AddFileButton.Click += new System.EventHandler(this.AddFileButton_Click);
            // 
            // MyFilesViewPartControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.AddFileButton);
            this.Controls.Add(this.OpenFileButton);
            this.Controls.Add(this.FilesListView);
            this.Name = "MyFilesViewPartControl";
            this.Size = new System.Drawing.Size(920, 200);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView FilesListView;
        private System.Windows.Forms.ColumnHeader FileNameColumn;
        private System.Windows.Forms.ColumnHeader WordCountColumn;
        private System.Windows.Forms.Button OpenFileButton;
        private System.Windows.Forms.Button AddFileButton;


    }
}
