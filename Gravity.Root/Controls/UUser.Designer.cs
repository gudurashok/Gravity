namespace Gravity.Root.Controls
{
    partial class UUser
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
            this.btnOK = new Scalable.Win.Controls.iCommandButton();
            this.lblUserName = new Scalable.Win.Controls.iLabel();
            this.txtUserName = new Scalable.Win.Controls.iTextBox();
            this.chkIsActive = new Scalable.Win.Controls.iCheckBox();
            this.lblParent = new Scalable.Win.Controls.iLabel();
            this.txbParentUser = new Scalable.Win.Controls.iTextBoxButton();
            this.chkIsAdmin = new Scalable.Win.Controls.iCheckBox();
            this.lblOptions = new Scalable.Win.Controls.iLabel();
            this.txtDesignation = new Scalable.Win.Controls.iTextBox();
            this.lblDesignation = new Scalable.Win.Controls.iLabel();
            this.lblMobileNrs = new Scalable.Win.Controls.iLabel();
            this.txtMobileNrs = new Scalable.Win.Controls.iTextBox();
            this.chkShowNotifications = new Scalable.Win.Controls.iCheckBox();
            this.chkAllowAdHocNrs = new Scalable.Win.Controls.iCheckBox();
            this.uCredentials = new Gravity.Root.Controls.UCredentials();
            this.CommandBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // CommandBar
            // 
            this.CommandBar.Controls.Add(this.btnOK);
            this.CommandBar.Location = new System.Drawing.Point(-1, 108);
            this.CommandBar.Size = new System.Drawing.Size(503, 35);
            this.CommandBar.TabIndex = 14;
            // 
            // btnOK
            // 
            this.btnOK.Action = Scalable.Win.Enums.CommandBarAction.Save;
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOK.Location = new System.Drawing.Point(213, 5);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "&Save";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(2, 4);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(61, 13);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "&User name:";
            // 
            // txtUserName
            // 
            this.txtUserName.AutoCasing = Scalable.Shared.Enums.TextCaseStyle.Proper;
            this.txtUserName.Location = new System.Drawing.Point(71, 2);
            this.txtUserName.MaxLength = 50;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(141, 20);
            this.txtUserName.TabIndex = 1;
            this.txtUserName.Tag = "Name";
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Checked = true;
            this.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsActive.Location = new System.Drawing.Point(144, 89);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(67, 17);
            this.chkIsActive.TabIndex = 11;
            this.chkIsActive.Tag = "IsActive";
            this.chkIsActive.Text = "Is Active";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // lblParent
            // 
            this.lblParent.AutoSize = true;
            this.lblParent.Location = new System.Drawing.Point(223, 71);
            this.lblParent.Name = "lblParent";
            this.lblParent.Size = new System.Drawing.Size(44, 13);
            this.lblParent.TabIndex = 7;
            this.lblParent.Text = "&Parent: ";
            // 
            // txbParentUser
            // 
            this.txbParentUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbParentUser.Location = new System.Drawing.Point(265, 68);
            this.txbParentUser.Name = "txbParentUser";
            this.txbParentUser.SearchProperty = "Name";
            this.txbParentUser.Size = new System.Drawing.Size(232, 20);
            this.txbParentUser.TabIndex = 8;
            // 
            // chkIsAdmin
            // 
            this.chkIsAdmin.AutoSize = true;
            this.chkIsAdmin.Location = new System.Drawing.Point(72, 89);
            this.chkIsAdmin.Name = "chkIsAdmin";
            this.chkIsAdmin.Size = new System.Drawing.Size(66, 17);
            this.chkIsAdmin.TabIndex = 10;
            this.chkIsAdmin.Tag = "IsAdmin";
            this.chkIsAdmin.Text = "Is Admin";
            this.chkIsAdmin.UseVisualStyleBackColor = true;
            this.chkIsAdmin.CheckedChanged += new System.EventHandler(this.chkIsAdmin_CheckedChanged);
            // 
            // lblOptions
            // 
            this.lblOptions.AutoSize = true;
            this.lblOptions.Location = new System.Drawing.Point(3, 91);
            this.lblOptions.Name = "lblOptions";
            this.lblOptions.Size = new System.Drawing.Size(49, 13);
            this.lblOptions.TabIndex = 9;
            this.lblOptions.Text = "&Options: ";
            // 
            // txtDesignation
            // 
            this.txtDesignation.AutoCasing = Scalable.Shared.Enums.TextCaseStyle.Proper;
            this.txtDesignation.Location = new System.Drawing.Point(71, 68);
            this.txtDesignation.MaxLength = 50;
            this.txtDesignation.Name = "txtDesignation";
            this.txtDesignation.Size = new System.Drawing.Size(141, 20);
            this.txtDesignation.TabIndex = 6;
            this.txtDesignation.Tag = "Name";
            // 
            // lblDesignation
            // 
            this.lblDesignation.AutoSize = true;
            this.lblDesignation.Location = new System.Drawing.Point(3, 71);
            this.lblDesignation.Name = "lblDesignation";
            this.lblDesignation.Size = new System.Drawing.Size(66, 13);
            this.lblDesignation.TabIndex = 5;
            this.lblDesignation.Text = "&Designation:";
            // 
            // lblMobileNrs
            // 
            this.lblMobileNrs.AutoSize = true;
            this.lblMobileNrs.Location = new System.Drawing.Point(212, 5);
            this.lblMobileNrs.Name = "lblMobileNrs";
            this.lblMobileNrs.Size = new System.Drawing.Size(55, 13);
            this.lblMobileNrs.TabIndex = 2;
            this.lblMobileNrs.Text = "&Mobile(s): ";
            // 
            // txtMobileNrs
            // 
            this.txtMobileNrs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMobileNrs.AutoCasing = Scalable.Shared.Enums.TextCaseStyle.Proper;
            this.txtMobileNrs.InputFilterExpr = "[0-9]|[+]|[,]";
            this.txtMobileNrs.Location = new System.Drawing.Point(265, 2);
            this.txtMobileNrs.MaxLength = 50;
            this.txtMobileNrs.Name = "txtMobileNrs";
            this.txtMobileNrs.Size = new System.Drawing.Size(232, 20);
            this.txtMobileNrs.TabIndex = 3;
            this.txtMobileNrs.Tag = "Name";
            // 
            // chkShowNotifications
            // 
            this.chkShowNotifications.AutoSize = true;
            this.chkShowNotifications.Checked = true;
            this.chkShowNotifications.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowNotifications.Location = new System.Drawing.Point(217, 89);
            this.chkShowNotifications.Name = "chkShowNotifications";
            this.chkShowNotifications.Size = new System.Drawing.Size(114, 17);
            this.chkShowNotifications.TabIndex = 12;
            this.chkShowNotifications.Tag = "ShowNotifications";
            this.chkShowNotifications.Text = "Show Notifications";
            this.chkShowNotifications.UseVisualStyleBackColor = true;
            // 
            // chkAllowAdHocNrs
            // 
            this.chkAllowAdHocNrs.AutoSize = true;
            this.chkAllowAdHocNrs.Location = new System.Drawing.Point(331, 89);
            this.chkAllowAdHocNrs.Name = "chkAllowAdHocNrs";
            this.chkAllowAdHocNrs.Size = new System.Drawing.Size(171, 17);
            this.chkAllowAdHocNrs.TabIndex = 13;
            this.chkAllowAdHocNrs.Tag = "AllowAdHocNrs";
            this.chkAllowAdHocNrs.Text = "Allow non-user mobile numbers";
            this.chkAllowAdHocNrs.UseVisualStyleBackColor = true;
            // 
            // uCredentials
            // 
            this.uCredentials.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uCredentials.Location = new System.Drawing.Point(2, 24);
            this.uCredentials.Name = "uCredentials";
            this.uCredentials.Size = new System.Drawing.Size(497, 42);
            this.uCredentials.TabIndex = 4;
            this.uCredentials.Tag = "Credentials";
            // 
            // UUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.txtMobileNrs);
            this.Controls.Add(this.lblMobileNrs);
            this.Controls.Add(this.txbParentUser);
            this.Controls.Add(this.lblOptions);
            this.Controls.Add(this.lblParent);
            this.Controls.Add(this.uCredentials);
            this.Controls.Add(this.chkAllowAdHocNrs);
            this.Controls.Add(this.chkShowNotifications);
            this.Controls.Add(this.chkIsAdmin);
            this.Controls.Add(this.lblDesignation);
            this.Controls.Add(this.txtDesignation);
            this.Controls.Add(this.chkIsActive);
            this.MaximumSize = new System.Drawing.Size(1500, 141);
            this.MinimumSize = new System.Drawing.Size(361, 141);
            this.Name = "UUser";
            this.Size = new System.Drawing.Size(500, 141);
            this.Controls.SetChildIndex(this.chkIsActive, 0);
            this.Controls.SetChildIndex(this.txtDesignation, 0);
            this.Controls.SetChildIndex(this.lblDesignation, 0);
            this.Controls.SetChildIndex(this.CommandBar, 0);
            this.Controls.SetChildIndex(this.chkIsAdmin, 0);
            this.Controls.SetChildIndex(this.chkShowNotifications, 0);
            this.Controls.SetChildIndex(this.chkAllowAdHocNrs, 0);
            this.Controls.SetChildIndex(this.uCredentials, 0);
            this.Controls.SetChildIndex(this.lblParent, 0);
            this.Controls.SetChildIndex(this.lblOptions, 0);
            this.Controls.SetChildIndex(this.txbParentUser, 0);
            this.Controls.SetChildIndex(this.lblMobileNrs, 0);
            this.Controls.SetChildIndex(this.txtMobileNrs, 0);
            this.Controls.SetChildIndex(this.lblUserName, 0);
            this.Controls.SetChildIndex(this.txtUserName, 0);
            this.CommandBar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Scalable.Win.Controls.iCommandButton btnOK;
        private Scalable.Win.Controls.iLabel lblUserName;
        private Scalable.Win.Controls.iTextBox txtUserName;
        private Scalable.Win.Controls.iCheckBox chkIsActive;
        private UCredentials uCredentials;
        private Scalable.Win.Controls.iLabel lblParent;
        private Scalable.Win.Controls.iTextBoxButton txbParentUser;
        private Scalable.Win.Controls.iCheckBox chkIsAdmin;
        private Scalable.Win.Controls.iLabel lblOptions;
        private Scalable.Win.Controls.iTextBox txtDesignation;
        private Scalable.Win.Controls.iLabel lblDesignation;
        private Scalable.Win.Controls.iLabel lblMobileNrs;
        private Scalable.Win.Controls.iTextBox txtMobileNrs;
        private Scalable.Win.Controls.iCheckBox chkShowNotifications;
        private Scalable.Win.Controls.iCheckBox chkAllowAdHocNrs;
    }
}
