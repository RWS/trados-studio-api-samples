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
            this.openPackageBtn = new System.Windows.Forms.Button();
            this.openSpecificPackageBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.packagePathTxt = new System.Windows.Forms.TextBox();
            this.createReturnPackageBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.packageIDTxt = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // openPackageBtn
            // 
            this.openPackageBtn.Location = new System.Drawing.Point(14, 19);
            this.openPackageBtn.Name = "openPackageBtn";
            this.openPackageBtn.Size = new System.Drawing.Size(126, 23);
            this.openPackageBtn.TabIndex = 0;
            this.openPackageBtn.Text = "Open Package";
            this.openPackageBtn.UseVisualStyleBackColor = true;
            this.openPackageBtn.Click += new System.EventHandler(this.openPackageBtn_Click);
            // 
            // openSpecificPackageBtn
            // 
            this.openSpecificPackageBtn.Location = new System.Drawing.Point(6, 47);
            this.openSpecificPackageBtn.Name = "openSpecificPackageBtn";
            this.openSpecificPackageBtn.Size = new System.Drawing.Size(126, 23);
            this.openSpecificPackageBtn.TabIndex = 1;
            this.openSpecificPackageBtn.Text = "Open Package";
            this.openSpecificPackageBtn.UseVisualStyleBackColor = true;
            this.openSpecificPackageBtn.Click += new System.EventHandler(this.openSpecificPackageBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.packagePathTxt);
            this.groupBox1.Controls.Add(this.openSpecificPackageBtn);
            this.groupBox1.Location = new System.Drawing.Point(14, 73);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(420, 100);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Choose package path";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Package path";
            // 
            // packagePathTxt
            // 
            this.packagePathTxt.Location = new System.Drawing.Point(91, 21);
            this.packagePathTxt.Name = "packagePathTxt";
            this.packagePathTxt.Size = new System.Drawing.Size(310, 20);
            this.packagePathTxt.TabIndex = 2;
            // 
            // createReturnPackageBtn
            // 
            this.createReturnPackageBtn.Location = new System.Drawing.Point(38, 72);
            this.createReturnPackageBtn.Name = "createReturnPackageBtn";
            this.createReturnPackageBtn.Size = new System.Drawing.Size(143, 23);
            this.createReturnPackageBtn.TabIndex = 3;
            this.createReturnPackageBtn.Text = "Create Return Package";
            this.createReturnPackageBtn.UseVisualStyleBackColor = true;
            this.createReturnPackageBtn.Click += new System.EventHandler(this.createReturnPackageBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Package ID:";
            // 
            // packageIDTxt
            // 
            this.packageIDTxt.Location = new System.Drawing.Point(106, 37);
            this.packageIDTxt.Name = "packageIDTxt";
            this.packageIDTxt.Size = new System.Drawing.Size(75, 20);
            this.packageIDTxt.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.packageIDTxt);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.createReturnPackageBtn);
            this.groupBox2.Location = new System.Drawing.Point(513, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(211, 189);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Return package";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Controls.Add(this.openPackageBtn);
            this.groupBox3.Location = new System.Drawing.Point(12, 10);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(459, 189);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Open package";
            // 
            // PackagesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Name = "PackagesControl";
            this.Size = new System.Drawing.Size(762, 216);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button openPackageBtn;
        private System.Windows.Forms.Button openSpecificPackageBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox packagePathTxt;
        private System.Windows.Forms.Button createReturnPackageBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox packageIDTxt;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}
