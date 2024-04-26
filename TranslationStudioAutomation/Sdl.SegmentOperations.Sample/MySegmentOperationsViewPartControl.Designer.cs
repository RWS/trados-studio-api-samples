namespace Sdl.SegmentOperations.Sample
{
    partial class MySegmentOperationsViewPartControl
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
            this._previousSegmentIdLabel = new System.Windows.Forms.Label();
            this._currentSegmentIdLabel = new System.Windows.Forms.Label();
            this._distanceLabel = new System.Windows.Forms.Label();
            this._scoreLabel = new System.Windows.Forms.Label();
            this._wordsCountLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _previousSegmentIdLabel
            // 
            this._previousSegmentIdLabel.AutoSize = true;
            this._previousSegmentIdLabel.Location = new System.Drawing.Point(2, 0);
            this._previousSegmentIdLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this._previousSegmentIdLabel.Name = "_previousSegmentIdLabel";
            this._previousSegmentIdLabel.Size = new System.Drawing.Size(0, 13);
            this._previousSegmentIdLabel.TabIndex = 0;
            // 
            // _currentSegmentIdLabel
            // 
            this._currentSegmentIdLabel.AutoSize = true;
            this._currentSegmentIdLabel.Location = new System.Drawing.Point(2, 24);
            this._currentSegmentIdLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this._currentSegmentIdLabel.Name = "_currentSegmentIdLabel";
            this._currentSegmentIdLabel.Size = new System.Drawing.Size(0, 13);
            this._currentSegmentIdLabel.TabIndex = 1;
            // 
            // _distanceLabel
            // 
            this._distanceLabel.AutoSize = true;
            this._distanceLabel.Location = new System.Drawing.Point(2, 48);
            this._distanceLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this._distanceLabel.Name = "_distanceLabel";
            this._distanceLabel.Size = new System.Drawing.Size(0, 13);
            this._distanceLabel.TabIndex = 2;
            // 
            // _scoreLabel
            // 
            this._scoreLabel.AutoSize = true;
            this._scoreLabel.Location = new System.Drawing.Point(2, 71);
            this._scoreLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this._scoreLabel.Name = "_scoreLabel";
            this._scoreLabel.Size = new System.Drawing.Size(0, 13);
            this._scoreLabel.TabIndex = 3;
            // 
            // _wordsCountLabel
            // 
            this._wordsCountLabel.AutoSize = true;
            this._wordsCountLabel.Location = new System.Drawing.Point(2, 96);
            this._wordsCountLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this._wordsCountLabel.Name = "_wordsCountLabel";
            this._wordsCountLabel.Size = new System.Drawing.Size(0, 13);
            this._wordsCountLabel.TabIndex = 4;
            // 
            // MySegmentOperationsViewPartControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._scoreLabel);
            this.Controls.Add(this._distanceLabel);
            this.Controls.Add(this._currentSegmentIdLabel);
            this.Controls.Add(this._previousSegmentIdLabel);
            this.Controls.Add(this._wordsCountLabel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MySegmentOperationsViewPartControl";
            this.Size = new System.Drawing.Size(415, 236);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _previousSegmentIdLabel;
        private System.Windows.Forms.Label _currentSegmentIdLabel;
        private System.Windows.Forms.Label _distanceLabel;
        private System.Windows.Forms.Label _scoreLabel;
        private System.Windows.Forms.Label _wordsCountLabel;
    }
}
