using Scalable.Shared.Enums;

namespace Gravity.Root.Controls
{
    partial class UCompanyGroup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCompanyGroup));
            this.lblCoGroup = new Scalable.Win.Controls.iLabel();
            this.lblAttachedDb = new Scalable.Win.Controls.iLabel();
            this.txtAttachedDb = new Scalable.Win.Controls.iTextBox();
            this.btnAttachDb = new Scalable.Win.Controls.iButton();
            this.txtCoGroupName = new Scalable.Win.Controls.iTextBox();
            this.btnOK = new Scalable.Win.Controls.iButton();
            this.cmbDatabases = new Scalable.Win.Controls.iComboBox();
            this.lblDataSource = new Scalable.Win.Controls.iLabel();
            this.CommandBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // CommandBar
            // 
            this.CommandBar.Controls.Add(this.btnOK);
            this.CommandBar.Location = new System.Drawing.Point(-1, 77);
            this.CommandBar.Size = new System.Drawing.Size(341, 35);
            this.CommandBar.TabIndex = 7;
            // 
            // lblCoGroup
            // 
            this.lblCoGroup.AutoSize = true;
            this.lblCoGroup.Location = new System.Drawing.Point(3, 6);
            this.lblCoGroup.Name = "lblCoGroup";
            this.lblCoGroup.Size = new System.Drawing.Size(68, 13);
            this.lblCoGroup.TabIndex = 0;
            this.lblCoGroup.Text = "&Group name:";
            // 
            // lblAttachedDb
            // 
            this.lblAttachedDb.AutoSize = true;
            this.lblAttachedDb.Location = new System.Drawing.Point(3, 53);
            this.lblAttachedDb.Name = "lblAttachedDb";
            this.lblAttachedDb.Size = new System.Drawing.Size(71, 13);
            this.lblAttachedDb.TabIndex = 5;
            this.lblAttachedDb.Text = "&Attached DB:";
            // 
            // txtAttachedDb
            // 
            this.txtAttachedDb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAttachedDb.Enabled = false;
            this.txtAttachedDb.Location = new System.Drawing.Point(80, 27);
            this.txtAttachedDb.Name = "txtAttachedDb";
            this.txtAttachedDb.ReadOnly = true;
            this.txtAttachedDb.Size = new System.Drawing.Size(231, 20);
            this.txtAttachedDb.TabIndex = 3;
            this.txtAttachedDb.TabStop = false;
            this.txtAttachedDb.Tag = "DatabaseName";
            // 
            // btnAttachDb
            // 
            this.btnAttachDb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAttachDb.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAttachDb.BackgroundImage")));
            this.btnAttachDb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAttachDb.Enabled = false;
            this.btnAttachDb.Location = new System.Drawing.Point(311, 26);
            this.btnAttachDb.Name = "btnAttachDb";
            this.btnAttachDb.Size = new System.Drawing.Size(24, 22);
            this.btnAttachDb.TabIndex = 4;
            this.btnAttachDb.UseVisualStyleBackColor = true;
            this.btnAttachDb.Click += new System.EventHandler(this.btnAttachDb_Click);
            // 
            // txtCoGroupName
            // 
            this.txtCoGroupName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCoGroupName.AutoCasing = Scalable.Shared.Enums.TextCaseStyle.Proper;
            this.txtCoGroupName.Location = new System.Drawing.Point(80, 4);
            this.txtCoGroupName.MaxLength = 100;
            this.txtCoGroupName.Name = "txtCoGroupName";
            this.txtCoGroupName.Size = new System.Drawing.Size(255, 20);
            this.txtCoGroupName.TabIndex = 1;
            this.txtCoGroupName.Tag = "Name";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOK.Location = new System.Drawing.Point(132, 5);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // cmbDatabases
            // 
            this.cmbDatabases.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDatabases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDatabases.Enabled = false;
            this.cmbDatabases.FormattingEnabled = true;
            this.cmbDatabases.Location = new System.Drawing.Point(80, 50);
            this.cmbDatabases.Name = "cmbDatabases";
            this.cmbDatabases.Size = new System.Drawing.Size(255, 21);
            this.cmbDatabases.TabIndex = 6;
            // 
            // lblDataSource
            // 
            this.lblDataSource.AutoSize = true;
            this.lblDataSource.Location = new System.Drawing.Point(3, 30);
            this.lblDataSource.Name = "lblDataSource";
            this.lblDataSource.Size = new System.Drawing.Size(68, 13);
            this.lblDataSource.TabIndex = 2;
            this.lblDataSource.Text = "&Data source:";
            // 
            // UCompanyGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbDatabases);
            this.Controls.Add(this.lblCoGroup);
            this.Controls.Add(this.lblDataSource);
            this.Controls.Add(this.lblAttachedDb);
            this.Controls.Add(this.txtAttachedDb);
            this.Controls.Add(this.btnAttachDb);
            this.Controls.Add(this.txtCoGroupName);
            this.Name = "UCompanyGroup";
            this.Size = new System.Drawing.Size(339, 111);
            this.Controls.SetChildIndex(this.txtCoGroupName, 0);
            this.Controls.SetChildIndex(this.btnAttachDb, 0);
            this.Controls.SetChildIndex(this.txtAttachedDb, 0);
            this.Controls.SetChildIndex(this.lblAttachedDb, 0);
            this.Controls.SetChildIndex(this.lblDataSource, 0);
            this.Controls.SetChildIndex(this.CommandBar, 0);
            this.Controls.SetChildIndex(this.lblCoGroup, 0);
            this.Controls.SetChildIndex(this.cmbDatabases, 0);
            this.CommandBar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Scalable.Win.Controls.iLabel lblCoGroup;
        private Scalable.Win.Controls.iLabel lblAttachedDb;
        private Scalable.Win.Controls.iTextBox txtAttachedDb;
        private Scalable.Win.Controls.iButton btnAttachDb;
        private Scalable.Win.Controls.iTextBox txtCoGroupName;
        private Scalable.Win.Controls.iButton btnOK;
        private Scalable.Win.Controls.iComboBox cmbDatabases;
        private Scalable.Win.Controls.iLabel lblDataSource;
    }
}
