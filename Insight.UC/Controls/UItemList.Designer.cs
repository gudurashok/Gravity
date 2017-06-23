namespace Insight.UC.Controls
{
    partial class UItemList
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
            this.iMenuStrip = new Scalable.Win.Controls.iMenuStrip();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CommandBar.SuspendLayout();
            this.iMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(147, 4);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(66, 4);
            // 
            // txt
            // 
            this.txt.Location = new System.Drawing.Point(2, 26);
            this.txt.Size = new System.Drawing.Size(221, 20);
            // 
            // lvw
            // 
            this.lvw.Location = new System.Drawing.Point(2, 48);
            this.lvw.Size = new System.Drawing.Size(221, 207);
            // 
            // CommandBar
            // 
            this.CommandBar.Location = new System.Drawing.Point(-1, 257);
            this.CommandBar.Size = new System.Drawing.Size(227, 35);
            // 
            // iMenuStrip
            // 
            this.iMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem});
            this.iMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.iMenuStrip.Name = "iMenuStrip";
            this.iMenuStrip.Size = new System.Drawing.Size(225, 24);
            this.iMenuStrip.TabIndex = 3;
            this.iMenuStrip.Text = "iMenuStrip1";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.newToolStripMenuItem.Text = "&New Item";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // UItemList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.iMenuStrip);
            this.Name = "UItemList";
            this.Size = new System.Drawing.Size(225, 291);
            this.Controls.SetChildIndex(this.iMenuStrip, 0);
            this.Controls.SetChildIndex(this.lvw, 0);
            this.Controls.SetChildIndex(this.CommandBar, 0);
            this.Controls.SetChildIndex(this.txt, 0);
            this.CommandBar.ResumeLayout(false);
            this.iMenuStrip.ResumeLayout(false);
            this.iMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Scalable.Win.Controls.iMenuStrip iMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
    }
}
