namespace Synergy.UC.Controls
{
    partial class UTaskAdvanced
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
            this.lblChecklist = new Scalable.Win.Controls.iLabel();
            this.lblChecklistItems = new Scalable.Win.Controls.iLabel();
            this.cmbChecklist = new Scalable.Win.Controls.iComboBox();
            this.btnOK = new Scalable.Win.Controls.iCommandButton();
            this.lvwChecklistItem = new Scalable.Win.Controls.iListView();
            this.lblProject = new Scalable.Win.Controls.iLabel();
            this.lblLocation = new Scalable.Win.Controls.iLabel();
            this.lblType = new Scalable.Win.Controls.iLabel();
            this.cmbLocation = new Scalable.Win.Controls.iComboBox();
            this.cmbProject = new Scalable.Win.Controls.iComboBox();
            this.cmbTaskType = new Scalable.Win.Controls.iComboBox();
            this.txtChecklistItem = new Scalable.Win.Controls.iTextBox();
            this.btnAddChecklistItem = new Scalable.Win.Controls.iCommandButton();
            this.btnRemoveChecklistItem = new Scalable.Win.Controls.iCommandButton();
            this.chkChecklistAppend = new Scalable.Win.Controls.iCheckBox();
            this.CommandBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // CommandBar
            // 
            this.CommandBar.Controls.Add(this.btnOK);
            this.CommandBar.Location = new System.Drawing.Point(-1, 183);
            this.CommandBar.Size = new System.Drawing.Size(331, 35);
            this.CommandBar.TabIndex = 14;
            // 
            // lblChecklist
            // 
            this.lblChecklist.AutoSize = true;
            this.lblChecklist.Location = new System.Drawing.Point(133, 0);
            this.lblChecklist.Name = "lblChecklist";
            this.lblChecklist.Size = new System.Drawing.Size(53, 13);
            this.lblChecklist.TabIndex = 6;
            this.lblChecklist.Text = "&Checklist:";
            // 
            // lblChecklistItems
            // 
            this.lblChecklistItems.AutoSize = true;
            this.lblChecklistItems.Location = new System.Drawing.Point(133, 42);
            this.lblChecklistItems.Name = "lblChecklistItems";
            this.lblChecklistItems.Size = new System.Drawing.Size(80, 13);
            this.lblChecklistItems.TabIndex = 9;
            this.lblChecklistItems.Text = "Checklist &items:";
            // 
            // cmbChecklist
            // 
            this.cmbChecklist.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbChecklist.BackColor = System.Drawing.Color.White;
            this.cmbChecklist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChecklist.FormattingEnabled = true;
            this.cmbChecklist.Location = new System.Drawing.Point(133, 16);
            this.cmbChecklist.Name = "cmbChecklist";
            this.cmbChecklist.Size = new System.Drawing.Size(127, 21);
            this.cmbChecklist.TabIndex = 7;
            // 
            // btnOK
            // 
            this.btnOK.Action = Scalable.Win.Enums.CommandBarAction.Add;
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOK.Location = new System.Drawing.Point(122, 5);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(84, 24);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lvwChecklistItem
            // 
            this.lvwChecklistItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwChecklistItem.FullRowSelect = true;
            this.lvwChecklistItem.GridLines = true;
            this.lvwChecklistItem.HideSelection = false;
            this.lvwChecklistItem.Location = new System.Drawing.Point(133, 58);
            this.lvwChecklistItem.MultiSelect = false;
            this.lvwChecklistItem.Name = "lvwChecklistItem";
            this.lvwChecklistItem.Size = new System.Drawing.Size(193, 99);
            this.lvwChecklistItem.TabIndex = 10;
            this.lvwChecklistItem.UseCompatibleStateImageBehavior = false;
            this.lvwChecklistItem.View = System.Windows.Forms.View.Details;
            this.lvwChecklistItem.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvwChecklistItem_ItemSelectionChanged);
            // 
            // lblProject
            // 
            this.lblProject.AutoSize = true;
            this.lblProject.Location = new System.Drawing.Point(3, 42);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(43, 13);
            this.lblProject.TabIndex = 2;
            this.lblProject.Text = "&Project:";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(3, 83);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(51, 13);
            this.lblLocation.TabIndex = 4;
            this.lblLocation.Text = "&Location:";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(3, 0);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(34, 13);
            this.lblType.TabIndex = 0;
            this.lblType.Text = "&Type:";
            // 
            // cmbLocation
            // 
            this.cmbLocation.BackColor = System.Drawing.Color.White;
            this.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Location = new System.Drawing.Point(3, 99);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(126, 21);
            this.cmbLocation.TabIndex = 5;
            // 
            // cmbProject
            // 
            this.cmbProject.BackColor = System.Drawing.Color.White;
            this.cmbProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProject.FormattingEnabled = true;
            this.cmbProject.Location = new System.Drawing.Point(3, 58);
            this.cmbProject.Name = "cmbProject";
            this.cmbProject.Size = new System.Drawing.Size(126, 21);
            this.cmbProject.TabIndex = 3;
            // 
            // cmbTaskType
            // 
            this.cmbTaskType.BackColor = System.Drawing.Color.White;
            this.cmbTaskType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTaskType.FormattingEnabled = true;
            this.cmbTaskType.Location = new System.Drawing.Point(3, 16);
            this.cmbTaskType.Name = "cmbTaskType";
            this.cmbTaskType.Size = new System.Drawing.Size(126, 21);
            this.cmbTaskType.TabIndex = 1;
            // 
            // txtChecklistItem
            // 
            this.txtChecklistItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtChecklistItem.Location = new System.Drawing.Point(133, 160);
            this.txtChecklistItem.Name = "txtChecklistItem";
            this.txtChecklistItem.Size = new System.Drawing.Size(150, 20);
            this.txtChecklistItem.TabIndex = 11;
            // 
            // btnAddChecklistItem
            // 
            this.btnAddChecklistItem.Action = Scalable.Win.Enums.CommandBarAction.Save;
            this.btnAddChecklistItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddChecklistItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddChecklistItem.ForeColor = System.Drawing.Color.Green;
            this.btnAddChecklistItem.Location = new System.Drawing.Point(285, 160);
            this.btnAddChecklistItem.Name = "btnAddChecklistItem";
            this.btnAddChecklistItem.Size = new System.Drawing.Size(20, 20);
            this.btnAddChecklistItem.TabIndex = 12;
            this.btnAddChecklistItem.Text = "+";
            this.btnAddChecklistItem.UseVisualStyleBackColor = false;
            this.btnAddChecklistItem.Click += new System.EventHandler(this.checklistCommandActions);
            // 
            // btnRemoveChecklistItem
            // 
            this.btnRemoveChecklistItem.Action = Scalable.Win.Enums.CommandBarAction.Delete;
            this.btnRemoveChecklistItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveChecklistItem.Enabled = false;
            this.btnRemoveChecklistItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveChecklistItem.ForeColor = System.Drawing.Color.Red;
            this.btnRemoveChecklistItem.Location = new System.Drawing.Point(306, 160);
            this.btnRemoveChecklistItem.Name = "btnRemoveChecklistItem";
            this.btnRemoveChecklistItem.Size = new System.Drawing.Size(20, 20);
            this.btnRemoveChecklistItem.TabIndex = 13;
            this.btnRemoveChecklistItem.Text = "-";
            this.btnRemoveChecklistItem.UseVisualStyleBackColor = false;
            this.btnRemoveChecklistItem.Click += new System.EventHandler(this.checklistCommandActions);
            // 
            // chkChecklistAppend
            // 
            this.chkChecklistAppend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkChecklistAppend.AutoSize = true;
            this.chkChecklistAppend.Location = new System.Drawing.Point(263, 19);
            this.chkChecklistAppend.Name = "chkChecklistAppend";
            this.chkChecklistAppend.Size = new System.Drawing.Size(63, 17);
            this.chkChecklistAppend.TabIndex = 8;
            this.chkChecklistAppend.Text = "&Append";
            this.chkChecklistAppend.UseVisualStyleBackColor = true;
            // 
            // UTaskAdvanced
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkChecklistAppend);
            this.Controls.Add(this.lvwChecklistItem);
            this.Controls.Add(this.lblProject);
            this.Controls.Add(this.lblChecklist);
            this.Controls.Add(this.lblChecklistItems);
            this.Controls.Add(this.cmbChecklist);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.txtChecklistItem);
            this.Controls.Add(this.btnAddChecklistItem);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.btnRemoveChecklistItem);
            this.Controls.Add(this.cmbLocation);
            this.Controls.Add(this.cmbTaskType);
            this.Controls.Add(this.cmbProject);
            this.MinimumSize = new System.Drawing.Size(329, 217);
            this.Name = "UTaskAdvanced";
            this.Size = new System.Drawing.Size(329, 217);
            this.Controls.SetChildIndex(this.cmbProject, 0);
            this.Controls.SetChildIndex(this.cmbTaskType, 0);
            this.Controls.SetChildIndex(this.cmbLocation, 0);
            this.Controls.SetChildIndex(this.btnRemoveChecklistItem, 0);
            this.Controls.SetChildIndex(this.lblType, 0);
            this.Controls.SetChildIndex(this.btnAddChecklistItem, 0);
            this.Controls.SetChildIndex(this.CommandBar, 0);
            this.Controls.SetChildIndex(this.txtChecklistItem, 0);
            this.Controls.SetChildIndex(this.lblLocation, 0);
            this.Controls.SetChildIndex(this.cmbChecklist, 0);
            this.Controls.SetChildIndex(this.lblChecklistItems, 0);
            this.Controls.SetChildIndex(this.lblChecklist, 0);
            this.Controls.SetChildIndex(this.lblProject, 0);
            this.Controls.SetChildIndex(this.lvwChecklistItem, 0);
            this.Controls.SetChildIndex(this.chkChecklistAppend, 0);
            this.CommandBar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Scalable.Win.Controls.iLabel lblChecklist;
        private Scalable.Win.Controls.iLabel lblChecklistItems;
        private Scalable.Win.Controls.iComboBox cmbChecklist;
        private Scalable.Win.Controls.iCommandButton btnOK;
        private Scalable.Win.Controls.iListView lvwChecklistItem;
        private Scalable.Win.Controls.iTextBox txtChecklistItem;
        private Scalable.Win.Controls.iCommandButton btnAddChecklistItem;
        private Scalable.Win.Controls.iCommandButton btnRemoveChecklistItem;
        private Scalable.Win.Controls.iComboBox cmbLocation;
        private Scalable.Win.Controls.iComboBox cmbProject;
        private Scalable.Win.Controls.iComboBox cmbTaskType;
        private Scalable.Win.Controls.iLabel lblProject;
        private Scalable.Win.Controls.iLabel lblLocation;
        private Scalable.Win.Controls.iLabel lblType;
        private Scalable.Win.Controls.iCheckBox chkChecklistAppend;
    }
}
