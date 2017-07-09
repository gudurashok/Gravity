namespace Insight.UC.Controls
{
    partial class UAccount
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
            this.lblName = new Scalable.Win.Controls.iLabel();
            this.lblParty = new Scalable.Win.Controls.iLabel();
            this.lblChartOfAccount = new Scalable.Win.Controls.iLabel();
            this.txtName = new Scalable.Win.Controls.iTextBox();
            this.txbParty = new Scalable.Win.Controls.iTextBoxButton();
            this.txbChartOfAccount = new Scalable.Win.Controls.iTextBoxButton();
            this.btnSave = new Scalable.Win.Controls.iCommandButton();
            this.lblGroup = new Scalable.Win.Controls.iLabel();
            this.txbGroup = new Scalable.Win.Controls.iTextBoxButton();
            this.ntbOpeningBalance = new Scalable.Win.Controls.iNumberTextBox();
            this.lblOpeningBalance = new Scalable.Win.Controls.iLabel();
            this.CommandBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // CommandBar
            // 
            this.CommandBar.Controls.Add(this.btnSave);
            this.CommandBar.Location = new System.Drawing.Point(-1, 122);
            this.CommandBar.Size = new System.Drawing.Size(304, 35);
            this.CommandBar.TabIndex = 10;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(0, 7);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(41, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "&Name: ";
            // 
            // lblParty
            // 
            this.lblParty.AutoSize = true;
            this.lblParty.Location = new System.Drawing.Point(0, 29);
            this.lblParty.Name = "lblParty";
            this.lblParty.Size = new System.Drawing.Size(37, 13);
            this.lblParty.TabIndex = 2;
            this.lblParty.Text = "&Party: ";
            // 
            // lblChartOfAccount
            // 
            this.lblChartOfAccount.AutoSize = true;
            this.lblChartOfAccount.Location = new System.Drawing.Point(0, 52);
            this.lblChartOfAccount.Name = "lblChartOfAccount";
            this.lblChartOfAccount.Size = new System.Drawing.Size(95, 13);
            this.lblChartOfAccount.TabIndex = 4;
            this.lblChartOfAccount.Text = "&Chart Of Account: ";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(92, 3);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(208, 20);
            this.txtName.TabIndex = 1;
            // 
            // txbParty
            // 
            this.txbParty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbParty.Location = new System.Drawing.Point(92, 26);
            this.txbParty.Name = "txbParty";
            this.txbParty.SearchProperty = "Name";
            this.txbParty.Size = new System.Drawing.Size(208, 20);
            this.txbParty.TabIndex = 3;
            // 
            // txbChartOfAccount
            // 
            this.txbChartOfAccount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbChartOfAccount.Location = new System.Drawing.Point(92, 49);
            this.txbChartOfAccount.Name = "txbChartOfAccount";
            this.txbChartOfAccount.SearchProperty = "Name";
            this.txbChartOfAccount.Size = new System.Drawing.Size(208, 20);
            this.txbChartOfAccount.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSave.Location = new System.Drawing.Point(114, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.Location = new System.Drawing.Point(0, 75);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(42, 13);
            this.lblGroup.TabIndex = 6;
            this.lblGroup.Text = "&Group: ";
            // 
            // txbGroup
            // 
            this.txbGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbGroup.Location = new System.Drawing.Point(92, 72);
            this.txbGroup.Name = "txbGroup";
            this.txbGroup.SearchProperty = "Name";
            this.txbGroup.Size = new System.Drawing.Size(208, 20);
            this.txbGroup.TabIndex = 7;
            // 
            // lblOpeningBalance
            // 
            this.lblOpeningBalance.AutoSize = true;
            this.lblOpeningBalance.Location = new System.Drawing.Point(0, 97);
            this.lblOpeningBalance.Name = "lblOpeningBalance";
            this.lblOpeningBalance.Size = new System.Drawing.Size(121, 17);
            this.lblOpeningBalance.TabIndex = 8;
            this.lblOpeningBalance.Text = "&Opening Balance:";
            // 
            // ntbOpeningBalance
            // 
            this.ntbOpeningBalance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ntbOpeningBalance.DisplayFormat = "##,##,##,###.##";
            this.ntbOpeningBalance.Location = new System.Drawing.Point(92, 95);
            this.ntbOpeningBalance.Name = "ntbOpeningBalance";
            this.ntbOpeningBalance.Size = new System.Drawing.Size(177, 22);
            this.ntbOpeningBalance.TabIndex = 9;
            this.ntbOpeningBalance.Text = "0.00";
            this.ntbOpeningBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntbOpeningBalance.Value = 0D;
            this.ntbOpeningBalance.ValueFormat = "9.2";
            // 
            // UAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ntbOpeningBalance);
            this.Controls.Add(this.lblOpeningBalance);
            this.Controls.Add(this.txbGroup);
            this.Controls.Add(this.txbChartOfAccount);
            this.Controls.Add(this.txbParty);
            this.Controls.Add(this.lblGroup);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblChartOfAccount);
            this.Controls.Add(this.lblParty);
            this.Controls.Add(this.lblName);
            this.MaximumSize = new System.Drawing.Size(640, 156);
            this.MinimumSize = new System.Drawing.Size(300, 156);
            this.Name = "UAccount";
            this.Size = new System.Drawing.Size(302, 156);
            this.Controls.SetChildIndex(this.CommandBar, 0);
            this.Controls.SetChildIndex(this.lblName, 0);
            this.Controls.SetChildIndex(this.lblParty, 0);
            this.Controls.SetChildIndex(this.lblChartOfAccount, 0);
            this.Controls.SetChildIndex(this.txtName, 0);
            this.Controls.SetChildIndex(this.lblGroup, 0);
            this.Controls.SetChildIndex(this.txbParty, 0);
            this.Controls.SetChildIndex(this.txbChartOfAccount, 0);
            this.Controls.SetChildIndex(this.txbGroup, 0);
            this.Controls.SetChildIndex(this.lblOpeningBalance, 0);
            this.Controls.SetChildIndex(this.ntbOpeningBalance, 0);
            this.CommandBar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Scalable.Win.Controls.iLabel lblName;
        private Scalable.Win.Controls.iLabel lblParty;
        private Scalable.Win.Controls.iLabel lblChartOfAccount;
        private Scalable.Win.Controls.iTextBox txtName;
        private Scalable.Win.Controls.iTextBoxButton txbParty;
        private Scalable.Win.Controls.iTextBoxButton txbChartOfAccount;
        private Scalable.Win.Controls.iCommandButton btnSave;
        private Scalable.Win.Controls.iLabel lblGroup;
        private Scalable.Win.Controls.iTextBoxButton txbGroup;
        protected Scalable.Win.Controls.iNumberTextBox ntbOpeningBalance;
        protected Scalable.Win.Controls.iLabel lblOpeningBalance;
    }
}
