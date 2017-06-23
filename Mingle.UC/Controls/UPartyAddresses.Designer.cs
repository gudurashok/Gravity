namespace Mingle.UC.Controls
{
    partial class UPartyAddresses
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
            this.btnAdd = new Scalable.Win.Controls.iCommandButton();
            this.btnDelete = new Scalable.Win.Controls.iCommandButton();
            this.btnUpdate = new Scalable.Win.Controls.iCommandButton();
            this.btnPreferred = new Scalable.Win.Controls.iCommandButton();
            this.lblTitle = new Scalable.Win.Controls.iLabel();
            this.cmbTitle = new Scalable.Win.Controls.iComboBox();
            this.chkIsActive = new Scalable.Win.Controls.iCheckBox();
            this.lblUsageType = new Scalable.Win.Controls.iLabel();
            this.cmbUsageType = new Scalable.Win.Controls.iComboBox();
            this.addressCommandBar = new Scalable.Win.Controls.iCommandBar();
            this.uAddress = new Mingle.UC.Controls.UAddress();
            this.ListView = new Scalable.Win.Controls.iListView();
            this.CommandBar = new Scalable.Win.Controls.iCommandBar();
            this.addressCommandBar.SuspendLayout();
            this.CommandBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAdd.Location = new System.Drawing.Point(125, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(60, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
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
            // btnUpdate
            // 
            this.btnUpdate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Location = new System.Drawing.Point(190, 4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(60, 23);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "&Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
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
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(0, 5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(30, 13);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "&Title:";
            // 
            // cmbTitle
            // 
            this.cmbTitle.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTitle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTitle.FormattingEnabled = true;
            this.cmbTitle.Location = new System.Drawing.Point(52, 2);
            this.cmbTitle.Name = "cmbTitle";
            this.cmbTitle.Size = new System.Drawing.Size(170, 21);
            this.cmbTitle.TabIndex = 1;
            // 
            // chkIsActive
            // 
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
            this.chkIsActive.CheckedChanged += new System.EventHandler(this.chkIsActive_CheckedChanged);
            // 
            // lblUsageType
            // 
            this.lblUsageType.AutoSize = true;
            this.lblUsageType.Location = new System.Drawing.Point(226, 6);
            this.lblUsageType.Name = "lblUsageType";
            this.lblUsageType.Size = new System.Drawing.Size(64, 13);
            this.lblUsageType.TabIndex = 2;
            this.lblUsageType.Text = "&Usage type:";
            // 
            // cmbUsageType
            // 
            this.cmbUsageType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbUsageType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbUsageType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbUsageType.FormattingEnabled = true;
            this.cmbUsageType.Location = new System.Drawing.Point(292, 2);
            this.cmbUsageType.Name = "cmbUsageType";
            this.cmbUsageType.Size = new System.Drawing.Size(80, 21);
            this.cmbUsageType.TabIndex = 3;
            // 
            // addressCommandBar
            // 
            this.addressCommandBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addressCommandBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.addressCommandBar.Controls.Add(this.btnAdd);
            this.addressCommandBar.Controls.Add(this.btnUpdate);
            this.addressCommandBar.Location = new System.Drawing.Point(-1, 165);
            this.addressCommandBar.Name = "addressCommandBar";
            this.addressCommandBar.Size = new System.Drawing.Size(377, 33);
            this.addressCommandBar.TabIndex = 5;
            // 
            // uAddress
            // 
            this.uAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uAddress.Location = new System.Drawing.Point(-3, 22);
            this.uAddress.Name = "uAddress";
            this.uAddress.Size = new System.Drawing.Size(378, 145);
            this.uAddress.TabIndex = 4;
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
            this.ListView.Location = new System.Drawing.Point(2, 200);
            this.ListView.MultiSelect = false;
            this.ListView.Name = "ListView";
            this.ListView.Size = new System.Drawing.Size(302, 66);
            this.ListView.TabIndex = 6;
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
            this.CommandBar.Controls.Add(this.btnPreferred);
            this.CommandBar.Controls.Add(this.chkIsActive);
            this.CommandBar.Location = new System.Drawing.Point(306, 200);
            this.CommandBar.Name = "CommandBar";
            this.CommandBar.Size = new System.Drawing.Size(66, 66);
            this.CommandBar.TabIndex = 7;
            // 
            // UPartyAddresses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CommandBar);
            this.Controls.Add(this.ListView);
            this.Controls.Add(this.addressCommandBar);
            this.Controls.Add(this.cmbTitle);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.cmbUsageType);
            this.Controls.Add(this.lblUsageType);
            this.Controls.Add(this.uAddress);
            this.MinimumSize = new System.Drawing.Size(375, 240);
            this.Name = "UPartyAddresses";
            this.Size = new System.Drawing.Size(375, 268);
            this.addressCommandBar.ResumeLayout(false);
            this.CommandBar.ResumeLayout(false);
            this.CommandBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Scalable.Win.Controls.iCommandButton btnAdd;
        private Scalable.Win.Controls.iCommandButton btnDelete;
        private Scalable.Win.Controls.iCommandButton btnUpdate;
        private Scalable.Win.Controls.iCommandButton btnPreferred;
        private Scalable.Win.Controls.iLabel lblTitle;
        private Scalable.Win.Controls.iComboBox cmbTitle;
        private Scalable.Win.Controls.iCheckBox chkIsActive;
        private Scalable.Win.Controls.iLabel lblUsageType;
        private Scalable.Win.Controls.iComboBox cmbUsageType;
        private UAddress uAddress;
        private Scalable.Win.Controls.iCommandBar addressCommandBar;
        private Scalable.Win.Controls.iListView ListView;
        private Scalable.Win.Controls.iCommandBar CommandBar;
    }
}
