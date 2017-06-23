namespace Insight.UC.Controls
{
    partial class USaleInvoice
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
            this.dgvLineItems = new Scalable.Win.Controls.iDataGridView();
            this.uLineItem = new Insight.UC.Controls.ULineItem();
            this.btnDeleteItem = new Scalable.Win.Controls.iButton();
            this.tableLayout = new Scalable.Win.Controls.iTableLayoutPanel();
            this.dgvBillTerms = new Scalable.Win.Controls.iDataGridView();
            this.CommandBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItems)).BeginInit();
            this.tableLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillTerms)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDaybook
            // 
            this.txtDaybook.Size = new System.Drawing.Size(423, 20);
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(492, 1);
            // 
            // txtDocNr
            // 
            this.txtDocNr.Size = new System.Drawing.Size(343, 20);
            // 
            // lblDate
            // 
            this.lblDate.Location = new System.Drawing.Point(413, 27);
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(448, 24);
            // 
            // txbAccount
            // 
            this.txbAccount.Size = new System.Drawing.Size(475, 20);
            // 
            // lblAmount
            // 
            this.lblAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAmount.Location = new System.Drawing.Point(415, 387);
            this.lblAmount.TabIndex = 12;
            // 
            // rtbDescription
            // 
            this.rtbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbDescription.Location = new System.Drawing.Point(4, 424);
            this.rtbDescription.Size = new System.Drawing.Size(540, 48);
            this.rtbDescription.TabIndex = 15;
            // 
            // lblNotes
            // 
            this.lblNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNotes.Location = new System.Drawing.Point(2, 408);
            this.lblNotes.TabIndex = 14;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(383, 4);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(465, 4);
            this.btnClose.TabIndex = 1;
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
            this.ntbAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ntbAmount.BackColor = System.Drawing.Color.White;
            this.ntbAmount.Location = new System.Drawing.Point(459, 384);
            this.ntbAmount.ReadOnly = true;
            this.ntbAmount.Size = new System.Drawing.Size(84, 20);
            this.ntbAmount.TabIndex = 13;
            // 
            // CommandBar
            // 
            this.CommandBar.Location = new System.Drawing.Point(-1, 474);
            this.CommandBar.Size = new System.Drawing.Size(550, 35);
            this.CommandBar.TabIndex = 16;
            // 
            // dgvLineItems
            // 
            this.dgvLineItems.AllowUserToOrderColumns = true;
            this.dgvLineItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLineItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLineItems.Location = new System.Drawing.Point(3, 3);
            this.dgvLineItems.MultiSelect = false;
            this.dgvLineItems.Name = "dgvLineItems";
            this.dgvLineItems.Size = new System.Drawing.Size(538, 158);
            this.dgvLineItems.TabIndex = 11;
            // 
            // uLineItem
            // 
            this.uLineItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uLineItem.Location = new System.Drawing.Point(-2, 68);
            this.uLineItem.MaximumSize = new System.Drawing.Size(640, 20);
            this.uLineItem.MinimumSize = new System.Drawing.Size(360, 20);
            this.uLineItem.Name = "uLineItem";
            this.uLineItem.Size = new System.Drawing.Size(499, 20);
            this.uLineItem.TabIndex = 9;
            // 
            // btnDeleteItem
            // 
            this.btnDeleteItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteItem.Location = new System.Drawing.Point(498, 67);
            this.btnDeleteItem.Name = "btnDeleteItem";
            this.btnDeleteItem.Size = new System.Drawing.Size(46, 22);
            this.btnDeleteItem.TabIndex = 10;
            this.btnDeleteItem.Text = "Delete";
            this.btnDeleteItem.UseVisualStyleBackColor = true;
            // 
            // tableLayout
            // 
            this.tableLayout.ColumnCount = 1;
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayout.Controls.Add(this.dgvLineItems, 0, 0);
            this.tableLayout.Controls.Add(this.dgvBillTerms, 0, 1);
            this.tableLayout.Location = new System.Drawing.Point(2, 88);
            this.tableLayout.Name = "tableLayout";
            this.tableLayout.RowCount = 2;
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.74324F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.25676F));
            this.tableLayout.Size = new System.Drawing.Size(544, 296);
            this.tableLayout.TabIndex = 17;
            // 
            // dgvBillTerms
            // 
            this.dgvBillTerms.AllowUserToOrderColumns = true;
            this.dgvBillTerms.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBillTerms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBillTerms.Location = new System.Drawing.Point(3, 167);
            this.dgvBillTerms.MultiSelect = false;
            this.dgvBillTerms.Name = "dgvBillTerms";
            this.dgvBillTerms.Size = new System.Drawing.Size(538, 126);
            this.dgvBillTerms.TabIndex = 11;
            // 
            // USaleInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDeleteItem);
            this.Controls.Add(this.uLineItem);
            this.Controls.Add(this.tableLayout);
            this.Name = "USaleInvoice";
            this.Size = new System.Drawing.Size(548, 508);
            this.Controls.SetChildIndex(this.tableLayout, 0);
            this.Controls.SetChildIndex(this.lblAmount, 0);
            this.Controls.SetChildIndex(this.ntbAmount, 0);
            this.Controls.SetChildIndex(this.uLineItem, 0);
            this.Controls.SetChildIndex(this.btnDeleteItem, 0);
            this.Controls.SetChildIndex(this.txtDocNr, 0);
            this.Controls.SetChildIndex(this.txtDaybook, 0);
            this.Controls.SetChildIndex(this.btnChange, 0);
            this.Controls.SetChildIndex(this.lblDate, 0);
            this.Controls.SetChildIndex(this.lblNotes, 0);
            this.Controls.SetChildIndex(this.lblDocNr, 0);
            this.Controls.SetChildIndex(this.dtpDate, 0);
            this.Controls.SetChildIndex(this.txbAccount, 0);
            this.Controls.SetChildIndex(this.lblAccount, 0);
            this.Controls.SetChildIndex(this.lblDaybook, 0);
            this.Controls.SetChildIndex(this.rtbDescription, 0);
            this.Controls.SetChildIndex(this.CommandBar, 0);
            this.CommandBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItems)).EndInit();
            this.tableLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillTerms)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Scalable.Win.Controls.iDataGridView dgvLineItems;
        private ULineItem uLineItem;
        private Scalable.Win.Controls.iButton btnDeleteItem;
        private Scalable.Win.Controls.iTableLayoutPanel tableLayout;
        private Scalable.Win.Controls.iDataGridView dgvBillTerms;
    }
}
