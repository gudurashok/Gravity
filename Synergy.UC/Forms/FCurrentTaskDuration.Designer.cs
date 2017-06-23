namespace Synergy.UC.Forms
{
    partial class FCurrentTaskDuration
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
            this.uCurrentTaskDuration = new Synergy.UC.Controls.UCurrentTaskDuration();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Size = new System.Drawing.Size(368, 43);
            // 
            // picLogo
            // 
            this.picLogo.Location = new System.Drawing.Point(325, 2);
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(316, 39);
            // 
            // uCurrentTaskDuration
            // 
            this.uCurrentTaskDuration.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uCurrentTaskDuration.Location = new System.Drawing.Point(0, 45);
            this.uCurrentTaskDuration.MinimumSize = new System.Drawing.Size(218, 137);
            this.uCurrentTaskDuration.Name = "uCurrentTaskDuration";
            this.uCurrentTaskDuration.Size = new System.Drawing.Size(368, 213);
            this.uCurrentTaskDuration.TabIndex = 13;
            // 
            // FCurrentTaskDuration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 257);
            this.Controls.Add(this.uCurrentTaskDuration);
            this.Name = "FCurrentTaskDuration";
            this.Text = "FCurrentTaskDuration";
            this.Controls.SetChildIndex(this.uCurrentTaskDuration, 0);
            this.Controls.SetChildIndex(this.pnlHeader, 0);
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.UCurrentTaskDuration uCurrentTaskDuration;
    }
}