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
            this.CommandBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(410, 5);
            this.btnOK.Text = "&Import";
            this.btnOK.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // txt
            // 
            this.txt.Location = new System.Drawing.Point(2, 2);
            this.txt.Size = new System.Drawing.Size(487, 20);
            // 
            // lvw
            // 
            this.lvw.Location = new System.Drawing.Point(2, 26);
            this.lvw.Size = new System.Drawing.Size(487, 265);
            this.lvw.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ListView_ItemCheck);
            this.lvw.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.ListView_ItemChecked);
            this.lvw.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.ListView_ItemSelectionChanged);
            // 
            // CommandBar
            // 
            this.CommandBar.Controls.Add(this.btnAddPeriods);
            this.CommandBar.Controls.Add(this.btnEditPeriod);
            this.CommandBar.Controls.Add(this.btnDeletePeriod);
            this.CommandBar.Controls.Add(this.btnAddPeriod);
            this.CommandBar.Location = new System.Drawing.Point(-1, 316);
            this.CommandBar.Size = new System.Drawing.Size(493, 35);
            this.CommandBar.Controls.SetChildIndex(this.btnOK, 0);
            this.CommandBar.Controls.SetChildIndex(this.btnAddPeriod, 0);
            this.CommandBar.Controls.SetChildIndex(this.btnDeletePeriod, 0);
            this.CommandBar.Controls.SetChildIndex(this.btnEditPeriod, 0);
            this.CommandBar.Controls.SetChildIndex(this.btnAddPeriods, 0);
            // 
            // btnEditPeriod
            // 
            this.btnEditPeriod.Enabled = false;
            this.btnEditPeriod.Location = new System.Drawing.Point(173, 5);
            this.btnEditPeriod.Name = "btnEditPeriod";
            this.btnEditPeriod.Size = new System.Drawing.Size(75, 23);
            this.btnEditPeriod.TabIndex = 3;
            this.btnEditPeriod.Text = "Edit";
            this.btnEditPeriod.UseVisualStyleBackColor = true;
            this.btnEditPeriod.Click += new System.EventHandler(this.btnEditPeriod_Click);
            // 
            // btnDeletePeriod
            // 
            this.btnDeletePeriod.Enabled = false;
            this.btnDeletePeriod.Location = new System.Drawing.Point(254, 5);
            this.btnDeletePeriod.Name = "btnDeletePeriod";
            this.btnDeletePeriod.Size = new System.Drawing.Size(75, 23);
            this.btnDeletePeriod.TabIndex = 4;
            this.btnDeletePeriod.Text = "Delete";
            this.btnDeletePeriod.UseVisualStyleBackColor = true;
            this.btnDeletePeriod.Click += new System.EventHandler(this.btnDeletePeriod_Click);
            // 
            // btnAddPeriod
            // 
            this.btnAddPeriod.Location = new System.Drawing.Point(92, 5);
            this.btnAddPeriod.Name = "btnAddPeriod";
            this.btnAddPeriod.Size = new System.Drawing.Size(75, 23);
            this.btnAddPeriod.TabIndex = 2;
            this.btnAddPeriod.Text = "Add";
            this.btnAddPeriod.UseVisualStyleBackColor = true;
            this.btnAddPeriod.Click += new System.EventHandler(this.btnAddPeriod_Click);
            // 
            // btnAddPeriods
            // 
            this.btnAddPeriods.Location = new System.Drawing.Point(6, 5);
            this.btnAddPeriods.Name = "btnAddPeriods";
            this.btnAddPeriods.Size = new System.Drawing.Size(75, 23);
            this.btnAddPeriods.TabIndex = 1;
            this.btnAddPeriods.Text = "Add Periods";
            this.btnAddPeriods.UseVisualStyleBackColor = true;
            this.btnAddPeriods.Click += new System.EventHandler(this.btnAddPeriods_Click);
            // 
            // lblPeriodDataPath
            // 
            this.lblPeriodDataPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPeriodDataPath.AutoSize = true;
            this.lblPeriodDataPath.Location = new System.Drawing.Point(3, 295);
            this.lblPeriodDataPath.Name = "lblPeriodDataPath";
            this.lblPeriodDataPath.Size = new System.Drawing.Size(32, 13);
            this.lblPeriodDataPath.TabIndex = 2;
            this.lblPeriodDataPath.Text = "Path:";
            // 
            // txtPeriodDataPath
            // 
            this.txtPeriodDataPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPeriodDataPath.BackColor = System.Drawing.Color.White;
            this.txtPeriodDataPath.Location = new System.Drawing.Point(37, 293);
            this.txtPeriodDataPath.Name = "txtPeriodDataPath";
            this.txtPeriodDataPath.ReadOnly = true;
            this.txtPeriodDataPath.Size = new System.Drawing.Size(452, 20);
            this.txtPeriodDataPath.TabIndex = 3;
            this.txtPeriodDataPath.TabStop = false;
            // 
            // UCompanyPeriods
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblPeriodDataPath);
            this.Controls.Add(this.txtPeriodDataPath);
            this.Name = "UCompanyPeriods";
            this.Size = new System.Drawing.Size(491, 350);
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
    }
}
