namespace Insight.UC.Controls
{
    partial class UChartOfAccount
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
            this.lblParentCoa = new Scalable.Win.Controls.iLabel();
            this.lblName = new Scalable.Win.Controls.iLabel();
            this.txbParentCoa = new Scalable.Win.Controls.iTextBoxButton();
            this.txtName = new Scalable.Win.Controls.iTextBox();
            this.btnSave = new Scalable.Win.Controls.iCommandButton();
            this.cmbCoaType = new Scalable.Win.Controls.iComboBox();
            this.lblType = new Scalable.Win.Controls.iLabel();
            this.CommandBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // CommandBar
            // 
            this.CommandBar.Controls.Add(this.btnSave);
            this.CommandBar.Location = new System.Drawing.Point(-1, 71);
            this.CommandBar.Size = new System.Drawing.Size(318, 36);
            this.CommandBar.TabIndex = 6;
            // 
            // lblParentCoa
            // 
            this.lblParentCoa.AutoSize = true;
            this.lblParentCoa.Location = new System.Drawing.Point(1, 51);
            this.lblParentCoa.Name = "lblParentCoa";
            this.lblParentCoa.Size = new System.Drawing.Size(41, 13);
            this.lblParentCoa.TabIndex = 4;
            this.lblParentCoa.Text = "&Parent:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(1, 5);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "&Name:";
            // 
            // txbParentCoa
            // 
            this.txbParentCoa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbParentCoa.Location = new System.Drawing.Point(42, 47);
            this.txbParentCoa.Name = "txbParentCoa";
            this.txbParentCoa.SearchProperty = "Name";
            this.txbParentCoa.Size = new System.Drawing.Size(271, 20);
            this.txbParentCoa.TabIndex = 5;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(42, 2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(271, 20);
            this.txtName.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Action = Scalable.Win.Enums.CommandBarAction.Save;
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSave.Location = new System.Drawing.Point(121, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmbCoaType
            // 
            this.cmbCoaType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCoaType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCoaType.FormattingEnabled = true;
            this.cmbCoaType.Location = new System.Drawing.Point(42, 24);
            this.cmbCoaType.Name = "cmbCoaType";
            this.cmbCoaType.Size = new System.Drawing.Size(271, 21);
            this.cmbCoaType.TabIndex = 3;
            this.cmbCoaType.Leave += new System.EventHandler(this.cmbCoaType_Leave);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(1, 27);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(34, 13);
            this.lblType.TabIndex = 2;
            this.lblType.Text = "&Type:";
            // 
            // UChartOfAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.cmbCoaType);
            this.Controls.Add(this.txbParentCoa);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblParentCoa);
            this.MaximumSize = new System.Drawing.Size(640, 105);
            this.MinimumSize = new System.Drawing.Size(300, 105);
            this.Name = "UChartOfAccount";
            this.Size = new System.Drawing.Size(316, 105);
            this.Controls.SetChildIndex(this.lblParentCoa, 0);
            this.Controls.SetChildIndex(this.lblType, 0);
            this.Controls.SetChildIndex(this.lblName, 0);
            this.Controls.SetChildIndex(this.txbParentCoa, 0);
            this.Controls.SetChildIndex(this.cmbCoaType, 0);
            this.Controls.SetChildIndex(this.txtName, 0);
            this.Controls.SetChildIndex(this.CommandBar, 0);
            this.CommandBar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Scalable.Win.Controls.iLabel lblParentCoa;
        private Scalable.Win.Controls.iCommandButton btnSave;
        private Scalable.Win.Controls.iLabel lblName;
        private Scalable.Win.Controls.iTextBoxButton txbParentCoa;
        private Scalable.Win.Controls.iTextBox txtName;
        private Scalable.Win.Controls.iComboBox cmbCoaType;
        private Scalable.Win.Controls.iLabel lblType;
    }
}
