namespace Synergy.UC.Forms
{
    partial class FFileAttachment
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
            this.uFileAttachment = new Synergy.UC.Controls.UFileAttachment();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Size = new System.Drawing.Size(536, 43);
            // 
            // picLogo
            // 
            this.picLogo.Location = new System.Drawing.Point(493, 2);
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(484, 39);
            // 
            // uFileAttachment
            // 
            this.uFileAttachment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uFileAttachment.Location = new System.Drawing.Point(-1, 43);
            this.uFileAttachment.MinimumSize = new System.Drawing.Size(440, 262);
            this.uFileAttachment.Name = "uFileAttachment";
            this.uFileAttachment.ReadOnly = false;
            this.uFileAttachment.SearchProperty = "Name";
            this.uFileAttachment.Size = new System.Drawing.Size(538, 289);
            this.uFileAttachment.TabIndex = 13;
            this.uFileAttachment.AttachmentsSaved += new System.EventHandler(this.uFileAttachment_AttachmentsSaved);
            // 
            // FFileAttachment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 332);
            this.Controls.Add(this.uFileAttachment);
            this.MinimumSize = new System.Drawing.Size(461, 366);
            this.Name = "FFileAttachment";
            this.Text = "FFileAttachment";
            this.Controls.SetChildIndex(this.uFileAttachment, 0);
            this.Controls.SetChildIndex(this.pnlHeader, 0);
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.UFileAttachment uFileAttachment;
    }
}