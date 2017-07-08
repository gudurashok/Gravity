namespace Scalable.Win.FormControls
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
            this.lblVersion = new Scalable.Win.Controls.iLabel();
            this.pictureBox1 = new Scalable.Win.Controls.iPictureBox();
            this.picLoading = new Scalable.Win.Controls.iPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // lnkiScalableWeb
            // 
            this.lnkiScalableWeb.AutoSize = true;
            this.lnkiScalableWeb.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkiScalableWeb.Location = new System.Drawing.Point(238, 293);
            this.lnkiScalableWeb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkiScalableWeb.Name = "lnkiScalableWeb";
            this.lnkiScalableWeb.Size = new System.Drawing.Size(258, 17);
            this.lnkiScalableWeb.TabIndex = 14;
            this.lnkiScalableWeb.TabStop = true;
            this.lnkiScalableWeb.Text = "Visit us at: http://www.gravitysoftware.in";
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVersion.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Location = new System.Drawing.Point(153, 161);
            this.lblVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(223, 17);
            this.lblVersion.TabIndex = 13;
            this.lblVersion.Text = "Version: 1.0.0.0000";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(223, 102);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(59, 53);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // picLoading
            // 
            this.picLoading.Image = ((System.Drawing.Image)(resources.GetObject("picLoading.Image")));
            this.picLoading.Location = new System.Drawing.Point(13, 14);
            this.picLoading.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picLoading.Name = "picLoading";
            this.picLoading.Size = new System.Drawing.Size(51, 49);
            this.picLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picLoading.TabIndex = 11;
            this.picLoading.TabStop = false;
            // 
            // USplash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.lnkiScalableWeb);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.picLoading);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "USplash";
            this.Size = new System.Drawing.Size(531, 325);
            this.Load += new System.EventHandler(this.USplash_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Scalable.Win.Controls.iLinkLabel lnkiScalableWeb;
        private Scalable.Win.Controls.iLabel lblVersion;
        private Scalable.Win.Controls.iPictureBox pictureBox1;
        private Scalable.Win.Controls.iPictureBox picLoading;
    }
}
