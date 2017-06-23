namespace Mingle.UC.Controls
{
    partial class UPhotoAndCustom
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
            this.gpbCustomInformation = new Scalable.Win.Controls.iGroupBox();
            this.gpbPictureAndNotes = new Scalable.Win.Controls.iGroupBox();
            this.uPictureAndNotes = new Mingle.UC.Controls.UPictureAndNotes();
            this.uPartyCustom = new Mingle.UC.Controls.UPartyCustom();
            this.gpbCustomInformation.SuspendLayout();
            this.gpbPictureAndNotes.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbCustomInformation
            // 
            this.gpbCustomInformation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbCustomInformation.Controls.Add(this.uPartyCustom);
            this.gpbCustomInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbCustomInformation.Location = new System.Drawing.Point(3, 175);
            this.gpbCustomInformation.Name = "gpbCustomInformation";
            this.gpbCustomInformation.Size = new System.Drawing.Size(393, 114);
            this.gpbCustomInformation.TabIndex = 1;
            this.gpbCustomInformation.TabStop = false;
            this.gpbCustomInformation.Text = "Custom Information";
            // 
            // gpbPictureAndNotes
            // 
            this.gpbPictureAndNotes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbPictureAndNotes.Controls.Add(this.uPictureAndNotes);
            this.gpbPictureAndNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbPictureAndNotes.Location = new System.Drawing.Point(3, 2);
            this.gpbPictureAndNotes.Name = "gpbPictureAndNotes";
            this.gpbPictureAndNotes.Size = new System.Drawing.Size(393, 172);
            this.gpbPictureAndNotes.TabIndex = 0;
            this.gpbPictureAndNotes.TabStop = false;
            this.gpbPictureAndNotes.Text = "Picture";
            // 
            // uPictureAndNotes
            // 
            this.uPictureAndNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uPictureAndNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uPictureAndNotes.Location = new System.Drawing.Point(3, 16);
            this.uPictureAndNotes.MaximumSize = new System.Drawing.Size(980, 151);
            this.uPictureAndNotes.MinimumSize = new System.Drawing.Size(383, 151);
            this.uPictureAndNotes.Name = "uPictureAndNotes";
            this.uPictureAndNotes.Size = new System.Drawing.Size(387, 151);
            this.uPictureAndNotes.TabIndex = 0;
            // 
            // uPartyCustom
            // 
            this.uPartyCustom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uPartyCustom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uPartyCustom.Location = new System.Drawing.Point(3, 16);
            this.uPartyCustom.MinimumSize = new System.Drawing.Size(387, 90);
            this.uPartyCustom.Name = "uPartyCustom";
            this.uPartyCustom.Size = new System.Drawing.Size(387, 95);
            this.uPartyCustom.TabIndex = 0;
            // 
            // UPhotoAndCustom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gpbPictureAndNotes);
            this.Controls.Add(this.gpbCustomInformation);
            this.Name = "UPhotoAndCustom";
            this.Size = new System.Drawing.Size(399, 290);
            this.gpbCustomInformation.ResumeLayout(false);
            this.gpbPictureAndNotes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UPictureAndNotes uPictureAndNotes;
        private Scalable.Win.Controls.iGroupBox gpbCustomInformation;
        private UPartyCustom uPartyCustom;
        private Scalable.Win.Controls.iGroupBox gpbPictureAndNotes;
    }
}
