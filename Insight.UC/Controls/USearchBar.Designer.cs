namespace Insight.UC.Controls
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
            this.btnReset = new Scalable.Win.Controls.iButton();
            this.btnSearch = new Scalable.Win.Controls.iButton();
            this.lblDocumentNr = new Scalable.Win.Controls.iLabel();
            this.txtDocumentNr = new Scalable.Win.Controls.iTextBox();
            this.txbDaybook = new Scalable.Win.Controls.iTextBoxButton();
            this.lblDaybook = new Scalable.Win.Controls.iLabel();
            this.lblAccount = new Scalable.Win.Controls.iLabel();
            this.txbAccount = new Scalable.Win.Controls.iTextBoxButton();
            this.dtpFrom = new Scalable.Win.Controls.iDateTimePicker();
            this.dtpTo = new Scalable.Win.Controls.iDateTimePicker();
            this.lblFrom = new Scalable.Win.Controls.iLabel();
            this.lblTo = new Scalable.Win.Controls.iLabel();
            this.lblMinAmount = new Scalable.Win.Controls.iLabel();
            this.lblMaxAmount = new Scalable.Win.Controls.iLabel();
            this.ntbMinAmount = new Scalable.Win.Controls.iNumberTextBox();
            this.ntbMaxAmount = new Scalable.Win.Controls.iNumberTextBox();
            this.SuspendLayout();
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.Location = new System.Drawing.Point(573, 23);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(62, 21);
            this.btnReset.TabIndex = 15;
            this.btnReset.Text = "Reset";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSearch.Location = new System.Drawing.Point(510, 23);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(62, 21);
            this.btnSearch.TabIndex = 14;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblDocumentNr
            // 
            this.lblDocumentNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDocumentNr.AutoSize = true;
            this.lblDocumentNr.Location = new System.Drawing.Point(507, 5);
            this.lblDocumentNr.Name = "lblDocumentNr";
            this.lblDocumentNr.Size = new System.Drawing.Size(47, 13);
            this.lblDocumentNr.TabIndex = 12;
            this.lblDocumentNr.Text = "Doc Nr.:";
            // 
            // txtDocumentNr
            // 
            this.txtDocumentNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDocumentNr.Location = new System.Drawing.Point(554, 2);
            this.txtDocumentNr.Name = "txtDocumentNr";
            this.txtDocumentNr.Size = new System.Drawing.Size(80, 20);
            this.txtDocumentNr.TabIndex = 13;
            // 
            // txbDaybook
            // 
            this.txbDaybook.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbDaybook.Location = new System.Drawing.Point(53, 2);
            this.txbDaybook.Name = "txbDaybook";
            this.txbDaybook.SearchProperty = "Name";
            this.txbDaybook.Size = new System.Drawing.Size(144, 20);
            this.txbDaybook.TabIndex = 1;
            // 
            // lblDaybook
            // 
            this.lblDaybook.AutoSize = true;
            this.lblDaybook.Location = new System.Drawing.Point(0, 5);
            this.lblDaybook.Name = "lblDaybook";
            this.lblDaybook.Size = new System.Drawing.Size(53, 13);
            this.lblDaybook.TabIndex = 0;
            this.lblDaybook.Text = "Daybook:";
            // 
            // lblAccount
            // 
            this.lblAccount.AutoSize = true;
            this.lblAccount.Location = new System.Drawing.Point(0, 26);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(50, 13);
            this.lblAccount.TabIndex = 2;
            this.lblAccount.Text = "Account:";
            // 
            // txbAccount
            // 
            this.txbAccount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbAccount.Location = new System.Drawing.Point(53, 23);
            this.txbAccount.Name = "txbAccount";
            this.txbAccount.SearchProperty = "Name";
            this.txbAccount.Size = new System.Drawing.Size(144, 20);
            this.txbAccount.TabIndex = 3;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFrom.Checked = false;
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(232, 2);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.ShowCheckBox = true;
            this.dtpFrom.Size = new System.Drawing.Size(112, 20);
            this.dtpFrom.TabIndex = 5;
            // 
            // dtpTo
            // 
            this.dtpTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpTo.Checked = false;
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(232, 23);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.ShowCheckBox = true;
            this.dtpTo.Size = new System.Drawing.Size(112, 20);
            this.dtpTo.TabIndex = 7;
            // 
            // lblFrom
            // 
            this.lblFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(199, 5);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(33, 13);
            this.lblFrom.TabIndex = 4;
            this.lblFrom.Text = "From:";
            // 
            // lblTo
            // 
            this.lblTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(199, 27);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(23, 13);
            this.lblTo.TabIndex = 6;
            this.lblTo.Text = "To:";
            // 
            // lblMinAmount
            // 
            this.lblMinAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMinAmount.AutoSize = true;
            this.lblMinAmount.Location = new System.Drawing.Point(347, 5);
            this.lblMinAmount.Name = "lblMinAmount";
            this.lblMinAmount.Size = new System.Drawing.Size(66, 13);
            this.lblMinAmount.TabIndex = 8;
            this.lblMinAmount.Text = "Min Amount:";
            // 
            // lblMaxAmount
            // 
            this.lblMaxAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMaxAmount.AutoSize = true;
            this.lblMaxAmount.Location = new System.Drawing.Point(347, 27);
            this.lblMaxAmount.Name = "lblMaxAmount";
            this.lblMaxAmount.Size = new System.Drawing.Size(69, 13);
            this.lblMaxAmount.TabIndex = 10;
            this.lblMaxAmount.Text = "Max Amount:";
            // 
            // ntbMinAmount
            // 
            this.ntbMinAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ntbMinAmount.DisplayFormat = "##,##,##,###.##";
            this.ntbMinAmount.Location = new System.Drawing.Point(415, 2);
            this.ntbMinAmount.Name = "ntbMinAmount";
            this.ntbMinAmount.Size = new System.Drawing.Size(91, 20);
            this.ntbMinAmount.TabIndex = 9;
            this.ntbMinAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntbMinAmount.Value = 0D;
            this.ntbMinAmount.ValueFormat = "9.2";
            // 
            // ntbMaxAmount
            // 
            this.ntbMaxAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ntbMaxAmount.DisplayFormat = "##,##,##,###.##";
            this.ntbMaxAmount.Location = new System.Drawing.Point(415, 23);
            this.ntbMaxAmount.Name = "ntbMaxAmount";
            this.ntbMaxAmount.Size = new System.Drawing.Size(91, 20);
            this.ntbMaxAmount.TabIndex = 11;
            this.ntbMaxAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntbMaxAmount.Value = 0D;
            this.ntbMaxAmount.ValueFormat = "9.2";
            // 
            // USearchBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ntbMaxAmount);
            this.Controls.Add(this.ntbMinAmount);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.txbAccount);
            this.Controls.Add(this.txbDaybook);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.lblAccount);
            this.Controls.Add(this.lblMaxAmount);
            this.Controls.Add(this.txtDocumentNr);
            this.Controls.Add(this.lblMinAmount);
            this.Controls.Add(this.lblDaybook);
            this.Controls.Add(this.lblDocumentNr);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSearch);
            this.Name = "USearchBar";
            this.Size = new System.Drawing.Size(638, 47);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Scalable.Win.Controls.iButton btnReset;
        public  Scalable.Win.Controls.iButton btnSearch;
        private Scalable.Win.Controls.iLabel lblDocumentNr;
        private Scalable.Win.Controls.iTextBox txtDocumentNr;
        private Scalable.Win.Controls.iTextBoxButton txbDaybook;
        private Scalable.Win.Controls.iLabel lblDaybook;
        private Scalable.Win.Controls.iLabel lblAccount;
        private Scalable.Win.Controls.iTextBoxButton txbAccount;
        private Scalable.Win.Controls.iDateTimePicker dtpFrom;
        private Scalable.Win.Controls.iDateTimePicker dtpTo;
        private Scalable.Win.Controls.iLabel lblFrom;
        private Scalable.Win.Controls.iLabel lblTo;
        private Scalable.Win.Controls.iLabel lblMinAmount;
        private Scalable.Win.Controls.iLabel lblMaxAmount;
        private Scalable.Win.Controls.iNumberTextBox ntbMinAmount;
        private Scalable.Win.Controls.iNumberTextBox ntbMaxAmount;
    }
}
