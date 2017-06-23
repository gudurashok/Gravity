namespace Insight.UC.Controls
{
    partial class UVouchers
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
            this.newVoucherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uSearchBar = new Insight.UC.Controls.USearchBar();
            this.CommandBar.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(551, 5);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(470, 5);
            // 
            // txt
            // 
            this.txt.Location = new System.Drawing.Point(2, 74);
            this.txt.Size = new System.Drawing.Size(628, 20);
            // 
            // lvw
            // 
            this.lvw.Location = new System.Drawing.Point(2, 96);
            this.lvw.Size = new System.Drawing.Size(628, 140);
            // 
            // CommandBar
            // 
            this.CommandBar.Location = new System.Drawing.Point(-1, 238);
            this.CommandBar.Size = new System.Drawing.Size(634, 35);
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.White;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newVoucherToolStripMenuItem,
            this.searchToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(632, 24);
            this.menuStrip.TabIndex = 5;
            // 
            // newVoucherToolStripMenuItem
            // 
            this.newVoucherToolStripMenuItem.Checked = true;
            this.newVoucherToolStripMenuItem.CheckOnClick = true;
            this.newVoucherToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.newVoucherToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newVoucherToolStripMenuItem.ForeColor = System.Drawing.Color.Blue;
            this.newVoucherToolStripMenuItem.Name = "newVoucherToolStripMenuItem";
            this.newVoucherToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N;
            this.newVoucherToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.newVoucherToolStripMenuItem.Text = "New Voucher";
            this.newVoucherToolStripMenuItem.Click += new System.EventHandler(this.newVoucherToolStripMenuItem_Click);
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Checked = true;
            this.searchToolStripMenuItem.CheckOnClick = true;
            this.searchToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.searchToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchToolStripMenuItem.ForeColor = System.Drawing.Color.Blue;
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H;
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.searchToolStripMenuItem.Text = "Hide Searc&h";
            this.searchToolStripMenuItem.Click += new System.EventHandler(this.searchToolStripMenuItem_Click);
            // 
            // uSearchBar
            // 
            this.uSearchBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uSearchBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uSearchBar.Location = new System.Drawing.Point(2, 25);
            this.uSearchBar.Name = "uSearchBar";
            this.uSearchBar.Size = new System.Drawing.Size(628, 47);
            this.uSearchBar.TabIndex = 3;
            // 
            // UVouchers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uSearchBar);
            this.Controls.Add(this.menuStrip);
            this.Name = "UVouchers";
            this.Size = new System.Drawing.Size(632, 272);
            this.Controls.SetChildIndex(this.menuStrip, 0);
            this.Controls.SetChildIndex(this.uSearchBar, 0);
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

        protected USearchBar uSearchBar;
        protected Scalable.Win.Controls.iMenuStrip menuStrip;
        protected System.Windows.Forms.ToolStripMenuItem newVoucherToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
    }
}
