namespace Insight.UC.Controls
{
    partial class UBillTerms
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
            this.btnCancel = new Scalable.Win.Controls.iCommandButton();
            this.btnDelete = new Scalable.Win.Controls.iCommandButton();
            this.btnNew = new Scalable.Win.Controls.iCommandButton();
            this.uBillTerm = new Insight.UC.Controls.UBillTerm();
            this.CommandBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(5, 32);
            this.btnOK.TabIndex = 1;
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpen.Location = new System.Drawing.Point(5, 113);
            this.btnOpen.TabIndex = 4;
            this.btnOpen.Text = "&Edit";
            this.btnOpen.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // txt
            // 
            this.txt.Location = new System.Drawing.Point(2, 2);
            this.txt.Size = new System.Drawing.Size(267, 20);
            // 
            // lvw
            // 
            this.lvw.Size = new System.Drawing.Size(267, 121);
            this.lvw.TabIndex = 2;
            this.lvw.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvw_ItemSelectionChanged);
            // 
            // CommandBar
            // 
            this.CommandBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CommandBar.Controls.Add(this.btnCancel);
            this.CommandBar.Controls.Add(this.btnDelete);
            this.CommandBar.Controls.Add(this.btnNew);
            this.CommandBar.Location = new System.Drawing.Point(271, 2);
            this.CommandBar.Size = new System.Drawing.Size(87, 143);
            this.CommandBar.TabIndex = 1;
            this.CommandBar.Controls.SetChildIndex(this.btnOK, 0);
            this.CommandBar.Controls.SetChildIndex(this.btnOpen, 0);
            this.CommandBar.Controls.SetChildIndex(this.btnNew, 0);
            this.CommandBar.Controls.SetChildIndex(this.btnDelete, 0);
            this.CommandBar.Controls.SetChildIndex(this.btnCancel, 0);
            // 
            // btnCancel
            // 
            this.btnCancel.Action = Scalable.Win.Enums.CommandBarAction.Cancel;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(5, 86);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Action = Scalable.Win.Enums.CommandBarAction.Delete;
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(5, 59);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.Location = new System.Drawing.Point(5, 5);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "&New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // uBillTerm
            // 
            this.uBillTerm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uBillTerm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uBillTerm.Enabled = false;
            this.uBillTerm.Location = new System.Drawing.Point(2, 147);
            this.uBillTerm.MaximumSize = new System.Drawing.Size(640, 126);
            this.uBillTerm.MinimumSize = new System.Drawing.Size(346, 126);
            this.uBillTerm.Name = "uBillTerm";
            this.uBillTerm.Size = new System.Drawing.Size(356, 126);
            this.uBillTerm.TabIndex = 3;
            // 
            // UBillTerms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uBillTerm);
            this.MinimumSize = new System.Drawing.Size(360, 275);
            this.Name = "UBillTerms";
            this.Size = new System.Drawing.Size(360, 275);
            this.Controls.SetChildIndex(this.lvw, 0);
            this.Controls.SetChildIndex(this.CommandBar, 0);
            this.Controls.SetChildIndex(this.txt, 0);
            this.Controls.SetChildIndex(this.uBillTerm, 0);
            this.CommandBar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Scalable.Win.Controls.iCommandButton btnCancel;
        private Scalable.Win.Controls.iCommandButton btnDelete;
        private Scalable.Win.Controls.iCommandButton btnNew;
        private UBillTerm uBillTerm;
    }
}
