namespace Synergy.UC.Controls
{
    partial class UFileAttachment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UFileAttachment));
            this.txtFullName = new Scalable.Win.Controls.iTextBox();
            this.btnBrowseFile = new Scalable.Win.Controls.iCommandButton();
            this.btnNew = new Scalable.Win.Controls.iCommandButton();
            this.btnDelete = new Scalable.Win.Controls.iCommandButton();
            this.pnlFileDetails = new Scalable.Win.Controls.iPanel();
            this.chkIsLink = new Scalable.Win.Controls.iCheckBox();
            this.btnAdd = new Scalable.Win.Controls.iCommandButton();
            this.chkEmbedded = new Scalable.Win.Controls.iCheckBox();
            this.txtPath = new Scalable.Win.Controls.iTextBox();
            this.btnCancel = new Scalable.Win.Controls.iCommandButton();
            this.lblPath = new Scalable.Win.Controls.iLabel();
            this.txtName = new Scalable.Win.Controls.iTextBox();
            this.lblName = new Scalable.Win.Controls.iLabel();
            this.lblFullName = new Scalable.Win.Controls.iLabel();
            this.btnSave = new Scalable.Win.Controls.iCommandButton();
            this.btnEdit = new Scalable.Win.Controls.iCommandButton();
            this.CommandBar.SuspendLayout();
            this.pnlFileDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(325, 5);
            // 
            // btnOpen
            // 
            this.btnOpen.Enabled = false;
            this.btnOpen.Location = new System.Drawing.Point(325, 5);
            // 
            // txt
            // 
            this.txt.Location = new System.Drawing.Point(3, 2);
            this.txt.Size = new System.Drawing.Size(400, 20);
            // 
            // lvw
            // 
            this.lvw.Location = new System.Drawing.Point(3, 24);
            this.lvw.Size = new System.Drawing.Size(400, 103);
            this.lvw.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvw_ItemSelectionChanged);
            // 
            // CommandBar
            // 
            this.CommandBar.Controls.Add(this.btnEdit);
            this.CommandBar.Controls.Add(this.btnNew);
            this.CommandBar.Controls.Add(this.btnSave);
            this.CommandBar.Controls.Add(this.btnDelete);
            this.CommandBar.Location = new System.Drawing.Point(-1, 228);
            this.CommandBar.Size = new System.Drawing.Size(408, 35);
            this.CommandBar.TabIndex = 5;
            this.CommandBar.Controls.SetChildIndex(this.btnOK, 0);
            this.CommandBar.Controls.SetChildIndex(this.btnOpen, 0);
            this.CommandBar.Controls.SetChildIndex(this.btnDelete, 0);
            this.CommandBar.Controls.SetChildIndex(this.btnSave, 0);
            this.CommandBar.Controls.SetChildIndex(this.btnNew, 0);
            this.CommandBar.Controls.SetChildIndex(this.btnEdit, 0);
            // 
            // txtFullName
            // 
            this.txtFullName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFullName.BackColor = System.Drawing.Color.White;
            this.txtFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFullName.Location = new System.Drawing.Point(65, 129);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.ReadOnly = true;
            this.txtFullName.Size = new System.Drawing.Size(338, 20);
            this.txtFullName.TabIndex = 3;
            // 
            // btnBrowseFile
            // 
            this.btnBrowseFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseFile.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBrowseFile.BackgroundImage")));
            this.btnBrowseFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBrowseFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseFile.Location = new System.Drawing.Point(374, 23);
            this.btnBrowseFile.Name = "btnBrowseFile";
            this.btnBrowseFile.Size = new System.Drawing.Size(24, 22);
            this.btnBrowseFile.TabIndex = 5;
            this.btnBrowseFile.UseVisualStyleBackColor = true;
            this.btnBrowseFile.Click += new System.EventHandler(this.btnBrowseFile_Click);
            // 
            // btnNew
            // 
            this.btnNew.Action = Scalable.Win.Enums.CommandBarAction.New;
            this.btnNew.Location = new System.Drawing.Point(6, 5);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 1;
            this.btnNew.Text = "&New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.commandButtonAction_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Action = Scalable.Win.Enums.CommandBarAction.Delete;
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(166, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.commandButtonAction_Click);
            // 
            // pnlFileDetails
            // 
            this.pnlFileDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFileDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFileDetails.Controls.Add(this.chkIsLink);
            this.pnlFileDetails.Controls.Add(this.btnAdd);
            this.pnlFileDetails.Controls.Add(this.chkEmbedded);
            this.pnlFileDetails.Controls.Add(this.txtPath);
            this.pnlFileDetails.Controls.Add(this.btnCancel);
            this.pnlFileDetails.Controls.Add(this.lblPath);
            this.pnlFileDetails.Controls.Add(this.txtName);
            this.pnlFileDetails.Controls.Add(this.lblName);
            this.pnlFileDetails.Controls.Add(this.btnBrowseFile);
            this.pnlFileDetails.Location = new System.Drawing.Point(3, 151);
            this.pnlFileDetails.Name = "pnlFileDetails";
            this.pnlFileDetails.Size = new System.Drawing.Size(400, 75);
            this.pnlFileDetails.TabIndex = 6;
            // 
            // chkIsLink
            // 
            this.chkIsLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkIsLink.AutoSize = true;
            this.chkIsLink.Location = new System.Drawing.Point(345, 3);
            this.chkIsLink.Name = "chkIsLink";
            this.chkIsLink.Size = new System.Drawing.Size(57, 17);
            this.chkIsLink.TabIndex = 2;
            this.chkIsLink.Text = "Is &Link";
            this.chkIsLink.UseVisualStyleBackColor = true;
            this.chkIsLink.CheckedChanged += new System.EventHandler(this.chkIsLink_CheckedChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Action = Scalable.Win.Enums.CommandBarAction.Add;
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAdd.Location = new System.Drawing.Point(121, 47);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.commandButtonAction_Click);
            // 
            // chkEmbedded
            // 
            this.chkEmbedded.AutoSize = true;
            this.chkEmbedded.Enabled = false;
            this.chkEmbedded.Location = new System.Drawing.Point(61, 51);
            this.chkEmbedded.Name = "chkEmbedded";
            this.chkEmbedded.Size = new System.Drawing.Size(77, 17);
            this.chkEmbedded.TabIndex = 6;
            this.chkEmbedded.Text = "&Embedded";
            this.chkEmbedded.UseVisualStyleBackColor = true;
            // 
            // txtPath
            // 
            this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath.BackColor = System.Drawing.Color.White;
            this.txtPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPath.Location = new System.Drawing.Point(61, 24);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(315, 20);
            this.txtPath.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.Action = Scalable.Win.Enums.CommandBarAction.Cancel;
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.Location = new System.Drawing.Point(202, 47);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.commandButtonAction_Click);
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(3, 27);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(32, 13);
            this.lblPath.TabIndex = 3;
            this.lblPath.Text = "&Path:";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Location = new System.Drawing.Point(61, 2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(278, 20);
            this.txtName.TabIndex = 1;
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
            // lblFullName
            // 
            this.lblFullName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFullName.AutoSize = true;
            this.lblFullName.Location = new System.Drawing.Point(7, 132);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(55, 13);
            this.lblFullName.TabIndex = 2;
            this.lblFullName.Text = "&Full name:";
            // 
            // btnSave
            // 
            this.btnSave.Action = Scalable.Win.Enums.CommandBarAction.Save;
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSave.Location = new System.Drawing.Point(245, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.commandButtonAction_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Action = Scalable.Win.Enums.CommandBarAction.Edit;
            this.btnEdit.Enabled = false;
            this.btnEdit.Location = new System.Drawing.Point(87, 5);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "&Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.commandButtonAction_Click);
            // 
            // UFileAttachment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlFileDetails);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.txtFullName);
            this.MinimumSize = new System.Drawing.Size(406, 262);
            this.Name = "UFileAttachment";
            this.Size = new System.Drawing.Size(406, 262);
            this.Controls.SetChildIndex(this.txt, 0);
            this.Controls.SetChildIndex(this.txtFullName, 0);
            this.Controls.SetChildIndex(this.lblFullName, 0);
            this.Controls.SetChildIndex(this.pnlFileDetails, 0);
            this.Controls.SetChildIndex(this.lvw, 0);
            this.Controls.SetChildIndex(this.CommandBar, 0);
            this.CommandBar.ResumeLayout(false);
            this.pnlFileDetails.ResumeLayout(false);
            this.pnlFileDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Scalable.Win.Controls.iTextBox txtFullName;
        private Scalable.Win.Controls.iCommandButton btnBrowseFile;
        private Scalable.Win.Controls.iCommandButton btnNew;
        private Scalable.Win.Controls.iCommandButton btnDelete;
        private Scalable.Win.Controls.iPanel pnlFileDetails;
        private Scalable.Win.Controls.iTextBox txtName;
        private Scalable.Win.Controls.iLabel lblName;
        private Scalable.Win.Controls.iLabel lblFullName;
        private Scalable.Win.Controls.iTextBox txtPath;
        private Scalable.Win.Controls.iLabel lblPath;
        private Scalable.Win.Controls.iCheckBox chkEmbedded;
        private Scalable.Win.Controls.iCommandButton btnSave;
        private Scalable.Win.Controls.iCommandButton btnCancel;
        private Scalable.Win.Controls.iCommandButton btnEdit;
        private Scalable.Win.Controls.iCheckBox chkIsLink;
        private Scalable.Win.Controls.iCommandButton btnAdd;
    }
}
