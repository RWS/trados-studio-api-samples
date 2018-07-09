namespace Sdl.ProjectsOperations.Sample
{
    partial class MyProjectsViewPartControl
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
            this.ProjectsListView = new System.Windows.Forms.ListView();
            this.ProjectNameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TargetFilesColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AddProjectButton = new System.Windows.Forms.Button();
            this.dueDateCalendar = new System.Windows.Forms.MonthCalendar();
            this.SetDueDateButton = new System.Windows.Forms.Button();
            this.ClearDueDateButton = new System.Windows.Forms.Button();
            this.MarkAsCompleted = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ProjectsListView
            // 
            this.ProjectsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ProjectNameColumn,
            this.TargetFilesColumn});
            this.ProjectsListView.Dock = System.Windows.Forms.DockStyle.Left;
            this.ProjectsListView.FullRowSelect = true;
            this.ProjectsListView.GridLines = true;
            this.ProjectsListView.HideSelection = false;
            this.ProjectsListView.Location = new System.Drawing.Point(0, 0);
            this.ProjectsListView.Name = "ProjectsListView";
            this.ProjectsListView.Size = new System.Drawing.Size(340, 200);
            this.ProjectsListView.TabIndex = 0;
            this.ProjectsListView.UseCompatibleStateImageBehavior = false;
            this.ProjectsListView.View = System.Windows.Forms.View.Details;
            this.ProjectsListView.ItemActivate += new System.EventHandler(this.ProjectsListView_ItemActivate);
            this.ProjectsListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.ProjectsListView_ItemSelectionChanged);
            // 
            // ProjectNameColumn
            // 
            this.ProjectNameColumn.Text = "Name";
            this.ProjectNameColumn.Width = 180;
            // 
            // TargetFilesColumn
            // 
            this.TargetFilesColumn.Text = "Target Files Count";
            this.TargetFilesColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TargetFilesColumn.Width = 100;
            // 
            // AddProjectButton
            // 
            this.AddProjectButton.Location = new System.Drawing.Point(346, 3);
            this.AddProjectButton.Name = "AddProjectButton";
            this.AddProjectButton.Size = new System.Drawing.Size(120, 23);
            this.AddProjectButton.TabIndex = 1;
            this.AddProjectButton.Text = "Add project";
            this.AddProjectButton.UseVisualStyleBackColor = true;
            this.AddProjectButton.Click += new System.EventHandler(this.AddProjectButton_Click);
            // 
            // dueDateCalendar
            // 
            this.dueDateCalendar.Location = new System.Drawing.Point(478, 3);
            this.dueDateCalendar.MaxSelectionCount = 1;
            this.dueDateCalendar.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dueDateCalendar.Name = "dueDateCalendar";
            this.dueDateCalendar.TabIndex = 2;
            // 
            // SetDueDateButton
            // 
            this.SetDueDateButton.Location = new System.Drawing.Point(595, 174);
            this.SetDueDateButton.Name = "SetDueDateButton";
            this.SetDueDateButton.Size = new System.Drawing.Size(110, 23);
            this.SetDueDateButton.TabIndex = 3;
            this.SetDueDateButton.Text = "Set due date";
            this.SetDueDateButton.UseVisualStyleBackColor = true;
            this.SetDueDateButton.Click += new System.EventHandler(this.SetDueDateButton_Click);
            // 
            // ClearDueDateButton
            // 
            this.ClearDueDateButton.Location = new System.Drawing.Point(479, 174);
            this.ClearDueDateButton.Name = "ClearDueDateButton";
            this.ClearDueDateButton.Size = new System.Drawing.Size(110, 23);
            this.ClearDueDateButton.TabIndex = 4;
            this.ClearDueDateButton.Text = "Clear due date";
            this.ClearDueDateButton.UseVisualStyleBackColor = true;
            this.ClearDueDateButton.Click += new System.EventHandler(this.ClearDueDateButton_Click);
            // 
            // MarkAsCompleted
            // 
            this.MarkAsCompleted.Location = new System.Drawing.Point(346, 32);
            this.MarkAsCompleted.Name = "MarkAsCompleted";
            this.MarkAsCompleted.Size = new System.Drawing.Size(120, 23);
            this.MarkAsCompleted.TabIndex = 5;
            this.MarkAsCompleted.Text = "Mark as completed";
            this.MarkAsCompleted.UseVisualStyleBackColor = true;
            this.MarkAsCompleted.Click += new System.EventHandler(this.MarkAsCompleted_Click);
            // 
            // MyProjectsViewPartControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MarkAsCompleted);
            this.Controls.Add(this.ClearDueDateButton);
            this.Controls.Add(this.SetDueDateButton);
            this.Controls.Add(this.dueDateCalendar);
            this.Controls.Add(this.AddProjectButton);
            this.Controls.Add(this.ProjectsListView);
            this.Name = "MyProjectsViewPartControl";
            this.Size = new System.Drawing.Size(920, 200);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView ProjectsListView;
        private System.Windows.Forms.ColumnHeader ProjectNameColumn;
        private System.Windows.Forms.Button AddProjectButton;
        private System.Windows.Forms.ColumnHeader TargetFilesColumn;
        private System.Windows.Forms.MonthCalendar dueDateCalendar;
        private System.Windows.Forms.Button SetDueDateButton;
        private System.Windows.Forms.Button ClearDueDateButton;
        private System.Windows.Forms.Button MarkAsCompleted;


    }
}
