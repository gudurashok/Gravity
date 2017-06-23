namespace Insight.UC.Controls
{
    partial class UChartOfAccountList
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
            this.menuStrip = new Scalable.Win.Controls.iMenuStrip();
            this.newChartOfAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CommandBar.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(146, 4);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(65, 4);
            // 
            // txt
            // 
            this.txt.Location = new System.Drawing.Point(2, 26);
            this.txt.Size = new System.Drawing.Size(220, 20);
            // 
            // lvw
            // 
            this.lvw.Location = new System.Drawing.Point(2, 48);
            this.lvw.Size = new System.Drawing.Size(220, 207);
            // 
            // CommandBar
            // 
            this.CommandBar.Location = new System.Drawing.Point(-1, 257);
            this.CommandBar.Size = new System.Drawing.Size(228, 35);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newChartOfAccountToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(225, 24);
            this.menuStrip.TabIndex = 3;
            this.menuStrip.Text = "iMenuStrip1";
            // 
            // newChartOfAccounToolStripMenuItem
            // 
            this.newChartOfAccountToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.newChartOfAccountToolStripMenuItem.Name = "newChartOfAccounToolStripMenuItem";
            this.newChartOfAccountToolStripMenuItem.Size = new System.Drawing.Size(138, 20);
            this.newChartOfAccountToolStripMenuItem.Text = "&New ChartOfAccount";
            this.newChartOfAccountToolStripMenuItem.Click += new System.EventHandler(this.newChartOfAccountToolStripMenuItem_Click);
            // 
            // UChartOfAccountList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.menuStrip);
            this.Name = "UChartOfAccountList";
            this.Size = new System.Drawing.Size(225, 291);
            this.Controls.SetChildIndex(this.menuStrip, 0);
            this.Controls.SetChildIndex(this.lvw, 0);
            this.Controls.SetChildIndex(this.CommandBar, 0);
            this.Controls.SetChildIndex(this.txt, 0);
            this.CommandBar.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Scalable.Win.Controls.iMenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem newChartOfAccountToolStripMenuItem;
    }
}
