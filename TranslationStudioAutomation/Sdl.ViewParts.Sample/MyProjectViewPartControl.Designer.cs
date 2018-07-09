namespace Sdl.ViewParts.Sample
{
    partial class MyProjectViewPartControl
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SelectedProjectsCountLabel = new System.Windows.Forms.Label();
            this.CurrentProjectLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Selected number of projects:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Current project:";
            // 
            // SelectedProjectsCountLabel
            // 
            this.SelectedProjectsCountLabel.AutoSize = true;
            this.SelectedProjectsCountLabel.Location = new System.Drawing.Point(157, 34);
            this.SelectedProjectsCountLabel.Name = "SelectedProjectsCountLabel";
            this.SelectedProjectsCountLabel.Size = new System.Drawing.Size(13, 13);
            this.SelectedProjectsCountLabel.TabIndex = 4;
            this.SelectedProjectsCountLabel.Text = "0";
            // 
            // CurrentProjectLabel
            // 
            this.CurrentProjectLabel.AutoSize = true;
            this.CurrentProjectLabel.Location = new System.Drawing.Point(93, 9);
            this.CurrentProjectLabel.Name = "CurrentProjectLabel";
            this.CurrentProjectLabel.Size = new System.Drawing.Size(37, 13);
            this.CurrentProjectLabel.TabIndex = 5;
            this.CurrentProjectLabel.Text = "[none]";
            // 
            // MyProjectViewPartControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CurrentProjectLabel);
            this.Controls.Add(this.SelectedProjectsCountLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "MyProjectViewPartControl";
            this.Size = new System.Drawing.Size(819, 150);
            this.Load += new System.EventHandler(this.MyProjectViewPartControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label SelectedProjectsCountLabel;
        private System.Windows.Forms.Label CurrentProjectLabel;
    }
}
