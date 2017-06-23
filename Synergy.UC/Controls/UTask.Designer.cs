using System.ComponentModel;
using Scalable.Win.Controls;

namespace Synergy.UC.Controls
{
    partial class UTask
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UTask));
            this.btnSaveAndClose = new Scalable.Win.Controls.iCommandButton();
            this.btnSaveAndNew = new Scalable.Win.Controls.iCommandButton();
            this.taskMenuStrip = new Scalable.Win.Controls.iMenuStrip();
            this.templatesToolStripMenuItem = new Scalable.Win.Controls.iToolStripMenuItem();
            this.recurrenceToolStripMenuItem = new Scalable.Win.Controls.iToolStripMenuItem();
            this.advancedToolStripMenuItem = new Scalable.Win.Controls.iToolStripMenuItem();
            this.attachmentToolStripMenuItem = new Scalable.Win.Controls.iToolStripMenuItem();
            this.addCommentToolStripMenuItem = new Scalable.Win.Controls.iToolStripMenuItem();
            this.viewCommentsToolStripMenuItem = new Scalable.Win.Controls.iToolStripMenuItem();
            this.pnlTask = new Scalable.Win.Controls.iPanel();
            this.txbAssignTo = new Scalable.Win.Controls.iTextBoxButton();
            this.lblAssignTo = new Scalable.Win.Controls.iLabel();
            this.txbAssignedBy = new Scalable.Win.Controls.iTextBoxButton();
            this.lblAssignedBy = new Scalable.Win.Controls.iLabel();
            this.btnCcTo = new Scalable.Win.Controls.iCommandButton();
            this.dtpReminderTime = new Scalable.Win.Controls.iDateTimePicker();
            this.chkReminderForAll = new Scalable.Win.Controls.iCheckBox();
            this.dtpReminderDate = new Scalable.Win.Controls.iDateTimePicker();
            this.txbOwner = new Scalable.Win.Controls.iTextBoxButton();
            this.lblCcTo = new Scalable.Win.Controls.iLabel();
            this.lblOwner = new Scalable.Win.Controls.iLabel();
            this.dtpStartDate = new Scalable.Win.Controls.iDateTimePicker();
            this.lblStartDate = new Scalable.Win.Controls.iLabel();
            this.txtCcTo = new Scalable.Win.Controls.iTextBox();
            this.cmbEstimatedTime = new Scalable.Win.Controls.iComboBox();
            this.lblEstimated = new Scalable.Win.Controls.iLabel();
            this.dtpStartTime = new Scalable.Win.Controls.iDateTimePicker();
            this.dtpDueTime = new Scalable.Win.Controls.iDateTimePicker();
            this.dtpDueDate = new Scalable.Win.Controls.iDateTimePicker();
            this.lblRemindAt = new Scalable.Win.Controls.iLabel();
            this.lblDueDate = new Scalable.Win.Controls.iLabel();
            this.cmbPriority = new Scalable.Win.Controls.iComboBox();
            this.lblPriority = new Scalable.Win.Controls.iLabel();
            this.lblParent = new Scalable.Win.Controls.iLabel();
            this.cmbTag = new Scalable.Win.Controls.iComboBox();
            this.txtName = new Scalable.Win.Controls.iTextBox();
            this.lblDescription = new Scalable.Win.Controls.iLabel();
            this.lblTag = new Scalable.Win.Controls.iLabel();
            this.rtbDescription = new Scalable.Win.Controls.iRichTextBox();
            this.lblName = new Scalable.Win.Controls.iLabel();
            this.txbParent = new Scalable.Win.Controls.iTextBoxButton();
            this.lnkSaveAsTemplate = new Scalable.Win.Controls.iLinkLabel();
            this.btnSave = new Scalable.Win.Controls.iCommandButton();
            this.btnSpellCheck = new Scalable.Win.Controls.iCommandButton();
            this.txtValue = new Scalable.Win.Controls.iNumberTextBox();
            this.CommandBar.SuspendLayout();
            this.taskMenuStrip.SuspendLayout();
            this.pnlTask.SuspendLayout();
            this.SuspendLayout();
            // 
            // CommandBar
            // 
            this.CommandBar.Controls.Add(this.btnSave);
            this.CommandBar.Controls.Add(this.btnSaveAndNew);
            this.CommandBar.Controls.Add(this.btnSpellCheck);
            this.CommandBar.Controls.Add(this.btnSaveAndClose);
            this.CommandBar.Location = new System.Drawing.Point(-1, 312);
            this.CommandBar.Size = new System.Drawing.Size(546, 35);
            this.CommandBar.TabIndex = 10;
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.Action = ((Scalable.Win.Enums.CommandBarAction)((Scalable.Win.Enums.CommandBarAction.Save | Scalable.Win.Enums.CommandBarAction.Close)));
            this.btnSaveAndClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveAndClose.Location = new System.Drawing.Point(461, 5);
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            this.btnSaveAndClose.Size = new System.Drawing.Size(78, 23);
            this.btnSaveAndClose.TabIndex = 1;
            this.btnSaveAndClose.Text = "Save && &Close";
            this.btnSaveAndClose.UseVisualStyleBackColor = true;
            this.btnSaveAndClose.Click += new System.EventHandler(this.commandBarButton_Click);
            // 
            // btnSaveAndNew
            // 
            this.btnSaveAndNew.Action = ((Scalable.Win.Enums.CommandBarAction)((Scalable.Win.Enums.CommandBarAction.New | Scalable.Win.Enums.CommandBarAction.Save)));
            this.btnSaveAndNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveAndNew.Location = new System.Drawing.Point(377, 5);
            this.btnSaveAndNew.Name = "btnSaveAndNew";
            this.btnSaveAndNew.Size = new System.Drawing.Size(78, 23);
            this.btnSaveAndNew.TabIndex = 2;
            this.btnSaveAndNew.Text = "Sa&ve && New";
            this.btnSaveAndNew.UseVisualStyleBackColor = true;
            this.btnSaveAndNew.Click += new System.EventHandler(this.commandBarButton_Click);
            // 
            // taskMenuStrip
            // 
            this.taskMenuStrip.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taskMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.templatesToolStripMenuItem,
            this.recurrenceToolStripMenuItem,
            this.advancedToolStripMenuItem,
            this.attachmentToolStripMenuItem,
            this.addCommentToolStripMenuItem,
            this.viewCommentsToolStripMenuItem});
            this.taskMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.taskMenuStrip.Name = "taskMenuStrip";
            this.taskMenuStrip.Size = new System.Drawing.Size(544, 24);
            this.taskMenuStrip.TabIndex = 10;
            this.taskMenuStrip.Text = "Task Menu Strip";
            // 
            // templatesToolStripMenuItem
            // 
            this.templatesToolStripMenuItem.Name = "templatesToolStripMenuItem";
            this.templatesToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.templatesToolStripMenuItem.Text = "&Templates";
            this.templatesToolStripMenuItem.Click += new System.EventHandler(this.templatesToolStripMenuItem_Click);
            // 
            // recurrenceToolStripMenuItem
            // 
            this.recurrenceToolStripMenuItem.Name = "recurrenceToolStripMenuItem";
            this.recurrenceToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.recurrenceToolStripMenuItem.Text = "&Recurrence";
            this.recurrenceToolStripMenuItem.Click += new System.EventHandler(this.recurranceToolStripMenuItem_Click);
            // 
            // advancedToolStripMenuItem
            // 
            this.advancedToolStripMenuItem.Name = "advancedToolStripMenuItem";
            this.advancedToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.advancedToolStripMenuItem.Text = "&Advanced";
            this.advancedToolStripMenuItem.Click += new System.EventHandler(this.advancedToolStripMenuItem_Click);
            // 
            // attachmentToolStripMenuItem
            // 
            this.attachmentToolStripMenuItem.Name = "attachmentToolStripMenuItem";
            this.attachmentToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.attachmentToolStripMenuItem.Text = "Attac&hment";
            this.attachmentToolStripMenuItem.Click += new System.EventHandler(this.attachmentToolStripMenuItem_Click);
            // 
            // addCommentToolStripMenuItem
            // 
            this.addCommentToolStripMenuItem.Name = "addCommentToolStripMenuItem";
            this.addCommentToolStripMenuItem.Size = new System.Drawing.Size(99, 20);
            this.addCommentToolStripMenuItem.Text = "Ad&d Comment";
            this.addCommentToolStripMenuItem.Click += new System.EventHandler(this.addCommentToolStripMenuItem_Click);
            // 
            // viewCommentsToolStripMenuItem
            // 
            this.viewCommentsToolStripMenuItem.Name = "viewCommentsToolStripMenuItem";
            this.viewCommentsToolStripMenuItem.Size = new System.Drawing.Size(110, 20);
            this.viewCommentsToolStripMenuItem.Text = "Vie&w Comments";
            this.viewCommentsToolStripMenuItem.Click += new System.EventHandler(this.viewCommentsToolStripMenuItem_Click);
            // 
            // pnlTask
            // 
            this.pnlTask.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTask.Controls.Add(this.txbAssignTo);
            this.pnlTask.Controls.Add(this.lblAssignTo);
            this.pnlTask.Controls.Add(this.txbAssignedBy);
            this.pnlTask.Controls.Add(this.lblAssignedBy);
            this.pnlTask.Controls.Add(this.btnCcTo);
            this.pnlTask.Controls.Add(this.dtpReminderTime);
            this.pnlTask.Controls.Add(this.chkReminderForAll);
            this.pnlTask.Controls.Add(this.dtpReminderDate);
            this.pnlTask.Controls.Add(this.txbOwner);
            this.pnlTask.Controls.Add(this.lblCcTo);
            this.pnlTask.Controls.Add(this.lblOwner);
            this.pnlTask.Controls.Add(this.dtpStartDate);
            this.pnlTask.Controls.Add(this.lblStartDate);
            this.pnlTask.Controls.Add(this.txtCcTo);
            this.pnlTask.Controls.Add(this.cmbEstimatedTime);
            this.pnlTask.Controls.Add(this.lblEstimated);
            this.pnlTask.Controls.Add(this.dtpStartTime);
            this.pnlTask.Controls.Add(this.dtpDueTime);
            this.pnlTask.Controls.Add(this.dtpDueDate);
            this.pnlTask.Controls.Add(this.lblRemindAt);
            this.pnlTask.Controls.Add(this.lblDueDate);
            this.pnlTask.Controls.Add(this.cmbPriority);
            this.pnlTask.Controls.Add(this.lblPriority);
            this.pnlTask.Location = new System.Drawing.Point(-1, 199);
            this.pnlTask.Name = "pnlTask";
            this.pnlTask.Size = new System.Drawing.Size(547, 116);
            this.pnlTask.TabIndex = 9;
            // 
            // txbAssignTo
            // 
            this.txbAssignTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbAssignTo.Location = new System.Drawing.Point(353, 69);
            this.txbAssignTo.Name = "txbAssignTo";
            this.txbAssignTo.SearchProperty = "Name";
            this.txbAssignTo.Size = new System.Drawing.Size(188, 20);
            this.txbAssignTo.TabIndex = 18;
            // 
            // lblAssignTo
            // 
            this.lblAssignTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAssignTo.AutoSize = true;
            this.lblAssignTo.Location = new System.Drawing.Point(298, 73);
            this.lblAssignTo.Name = "lblAssignTo";
            this.lblAssignTo.Size = new System.Drawing.Size(53, 13);
            this.lblAssignTo.TabIndex = 17;
            this.lblAssignTo.Text = "Assi&gn to:";
            // 
            // txbAssignedBy
            // 
            this.txbAssignedBy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txbAssignedBy.Location = new System.Drawing.Point(96, 69);
            this.txbAssignedBy.Name = "txbAssignedBy";
            this.txbAssignedBy.SearchProperty = "Name";
            this.txbAssignedBy.Size = new System.Drawing.Size(200, 20);
            this.txbAssignedBy.TabIndex = 16;
            // 
            // lblAssignedBy
            // 
            this.lblAssignedBy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAssignedBy.AutoSize = true;
            this.lblAssignedBy.Location = new System.Drawing.Point(4, 73);
            this.lblAssignedBy.Name = "lblAssignedBy";
            this.lblAssignedBy.Size = new System.Drawing.Size(67, 13);
            this.lblAssignedBy.TabIndex = 15;
            this.lblAssignedBy.Text = "Assigned &by:";
            // 
            // btnCcTo
            // 
            this.btnCcTo.Action = ((Scalable.Win.Enums.CommandBarAction)((Scalable.Win.Enums.CommandBarAction.New | Scalable.Win.Enums.CommandBarAction.Save)));
            this.btnCcTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCcTo.Image = ((System.Drawing.Image)(resources.GetObject("btnCcTo.Image")));
            this.btnCcTo.Location = new System.Drawing.Point(519, 46);
            this.btnCcTo.Name = "btnCcTo";
            this.btnCcTo.Size = new System.Drawing.Size(23, 22);
            this.btnCcTo.TabIndex = 14;
            this.btnCcTo.UseVisualStyleBackColor = true;
            this.btnCcTo.Click += new System.EventHandler(this.btnCcTo_Click);
            // 
            // dtpReminderTime
            // 
            this.dtpReminderTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtpReminderTime.Checked = false;
            this.dtpReminderTime.CustomFormat = "h:mm tt";
            this.dtpReminderTime.Enabled = false;
            this.dtpReminderTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpReminderTime.Location = new System.Drawing.Point(209, 91);
            this.dtpReminderTime.Name = "dtpReminderTime";
            this.dtpReminderTime.ShowUpDown = true;
            this.dtpReminderTime.Size = new System.Drawing.Size(87, 20);
            this.dtpReminderTime.TabIndex = 21;
            // 
            // chkReminderForAll
            // 
            this.chkReminderForAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkReminderForAll.AutoSize = true;
            this.chkReminderForAll.Enabled = false;
            this.chkReminderForAll.Location = new System.Drawing.Point(301, 93);
            this.chkReminderForAll.Name = "chkReminderForAll";
            this.chkReminderForAll.Size = new System.Drawing.Size(237, 17);
            this.chkReminderForAll.TabIndex = 22;
            this.chkReminderForAll.Text = "Set reminder for all users involved in this task";
            this.chkReminderForAll.UseVisualStyleBackColor = true;
            // 
            // dtpReminderDate
            // 
            this.dtpReminderDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtpReminderDate.Checked = false;
            this.dtpReminderDate.CustomFormat = "dd/MM/yyyy";
            this.dtpReminderDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpReminderDate.Location = new System.Drawing.Point(96, 91);
            this.dtpReminderDate.Name = "dtpReminderDate";
            this.dtpReminderDate.ShowCheckBox = true;
            this.dtpReminderDate.Size = new System.Drawing.Size(113, 20);
            this.dtpReminderDate.TabIndex = 20;
            this.dtpReminderDate.CheckedChanged += new System.EventHandler(this.dtpReminder_CheckedChanged);
            // 
            // txbOwner
            // 
            this.txbOwner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txbOwner.Location = new System.Drawing.Point(96, 47);
            this.txbOwner.Name = "txbOwner";
            this.txbOwner.SearchProperty = "Name";
            this.txbOwner.Size = new System.Drawing.Size(200, 20);
            this.txbOwner.TabIndex = 11;
            // 
            // lblCcTo
            // 
            this.lblCcTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCcTo.AutoSize = true;
            this.lblCcTo.Location = new System.Drawing.Point(298, 51);
            this.lblCcTo.Name = "lblCcTo";
            this.lblCcTo.Size = new System.Drawing.Size(40, 13);
            this.lblCcTo.TabIndex = 12;
            this.lblCcTo.Text = "CC T&o:";
            // 
            // lblOwner
            // 
            this.lblOwner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblOwner.AutoSize = true;
            this.lblOwner.Location = new System.Drawing.Point(4, 51);
            this.lblOwner.Name = "lblOwner";
            this.lblOwner.Size = new System.Drawing.Size(41, 13);
            this.lblOwner.TabIndex = 10;
            this.lblOwner.Text = "O&wner:";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtpStartDate.Checked = false;
            this.dtpStartDate.CustomFormat = "dd/MM/yyyy";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(96, 2);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.ShowCheckBox = true;
            this.dtpStartDate.Size = new System.Drawing.Size(113, 20);
            this.dtpStartDate.TabIndex = 1;
            this.dtpStartDate.CheckedChanged += new System.EventHandler(this.dtpStartDate_CheckedChanged);
            // 
            // lblStartDate
            // 
            this.lblStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(2, 5);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(96, 13);
            this.lblStartDate.TabIndex = 0;
            this.lblStartDate.Text = "Planned &start date:";
            // 
            // txtCcTo
            // 
            this.txtCcTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCcTo.AutoCasing = Scalable.Shared.Enums.TextCaseStyle.Proper;
            this.txtCcTo.BackColor = System.Drawing.SystemColors.Control;
            this.txtCcTo.Location = new System.Drawing.Point(353, 47);
            this.txtCcTo.MaxLength = 70;
            this.txtCcTo.Name = "txtCcTo";
            this.txtCcTo.ReadOnly = true;
            this.txtCcTo.Size = new System.Drawing.Size(166, 20);
            this.txtCcTo.TabIndex = 13;
            // 
            // cmbEstimatedTime
            // 
            this.cmbEstimatedTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbEstimatedTime.BackColor = System.Drawing.Color.White;
            this.cmbEstimatedTime.FormattingEnabled = true;
            this.cmbEstimatedTime.Location = new System.Drawing.Point(353, 1);
            this.cmbEstimatedTime.MaxLength = 15;
            this.cmbEstimatedTime.Name = "cmbEstimatedTime";
            this.cmbEstimatedTime.Size = new System.Drawing.Size(188, 21);
            this.cmbEstimatedTime.TabIndex = 7;
            // 
            // lblEstimated
            // 
            this.lblEstimated.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblEstimated.AutoSize = true;
            this.lblEstimated.Location = new System.Drawing.Point(298, 4);
            this.lblEstimated.Name = "lblEstimated";
            this.lblEstimated.Size = new System.Drawing.Size(56, 13);
            this.lblEstimated.TabIndex = 6;
            this.lblEstimated.Text = "&Estimated:";
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtpStartTime.Checked = false;
            this.dtpStartTime.CustomFormat = "h:mm tt";
            this.dtpStartTime.Enabled = false;
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime.Location = new System.Drawing.Point(209, 2);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.ShowCheckBox = true;
            this.dtpStartTime.ShowUpDown = true;
            this.dtpStartTime.Size = new System.Drawing.Size(87, 20);
            this.dtpStartTime.TabIndex = 2;
            this.dtpStartTime.CheckedChanged += new System.EventHandler(this.dtpStartTime_CheckedChanged);
            // 
            // dtpDueTime
            // 
            this.dtpDueTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtpDueTime.Checked = false;
            this.dtpDueTime.CustomFormat = "h:mm tt";
            this.dtpDueTime.Enabled = false;
            this.dtpDueTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDueTime.Location = new System.Drawing.Point(209, 24);
            this.dtpDueTime.Name = "dtpDueTime";
            this.dtpDueTime.ShowCheckBox = true;
            this.dtpDueTime.ShowUpDown = true;
            this.dtpDueTime.Size = new System.Drawing.Size(87, 20);
            this.dtpDueTime.TabIndex = 5;
            this.dtpDueTime.CheckedChanged += new System.EventHandler(this.dtpDueTime_CheckedChanged);
            // 
            // dtpDueDate
            // 
            this.dtpDueDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtpDueDate.Checked = false;
            this.dtpDueDate.CustomFormat = "dd/MM/yyyy";
            this.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDueDate.Location = new System.Drawing.Point(96, 24);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.ShowCheckBox = true;
            this.dtpDueDate.Size = new System.Drawing.Size(113, 20);
            this.dtpDueDate.TabIndex = 4;
            this.dtpDueDate.CheckedChanged += new System.EventHandler(this.dtpDueDate_CheckedChanged);
            // 
            // lblRemindAt
            // 
            this.lblRemindAt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRemindAt.AutoSize = true;
            this.lblRemindAt.Location = new System.Drawing.Point(4, 95);
            this.lblRemindAt.Name = "lblRemindAt";
            this.lblRemindAt.Size = new System.Drawing.Size(58, 13);
            this.lblRemindAt.TabIndex = 19;
            this.lblRemindAt.Text = "Re&mind at:";
            // 
            // lblDueDate
            // 
            this.lblDueDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDueDate.AutoSize = true;
            this.lblDueDate.Location = new System.Drawing.Point(2, 28);
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.Size = new System.Drawing.Size(54, 13);
            this.lblDueDate.TabIndex = 3;
            this.lblDueDate.Text = "D&ue date:";
            // 
            // cmbPriority
            // 
            this.cmbPriority.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPriority.BackColor = System.Drawing.Color.White;
            this.cmbPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPriority.FormattingEnabled = true;
            this.cmbPriority.Location = new System.Drawing.Point(353, 24);
            this.cmbPriority.Name = "cmbPriority";
            this.cmbPriority.Size = new System.Drawing.Size(188, 21);
            this.cmbPriority.TabIndex = 9;
            // 
            // lblPriority
            // 
            this.lblPriority.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPriority.AutoSize = true;
            this.lblPriority.Location = new System.Drawing.Point(298, 27);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(41, 13);
            this.lblPriority.TabIndex = 8;
            this.lblPriority.Text = "&Priority:";
            // 
            // lblParent
            // 
            this.lblParent.AutoSize = true;
            this.lblParent.Location = new System.Drawing.Point(2, 53);
            this.lblParent.Name = "lblParent";
            this.lblParent.Size = new System.Drawing.Size(41, 13);
            this.lblParent.TabIndex = 4;
            this.lblParent.Text = "Parent:";
            // 
            // cmbTag
            // 
            this.cmbTag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTag.BackColor = System.Drawing.Color.White;
            this.cmbTag.FormattingEnabled = true;
            this.cmbTag.Location = new System.Drawing.Point(439, 28);
            this.cmbTag.Name = "cmbTag";
            this.cmbTag.Size = new System.Drawing.Size(101, 21);
            this.cmbTag.TabIndex = 3;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.AutoCasing = Scalable.Shared.Enums.TextCaseStyle.Proper;
            this.txtName.Location = new System.Drawing.Point(44, 28);
            this.txtName.MaxLength = 125;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(366, 20);
            this.txtName.TabIndex = 1;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(2, 73);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(63, 13);
            this.lblDescription.TabIndex = 7;
            this.lblDescription.Text = "&Description:";
            // 
            // lblTag
            // 
            this.lblTag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTag.AutoSize = true;
            this.lblTag.Location = new System.Drawing.Point(410, 31);
            this.lblTag.Name = "lblTag";
            this.lblTag.Size = new System.Drawing.Size(29, 13);
            this.lblTag.TabIndex = 2;
            this.lblTag.Text = "Ta&g:";
            // 
            // rtbDescription
            // 
            this.rtbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbDescription.Location = new System.Drawing.Point(4, 90);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.ShowSelectionMargin = true;
            this.rtbDescription.Size = new System.Drawing.Size(537, 109);
            this.rtbDescription.TabIndex = 8;
            this.rtbDescription.Text = "";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(2, 31);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "&Name:";
            // 
            // txbParent
            // 
            this.txbParent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbParent.Location = new System.Drawing.Point(44, 50);
            this.txbParent.Name = "txbParent";
            this.txbParent.SearchProperty = "Name";
            this.txbParent.Size = new System.Drawing.Size(366, 20);
            this.txbParent.TabIndex = 5;
            // 
            // lnkSaveAsTemplate
            // 
            this.lnkSaveAsTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkSaveAsTemplate.AutoSize = true;
            this.lnkSaveAsTemplate.Location = new System.Drawing.Point(450, 73);
            this.lnkSaveAsTemplate.Name = "lnkSaveAsTemplate";
            this.lnkSaveAsTemplate.Size = new System.Drawing.Size(89, 13);
            this.lnkSaveAsTemplate.TabIndex = 11;
            this.lnkSaveAsTemplate.TabStop = true;
            this.lnkSaveAsTemplate.Text = "Save as template";
            this.lnkSaveAsTemplate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSaveAsTemplate_LinkClicked);
            // 
            // btnSave
            // 
            this.btnSave.Action = Scalable.Win.Enums.CommandBarAction.Save;
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(293, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(78, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.commandBarButton_Click);
            // 
            // btnSpellCheck
            // 
            this.btnSpellCheck.Image = ((System.Drawing.Image)(resources.GetObject("btnSpellCheck.Image")));
            this.btnSpellCheck.Location = new System.Drawing.Point(6, 5);
            this.btnSpellCheck.Name = "btnSpellCheck";
            this.btnSpellCheck.Size = new System.Drawing.Size(23, 23);
            this.btnSpellCheck.TabIndex = 12;
            this.btnSpellCheck.UseVisualStyleBackColor = true;
            this.btnSpellCheck.Click += new System.EventHandler(this.btnSpellCheck_Click);
            // 
            // txtAmount
            // 
            this.txtValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValue.ValueFormat = "9.2";
            this.txtValue.Location = new System.Drawing.Point(413, 50);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(127, 20);
            this.txtValue.TabIndex = 6;
            this.txtValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtValue.Text = "0";
            this.txtValue.Value = 0D;
            this.txtValue.DisplayFormat = "##,##,##,###.##";
            // 
            // UTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.taskMenuStrip);
            this.Controls.Add(this.lnkSaveAsTemplate);
            this.Controls.Add(this.txbParent);
            this.Controls.Add(this.lblParent);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.rtbDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.cmbTag);
            this.Controls.Add(this.lblTag);
            this.Controls.Add(this.pnlTask);
            this.Name = "UTask";
            this.Size = new System.Drawing.Size(544, 346);
            this.Controls.SetChildIndex(this.pnlTask, 0);
            this.Controls.SetChildIndex(this.lblTag, 0);
            this.Controls.SetChildIndex(this.cmbTag, 0);
            this.Controls.SetChildIndex(this.txtName, 0);
            this.Controls.SetChildIndex(this.lblDescription, 0);
            this.Controls.SetChildIndex(this.rtbDescription, 0);
            this.Controls.SetChildIndex(this.lblName, 0);
            this.Controls.SetChildIndex(this.lblParent, 0);
            this.Controls.SetChildIndex(this.txbParent, 0);
            this.Controls.SetChildIndex(this.lnkSaveAsTemplate, 0);
            this.Controls.SetChildIndex(this.taskMenuStrip, 0);
            this.Controls.SetChildIndex(this.CommandBar, 0);
            this.Controls.SetChildIndex(this.txtValue, 0);
            this.CommandBar.ResumeLayout(false);
            this.taskMenuStrip.ResumeLayout(false);
            this.taskMenuStrip.PerformLayout();
            this.pnlTask.ResumeLayout(false);
            this.pnlTask.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private iCommandButton btnSaveAndClose;
        private iCommandButton btnSaveAndNew;
        private iMenuStrip taskMenuStrip;
        private iToolStripMenuItem recurrenceToolStripMenuItem;
        private iToolStripMenuItem advancedToolStripMenuItem;
        private iToolStripMenuItem attachmentToolStripMenuItem;
        private iToolStripMenuItem addCommentToolStripMenuItem;
        private iToolStripMenuItem viewCommentsToolStripMenuItem;
        private iLabel lblAssignTo;
        private iTextBoxButton txbOwner;
        private iLabel lblOwner;
        private iTextBoxButton txbAssignedBy;
        private iLabel lblAssignedBy;
        private iTextBoxButton txbAssignTo;
        private iDateTimePicker dtpStartDate;
        private iLabel lblStartDate;
        private iComboBox cmbTag;
        private iComboBox cmbEstimatedTime;
        private iLabel lblEstimated;
        private iDateTimePicker dtpStartTime;
        private iDateTimePicker dtpDueTime;
        private iDateTimePicker dtpDueDate;
        private iLabel lblDueDate;
        private iComboBox cmbPriority;
        private iLabel lblPriority;
        private iTextBox txtName;
        private iLabel lblDescription;
        private iLabel lblTag;
        private iRichTextBox rtbDescription;
        private iLabel lblName;
        protected iPanel pnlTask;
        private iLabel lblParent;
        private iTextBoxButton txbParent;
        private iDateTimePicker dtpReminderDate;
        private iDateTimePicker dtpReminderTime;
        private iCheckBox chkReminderForAll;
        private iLabel lblRemindAt;
        private iCommandButton btnCcTo;
        private iLabel lblCcTo;
        private iTextBox txtCcTo;
        private iToolStripMenuItem templatesToolStripMenuItem;
        private iLinkLabel lnkSaveAsTemplate;
        private iCommandButton btnSave;
        private iCommandButton btnSpellCheck;
        private iNumberTextBox txtValue;
    }
}
