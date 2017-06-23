namespace Synergy.UC.Forms
{
    partial class FTaskStatistics
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
            this.uTaskStatistics = new Synergy.UC.Controls.UTaskStatistics();
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
            this.picLogo.Location = new System.Drawing.Point(389, 2);
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(380, 39);
            // 
            // uTaskStatistics
            // 
            this.uTaskStatistics.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uTaskStatistics.Location = new System.Drawing.Point(0, 45);
            this.uTaskStatistics.MinimumSize = new System.Drawing.Size(428, 276);
            this.uTaskStatistics.Name = "uTaskStatistics";
            this.uTaskStatistics.Size = new System.Drawing.Size(432, 280);
            this.uTaskStatistics.TabIndex = 13;
            // 
            // FTaskStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 325);
            this.Controls.Add(this.uTaskStatistics);
            this.Name = "FTaskStatistics";
            this.Text = "FTaskStatistics";
            this.Controls.SetChildIndex(this.uTaskStatistics, 0);
            this.Controls.SetChildIndex(this.pnlHeader, 0);
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.UTaskStatistics uTaskStatistics;
    }
}