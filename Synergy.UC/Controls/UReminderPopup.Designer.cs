namespace Synergy.UC.Controls
{
    partial class UReminderPopup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UReminderPopup));
            this.btnDismiss = new Scalable.Win.Controls.iCommandButton();
            this.btnDismissAll = new Scalable.Win.Controls.iCommandButton();
            this.btnSnooze = new Scalable.Win.Controls.iCommandButton();
            this.cmbSnoozeDuration = new Scalable.Win.Controls.iComboBox();
            this.btnStopSound = new Scalable.Win.Controls.iCommandButton();
            this.CommandBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(314, 5);
            this.btnOK.Size = new System.Drawing.Size(65, 23);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(315, 5);
            this.btnOpen.Size = new System.Drawing.Size(65, 23);
            this.btnOpen.TabIndex = 0;
            // 
            // txt
            // 
            this.txt.Size = new System.Drawing.Size(380, 20);
            // 
            // lvw
            // 
            this.lvw.Size = new System.Drawing.Size(380, 139);
            // 
            // CommandBar
            // 
            this.CommandBar.Controls.Add(this.cmbSnoozeDuration);
            this.CommandBar.Controls.Add(this.btnDismiss);
            this.CommandBar.Controls.Add(this.btnDismissAll);
            this.CommandBar.Controls.Add(this.btnStopSound);
            this.CommandBar.Controls.Add(this.btnSnooze);
            this.CommandBar.Location = new System.Drawing.Point(-1, 166);
            this.CommandBar.Size = new System.Drawing.Size(387, 35);
            this.CommandBar.Controls.SetChildIndex(this.btnOK, 0);
            this.CommandBar.Controls.SetChildIndex(this.btnOpen, 0);
            this.CommandBar.Controls.SetChildIndex(this.btnSnooze, 0);
            this.CommandBar.Controls.SetChildIndex(this.btnStopSound, 0);
            this.CommandBar.Controls.SetChildIndex(this.btnDismissAll, 0);
            this.CommandBar.Controls.SetChildIndex(this.btnDismiss, 0);
            this.CommandBar.Controls.SetChildIndex(this.cmbSnoozeDuration, 0);
            // 
            // btnDismiss
            // 
            this.btnDismiss.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDismiss.Location = new System.Drawing.Point(5, 5);
            this.btnDismiss.Name = "btnDismiss";
            this.btnDismiss.Size = new System.Drawing.Size(65, 23);
            this.btnDismiss.TabIndex = 1;
            this.btnDismiss.Text = "&Dismiss";
            this.btnDismiss.UseVisualStyleBackColor = true;
            this.btnDismiss.Click += new System.EventHandler(this.btnDismiss_Click);
            // 
            // btnDismissAll
            // 
            this.btnDismissAll.Action = Scalable.Win.Enums.CommandBarAction.Open;
            this.btnDismissAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDismissAll.Location = new System.Drawing.Point(73, 5);
            this.btnDismissAll.Name = "btnDismissAll";
            this.btnDismissAll.Size = new System.Drawing.Size(65, 23);
            this.btnDismissAll.TabIndex = 2;
            this.btnDismissAll.Text = "Di&smiss All";
            this.btnDismissAll.UseVisualStyleBackColor = true;
            this.btnDismissAll.Click += new System.EventHandler(this.btnDismissAll_Click);
            // 
            // btnSnooze
            // 
            this.btnSnooze.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSnooze.Location = new System.Drawing.Point(221, 5);
            this.btnSnooze.Name = "btnSnooze";
            this.btnSnooze.Size = new System.Drawing.Size(65, 23);
            this.btnSnooze.TabIndex = 4;
            this.btnSnooze.Text = "&Snooze";
            this.btnSnooze.UseVisualStyleBackColor = true;
            this.btnSnooze.Click += new System.EventHandler(this.btnSnooze_Click);
            // 
            // cmbSnoozeDuration
            // 
            this.cmbSnoozeDuration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSnoozeDuration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSnoozeDuration.FormattingEnabled = true;
            this.cmbSnoozeDuration.Location = new System.Drawing.Point(142, 6);
            this.cmbSnoozeDuration.Name = "cmbSnoozeDuration";
            this.cmbSnoozeDuration.Size = new System.Drawing.Size(75, 21);
            this.cmbSnoozeDuration.TabIndex = 3;
            this.cmbSnoozeDuration.SelectedIndexChanged += new System.EventHandler(this.cmbSnoozeDuration_SelectedIndexChanged);
            // 
            // btnStopSound
            // 
            this.btnStopSound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStopSound.Image = ((System.Drawing.Image)(resources.GetObject("btnStopSound.Image")));
            this.btnStopSound.Location = new System.Drawing.Point(289, 5);
            this.btnStopSound.Name = "btnStopSound";
            this.btnStopSound.Size = new System.Drawing.Size(23, 23);
            this.btnStopSound.TabIndex = 5;
            this.btnStopSound.UseVisualStyleBackColor = true;
            this.btnStopSound.Click += new System.EventHandler(this.btnStopSound_Click);
            // 
            // UReminderPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.MinimumSize = new System.Drawing.Size(385, 200);
            this.Name = "UReminderPopup";
            this.Size = new System.Drawing.Size(385, 200);
            this.CommandBar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Scalable.Win.Controls.iCommandButton btnDismiss;
        private Scalable.Win.Controls.iCommandButton btnDismissAll;
        internal Scalable.Win.Controls.iCommandButton btnSnooze;
        private Scalable.Win.Controls.iComboBox cmbSnoozeDuration;
        internal Scalable.Win.Controls.iCommandButton btnStopSound;
    }
}
