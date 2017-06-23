using System.Windows.Forms;

namespace Mingle.UC.Controls
{
    partial class UPartyBasic
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
            this.txbGroup = new Scalable.Win.Controls.iTextBoxButton();
            this.lblPartyType = new Scalable.Win.Controls.iLabel();
            this.lblGroup = new Scalable.Win.Controls.iLabel();
            this.cmbPartyType = new Scalable.Win.Controls.iComboBox();
            this.lblName = new Scalable.Win.Controls.iLabel();
            this.txtOrganizationName = new Scalable.Win.Controls.iTextBox();
            this.cmbSalutation = new Scalable.Win.Controls.iComboBox();
            this.lblShortName = new Scalable.Win.Controls.iLabel();
            this.txtShortName = new Scalable.Win.Controls.iTextBox();
            this.txtAliasName = new Scalable.Win.Controls.iTextBox();
            this.lblAliasName = new Scalable.Win.Controls.iLabel();
            this.gpbNatureOfContacts = new Scalable.Win.Controls.iGroupBox();
            this.uPartyNatureOfContacts = new Mingle.UC.Controls.UPartyNatureOfContacts();
            this.gpbPhones = new Scalable.Win.Controls.iGroupBox();
            this.uPartyPhones = new Mingle.UC.Controls.UPartyPhones();
            this.uFullName = new Mingle.UC.Controls.UFullName();
            this.gpbNatureOfContacts.SuspendLayout();
            this.gpbPhones.SuspendLayout();
            this.SuspendLayout();
            // 
            // txbGroup
            // 
            this.txbGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbGroup.Location = new System.Drawing.Point(64, 25);
            this.txbGroup.Name = "txbGroup";
            this.txbGroup.SearchProperty = "Name";
            this.txbGroup.Size = new System.Drawing.Size(335, 20);
            this.txbGroup.TabIndex = 7;
            // 
            // lblPartyType
            // 
            this.lblPartyType.AutoSize = true;
            this.lblPartyType.Location = new System.Drawing.Point(0, 6);
            this.lblPartyType.Name = "lblPartyType";
            this.lblPartyType.Size = new System.Drawing.Size(34, 13);
            this.lblPartyType.TabIndex = 0;
            this.lblPartyType.Text = "Type:";
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.Location = new System.Drawing.Point(1, 29);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(39, 13);
            this.lblGroup.TabIndex = 6;
            this.lblGroup.Text = "Group:";
            // 
            // cmbPartyType
            // 
            this.cmbPartyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPartyType.FormattingEnabled = true;
            this.cmbPartyType.Location = new System.Drawing.Point(36, 2);
            this.cmbPartyType.Name = "cmbPartyType";
            this.cmbPartyType.Size = new System.Drawing.Size(89, 21);
            this.cmbPartyType.TabIndex = 1;
            this.cmbPartyType.TabStop = false;
            this.cmbPartyType.SelectedIndexChanged += new System.EventHandler(this.cmbPartyType_SelectedIndexChanged);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(129, 7);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Na&me:";
            // 
            // txtOrganizationName
            // 
            this.txtOrganizationName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOrganizationName.Location = new System.Drawing.Point(224, 2);
            this.txtOrganizationName.Name = "txtOrganizationName";
            this.txtOrganizationName.Size = new System.Drawing.Size(176, 20);
            this.txtOrganizationName.TabIndex = 4;
            // 
            // cmbSalutation
            // 
            this.cmbSalutation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSalutation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSalutation.FormattingEnabled = true;
            this.cmbSalutation.Location = new System.Drawing.Point(167, 2);
            this.cmbSalutation.Name = "cmbSalutation";
            this.cmbSalutation.Size = new System.Drawing.Size(55, 21);
            this.cmbSalutation.TabIndex = 3;
            this.cmbSalutation.TabStop = false;
            this.cmbSalutation.DropDown += new System.EventHandler(this.cmbSalutation_DropDown);
            // 
            // lblShortName
            // 
            this.lblShortName.AutoSize = true;
            this.lblShortName.Location = new System.Drawing.Point(0, 51);
            this.lblShortName.Name = "lblShortName";
            this.lblShortName.Size = new System.Drawing.Size(64, 13);
            this.lblShortName.TabIndex = 8;
            this.lblShortName.Text = "Short name:";
            // 
            // txtShortName
            // 
            this.txtShortName.Location = new System.Drawing.Point(64, 47);
            this.txtShortName.Name = "txtShortName";
            this.txtShortName.Size = new System.Drawing.Size(151, 20);
            this.txtShortName.TabIndex = 9;
            // 
            // txtAliasName
            // 
            this.txtAliasName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAliasName.Location = new System.Drawing.Point(279, 47);
            this.txtAliasName.Name = "txtAliasName";
            this.txtAliasName.Size = new System.Drawing.Size(121, 20);
            this.txtAliasName.TabIndex = 11;
            // 
            // lblAliasName
            // 
            this.lblAliasName.AutoSize = true;
            this.lblAliasName.Location = new System.Drawing.Point(217, 51);
            this.lblAliasName.Name = "lblAliasName";
            this.lblAliasName.Size = new System.Drawing.Size(61, 13);
            this.lblAliasName.TabIndex = 10;
            this.lblAliasName.Text = "Alias name:";
            // 
            // gpbNatureOfContacts
            // 
            this.gpbNatureOfContacts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbNatureOfContacts.Controls.Add(this.uPartyNatureOfContacts);
            this.gpbNatureOfContacts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbNatureOfContacts.Location = new System.Drawing.Point(3, 71);
            this.gpbNatureOfContacts.Name = "gpbNatureOfContacts";
            this.gpbNatureOfContacts.Size = new System.Drawing.Size(397, 141);
            this.gpbNatureOfContacts.TabIndex = 12;
            this.gpbNatureOfContacts.TabStop = false;
            this.gpbNatureOfContacts.Text = "Nature of contacts";
            // 
            // uPartyNatureOfContacts
            // 
            this.uPartyNatureOfContacts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uPartyNatureOfContacts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uPartyNatureOfContacts.Location = new System.Drawing.Point(3, 16);
            this.uPartyNatureOfContacts.MinimumSize = new System.Drawing.Size(344, 92);
            this.uPartyNatureOfContacts.Name = "uPartyNatureOfContacts";
            this.uPartyNatureOfContacts.Size = new System.Drawing.Size(391, 122);
            this.uPartyNatureOfContacts.TabIndex = 0;
            // 
            // gpbPhones
            // 
            this.gpbPhones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbPhones.Controls.Add(this.uPartyPhones);
            this.gpbPhones.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbPhones.Location = new System.Drawing.Point(3, 214);
            this.gpbPhones.Name = "gpbPhones";
            this.gpbPhones.Size = new System.Drawing.Size(397, 120);
            this.gpbPhones.TabIndex = 13;
            this.gpbPhones.TabStop = false;
            this.gpbPhones.Text = "Phones";
            // 
            // uPartyPhones
            // 
            this.uPartyPhones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uPartyPhones.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uPartyPhones.Location = new System.Drawing.Point(3, 16);
            this.uPartyPhones.MinimumSize = new System.Drawing.Size(389, 92);
            this.uPartyPhones.Name = "uPartyPhones";
            this.uPartyPhones.Size = new System.Drawing.Size(391, 101);
            this.uPartyPhones.TabIndex = 0;
            // 
            // uFullName
            // 
            this.uFullName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uFullName.Location = new System.Drawing.Point(224, 2);
            this.uFullName.Name = "uFullName";
            this.uFullName.Size = new System.Drawing.Size(177, 20);
            this.uFullName.TabIndex = 5;
            // 
            // UPartyBasic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gpbPhones);
            this.Controls.Add(this.gpbNatureOfContacts);
            this.Controls.Add(this.txbGroup);
            this.Controls.Add(this.lblPartyType);
            this.Controls.Add(this.lblAliasName);
            this.Controls.Add(this.lblShortName);
            this.Controls.Add(this.lblGroup);
            this.Controls.Add(this.cmbPartyType);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtAliasName);
            this.Controls.Add(this.txtShortName);
            this.Controls.Add(this.cmbSalutation);
            this.Controls.Add(this.uFullName);
            this.Controls.Add(this.txtOrganizationName);
            this.MinimumSize = new System.Drawing.Size(403, 335);
            this.Name = "UPartyBasic";
            this.Size = new System.Drawing.Size(403, 335);
            this.gpbNatureOfContacts.ResumeLayout(false);
            this.gpbPhones.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Scalable.Win.Controls.iTextBoxButton txbGroup;
        private Scalable.Win.Controls.iLabel lblPartyType;
        private Scalable.Win.Controls.iLabel lblGroup;
        private Scalable.Win.Controls.iComboBox cmbPartyType;
        private Scalable.Win.Controls.iLabel lblName;
        private Scalable.Win.Controls.iTextBox txtOrganizationName;
        private Scalable.Win.Controls.iComboBox cmbSalutation;
        private UFullName uFullName;
        private Scalable.Win.Controls.iLabel lblShortName;
        private Scalable.Win.Controls.iTextBox txtShortName;
        private Scalable.Win.Controls.iTextBox txtAliasName;
        private Scalable.Win.Controls.iLabel lblAliasName;
        private UPartyNatureOfContacts uPartyNatureOfContacts;
        private UPartyPhones uPartyPhones;
        private Scalable.Win.Controls.iGroupBox gpbNatureOfContacts;
        private Scalable.Win.Controls.iGroupBox gpbPhones;
    }
}
