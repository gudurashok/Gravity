namespace Synergy.UC.Forms
{
    partial class FMessageBox
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
            this.menuStrip = new Scalable.Win.Controls.iMenuStrip();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uMessageBox = new Synergy.UC.Controls.UMessageBox();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Size = new System.Drawing.Size(500, 43);
            // 
            // picLogo
            // 
            this.picLogo.Location = new System.Drawing.Point(457, 2);
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(448, 39);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 43);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(500, 24);
            this.menuStrip.TabIndex = 13;
            this.menuStrip.Text = "iMenuStrip1";
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.refreshToolStripMenuItem.Text = "&Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // uMessageBox
            // 
            this.uMessageBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uMessageBox.Location = new System.Drawing.Point(0, 69);
            this.uMessageBox.MinimumSize = new System.Drawing.Size(344, 256);
            this.uMessageBox.Name = "uMessageBox";
            this.uMessageBox.SearchProperty = "TaskName";
            this.uMessageBox.Size = new System.Drawing.Size(500, 259);
            this.uMessageBox.TabIndex = 0;
            // 
            // FMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 328);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.uMessageBox);
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(508, 362);
            this.Name = "FMessageBox";
            this.Text = "FMessageBox";
            this.Controls.SetChildIndex(this.uMessageBox, 0);
            this.Controls.SetChildIndex(this.pnlHeader, 0);
            this.Controls.SetChildIndex(this.menuStrip, 0);
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.UMessageBox uMessageBox;
        private Scalable.Win.Controls.iMenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;


    }
}