namespace Synergy.UC.Forms
{
    partial class FReminderPopup
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
            this.uReminderPopUp = new Synergy.UC.Controls.UReminderPopup();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.Teal;
            this.pnlHeader.Size = new System.Drawing.Size(393, 43);
            // 
            // picLogo
            // 
            this.picLogo.Location = new System.Drawing.Point(350, 2);
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(341, 39);
            // 
            // uReminderPopUp
            // 
            this.uReminderPopUp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uReminderPopUp.Location = new System.Drawing.Point(0, 45);
            this.uReminderPopUp.MinimumSize = new System.Drawing.Size(385, 200);
            this.uReminderPopUp.Name = "uReminderPopUp";
            this.uReminderPopUp.Size = new System.Drawing.Size(393, 214);
            this.uReminderPopUp.TabIndex = 13;
            // 
            // FReminderPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 259);
            this.Controls.Add(this.uReminderPopUp);
            this.MinimumSize = new System.Drawing.Size(401, 293);
            this.Name = "FReminderPopup";
            this.Text = "FReminderPopUp";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FReminder_FormClosing);
            this.Controls.SetChildIndex(this.uReminderPopUp, 0);
            this.Controls.SetChildIndex(this.pnlHeader, 0);
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.UReminderPopup uReminderPopUp;
    }
}