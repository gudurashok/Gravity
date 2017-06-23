﻿namespace Gravity.Root.Controls
{
	partial class URoles
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
            this.lvwUserRoles = new Scalable.Win.Controls.iListView();
            this.txbName = new Scalable.Win.Controls.iTextBoxButton();
            this.btnRemove = new Scalable.Win.Controls.iCommandButton();
            this.btnAdd = new Scalable.Win.Controls.iCommandButton();
            this.lblName = new Scalable.Win.Controls.iLabel();
            this.SuspendLayout();
            // 
            // lvwUserRoles
            // 
            this.lvwUserRoles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwUserRoles.FullRowSelect = true;
            this.lvwUserRoles.GridLines = true;
            this.lvwUserRoles.Location = new System.Drawing.Point(3, 24);
            this.lvwUserRoles.Name = "lvwUserRoles";
            this.lvwUserRoles.Size = new System.Drawing.Size(250, 92);
            this.lvwUserRoles.TabIndex = 5;
            this.lvwUserRoles.UseCompatibleStateImageBehavior = false;
            this.lvwUserRoles.View = System.Windows.Forms.View.Details;
            this.lvwUserRoles.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvwResponsibilities_ItemSelectionChanged);
            // 
            // txbName
            // 
            this.txbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbName.Location = new System.Drawing.Point(39, 2);
            this.txbName.Name = "txbName";
            this.txbName.SearchProperty = "Name";
            this.txbName.Size = new System.Drawing.Size(168, 20);
            this.txbName.TabIndex = 1;
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.ForeColor = System.Drawing.Color.Red;
            this.btnRemove.Location = new System.Drawing.Point(232, 1);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(22, 22);
            this.btnRemove.TabIndex = 4;
            this.btnRemove.Text = "-";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.Green;
            this.btnAdd.Location = new System.Drawing.Point(209, 1);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(22, 22);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(0, 5);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "&Name:";
            // 
            // URoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lvwUserRoles);
            this.Controls.Add(this.txbName);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblName);
            this.Name = "URoles";
            this.Size = new System.Drawing.Size(256, 118);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private Scalable.Win.Controls.iListView lvwUserRoles;
		private Scalable.Win.Controls.iTextBoxButton txbName;
		private Scalable.Win.Controls.iCommandButton btnRemove;
		private Scalable.Win.Controls.iCommandButton btnAdd;
        private Scalable.Win.Controls.iLabel lblName;

	}
}
