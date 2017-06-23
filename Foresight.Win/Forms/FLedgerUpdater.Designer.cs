namespace Foresight.Win.Forms
{
    partial class FLedgerUpdater
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FLedgerUpdater));
            this.picWaitIndicator = new Scalable.Win.Controls.iPictureBox();
            this.btnStart = new Scalable.Win.Controls.iButton();
            this.pnlCommandBar = new Scalable.Win.Controls.iPanel();
            this.btnCancel = new Scalable.Win.Controls.iButton();
            this.btnOK = new Scalable.Win.Controls.iButton();
            this.pnlProgress = new Scalable.Win.Controls.iPanel();
            this.lblTimeElapsed = new Scalable.Win.Controls.iLabel();
            this.lblCompany = new Scalable.Win.Controls.iLabel();
            this.lblProgress = new Scalable.Win.Controls.iLabel();
            this.lblStartTime = new Scalable.Win.Controls.iLabel();
            this.lblStatus = new Scalable.Win.Controls.iLabel();
            this.pnlStart = new Scalable.Win.Controls.iPanel();
            this.lblMessage = new Scalable.Win.Controls.iLabel();
            this.lvwList = new Scalable.Win.Controls.iListView();
            this.pnlStatus = new Scalable.Win.Controls.iPanel();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWaitIndicator)).BeginInit();
            this.pnlCommandBar.SuspendLayout();
            this.pnlProgress.SuspendLayout();
            this.pnlStart.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Size = new System.Drawing.Size(458, 43);
            // 
            // picLogo
            // 
            this.picLogo.Location = new System.Drawing.Point(415, 2);
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(235, 14);
            this.lblTitle.Text = "Dimension tables updater and its progress";
            // 
            // picWaitIndicator
            // 
            this.picWaitIndicator.Image = ((System.Drawing.Image)(resources.GetObject("picWaitIndicator.Image")));
            this.picWaitIndicator.Location = new System.Drawing.Point(2, 23);
            this.picWaitIndicator.Name = "picWaitIndicator";
            this.picWaitIndicator.Size = new System.Drawing.Size(38, 40);
            this.picWaitIndicator.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picWaitIndicator.TabIndex = 5;
            this.picWaitIndicator.TabStop = false;
            this.picWaitIndicator.Visible = false;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(199, 3);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // pnlCommandBar
            // 
            this.pnlCommandBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCommandBar.BackColor = System.Drawing.SystemColors.Control;
            this.pnlCommandBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCommandBar.Controls.Add(this.btnStart);
            this.pnlCommandBar.Controls.Add(this.btnCancel);
            this.pnlCommandBar.Controls.Add(this.btnOK);
            this.pnlCommandBar.Location = new System.Drawing.Point(-2, 278);
            this.pnlCommandBar.Name = "pnlCommandBar";
            this.pnlCommandBar.Size = new System.Drawing.Size(461, 31);
            this.pnlCommandBar.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(378, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(378, 3);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Visible = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // pnlProgress
            // 
            this.pnlProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlProgress.Controls.Add(this.lblTimeElapsed);
            this.pnlProgress.Controls.Add(this.lblCompany);
            this.pnlProgress.Controls.Add(this.lblProgress);
            this.pnlProgress.Controls.Add(this.lblStartTime);
            this.pnlProgress.Controls.Add(this.lblStatus);
            this.pnlProgress.Location = new System.Drawing.Point(46, 3);
            this.pnlProgress.Name = "pnlProgress";
            this.pnlProgress.Size = new System.Drawing.Size(403, 92);
            this.pnlProgress.TabIndex = 0;
            this.pnlProgress.Visible = false;
            // 
            // lblTimeElapsed
            // 
            this.lblTimeElapsed.AutoSize = true;
            this.lblTimeElapsed.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeElapsed.ForeColor = System.Drawing.Color.Maroon;
            this.lblTimeElapsed.Location = new System.Drawing.Point(204, 24);
            this.lblTimeElapsed.Name = "lblTimeElapsed";
            this.lblTimeElapsed.Size = new System.Drawing.Size(79, 14);
            this.lblTimeElapsed.TabIndex = 4;
            this.lblTimeElapsed.Text = "Time Elapsed";
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompany.ForeColor = System.Drawing.Color.Navy;
            this.lblCompany.Location = new System.Drawing.Point(5, 4);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(79, 16);
            this.lblCompany.TabIndex = 0;
            this.lblCompany.Text = "Company...";
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgress.ForeColor = System.Drawing.Color.Blue;
            this.lblProgress.Location = new System.Drawing.Point(5, 64);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(83, 16);
            this.lblProgress.TabIndex = 3;
            this.lblProgress.Text = "Connecting...";
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartTime.Location = new System.Drawing.Point(5, 24);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(65, 14);
            this.lblStartTime.TabIndex = 1;
            this.lblStartTime.Text = "Start Time";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Red;
            this.lblStatus.Location = new System.Drawing.Point(5, 44);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(170, 16);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Importing data: Please wait.";
            // 
            // pnlStart
            // 
            this.pnlStart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlStart.Controls.Add(this.lblMessage);
            this.pnlStart.Location = new System.Drawing.Point(46, 3);
            this.pnlStart.Name = "pnlStart";
            this.pnlStart.Size = new System.Drawing.Size(403, 92);
            this.pnlStart.TabIndex = 6;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.Blue;
            this.lblMessage.Location = new System.Drawing.Point(13, 31);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(369, 16);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "Click start button to build ledgers for selected company/periods";
            // 
            // lvwList
            // 
            this.lvwList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwList.FullRowSelect = true;
            this.lvwList.GridLines = true;
            this.lvwList.HideSelection = false;
            this.lvwList.Location = new System.Drawing.Point(2, 45);
            this.lvwList.MultiSelect = false;
            this.lvwList.Name = "lvwList";
            this.lvwList.Size = new System.Drawing.Size(454, 130);
            this.lvwList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvwList.TabIndex = 8;
            this.lvwList.UseCompatibleStateImageBehavior = false;
            this.lvwList.View = System.Windows.Forms.View.Details;
            this.lvwList.DoubleClick += new System.EventHandler(this.lvwList_DoubleClick);
            // 
            // pnlStatus
            // 
            this.pnlStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStatus.Controls.Add(this.picWaitIndicator);
            this.pnlStatus.Controls.Add(this.pnlStart);
            this.pnlStatus.Controls.Add(this.pnlProgress);
            this.pnlStatus.Location = new System.Drawing.Point(2, 177);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(454, 99);
            this.pnlStatus.TabIndex = 9;
            // 
            // FLedgerUpdater
            // 
            this.AcceptButton = this.btnStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(458, 308);
            this.ControlBox = false;
            this.Controls.Add(this.pnlStatus);
            this.Controls.Add(this.lvwList);
            this.Controls.Add(this.pnlCommandBar);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(474, 295);
            this.Name = "FLedgerUpdater";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Foresight: Dimension Tables Updater";
            this.Controls.SetChildIndex(this.pnlCommandBar, 0);
            this.Controls.SetChildIndex(this.pnlHeader, 0);
            this.Controls.SetChildIndex(this.lvwList, 0);
            this.Controls.SetChildIndex(this.pnlStatus, 0);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWaitIndicator)).EndInit();
            this.pnlCommandBar.ResumeLayout(false);
            this.pnlProgress.ResumeLayout(false);
            this.pnlProgress.PerformLayout();
            this.pnlStart.ResumeLayout(false);
            this.pnlStart.PerformLayout();
            this.pnlStatus.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Scalable.Win.Controls.iPictureBox picWaitIndicator;
        private Scalable.Win.Controls.iButton btnStart;
        private Scalable.Win.Controls.iPanel pnlCommandBar;
        private Scalable.Win.Controls.iPanel pnlProgress;
        private Scalable.Win.Controls.iLabel lblProgress;
        private Scalable.Win.Controls.iLabel lblStartTime;
        private Scalable.Win.Controls.iLabel lblStatus;
        private Scalable.Win.Controls.iButton btnCancel;
        private Scalable.Win.Controls.iPanel pnlStart;
        private Scalable.Win.Controls.iLabel lblMessage;
        private Scalable.Win.Controls.iLabel lblCompany;
        private Scalable.Win.Controls.iButton btnOK;
        private Scalable.Win.Controls.iListView lvwList;
        private Scalable.Win.Controls.iPanel pnlStatus;
        private Scalable.Win.Controls.iLabel lblTimeElapsed;
    }
}