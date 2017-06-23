namespace Insight.UC.Controls
{
    partial class UVoucher
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
            this.lblDaybook = new Scalable.Win.Controls.iLabel();
            this.txtDaybook = new Scalable.Win.Controls.iTextBox();
            this.btnChange = new Scalable.Win.Controls.iButton();
            this.txtDocNr = new Scalable.Win.Controls.iTextBox();
            this.lblDocNr = new Scalable.Win.Controls.iLabel();
            this.lblDate = new Scalable.Win.Controls.iLabel();
            this.dtpDate = new Scalable.Win.Controls.iDateTimePicker();
            this.txbAccount = new Scalable.Win.Controls.iTextBoxButton();
            this.lblAccount = new Scalable.Win.Controls.iLabel();
            this.lblAmount = new Scalable.Win.Controls.iLabel();
            this.rtbDescription = new Scalable.Win.Controls.iRichTextBox();
            this.lblNotes = new Scalable.Win.Controls.iLabel();
            this.btnSave = new Scalable.Win.Controls.iCommandButton();
            this.btnClose = new Scalable.Win.Controls.iCommandButton();
            this.btnNew = new Scalable.Win.Controls.iCommandButton();
            this.btnDelete = new Scalable.Win.Controls.iCommandButton();
            this.ntbAmount = new Scalable.Win.Controls.iNumberTextBox();
            this.CommandBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // CommandBar
            // 
            this.CommandBar.Controls.Add(this.btnClose);
            this.CommandBar.Controls.Add(this.btnDelete);
            this.CommandBar.Controls.Add(this.btnNew);
            this.CommandBar.Controls.Add(this.btnSave);
            this.CommandBar.Location = new System.Drawing.Point(-1, 174);
            this.CommandBar.Size = new System.Drawing.Size(387, 35);
            this.CommandBar.TabIndex = 13;
            // 
            // lblDaybook
            // 
            this.lblDaybook.AutoSize = true;
            this.lblDaybook.Location = new System.Drawing.Point(2, 5);
            this.lblDaybook.Name = "lblDaybook";
            this.lblDaybook.Size = new System.Drawing.Size(53, 13);
            this.lblDaybook.TabIndex = 0;
            this.lblDaybook.Text = "&Daybook:";
            // 
            // txtDaybook
            // 
            this.txtDaybook.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDaybook.BackColor = System.Drawing.Color.White;
            this.txtDaybook.Location = new System.Drawing.Point(68, 2);
            this.txtDaybook.Name = "txtDaybook";
            this.txtDaybook.ReadOnly = true;
            this.txtDaybook.Size = new System.Drawing.Size(260, 20);
            this.txtDaybook.TabIndex = 1;
            // 
            // btnChange
            // 
            this.btnChange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChange.Location = new System.Drawing.Point(329, 1);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(53, 22);
            this.btnChange.TabIndex = 2;
            this.btnChange.Text = "&Change";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // txtDocNr
            // 
            this.txtDocNr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDocNr.BackColor = System.Drawing.Color.White;
            this.txtDocNr.Location = new System.Drawing.Point(68, 24);
            this.txtDocNr.Name = "txtDocNr";
            this.txtDocNr.ReadOnly = true;
            this.txtDocNr.Size = new System.Drawing.Size(180, 20);
            this.txtDocNr.TabIndex = 4;
            // 
            // lblDocNr
            // 
            this.lblDocNr.AutoSize = true;
            this.lblDocNr.Location = new System.Drawing.Point(2, 27);
            this.lblDocNr.Name = "lblDocNr";
            this.lblDocNr.Size = new System.Drawing.Size(44, 13);
            this.lblDocNr.TabIndex = 3;
            this.lblDocNr.Text = "Doc &Nr:";
            // 
            // lblDate
            // 
            this.lblDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(250, 27);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(33, 13);
            this.lblDate.TabIndex = 5;
            this.lblDate.Text = "Da&te:";
            // 
            // dtpDate
            // 
            this.dtpDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(285, 24);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(96, 20);
            this.dtpDate.TabIndex = 6;
            // 
            // txbAccount
            // 
            this.txbAccount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbAccount.Location = new System.Drawing.Point(68, 46);
            this.txbAccount.Name = "txbAccount";
            this.txbAccount.SearchProperty = "Name";
            this.txbAccount.Size = new System.Drawing.Size(312, 20);
            this.txbAccount.TabIndex = 8;
            // 
            // lblAccount
            // 
            this.lblAccount.AutoSize = true;
            this.lblAccount.Location = new System.Drawing.Point(2, 49);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(50, 13);
            this.lblAccount.TabIndex = 7;
            this.lblAccount.Text = "&Account:";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(2, 71);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(46, 13);
            this.lblAmount.TabIndex = 9;
            this.lblAmount.Text = "A&mount:";
            // 
            // rtbDescription
            // 
            this.rtbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbDescription.Location = new System.Drawing.Point(4, 107);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.ShowSelectionMargin = true;
            this.rtbDescription.Size = new System.Drawing.Size(377, 65);
            this.rtbDescription.TabIndex = 12;
            this.rtbDescription.Text = "";
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(2, 91);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(38, 13);
            this.lblNotes.TabIndex = 11;
            this.lblNotes.Text = "N&otes:";
            // 
            // btnSave
            // 
            this.btnSave.Action = ((Scalable.Win.Enums.CommandBarAction)((Scalable.Win.Enums.CommandBarAction.New | Scalable.Win.Enums.CommandBarAction.Save)));
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(220, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(78, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "S&ave && New";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.commandBarButton_Click);
            // 
            // btnClose
            // 
            this.btnClose.Action = ((Scalable.Win.Enums.CommandBarAction)((Scalable.Win.Enums.CommandBarAction.Save | Scalable.Win.Enums.CommandBarAction.Close)));
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(302, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(78, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Save && &Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.commandBarButton_Click);
            // 
            // btnNew
            // 
            this.btnNew.Action = Scalable.Win.Enums.CommandBarAction.New;
            this.btnNew.Location = new System.Drawing.Point(31, 4);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(78, 23);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "&New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.commandBarButton_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Action = Scalable.Win.Enums.CommandBarAction.Delete;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.Red;
            this.btnDelete.Location = new System.Drawing.Point(4, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(23, 23);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Text = "X";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.commandBarButton_Click);
            // 
            // ntbAmount
            // 
            this.ntbAmount.ValueFormat = "9.2";
            this.ntbAmount.Location = new System.Drawing.Point(68, 68);
            this.ntbAmount.Name = "ntbAmount";
            this.ntbAmount.Size = new System.Drawing.Size(180, 20);
            this.ntbAmount.TabIndex = 10;
            this.ntbAmount.Text = "0";
            this.ntbAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntbAmount.Value = 0D;
            this.ntbAmount.DisplayFormat = "##,##,##,###.##";
            // 
            // UVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rtbDescription);
            this.Controls.Add(this.ntbAmount);
            this.Controls.Add(this.lblDaybook);
            this.Controls.Add(this.lblAccount);
            this.Controls.Add(this.txbAccount);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblDocNr);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.txtDaybook);
            this.Controls.Add(this.txtDocNr);
            this.Name = "UVoucher";
            this.Size = new System.Drawing.Size(385, 208);
            this.Controls.SetChildIndex(this.txtDocNr, 0);
            this.Controls.SetChildIndex(this.txtDaybook, 0);
            this.Controls.SetChildIndex(this.btnChange, 0);
            this.Controls.SetChildIndex(this.lblDate, 0);
            this.Controls.SetChildIndex(this.lblNotes, 0);
            this.Controls.SetChildIndex(this.lblAmount, 0);
            this.Controls.SetChildIndex(this.lblDocNr, 0);
            this.Controls.SetChildIndex(this.dtpDate, 0);
            this.Controls.SetChildIndex(this.txbAccount, 0);
            this.Controls.SetChildIndex(this.lblAccount, 0);
            this.Controls.SetChildIndex(this.lblDaybook, 0);
            this.Controls.SetChildIndex(this.ntbAmount, 0);
            this.Controls.SetChildIndex(this.rtbDescription, 0);
            this.Controls.SetChildIndex(this.CommandBar, 0);
            this.CommandBar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected Scalable.Win.Controls.iLabel lblDaybook;
        protected Scalable.Win.Controls.iTextBox txtDaybook;
        protected Scalable.Win.Controls.iButton btnChange;
        protected Scalable.Win.Controls.iTextBox txtDocNr;
        protected Scalable.Win.Controls.iLabel lblDocNr;
        protected Scalable.Win.Controls.iLabel lblDate;
        protected Scalable.Win.Controls.iDateTimePicker dtpDate;
        protected Scalable.Win.Controls.iTextBoxButton txbAccount;
        protected Scalable.Win.Controls.iLabel lblAccount;
        protected Scalable.Win.Controls.iLabel lblAmount;
        protected Scalable.Win.Controls.iRichTextBox rtbDescription;
        protected Scalable.Win.Controls.iLabel lblNotes;
        protected Scalable.Win.Controls.iCommandButton btnSave;
        protected Scalable.Win.Controls.iCommandButton btnClose;
        protected Scalable.Win.Controls.iCommandButton btnNew;
        protected Scalable.Win.Controls.iCommandButton btnDelete;
        protected Scalable.Win.Controls.iNumberTextBox ntbAmount;
    }
}
