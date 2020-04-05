namespace PortMan2014
{
	partial class FrmSplash
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
            this.lbVersion = new System.Windows.Forms.Label();
            this.lbCopyright = new System.Windows.Forms.Label();
            this.lbDevelopers = new System.Windows.Forms.Label();
            this.lbTestQuality = new System.Windows.Forms.Label();
            this.lbBeta = new System.Windows.Forms.Label();
            this.pnSplash = new System.Windows.Forms.Panel();
            this.lbManagement = new System.Windows.Forms.Label();
            this.pnAppVersion = new System.Windows.Forms.Panel();
            this.lbBolum = new DevExpress.XtraEditors.LabelControl();
            this.lbApplication = new DevExpress.XtraEditors.LabelControl();
            this.picLogo = new DevExpress.XtraEditors.PictureEdit();
            this.pictureSplash = new System.Windows.Forms.PictureBox();
            this.pnSplash.SuspendLayout();
            this.pnAppVersion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSplash)).BeginInit();
            this.SuspendLayout();
            // 
            // lbVersion
            // 
            this.lbVersion.AutoSize = true;
            this.lbVersion.BackColor = System.Drawing.Color.White;
            this.lbVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbVersion.Location = new System.Drawing.Point(11, 56);
            this.lbVersion.Name = "lbVersion";
            this.lbVersion.Size = new System.Drawing.Size(60, 16);
            this.lbVersion.TabIndex = 3;
            this.lbVersion.Text = "v1.0.0.0";
            this.lbVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbVersion.Click += new System.EventHandler(this.pictureSplash_Click);
            // 
            // lbCopyright
            // 
            this.lbCopyright.AutoSize = true;
            this.lbCopyright.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbCopyright.Location = new System.Drawing.Point(7, 164);
            this.lbCopyright.Name = "lbCopyright";
            this.lbCopyright.Size = new System.Drawing.Size(257, 13);
            this.lbCopyright.TabIndex = 32;
            this.lbCopyright.Text = "Copyright 2014 © AVEA. All Rights Reserved.";
            this.lbCopyright.Click += new System.EventHandler(this.pictureSplash_Click);
            // 
            // lbDevelopers
            // 
            this.lbDevelopers.AutoSize = true;
            this.lbDevelopers.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbDevelopers.Location = new System.Drawing.Point(11, 123);
            this.lbDevelopers.Name = "lbDevelopers";
            this.lbDevelopers.Size = new System.Drawing.Size(226, 13);
            this.lbDevelopers.TabIndex = 35;
            this.lbDevelopers.Text = "Developers :  Hasan Yildirim / Gokhan Yenigun";
            this.lbDevelopers.Click += new System.EventHandler(this.pictureSplash_Click);
            // 
            // lbTestQuality
            // 
            this.lbTestQuality.AutoSize = true;
            this.lbTestQuality.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbTestQuality.Location = new System.Drawing.Point(11, 136);
            this.lbTestQuality.Name = "lbTestQuality";
            this.lbTestQuality.Size = new System.Drawing.Size(204, 13);
            this.lbTestQuality.TabIndex = 36;
            this.lbTestQuality.Text = "Analys && Design : Faruk Acik / Kadir Polat";
            // 
            // lbBeta
            // 
            this.lbBeta.AutoSize = true;
            this.lbBeta.Font = new System.Drawing.Font("Tahoma", 6.75F);
            this.lbBeta.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbBeta.Location = new System.Drawing.Point(77, 60);
            this.lbBeta.Name = "lbBeta";
            this.lbBeta.Size = new System.Drawing.Size(72, 11);
            this.lbBeta.TabIndex = 44;
            this.lbBeta.Text = "[ Final Release ]";
            // 
            // pnSplash
            // 
            this.pnSplash.BackColor = System.Drawing.Color.White;
            this.pnSplash.Controls.Add(this.lbManagement);
            this.pnSplash.Controls.Add(this.pnAppVersion);
            this.pnSplash.Controls.Add(this.lbTestQuality);
            this.pnSplash.Controls.Add(this.lbCopyright);
            this.pnSplash.Controls.Add(this.lbDevelopers);
            this.pnSplash.Location = new System.Drawing.Point(268, 0);
            this.pnSplash.Name = "pnSplash";
            this.pnSplash.Size = new System.Drawing.Size(279, 208);
            this.pnSplash.TabIndex = 45;
            // 
            // lbManagement
            // 
            this.lbManagement.AutoSize = true;
            this.lbManagement.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbManagement.Location = new System.Drawing.Point(11, 110);
            this.lbManagement.Name = "lbManagement";
            this.lbManagement.Size = new System.Drawing.Size(210, 13);
            this.lbManagement.TabIndex = 46;
            this.lbManagement.Text = "Management :  Ihsan Bozdag / Engin Uzun";
            // 
            // pnAppVersion
            // 
            this.pnAppVersion.Controls.Add(this.lbBolum);
            this.pnAppVersion.Controls.Add(this.lbApplication);
            this.pnAppVersion.Controls.Add(this.lbVersion);
            this.pnAppVersion.Controls.Add(this.lbBeta);
            this.pnAppVersion.Location = new System.Drawing.Point(3, 15);
            this.pnAppVersion.Name = "pnAppVersion";
            this.pnAppVersion.Size = new System.Drawing.Size(266, 80);
            this.pnAppVersion.TabIndex = 45;
            // 
            // lbBolum
            // 
            this.lbBolum.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbBolum.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.lbBolum.Location = new System.Drawing.Point(11, 35);
            this.lbBolum.Name = "lbBolum";
            this.lbBolum.Size = new System.Drawing.Size(119, 18);
            this.lbBolum.TabIndex = 51;
            this.lbBolum.Text = "Powered by CIS";
            // 
            // lbApplication
            // 
            this.lbApplication.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbApplication.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lbApplication.Location = new System.Drawing.Point(11, 8);
            this.lbApplication.Name = "lbApplication";
            this.lbApplication.Size = new System.Drawing.Size(161, 29);
            this.lbApplication.TabIndex = 50;
            this.lbApplication.Text = "PortMan2014";
            // 
            // picLogo
            // 
            this.picLogo.EditValue = global::PortMan2014.Properties.Resources.TT01;
            this.picLogo.Location = new System.Drawing.Point(48, 149);
            this.picLogo.Name = "picLogo";
            this.picLogo.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.picLogo.Properties.Appearance.Options.UseBackColor = true;
            this.picLogo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picLogo.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.picLogo.Size = new System.Drawing.Size(161, 48);
            this.picLogo.TabIndex = 48;
            // 
            // pictureSplash
            // 
            this.pictureSplash.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureSplash.Image = global::PortMan2014.Properties.Resources.SPLASH;
            this.pictureSplash.Location = new System.Drawing.Point(0, 0);
            this.pictureSplash.Name = "pictureSplash";
            this.pictureSplash.Size = new System.Drawing.Size(549, 209);
            this.pictureSplash.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureSplash.TabIndex = 0;
            this.pictureSplash.TabStop = false;
            this.pictureSplash.Click += new System.EventHandler(this.pictureSplash_Click);
            // 
            // FrmSplash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(549, 209);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.pnSplash);
            this.Controls.Add(this.pictureSplash);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmSplash";
            this.Text = "frmSplash";
            this.pnSplash.ResumeLayout(false);
            this.pnSplash.PerformLayout();
            this.pnAppVersion.ResumeLayout(false);
            this.pnAppVersion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSplash)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureSplash;
        private System.Windows.Forms.Label lbVersion;
        private System.Windows.Forms.Label lbCopyright;
        private System.Windows.Forms.Label lbDevelopers;
        private System.Windows.Forms.Label lbTestQuality;
        private System.Windows.Forms.Label lbBeta;
        private System.Windows.Forms.Panel pnSplash;
        private System.Windows.Forms.Panel pnAppVersion;
        private System.Windows.Forms.Label lbManagement;
        private DevExpress.XtraEditors.PictureEdit picLogo;
        private DevExpress.XtraEditors.LabelControl lbApplication;
        private DevExpress.XtraEditors.LabelControl lbBolum;
	}
}