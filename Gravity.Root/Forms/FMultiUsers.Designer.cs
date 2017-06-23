namespace Gravity.Root.Forms
{
    partial class FMultiUsers
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
            this.uMultiUsers = new Gravity.Root.Controls.UMultiUsers();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Size = new System.Drawing.Size(264, 43);
            // 
            // picLogo
            // 
            this.picLogo.Location = new System.Drawing.Point(221, 2);
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(212, 39);
            // 
            // uMultiUsers
            // 
            this.uMultiUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uMultiUsers.Location = new System.Drawing.Point(0, 43);
            this.uMultiUsers.Name = "uMultiUsers";
            this.uMultiUsers.Size = new System.Drawing.Size(265, 262);
            this.uMultiUsers.TabIndex = 13;
            // 
            // FMultiUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 304);
            this.Controls.Add(this.uMultiUsers);
            this.MinimumSize = new System.Drawing.Size(272, 338);
            this.Name = "FMultiUsers";
            this.Text = "FMultiUsers";
            this.Controls.SetChildIndex(this.uMultiUsers, 0);
            this.Controls.SetChildIndex(this.pnlHeader, 0);
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.UMultiUsers uMultiUsers;
    }
}