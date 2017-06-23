namespace Gravity.Root.Forms
{
    partial class FUserFeedback
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
            this.uUserFeedback = new Gravity.Root.Controls.UUserFeedback();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Size = new System.Drawing.Size(432, 43);
            // 
            // picLogo
            // 
            this.picLogo.Location = new System.Drawing.Point(461, 2);
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(452, 39);
            this.lblTitle.Text = "Enter your feedback below and click <Send>";
            // 
            // uUserFeedback
            // 
            this.uUserFeedback.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uUserFeedback.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uUserFeedback.Location = new System.Drawing.Point(0, 45);
            this.uUserFeedback.Name = "uUserFeedback";
            this.uUserFeedback.Size = new System.Drawing.Size(432, 223);
            this.uUserFeedback.TabIndex = 13;
            this.uUserFeedback.CloseForm += new System.EventHandler(this.uUserFeedback_CloseForm);
            // 
            // FUserFeedback
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 268);
            this.Controls.Add(this.uUserFeedback);
            this.MinimumSize = new System.Drawing.Size(376, 274);
            this.Name = "FUserFeedback";
            this.Text = "User Feedback";
            this.Controls.SetChildIndex(this.pnlHeader, 0);
            this.Controls.SetChildIndex(this.uUserFeedback, 0);
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.UUserFeedback uUserFeedback;

    }
}