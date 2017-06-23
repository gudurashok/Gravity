namespace Synergy.UC.Forms
{
    partial class FOptions
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
            this.uOptions = new Synergy.UC.Controls.UOptions();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Size = new System.Drawing.Size(554, 43);
            // 
            // picLogo
            // 
            this.picLogo.Location = new System.Drawing.Point(753, 2);
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(744, 39);
            // 
            // uOptions
            // 
            this.uOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uOptions.Location = new System.Drawing.Point(0, 45);
            this.uOptions.Name = "uOptions";
            this.uOptions.Size = new System.Drawing.Size(555, 354);
            this.uOptions.TabIndex = 13;
            // 
            // FOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 399);
            this.Controls.Add(this.uOptions);
            this.MinimumSize = new System.Drawing.Size(562, 433);
            this.Name = "FOptions";
            this.Text = "FOptions";
            this.Controls.SetChildIndex(this.uOptions, 0);
            this.Controls.SetChildIndex(this.pnlHeader, 0);
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.UOptions uOptions;





    }
}