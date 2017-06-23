namespace Synergy.UC.Controls
{
    partial class USearchBar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(USearchBar));
            this.cmbTaskType = new Scalable.Win.Controls.iComboBox();
            this.lblType = new Scalable.Win.Controls.iLabel();
            this.lblProject = new Scalable.Win.Controls.iLabel();
            this.cmbProject = new Scalable.Win.Controls.iComboBox();
            this.lblStatus = new Scalable.Win.Controls.iLabel();
            this.cmbStatus = new Scalable.Win.Controls.iComboBox();
            this.cmbDateFieldName = new Scalable.Win.Controls.iComboBox();
            this.dtpFromDate = new Scalable.Win.Controls.iDateTimePicker();
            this.lblUser = new Scalable.Win.Controls.iLabel();
            this.cmbAssigned = new Scalable.Win.Controls.iComboBox();
            this.dtpToDate = new Scalable.Win.Controls.iDateTimePicker();
            this.lblToDateTime = new Scalable.Win.Controls.iLabel();
            this.lblFromDateTime = new Scalable.Win.Controls.iLabel();
            this.btnSearch = new Scalable.Win.Controls.iButton();
            this.btnReset = new Scalable.Win.Controls.iButton();
            this.splitter = new Scalable.Win.Controls.iSplitContainer();
            this.txbAssigned = new Scalable.Win.Controls.iTextBoxButton();
            this.lblDateFieldName = new Scalable.Win.Controls.iLabel();
            this.dtpToTime = new Scalable.Win.Controls.iDateTimePicker();
            this.dtpFromTime = new Scalable.Win.Controls.iDateTimePicker();
            this.cmbPriority = new Scalable.Win.Controls.iComboBox();
            this.lblOrderBy = new Scalable.Win.Controls.iLabel();
            this.cmbLocation = new Scalable.Win.Controls.iComboBox();
            this.cmbOrderBy = new Scalable.Win.Controls.iComboBox();
            this.lblPriority = new Scalable.Win.Controls.iLabel();
            this.cmbGroupBy = new Scalable.Win.Controls.iComboBox();
            this.lblLocation = new Scalable.Win.Controls.iLabel();
            this.lblGroupBy = new Scalable.Win.Controls.iLabel();
            ((System.ComponentModel.ISupportInitialize)(this.splitter)).BeginInit();
            this.splitter.Panel1.SuspendLayout();
            this.splitter.Panel2.SuspendLayout();
            this.splitter.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbTaskType
            // 
            this.cmbTaskType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbTaskType.BackColor = System.Drawing.Color.White;
            this.cmbTaskType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTaskType.FormattingEnabled = true;
            this.cmbTaskType.Location = new System.Drawing.Point(51, 24);
            this.cmbTaskType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbTaskType.Name = "cmbTaskType";
            this.cmbTaskType.Size = new System.Drawing.Size(94, 21);
            this.cmbTaskType.TabIndex = 3;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(0, 27);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(34, 13);
            this.lblType.TabIndex = 2;
            this.lblType.Text = "T&ype:";
            // 
            // lblProject
            // 
            this.lblProject.AutoSize = true;
            this.lblProject.Location = new System.Drawing.Point(0, 50);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(43, 13);
            this.lblProject.TabIndex = 4;
            this.lblProject.Text = "Pro&ject:";
            // 
            // cmbProject
            // 
            this.cmbProject.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbProject.BackColor = System.Drawing.Color.White;
            this.cmbProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProject.FormattingEnabled = true;
            this.cmbProject.Location = new System.Drawing.Point(51, 47);
            this.cmbProject.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbProject.Name = "cmbProject";
            this.cmbProject.Size = new System.Drawing.Size(94, 21);
            this.cmbProject.TabIndex = 5;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(-1, 5);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 13);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Stat&us:";
            // 
            // cmbStatus
            // 
            this.cmbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbStatus.BackColor = System.Drawing.Color.White;
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(38, 1);
            this.cmbStatus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(112, 21);
            this.cmbStatus.TabIndex = 1;
            // 
            // cmbDateFieldName
            // 
            this.cmbDateFieldName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDateFieldName.BackColor = System.Drawing.Color.White;
            this.cmbDateFieldName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDateFieldName.FormattingEnabled = true;
            this.cmbDateFieldName.Location = new System.Drawing.Point(181, 1);
            this.cmbDateFieldName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbDateFieldName.Name = "cmbDateFieldName";
            this.cmbDateFieldName.Size = new System.Drawing.Size(179, 21);
            this.cmbDateFieldName.TabIndex = 6;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFromDate.Checked = false;
            this.dtpFromDate.Enabled = false;
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(181, 25);
            this.dtpFromDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(95, 20);
            this.dtpFromDate.TabIndex = 8;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(-1, 28);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(32, 13);
            this.lblUser.TabIndex = 2;
            this.lblUser.Text = "&User:";
            // 
            // cmbAssigned
            // 
            this.cmbAssigned.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbAssigned.BackColor = System.Drawing.Color.White;
            this.cmbAssigned.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAssigned.FormattingEnabled = true;
            this.cmbAssigned.Location = new System.Drawing.Point(38, 24);
            this.cmbAssigned.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbAssigned.Name = "cmbAssigned";
            this.cmbAssigned.Size = new System.Drawing.Size(112, 21);
            this.cmbAssigned.TabIndex = 3;
            // 
            // dtpToDate
            // 
            this.dtpToDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpToDate.Enabled = false;
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(181, 47);
            this.dtpToDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(95, 20);
            this.dtpToDate.TabIndex = 11;
            // 
            // lblToDateTime
            // 
            this.lblToDateTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblToDateTime.AutoSize = true;
            this.lblToDateTime.Location = new System.Drawing.Point(150, 51);
            this.lblToDateTime.Name = "lblToDateTime";
            this.lblToDateTime.Size = new System.Drawing.Size(23, 13);
            this.lblToDateTime.TabIndex = 10;
            this.lblToDateTime.Text = "&To:";
            // 
            // lblFromDateTime
            // 
            this.lblFromDateTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFromDateTime.AutoSize = true;
            this.lblFromDateTime.Location = new System.Drawing.Point(150, 29);
            this.lblFromDateTime.Name = "lblFromDateTime";
            this.lblFromDateTime.Size = new System.Drawing.Size(33, 13);
            this.lblFromDateTime.TabIndex = 7;
            this.lblFromDateTime.Text = "&From:";
            // 
            // btnSearch
            // 
            this.btnSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.BackgroundImage")));
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSearch.Location = new System.Drawing.Point(290, 0);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(34, 34);
            this.btnSearch.TabIndex = 12;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReset.BackgroundImage")));
            this.btnReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnReset.Location = new System.Drawing.Point(290, 35);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(34, 34);
            this.btnReset.TabIndex = 13;
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // splitter
            // 
            this.splitter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitter.Location = new System.Drawing.Point(1, 1);
            this.splitter.Name = "splitter";
            // 
            // splitter.Panel1
            // 
            this.splitter.Panel1.Controls.Add(this.txbAssigned);
            this.splitter.Panel1.Controls.Add(this.cmbStatus);
            this.splitter.Panel1.Controls.Add(this.cmbAssigned);
            this.splitter.Panel1.Controls.Add(this.lblUser);
            this.splitter.Panel1.Controls.Add(this.cmbDateFieldName);
            this.splitter.Panel1.Controls.Add(this.lblDateFieldName);
            this.splitter.Panel1.Controls.Add(this.dtpToTime);
            this.splitter.Panel1.Controls.Add(this.dtpFromTime);
            this.splitter.Panel1.Controls.Add(this.dtpToDate);
            this.splitter.Panel1.Controls.Add(this.dtpFromDate);
            this.splitter.Panel1.Controls.Add(this.lblToDateTime);
            this.splitter.Panel1.Controls.Add(this.lblFromDateTime);
            this.splitter.Panel1.Controls.Add(this.lblStatus);
            // 
            // splitter.Panel2
            // 
            this.splitter.Panel2.Controls.Add(this.btnReset);
            this.splitter.Panel2.Controls.Add(this.cmbPriority);
            this.splitter.Panel2.Controls.Add(this.lblOrderBy);
            this.splitter.Panel2.Controls.Add(this.cmbLocation);
            this.splitter.Panel2.Controls.Add(this.lblType);
            this.splitter.Panel2.Controls.Add(this.btnSearch);
            this.splitter.Panel2.Controls.Add(this.cmbOrderBy);
            this.splitter.Panel2.Controls.Add(this.lblProject);
            this.splitter.Panel2.Controls.Add(this.lblPriority);
            this.splitter.Panel2.Controls.Add(this.cmbTaskType);
            this.splitter.Panel2.Controls.Add(this.cmbGroupBy);
            this.splitter.Panel2.Controls.Add(this.lblLocation);
            this.splitter.Panel2.Controls.Add(this.cmbProject);
            this.splitter.Panel2.Controls.Add(this.lblGroupBy);
            this.splitter.Size = new System.Drawing.Size(687, 70);
            this.splitter.SplitterDistance = 361;
            this.splitter.SplitterWidth = 1;
            this.splitter.TabIndex = 0;
            // 
            // txbAssigned
            // 
            this.txbAssigned.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbAssigned.Enabled = false;
            this.txbAssigned.Location = new System.Drawing.Point(2, 47);
            this.txbAssigned.Name = "txbAssigned";
            this.txbAssigned.SearchProperty = "Name";
            this.txbAssigned.Size = new System.Drawing.Size(148, 20);
            this.txbAssigned.TabIndex = 4;
            // 
            // lblDateFieldName
            // 
            this.lblDateFieldName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDateFieldName.AutoSize = true;
            this.lblDateFieldName.Location = new System.Drawing.Point(150, 5);
            this.lblDateFieldName.Name = "lblDateFieldName";
            this.lblDateFieldName.Size = new System.Drawing.Size(33, 13);
            this.lblDateFieldName.TabIndex = 5;
            this.lblDateFieldName.Text = "&Date:";
            // 
            // dtpToTime
            // 
            this.dtpToTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpToTime.Checked = false;
            this.dtpToTime.CustomFormat = "h:mm tt";
            this.dtpToTime.Enabled = false;
            this.dtpToTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToTime.Location = new System.Drawing.Point(277, 47);
            this.dtpToTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpToTime.Name = "dtpToTime";
            this.dtpToTime.ShowCheckBox = true;
            this.dtpToTime.ShowUpDown = true;
            this.dtpToTime.Size = new System.Drawing.Size(84, 20);
            this.dtpToTime.TabIndex = 12;
            // 
            // dtpFromTime
            // 
            this.dtpFromTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFromTime.Checked = false;
            this.dtpFromTime.CustomFormat = "h:mm tt";
            this.dtpFromTime.Enabled = false;
            this.dtpFromTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromTime.Location = new System.Drawing.Point(277, 25);
            this.dtpFromTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpFromTime.Name = "dtpFromTime";
            this.dtpFromTime.ShowCheckBox = true;
            this.dtpFromTime.ShowUpDown = true;
            this.dtpFromTime.Size = new System.Drawing.Size(84, 20);
            this.dtpFromTime.TabIndex = 9;
            // 
            // cmbPriority
            // 
            this.cmbPriority.BackColor = System.Drawing.Color.White;
            this.cmbPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPriority.FormattingEnabled = true;
            this.cmbPriority.Location = new System.Drawing.Point(198, 1);
            this.cmbPriority.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbPriority.Name = "cmbPriority";
            this.cmbPriority.Size = new System.Drawing.Size(90, 21);
            this.cmbPriority.TabIndex = 7;
            // 
            // lblOrderBy
            // 
            this.lblOrderBy.AutoSize = true;
            this.lblOrderBy.Location = new System.Drawing.Point(146, 28);
            this.lblOrderBy.Name = "lblOrderBy";
            this.lblOrderBy.Size = new System.Drawing.Size(50, 13);
            this.lblOrderBy.TabIndex = 8;
            this.lblOrderBy.Text = "O&rder by:";
            // 
            // cmbLocation
            // 
            this.cmbLocation.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbLocation.BackColor = System.Drawing.Color.White;
            this.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Location = new System.Drawing.Point(51, 1);
            this.cmbLocation.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(94, 21);
            this.cmbLocation.TabIndex = 1;
            // 
            // cmbOrderBy
            // 
            this.cmbOrderBy.BackColor = System.Drawing.Color.White;
            this.cmbOrderBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrderBy.FormattingEnabled = true;
            this.cmbOrderBy.Location = new System.Drawing.Point(198, 24);
            this.cmbOrderBy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbOrderBy.Name = "cmbOrderBy";
            this.cmbOrderBy.Size = new System.Drawing.Size(90, 21);
            this.cmbOrderBy.TabIndex = 9;
            // 
            // lblPriority
            // 
            this.lblPriority.AutoSize = true;
            this.lblPriority.Location = new System.Drawing.Point(146, 5);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(41, 13);
            this.lblPriority.TabIndex = 6;
            this.lblPriority.Text = "&Priority:";
            // 
            // cmbGroupBy
            // 
            this.cmbGroupBy.BackColor = System.Drawing.Color.White;
            this.cmbGroupBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGroupBy.FormattingEnabled = true;
            this.cmbGroupBy.Location = new System.Drawing.Point(198, 47);
            this.cmbGroupBy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbGroupBy.Name = "cmbGroupBy";
            this.cmbGroupBy.Size = new System.Drawing.Size(90, 21);
            this.cmbGroupBy.TabIndex = 11;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(0, 4);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(51, 13);
            this.lblLocation.TabIndex = 0;
            this.lblLocation.Text = "&Location:";
            // 
            // lblGroupBy
            // 
            this.lblGroupBy.AutoSize = true;
            this.lblGroupBy.Location = new System.Drawing.Point(146, 51);
            this.lblGroupBy.Name = "lblGroupBy";
            this.lblGroupBy.Size = new System.Drawing.Size(53, 13);
            this.lblGroupBy.TabIndex = 10;
            this.lblGroupBy.Text = "&Group by:";
            // 
            // USearchBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitter);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "USearchBar";
            this.Size = new System.Drawing.Size(688, 73);
            this.splitter.Panel1.ResumeLayout(false);
            this.splitter.Panel1.PerformLayout();
            this.splitter.Panel2.ResumeLayout(false);
            this.splitter.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitter)).EndInit();
            this.splitter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Scalable.Win.Controls.iComboBox cmbTaskType;
        private Scalable.Win.Controls.iLabel lblType;
        private Scalable.Win.Controls.iLabel lblProject;
        private Scalable.Win.Controls.iComboBox cmbProject;
        private Scalable.Win.Controls.iLabel lblStatus;
        private Scalable.Win.Controls.iComboBox cmbStatus;
        private Scalable.Win.Controls.iComboBox cmbDateFieldName;
        private Scalable.Win.Controls.iDateTimePicker dtpFromDate;
        private Scalable.Win.Controls.iLabel lblUser;
        private Scalable.Win.Controls.iComboBox cmbAssigned;
        private Scalable.Win.Controls.iDateTimePicker dtpToDate;
        private Scalable.Win.Controls.iLabel lblToDateTime;
        private Scalable.Win.Controls.iLabel lblFromDateTime;
        public Scalable.Win.Controls.iButton btnSearch;
        private Scalable.Win.Controls.iButton btnReset;
        private Scalable.Win.Controls.iSplitContainer splitter;
        private Scalable.Win.Controls.iTextBoxButton txbAssigned;
        private Scalable.Win.Controls.iDateTimePicker dtpFromTime;
        private Scalable.Win.Controls.iDateTimePicker dtpToTime;
        private Scalable.Win.Controls.iComboBox cmbLocation;
        private Scalable.Win.Controls.iLabel lblLocation;
        private Scalable.Win.Controls.iLabel lblDateFieldName;
        private Scalable.Win.Controls.iComboBox cmbPriority;
        private Scalable.Win.Controls.iLabel lblOrderBy;
        private Scalable.Win.Controls.iLabel lblGroupBy;
        private Scalable.Win.Controls.iComboBox cmbOrderBy;
        private Scalable.Win.Controls.iLabel lblPriority;
        private Scalable.Win.Controls.iComboBox cmbGroupBy;
    }
}
