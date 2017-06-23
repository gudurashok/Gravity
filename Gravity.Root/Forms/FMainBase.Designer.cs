using System.ComponentModel;
using System.Drawing;

namespace Gravity.Root.Forms
{
    partial class FMainBase
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
            this.components = new System.ComponentModel.Container();
            this.lblUserName = new Scalable.Win.Controls.iLabel();
            this.lblUserCaption = new Scalable.Win.Controls.iLabel();
            this.toolStripStatusLabel = new Scalable.Win.Controls.iToolStripStatusLabel();
            this.statusStripBar = new Scalable.Win.Controls.iStatusStrip();
            this.mainMenuStrip = new Scalable.Win.Controls.iMenuStrip();
            this.companyGroupToolStripMenuItem = new Scalable.Win.Controls.iToolStripMenuItem();
            this.lnkAbout = new Scalable.Win.Controls.iLinkLabel();
            this.lblAdditionalInfo = new Scalable.Win.Controls.iLabel();
            this.lnkExit = new Scalable.Win.Controls.iLinkLabel();
            this.lnkRefresh = new Scalable.Win.Controls.iLinkLabel();
            this.lnkUsers = new Scalable.Win.Controls.iLinkLabel();
            this.lblTaskStats = new Scalable.Win.Controls.iLabel();
            this.toolTip = new Scalable.Win.Controls.iToolTip();
            this.lnkFeedback = new Scalable.Win.Controls.iLinkLabel();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.statusStripBar.SuspendLayout();
            this.mainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblTaskStats);
            this.pnlHeader.Controls.Add(this.lblAdditionalInfo);
            this.pnlHeader.Controls.Add(this.lblUserName);
            this.pnlHeader.Controls.Add(this.lblUserCaption);
            this.pnlHeader.Size = new System.Drawing.Size(632, 43);
            this.pnlHeader.TabIndex = 2;
            this.pnlHeader.Controls.SetChildIndex(this.lblUserCaption, 0);
            this.pnlHeader.Controls.SetChildIndex(this.lblUserName, 0);
            this.pnlHeader.Controls.SetChildIndex(this.lblTitle, 0);
            this.pnlHeader.Controls.SetChildIndex(this.picLogo, 0);
            this.pnlHeader.Controls.SetChildIndex(this.lblAdditionalInfo, 0);
            this.pnlHeader.Controls.SetChildIndex(this.lblTaskStats, 0);
            // 
            // picLogo
            // 
            this.picLogo.Location = new System.Drawing.Point(587, 2);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Cyan;
            this.lblTitle.Location = new System.Drawing.Point(4, 3);
            this.lblTitle.Size = new System.Drawing.Size(271, 19);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "<< No Company Group Selected >>";
            // 
            // lblUserName
            // 
            this.lblUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.ForeColor = System.Drawing.Color.Yellow;
            this.lblUserName.Location = new System.Drawing.Point(408, 7);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(88, 14);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.Text = "Logged in user";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUserCaption
            // 
            this.lblUserCaption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserCaption.AutoSize = true;
            this.lblUserCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserCaption.ForeColor = System.Drawing.Color.White;
            this.lblUserCaption.Location = new System.Drawing.Point(373, 7);
            this.lblUserCaption.Name = "lblUserCaption";
            this.lblUserCaption.Size = new System.Drawing.Size(35, 14);
            this.lblUserCaption.TabIndex = 1;
            this.lblUserCaption.Text = "User:";
            this.lblUserCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // statusStripBar
            // 
            this.statusStripBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStripBar.Location = new System.Drawing.Point(0, 424);
            this.statusStripBar.Name = "statusStripBar";
            this.statusStripBar.Size = new System.Drawing.Size(632, 22);
            this.statusStripBar.TabIndex = 14;
            this.statusStripBar.Text = "statusStrip1";
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.companyGroupToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 43);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(632, 24);
            this.mainMenuStrip.TabIndex = 1;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // companyGroupToolStripMenuItem
            // 
            this.companyGroupToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.companyGroupToolStripMenuItem.Name = "companyGroupToolStripMenuItem";
            this.companyGroupToolStripMenuItem.Size = new System.Drawing.Size(121, 20);
            this.companyGroupToolStripMenuItem.Text = "&Company Group";
            this.companyGroupToolStripMenuItem.Click += new System.EventHandler(this.companyGroupToolStripMenuItem_Click);
            // 
            // lnkAbout
            // 
            this.lnkAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkAbout.AutoSize = true;
            this.lnkAbout.Location = new System.Drawing.Point(549, 48);
            this.lnkAbout.Name = "lnkAbout";
            this.lnkAbout.Size = new System.Drawing.Size(35, 13);
            this.lnkAbout.TabIndex = 3;
            this.lnkAbout.TabStop = true;
            this.lnkAbout.Text = "&About";
            this.lnkAbout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAbout_LinkClicked);
            // 
            // lblAdditionalInfo
            // 
            this.lblAdditionalInfo.AutoSize = true;
            this.lblAdditionalInfo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdditionalInfo.ForeColor = System.Drawing.Color.Yellow;
            this.lblAdditionalInfo.Location = new System.Drawing.Point(4, 24);
            this.lblAdditionalInfo.Name = "lblAdditionalInfo";
            this.lblAdditionalInfo.Size = new System.Drawing.Size(125, 14);
            this.lblAdditionalInfo.TabIndex = 8;
            this.lblAdditionalInfo.Text = "Additional information";
            // 
            // lnkExit
            // 
            this.lnkExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkExit.AutoSize = true;
            this.lnkExit.Location = new System.Drawing.Point(590, 48);
            this.lnkExit.Name = "lnkExit";
            this.lnkExit.Size = new System.Drawing.Size(24, 13);
            this.lnkExit.TabIndex = 3;
            this.lnkExit.TabStop = true;
            this.lnkExit.Text = "E&xit";
            // 
            // lnkRefresh
            // 
            this.lnkRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkRefresh.AutoSize = true;
            this.lnkRefresh.Location = new System.Drawing.Point(499, 48);
            this.lnkRefresh.Name = "lnkRefresh";
            this.lnkRefresh.Size = new System.Drawing.Size(44, 13);
            this.lnkRefresh.TabIndex = 3;
            this.lnkRefresh.TabStop = true;
            this.lnkRefresh.Text = "&Refresh";
            this.lnkRefresh.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblRefresh_LinkClicked);
            // 
            // lnkUsers
            // 
            this.lnkUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkUsers.AutoSize = true;
            this.lnkUsers.Location = new System.Drawing.Point(402, 48);
            this.lnkUsers.Name = "lnkUsers";
            this.lnkUsers.Size = new System.Drawing.Size(34, 13);
            this.lnkUsers.TabIndex = 3;
            this.lnkUsers.TabStop = true;
            this.lnkUsers.Text = "&Users";
            this.lnkUsers.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkUsers_LinkClicked);
            // 
            // lblTaskStats
            // 
            this.lblTaskStats.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTaskStats.AutoSize = true;
            this.lblTaskStats.ForeColor = System.Drawing.Color.Cornsilk;
            this.lblTaskStats.Location = new System.Drawing.Point(373, 25);
            this.lblTaskStats.Name = "lblTaskStats";
            this.lblTaskStats.Size = new System.Drawing.Size(0, 13);
            this.lblTaskStats.TabIndex = 9;
            // 
            // lnkFeedback
            // 
            this.lnkFeedback.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkFeedback.AutoSize = true;
            this.lnkFeedback.Location = new System.Drawing.Point(442, 48);
            this.lnkFeedback.Name = "lnkFeedback";
            this.lnkFeedback.Size = new System.Drawing.Size(55, 13);
            this.lnkFeedback.TabIndex = 3;
            this.lnkFeedback.TabStop = true;
            this.lnkFeedback.Text = "&Feedback";
            this.lnkFeedback.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkFeedback_LinkClicked);
            // 
            // FMainBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(632, 446);
            this.Controls.Add(this.lnkExit);
            this.Controls.Add(this.lnkFeedback);
            this.Controls.Add(this.lnkUsers);
            this.Controls.Add(this.lnkRefresh);
            this.Controls.Add(this.lnkAbout);
            this.Controls.Add(this.statusStripBar);
            this.Controls.Add(this.mainMenuStrip);
            this.MainMenuStrip = this.mainMenuStrip;
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "FMainBase";
            this.ShowInTaskbar = true;
            this.Text = "Gravity";
            this.Load += new System.EventHandler(this.FMainBase_Load);
            this.Controls.SetChildIndex(this.pnlHeader, 0);
            this.Controls.SetChildIndex(this.mainMenuStrip, 0);
            this.Controls.SetChildIndex(this.statusStripBar, 0);
            this.Controls.SetChildIndex(this.lnkAbout, 0);
            this.Controls.SetChildIndex(this.lnkRefresh, 0);
            this.Controls.SetChildIndex(this.lnkUsers, 0);
            this.Controls.SetChildIndex(this.lnkFeedback, 0);
            this.Controls.SetChildIndex(this.lnkExit, 0);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.statusStripBar.ResumeLayout(false);
            this.statusStripBar.PerformLayout();
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected Scalable.Win.Controls.iToolStripStatusLabel toolStripStatusLabel;
        protected Scalable.Win.Controls.iStatusStrip statusStripBar;
        protected Scalable.Win.Controls.iToolStripMenuItem companyGroupToolStripMenuItem;
        protected Scalable.Win.Controls.iMenuStrip mainMenuStrip;
        protected Scalable.Win.Controls.iLabel lblUserCaption;
        protected Scalable.Win.Controls.iLinkLabel lnkAbout;
        protected Scalable.Win.Controls.iLabel lblUserName;
        protected System.Windows.Forms.Timer pollingTimer;
        protected Scalable.Win.Controls.iLabel lblAdditionalInfo;
        protected Scalable.Win.Controls.iLinkLabel lnkExit;
        protected Scalable.Win.Controls.iLinkLabel lnkRefresh;
        protected Scalable.Win.Controls.iLinkLabel lnkUsers;
        private Scalable.Win.Controls.iLabel lblTaskStats;
        private Scalable.Win.Controls.iToolTip toolTip;
        protected Scalable.Win.Controls.iLinkLabel lnkFeedback;
    }
}
