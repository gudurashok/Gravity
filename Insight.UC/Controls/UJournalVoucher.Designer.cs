namespace Insight.UC.Controls
{
    partial class UJournalVoucher
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
            this.lblDebit = new Scalable.Win.Controls.iLabel();
            this.txbDebitAccount = new Scalable.Win.Controls.iTextBoxButton();
            this.lblNotesDebit = new Scalable.Win.Controls.iLabel();
            this.rtbNotesDebit = new Scalable.Win.Controls.iRichTextBox();
            this.CommandBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAccount
            // 
            this.lblAccount.Size = new System.Drawing.Size(37, 13);
            this.lblAccount.Text = "&Credit:";
            // 
            // lblAmount
            // 
            this.lblAmount.Location = new System.Drawing.Point(2, 161);
            this.lblAmount.TabIndex = 15;
            // 
            // rtbDescription
            // 
            this.rtbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbDescription.Location = new System.Drawing.Point(68, 68);
            this.rtbDescription.Size = new System.Drawing.Size(312, 32);
            this.rtbDescription.TabIndex = 10;
            // 
            // lblNotes
            // 
            this.lblNotes.Location = new System.Drawing.Point(2, 68);
            this.lblNotes.TabIndex = 9;
            // 
            // btnSave
            // 
            this.btnSave.TabIndex = 1;
            // 
            // btnNew
            // 
            this.btnNew.TabIndex = 2;
            // 
            // btnDelete
            // 
            this.btnDelete.TabIndex = 3;
            // 
            // ntbAmount
            // 
            this.ntbAmount.Location = new System.Drawing.Point(68, 158);
            this.ntbAmount.TabIndex = 16;
            // 
            // CommandBar
            // 
            this.CommandBar.Location = new System.Drawing.Point(-1, 181);
            this.CommandBar.TabIndex = 17;
            // 
            // lblDebit
            // 
            this.lblDebit.AutoSize = true;
            this.lblDebit.Location = new System.Drawing.Point(2, 105);
            this.lblDebit.Name = "lblDebit";
            this.lblDebit.Size = new System.Drawing.Size(35, 13);
            this.lblDebit.TabIndex = 11;
            this.lblDebit.Text = "&Debit:";
            // 
            // txbDebitAccount
            // 
            this.txbDebitAccount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbDebitAccount.Location = new System.Drawing.Point(68, 102);
            this.txbDebitAccount.Name = "txbDebitAccount";
            this.txbDebitAccount.SearchProperty = "Name";
            this.txbDebitAccount.Size = new System.Drawing.Size(312, 20);
            this.txbDebitAccount.TabIndex = 12;
            // 
            // lblNotesDebit
            // 
            this.lblNotesDebit.AutoSize = true;
            this.lblNotesDebit.Location = new System.Drawing.Point(2, 132);
            this.lblNotesDebit.Name = "lblNotesDebit";
            this.lblNotesDebit.Size = new System.Drawing.Size(38, 13);
            this.lblNotesDebit.TabIndex = 13;
            this.lblNotesDebit.Text = "No&tes:";
            // 
            // rtbNotesDebit
            // 
            this.rtbNotesDebit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbNotesDebit.Location = new System.Drawing.Point(68, 124);
            this.rtbNotesDebit.Name = "rtbNotesDebit";
            this.rtbNotesDebit.ShowSelectionMargin = true;
            this.rtbNotesDebit.Size = new System.Drawing.Size(312, 32);
            this.rtbNotesDebit.TabIndex = 14;
            this.rtbNotesDebit.Text = "";
            // 
            // UJournalVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rtbNotesDebit);
            this.Controls.Add(this.txbDebitAccount);
            this.Controls.Add(this.lblDebit);
            this.Controls.Add(this.lblNotesDebit);
            this.MaximumSize = new System.Drawing.Size(640, 215);
            this.MinimumSize = new System.Drawing.Size(385, 215);
            this.Name = "UJournalVoucher";
            this.Size = new System.Drawing.Size(385, 215);
            this.Controls.SetChildIndex(this.lblNotesDebit, 0);
            this.Controls.SetChildIndex(this.lblNotes, 0);
            this.Controls.SetChildIndex(this.rtbDescription, 0);
            this.Controls.SetChildIndex(this.lblDebit, 0);
            this.Controls.SetChildIndex(this.txbDebitAccount, 0);
            this.Controls.SetChildIndex(this.rtbNotesDebit, 0);
            this.Controls.SetChildIndex(this.lblAmount, 0);
            this.Controls.SetChildIndex(this.ntbAmount, 0);
            this.Controls.SetChildIndex(this.txtDocNr, 0);
            this.Controls.SetChildIndex(this.txtDaybook, 0);
            this.Controls.SetChildIndex(this.btnChange, 0);
            this.Controls.SetChildIndex(this.lblDate, 0);
            this.Controls.SetChildIndex(this.lblDocNr, 0);
            this.Controls.SetChildIndex(this.dtpDate, 0);
            this.Controls.SetChildIndex(this.txbAccount, 0);
            this.Controls.SetChildIndex(this.lblAccount, 0);
            this.Controls.SetChildIndex(this.lblDaybook, 0);
            this.Controls.SetChildIndex(this.CommandBar, 0);
            this.CommandBar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Scalable.Win.Controls.iLabel lblDebit;
        private Scalable.Win.Controls.iTextBoxButton txbDebitAccount;
        private Scalable.Win.Controls.iLabel lblNotesDebit;
        private Scalable.Win.Controls.iRichTextBox rtbNotesDebit;
    }
}
