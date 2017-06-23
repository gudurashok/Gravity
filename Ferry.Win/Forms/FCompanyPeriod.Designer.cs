namespace Ferry.Win.Forms
{
    partial class FCompanyPeriod
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCompanyPeriod));
            this.txtDataPath = new Scalable.Win.Controls.iTextBox();
            this.btnDataSourceBrowser = new Scalable.Win.Controls.iButton();
            this.lblDatePeriodName = new Scalable.Win.Controls.iLabel();
            this.lblDataPathName = new Scalable.Win.Controls.iLabel();
            this.btnOK = new Scalable.Win.Controls.iButton();
            this.lblProviderName = new Scalable.Win.Controls.iLabel();
            this.pnlCommandBar = new Scalable.Win.Controls.iPanel();
            this.lblCompanyName = new Scalable.Win.Controls.iLabel();
            this.cmbCompany = new Scalable.Win.Controls.iComboBox();
            this.btnDelete = new Scalable.Win.Controls.iButton();
            this.lblProvider = new Scalable.Win.Controls.iLabel();
            this.lblDatePeriod = new Scalable.Win.Controls.iLabel();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnlCommandBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Size = new System.Drawing.Size(384, 43);
            // 
            // picLogo
            // 
            this.picLogo.Location = new System.Drawing.Point(341, 2);
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(143, 14);
            this.lblTitle.Text = "Enter data source details";
            // 
            // txtDataPath
            // 
            this.txtDataPath.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDataPath.Location = new System.Drawing.Point(94, 47);
            this.txtDataPath.Name = "txtDataPath";
            this.txtDataPath.ReadOnly = true;
            this.txtDataPath.Size = new System.Drawing.Size(259, 20);
            this.txtDataPath.TabIndex = 1;
            // 
            // btnDataSourceBrowser
            // 
            this.btnDataSourceBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDataSourceBrowser.Location = new System.Drawing.Point(352, 46);
            this.btnDataSourceBrowser.Name = "btnDataSourceBrowser";
            this.btnDataSourceBrowser.Size = new System.Drawing.Size(25, 21);
            this.btnDataSourceBrowser.TabIndex = 2;
            this.btnDataSourceBrowser.Text = "...";
            this.btnDataSourceBrowser.UseVisualStyleBackColor = true;
            this.btnDataSourceBrowser.Click += new System.EventHandler(this.btnDataSourceBrowser_Click);
            // 
            // lblDatePeriodName
            // 
            this.lblDatePeriodName.AutoSize = true;
            this.lblDatePeriodName.Location = new System.Drawing.Point(5, 91);
            this.lblDatePeriodName.Name = "lblDatePeriodName";
            this.lblDatePeriodName.Size = new System.Drawing.Size(40, 13);
            this.lblDatePeriodName.TabIndex = 6;
            this.lblDatePeriodName.Text = "&Period:";
            // 
            // lblDataPathName
            // 
            this.lblDataPathName.AutoSize = true;
            this.lblDataPathName.Location = new System.Drawing.Point(5, 50);
            this.lblDataPathName.Name = "lblDataPathName";
            this.lblDataPathName.Size = new System.Drawing.Size(57, 13);
            this.lblDataPathName.TabIndex = 0;
            this.lblDataPathName.Text = "D&ata path:";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(155, 3);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblProviderName
            // 
            this.lblProviderName.AutoSize = true;
            this.lblProviderName.Location = new System.Drawing.Point(5, 117);
            this.lblProviderName.Name = "lblProviderName";
            this.lblProviderName.Size = new System.Drawing.Size(74, 13);
            this.lblProviderName.TabIndex = 8;
            this.lblProviderName.Text = "&Data provider:";
            // 
            // pnlCommandBar
            // 
            this.pnlCommandBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCommandBar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlCommandBar.Controls.Add(this.btnOK);
            this.pnlCommandBar.Location = new System.Drawing.Point(-2, 142);
            this.pnlCommandBar.Name = "pnlCommandBar";
            this.pnlCommandBar.Size = new System.Drawing.Size(388, 35);
            this.pnlCommandBar.TabIndex = 9;
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Location = new System.Drawing.Point(5, 72);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(83, 13);
            this.lblCompanyName.TabIndex = 3;
            this.lblCompanyName.Text = "Company &name:";
            // 
            // cmbCompany
            // 
            this.cmbCompany.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCompany.FormattingEnabled = true;
            this.cmbCompany.Location = new System.Drawing.Point(94, 68);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.Size = new System.Drawing.Size(259, 21);
            this.cmbCompany.TabIndex = 4;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.Red;
            this.btnDelete.Location = new System.Drawing.Point(352, 67);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(25, 21);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "X";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblProvider
            // 
            this.lblProvider.AutoSize = true;
            this.lblProvider.Location = new System.Drawing.Point(97, 117);
            this.lblProvider.Name = "lblProvider";
            this.lblProvider.Size = new System.Drawing.Size(0, 13);
            this.lblProvider.TabIndex = 9;
            // 
            // lblDatePeriod
            // 
            this.lblDatePeriod.AutoSize = true;
            this.lblDatePeriod.Location = new System.Drawing.Point(97, 95);
            this.lblDatePeriod.Name = "lblDatePeriod";
            this.lblDatePeriod.Size = new System.Drawing.Size(0, 13);
            this.lblDatePeriod.TabIndex = 7;
            // 
            // FCompanyPeriod
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 174);
            this.Controls.Add(this.lblDatePeriod);
            this.Controls.Add(this.lblProvider);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.cmbCompany);
            this.Controls.Add(this.lblCompanyName);
            this.Controls.Add(this.pnlCommandBar);
            this.Controls.Add(this.lblDataPathName);
            this.Controls.Add(this.lblProviderName);
            this.Controls.Add(this.lblDatePeriodName);
            this.Controls.Add(this.btnDataSourceBrowser);
            this.Controls.Add(this.txtDataPath);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 212);
            this.Name = "FCompanyPeriod";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Source company details";
            this.Controls.SetChildIndex(this.txtDataPath, 0);
            this.Controls.SetChildIndex(this.btnDataSourceBrowser, 0);
            this.Controls.SetChildIndex(this.lblDatePeriodName, 0);
            this.Controls.SetChildIndex(this.lblProviderName, 0);
            this.Controls.SetChildIndex(this.lblDataPathName, 0);
            this.Controls.SetChildIndex(this.pnlCommandBar, 0);
            this.Controls.SetChildIndex(this.lblCompanyName, 0);
            this.Controls.SetChildIndex(this.cmbCompany, 0);
            this.Controls.SetChildIndex(this.pnlHeader, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.lblProvider, 0);
            this.Controls.SetChildIndex(this.lblDatePeriod, 0);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.pnlCommandBar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Scalable.Win.Controls.iTextBox txtDataPath;
        private Scalable.Win.Controls.iButton btnDataSourceBrowser;
        private Scalable.Win.Controls.iLabel lblDatePeriodName;
        private Scalable.Win.Controls.iLabel lblDataPathName;
        private Scalable.Win.Controls.iButton btnOK;
        private Scalable.Win.Controls.iLabel lblProviderName;
        private Scalable.Win.Controls.iPanel pnlCommandBar;
        private Scalable.Win.Controls.iLabel lblCompanyName;
        private Scalable.Win.Controls.iComboBox cmbCompany;
        private Scalable.Win.Controls.iButton btnDelete;
        private Scalable.Win.Controls.iLabel lblProvider;
        private Scalable.Win.Controls.iLabel lblDatePeriod;
    }
}