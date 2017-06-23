namespace Insight.UC.Controls
{
    partial class UCompany
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
            this.lblParty = new Scalable.Win.Controls.iLabel();
            this.lblName = new Scalable.Win.Controls.iLabel();
            this.txbParty = new Scalable.Win.Controls.iTextBoxButton();
            this.txtName = new Scalable.Win.Controls.iTextBox();
            this.btnSave = new Scalable.Win.Controls.iCommandButton();
            this.CommandBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // CommandBar
            // 
            this.CommandBar.Controls.Add(this.btnSave);
            this.CommandBar.Location = new System.Drawing.Point(-1, 47);
            this.CommandBar.Size = new System.Drawing.Size(318, 36);
            // 
            // lblParty
            // 
            this.lblParty.AutoSize = true;
            this.lblParty.Location = new System.Drawing.Point(1, 5);
            this.lblParty.Name = "lblParty";
            this.lblParty.Size = new System.Drawing.Size(34, 13);
            this.lblParty.TabIndex = 16;
            this.lblParty.Text = "&Party:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(1, 27);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 17;
            this.lblName.Text = "&Name:";
            // 
            // txbParty
            // 
            this.txbParty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbParty.Location = new System.Drawing.Point(42, 2);
            this.txbParty.Name = "txbParty";
            this.txbParty.SearchProperty = "Name";
            this.txbParty.Size = new System.Drawing.Size(271, 20);
            this.txbParty.TabIndex = 18;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(42, 24);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(271, 20);
            this.txtName.TabIndex = 19;
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
            // UCompany
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txbParty);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblParty);
            this.MaximumSize = new System.Drawing.Size(840, 81);
            this.MinimumSize = new System.Drawing.Size(300, 81);
            this.Name = "UCompany";
            this.Size = new System.Drawing.Size(316, 81);
            this.Controls.SetChildIndex(this.lblParty, 0);
            this.Controls.SetChildIndex(this.lblName, 0);
            this.Controls.SetChildIndex(this.txbParty, 0);
            this.Controls.SetChildIndex(this.txtName, 0);
            this.Controls.SetChildIndex(this.CommandBar, 0);
            this.CommandBar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Scalable.Win.Controls.iLabel lblParty;
        private Scalable.Win.Controls.iCommandButton btnSave;
        private Scalable.Win.Controls.iLabel lblName;
        private Scalable.Win.Controls.iTextBoxButton txbParty;
        private Scalable.Win.Controls.iTextBox txtName;
    }
}
