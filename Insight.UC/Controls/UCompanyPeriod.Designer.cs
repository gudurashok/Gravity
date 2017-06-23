namespace Insight.UC.Controls
{
    partial class UCompanyPeriod
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
            this.lblCompany = new Scalable.Win.Controls.iLabel();
            this.lblFiscalDatePeriod = new Scalable.Win.Controls.iLabel();
            this.btnSave = new Scalable.Win.Controls.iCommandButton();
            this.txbCompany = new Scalable.Win.Controls.iTextBoxButton();
            this.txbFiscalDatePeriod = new Scalable.Win.Controls.iTextBoxButton();
            this.CommandBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // CommandBar
            // 
            this.CommandBar.Controls.Add(this.btnSave);
            this.CommandBar.Location = new System.Drawing.Point(-1, 48);
            this.CommandBar.Size = new System.Drawing.Size(318, 36);
            this.CommandBar.TabIndex = 4;
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Location = new System.Drawing.Point(1, 5);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(54, 13);
            this.lblCompany.TabIndex = 0;
            this.lblCompany.Text = "&Company:";
            // 
            // lblFiscalDatePeriod
            // 
            this.lblFiscalDatePeriod.AutoSize = true;
            this.lblFiscalDatePeriod.Location = new System.Drawing.Point(1, 26);
            this.lblFiscalDatePeriod.Name = "lblFiscalDatePeriod";
            this.lblFiscalDatePeriod.Size = new System.Drawing.Size(93, 13);
            this.lblFiscalDatePeriod.TabIndex = 2;
            this.lblFiscalDatePeriod.Text = "&Fiscal date period:";
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
            // txbCompany
            // 
            this.txbCompany.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbCompany.Location = new System.Drawing.Point(94, 2);
            this.txbCompany.Name = "txbCompany";
            this.txbCompany.SearchProperty = "Name";
            this.txbCompany.Size = new System.Drawing.Size(219, 20);
            this.txbCompany.TabIndex = 1;
            // 
            // txbFiscalDatePeriod
            // 
            this.txbFiscalDatePeriod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbFiscalDatePeriod.Location = new System.Drawing.Point(94, 24);
            this.txbFiscalDatePeriod.Name = "txbFiscalDatePeriod";
            this.txbFiscalDatePeriod.SearchProperty = "Name";
            this.txbFiscalDatePeriod.Size = new System.Drawing.Size(219, 20);
            this.txbFiscalDatePeriod.TabIndex = 3;
            // 
            // UCompanyPeriod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txbFiscalDatePeriod);
            this.Controls.Add(this.txbCompany);
            this.Controls.Add(this.lblFiscalDatePeriod);
            this.Controls.Add(this.lblCompany);
            this.MaximumSize = new System.Drawing.Size(840, 82);
            this.MinimumSize = new System.Drawing.Size(300, 82);
            this.Name = "UCompanyPeriod";
            this.Size = new System.Drawing.Size(316, 82);
            this.Controls.SetChildIndex(this.lblCompany, 0);
            this.Controls.SetChildIndex(this.lblFiscalDatePeriod, 0);
            this.Controls.SetChildIndex(this.txbCompany, 0);
            this.Controls.SetChildIndex(this.txbFiscalDatePeriod, 0);
            this.Controls.SetChildIndex(this.CommandBar, 0);
            this.CommandBar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Scalable.Win.Controls.iLabel lblCompany;
        private Scalable.Win.Controls.iCommandButton btnSave;
        private Scalable.Win.Controls.iLabel lblFiscalDatePeriod;
        private Scalable.Win.Controls.iTextBoxButton txbCompany;
        private Scalable.Win.Controls.iTextBoxButton txbFiscalDatePeriod;
    }
}
