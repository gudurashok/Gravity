namespace Insight.UC.Controls
{
    partial class UFiscalDatePeriods
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
            this.btnNew = new Scalable.Win.Controls.iCommandButton();
            this.btnPreferred = new Scalable.Win.Controls.iCommandButton();
            this.btnCancel = new Scalable.Win.Controls.iCommandButton();
            this.uFiscalDatePeriod = new Insight.UC.Controls.UFiscalDatePeriod();
            this.btnDelete = new Scalable.Win.Controls.iCommandButton();
            this.CommandBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnOK.Location = new System.Drawing.Point(5, 32);
            this.btnOK.TabIndex = 1;
            // 
            // btnOpen
            // 
            this.btnOpen.Action = Scalable.Win.Enums.CommandBarAction.Edit;
            this.btnOpen.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnOpen.Location = new System.Drawing.Point(5, 59);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "&Edit";
            this.btnOpen.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // txt
            // 
            this.txt.Location = new System.Drawing.Point(2, 2);
            this.txt.Size = new System.Drawing.Size(285, 20);
            // 
            // lvw
            // 
            this.lvw.Size = new System.Drawing.Size(285, 148);
            this.lvw.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvw_ItemSelectionChanged);
            // 
            // CommandBar
            // 
            this.CommandBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CommandBar.Controls.Add(this.btnDelete);
            this.CommandBar.Controls.Add(this.btnCancel);
            this.CommandBar.Controls.Add(this.btnPreferred);
            this.CommandBar.Controls.Add(this.btnNew);
            this.CommandBar.Location = new System.Drawing.Point(289, 2);
            this.CommandBar.Size = new System.Drawing.Size(87, 170);
            this.CommandBar.Controls.SetChildIndex(this.btnOpen, 0);
            this.CommandBar.Controls.SetChildIndex(this.btnOK, 0);
            this.CommandBar.Controls.SetChildIndex(this.btnNew, 0);
            this.CommandBar.Controls.SetChildIndex(this.btnPreferred, 0);
            this.CommandBar.Controls.SetChildIndex(this.btnCancel, 0);
            this.CommandBar.Controls.SetChildIndex(this.btnDelete, 0);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(5, 5);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "&New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnPreferred
            // 
            this.btnPreferred.Location = new System.Drawing.Point(5, 140);
            this.btnPreferred.Name = "btnPreferred";
            this.btnPreferred.Size = new System.Drawing.Size(75, 23);
            this.btnPreferred.TabIndex = 5;
            this.btnPreferred.Text = "&Preferred";
            this.btnPreferred.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Action = Scalable.Win.Enums.CommandBarAction.Cancel;
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(5, 113);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // uFiscalDatePeriod
            // 
            this.uFiscalDatePeriod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uFiscalDatePeriod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uFiscalDatePeriod.Enabled = false;
            this.uFiscalDatePeriod.Location = new System.Drawing.Point(2, 174);
            this.uFiscalDatePeriod.MaximumSize = new System.Drawing.Size(640, 104);
            this.uFiscalDatePeriod.MinimumSize = new System.Drawing.Size(369, 102);
            this.uFiscalDatePeriod.Name = "uFiscalDatePeriod";
            this.uFiscalDatePeriod.Size = new System.Drawing.Size(374, 104);
            this.uFiscalDatePeriod.TabIndex = 3;
            // 
            // btnDelete
            // 
            this.btnDelete.Action = Scalable.Win.Enums.CommandBarAction.Delete;
            this.btnDelete.Location = new System.Drawing.Point(5, 86);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // UFiscalDatePeriods
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uFiscalDatePeriod);
            this.MinimumSize = new System.Drawing.Size(378, 280);
            this.Name = "UFiscalDatePeriods";
            this.Size = new System.Drawing.Size(378, 280);
            this.Controls.SetChildIndex(this.uFiscalDatePeriod, 0);
            this.Controls.SetChildIndex(this.lvw, 0);
            this.Controls.SetChildIndex(this.CommandBar, 0);
            this.Controls.SetChildIndex(this.txt, 0);
            this.CommandBar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Scalable.Win.Controls.iCommandButton btnNew;
        private Scalable.Win.Controls.iCommandButton btnPreferred;
        private Scalable.Win.Controls.iCommandButton btnCancel;
        private UFiscalDatePeriod uFiscalDatePeriod;
        private Scalable.Win.Controls.iCommandButton btnDelete;
    }
}
