namespace Mingle.UC.Controls
{
    partial class UPartyIMs
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
            this.lblIMName = new Scalable.Win.Controls.iLabel();
            this.txtIMId = new Scalable.Win.Controls.iTextBox();
            this.lblIMId = new Scalable.Win.Controls.iLabel();
            this.cmbIMName = new Scalable.Win.Controls.iComboBox();
            this.btnDelete = new Scalable.Win.Controls.iCommandButton();
            this.ListView = new Scalable.Win.Controls.iListView();
            this.CommandBar = new Scalable.Win.Controls.iCommandBar();
            this.chkIsActive = new Scalable.Win.Controls.iCheckBox();
            this.btnPreferred = new Scalable.Win.Controls.iCommandButton();
            this.btnAdd = new Scalable.Win.Controls.iCommandButton();
            this.btnUpdate = new Scalable.Win.Controls.iCommandButton();
            this.cmbTitle = new Scalable.Win.Controls.iComboBox();
            this.lblTitle = new Scalable.Win.Controls.iLabel();
            this.IMCommandBar = new Scalable.Win.Controls.iCommandBar();
            this.CommandBar.SuspendLayout();
            this.IMCommandBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblIMName
            // 
            this.lblIMName.AutoSize = true;
            this.lblIMName.Location = new System.Drawing.Point(153, 5);
            this.lblIMName.Name = "lblIMName";
            this.lblIMName.Size = new System.Drawing.Size(62, 13);
            this.lblIMName.TabIndex = 2;
            this.lblIMName.Text = "Messenger:";
            // 
            // txtIMId
            // 
            this.txtIMId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIMId.Location = new System.Drawing.Point(34, 25);
            this.txtIMId.Name = "txtIMId";
            this.txtIMId.Size = new System.Drawing.Size(271, 20);
            this.txtIMId.TabIndex = 5;
            // 
            // lblIMId
            // 
            this.lblIMId.AutoSize = true;
            this.lblIMId.Location = new System.Drawing.Point(3, 28);
            this.lblIMId.Name = "lblIMId";
            this.lblIMId.Size = new System.Drawing.Size(21, 13);
            this.lblIMId.TabIndex = 4;
            this.lblIMId.Text = "ID:";
            // 
            // cmbIMName
            // 
            this.cmbIMName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbIMName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbIMName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbIMName.FormattingEnabled = true;
            this.cmbIMName.Location = new System.Drawing.Point(217, 2);
            this.cmbIMName.Name = "cmbIMName";
            this.cmbIMName.Size = new System.Drawing.Size(88, 21);
            this.cmbIMName.TabIndex = 3;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(2, 1);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(60, 23);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // ListView
            // 
            this.ListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ListView.FullRowSelect = true;
            this.ListView.GridLines = true;
            this.ListView.HideSelection = false;
            this.ListView.Location = new System.Drawing.Point(2, 53);
            this.ListView.MultiSelect = false;
            this.ListView.Name = "ListView";
            this.ListView.Size = new System.Drawing.Size(304, 66);
            this.ListView.TabIndex = 1;
            this.ListView.UseCompatibleStateImageBehavior = false;
            this.ListView.View = System.Windows.Forms.View.Details;
            this.ListView.SelectedIndexChanged += new System.EventHandler(this.lvw_SelectedIndexChanged);
            // 
            // CommandBar
            // 
            this.CommandBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CommandBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CommandBar.Controls.Add(this.btnDelete);
            this.CommandBar.Controls.Add(this.chkIsActive);
            this.CommandBar.Controls.Add(this.btnPreferred);
            this.CommandBar.Location = new System.Drawing.Point(308, 53);
            this.CommandBar.Name = "CommandBar";
            this.CommandBar.Size = new System.Drawing.Size(66, 66);
            this.CommandBar.TabIndex = 2;
            // 
            // chkIsActive
            // 
            this.chkIsActive.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Checked = true;
            this.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsActive.Enabled = false;
            this.chkIsActive.Location = new System.Drawing.Point(3, 47);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(66, 17);
            this.chkIsActive.TabIndex = 2;
            this.chkIsActive.Text = "&Is active";
            this.chkIsActive.UseVisualStyleBackColor = true;
            this.chkIsActive.Click += new System.EventHandler(this.chkIsActive_CheckedChanged);
            // 
            // btnPreferred
            // 
            this.btnPreferred.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnPreferred.Enabled = false;
            this.btnPreferred.Location = new System.Drawing.Point(2, 24);
            this.btnPreferred.Name = "btnPreferred";
            this.btnPreferred.Size = new System.Drawing.Size(60, 23);
            this.btnPreferred.TabIndex = 1;
            this.btnPreferred.Text = "&Preferred";
            this.btnPreferred.UseVisualStyleBackColor = true;
            this.btnPreferred.Click += new System.EventHandler(this.btnPreferred_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(308, 1);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(60, 23);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Location = new System.Drawing.Point(308, 24);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(60, 22);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "&Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // cmbTitle
            // 
            this.cmbTitle.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTitle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTitle.FormattingEnabled = true;
            this.cmbTitle.Location = new System.Drawing.Point(34, 2);
            this.cmbTitle.Name = "cmbTitle";
            this.cmbTitle.Size = new System.Drawing.Size(119, 21);
            this.cmbTitle.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(3, 5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(30, 13);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Title:";
            // 
            // IMCommandBar
            // 
            this.IMCommandBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.IMCommandBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IMCommandBar.Controls.Add(this.cmbTitle);
            this.IMCommandBar.Controls.Add(this.lblIMId);
            this.IMCommandBar.Controls.Add(this.txtIMId);
            this.IMCommandBar.Controls.Add(this.btnAdd);
            this.IMCommandBar.Controls.Add(this.lblIMName);
            this.IMCommandBar.Controls.Add(this.btnUpdate);
            this.IMCommandBar.Controls.Add(this.lblTitle);
            this.IMCommandBar.Controls.Add(this.cmbIMName);
            this.IMCommandBar.Location = new System.Drawing.Point(2, 2);
            this.IMCommandBar.Name = "IMCommandBar";
            this.IMCommandBar.Size = new System.Drawing.Size(372, 49);
            this.IMCommandBar.TabIndex = 0;
            // 
            // UPartyIMs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.IMCommandBar);
            this.Controls.Add(this.ListView);
            this.Controls.Add(this.CommandBar);
            this.MinimumSize = new System.Drawing.Size(378, 122);
            this.Name = "UPartyIMs";
            this.Size = new System.Drawing.Size(378, 122);
            this.CommandBar.ResumeLayout(false);
            this.CommandBar.PerformLayout();
            this.IMCommandBar.ResumeLayout(false);
            this.IMCommandBar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Scalable.Win.Controls.iLabel lblIMName;
        private Scalable.Win.Controls.iTextBox txtIMId;
        private Scalable.Win.Controls.iLabel lblIMId;
        private Scalable.Win.Controls.iComboBox cmbIMName;
        private Scalable.Win.Controls.iCommandButton btnDelete;
        private Scalable.Win.Controls.iListView ListView;
        private Scalable.Win.Controls.iCommandBar CommandBar;
        private Scalable.Win.Controls.iCheckBox chkIsActive;
        private Scalable.Win.Controls.iCommandButton btnPreferred;
        private Scalable.Win.Controls.iCommandButton btnAdd;
        private Scalable.Win.Controls.iCommandButton btnUpdate;
        private Scalable.Win.Controls.iComboBox cmbTitle;
        private Scalable.Win.Controls.iLabel lblTitle;
        private Scalable.Win.Controls.iCommandBar IMCommandBar;
    }
}
