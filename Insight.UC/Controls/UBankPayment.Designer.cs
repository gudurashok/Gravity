using System.Windows.Forms;

namespace Insight.UC.Controls
{
    partial class UBankPayment
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
            this.lblBankDetails = new Scalable.Win.Controls.iLabel();
            this.txtBankDetails = new Scalable.Win.Controls.iTextBox();
            this.lblChequeNr = new Scalable.Win.Controls.iLabel();
            this.txtChequeNr = new Scalable.Win.Controls.iTextBox();
            this.CommandBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAmount
            // 
            this.lblAmount.Location = new System.Drawing.Point(0, 93);
            // 
            // rtbDescription
            // 
            this.rtbDescription.Location = new System.Drawing.Point(2, 129);
            this.rtbDescription.Size = new System.Drawing.Size(381, 105);
            // 
            // lblNotes
            // 
            this.lblNotes.Location = new System.Drawing.Point(0, 113);
            // 
            // ntbAmount
            // 
            this.ntbAmount.Location = new System.Drawing.Point(68, 90);
            // 
            // CommandBar
            // 
            this.CommandBar.Location = new System.Drawing.Point(-1, 236);
            // 
            // lblBankDetails
            // 
            this.lblBankDetails.AutoSize = true;
            this.lblBankDetails.Location = new System.Drawing.Point(0, 71);
            this.lblBankDetails.Name = "lblBankDetails";
            this.lblBankDetails.Size = new System.Drawing.Size(70, 13);
            this.lblBankDetails.TabIndex = 14;
            this.lblBankDetails.Text = "Bank Details:";
            // 
            // txtBankDetails
            // 
            this.txtBankDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBankDetails.Location = new System.Drawing.Point(68, 68);
            this.txtBankDetails.Name = "txtBankDetails";
            this.txtBankDetails.Size = new System.Drawing.Size(180, 20);
            this.txtBankDetails.TabIndex = 15;
            // 
            // lblChequeNr
            // 
            this.lblChequeNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblChequeNr.AutoSize = true;
            this.lblChequeNr.Location = new System.Drawing.Point(251, 71);
            this.lblChequeNr.Name = "lblChequeNr";
            this.lblChequeNr.Size = new System.Drawing.Size(61, 13);
            this.lblChequeNr.TabIndex = 14;
            this.lblChequeNr.Text = "Cheque Nr:";
            // 
            // txtChequeNr
            // 
            this.txtChequeNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtChequeNr.InputFilterExpr = "[0-9]";
            this.txtChequeNr.Location = new System.Drawing.Point(310, 68);
            this.txtChequeNr.Name = "txtChequeNr";
            this.txtChequeNr.Size = new System.Drawing.Size(71, 20);
            this.txtChequeNr.TabIndex = 15;
            // 
            // UBankPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.txtBankDetails);
            this.Controls.Add(this.lblBankDetails);
            this.Controls.Add(this.txtChequeNr);
            this.Controls.Add(this.lblChequeNr);
            this.Name = "UBankPayment";
            this.Size = new System.Drawing.Size(385, 270);
            this.Controls.SetChildIndex(this.ntbAmount, 0);
            this.Controls.SetChildIndex(this.lblChequeNr, 0);
            this.Controls.SetChildIndex(this.txtChequeNr, 0);
            this.Controls.SetChildIndex(this.lblBankDetails, 0);
            this.Controls.SetChildIndex(this.txtBankDetails, 0);
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
            this.Controls.SetChildIndex(this.rtbDescription, 0);
            this.Controls.SetChildIndex(this.CommandBar, 0);
            this.CommandBar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Scalable.Win.Controls.iLabel lblBankDetails;
        private Scalable.Win.Controls.iTextBox txtBankDetails;
        private Scalable.Win.Controls.iLabel lblChequeNr;
        private Scalable.Win.Controls.iTextBox txtChequeNr;


    }
}
