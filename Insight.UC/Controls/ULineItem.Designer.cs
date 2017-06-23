namespace Insight.UC.Controls
{
    partial class ULineItem
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
            this.txbItem = new Scalable.Win.Controls.iTextBoxButton();
            this.ntbQty = new Scalable.Win.Controls.iNumberTextBox();
            this.lblItem = new Scalable.Win.Controls.iLabel();
            this.lblQuantity = new Scalable.Win.Controls.iLabel();
            this.btnAdd = new Scalable.Win.Controls.iButton();
            this.ntbPrice = new Scalable.Win.Controls.iNumberTextBox();
            this.lblPrice = new Scalable.Win.Controls.iLabel();
            this.SuspendLayout();
            // 
            // txbItem
            // 
            this.txbItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbItem.Location = new System.Drawing.Point(33, 0);
            this.txbItem.Name = "txbItem";
            this.txbItem.SearchProperty = "Name";
            this.txbItem.Size = new System.Drawing.Size(170, 20);
            this.txbItem.TabIndex = 1;
            // 
            // ntbQty
            // 
            this.ntbQty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ntbQty.DisplayFormat = null;
            this.ntbQty.Location = new System.Drawing.Point(331, 0);
            this.ntbQty.Name = "ntbQty";
            this.ntbQty.Size = new System.Drawing.Size(60, 20);
            this.ntbQty.TabIndex = 5;
            this.ntbQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntbQty.Value = 0D;
            this.ntbQty.ValueFormat = "5.3";
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.lblItem.Location = new System.Drawing.Point(3, 3);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(30, 13);
            this.lblItem.TabIndex = 0;
            this.lblItem.Text = "Item:";
            // 
            // lblQuantity
            // 
            this.lblQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(307, 3);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(26, 13);
            this.lblQuantity.TabIndex = 4;
            this.lblQuantity.Text = "Qty:";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(392, -1);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(34, 22);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // ntbPrice
            // 
            this.ntbPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ntbPrice.DisplayFormat = "##,##,###.##";
            this.ntbPrice.Location = new System.Drawing.Point(236, 0);
            this.ntbPrice.Name = "ntbPrice";
            this.ntbPrice.Size = new System.Drawing.Size(69, 20);
            this.ntbPrice.TabIndex = 3;
            this.ntbPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntbPrice.Value = 0D;
            this.ntbPrice.ValueFormat = "7.2";
            // 
            // lblPrice
            // 
            this.lblPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(204, 3);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(34, 13);
            this.lblPrice.TabIndex = 2;
            this.lblPrice.Text = "Price:";
            // 
            // ULineItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.lblItem);
            this.Controls.Add(this.ntbPrice);
            this.Controls.Add(this.ntbQty);
            this.Controls.Add(this.txbItem);
            this.MaximumSize = new System.Drawing.Size(640, 20);
            this.MinimumSize = new System.Drawing.Size(426, 20);
            this.Name = "ULineItem";
            this.Size = new System.Drawing.Size(426, 20);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Scalable.Win.Controls.iTextBoxButton txbItem;
        private Scalable.Win.Controls.iNumberTextBox ntbQty;
        private Scalable.Win.Controls.iLabel lblItem;
        private Scalable.Win.Controls.iLabel lblQuantity;
        private Scalable.Win.Controls.iButton btnAdd;
        private Scalable.Win.Controls.iNumberTextBox ntbPrice;
        private Scalable.Win.Controls.iLabel lblPrice;
    }
}
