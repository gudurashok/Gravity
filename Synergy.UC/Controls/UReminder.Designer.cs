namespace Synergy.UC.Controls
{
    partial class UReminder
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
            this.lblTask = new Scalable.Win.Controls.iLabel();
            this.txbTask = new Scalable.Win.Controls.iTextBoxButton();
            this.lblName = new Scalable.Win.Controls.iLabel();
            this.txtName = new Scalable.Win.Controls.iTextBox();
            this.dtpReminderTime = new Scalable.Win.Controls.iDateTimePicker();
            this.dtpReminderDate = new Scalable.Win.Controls.iDateTimePicker();
            this.lblRemindAt = new Scalable.Win.Controls.iLabel();
            this.btnSave = new Scalable.Win.Controls.iCommandButton();
            this.btnCancel = new Scalable.Win.Controls.iCommandButton();
            this.SuspendLayout();
            // 
            // lblTask
            // 
            this.lblTask.AutoSize = true;
            this.lblTask.Location = new System.Drawing.Point(0, 5);
            this.lblTask.Name = "lblTask";
            this.lblTask.Size = new System.Drawing.Size(34, 13);
            this.lblTask.TabIndex = 0;
            this.lblTask.Text = "Task:";
            // 
            // txbTask
            // 
            this.txbTask.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbTask.Location = new System.Drawing.Point(66, 2);
            this.txbTask.Name = "txbTask";
            this.txbTask.SearchProperty = "Name";
            this.txbTask.Size = new System.Drawing.Size(296, 20);
            this.txbTask.TabIndex = 1;
            this.txbTask.Leave += new System.EventHandler(this.txbTask_Leave);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(0, 27);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(66, 24);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(296, 20);
            this.txtName.TabIndex = 3;
            // 
            // dtpReminderTime
            // 
            this.dtpReminderTime.Checked = false;
            this.dtpReminderTime.CustomFormat = "h:mm tt";
            this.dtpReminderTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpReminderTime.Location = new System.Drawing.Point(163, 46);
            this.dtpReminderTime.Name = "dtpReminderTime";
            this.dtpReminderTime.ShowUpDown = true;
            this.dtpReminderTime.Size = new System.Drawing.Size(75, 20);
            this.dtpReminderTime.TabIndex = 6;
            // 
            // dtpReminderDate
            // 
            this.dtpReminderDate.Checked = false;
            this.dtpReminderDate.CustomFormat = "dd/MM/yyyy";
            this.dtpReminderDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpReminderDate.Location = new System.Drawing.Point(66, 46);
            this.dtpReminderDate.Name = "dtpReminderDate";
            this.dtpReminderDate.Size = new System.Drawing.Size(97, 20);
            this.dtpReminderDate.TabIndex = 5;
            // 
            // lblRemindAt
            // 
            this.lblRemindAt.AutoSize = true;
            this.lblRemindAt.Location = new System.Drawing.Point(0, 49);
            this.lblRemindAt.Name = "lblRemindAt";
            this.lblRemindAt.Size = new System.Drawing.Size(58, 13);
            this.lblRemindAt.TabIndex = 4;
            this.lblRemindAt.Text = "Re&mind at:";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(241, 45);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(60, 22);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(303, 45);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(60, 22);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // UReminder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.dtpReminderTime);
            this.Controls.Add(this.dtpReminderDate);
            this.Controls.Add(this.lblRemindAt);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txbTask);
            this.Controls.Add(this.lblTask);
            this.Controls.Add(this.lblName);
            this.MaximumSize = new System.Drawing.Size(840, 70);
            this.MinimumSize = new System.Drawing.Size(365, 70);
            this.Name = "UReminder";
            this.Size = new System.Drawing.Size(365, 70);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Scalable.Win.Controls.iLabel lblTask;
        private Scalable.Win.Controls.iTextBoxButton txbTask;
        private Scalable.Win.Controls.iLabel lblName;
        private Scalable.Win.Controls.iTextBox txtName;
        private Scalable.Win.Controls.iDateTimePicker dtpReminderTime;
        private Scalable.Win.Controls.iDateTimePicker dtpReminderDate;
        private Scalable.Win.Controls.iLabel lblRemindAt;
        private Scalable.Win.Controls.iCommandButton btnSave;
        private Scalable.Win.Controls.iCommandButton btnCancel;
    }
}
