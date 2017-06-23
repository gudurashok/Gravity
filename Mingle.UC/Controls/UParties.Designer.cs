using System.Windows.Forms;

namespace Mingle.UC.Controls
{
    partial class UParties
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
            this.btnDelete = new Scalable.Win.Controls.iButton();
            this.uPartyPreview = new Mingle.UC.Controls.UPartyPreview();
            this.menuStrip = new Scalable.Win.Controls.iMenuStrip();
            this.newPartyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.previewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CommandBar.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(418, 5);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(337, 5);
            // 
            // txt
            // 
            this.txt.Location = new System.Drawing.Point(2, 25);
            this.txt.Size = new System.Drawing.Size(494, 20);
            // 
            // lvw
            // 
            this.lvw.Location = new System.Drawing.Point(2, 47);
            this.lvw.Size = new System.Drawing.Size(494, 113);
            // 
            // CommandBar
            // 
            this.CommandBar.Controls.Add(this.btnDelete);
            this.CommandBar.Location = new System.Drawing.Point(-1, 299);
            this.CommandBar.Size = new System.Drawing.Size(500, 35);
            this.CommandBar.TabIndex = 3;
            this.CommandBar.Controls.SetChildIndex(this.btnOpen, 0);
            this.CommandBar.Controls.SetChildIndex(this.btnOK, 0);
            this.CommandBar.Controls.SetChildIndex(this.btnDelete, 0);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Enabled = false;
            this.btnDelete.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.Red;
            this.btnDelete.Location = new System.Drawing.Point(6, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(23, 23);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "X";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // uPartyPreview
            // 
            this.uPartyPreview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uPartyPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uPartyPreview.Location = new System.Drawing.Point(2, 162);
            this.uPartyPreview.Name = "uPartyPreview";
            this.uPartyPreview.Size = new System.Drawing.Size(494, 135);
            this.uPartyPreview.TabIndex = 2;
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.White;
            this.menuStrip.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newPartyToolStripMenuItem,
            this.previewToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(498, 24);
            this.menuStrip.TabIndex = 4;
            // 
            // newPartyToolStripMenuItem
            // 
            this.newPartyToolStripMenuItem.ForeColor = System.Drawing.Color.Blue;
            this.newPartyToolStripMenuItem.Name = "newPartyToolStripMenuItem";
            this.newPartyToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.newPartyToolStripMenuItem.Text = "&New Party";
            this.newPartyToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            this.newPartyToolStripMenuItem.Click += new System.EventHandler(this.newPartyToolStripMenuItem_Click);
            // 
            // previewToolStripMenuItem
            // 
            this.previewToolStripMenuItem.ForeColor = System.Drawing.Color.Blue;
            this.previewToolStripMenuItem.Name = "previewToolStripMenuItem";
            this.previewToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.previewToolStripMenuItem.Text = "Hide Previe&w";
            this.previewToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.W;
            this.previewToolStripMenuItem.Click += new System.EventHandler(this.previewToolStripMenuItem_Click);
            // 
            // UParties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uPartyPreview);
            this.Controls.Add(this.menuStrip);
            this.Name = "UParties";
            this.Size = new System.Drawing.Size(498, 333);
            this.Controls.SetChildIndex(this.menuStrip, 0);
            this.Controls.SetChildIndex(this.uPartyPreview, 0);
            this.Controls.SetChildIndex(this.lvw, 0);
            this.Controls.SetChildIndex(this.txt, 0);
            this.Controls.SetChildIndex(this.CommandBar, 0);
            this.CommandBar.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Scalable.Win.Controls.iButton btnDelete;
        private UPartyPreview uPartyPreview;
        private Scalable.Win.Controls.iMenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem newPartyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem previewToolStripMenuItem;
    }
}
