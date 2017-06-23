namespace Synergy.UC.Controls
{
    partial class UTaskTemplate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UTaskTemplate));
            this.lblName = new Scalable.Win.Controls.iLabel();
            this.txtName = new Scalable.Win.Controls.iTextBox();
            this.lblTag = new Scalable.Win.Controls.iLabel();
            this.txtTag = new Scalable.Win.Controls.iTextBox();
            this.rtbDescription = new Scalable.Win.Controls.iRichTextBox();
            this.lblDescription = new Scalable.Win.Controls.iLabel();
            this.btnSave = new Scalable.Win.Controls.iCommandButton();
            this.btnCancel = new Scalable.Win.Controls.iCommandButton();
            this.btnSpellCheck = new Scalable.Win.Controls.iCommandButton();
            this.txbAssignedBy = new Scalable.Win.Controls.iTextBoxButton();
            this.lblAssignedBy = new Scalable.Win.Controls.iLabel();
            this.btnCcTo = new Scalable.Win.Controls.iCommandButton();
            this.lblCcTo = new Scalable.Win.Controls.iLabel();
            this.txtCcTo = new Scalable.Win.Controls.iTextBox();
            this.cmbEstimatedTime = new Scalable.Win.Controls.iComboBox();
            this.lblEstimated = new Scalable.Win.Controls.iLabel();
            this.cmbPriority = new Scalable.Win.Controls.iComboBox();
            this.lblPriority = new Scalable.Win.Controls.iLabel();
            this.lblAssignTo = new Scalable.Win.Controls.iLabel();
            this.chkChecklistAppend = new Scalable.Win.Controls.iCheckBox();
            this.lvwChecklistItem = new Scalable.Win.Controls.iListView();
            this.lblProject = new Scalable.Win.Controls.iLabel();
            this.lblChecklist = new Scalable.Win.Controls.iLabel();
            this.cmbChecklist = new Scalable.Win.Controls.iComboBox();
            this.lblLocation = new Scalable.Win.Controls.iLabel();
            this.txtChecklistItem = new Scalable.Win.Controls.iTextBox();
            this.btnAddChecklistItem = new Scalable.Win.Controls.iCommandButton();
            this.lblType = new Scalable.Win.Controls.iLabel();
            this.btnRemoveChecklistItem = new Scalable.Win.Controls.iCommandButton();
            this.cmbLocation = new Scalable.Win.Controls.iComboBox();
            this.cmbTaskType = new Scalable.Win.Controls.iComboBox();
            this.cmbProject = new Scalable.Win.Controls.iComboBox();
            this.pnlAttachments = new Scalable.Win.Controls.iPanel();
            this.btnRemoveAttachment = new Scalable.Win.Controls.iCommandButton();
            this.btnAddAttachment = new Scalable.Win.Controls.iCommandButton();
            this.lvwAttachments = new Scalable.Win.Controls.iListView();
            this.chkIsLink = new Scalable.Win.Controls.iCheckBox();
            this.txtPath = new Scalable.Win.Controls.iTextBox();
            this.lblPath = new Scalable.Win.Controls.iLabel();
            this.txtAttachment = new Scalable.Win.Controls.iTextBox();
            this.lblAttachment = new Scalable.Win.Controls.iLabel();
            this.btnBrowseFile = new Scalable.Win.Controls.iCommandButton();
            this.pnlCheckList = new Scalable.Win.Controls.iPanel();
            this.txbAssignTo = new Scalable.Win.Controls.iTextBoxButton();
            this.Splitter3 = new Scalable.Win.Controls.iSplitContainer();
            this.Splitter4 = new Scalable.Win.Controls.iSplitContainer();
            this.Splitter1 = new Scalable.Win.Controls.iSplitContainer();
            this.Splitter2 = new Scalable.Win.Controls.iSplitContainer();
            this.Splitter5 = new Scalable.Win.Controls.iSplitContainer();
            this.CommandBar.SuspendLayout();
            this.pnlAttachments.SuspendLayout();
            this.pnlCheckList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Splitter3)).BeginInit();
            this.Splitter3.Panel1.SuspendLayout();
            this.Splitter3.Panel2.SuspendLayout();
            this.Splitter3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Splitter4)).BeginInit();
            this.Splitter4.Panel1.SuspendLayout();
            this.Splitter4.Panel2.SuspendLayout();
            this.Splitter4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Splitter1)).BeginInit();
            this.Splitter1.Panel1.SuspendLayout();
            this.Splitter1.Panel2.SuspendLayout();
            this.Splitter1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Splitter2)).BeginInit();
            this.Splitter2.Panel1.SuspendLayout();
            this.Splitter2.Panel2.SuspendLayout();
            this.Splitter2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Splitter5)).BeginInit();
            this.Splitter5.Panel1.SuspendLayout();
            this.Splitter5.Panel2.SuspendLayout();
            this.Splitter5.SuspendLayout();
            this.SuspendLayout();
            // 
            // CommandBar
            // 
            this.CommandBar.Controls.Add(this.btnSpellCheck);
            this.CommandBar.Controls.Add(this.btnCancel);
            this.CommandBar.Controls.Add(this.btnSave);
            this.CommandBar.Location = new System.Drawing.Point(-1, 383);
            this.CommandBar.Size = new System.Drawing.Size(549, 35);
            this.CommandBar.TabIndex = 6;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(3, 5);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "&Name:";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(68, 2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(339, 20);
            this.txtName.TabIndex = 1;
            this.txtName.Tag = "Name";
            // 
            // lblTag
            // 
            this.lblTag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTag.AutoSize = true;
            this.lblTag.Location = new System.Drawing.Point(409, 5);
            this.lblTag.Name = "lblTag";
            this.lblTag.Size = new System.Drawing.Size(29, 13);
            this.lblTag.TabIndex = 2;
            this.lblTag.Text = "Ta&g:";
            // 
            // txtTag
            // 
            this.txtTag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTag.Location = new System.Drawing.Point(438, 2);
            this.txtTag.Name = "txtTag";
            this.txtTag.Size = new System.Drawing.Size(107, 20);
            this.txtTag.TabIndex = 3;
            this.txtTag.Tag = "Tag";
            // 
            // rtbDescription
            // 
            this.rtbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbDescription.Location = new System.Drawing.Point(4, 43);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.ShowSelectionMargin = true;
            this.rtbDescription.Size = new System.Drawing.Size(542, 120);
            this.rtbDescription.TabIndex = 5;
            this.rtbDescription.Tag = "Template";
            this.rtbDescription.Text = "";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(3, 27);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(63, 13);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "&Description:";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSave.Location = new System.Drawing.Point(195, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.Location = new System.Drawing.Point(276, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txbAssignedBy
            // 
            this.txbAssignedBy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbAssignedBy.Location = new System.Drawing.Point(68, 0);
            this.txbAssignedBy.Name = "txbAssignedBy";
            this.txbAssignedBy.SearchProperty = "Name";
            this.txbAssignedBy.Size = new System.Drawing.Size(205, 20);
            this.txbAssignedBy.TabIndex = 27;
            // 
            // lblAssignedBy
            // 
            this.lblAssignedBy.AutoSize = true;
            this.lblAssignedBy.Location = new System.Drawing.Point(3, 3);
            this.lblAssignedBy.Name = "lblAssignedBy";
            this.lblAssignedBy.Size = new System.Drawing.Size(67, 13);
            this.lblAssignedBy.TabIndex = 26;
            this.lblAssignedBy.Text = "Assigned &by:";
            // 
            // btnCcTo
            // 
            this.btnCcTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCcTo.Image = ((System.Drawing.Image)(resources.GetObject("btnCcTo.Image")));
            this.btnCcTo.Location = new System.Drawing.Point(158, -1);
            this.btnCcTo.Name = "btnCcTo";
            this.btnCcTo.Size = new System.Drawing.Size(23, 22);
            this.btnCcTo.TabIndex = 25;
            this.btnCcTo.UseVisualStyleBackColor = true;
            this.btnCcTo.Click += new System.EventHandler(this.btnCcTo_Click);
            // 
            // lblCcTo
            // 
            this.lblCcTo.AutoSize = true;
            this.lblCcTo.Location = new System.Drawing.Point(1, 3);
            this.lblCcTo.Name = "lblCcTo";
            this.lblCcTo.Size = new System.Drawing.Size(40, 13);
            this.lblCcTo.TabIndex = 23;
            this.lblCcTo.Text = "CC T&o:";
            // 
            // txtCcTo
            // 
            this.txtCcTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCcTo.AutoCasing = Scalable.Shared.Enums.TextCaseStyle.Proper;
            this.txtCcTo.BackColor = System.Drawing.SystemColors.Control;
            this.txtCcTo.Location = new System.Drawing.Point(55, 0);
            this.txtCcTo.MaxLength = 70;
            this.txtCcTo.Name = "txtCcTo";
            this.txtCcTo.ReadOnly = true;
            this.txtCcTo.Size = new System.Drawing.Size(103, 20);
            this.txtCcTo.TabIndex = 24;
            // 
            // cmbEstimatedTime
            // 
            this.cmbEstimatedTime.BackColor = System.Drawing.Color.White;
            this.cmbEstimatedTime.FormattingEnabled = true;
            this.cmbEstimatedTime.Location = new System.Drawing.Point(68, 0);
            this.cmbEstimatedTime.MaxLength = 15;
            this.cmbEstimatedTime.Name = "cmbEstimatedTime";
            this.cmbEstimatedTime.Size = new System.Drawing.Size(123, 21);
            this.cmbEstimatedTime.TabIndex = 20;
            // 
            // lblEstimated
            // 
            this.lblEstimated.AutoSize = true;
            this.lblEstimated.Location = new System.Drawing.Point(3, 3);
            this.lblEstimated.Name = "lblEstimated";
            this.lblEstimated.Size = new System.Drawing.Size(56, 13);
            this.lblEstimated.TabIndex = 19;
            this.lblEstimated.Text = "&Estimated:";
            // 
            // cmbPriority
            // 
            this.cmbPriority.BackColor = System.Drawing.Color.White;
            this.cmbPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPriority.FormattingEnabled = true;
            this.cmbPriority.Location = new System.Drawing.Point(235, 0);
            this.cmbPriority.Name = "cmbPriority";
            this.cmbPriority.Size = new System.Drawing.Size(126, 21);
            this.cmbPriority.TabIndex = 22;
            // 
            // lblPriority
            // 
            this.lblPriority.AutoSize = true;
            this.lblPriority.Location = new System.Drawing.Point(195, 3);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(41, 13);
            this.lblPriority.TabIndex = 21;
            this.lblPriority.Text = "&Priority:";
            // 
            // lblAssignTo
            // 
            this.lblAssignTo.AutoSize = true;
            this.lblAssignTo.Location = new System.Drawing.Point(5, 3);
            this.lblAssignTo.Name = "lblAssignTo";
            this.lblAssignTo.Size = new System.Drawing.Size(53, 13);
            this.lblAssignTo.TabIndex = 29;
            this.lblAssignTo.Text = "Assi&gn to:";
            // 
            // chkChecklistAppend
            // 
            this.chkChecklistAppend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkChecklistAppend.AutoSize = true;
            this.chkChecklistAppend.Location = new System.Drawing.Point(202, 21);
            this.chkChecklistAppend.Name = "chkChecklistAppend";
            this.chkChecklistAppend.Size = new System.Drawing.Size(63, 17);
            this.chkChecklistAppend.TabIndex = 38;
            this.chkChecklistAppend.Text = "&Append";
            this.chkChecklistAppend.UseVisualStyleBackColor = true;
            // 
            // lvwChecklistItem
            // 
            this.lvwChecklistItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwChecklistItem.FullRowSelect = true;
            this.lvwChecklistItem.GridLines = true;
            this.lvwChecklistItem.HideSelection = false;
            this.lvwChecklistItem.Location = new System.Drawing.Point(3, 41);
            this.lvwChecklistItem.MultiSelect = false;
            this.lvwChecklistItem.Name = "lvwChecklistItem";
            this.lvwChecklistItem.Size = new System.Drawing.Size(262, 81);
            this.lvwChecklistItem.TabIndex = 40;
            this.lvwChecklistItem.UseCompatibleStateImageBehavior = false;
            this.lvwChecklistItem.View = System.Windows.Forms.View.Details;
            this.lvwChecklistItem.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvwChecklist_ItemSelectionChanged);
            // 
            // lblProject
            // 
            this.lblProject.AutoSize = true;
            this.lblProject.Location = new System.Drawing.Point(3, 3);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(43, 13);
            this.lblProject.TabIndex = 32;
            this.lblProject.Text = "&Project:";
            // 
            // lblChecklist
            // 
            this.lblChecklist.AutoSize = true;
            this.lblChecklist.Location = new System.Drawing.Point(3, 2);
            this.lblChecklist.Name = "lblChecklist";
            this.lblChecklist.Size = new System.Drawing.Size(53, 13);
            this.lblChecklist.TabIndex = 36;
            this.lblChecklist.Text = "&Checklist:";
            // 
            // cmbChecklist
            // 
            this.cmbChecklist.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbChecklist.BackColor = System.Drawing.Color.White;
            this.cmbChecklist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChecklist.FormattingEnabled = true;
            this.cmbChecklist.Location = new System.Drawing.Point(3, 18);
            this.cmbChecklist.Name = "cmbChecklist";
            this.cmbChecklist.Size = new System.Drawing.Size(196, 21);
            this.cmbChecklist.TabIndex = 37;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(-1, 3);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(51, 13);
            this.lblLocation.TabIndex = 34;
            this.lblLocation.Text = "&Location:";
            // 
            // txtChecklistItem
            // 
            this.txtChecklistItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtChecklistItem.Location = new System.Drawing.Point(3, 124);
            this.txtChecklistItem.Name = "txtChecklistItem";
            this.txtChecklistItem.Size = new System.Drawing.Size(216, 20);
            this.txtChecklistItem.TabIndex = 41;
            // 
            // btnAddChecklistItem
            // 
            this.btnAddChecklistItem.Action = Scalable.Win.Enums.CommandBarAction.Add;
            this.btnAddChecklistItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddChecklistItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddChecklistItem.ForeColor = System.Drawing.Color.Green;
            this.btnAddChecklistItem.Location = new System.Drawing.Point(221, 123);
            this.btnAddChecklistItem.Name = "btnAddChecklistItem";
            this.btnAddChecklistItem.Size = new System.Drawing.Size(21, 21);
            this.btnAddChecklistItem.TabIndex = 42;
            this.btnAddChecklistItem.Text = "+";
            this.btnAddChecklistItem.UseVisualStyleBackColor = false;
            this.btnAddChecklistItem.Click += new System.EventHandler(this.checklistCommandActions);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(0, 3);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(34, 13);
            this.lblType.TabIndex = 30;
            this.lblType.Text = "&Type:";
            // 
            // btnRemoveChecklistItem
            // 
            this.btnRemoveChecklistItem.Action = Scalable.Win.Enums.CommandBarAction.Delete;
            this.btnRemoveChecklistItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveChecklistItem.Enabled = false;
            this.btnRemoveChecklistItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveChecklistItem.ForeColor = System.Drawing.Color.Red;
            this.btnRemoveChecklistItem.Location = new System.Drawing.Point(244, 123);
            this.btnRemoveChecklistItem.Name = "btnRemoveChecklistItem";
            this.btnRemoveChecklistItem.Size = new System.Drawing.Size(21, 21);
            this.btnRemoveChecklistItem.TabIndex = 43;
            this.btnRemoveChecklistItem.Text = "-";
            this.btnRemoveChecklistItem.UseVisualStyleBackColor = false;
            this.btnRemoveChecklistItem.Click += new System.EventHandler(this.checklistCommandActions);
            // 
            // cmbLocation
            // 
            this.cmbLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbLocation.BackColor = System.Drawing.Color.White;
            this.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Location = new System.Drawing.Point(53, 0);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(122, 21);
            this.cmbLocation.TabIndex = 35;
            // 
            // cmbTaskType
            // 
            this.cmbTaskType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTaskType.BackColor = System.Drawing.Color.White;
            this.cmbTaskType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTaskType.FormattingEnabled = true;
            this.cmbTaskType.Location = new System.Drawing.Point(40, 0);
            this.cmbTaskType.Name = "cmbTaskType";
            this.cmbTaskType.Size = new System.Drawing.Size(126, 21);
            this.cmbTaskType.TabIndex = 31;
            // 
            // cmbProject
            // 
            this.cmbProject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbProject.BackColor = System.Drawing.Color.White;
            this.cmbProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProject.FormattingEnabled = true;
            this.cmbProject.Location = new System.Drawing.Point(68, 0);
            this.cmbProject.Name = "cmbProject";
            this.cmbProject.Size = new System.Drawing.Size(126, 21);
            this.cmbProject.TabIndex = 33;
            // 
            // pnlAttachments
            // 
            this.pnlAttachments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlAttachments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAttachments.Controls.Add(this.btnRemoveAttachment);
            this.pnlAttachments.Controls.Add(this.btnAddAttachment);
            this.pnlAttachments.Controls.Add(this.lvwAttachments);
            this.pnlAttachments.Controls.Add(this.chkIsLink);
            this.pnlAttachments.Controls.Add(this.txtPath);
            this.pnlAttachments.Controls.Add(this.lblPath);
            this.pnlAttachments.Controls.Add(this.txtAttachment);
            this.pnlAttachments.Controls.Add(this.lblAttachment);
            this.pnlAttachments.Controls.Add(this.btnBrowseFile);
            this.pnlAttachments.Location = new System.Drawing.Point(2, 0);
            this.pnlAttachments.Name = "pnlAttachments";
            this.pnlAttachments.Size = new System.Drawing.Size(266, 149);
            this.pnlAttachments.TabIndex = 46;
            // 
            // btnRemoveAttachment
            // 
            this.btnRemoveAttachment.Action = Scalable.Win.Enums.CommandBarAction.Delete;
            this.btnRemoveAttachment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveAttachment.Enabled = false;
            this.btnRemoveAttachment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveAttachment.ForeColor = System.Drawing.Color.Red;
            this.btnRemoveAttachment.Location = new System.Drawing.Point(240, 124);
            this.btnRemoveAttachment.Name = "btnRemoveAttachment";
            this.btnRemoveAttachment.Size = new System.Drawing.Size(21, 21);
            this.btnRemoveAttachment.TabIndex = 45;
            this.btnRemoveAttachment.Text = "-";
            this.btnRemoveAttachment.UseVisualStyleBackColor = false;
            this.btnRemoveAttachment.Click += new System.EventHandler(this.attachmentButtonAction_Click);
            // 
            // btnAddAttachment
            // 
            this.btnAddAttachment.Action = Scalable.Win.Enums.CommandBarAction.Add;
            this.btnAddAttachment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddAttachment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddAttachment.ForeColor = System.Drawing.Color.Green;
            this.btnAddAttachment.Location = new System.Drawing.Point(217, 124);
            this.btnAddAttachment.Name = "btnAddAttachment";
            this.btnAddAttachment.Size = new System.Drawing.Size(21, 21);
            this.btnAddAttachment.TabIndex = 44;
            this.btnAddAttachment.Text = "+";
            this.btnAddAttachment.UseVisualStyleBackColor = false;
            this.btnAddAttachment.Click += new System.EventHandler(this.attachmentButtonAction_Click);
            // 
            // lvwAttachments
            // 
            this.lvwAttachments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwAttachments.FullRowSelect = true;
            this.lvwAttachments.GridLines = true;
            this.lvwAttachments.HideSelection = false;
            this.lvwAttachments.Location = new System.Drawing.Point(2, 2);
            this.lvwAttachments.MultiSelect = false;
            this.lvwAttachments.Name = "lvwAttachments";
            this.lvwAttachments.Size = new System.Drawing.Size(260, 99);
            this.lvwAttachments.TabIndex = 40;
            this.lvwAttachments.UseCompatibleStateImageBehavior = false;
            this.lvwAttachments.View = System.Windows.Forms.View.Details;
            this.lvwAttachments.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvwAttachment_ItemSelectionChanged);
            // 
            // chkIsLink
            // 
            this.chkIsLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkIsLink.AutoSize = true;
            this.chkIsLink.Location = new System.Drawing.Point(217, 105);
            this.chkIsLink.Name = "chkIsLink";
            this.chkIsLink.Size = new System.Drawing.Size(53, 17);
            this.chkIsLink.TabIndex = 2;
            this.chkIsLink.Text = "Is &link";
            this.chkIsLink.UseVisualStyleBackColor = true;
            this.chkIsLink.CheckedChanged += new System.EventHandler(this.chkIsLink_CheckedChanged);
            // 
            // txtPath
            // 
            this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath.BackColor = System.Drawing.Color.White;
            this.txtPath.Location = new System.Drawing.Point(66, 125);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(129, 20);
            this.txtPath.TabIndex = 4;
            // 
            // lblPath
            // 
            this.lblPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(3, 128);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(32, 13);
            this.lblPath.TabIndex = 3;
            this.lblPath.Text = "&Path:";
            // 
            // txtAttachment
            // 
            this.txtAttachment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAttachment.Location = new System.Drawing.Point(66, 103);
            this.txtAttachment.Name = "txtAttachment";
            this.txtAttachment.Size = new System.Drawing.Size(148, 20);
            this.txtAttachment.TabIndex = 1;
            // 
            // lblAttachment
            // 
            this.lblAttachment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAttachment.AutoSize = true;
            this.lblAttachment.Location = new System.Drawing.Point(3, 106);
            this.lblAttachment.Name = "lblAttachment";
            this.lblAttachment.Size = new System.Drawing.Size(64, 13);
            this.lblAttachment.TabIndex = 0;
            this.lblAttachment.Text = "&Attachment:";
            // 
            // btnBrowseFile
            // 
            this.btnBrowseFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseFile.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBrowseFile.BackgroundImage")));
            this.btnBrowseFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBrowseFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseFile.Location = new System.Drawing.Point(194, 124);
            this.btnBrowseFile.Name = "btnBrowseFile";
            this.btnBrowseFile.Size = new System.Drawing.Size(21, 21);
            this.btnBrowseFile.TabIndex = 5;
            this.btnBrowseFile.UseVisualStyleBackColor = true;
            this.btnBrowseFile.Click += new System.EventHandler(this.btnBrowseFile_Click);
            // 
            // pnlCheckList
            // 
            this.pnlCheckList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCheckList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCheckList.Controls.Add(this.lblChecklist);
            this.pnlCheckList.Controls.Add(this.btnRemoveChecklistItem);
            this.pnlCheckList.Controls.Add(this.btnAddChecklistItem);
            this.pnlCheckList.Controls.Add(this.txtChecklistItem);
            this.pnlCheckList.Controls.Add(this.chkChecklistAppend);
            this.pnlCheckList.Controls.Add(this.cmbChecklist);
            this.pnlCheckList.Controls.Add(this.lvwChecklistItem);
            this.pnlCheckList.Location = new System.Drawing.Point(3, 0);
            this.pnlCheckList.Name = "pnlCheckList";
            this.pnlCheckList.Size = new System.Drawing.Size(270, 149);
            this.pnlCheckList.TabIndex = 47;
            // 
            // txbAssignTo
            // 
            this.txbAssignTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbAssignTo.Location = new System.Drawing.Point(64, 0);
            this.txbAssignTo.Name = "txbAssignTo";
            this.txbAssignTo.SearchProperty = "Name";
            this.txbAssignTo.Size = new System.Drawing.Size(204, 20);
            this.txbAssignTo.TabIndex = 27;
            // 
            // Splitter3
            // 
            this.Splitter3.Location = new System.Drawing.Point(0, 209);
            this.Splitter3.Name = "Splitter3";
            // 
            // Splitter3.Panel1
            // 
            this.Splitter3.Panel1.Controls.Add(this.cmbProject);
            this.Splitter3.Panel1.Controls.Add(this.lblProject);
            // 
            // Splitter3.Panel2
            // 
            this.Splitter3.Panel2.Controls.Add(this.Splitter4);
            this.Splitter3.Size = new System.Drawing.Size(547, 21);
            this.Splitter3.SplitterDistance = 194;
            this.Splitter3.SplitterWidth = 1;
            this.Splitter3.TabIndex = 48;
            // 
            // Splitter4
            // 
            this.Splitter4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Splitter4.Location = new System.Drawing.Point(0, 0);
            this.Splitter4.Name = "Splitter4";
            // 
            // Splitter4.Panel1
            // 
            this.Splitter4.Panel1.Controls.Add(this.cmbTaskType);
            this.Splitter4.Panel1.Controls.Add(this.lblType);
            // 
            // Splitter4.Panel2
            // 
            this.Splitter4.Panel2.Controls.Add(this.cmbLocation);
            this.Splitter4.Panel2.Controls.Add(this.lblLocation);
            this.Splitter4.Size = new System.Drawing.Size(350, 21);
            this.Splitter4.SplitterDistance = 168;
            this.Splitter4.SplitterWidth = 1;
            this.Splitter4.TabIndex = 0;
            // 
            // Splitter1
            // 
            this.Splitter1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.Splitter1.Location = new System.Drawing.Point(0, 164);
            this.Splitter1.Name = "Splitter1";
            // 
            // Splitter1.Panel1
            // 
            this.Splitter1.Panel1.Controls.Add(this.cmbEstimatedTime);
            this.Splitter1.Panel1.Controls.Add(this.lblEstimated);
            this.Splitter1.Panel1.Controls.Add(this.cmbPriority);
            this.Splitter1.Panel1.Controls.Add(this.lblPriority);
            // 
            // Splitter1.Panel2
            // 
            this.Splitter1.Panel2.Controls.Add(this.lblCcTo);
            this.Splitter1.Panel2.Controls.Add(this.btnCcTo);
            this.Splitter1.Panel2.Controls.Add(this.txtCcTo);
            this.Splitter1.Size = new System.Drawing.Size(547, 21);
            this.Splitter1.SplitterDistance = 361;
            this.Splitter1.SplitterWidth = 1;
            this.Splitter1.TabIndex = 48;
            // 
            // Splitter2
            // 
            this.Splitter2.Location = new System.Drawing.Point(0, 187);
            this.Splitter2.Name = "Splitter2";
            // 
            // Splitter2.Panel1
            // 
            this.Splitter2.Panel1.Controls.Add(this.txbAssignedBy);
            this.Splitter2.Panel1.Controls.Add(this.lblAssignedBy);
            // 
            // Splitter2.Panel2
            // 
            this.Splitter2.Panel2.Controls.Add(this.txbAssignTo);
            this.Splitter2.Panel2.Controls.Add(this.lblAssignTo);
            this.Splitter2.Size = new System.Drawing.Size(547, 20);
            this.Splitter2.SplitterDistance = 273;
            this.Splitter2.SplitterWidth = 1;
            this.Splitter2.TabIndex = 49;
            // 
            // Splitter5
            // 
            this.Splitter5.Location = new System.Drawing.Point(0, 232);
            this.Splitter5.Name = "Splitter5";
            // 
            // Splitter5.Panel1
            // 
            this.Splitter5.Panel1.Controls.Add(this.pnlCheckList);
            // 
            // Splitter5.Panel2
            // 
            this.Splitter5.Panel2.Controls.Add(this.pnlAttachments);
            this.Splitter5.Size = new System.Drawing.Size(547, 150);
            this.Splitter5.SplitterDistance = 273;
            this.Splitter5.SplitterWidth = 1;
            this.Splitter5.TabIndex = 50;
            // 
            // btnSpellCheck
            // 
            this.btnSpellCheck.Image = ((System.Drawing.Image)(resources.GetObject("btnSpellCheck.Image")));
            this.btnSpellCheck.Location = new System.Drawing.Point(6, 5);
            this.btnSpellCheck.Name = "btnSpellCheck";
            this.btnSpellCheck.Size = new System.Drawing.Size(23, 23);
            this.btnSpellCheck.TabIndex = 13;
            this.btnSpellCheck.UseVisualStyleBackColor = true;
            this.btnSpellCheck.Click += new System.EventHandler(this.btnSpellCheck_Click);
            // 
            // UTaskTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Splitter5);
            this.Controls.Add(this.Splitter2);
            this.Controls.Add(this.Splitter1);
            this.Controls.Add(this.Splitter3);
            this.Controls.Add(this.rtbDescription);
            this.Controls.Add(this.txtTag);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblTag);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Name = "UTaskTemplate";
            this.Size = new System.Drawing.Size(547, 417);
            this.Controls.SetChildIndex(this.lblName, 0);
            this.Controls.SetChildIndex(this.txtName, 0);
            this.Controls.SetChildIndex(this.lblTag, 0);
            this.Controls.SetChildIndex(this.lblDescription, 0);
            this.Controls.SetChildIndex(this.txtTag, 0);
            this.Controls.SetChildIndex(this.rtbDescription, 0);
            this.Controls.SetChildIndex(this.CommandBar, 0);
            this.Controls.SetChildIndex(this.Splitter3, 0);
            this.Controls.SetChildIndex(this.Splitter1, 0);
            this.Controls.SetChildIndex(this.Splitter2, 0);
            this.Controls.SetChildIndex(this.Splitter5, 0);
            this.CommandBar.ResumeLayout(false);
            this.pnlAttachments.ResumeLayout(false);
            this.pnlAttachments.PerformLayout();
            this.pnlCheckList.ResumeLayout(false);
            this.pnlCheckList.PerformLayout();
            this.Splitter3.Panel1.ResumeLayout(false);
            this.Splitter3.Panel1.PerformLayout();
            this.Splitter3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Splitter3)).EndInit();
            this.Splitter3.ResumeLayout(false);
            this.Splitter4.Panel1.ResumeLayout(false);
            this.Splitter4.Panel1.PerformLayout();
            this.Splitter4.Panel2.ResumeLayout(false);
            this.Splitter4.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Splitter4)).EndInit();
            this.Splitter4.ResumeLayout(false);
            this.Splitter1.Panel1.ResumeLayout(false);
            this.Splitter1.Panel1.PerformLayout();
            this.Splitter1.Panel2.ResumeLayout(false);
            this.Splitter1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Splitter1)).EndInit();
            this.Splitter1.ResumeLayout(false);
            this.Splitter2.Panel1.ResumeLayout(false);
            this.Splitter2.Panel1.PerformLayout();
            this.Splitter2.Panel2.ResumeLayout(false);
            this.Splitter2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Splitter2)).EndInit();
            this.Splitter2.ResumeLayout(false);
            this.Splitter5.Panel1.ResumeLayout(false);
            this.Splitter5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Splitter5)).EndInit();
            this.Splitter5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Scalable.Win.Controls.iLabel lblName;
        private Scalable.Win.Controls.iTextBox txtName;
        private Scalable.Win.Controls.iLabel lblTag;
        private Scalable.Win.Controls.iTextBox txtTag;
        private Scalable.Win.Controls.iRichTextBox rtbDescription;
        private Scalable.Win.Controls.iLabel lblDescription;
        private Scalable.Win.Controls.iCommandButton btnSave;
        private Scalable.Win.Controls.iCommandButton btnCancel;
        private Scalable.Win.Controls.iCommandButton btnSpellCheck;
        private Scalable.Win.Controls.iTextBoxButton txbAssignedBy;
        private Scalable.Win.Controls.iLabel lblAssignedBy;
        private Scalable.Win.Controls.iCommandButton btnCcTo;
        private Scalable.Win.Controls.iLabel lblCcTo;
        private Scalable.Win.Controls.iTextBox txtCcTo;
        private Scalable.Win.Controls.iComboBox cmbEstimatedTime;
        private Scalable.Win.Controls.iLabel lblEstimated;
        private Scalable.Win.Controls.iComboBox cmbPriority;
        private Scalable.Win.Controls.iLabel lblPriority;
        private Scalable.Win.Controls.iLabel lblAssignTo;
        private Scalable.Win.Controls.iCheckBox chkChecklistAppend;
        private Scalable.Win.Controls.iListView lvwChecklistItem;
        private Scalable.Win.Controls.iLabel lblProject;
        private Scalable.Win.Controls.iLabel lblChecklist;
        private Scalable.Win.Controls.iComboBox cmbChecklist;
        private Scalable.Win.Controls.iLabel lblLocation;
        private Scalable.Win.Controls.iTextBox txtChecklistItem;
        private Scalable.Win.Controls.iCommandButton btnAddChecklistItem;
        private Scalable.Win.Controls.iLabel lblType;
        private Scalable.Win.Controls.iCommandButton btnRemoveChecklistItem;
        private Scalable.Win.Controls.iComboBox cmbLocation;
        private Scalable.Win.Controls.iComboBox cmbTaskType;
        private Scalable.Win.Controls.iComboBox cmbProject;
        private Scalable.Win.Controls.iPanel pnlAttachments;
        private Scalable.Win.Controls.iCheckBox chkIsLink;
        private Scalable.Win.Controls.iTextBox txtPath;
        private Scalable.Win.Controls.iLabel lblPath;
        private Scalable.Win.Controls.iTextBox txtAttachment;
        private Scalable.Win.Controls.iLabel lblAttachment;
        private Scalable.Win.Controls.iCommandButton btnBrowseFile;
        private Scalable.Win.Controls.iListView lvwAttachments;
        private Scalable.Win.Controls.iPanel pnlCheckList;
        private Scalable.Win.Controls.iCommandButton btnRemoveAttachment;
        private Scalable.Win.Controls.iCommandButton btnAddAttachment;
        private Scalable.Win.Controls.iTextBoxButton txbAssignTo;
        private Scalable.Win.Controls.iSplitContainer Splitter3;
        private Scalable.Win.Controls.iSplitContainer Splitter4;
        private Scalable.Win.Controls.iSplitContainer Splitter1;
        private Scalable.Win.Controls.iSplitContainer Splitter2;
        private Scalable.Win.Controls.iSplitContainer Splitter5;
    }
}
