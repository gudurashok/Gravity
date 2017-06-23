namespace Insight.UC.Controls
{
    partial class UDaybook
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
            this.lblType = new Scalable.Win.Controls.iLabel();
            this.lblName = new Scalable.Win.Controls.iLabel();
            this.txtName = new Scalable.Win.Controls.iTextBox();
            this.lblAccount = new Scalable.Win.Controls.iLabel();
            this.txbAccount = new Scalable.Win.Controls.iTextBoxButton();
            this.btnSave = new Scalable.Win.Controls.iCommandButton();
            this.cmbDaybookType = new Scalable.Win.Controls.iComboBox();
            this.CommandBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // CommandBar
            // 
            this.CommandBar.Controls.Add(this.btnSave);
            this.CommandBar.Location = new System.Drawing.Point(-1, 71);
            this.CommandBar.Size = new System.Drawing.Size(252, 35);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(3, 28);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(37, 13);
            this.lblType.TabIndex = 16;
            this.lblType.Text = "&Type: ";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(3, 2);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(41, 13);
            this.lblName.TabIndex = 18;
            this.lblName.Text = "&Name: ";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(55, 2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(192, 20);
            this.txtName.TabIndex = 20;
            // 
            // lblAccount
            // 
            this.lblAccount.AutoSize = true;
            this.lblAccount.Location = new System.Drawing.Point(3, 51);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(53, 13);
            this.lblAccount.TabIndex = 21;
            this.lblAccount.Text = "&Account: ";
            // 
            // txbAccount
            // 
            this.txbAccount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbAccount.Location = new System.Drawing.Point(55, 47);
            this.txbAccount.Name = "txbAccount";
            this.txbAccount.SearchProperty = "Name";
            this.txbAccount.Size = new System.Drawing.Size(192, 20);
            this.txbAccount.TabIndex = 24;
            // 
            // btnSave
            // 
            this.btnSave.Action = Scalable.Win.Enums.CommandBarAction.Save;
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSave.Location = new System.Drawing.Point(88, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmbDaybookType
            // 
            this.cmbDaybookType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDaybookType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDaybookType.FormattingEnabled = true;
            this.cmbDaybookType.Location = new System.Drawing.Point(55, 24);
            this.cmbDaybookType.Name = "cmbDaybookType";
            this.cmbDaybookType.Size = new System.Drawing.Size(192, 21);
            this.cmbDaybookType.TabIndex = 25;
            // 
            // UDaybook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbDaybookType);
            this.Controls.Add(this.txbAccount);
            this.Controls.Add(this.lblAccount);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.txtName);
            this.MaximumSize = new System.Drawing.Size(640, 105);
            this.MinimumSize = new System.Drawing.Size(250, 105);
            this.Name = "UDaybook";
            this.Size = new System.Drawing.Size(250, 105);
            this.Controls.SetChildIndex(this.txtName, 0);
            this.Controls.SetChildIndex(this.CommandBar, 0);
            this.Controls.SetChildIndex(this.lblType, 0);
            this.Controls.SetChildIndex(this.lblName, 0);
            this.Controls.SetChildIndex(this.lblAccount, 0);
            this.Controls.SetChildIndex(this.txbAccount, 0);
            this.Controls.SetChildIndex(this.cmbDaybookType, 0);
            this.CommandBar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Scalable.Win.Controls.iLabel lblType;
        private Scalable.Win.Controls.iLabel lblName;
        private Scalable.Win.Controls.iTextBox txtName;
        private Scalable.Win.Controls.iLabel lblAccount;
        private Scalable.Win.Controls.iTextBoxButton txbAccount;
        private Scalable.Win.Controls.iCommandButton btnSave;
        private Scalable.Win.Controls.iComboBox cmbDaybookType;
    }
}
