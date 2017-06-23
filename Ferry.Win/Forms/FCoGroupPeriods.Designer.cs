namespace Ferry.Win.Forms
{
    partial class FCoGroupPeriods
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
            this.pnlCommandBar = new Scalable.Win.Controls.iPanel();
            this.btnSave = new Scalable.Win.Controls.iButton();
            this.lvwCoGroups = new Scalable.Win.Controls.iListView();
            this.pnlDetails = new Scalable.Win.Controls.iPanel();
            this.lblImportFrom = new Scalable.Win.Controls.iLabel();
            this.txtImportFrom = new Scalable.Win.Controls.iTextBox();
            this.btnImportFrom = new Scalable.Win.Controls.iButton();
            this.lblProvider = new Scalable.Win.Controls.iLabel();
            this.lblProviderName = new Scalable.Win.Controls.iLabel();
            this.lvwCoPeriods = new Scalable.Win.Controls.iListView();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnlCommandBar.SuspendLayout();
            this.pnlDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Size = new System.Drawing.Size(348, 43);
            // 
            // picLogo
            // 
            this.picLogo.Location = new System.Drawing.Point(305, 2);
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(290, 14);
            this.lblTitle.Text = "Enter company group details. Optionally import details";
            // 
            // pnlCommandBar
            // 
            this.pnlCommandBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCommandBar.BackColor = System.Drawing.SystemColors.Control;
            this.pnlCommandBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCommandBar.Controls.Add(this.btnSave);
            this.pnlCommandBar.Location = new System.Drawing.Point(-1, 380);
            this.pnlCommandBar.Name = "pnlCommandBar";
            this.pnlCommandBar.Size = new System.Drawing.Size(350, 35);
            this.pnlCommandBar.TabIndex = 4;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSave.Location = new System.Drawing.Point(137, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lvwCoGroups
            // 
            this.lvwCoGroups.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwCoGroups.CheckBoxes = true;
            this.lvwCoGroups.FullRowSelect = true;
            this.lvwCoGroups.GridLines = true;
            this.lvwCoGroups.HideSelection = false;
            this.lvwCoGroups.Location = new System.Drawing.Point(2, 94);
            this.lvwCoGroups.MultiSelect = false;
            this.lvwCoGroups.Name = "lvwCoGroups";
            this.lvwCoGroups.Size = new System.Drawing.Size(343, 99);
            this.lvwCoGroups.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvwCoGroups.TabIndex = 2;
            this.lvwCoGroups.UseCompatibleStateImageBehavior = false;
            this.lvwCoGroups.View = System.Windows.Forms.View.Details;
            this.lvwCoGroups.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvwCoGroups_ItemChecked);
            // 
            // pnlDetails
            // 
            this.pnlDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetails.Controls.Add(this.lblImportFrom);
            this.pnlDetails.Controls.Add(this.txtImportFrom);
            this.pnlDetails.Controls.Add(this.btnImportFrom);
            this.pnlDetails.Controls.Add(this.lblProvider);
            this.pnlDetails.Controls.Add(this.lblProviderName);
            this.pnlDetails.Location = new System.Drawing.Point(2, 45);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Size = new System.Drawing.Size(343, 47);
            this.pnlDetails.TabIndex = 1;
            // 
            // lblImportFrom
            // 
            this.lblImportFrom.AutoSize = true;
            this.lblImportFrom.Location = new System.Drawing.Point(0, 0);
            this.lblImportFrom.Name = "lblImportFrom";
            this.lblImportFrom.Size = new System.Drawing.Size(65, 13);
            this.lblImportFrom.TabIndex = 5;
            this.lblImportFrom.Text = "&Import From:";
            // 
            // txtImportFrom
            // 
            this.txtImportFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImportFrom.Location = new System.Drawing.Point(70, 2);
            this.txtImportFrom.Name = "txtImportFrom";
            this.txtImportFrom.ReadOnly = true;
            this.txtImportFrom.Size = new System.Drawing.Size(244, 20);
            this.txtImportFrom.TabIndex = 6;
            this.txtImportFrom.TabStop = false;
            // 
            // btnImportFrom
            // 
            this.btnImportFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImportFrom.Location = new System.Drawing.Point(314, 1);
            this.btnImportFrom.Name = "btnImportFrom";
            this.btnImportFrom.Size = new System.Drawing.Size(25, 21);
            this.btnImportFrom.TabIndex = 7;
            this.btnImportFrom.Text = "...";
            this.btnImportFrom.UseVisualStyleBackColor = true;
            this.btnImportFrom.Click += new System.EventHandler(this.btnImportFrom_Click);
            // 
            // lblProvider
            // 
            this.lblProvider.AutoSize = true;
            this.lblProvider.Location = new System.Drawing.Point(0, 21);
            this.lblProvider.Name = "lblProvider";
            this.lblProvider.Size = new System.Drawing.Size(49, 13);
            this.lblProvider.TabIndex = 8;
            this.lblProvider.Text = "&Provider:";
            // 
            // lblProviderName
            // 
            this.lblProviderName.AutoSize = true;
            this.lblProviderName.Location = new System.Drawing.Point(67, 24);
            this.lblProviderName.Name = "lblProviderName";
            this.lblProviderName.Size = new System.Drawing.Size(0, 13);
            this.lblProviderName.TabIndex = 9;
            // 
            // lvwCoPeriods
            // 
            this.lvwCoPeriods.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwCoPeriods.CheckBoxes = true;
            this.lvwCoPeriods.FullRowSelect = true;
            this.lvwCoPeriods.GridLines = true;
            this.lvwCoPeriods.HideSelection = false;
            this.lvwCoPeriods.Location = new System.Drawing.Point(2, 195);
            this.lvwCoPeriods.MultiSelect = false;
            this.lvwCoPeriods.Name = "lvwCoPeriods";
            this.lvwCoPeriods.Size = new System.Drawing.Size(343, 182);
            this.lvwCoPeriods.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvwCoPeriods.TabIndex = 3;
            this.lvwCoPeriods.UseCompatibleStateImageBehavior = false;
            this.lvwCoPeriods.View = System.Windows.Forms.View.Details;
            this.lvwCoPeriods.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lvwCoPeriods_ItemCheck);
            // 
            // FCoGroupPeriods
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(348, 414);
            this.Controls.Add(this.pnlCommandBar);
            this.Controls.Add(this.lvwCoGroups);
            this.Controls.Add(this.pnlDetails);
            this.Controls.Add(this.lvwCoPeriods);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 370);
            this.Name = "FCoGroupPeriods";
            this.Text = "Company Groups and Periods";
            this.Controls.SetChildIndex(this.pnlHeader, 0);
            this.Controls.SetChildIndex(this.lvwCoPeriods, 0);
            this.Controls.SetChildIndex(this.pnlDetails, 0);
            this.Controls.SetChildIndex(this.lvwCoGroups, 0);
            this.Controls.SetChildIndex(this.pnlCommandBar, 0);
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.pnlCommandBar.ResumeLayout(false);
            this.pnlDetails.ResumeLayout(false);
            this.pnlDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Scalable.Win.Controls.iPanel pnlCommandBar;
        private Scalable.Win.Controls.iButton btnSave;
        private Scalable.Win.Controls.iListView lvwCoGroups;
        private Scalable.Win.Controls.iPanel pnlDetails;
        private Scalable.Win.Controls.iLabel lblProvider;
        private Scalable.Win.Controls.iLabel lblProviderName;
        private Scalable.Win.Controls.iListView lvwCoPeriods;
        private Scalable.Win.Controls.iLabel lblImportFrom;
        private Scalable.Win.Controls.iTextBox txtImportFrom;
        private Scalable.Win.Controls.iButton btnImportFrom;
    }
}