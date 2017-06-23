namespace Synergy.UC.Forms
{
    partial class FTaskTemplate
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
            this.uTaskTemplate = new Synergy.UC.Controls.UTaskTemplate();
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
            this.picLogo.Location = new System.Drawing.Point(511, 2);
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(502, 39);
            // 
            // uTaskTemplate
            // 
            this.uTaskTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uTaskTemplate.Location = new System.Drawing.Point(-1, 44);
            this.uTaskTemplate.Name = "uTaskTemplate";
            this.uTaskTemplate.Size = new System.Drawing.Size(555, 402);
            this.uTaskTemplate.TabIndex = 13;
            // 
            // FTaskTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 446);
            this.Controls.Add(this.uTaskTemplate);
            this.MinimumSize = new System.Drawing.Size(562, 480);
            this.Name = "FTaskTemplate";
            this.Text = "FTaskTemplate";
            this.Controls.SetChildIndex(this.uTaskTemplate, 0);
            this.Controls.SetChildIndex(this.pnlHeader, 0);
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.UTaskTemplate uTaskTemplate;
    }
}