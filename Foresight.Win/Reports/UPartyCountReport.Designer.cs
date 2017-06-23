﻿namespace Foresight.Win.Reports
{
    partial class UPartyCountReport
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
            this.btnClose = new Scalable.Win.Controls.iButton();
            this.lvwReport = new Scalable.Win.Controls.iListView();
            this.btnSelectCompany = new Scalable.Win.Controls.iButton();
            this.btnSelectAll = new Scalable.Win.Controls.iButton();
            this.lblCompany = new Scalable.Win.Controls.iLabel();
            this.cmbAmtFormat = new Scalable.Win.Controls.iComboBox();
            this.lblAmtFormat = new Scalable.Win.Controls.iLabel();
            this.btnShow = new Scalable.Win.Controls.iButton();
            this.chkPartyGrouping = new Scalable.Win.Controls.iCheckBox();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Size = new System.Drawing.Size(551, 43);
            this.pnlHeader.TabIndex = 9;
            // 
            // lblTitle
            // 
            this.lblTitle.TabIndex = 0;
            // 
            // lblDescription
            // 
            this.lblDescription.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Red;
            this.btnClose.Location = new System.Drawing.Point(523, 48);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(23, 23);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lvwReport
            // 
            this.lvwReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwReport.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwReport.FullRowSelect = true;
            this.lvwReport.GridLines = true;
            this.lvwReport.HideSelection = false;
            this.lvwReport.Location = new System.Drawing.Point(5, 76);
            this.lvwReport.MultiSelect = false;
            this.lvwReport.Name = "lvwReport";
            this.lvwReport.Size = new System.Drawing.Size(541, 271);
            this.lvwReport.TabIndex = 8;
            this.lvwReport.UseCompatibleStateImageBehavior = false;
            this.lvwReport.View = System.Windows.Forms.View.Details;
            // 
            // btnSelectCompany
            // 
            this.btnSelectCompany.Location = new System.Drawing.Point(143, 48);
            this.btnSelectCompany.Name = "btnSelectCompany";
            this.btnSelectCompany.Size = new System.Drawing.Size(75, 23);
            this.btnSelectCompany.TabIndex = 3;
            this.btnSelectCompany.Text = "Select...";
            this.btnSelectCompany.UseVisualStyleBackColor = true;
            this.btnSelectCompany.Click += new System.EventHandler(this.btnSelectCompany_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(62, 48);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(75, 23);
            this.btnSelectAll.TabIndex = 2;
            this.btnSelectAll.Text = "Select All";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Location = new System.Drawing.Point(2, 53);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(54, 13);
            this.lblCompany.TabIndex = 1;
            this.lblCompany.Text = "&Company:";
            // 
            // cmbAmtFormat
            // 
            this.cmbAmtFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAmtFormat.FormattingEnabled = true;
            this.cmbAmtFormat.Location = new System.Drawing.Point(275, 49);
            this.cmbAmtFormat.Name = "cmbAmtFormat";
            this.cmbAmtFormat.Size = new System.Drawing.Size(80, 21);
            this.cmbAmtFormat.TabIndex = 5;
            this.cmbAmtFormat.SelectedIndexChanged += new System.EventHandler(this.cmbAmtFormat_SelectedIndexChanged);
            // 
            // lblAmtFormat
            // 
            this.lblAmtFormat.AutoSize = true;
            this.lblAmtFormat.Location = new System.Drawing.Point(227, 53);
            this.lblAmtFormat.Name = "lblAmtFormat";
            this.lblAmtFormat.Size = new System.Drawing.Size(42, 13);
            this.lblAmtFormat.TabIndex = 4;
            this.lblAmtFormat.Text = "&Format:";
            // 
            // btnShow
            // 
            this.btnShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShow.Location = new System.Drawing.Point(474, 48);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(43, 23);
            this.btnShow.TabIndex = 0;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // chkPartyGrouping
            // 
            this.chkPartyGrouping.AutoSize = true;
            this.chkPartyGrouping.Location = new System.Drawing.Point(361, 51);
            this.chkPartyGrouping.Name = "chkPartyGrouping";
            this.chkPartyGrouping.Size = new System.Drawing.Size(96, 17);
            this.chkPartyGrouping.TabIndex = 6;
            this.chkPartyGrouping.Text = "Party Grouping";
            this.chkPartyGrouping.UseVisualStyleBackColor = true;
            // 
            // UPartyCountReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkPartyGrouping);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.cmbAmtFormat);
            this.Controls.Add(this.lblAmtFormat);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lvwReport);
            this.Controls.Add(this.btnSelectCompany);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.lblCompany);
            this.Name = "UPartyCountReport";
            this.Size = new System.Drawing.Size(551, 351);
            this.Load += new System.EventHandler(this.UPartyCountReport_Load);
            this.Controls.SetChildIndex(this.lblCompany, 0);
            this.Controls.SetChildIndex(this.btnSelectAll, 0);
            this.Controls.SetChildIndex(this.pnlHeader, 0);
            this.Controls.SetChildIndex(this.btnSelectCompany, 0);
            this.Controls.SetChildIndex(this.lvwReport, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.lblAmtFormat, 0);
            this.Controls.SetChildIndex(this.cmbAmtFormat, 0);
            this.Controls.SetChildIndex(this.btnShow, 0);
            this.Controls.SetChildIndex(this.chkPartyGrouping, 0);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        
        #endregion

        private Scalable.Win.Controls.iButton btnClose;
        private Scalable.Win.Controls.iListView lvwReport;
        private Scalable.Win.Controls.iButton btnSelectCompany;
        private Scalable.Win.Controls.iButton btnSelectAll;
        private Scalable.Win.Controls.iLabel lblCompany;
        private Scalable.Win.Controls.iComboBox cmbAmtFormat;
        private Scalable.Win.Controls.iLabel lblAmtFormat;
        private Scalable.Win.Controls.iButton btnShow;
        private Scalable.Win.Controls.iCheckBox chkPartyGrouping;
    }
}
