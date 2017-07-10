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
            this.lnkEMail.Location = new System.Drawing.Point(181, 244);
            this.lnkEMail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkEMail.Name = "lnkEMail";
            this.lnkEMail.Size = new System.Drawing.Size(223, 18);
            this.lnkEMail.TabIndex = 2;
            this.lnkEMail.TabStop = true;
            this.lnkEMail.Text = "Email us: info@gravitysoftware.in";
            // 
            // lnkiScalableWeb
            // 
            this.lnkiScalableWeb.AutoSize = true;
            this.lnkiScalableWeb.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkiScalableWeb.Location = new System.Drawing.Point(157, 219);
            this.lnkiScalableWeb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkiScalableWeb.Name = "lnkiScalableWeb";
            this.lnkiScalableWeb.Size = new System.Drawing.Size(274, 18);
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
            this.lblVersion.Location = new System.Drawing.Point(195, 178);
            this.lblVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(223, 17);
            this.lblVersion.TabIndex = 0;
            this.lblVersion.Text = "Version: 1.0.0.0000";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCopyright
            // 
            this.lblCopyright.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCopyright.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCopyright.Location = new System.Drawing.Point(16, 351);
            this.lblCopyright.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(564, 16);
            this.lblCopyright.TabIndex = 0;
            this.lblCopyright.Text = "© 2017 Gravity Software Technologies Private Limited. All rights reserved.";
            this.lblCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picLogo
            // 
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(268, 113);
            this.picLogo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(59, 53);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 20;
            this.picLogo.TabStop = false;
            // 
            // picTitle
            // 
            this.picTitle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picTitle.BackgroundImage")));
            this.picTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picTitle.Location = new System.Drawing.Point(121, 14);
            this.picTitle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picTitle.Name = "picTitle";
            this.picTitle.Size = new System.Drawing.Size(353, 92);
            this.picTitle.TabIndex = 19;
            this.picTitle.TabStop = false;
            // 
            // pnlCopyrightNotice
            // 
            this.pnlCopyrightNotice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCopyrightNotice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCopyrightNotice.Controls.Add(this.lblCopyrightNotice);
            this.pnlCopyrightNotice.Location = new System.Drawing.Point(-3, 271);
            this.pnlCopyrightNotice.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlCopyrightNotice.Name = "pnlCopyrightNotice";
            this.pnlCopyrightNotice.Size = new System.Drawing.Size(599, 75);
            this.pnlCopyrightNotice.TabIndex = 3;
            // 
            // lblCopyrightNotice
            // 
            this.lblCopyrightNotice.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCopyrightNotice.Location = new System.Drawing.Point(1, 2);
            this.lblCopyrightNotice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCopyrightNotice.Name = "lblCopyrightNotice";
            this.lblCopyrightNotice.Size = new System.Drawing.Size(592, 69);
            this.lblCopyrightNotice.TabIndex = 0;
            this.lblCopyrightNotice.Text = resources.GetString("lblCopyrightNotice.Text");
            // 
            // UAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lnkEMail);
            this.Controls.Add(this.lnkiScalableWeb);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblCopyright);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.picTitle);
            this.Controls.Add(this.pnlCopyrightNotice);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "UAbout";
            this.Size = new System.Drawing.Size(595, 379);
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
