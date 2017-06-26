namespace Ferry.Win.Controls
{
    partial class UCompanyPeriods
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
            this.btnEditPeriod = new Scalable.Win.Controls.iButton();
            this.btnDeletePeriod = new Scalable.Win.Controls.iButton();
            this.btnAddPeriod = new Scalable.Win.Controls.iButton();
            this.btnAddPeriods = new Scalable.Win.Controls.iButton();
            this.lblPeriodDataPath = new Scalable.Win.Controls.iLabel();
            this.txtPeriodDataPath = new Scalable.Win.Controls.iTextBox();
            this.btnCreatePeriod = new Scalable.Win.Controls.iButton();
            this.CommandBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(567, 6);
            this.btnOK.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnOK.Text = "&Import";
            this.btnOK.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(458, 6);
            // 
            // txt
            // 
            this.txt.Location = new System.Drawing.Point(3, 2);
            this.txt.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txt.Size = new System.Drawing.Size(669, 22);
            // 
            // lvw
            // 
            this.lvw.Location = new System.Drawing.Point(3, 32);
            this.lvw.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.lvw.Size = new System.Drawing.Size(669, 326);
            this.lvw.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ListView_ItemCheck);
            this.lvw.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.ListView_ItemChecked);
            this.lvw.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.ListView_ItemSelectionChanged);
            // 
            // CommandBar
            // 
            this.CommandBar.Controls.Add(this.btnCreatePeriod);
            this.CommandBar.Controls.Add(this.btnAddPeriods);
            this.CommandBar.Controls.Add(this.btnEditPeriod);
            this.CommandBar.Controls.Add(this.btnDeletePeriod);
            this.CommandBar.Controls.Add(this.btnAddPeriod);
            this.CommandBar.Location = new System.Drawing.Point(-1, 389);
            this.CommandBar.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.CommandBar.Size = new System.Drawing.Size(677, 43);
            this.CommandBar.Controls.SetChildIndex(this.btnOpen, 0);
            this.CommandBar.Controls.SetChildIndex(this.btnOK, 0);
            this.CommandBar.Controls.SetChildIndex(this.btnAddPeriod, 0);
            this.CommandBar.Controls.SetChildIndex(this.btnDeletePeriod, 0);
            this.CommandBar.Controls.SetChildIndex(this.btnEditPeriod, 0);
            this.CommandBar.Controls.SetChildIndex(this.btnAddPeriods, 0);
            this.CommandBar.Controls.SetChildIndex(this.btnCreatePeriod, 0);
            // 
            // btnEditPeriod
            // 
            this.btnEditPeriod.Enabled = false;
            this.btnEditPeriod.Location = new System.Drawing.Point(194, 6);
            this.btnEditPeriod.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEditPeriod.Name = "btnEditPeriod";
            this.btnEditPeriod.Size = new System.Drawing.Size(80, 28);
            this.btnEditPeriod.TabIndex = 3;
            this.btnEditPeriod.Text = "Edit";
            this.btnEditPeriod.UseVisualStyleBackColor = true;
            this.btnEditPeriod.Click += new System.EventHandler(this.btnEditPeriod_Click);
            // 
            // btnDeletePeriod
            // 
            this.btnDeletePeriod.Enabled = false;
            this.btnDeletePeriod.Location = new System.Drawing.Point(278, 6);
            this.btnDeletePeriod.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDeletePeriod.Name = "btnDeletePeriod";
            this.btnDeletePeriod.Size = new System.Drawing.Size(80, 28);
            this.btnDeletePeriod.TabIndex = 4;
            this.btnDeletePeriod.Text = "Delete";
            this.btnDeletePeriod.UseVisualStyleBackColor = true;
            this.btnDeletePeriod.Click += new System.EventHandler(this.btnDeletePeriod_Click);
            // 
            // btnAddPeriod
            // 
            this.btnAddPeriod.Location = new System.Drawing.Point(110, 6);
            this.btnAddPeriod.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddPeriod.Name = "btnAddPeriod";
            this.btnAddPeriod.Size = new System.Drawing.Size(80, 28);
            this.btnAddPeriod.TabIndex = 2;
            this.btnAddPeriod.Text = "Add";
            this.btnAddPeriod.UseVisualStyleBackColor = true;
            this.btnAddPeriod.Click += new System.EventHandler(this.btnAddPeriod_Click);
            // 
            // btnAddPeriods
            // 
            this.btnAddPeriods.Location = new System.Drawing.Point(8, 6);
            this.btnAddPeriods.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddPeriods.Name = "btnAddPeriods";
            this.btnAddPeriods.Size = new System.Drawing.Size(98, 28);
            this.btnAddPeriods.TabIndex = 1;
            this.btnAddPeriods.Text = "Add Periods";
            this.btnAddPeriods.UseVisualStyleBackColor = true;
            this.btnAddPeriods.Click += new System.EventHandler(this.btnAddPeriods_Click);
            // 
            // lblPeriodDataPath
            // 
            this.lblPeriodDataPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPeriodDataPath.AutoSize = true;
            this.lblPeriodDataPath.Location = new System.Drawing.Point(4, 363);
            this.lblPeriodDataPath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPeriodDataPath.Name = "lblPeriodDataPath";
            this.lblPeriodDataPath.Size = new System.Drawing.Size(41, 17);
            this.lblPeriodDataPath.TabIndex = 2;
            this.lblPeriodDataPath.Text = "Path:";
            // 
            // txtPeriodDataPath
            // 
            this.txtPeriodDataPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPeriodDataPath.BackColor = System.Drawing.Color.White;
            this.txtPeriodDataPath.Location = new System.Drawing.Point(49, 361);
            this.txtPeriodDataPath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPeriodDataPath.Name = "txtPeriodDataPath";
            this.txtPeriodDataPath.ReadOnly = true;
            this.txtPeriodDataPath.Size = new System.Drawing.Size(621, 22);
            this.txtPeriodDataPath.TabIndex = 3;
            this.txtPeriodDataPath.TabStop = false;
            // 
            // btnCreate
            // 
            this.btnCreatePeriod.Enabled = false;
            this.btnCreatePeriod.Location = new System.Drawing.Point(362, 6);
            this.btnCreatePeriod.Margin = new System.Windows.Forms.Padding(4);
            this.btnCreatePeriod.Name = "btnCreate";
            this.btnCreatePeriod.Size = new System.Drawing.Size(80, 28);
            this.btnCreatePeriod.TabIndex = 5;
            this.btnCreatePeriod.Text = "Create";
            this.btnCreatePeriod.UseVisualStyleBackColor = true;
            this.btnCreatePeriod.Click += new System.EventHandler(this.btnCreatePeriod_Click);
            // 
            // UCompanyPeriods
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblPeriodDataPath);
            this.Controls.Add(this.txtPeriodDataPath);
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "UCompanyPeriods";
            this.Size = new System.Drawing.Size(675, 431);
            this.Controls.SetChildIndex(this.lvw, 0);
            this.Controls.SetChildIndex(this.CommandBar, 0);
            this.Controls.SetChildIndex(this.txt, 0);
            this.Controls.SetChildIndex(this.txtPeriodDataPath, 0);
            this.Controls.SetChildIndex(this.lblPeriodDataPath, 0);
            this.CommandBar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Scalable.Win.Controls.iButton btnEditPeriod;
        private Scalable.Win.Controls.iButton btnDeletePeriod;
        private Scalable.Win.Controls.iButton btnAddPeriod;
        private Scalable.Win.Controls.iButton btnAddPeriods;
        private Scalable.Win.Controls.iLabel lblPeriodDataPath;
        private Scalable.Win.Controls.iTextBox txtPeriodDataPath;
        private Scalable.Win.Controls.iButton btnCreatePeriod;
    }
}
