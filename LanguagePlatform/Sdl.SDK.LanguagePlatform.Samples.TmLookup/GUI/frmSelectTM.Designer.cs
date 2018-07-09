namespace Sdl.SDK.LanguagePlatform.Samples.TmLookup
{
    partial class frmSelectTM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelectTM));
            this.groupBoxServerTM = new System.Windows.Forms.GroupBox();
            this.comboServerTMs = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtServerUri = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBoxServerTM.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxServerTM
            // 
            this.groupBoxServerTM.Controls.Add(this.comboServerTMs);
            this.groupBoxServerTM.Controls.Add(this.label4);
            this.groupBoxServerTM.Controls.Add(this.btnConnect);
            this.groupBoxServerTM.Controls.Add(this.label3);
            this.groupBoxServerTM.Controls.Add(this.label2);
            this.groupBoxServerTM.Controls.Add(this.label1);
            this.groupBoxServerTM.Controls.Add(this.txtPassword);
            this.groupBoxServerTM.Controls.Add(this.txtUserName);
            this.groupBoxServerTM.Controls.Add(this.txtServerUri);
            this.groupBoxServerTM.Location = new System.Drawing.Point(7, 12);
            this.groupBoxServerTM.Name = "groupBoxServerTM";
            this.groupBoxServerTM.Size = new System.Drawing.Size(450, 172);
            this.groupBoxServerTM.TabIndex = 3;
            this.groupBoxServerTM.TabStop = false;
            this.groupBoxServerTM.Text = "Select Server TM";
            // 
            // comboServerTMs
            // 
            this.comboServerTMs.Enabled = false;
            this.comboServerTMs.FormattingEnabled = true;
            this.comboServerTMs.Location = new System.Drawing.Point(74, 132);
            this.comboServerTMs.Name = "comboServerTMs";
            this.comboServerTMs.Size = new System.Drawing.Size(194, 21);
            this.comboServerTMs.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Select TM:";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(202, 95);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(70, 23);
            this.btnConnect.TabIndex = 6;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "User name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Server URI";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(75, 95);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(121, 20);
            this.txtPassword.TabIndex = 2;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(74, 65);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(123, 20);
            this.txtUserName.TabIndex = 1;
            // 
            // txtServerUri
            // 
            this.txtServerUri.Location = new System.Drawing.Point(74, 31);
            this.txtServerUri.Name = "txtServerUri";
            this.txtServerUri.Size = new System.Drawing.Size(368, 20);
            this.txtServerUri.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(392, 197);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(65, 24);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 197);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            this.lblStatus.TabIndex = 6;
            // 
            // btnOK
            // 
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(320, 198);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(66, 23);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmSelectTM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 228);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBoxServerTM);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSelectTM";
            this.Text = "Select Server Translation Memory";
            this.Load += new System.EventHandler(this.frmSelectTM_Load);
            this.groupBoxServerTM.ResumeLayout(false);
            this.groupBoxServerTM.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxServerTM;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtServerUri;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox comboServerTMs;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnOK;

    }
}