namespace Gravity.Root.Controls
{
	partial class URole
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
            this.txtName = new Scalable.Win.Controls.iTextBox();
            this.lblName = new Scalable.Win.Controls.iLabel();
            this.btnAdd = new Scalable.Win.Controls.iCommandButton();
            this.btnDelete = new Scalable.Win.Controls.iCommandButton();
            this.btnDescription = new Scalable.Win.Controls.iCommandButton();
            this.btnUpdate = new Scalable.Win.Controls.iCommandButton();
            this.pnlLine = new Scalable.Win.Controls.iPanel();
            this.lblResponsibilities = new Scalable.Win.Controls.iLabel();
            this.chkIsActive = new Scalable.Win.Controls.iCheckBox();
            this.uRoleResponsibility = new Gravity.Root.Controls.UResponsibilities();
            this.CommandBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt
            // 
            this.txt.Location = new System.Drawing.Point(3, 44);
            this.txt.Size = new System.Drawing.Size(205, 20);
            this.txt.TabIndex = 6;
            this.txt.TabStop = false;
            this.txt.Visible = false;
            // 
            // lvw
            // 
            this.lvw.Location = new System.Drawing.Point(3, 23);
            this.lvw.Size = new System.Drawing.Size(208, 152);
            this.lvw.TabIndex = 4;
            this.lvw.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvw_ItemSelectionChanged);
            // 
            // CommandBar
            // 
            this.CommandBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.CommandBar.Controls.Add(this.btnDescription);
            this.CommandBar.Controls.Add(this.chkIsActive);
            this.CommandBar.Controls.Add(this.btnDelete);
            this.CommandBar.Location = new System.Drawing.Point(214, 23);
            this.CommandBar.Size = new System.Drawing.Size(78, 152);
            this.CommandBar.TabIndex = 5;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(41, 1);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(148, 20);
            this.txtName.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(2, 4);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(41, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "N&ame: ";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(191, 0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(50, 22);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(70, 23);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnDescription
            // 
            this.btnDescription.Location = new System.Drawing.Point(3, 26);
            this.btnDescription.Name = "btnDescription";
            this.btnDescription.Size = new System.Drawing.Size(70, 23);
            this.btnDescription.TabIndex = 1;
            this.btnDescription.Text = "Descri&ption";
            this.btnDescription.UseVisualStyleBackColor = true;
            this.btnDescription.Click += new System.EventHandler(this.btnDescription_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Location = new System.Drawing.Point(242, 0);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(51, 22);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "&Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // pnlLine
            // 
            this.pnlLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLine.Location = new System.Drawing.Point(86, 185);
            this.pnlLine.Name = "pnlLine";
            this.pnlLine.Size = new System.Drawing.Size(205, 1);
            this.pnlLine.TabIndex = 8;
            // 
            // lblResponsibilities
            // 
            this.lblResponsibilities.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblResponsibilities.AutoSize = true;
            this.lblResponsibilities.Location = new System.Drawing.Point(0, 178);
            this.lblResponsibilities.Name = "lblResponsibilities";
            this.lblResponsibilities.Size = new System.Drawing.Size(79, 13);
            this.lblResponsibilities.TabIndex = 7;
            this.lblResponsibilities.Text = "&Responsibilities";
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Checked = true;
            this.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsActive.Location = new System.Drawing.Point(4, 51);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(67, 17);
            this.chkIsActive.TabIndex = 2;
            this.chkIsActive.Text = "&Is Active";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // uRoleResponsibility
            // 
            this.uRoleResponsibility.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uRoleResponsibility.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uRoleResponsibility.Location = new System.Drawing.Point(3, 196);
            this.uRoleResponsibility.Name = "uRoleResponsibility";
            this.uRoleResponsibility.Size = new System.Drawing.Size(288, 162);
            this.uRoleResponsibility.TabIndex = 9;
            // 
            // URole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.pnlLine);
            this.Controls.Add(this.lblResponsibilities);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.uRoleResponsibility);
            this.Controls.Add(this.lblName);
            this.Name = "URole";
            this.Size = new System.Drawing.Size(294, 360);
            this.Controls.SetChildIndex(this.lblName, 0);
            this.Controls.SetChildIndex(this.uRoleResponsibility, 0);
            this.Controls.SetChildIndex(this.txtName, 0);
            this.Controls.SetChildIndex(this.txt, 0);
            this.Controls.SetChildIndex(this.CommandBar, 0);
            this.Controls.SetChildIndex(this.btnAdd, 0);
            this.Controls.SetChildIndex(this.lblResponsibilities, 0);
            this.Controls.SetChildIndex(this.pnlLine, 0);
            this.Controls.SetChildIndex(this.btnUpdate, 0);
            this.Controls.SetChildIndex(this.lvw, 0);
            this.CommandBar.ResumeLayout(false);
            this.CommandBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private Scalable.Win.Controls.iTextBox txtName;
		private Scalable.Win.Controls.iLabel lblName;
		private Scalable.Win.Controls.iCommandButton btnDescription;
		private Scalable.Win.Controls.iCommandButton btnDelete;
		private Scalable.Win.Controls.iCommandButton btnAdd;
		private Scalable.Win.Controls.iCommandButton btnUpdate;
		private Scalable.Win.Controls.iPanel pnlLine;
		private Scalable.Win.Controls.iLabel lblResponsibilities;
        private Scalable.Win.Controls.iCheckBox chkIsActive;
        private UResponsibilities uRoleResponsibility;



	}
}
