namespace Synergy.UC.Controls
{
    partial class UChecklist
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
            this.lblItems = new Scalable.Win.Controls.iLabel();
            this.pnlLine = new Scalable.Win.Controls.iPanel();
            this.uChecklistItem = new Synergy.UC.Controls.UChecklistItem();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(159, 42);
            // 
            // lvwItems
            // 
            this.lvwItems.Size = new System.Drawing.Size(155, 96);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(159, 92);
            // 
            // chkIsActive
            // 
            this.chkIsActive.Location = new System.Drawing.Point(162, 1);
            // 
            // txtName
            // 
            this.txtName.Size = new System.Drawing.Size(155, 20);
            // 
            // btnPreferred
            // 
            this.btnPreferred.Location = new System.Drawing.Point(159, 67);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(159, 18);
            // 
            // btnDescription
            // 
            this.btnDescription.Location = new System.Drawing.Point(159, 117);
            this.btnDescription.TabIndex = 7;
            // 
            // lblItems
            // 
            this.lblItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblItems.AutoSize = true;
            this.lblItems.Location = new System.Drawing.Point(-1, 145);
            this.lblItems.Name = "lblItems";
            this.lblItems.Size = new System.Drawing.Size(32, 13);
            this.lblItems.TabIndex = 9;
            this.lblItems.Text = "&Items";
            // 
            // pnlLine
            // 
            this.pnlLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLine.Location = new System.Drawing.Point(34, 152);
            this.pnlLine.Name = "pnlLine";
            this.pnlLine.Size = new System.Drawing.Size(201, 1);
            this.pnlLine.TabIndex = 10;
            // 
            // uChecklistItem
            // 
            this.uChecklistItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uChecklistItem.Location = new System.Drawing.Point(1, 163);
            this.uChecklistItem.Name = "uChecklistItem";
            this.uChecklistItem.Size = new System.Drawing.Size(233, 143);
            this.uChecklistItem.TabIndex = 11;
            // 
            // UChecklist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblItems);
            this.Controls.Add(this.pnlLine);
            this.Controls.Add(this.uChecklistItem);
            this.Name = "UChecklist";
            this.Size = new System.Drawing.Size(235, 306);
            this.Controls.SetChildIndex(this.btnAdd, 0);
            this.Controls.SetChildIndex(this.txtName, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.btnUpdate, 0);
            this.Controls.SetChildIndex(this.btnPreferred, 0);
            this.Controls.SetChildIndex(this.chkIsActive, 0);
            this.Controls.SetChildIndex(this.lvwItems, 0);
            this.Controls.SetChildIndex(this.btnDescription, 0);
            this.Controls.SetChildIndex(this.uChecklistItem, 0);
            this.Controls.SetChildIndex(this.pnlLine, 0);
            this.Controls.SetChildIndex(this.lblItems, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Scalable.Win.Controls.iLabel lblItems;
        private Scalable.Win.Controls.iPanel pnlLine;
        private UChecklistItem uChecklistItem;
    }
}
