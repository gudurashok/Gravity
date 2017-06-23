namespace Mingle.UC.Controls
{
    partial class UPartyRelations
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
            this.txbContacts = new Scalable.Win.Controls.iTextBoxButton();
            this.lblContact = new Scalable.Win.Controls.iLabel();
            this.btnAdd = new Scalable.Win.Controls.iCommandButton();
            this.btnDelete = new Scalable.Win.Controls.iCommandButton();
            this.lblRelationType = new Scalable.Win.Controls.iLabel();
            this.btnUpdate = new Scalable.Win.Controls.iCommandButton();
            this.cmbRelationType = new Scalable.Win.Controls.iComboBox();
            this.CommandBar = new Scalable.Win.Controls.iCommandBar();
            this.ListView = new Scalable.Win.Controls.iListView();
            this.CommandBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // txbContacts
            // 
            this.txbContacts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbContacts.Location = new System.Drawing.Point(50, 2);
            this.txbContacts.Name = "txbContacts";
            this.txbContacts.SearchProperty = "Name";
            this.txbContacts.Size = new System.Drawing.Size(213, 20);
            this.txbContacts.TabIndex = 1;
            // 
            // lblContact
            // 
            this.lblContact.AutoSize = true;
            this.lblContact.Location = new System.Drawing.Point(0, 5);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(47, 13);
            this.lblContact.TabIndex = 0;
            this.lblContact.Text = "Contact:";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(163, 23);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(50, 23);
            this.btnAdd.TabIndex = 4;
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
            // lblRelationType
            // 
            this.lblRelationType.AutoSize = true;
            this.lblRelationType.Location = new System.Drawing.Point(0, 28);
            this.lblRelationType.Name = "lblRelationType";
            this.lblRelationType.Size = new System.Drawing.Size(49, 13);
            this.lblRelationType.TabIndex = 2;
            this.lblRelationType.Text = "Relation:";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Location = new System.Drawing.Point(214, 23);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(50, 23);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "&Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // cmbRelationType
            // 
            this.cmbRelationType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbRelationType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbRelationType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbRelationType.FormattingEnabled = true;
            this.cmbRelationType.Location = new System.Drawing.Point(50, 24);
            this.cmbRelationType.Name = "cmbRelationType";
            this.cmbRelationType.Size = new System.Drawing.Size(111, 21);
            this.cmbRelationType.TabIndex = 3;
            // 
            // CommandBar
            // 
            this.CommandBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CommandBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CommandBar.Controls.Add(this.btnDelete);
            this.CommandBar.Location = new System.Drawing.Point(197, 47);
            this.CommandBar.Name = "CommandBar";
            this.CommandBar.Size = new System.Drawing.Size(66, 79);
            this.CommandBar.TabIndex = 7;
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
            this.ListView.Location = new System.Drawing.Point(2, 47);
            this.ListView.MultiSelect = false;
            this.ListView.Name = "ListView";
            this.ListView.Size = new System.Drawing.Size(193, 79);
            this.ListView.TabIndex = 6;
            this.ListView.UseCompatibleStateImageBehavior = false;
            this.ListView.View = System.Windows.Forms.View.Details;
            this.ListView.SelectedIndexChanged += new System.EventHandler(this.lvw_SelectedIndexChanged);
            // 
            // UPartyRelations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ListView);
            this.Controls.Add(this.CommandBar);
            this.Controls.Add(this.txbContacts);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lblContact);
            this.Controls.Add(this.cmbRelationType);
            this.Controls.Add(this.lblRelationType);
            this.MinimumSize = new System.Drawing.Size(266, 128);
            this.Name = "UPartyRelations";
            this.Size = new System.Drawing.Size(266, 128);
            this.CommandBar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Scalable.Win.Controls.iTextBoxButton txbContacts;
        private Scalable.Win.Controls.iLabel lblContact;
        private Scalable.Win.Controls.iCommandButton btnAdd;
        private Scalable.Win.Controls.iCommandButton btnDelete;
        private Scalable.Win.Controls.iLabel lblRelationType;
        private Scalable.Win.Controls.iCommandButton btnUpdate;
        private Scalable.Win.Controls.iComboBox cmbRelationType;
        private Scalable.Win.Controls.iCommandBar CommandBar;
        private Scalable.Win.Controls.iListView ListView;
    }
}
