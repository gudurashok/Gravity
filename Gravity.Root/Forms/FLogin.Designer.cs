using Gravity.Root.Controls;

namespace Gravity.Root.Forms
{
    partial class FLogin
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lnkChangePassword = new Scalable.Win.Controls.iLinkLabel();
            this.uLogin = new Gravity.Root.Controls.ULogin();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Size = new System.Drawing.Size(272, 43);
            // 
            // picLogo
            // 
            this.picLogo.Location = new System.Drawing.Point(229, 2);
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(220, 39);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Enter your login credentials";
            // 
            // lnkChangePassword
            // 
            this.lnkChangePassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkChangePassword.AutoSize = true;
            this.lnkChangePassword.Location = new System.Drawing.Point(180, 44);
            this.lnkChangePassword.Name = "lnkChangePassword";
            this.lnkChangePassword.Size = new System.Drawing.Size(92, 13);
            this.lnkChangePassword.TabIndex = 13;
            this.lnkChangePassword.TabStop = true;
            this.lnkChangePassword.Text = "Change password";
            this.lnkChangePassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkChangePassword_LinkClicked);
            // 
            // uLogin
            // 
            this.uLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uLogin.Location = new System.Drawing.Point(0, 71);
            this.uLogin.Name = "uLogin";
            this.uLogin.Size = new System.Drawing.Size(272, 256);
            this.uLogin.TabIndex = 1;
            this.uLogin.Login += new System.EventHandler<Gravity.Root.Events.LoginEventArgs>(this.uLogin_Login);
            // 
            // FLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(272, 326);
            this.Controls.Add(this.lnkChangePassword);
            this.Controls.Add(this.uLogin);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(245, 360);
            this.Name = "FLogin";
            this.ShowInTaskbar = true;
            this.Text = "Gravity Login";
            this.TopMost = true;
            this.Controls.SetChildIndex(this.pnlHeader, 0);
            this.Controls.SetChildIndex(this.uLogin, 0);
            this.Controls.SetChildIndex(this.lnkChangePassword, 0);
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ULogin uLogin;
        private Scalable.Win.Controls.iLinkLabel lnkChangePassword;
    }
}

