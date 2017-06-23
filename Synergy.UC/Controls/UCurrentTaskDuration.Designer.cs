namespace Synergy.UC.Controls
{
    partial class UCurrentTaskDuration
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
            this.lblMessage = new Scalable.Win.Controls.iLabel();
            this.dtpDuration = new Scalable.Win.Controls.iDateTimePicker();
            this.lblDuration = new Scalable.Win.Controls.iLabel();
            this.btnOK = new Scalable.Win.Controls.iCommandButton();
            this.CommandBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // CommandBar
            // 
            this.CommandBar.Controls.Add(this.btnOK);
            this.CommandBar.Location = new System.Drawing.Point(-1, 169);
            this.CommandBar.Size = new System.Drawing.Size(262, 35);
            // 
            // lblMessage
            // 
            this.lblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMessage.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMessage.Location = new System.Drawing.Point(5, 8);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(250, 134);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "Message to be displayed";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpDuration
            // 
            this.dtpDuration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtpDuration.Checked = false;
            this.dtpDuration.CustomFormat = "HH:mm";
            this.dtpDuration.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDuration.Location = new System.Drawing.Point(162, 147);
            this.dtpDuration.Name = "dtpDuration";
            this.dtpDuration.ShowUpDown = true;
            this.dtpDuration.Size = new System.Drawing.Size(51, 20);
            this.dtpDuration.TabIndex = 1;
            this.dtpDuration.Value = new System.DateTime(2012, 11, 5, 0, 0, 0, 0);
            // 
            // lblDuration
            // 
            this.lblDuration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(2, 150);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(156, 13);
            this.lblDuration.TabIndex = 2;
            this.lblDuration.Text = "Enter duration (hours : minutes):";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOK.Location = new System.Drawing.Point(93, 5);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // UCurrentTaskDuration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.dtpDuration);
            this.Controls.Add(this.lblMessage);
            this.Name = "UCurrentTaskDuration";
            this.Size = new System.Drawing.Size(260, 203);
            this.Controls.SetChildIndex(this.lblMessage, 0);
            this.Controls.SetChildIndex(this.dtpDuration, 0);
            this.Controls.SetChildIndex(this.lblDuration, 0);
            this.Controls.SetChildIndex(this.CommandBar, 0);
            this.CommandBar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Scalable.Win.Controls.iLabel lblMessage;
        private Scalable.Win.Controls.iDateTimePicker dtpDuration;
        private Scalable.Win.Controls.iLabel lblDuration;
        private Scalable.Win.Controls.iCommandButton btnOK;
    }
}
