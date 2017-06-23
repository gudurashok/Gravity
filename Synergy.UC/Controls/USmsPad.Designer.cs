namespace Synergy.UC.Controls
{
    partial class USmsPad
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(USmsPad));
            this.btnSend = new Scalable.Win.Controls.iCommandButton();
            this.lblTo = new Scalable.Win.Controls.iLabel();
            this.txtNumbers = new Scalable.Win.Controls.iTextBox();
            this.cmbRecipientType = new Scalable.Win.Controls.iComboBox();
            this.lblMessage = new Scalable.Win.Controls.iLabel();
            this.txtMessage = new Scalable.Win.Controls.iTextBox();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nameToolStripMenuItem = new Scalable.Win.Controls.iToolStripMenuItem();
            this.descriptionToolStripMenuItem = new Scalable.Win.Controls.iToolStripMenuItem();
            this.lblCount = new Scalable.Win.Controls.iLabel();
            this.btnUsers = new Scalable.Win.Controls.iCommandButton();
            this.btnFillSelectedTask = new Scalable.Win.Controls.iCommandButton();
            this.btnSendAndExit = new Scalable.Win.Controls.iCommandButton();
            this.CommandBar.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // CommandBar
            // 
            this.CommandBar.Controls.Add(this.btnSendAndExit);
            this.CommandBar.Controls.Add(this.btnSend);
            this.CommandBar.Location = new System.Drawing.Point(-1, 118);
            this.CommandBar.Size = new System.Drawing.Size(308, 35);
            this.CommandBar.TabIndex = 6;
            // 
            // btnSend
            // 
            this.btnSend.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSend.Location = new System.Drawing.Point(116, 5);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "&Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(0, 5);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(26, 13);
            this.lblTo.TabIndex = 0;
            this.lblTo.Text = "&To:";
            // 
            // txtNumbers
            // 
            this.txtNumbers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumbers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumbers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumbers.InputFilterExpr = "[0-9]|[+]|[,]";
            this.txtNumbers.Location = new System.Drawing.Point(27, 2);
            this.txtNumbers.Name = "txtNumbers";
            this.txtNumbers.Size = new System.Drawing.Size(157, 21);
            this.txtNumbers.TabIndex = 1;
            this.txtNumbers.Leave += new System.EventHandler(this.txtNumbers_Leave);
            // 
            // cmbRecipientType
            // 
            this.cmbRecipientType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbRecipientType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRecipientType.FormattingEnabled = true;
            this.cmbRecipientType.Location = new System.Drawing.Point(207, 2);
            this.cmbRecipientType.Name = "cmbRecipientType";
            this.cmbRecipientType.Size = new System.Drawing.Size(96, 21);
            this.cmbRecipientType.TabIndex = 2;
            this.cmbRecipientType.SelectedIndexChanged += new System.EventHandler(this.cmbRecipientType_SelectedIndexChanged);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(1, 32);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(61, 13);
            this.lblMessage.TabIndex = 3;
            this.lblMessage.Text = "&Message:";
            // 
            // txtMessage
            // 
            this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMessage.ContextMenuStrip = this.contextMenuStrip;
            this.txtMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessage.Location = new System.Drawing.Point(3, 48);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessage.Size = new System.Drawing.Size(300, 67);
            this.txtMessage.TabIndex = 5;
            this.txtMessage.TextChanged += new System.EventHandler(this.txtMessage_TextChanged);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nameToolStripMenuItem,
            this.descriptionToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(180, 70);
            // 
            // nameToolStripMenuItem
            // 
            this.nameToolStripMenuItem.Name = "nameToolStripMenuItem";
            this.nameToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.nameToolStripMenuItem.Text = "Fill Task Name";
            this.nameToolStripMenuItem.Click += new System.EventHandler(this.nameToolStripMenuItem_Click);
            // 
            // descriptionToolStripMenuItem
            // 
            this.descriptionToolStripMenuItem.Name = "descriptionToolStripMenuItem";
            this.descriptionToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.descriptionToolStripMenuItem.Text = "Fill Task Description";
            this.descriptionToolStripMenuItem.Click += new System.EventHandler(this.descriptionToolStripMenuItem_Click);
            // 
            // lblCount
            // 
            this.lblCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.ForeColor = System.Drawing.Color.Blue;
            this.lblCount.Location = new System.Drawing.Point(250, 32);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(55, 13);
            this.lblCount.TabIndex = 8;
            this.lblCount.Text = "Count: 0";
            // 
            // btnUsers
            // 
            this.btnUsers.Action = ((Scalable.Win.Enums.CommandBarAction)((Scalable.Win.Enums.CommandBarAction.New | Scalable.Win.Enums.CommandBarAction.Save)));
            this.btnUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUsers.Image = ((System.Drawing.Image)(resources.GetObject("btnUsers.Image")));
            this.btnUsers.Location = new System.Drawing.Point(184, 1);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(23, 23);
            this.btnUsers.TabIndex = 7;
            this.btnUsers.UseVisualStyleBackColor = true;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // btnFillSelectedTask
            // 
            this.btnFillSelectedTask.Location = new System.Drawing.Point(67, 25);
            this.btnFillSelectedTask.Name = "btnFillSelectedTask";
            this.btnFillSelectedTask.Size = new System.Drawing.Size(98, 21);
            this.btnFillSelectedTask.TabIndex = 4;
            this.btnFillSelectedTask.Text = "Fill selected task";
            this.btnFillSelectedTask.UseVisualStyleBackColor = true;
            this.btnFillSelectedTask.Visible = false;
            this.btnFillSelectedTask.Click += new System.EventHandler(this.btnFillSelectedTask_Click);
            // 
            // btnSendAndExit
            // 
            this.btnSendAndExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendAndExit.Location = new System.Drawing.Point(226, 5);
            this.btnSendAndExit.Name = "btnSendAndExit";
            this.btnSendAndExit.Size = new System.Drawing.Size(75, 23);
            this.btnSendAndExit.TabIndex = 0;
            this.btnSendAndExit.Text = "Send && &Exit";
            this.btnSendAndExit.UseVisualStyleBackColor = true;
            this.btnSendAndExit.Click += new System.EventHandler(this.btnSendAndExit_Click);
            // 
            // USmsPad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnFillSelectedTask);
            this.Controls.Add(this.btnUsers);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.cmbRecipientType);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.txtNumbers);
            this.Controls.Add(this.lblCount);
            this.MinimumSize = new System.Drawing.Size(306, 144);
            this.Name = "USmsPad";
            this.Size = new System.Drawing.Size(306, 152);
            this.Controls.SetChildIndex(this.lblCount, 0);
            this.Controls.SetChildIndex(this.txtNumbers, 0);
            this.Controls.SetChildIndex(this.txtMessage, 0);
            this.Controls.SetChildIndex(this.cmbRecipientType, 0);
            this.Controls.SetChildIndex(this.lblMessage, 0);
            this.Controls.SetChildIndex(this.lblTo, 0);
            this.Controls.SetChildIndex(this.CommandBar, 0);
            this.Controls.SetChildIndex(this.btnUsers, 0);
            this.Controls.SetChildIndex(this.btnFillSelectedTask, 0);
            this.CommandBar.ResumeLayout(false);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Scalable.Win.Controls.iCommandButton btnSend;
        private Scalable.Win.Controls.iLabel lblTo;
        private Scalable.Win.Controls.iTextBox txtNumbers;
        private Scalable.Win.Controls.iComboBox cmbRecipientType;
        private Scalable.Win.Controls.iLabel lblMessage;
        private Scalable.Win.Controls.iTextBox txtMessage;
        private Scalable.Win.Controls.iLabel lblCount;
        private Scalable.Win.Controls.iCommandButton btnUsers;
        private Scalable.Win.Controls.iCommandButton btnFillSelectedTask;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private Scalable.Win.Controls.iToolStripMenuItem nameToolStripMenuItem;
        private Scalable.Win.Controls.iToolStripMenuItem descriptionToolStripMenuItem;
        private Scalable.Win.Controls.iCommandButton btnSendAndExit;

    }
}
