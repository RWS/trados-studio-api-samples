namespace Sdl.EditorOperations.Sample
{
    partial class MyEditorViewPartControl
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.DocumentsList = new System.Windows.Forms.ListView();
            this.DocumentNameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SegmentsCountColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SourceLanguageColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TargetLanguageColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OpenUsingStudioActionButton = new System.Windows.Forms.Button();
            this.SaveAllButton = new System.Windows.Forms.Button();
            this.ReplaceAllButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ReplaceText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.FindText = new System.Windows.Forms.TextBox();
            this.FindReplaceActiveButton = new System.Windows.Forms.RadioButton();
            this.FindReplaceAllButton = new System.Windows.Forms.RadioButton();
            this.CloseAllDocumentsButton = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.EventsListView = new System.Windows.Forms.ListView();
            this.EventIndexColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EventName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EventMetadataColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.ReplaceSelectionButton = new System.Windows.Forms.Button();
            this.ReplaceSelectionTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CurrentSelectionTextBox = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SetTranslationOriginOnSegmentButton = new System.Windows.Forms.Button();
            this.SetTranslatedConfirmationLevelOnSegmentButton = new System.Windows.Forms.Button();
            this.UpdateCommentOnSegmentButton = new System.Windows.Forms.Button();
            this.DeleteAllCommentsOnSegmentButton = new System.Windows.Forms.Button();
            this.DeleteCommentOnSegmentButton = new System.Windows.Forms.Button();
            this.AddCommentToSegmentButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.UpdateParagraphPropertiesButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.ProcessSegmentPropertiesButton = new System.Windows.Forms.Button();
            this.UpdateSegmentPropertiesButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.ProcessSegmentPairButton = new System.Windows.Forms.Button();
            this.UpdateSegmentPairButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.GetSegmentPairsValueLabel = new System.Windows.Forms.Label();
            this.GetSegmentPairsTextLabel = new System.Windows.Forms.Label();
            this.GetSegmentPairsButton = new System.Windows.Forms.Button();
            this.activeSegmentValueLabel = new System.Windows.Forms.Label();
            this.activeSegmentLabel = new System.Windows.Forms.Label();
            this.availableValueLabel = new System.Windows.Forms.Label();
            this.availableLabel = new System.Windows.Forms.Label();
            this.TranslateActiveSegmentButton = new System.Windows.Forms.Button();
            this.ReverseLockedButton = new System.Windows.Forms.Button();
            this.UpdateStatusTextBox = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(920, 200);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.DocumentsList);
            this.tabPage1.Controls.Add(this.OpenUsingStudioActionButton);
            this.tabPage1.Controls.Add(this.SaveAllButton);
            this.tabPage1.Controls.Add(this.ReplaceAllButton);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.ReplaceText);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.FindText);
            this.tabPage1.Controls.Add(this.FindReplaceActiveButton);
            this.tabPage1.Controls.Add(this.FindReplaceAllButton);
            this.tabPage1.Controls.Add(this.CloseAllDocumentsButton);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(912, 174);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // DocumentsList
            // 
            this.DocumentsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.DocumentNameColumn,
            this.SegmentsCountColumn,
            this.SourceLanguageColumn,
            this.TargetLanguageColumn});
            this.DocumentsList.Dock = System.Windows.Forms.DockStyle.Left;
            this.DocumentsList.FullRowSelect = true;
            this.DocumentsList.GridLines = true;
            this.DocumentsList.HideSelection = false;
            this.DocumentsList.Location = new System.Drawing.Point(3, 3);
            this.DocumentsList.MultiSelect = false;
            this.DocumentsList.Name = "DocumentsList";
            this.DocumentsList.Size = new System.Drawing.Size(528, 168);
            this.DocumentsList.TabIndex = 18;
            this.DocumentsList.UseCompatibleStateImageBehavior = false;
            this.DocumentsList.View = System.Windows.Forms.View.Details;
            this.DocumentsList.ItemActivate += new System.EventHandler(this.DocumentsList_ItemActivate);
            // 
            // DocumentNameColumn
            // 
            this.DocumentNameColumn.Text = "Name";
            this.DocumentNameColumn.Width = 200;
            // 
            // SegmentsCountColumn
            // 
            this.SegmentsCountColumn.Text = "Seg. Count";
            this.SegmentsCountColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.SegmentsCountColumn.Width = 80;
            // 
            // SourceLanguageColumn
            // 
            this.SourceLanguageColumn.Text = "Source Language";
            this.SourceLanguageColumn.Width = 120;
            // 
            // TargetLanguageColumn
            // 
            this.TargetLanguageColumn.Text = "Target Language";
            this.TargetLanguageColumn.Width = 120;
            // 
            // OpenUsingStudioActionButton
            // 
            this.OpenUsingStudioActionButton.Location = new System.Drawing.Point(537, 6);
            this.OpenUsingStudioActionButton.Name = "OpenUsingStudioActionButton";
            this.OpenUsingStudioActionButton.Size = new System.Drawing.Size(98, 23);
            this.OpenUsingStudioActionButton.TabIndex = 17;
            this.OpenUsingStudioActionButton.Text = "Open document";
            this.OpenUsingStudioActionButton.UseVisualStyleBackColor = true;
            this.OpenUsingStudioActionButton.Click += new System.EventHandler(this.OpenUsingStudioActionButton_Click);
            // 
            // SaveAllButton
            // 
            this.SaveAllButton.Location = new System.Drawing.Point(537, 35);
            this.SaveAllButton.Name = "SaveAllButton";
            this.SaveAllButton.Size = new System.Drawing.Size(98, 23);
            this.SaveAllButton.TabIndex = 27;
            this.SaveAllButton.Text = "Save all";
            this.SaveAllButton.UseVisualStyleBackColor = true;
            this.SaveAllButton.Click += new System.EventHandler(this.SaveAllButton_Click);
            // 
            // ReplaceAllButton
            // 
            this.ReplaceAllButton.Location = new System.Drawing.Point(831, 119);
            this.ReplaceAllButton.Name = "ReplaceAllButton";
            this.ReplaceAllButton.Size = new System.Drawing.Size(75, 23);
            this.ReplaceAllButton.TabIndex = 26;
            this.ReplaceAllButton.Text = "Replace all";
            this.ReplaceAllButton.UseVisualStyleBackColor = true;
            this.ReplaceAllButton.Click += new System.EventHandler(this.ReplaceAllButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(688, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Replace:";
            // 
            // ReplaceText
            // 
            this.ReplaceText.Location = new System.Drawing.Point(746, 80);
            this.ReplaceText.Name = "ReplaceText";
            this.ReplaceText.Size = new System.Drawing.Size(160, 20);
            this.ReplaceText.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(688, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Find:";
            // 
            // FindText
            // 
            this.FindText.Location = new System.Drawing.Point(746, 54);
            this.FindText.Name = "FindText";
            this.FindText.Size = new System.Drawing.Size(160, 20);
            this.FindText.TabIndex = 22;
            // 
            // FindReplaceActiveButton
            // 
            this.FindReplaceActiveButton.AutoSize = true;
            this.FindReplaceActiveButton.Location = new System.Drawing.Point(691, 30);
            this.FindReplaceActiveButton.Name = "FindReplaceActiveButton";
            this.FindReplaceActiveButton.Size = new System.Drawing.Size(190, 17);
            this.FindReplaceActiveButton.TabIndex = 21;
            this.FindReplaceActiveButton.Text = "Find && Replace in active document";
            this.FindReplaceActiveButton.UseVisualStyleBackColor = true;
            // 
            // FindReplaceAllButton
            // 
            this.FindReplaceAllButton.AutoSize = true;
            this.FindReplaceAllButton.Checked = true;
            this.FindReplaceAllButton.Location = new System.Drawing.Point(691, 7);
            this.FindReplaceAllButton.Name = "FindReplaceAllButton";
            this.FindReplaceAllButton.Size = new System.Drawing.Size(215, 17);
            this.FindReplaceAllButton.TabIndex = 20;
            this.FindReplaceAllButton.TabStop = true;
            this.FindReplaceAllButton.Text = "Find && Replace in all opened documents";
            this.FindReplaceAllButton.UseVisualStyleBackColor = true;
            // 
            // CloseAllDocumentsButton
            // 
            this.CloseAllDocumentsButton.Location = new System.Drawing.Point(537, 64);
            this.CloseAllDocumentsButton.Name = "CloseAllDocumentsButton";
            this.CloseAllDocumentsButton.Size = new System.Drawing.Size(98, 23);
            this.CloseAllDocumentsButton.TabIndex = 19;
            this.CloseAllDocumentsButton.Text = "Close all";
            this.CloseAllDocumentsButton.UseVisualStyleBackColor = true;
            this.CloseAllDocumentsButton.Click += new System.EventHandler(this.CloseAllDocumentsButton_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.EventsListView);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(912, 174);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Tracking Events";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // EventsListView
            // 
            this.EventsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.EventIndexColumn,
            this.EventName,
            this.EventMetadataColumn});
            this.EventsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EventsListView.FullRowSelect = true;
            this.EventsListView.GridLines = true;
            this.EventsListView.Location = new System.Drawing.Point(3, 3);
            this.EventsListView.MultiSelect = false;
            this.EventsListView.Name = "EventsListView";
            this.EventsListView.Size = new System.Drawing.Size(906, 168);
            this.EventsListView.TabIndex = 0;
            this.EventsListView.UseCompatibleStateImageBehavior = false;
            this.EventsListView.View = System.Windows.Forms.View.Details;
            // 
            // EventIndexColumn
            // 
            this.EventIndexColumn.Text = "Crt.";
            this.EventIndexColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // EventName
            // 
            this.EventName.Text = "EventName";
            this.EventName.Width = 200;
            // 
            // EventMetadataColumn
            // 
            this.EventMetadataColumn.Text = "Meta";
            this.EventMetadataColumn.Width = 300;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.ReplaceSelectionButton);
            this.tabPage3.Controls.Add(this.ReplaceSelectionTextBox);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.CurrentSelectionTextBox);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(912, 174);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Selections";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // ReplaceSelectionButton
            // 
            this.ReplaceSelectionButton.Location = new System.Drawing.Point(434, 90);
            this.ReplaceSelectionButton.Name = "ReplaceSelectionButton";
            this.ReplaceSelectionButton.Size = new System.Drawing.Size(99, 23);
            this.ReplaceSelectionButton.TabIndex = 4;
            this.ReplaceSelectionButton.Text = "Replace";
            this.ReplaceSelectionButton.UseVisualStyleBackColor = true;
            this.ReplaceSelectionButton.Click += new System.EventHandler(this.ReplaceSelectionButton_Click);
            // 
            // ReplaceSelectionTextBox
            // 
            this.ReplaceSelectionTextBox.Location = new System.Drawing.Point(434, 16);
            this.ReplaceSelectionTextBox.Multiline = true;
            this.ReplaceSelectionTextBox.Name = "ReplaceSelectionTextBox";
            this.ReplaceSelectionTextBox.Size = new System.Drawing.Size(374, 67);
            this.ReplaceSelectionTextBox.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(431, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Replace selection with:";
            // 
            // CurrentSelectionTextBox
            // 
            this.CurrentSelectionTextBox.Location = new System.Drawing.Point(6, 16);
            this.CurrentSelectionTextBox.Name = "CurrentSelectionTextBox";
            this.CurrentSelectionTextBox.ReadOnly = true;
            this.CurrentSelectionTextBox.Size = new System.Drawing.Size(419, 96);
            this.CurrentSelectionTextBox.TabIndex = 1;
            this.CurrentSelectionTextBox.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Current selection text";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox2);
            this.tabPage4.Controls.Add(this.groupBox1);
            this.tabPage4.Controls.Add(this.GetSegmentPairsValueLabel);
            this.tabPage4.Controls.Add(this.GetSegmentPairsTextLabel);
            this.tabPage4.Controls.Add(this.GetSegmentPairsButton);
            this.tabPage4.Controls.Add(this.activeSegmentValueLabel);
            this.tabPage4.Controls.Add(this.activeSegmentLabel);
            this.tabPage4.Controls.Add(this.availableValueLabel);
            this.tabPage4.Controls.Add(this.availableLabel);
            this.tabPage4.Controls.Add(this.TranslateActiveSegmentButton);
            this.tabPage4.Controls.Add(this.ReverseLockedButton);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(912, 174);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Integration Tests";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.SetTranslationOriginOnSegmentButton);
            this.groupBox2.Controls.Add(this.SetTranslatedConfirmationLevelOnSegmentButton);
            this.groupBox2.Controls.Add(this.UpdateCommentOnSegmentButton);
            this.groupBox2.Controls.Add(this.DeleteAllCommentsOnSegmentButton);
            this.groupBox2.Controls.Add(this.DeleteCommentOnSegmentButton);
            this.groupBox2.Controls.Add(this.AddCommentToSegmentButton);
            this.groupBox2.Location = new System.Drawing.Point(238, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(309, 168);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Active segment operations";
            // 
            // SetTranslationOriginOnSegmentButton
            // 
            this.SetTranslationOriginOnSegmentButton.Location = new System.Drawing.Point(131, 48);
            this.SetTranslationOriginOnSegmentButton.Name = "SetTranslationOriginOnSegmentButton";
            this.SetTranslationOriginOnSegmentButton.Size = new System.Drawing.Size(172, 23);
            this.SetTranslationOriginOnSegmentButton.TabIndex = 13;
            this.SetTranslationOriginOnSegmentButton.Text = "Set TranslationOrigin";
            this.SetTranslationOriginOnSegmentButton.UseVisualStyleBackColor = true;
            this.SetTranslationOriginOnSegmentButton.Click += new System.EventHandler(this.SetTranslationOriginOnSegmentButton_Click);
            // 
            // SetTranslatedConfirmationLevelOnSegmentButton
            // 
            this.SetTranslatedConfirmationLevelOnSegmentButton.Location = new System.Drawing.Point(131, 19);
            this.SetTranslatedConfirmationLevelOnSegmentButton.Name = "SetTranslatedConfirmationLevelOnSegmentButton";
            this.SetTranslatedConfirmationLevelOnSegmentButton.Size = new System.Drawing.Size(172, 23);
            this.SetTranslatedConfirmationLevelOnSegmentButton.TabIndex = 11;
            this.SetTranslatedConfirmationLevelOnSegmentButton.Text = "Set Translated ConfirmationLevel";
            this.SetTranslatedConfirmationLevelOnSegmentButton.UseVisualStyleBackColor = true;
            this.SetTranslatedConfirmationLevelOnSegmentButton.Click += new System.EventHandler(this.SetTranslatedConfirmationLevelOnSegmentButton_Click);
            // 
            // UpdateCommentOnSegmentButton
            // 
            this.UpdateCommentOnSegmentButton.Location = new System.Drawing.Point(6, 48);
            this.UpdateCommentOnSegmentButton.Name = "UpdateCommentOnSegmentButton";
            this.UpdateCommentOnSegmentButton.Size = new System.Drawing.Size(119, 23);
            this.UpdateCommentOnSegmentButton.TabIndex = 10;
            this.UpdateCommentOnSegmentButton.Text = "Update Comment";
            this.UpdateCommentOnSegmentButton.UseVisualStyleBackColor = true;
            this.UpdateCommentOnSegmentButton.Click += new System.EventHandler(this.UpdateCommentOnSegmentButton_Click);
            // 
            // DeleteAllCommentsOnSegmentButton
            // 
            this.DeleteAllCommentsOnSegmentButton.Location = new System.Drawing.Point(6, 106);
            this.DeleteAllCommentsOnSegmentButton.Name = "DeleteAllCommentsOnSegmentButton";
            this.DeleteAllCommentsOnSegmentButton.Size = new System.Drawing.Size(119, 23);
            this.DeleteAllCommentsOnSegmentButton.TabIndex = 9;
            this.DeleteAllCommentsOnSegmentButton.Text = "Delete All Comments";
            this.DeleteAllCommentsOnSegmentButton.UseVisualStyleBackColor = true;
            this.DeleteAllCommentsOnSegmentButton.Click += new System.EventHandler(this.DeleteAllCommentsOnSegmentButton_Click);
            // 
            // DeleteCommentOnSegmentButton
            // 
            this.DeleteCommentOnSegmentButton.Location = new System.Drawing.Point(6, 77);
            this.DeleteCommentOnSegmentButton.Name = "DeleteCommentOnSegmentButton";
            this.DeleteCommentOnSegmentButton.Size = new System.Drawing.Size(119, 23);
            this.DeleteCommentOnSegmentButton.TabIndex = 8;
            this.DeleteCommentOnSegmentButton.Text = "Delete Comment";
            this.DeleteCommentOnSegmentButton.UseVisualStyleBackColor = true;
            this.DeleteCommentOnSegmentButton.Click += new System.EventHandler(this.DeleteCommentOnSegmentButton_Click);
            // 
            // AddCommentToSegmentButton
            // 
            this.AddCommentToSegmentButton.Location = new System.Drawing.Point(6, 19);
            this.AddCommentToSegmentButton.Name = "AddCommentToSegmentButton";
            this.AddCommentToSegmentButton.Size = new System.Drawing.Size(119, 23);
            this.AddCommentToSegmentButton.TabIndex = 7;
            this.AddCommentToSegmentButton.Text = "Add Comment";
            this.AddCommentToSegmentButton.UseVisualStyleBackColor = true;
            this.AddCommentToSegmentButton.Click += new System.EventHandler(this.AddCommentToSegmentButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.UpdateStatusTextBox);
            this.groupBox1.Controls.Add(this.UpdateParagraphPropertiesButton);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.ProcessSegmentPropertiesButton);
            this.groupBox1.Controls.Add(this.UpdateSegmentPropertiesButton);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.ProcessSegmentPairButton);
            this.groupBox1.Controls.Add(this.UpdateSegmentPairButton);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(553, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(308, 168);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Active segment update operations";
            // 
            // UpdateParagraphPropertiesButton
            // 
            this.UpdateParagraphPropertiesButton.Location = new System.Drawing.Point(208, 77);
            this.UpdateParagraphPropertiesButton.Name = "UpdateParagraphPropertiesButton";
            this.UpdateParagraphPropertiesButton.Size = new System.Drawing.Size(85, 23);
            this.UpdateParagraphPropertiesButton.TabIndex = 26;
            this.UpdateParagraphPropertiesButton.Text = "Direct Update";
            this.UpdateParagraphPropertiesButton.UseVisualStyleBackColor = true;
            this.UpdateParagraphPropertiesButton.Click += new System.EventHandler(this.UpdateParagraphPropertiesButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Paragraph properties:";
            // 
            // ProcessSegmentPropertiesButton
            // 
            this.ProcessSegmentPropertiesButton.Location = new System.Drawing.Point(117, 48);
            this.ProcessSegmentPropertiesButton.Name = "ProcessSegmentPropertiesButton";
            this.ProcessSegmentPropertiesButton.Size = new System.Drawing.Size(85, 23);
            this.ProcessSegmentPropertiesButton.TabIndex = 24;
            this.ProcessSegmentPropertiesButton.Text = "Process";
            this.ProcessSegmentPropertiesButton.UseVisualStyleBackColor = true;
            this.ProcessSegmentPropertiesButton.Click += new System.EventHandler(this.ProcessSegmentPropertiesButton_Click);
            // 
            // UpdateSegmentPropertiesButton
            // 
            this.UpdateSegmentPropertiesButton.Location = new System.Drawing.Point(208, 48);
            this.UpdateSegmentPropertiesButton.Name = "UpdateSegmentPropertiesButton";
            this.UpdateSegmentPropertiesButton.Size = new System.Drawing.Size(85, 23);
            this.UpdateSegmentPropertiesButton.TabIndex = 23;
            this.UpdateSegmentPropertiesButton.Text = "Direct Update";
            this.UpdateSegmentPropertiesButton.UseVisualStyleBackColor = true;
            this.UpdateSegmentPropertiesButton.Click += new System.EventHandler(this.UpdateSegmentPropertiesButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Segment properties:";
            // 
            // ProcessSegmentPairButton
            // 
            this.ProcessSegmentPairButton.Location = new System.Drawing.Point(117, 19);
            this.ProcessSegmentPairButton.Name = "ProcessSegmentPairButton";
            this.ProcessSegmentPairButton.Size = new System.Drawing.Size(85, 23);
            this.ProcessSegmentPairButton.TabIndex = 21;
            this.ProcessSegmentPairButton.Text = "Process";
            this.ProcessSegmentPairButton.UseVisualStyleBackColor = true;
            this.ProcessSegmentPairButton.Click += new System.EventHandler(this.ProcessSegmentPairButton_Click);
            // 
            // UpdateSegmentPairButton
            // 
            this.UpdateSegmentPairButton.Location = new System.Drawing.Point(208, 19);
            this.UpdateSegmentPairButton.Name = "UpdateSegmentPairButton";
            this.UpdateSegmentPairButton.Size = new System.Drawing.Size(85, 23);
            this.UpdateSegmentPairButton.TabIndex = 20;
            this.UpdateSegmentPairButton.Text = "Direct Update";
            this.UpdateSegmentPairButton.UseVisualStyleBackColor = true;
            this.UpdateSegmentPairButton.Click += new System.EventHandler(this.UpdateSegmentPairButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Segment content:";
            // 
            // GetSegmentPairsValueLabel
            // 
            this.GetSegmentPairsValueLabel.AutoSize = true;
            this.GetSegmentPairsValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GetSegmentPairsValueLabel.Location = new System.Drawing.Point(180, 132);
            this.GetSegmentPairsValueLabel.Name = "GetSegmentPairsValueLabel";
            this.GetSegmentPairsValueLabel.Size = new System.Drawing.Size(0, 13);
            this.GetSegmentPairsValueLabel.TabIndex = 17;
            // 
            // GetSegmentPairsTextLabel
            // 
            this.GetSegmentPairsTextLabel.AutoSize = true;
            this.GetSegmentPairsTextLabel.Location = new System.Drawing.Point(3, 132);
            this.GetSegmentPairsTextLabel.Name = "GetSegmentPairsTextLabel";
            this.GetSegmentPairsTextLabel.Size = new System.Drawing.Size(177, 13);
            this.GetSegmentPairsTextLabel.TabIndex = 16;
            this.GetSegmentPairsTextLabel.Text = "Current paragraph segment pair IDs:";
            // 
            // GetSegmentPairsButton
            // 
            this.GetSegmentPairsButton.Location = new System.Drawing.Point(3, 107);
            this.GetSegmentPairsButton.Name = "GetSegmentPairsButton";
            this.GetSegmentPairsButton.Size = new System.Drawing.Size(219, 22);
            this.GetSegmentPairsButton.TabIndex = 15;
            this.GetSegmentPairsButton.Text = "Get Segment Pairs From Current Paragraph";
            this.GetSegmentPairsButton.UseVisualStyleBackColor = true;
            this.GetSegmentPairsButton.Click += new System.EventHandler(this.GetSegmentPairsButton_Click);
            // 
            // activeSegmentValueLabel
            // 
            this.activeSegmentValueLabel.AutoSize = true;
            this.activeSegmentValueLabel.Location = new System.Drawing.Point(169, 93);
            this.activeSegmentValueLabel.Name = "activeSegmentValueLabel";
            this.activeSegmentValueLabel.Size = new System.Drawing.Size(0, 13);
            this.activeSegmentValueLabel.TabIndex = 6;
            // 
            // activeSegmentLabel
            // 
            this.activeSegmentLabel.AutoSize = true;
            this.activeSegmentLabel.Location = new System.Drawing.Point(9, 93);
            this.activeSegmentLabel.Name = "activeSegmentLabel";
            this.activeSegmentLabel.Size = new System.Drawing.Size(160, 13);
            this.activeSegmentLabel.TabIndex = 5;
            this.activeSegmentLabel.Text = "ActiveSegment content is ready:";
            // 
            // availableValueLabel
            // 
            this.availableValueLabel.AutoSize = true;
            this.availableValueLabel.Location = new System.Drawing.Point(131, 74);
            this.availableValueLabel.Name = "availableValueLabel";
            this.availableValueLabel.Size = new System.Drawing.Size(0, 13);
            this.availableValueLabel.TabIndex = 4;
            // 
            // availableLabel
            // 
            this.availableLabel.AutoSize = true;
            this.availableLabel.Location = new System.Drawing.Point(9, 77);
            this.availableLabel.Name = "availableLabel";
            this.availableLabel.Size = new System.Drawing.Size(122, 13);
            this.availableLabel.TabIndex = 3;
            this.availableLabel.Text = "TM provider is available:";
            // 
            // TranslateActiveSegmentButton
            // 
            this.TranslateActiveSegmentButton.Location = new System.Drawing.Point(3, 48);
            this.TranslateActiveSegmentButton.Name = "TranslateActiveSegmentButton";
            this.TranslateActiveSegmentButton.Size = new System.Drawing.Size(138, 23);
            this.TranslateActiveSegmentButton.TabIndex = 1;
            this.TranslateActiveSegmentButton.Text = "Translate Active Segment";
            this.TranslateActiveSegmentButton.UseVisualStyleBackColor = true;
            this.TranslateActiveSegmentButton.Click += new System.EventHandler(this.TranslateActiveSegmentButton_Click);
            // 
            // ReverseLockedButton
            // 
            this.ReverseLockedButton.Location = new System.Drawing.Point(3, 19);
            this.ReverseLockedButton.Name = "ReverseLockedButton";
            this.ReverseLockedButton.Size = new System.Drawing.Size(138, 23);
            this.ReverseLockedButton.TabIndex = 0;
            this.ReverseLockedButton.Text = "Reverse Locked";
            this.ReverseLockedButton.UseVisualStyleBackColor = true;
            this.ReverseLockedButton.Click += new System.EventHandler(this.ReverseLockedButton_Click);
            // 
            // UpdateStatusTextBox
            // 
            this.UpdateStatusTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateStatusTextBox.ForeColor = System.Drawing.Color.Green;
            this.UpdateStatusTextBox.Location = new System.Drawing.Point(11, 126);
            this.UpdateStatusTextBox.Multiline = true;
            this.UpdateStatusTextBox.Name = "UpdateStatusTextBox";
            this.UpdateStatusTextBox.Size = new System.Drawing.Size(282, 36);
            this.UpdateStatusTextBox.TabIndex = 28;
            // 
            // MyEditorViewPartControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tabControl1);
            this.Name = "MyEditorViewPartControl";
            this.Size = new System.Drawing.Size(920, 200);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView DocumentsList;
        private System.Windows.Forms.ColumnHeader DocumentNameColumn;
        private System.Windows.Forms.ColumnHeader SegmentsCountColumn;
        private System.Windows.Forms.ColumnHeader SourceLanguageColumn;
        private System.Windows.Forms.ColumnHeader TargetLanguageColumn;
        private System.Windows.Forms.Button OpenUsingStudioActionButton;
        private System.Windows.Forms.Button SaveAllButton;
        private System.Windows.Forms.Button ReplaceAllButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ReplaceText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FindText;
        private System.Windows.Forms.RadioButton FindReplaceActiveButton;
        private System.Windows.Forms.RadioButton FindReplaceAllButton;
        private System.Windows.Forms.Button CloseAllDocumentsButton;
        private System.Windows.Forms.ListView EventsListView;
        private System.Windows.Forms.ColumnHeader EventName;
        private System.Windows.Forms.ColumnHeader EventIndexColumn;
        private System.Windows.Forms.ColumnHeader EventMetadataColumn;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox CurrentSelectionTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ReplaceSelectionTextBox;
        private System.Windows.Forms.Button ReplaceSelectionButton;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button ReverseLockedButton;
        private System.Windows.Forms.Button TranslateActiveSegmentButton;
        private System.Windows.Forms.Label availableValueLabel;
        private System.Windows.Forms.Label availableLabel;
        private System.Windows.Forms.Label activeSegmentLabel;
        private System.Windows.Forms.Label activeSegmentValueLabel;
        private System.Windows.Forms.Button AddCommentToSegmentButton;
        private System.Windows.Forms.Button DeleteCommentOnSegmentButton;
        private System.Windows.Forms.Button DeleteAllCommentsOnSegmentButton;
        private System.Windows.Forms.Button UpdateCommentOnSegmentButton;
        private System.Windows.Forms.Button SetTranslatedConfirmationLevelOnSegmentButton;
        private System.Windows.Forms.Button SetTranslationOriginOnSegmentButton;
        private System.Windows.Forms.Button GetSegmentPairsButton;
        private System.Windows.Forms.Label GetSegmentPairsValueLabel;
        private System.Windows.Forms.Label GetSegmentPairsTextLabel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button UpdateParagraphPropertiesButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button ProcessSegmentPropertiesButton;
        private System.Windows.Forms.Button UpdateSegmentPropertiesButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button ProcessSegmentPairButton;
        private System.Windows.Forms.Button UpdateSegmentPairButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox UpdateStatusTextBox;

    }
}
