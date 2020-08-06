namespace Sdl.SDK.LanguagePlatform.Samples.TmLookup
{
    partial class frmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.trackFuzzy = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaxHits = new System.Windows.Forms.TextBox();
            this.lblFuzzyValue = new System.Windows.Forms.Label();
            this.btnDefaults = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackFuzzy)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(220, 179);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(71, 27);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(297, 179);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(66, 26);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // trackFuzzy
            // 
            this.trackFuzzy.Location = new System.Drawing.Point(6, 94);
            this.trackFuzzy.Maximum = 100;
            this.trackFuzzy.Minimum = 30;
            this.trackFuzzy.Name = "trackFuzzy";
            this.trackFuzzy.Size = new System.Drawing.Size(302, 50);
            this.trackFuzzy.TabIndex = 2;
            this.trackFuzzy.Value = 70;
            this.trackFuzzy.Scroll += new System.EventHandler(this.TrackFuzzy_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Minimum fuzzy value (30 - 100%)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Maxmimum number of hits";
            // 
            // txtMaxHits
            // 
            this.txtMaxHits.Location = new System.Drawing.Point(154, 19);
            this.txtMaxHits.MaxLength = 2;
            this.txtMaxHits.Name = "txtMaxHits";
            this.txtMaxHits.Size = new System.Drawing.Size(39, 20);
            this.txtMaxHits.TabIndex = 5;
            this.txtMaxHits.Text = "30";
            // 
            // lblFuzzyValue
            // 
            this.lblFuzzyValue.AutoSize = true;
            this.lblFuzzyValue.Location = new System.Drawing.Point(314, 104);
            this.lblFuzzyValue.Name = "lblFuzzyValue";
            this.lblFuzzyValue.Size = new System.Drawing.Size(19, 13);
            this.lblFuzzyValue.TabIndex = 6;
            this.lblFuzzyValue.Text = "70";
            // 
            // btnDefaults
            // 
            this.btnDefaults.Location = new System.Drawing.Point(5, 180);
            this.btnDefaults.Name = "btnDefaults";
            this.btnDefaults.Size = new System.Drawing.Size(98, 26);
            this.btnDefaults.TabIndex = 7;
            this.btnDefaults.Text = "Reset to defaults";
            this.btnDefaults.UseVisualStyleBackColor = true;
            this.btnDefaults.Click += new System.EventHandler(this.BtnDefaults_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtMaxHits);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblFuzzyValue);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.trackFuzzy);
            this.groupBox1.Location = new System.Drawing.Point(5, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(358, 170);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configure Settings";
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 213);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDefaults);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSettings";
            this.Text = "Search Settings";
            ((System.ComponentModel.ISupportInitialize)(this.trackFuzzy)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TrackBar trackFuzzy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaxHits;
        private System.Windows.Forms.Label lblFuzzyValue;
        private System.Windows.Forms.Button btnDefaults;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}