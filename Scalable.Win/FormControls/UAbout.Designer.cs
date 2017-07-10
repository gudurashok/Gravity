namespace Scalable.Win.FormControls
{
    partial class UAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UAbout));
            this.lnkEMail = new Scalable.Win.Controls.iLinkLabel();
            this.lnkiScalableWeb = new Scalable.Win.Controls.iLinkLabel();
            this.lblVersion = new Scalable.Win.Controls.iLabel();
            this.lblCopyright = new Scalable.Win.Controls.iLabel();
            this.picLogo = new Scalable.Win.Controls.iPictureBox();
            this.picTitle = new Scalable.Win.Controls.iPictureBox();
            this.pnlCopyrightNotice = new Scalable.Win.Controls.iPanel();
            this.lblCopyrightNotice = new Scalable.Win.Controls.iLabel();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).BeginInit();
            this.pnlCopyrightNotice.SuspendLayout();
            this.SuspendLayout();
            // 
            // lnkEMail
            // 
            this.lnkEMail.AutoSize = true;
            this.lnkEMail.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkEMail.Location = new System.Drawing.Point(136, 198);
            this.lnkEMail.Name = "lnkEMail";
            this.lnkEMail.Size = new System.Drawing.Size(159, 14);
            this.lnkEMail.TabIndex = 2;
            this.lnkEMail.TabStop = true;
            this.lnkEMail.Text = "Email us: info@gravitysoftware.in";
            // 
            // lnkiScalableWeb
            // 
            this.lnkiScalableWeb.AutoSize = true;
            this.lnkiScalableWeb.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkiScalableWeb.Location = new System.Drawing.Point(118, 178);
            this.lnkiScalableWeb.Name = "lnkiScalableWeb";
            this.lnkiScalableWeb.Size = new System.Drawing.Size(210, 14);
            this.lnkiScalableWeb.TabIndex = 1;
            this.lnkiScalableWeb.TabStop = true;
            this.lnkiScalableWeb.Text = "Visit us at: http://www.gravitysoftware.in";
            this.lnkiScalableWeb.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkClicked);
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVersion.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Location = new System.Drawing.Point(146, 145);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(167, 14);
            this.lblVersion.TabIndex = 0;
            this.lblVersion.Text = "Version: 1.0.0.0000";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCopyright
            // 
            this.lblCopyright.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCopyright.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCopyright.Location = new System.Drawing.Point(12, 285);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(423, 13);
            this.lblCopyright.TabIndex = 0;
            this.lblCopyright.Text = "© 2017 Gravity Software Technologies Private Limited. All rights reserved.";
            this.lblCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picLogo
            // 
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(201, 92);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(44, 43);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 20;
            this.picLogo.TabStop = false;
            // 
            // picTitle
            // 
            this.picTitle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picTitle.BackgroundImage")));
            this.picTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picTitle.Location = new System.Drawing.Point(91, 11);
            this.picTitle.Name = "picTitle";
            this.picTitle.Size = new System.Drawing.Size(265, 75);
            this.picTitle.TabIndex = 19;
            this.picTitle.TabStop = false;
            // 
            // pnlCopyrightNotice
            // 
            this.pnlCopyrightNotice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCopyrightNotice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCopyrightNotice.Controls.Add(this.lblCopyrightNotice);
            this.pnlCopyrightNotice.Location = new System.Drawing.Point(-2, 220);
            this.pnlCopyrightNotice.Name = "pnlCopyrightNotice";
            this.pnlCopyrightNotice.Size = new System.Drawing.Size(450, 61);
            this.pnlCopyrightNotice.TabIndex = 3;
            // 
            // lblCopyrightNotice
            // 
            this.lblCopyrightNotice.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCopyrightNotice.Location = new System.Drawing.Point(1, 2);
            this.lblCopyrightNotice.Name = "lblCopyrightNotice";
            this.lblCopyrightNotice.Size = new System.Drawing.Size(444, 56);
            this.lblCopyrightNotice.TabIndex = 0;
            this.lblCopyrightNotice.Text = resources.GetString("lblCopyrightNotice.Text");
            // 
            // UAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lnkEMail);
            this.Controls.Add(this.lnkiScalableWeb);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblCopyright);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.picTitle);
            this.Controls.Add(this.pnlCopyrightNotice);
            this.Name = "UAbout";
            this.Size = new System.Drawing.Size(446, 308);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.UAbout_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).EndInit();
            this.pnlCopyrightNotice.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Scalable.Win.Controls.iLinkLabel lnkEMail;
        private Scalable.Win.Controls.iLinkLabel lnkiScalableWeb;
        private Scalable.Win.Controls.iLabel lblVersion;
        private Scalable.Win.Controls.iLabel lblCopyright;
        private Scalable.Win.Controls.iPictureBox picLogo;
        private Scalable.Win.Controls.iPictureBox picTitle;
        private Scalable.Win.Controls.iPanel pnlCopyrightNotice;
        private Scalable.Win.Controls.iLabel lblCopyrightNotice;



    }
}
