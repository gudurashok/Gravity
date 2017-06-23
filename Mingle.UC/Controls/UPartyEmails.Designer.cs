namespace Mingle.UC.Controls
{
    partial class UPartyEmails
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
            this.ListView = new Scalable.Win.Controls.iListView();
            this.btnPreferred = new Scalable.Win.Controls.iCommandButton();
            this.chkIsActive = new Scalable.Win.Controls.iCheckBox();
            this.CommandBar = new Scalable.Win.Controls.iCommandBar();
            this.btnDelete = new Scalable.Win.Controls.iCommandButton();
            this.cmbTitle = new Scalable.Win.Controls.iComboBox();
            this.btnAdd = new Scalable.Win.Controls.iCommandButton();
            this.lblTitle = new Scalable.Win.Controls.iLabel();
            this.lblEmail = new Scalable.Win.Controls.iLabel();
            this.btnUpdate = new Scalable.Win.Controls.iCommandButton();
            this.txtEmail = new Scalable.Win.Controls.iTextBox();
            this.CommandBar.SuspendLayout();
            this.SuspendLayout();
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
            this.ListView.Location = new System.Drawing.Point(2, 25);
            this.ListView.MultiSelect = false;
            this.ListView.Name = "ListView";
            this.ListView.Size = new System.Drawing.Size(296, 65);
            this.ListView.TabIndex = 6;
            this.ListView.UseCompatibleStateImageBehavior = false;
            this.ListView.View = System.Windows.Forms.View.Details;
            this.ListView.SelectedIndexChanged += new System.EventHandler(this.lvw_SelectedIndexChanged);
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
            // CommandBar
            // 
            this.CommandBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CommandBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CommandBar.Controls.Add(this.btnDelete);
            this.CommandBar.Controls.Add(this.chkIsActive);
            this.CommandBar.Controls.Add(this.btnPreferred);
            this.CommandBar.Location = new System.Drawing.Point(300, 25);
            this.CommandBar.Name = "CommandBar";
            this.CommandBar.Size = new System.Drawing.Size(66, 65);
            this.CommandBar.TabIndex = 7;
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
            // cmbTitle
            // 
            this.cmbTitle.FormattingEnabled = true;
            this.cmbTitle.Location = new System.Drawing.Point(29, 2);
            this.cmbTitle.Name = "cmbTitle";
            this.cmbTitle.Size = new System.Drawing.Size(100, 21);
            this.cmbTitle.TabIndex = 1;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(266, 1);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(50, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(-1, 5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(30, 13);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Title:";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(130, 5);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 13);
            this.lblEmail.TabIndex = 2;
            this.lblEmail.Text = "Email:";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Location = new System.Drawing.Point(317, 1);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(50, 23);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "&Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmail.Location = new System.Drawing.Point(166, 2);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(98, 20);
            this.txtEmail.TabIndex = 3;
            // 
            // UPartyEmails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ListView);
            this.Controls.Add(this.CommandBar);
            this.Controls.Add(this.cmbTitle);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtEmail);
            this.Name = "UPartyEmails";
            this.Size = new System.Drawing.Size(369, 92);
            this.CommandBar.ResumeLayout(false);
            this.CommandBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Scalable.Win.Controls.iListView ListView;
        private Scalable.Win.Controls.iCommandButton btnPreferred;
        private Scalable.Win.Controls.iCheckBox chkIsActive;
        private Scalable.Win.Controls.iCommandBar CommandBar;
        private Scalable.Win.Controls.iCommandButton btnDelete;
        private Scalable.Win.Controls.iComboBox cmbTitle;
        private Scalable.Win.Controls.iCommandButton btnAdd;
        private Scalable.Win.Controls.iLabel lblTitle;
        private Scalable.Win.Controls.iLabel lblEmail;
        private Scalable.Win.Controls.iCommandButton btnUpdate;
        private Scalable.Win.Controls.iTextBox txtEmail;

    }
}
