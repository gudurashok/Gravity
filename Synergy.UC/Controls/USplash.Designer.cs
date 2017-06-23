namespace Synergy.UC.Controls
{
    partial class USplash
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(USplash));
            this.lnkiScalableWeb = new Scalable.Win.Controls.iLinkLabel();
            this.picLoading = new Scalable.Win.Controls.iPictureBox();
            this.lblVersion = new Scalable.Win.Controls.iLabel();
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // lnkiScalableWeb
            // 
            this.lnkiScalableWeb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkiScalableWeb.AutoSize = true;
            this.lnkiScalableWeb.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkiScalableWeb.Location = new System.Drawing.Point(144, 308);
            this.lnkiScalableWeb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkiScalableWeb.Name = "lnkiScalableWeb";
            this.lnkiScalableWeb.Size = new System.Drawing.Size(258, 17);
            this.lnkiScalableWeb.TabIndex = 14;
            this.lnkiScalableWeb.TabStop = true;
            this.lnkiScalableWeb.Text = "Visit us at: http://www.gravitysoftware.in";
            this.lnkiScalableWeb.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkiScalableWeb_LinkClicked);
            // 
            // picLoading
            // 
            this.picLoading.Image = ((System.Drawing.Image)(resources.GetObject("picLoading.Image")));
            this.picLoading.Location = new System.Drawing.Point(13, 14);
            this.picLoading.Margin = new System.Windows.Forms.Padding(4);
            this.picLoading.Name = "picLoading";
            this.picLoading.Size = new System.Drawing.Size(51, 49);
            this.picLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picLoading.TabIndex = 11;
            this.picLoading.TabStop = false;
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVersion.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblVersion.Location = new System.Drawing.Point(360, 191);
            this.lblVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(175, 17);
            this.lblVersion.TabIndex = 15;
            this.lblVersion.Text = "Version: 1.0.0.0000";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // USplash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lnkiScalableWeb);
            this.Controls.Add(this.picLoading);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "USplash";
            this.Size = new System.Drawing.Size(545, 340);
            this.Load += new System.EventHandler(this.USplash_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Scalable.Win.Controls.iLinkLabel lnkiScalableWeb;
        private Scalable.Win.Controls.iPictureBox picLoading;
        private Scalable.Win.Controls.iLabel lblVersion;
    }
}
