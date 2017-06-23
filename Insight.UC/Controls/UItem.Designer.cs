namespace Insight.UC.Controls
{
    partial class UItem
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
            this.btnSave = new Scalable.Win.Controls.iCommandButton();
            this.chkIsActive = new Scalable.Win.Controls.iCheckBox();
            this.chkHasBom = new Scalable.Win.Controls.iCheckBox();
            this.txtShortName = new Scalable.Win.Controls.iTextBox();
            this.lblShortName = new Scalable.Win.Controls.iLabel();
            this.txbItemGroup = new Scalable.Win.Controls.iTextBoxButton();
            this.lblGroup = new Scalable.Win.Controls.iLabel();
            this.txtCode = new Scalable.Win.Controls.iTextBox();
            this.lblCode = new Scalable.Win.Controls.iLabel();
            this.txbItemCategory = new Scalable.Win.Controls.iTextBoxButton();
            this.txtName = new Scalable.Win.Controls.iTextBox();
            this.lblName = new Scalable.Win.Controls.iLabel();
            this.lblCategory = new Scalable.Win.Controls.iLabel();
            this.CommandBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // CommandBar
            // 
            this.CommandBar.Controls.Add(this.btnSave);
            this.CommandBar.Location = new System.Drawing.Point(-1, 89);
            this.CommandBar.Size = new System.Drawing.Size(278, 35);
            this.CommandBar.TabIndex = 12;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSave.Location = new System.Drawing.Point(101, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkIsActive
            // 
            this.chkIsActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Location = new System.Drawing.Point(206, 71);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(64, 17);
            this.chkIsActive.TabIndex = 11;
            this.chkIsActive.Text = "&IsActive";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // chkHasBom
            // 
            this.chkHasBom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkHasBom.AutoSize = true;
            this.chkHasBom.Location = new System.Drawing.Point(206, 49);
            this.chkHasBom.Name = "chkHasBom";
            this.chkHasBom.Size = new System.Drawing.Size(69, 17);
            this.chkHasBom.TabIndex = 8;
            this.chkHasBom.Text = "Has &Bom";
            this.chkHasBom.UseVisualStyleBackColor = true;
            // 
            // txtShortName
            // 
            this.txtShortName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtShortName.Location = new System.Drawing.Point(70, 24);
            this.txtShortName.Name = "txtShortName";
            this.txtShortName.Size = new System.Drawing.Size(108, 20);
            this.txtShortName.TabIndex = 3;
            // 
            // lblShortName
            // 
            this.lblShortName.AutoSize = true;
            this.lblShortName.Location = new System.Drawing.Point(2, 29);
            this.lblShortName.Name = "lblShortName";
            this.lblShortName.Size = new System.Drawing.Size(69, 13);
            this.lblShortName.TabIndex = 2;
            this.lblShortName.Text = "S&hort Name: ";
            // 
            // txbItemGroup
            // 
            this.txbItemGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbItemGroup.Location = new System.Drawing.Point(70, 46);
            this.txbItemGroup.Name = "txbItemGroup";
            this.txbItemGroup.SearchProperty = "Name";
            this.txbItemGroup.Size = new System.Drawing.Size(132, 20);
            this.txbItemGroup.TabIndex = 7;
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.Location = new System.Drawing.Point(2, 51);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(42, 13);
            this.lblGroup.TabIndex = 6;
            this.lblGroup.Text = "&Group: ";
            // 
            // txtCode
            // 
            this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCode.Location = new System.Drawing.Point(226, 25);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(46, 20);
            this.txtCode.TabIndex = 5;
            // 
            // lblCode
            // 
            this.lblCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(182, 29);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(38, 13);
            this.lblCode.TabIndex = 4;
            this.lblCode.Text = "&Code: ";
            // 
            // txbItemCategory
            // 
            this.txbItemCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbItemCategory.Location = new System.Drawing.Point(70, 68);
            this.txbItemCategory.Name = "txbItemCategory";
            this.txbItemCategory.SearchProperty = "Name";
            this.txbItemCategory.Size = new System.Drawing.Size(132, 20);
            this.txbItemCategory.TabIndex = 10;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(70, 2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(202, 20);
            this.txtName.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(2, 5);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(41, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "&Name: ";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(2, 73);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(49, 13);
            this.lblCategory.TabIndex = 9;
            this.lblCategory.Text = "&Category";
            // 
            // UItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.chkIsActive);
            this.Controls.Add(this.chkHasBom);
            this.Controls.Add(this.txtShortName);
            this.Controls.Add(this.lblShortName);
            this.Controls.Add(this.txbItemGroup);
            this.Controls.Add(this.lblGroup);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.txbItemCategory);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblCategory);
            this.MaximumSize = new System.Drawing.Size(500, 125);
            this.MinimumSize = new System.Drawing.Size(278, 125);
            this.Name = "UItem";
            this.Size = new System.Drawing.Size(276, 123);
            this.Controls.SetChildIndex(this.CommandBar, 0);
            this.Controls.SetChildIndex(this.lblCategory, 0);
            this.Controls.SetChildIndex(this.lblName, 0);
            this.Controls.SetChildIndex(this.txtName, 0);
            this.Controls.SetChildIndex(this.txbItemCategory, 0);
            this.Controls.SetChildIndex(this.lblCode, 0);
            this.Controls.SetChildIndex(this.txtCode, 0);
            this.Controls.SetChildIndex(this.lblGroup, 0);
            this.Controls.SetChildIndex(this.txbItemGroup, 0);
            this.Controls.SetChildIndex(this.lblShortName, 0);
            this.Controls.SetChildIndex(this.txtShortName, 0);
            this.Controls.SetChildIndex(this.chkHasBom, 0);
            this.Controls.SetChildIndex(this.chkIsActive, 0);
            this.CommandBar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Scalable.Win.Controls.iCommandButton btnSave;
        private Scalable.Win.Controls.iCheckBox chkIsActive;
        private Scalable.Win.Controls.iCheckBox chkHasBom;
        private Scalable.Win.Controls.iTextBox txtShortName;
        private Scalable.Win.Controls.iLabel lblShortName;
        private Scalable.Win.Controls.iTextBoxButton txbItemGroup;
        private Scalable.Win.Controls.iLabel lblGroup;
        private Scalable.Win.Controls.iTextBox txtCode;
        private Scalable.Win.Controls.iLabel lblCode;
        private Scalable.Win.Controls.iTextBoxButton txbItemCategory;
        private Scalable.Win.Controls.iTextBox txtName;
        private Scalable.Win.Controls.iLabel lblName;
        private Scalable.Win.Controls.iLabel lblCategory;
    }
}
