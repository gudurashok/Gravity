namespace Synergy.UC.Forms
{
    partial class FReminders
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
            this.uReminders = new Synergy.UC.Controls.UReminders();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Size = new System.Drawing.Size(438, 43);
            // 
            // picLogo
            // 
            this.picLogo.Location = new System.Drawing.Point(395, 2);
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(386, 39);
            // 
            // uReminders
            // 
            this.uReminders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uReminders.Location = new System.Drawing.Point(0, 44);
            this.uReminders.MaximumSize = new System.Drawing.Size(840, 640);
            this.uReminders.MinimumSize = new System.Drawing.Size(387, 153);
            this.uReminders.Name = "uReminders";
            this.uReminders.Size = new System.Drawing.Size(439, 282);
            this.uReminders.TabIndex = 13;
            // 
            // FReminders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 326);
            this.Controls.Add(this.uReminders);
            this.MinimumSize = new System.Drawing.Size(404, 235);
            this.Name = "FReminders";
            this.Text = "FReminders";
            this.Activated += new System.EventHandler(this.FReminders_Activated);
            this.Controls.SetChildIndex(this.uReminders, 0);
            this.Controls.SetChildIndex(this.pnlHeader, 0);
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.UReminders uReminders;


    }
}