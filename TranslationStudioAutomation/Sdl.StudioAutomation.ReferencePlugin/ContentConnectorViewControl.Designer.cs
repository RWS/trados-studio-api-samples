namespace StudioIntegrationApiSample
{
    partial class ContentConnectorViewControl
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
            this._tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this._progressBar = new System.Windows.Forms.ProgressBar();
            this._proejctTemplateLabel = new System.Windows.Forms.Label();
            this._projectTemplatesComboBox = new System.Windows.Forms.ComboBox();
            this._resultsTextBox = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this._projectsListBox = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this._filesListView = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this._tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tableLayoutPanel
            // 
            this._tableLayoutPanel.ColumnCount = 2;
            this._tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this._tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tableLayoutPanel.Controls.Add(this._progressBar, 0, 4);
            this._tableLayoutPanel.Controls.Add(this._proejctTemplateLabel, 0, 2);
            this._tableLayoutPanel.Controls.Add(this._projectTemplatesComboBox, 0, 3);
            this._tableLayoutPanel.Controls.Add(this._resultsTextBox, 0, 5);
            this._tableLayoutPanel.Controls.Add(this.splitContainer1, 0, 1);
            this._tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this._tableLayoutPanel.Name = "_tableLayoutPanel";
            this._tableLayoutPanel.RowCount = 6;
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._tableLayoutPanel.Size = new System.Drawing.Size(710, 378);
            this._tableLayoutPanel.TabIndex = 0;
            // 
            // _progressBar
            // 
            this._progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._tableLayoutPanel.SetColumnSpan(this._progressBar, 2);
            this._progressBar.Location = new System.Drawing.Point(3, 199);
            this._progressBar.Name = "_progressBar";
            this._progressBar.Size = new System.Drawing.Size(704, 20);
            this._progressBar.TabIndex = 2;
            // 
            // _proejctTemplateLabel
            // 
            this._proejctTemplateLabel.AutoSize = true;
            this._proejctTemplateLabel.Location = new System.Drawing.Point(0, 156);
            this._proejctTemplateLabel.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this._proejctTemplateLabel.Name = "_proejctTemplateLabel";
            this._proejctTemplateLabel.Size = new System.Drawing.Size(86, 13);
            this._proejctTemplateLabel.TabIndex = 3;
            this._proejctTemplateLabel.Text = "Project template:";
            // 
            // _projectTemplatesComboBox
            // 
            this._projectTemplatesComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._projectTemplatesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._projectTemplatesComboBox.FormattingEnabled = true;
            this._projectTemplatesComboBox.Location = new System.Drawing.Point(3, 172);
            this._projectTemplatesComboBox.Name = "_projectTemplatesComboBox";
            this._projectTemplatesComboBox.Size = new System.Drawing.Size(234, 21);
            this._projectTemplatesComboBox.TabIndex = 4;
            this._projectTemplatesComboBox.SelectedIndexChanged += new System.EventHandler(this._projectTemplatesComboBox_SelectedIndexChanged);
            // 
            // _resultsTextBox
            // 
            this._resultsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._resultsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._tableLayoutPanel.SetColumnSpan(this._resultsTextBox, 2);
            this._resultsTextBox.Location = new System.Drawing.Point(3, 225);
            this._resultsTextBox.Multiline = true;
            this._resultsTextBox.Name = "_resultsTextBox";
            this._resultsTextBox.ReadOnly = true;
            this._resultsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._resultsTextBox.Size = new System.Drawing.Size(704, 150);
            this._resultsTextBox.TabIndex = 5;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._tableLayoutPanel.SetColumnSpan(this.splitContainer1, 2);
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer1.Size = new System.Drawing.Size(704, 150);
            this.splitContainer1.SplitterDistance = 234;
            this.splitContainer1.TabIndex = 8;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this._projectsListBox, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(234, 150);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Project Requests:";
            // 
            // _projectsListBox
            // 
            this._projectsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._projectsListBox.FormattingEnabled = true;
            this._projectsListBox.IntegralHeight = false;
            this._projectsListBox.Location = new System.Drawing.Point(0, 13);
            this._projectsListBox.Margin = new System.Windows.Forms.Padding(0);
            this._projectsListBox.Name = "_projectsListBox";
            this._projectsListBox.Size = new System.Drawing.Size(234, 137);
            this._projectsListBox.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this._filesListView, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(466, 150);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // _filesListView
            // 
            this._filesListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._filesListView.Location = new System.Drawing.Point(0, 13);
            this._filesListView.Margin = new System.Windows.Forms.Padding(0);
            this._filesListView.Name = "_filesListView";
            this._filesListView.Size = new System.Drawing.Size(466, 137);
            this._filesListView.TabIndex = 0;
            this._filesListView.UseCompatibleStateImageBehavior = false;
            this._filesListView.View = System.Windows.Forms.View.List;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Files:";
            // 
            // ContentConnectorViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._tableLayoutPanel);
            this.Name = "ContentConnectorViewControl";
            this.Size = new System.Drawing.Size(710, 378);
            this._tableLayoutPanel.ResumeLayout(false);
            this._tableLayoutPanel.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _tableLayoutPanel;
        private System.Windows.Forms.ProgressBar _progressBar;
        private System.Windows.Forms.Label _proejctTemplateLabel;
        private System.Windows.Forms.ComboBox _projectTemplatesComboBox;
        private System.Windows.Forms.TextBox _resultsTextBox;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView _filesListView;
        private System.Windows.Forms.ListBox _projectsListBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label2;
    }
}
