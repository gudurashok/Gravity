namespace Mingle.UC.Controls
{
    partial class UParty
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
            this.txbParty = new Scalable.Win.Controls.iTextBoxButton();
            this.lblParty = new Scalable.Win.Controls.iLabel();
            this.btnCancel = new Scalable.Win.Controls.iCommandButton();
            this.btnSaveAndClose = new Scalable.Win.Controls.iCommandButton();
            this.btnSaveAndNew = new Scalable.Win.Controls.iCommandButton();
            this.btnSave = new Scalable.Win.Controls.iCommandButton();
            this.btnDelete = new Scalable.Win.Controls.iCommandButton();
            this.btnNew = new Scalable.Win.Controls.iCommandButton();
            this.chkEnableSelection = new Scalable.Win.Controls.iCheckBox();
            this.CommandBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt
            // 
            this.txt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.txt.Location = new System.Drawing.Point(2, 22);
            this.txt.Size = new System.Drawing.Size(148, 20);
            this.txt.TabStop = false;
            this.txt.Visible = false;
            // 
            // lvw
            // 
            this.lvw.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lvw.HideSelection = false;
            this.lvw.Location = new System.Drawing.Point(2, 22);
            this.lvw.Size = new System.Drawing.Size(148, 301);
            this.lvw.TabIndex = 0;
            // 
            // CommandBar
            // 
            this.CommandBar.Controls.Add(this.btnCancel);
            this.CommandBar.Controls.Add(this.btnSaveAndClose);
            this.CommandBar.Controls.Add(this.btnSaveAndNew);
            this.CommandBar.Controls.Add(this.btnSave);
            this.CommandBar.Controls.Add(this.btnDelete);
            this.CommandBar.Controls.Add(this.btnNew);
            this.CommandBar.Location = new System.Drawing.Point(-1, 325);
            this.CommandBar.Size = new System.Drawing.Size(464, 35);
            this.CommandBar.TabIndex = 1;
            // 
            // txbParty
            // 
            this.txbParty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbParty.Enabled = false;
            this.txbParty.Location = new System.Drawing.Point(192, 0);
            this.txbParty.Name = "txbParty";
            this.txbParty.SearchProperty = "Name";
            this.txbParty.Size = new System.Drawing.Size(267, 20);
            this.txbParty.TabIndex = 4;
            // 
            // lblParty
            // 
            this.lblParty.AutoSize = true;
            this.lblParty.Location = new System.Drawing.Point(153, 3);
            this.lblParty.Name = "lblParty";
            this.lblParty.Size = new System.Drawing.Size(34, 13);
            this.lblParty.TabIndex = 3;
            this.lblParty.Text = "Party:";
            // 
            // btnCancel
            // 
            this.btnCancel.Action = Scalable.Win.Enums.CommandBarAction.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(92, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Can&cel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.commandBarButton_Click);
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.Action = ((Scalable.Win.Enums.CommandBarAction)((Scalable.Win.Enums.CommandBarAction.Save | Scalable.Win.Enums.CommandBarAction.Close)));
            this.btnSaveAndClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveAndClose.Location = new System.Drawing.Point(376, 5);
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            this.btnSaveAndClose.Size = new System.Drawing.Size(80, 23);
            this.btnSaveAndClose.TabIndex = 3;
            this.btnSaveAndClose.Text = "Save && Clos&e";
            this.btnSaveAndClose.UseVisualStyleBackColor = true;
            this.btnSaveAndClose.Click += new System.EventHandler(this.commandBarButton_Click);
            // 
            // btnSaveAndNew
            // 
            this.btnSaveAndNew.Action = ((Scalable.Win.Enums.CommandBarAction)((Scalable.Win.Enums.CommandBarAction.New | Scalable.Win.Enums.CommandBarAction.Save)));
            this.btnSaveAndNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveAndNew.Location = new System.Drawing.Point(290, 5);
            this.btnSaveAndNew.Name = "btnSaveAndNew";
            this.btnSaveAndNew.Size = new System.Drawing.Size(80, 23);
            this.btnSaveAndNew.TabIndex = 2;
            this.btnSaveAndNew.Text = "S&ave && New";
            this.btnSaveAndNew.UseVisualStyleBackColor = true;
            this.btnSaveAndNew.Click += new System.EventHandler(this.commandBarButton_Click);
            // 
            // btnSave
            // 
            this.btnSave.Action = Scalable.Win.Enums.CommandBarAction.Save;
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(204, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.commandBarButton_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Action = ((Scalable.Win.Enums.CommandBarAction)((Scalable.Win.Enums.CommandBarAction.New | Scalable.Win.Enums.CommandBarAction.Delete)));
            this.btnDelete.Enabled = false;
            this.btnDelete.ForeColor = System.Drawing.Color.Red;
            this.btnDelete.Location = new System.Drawing.Point(92, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(23, 23);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "X";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Action = Scalable.Win.Enums.CommandBarAction.New;
            this.btnNew.Location = new System.Drawing.Point(6, 5);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(80, 23);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "&New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.commandBarButton_Click);
            // 
            // chkEnableSelection
            // 
            this.chkEnableSelection.AutoSize = true;
            this.chkEnableSelection.Location = new System.Drawing.Point(6, 2);
            this.chkEnableSelection.Name = "chkEnableSelection";
            this.chkEnableSelection.Size = new System.Drawing.Size(130, 17);
            this.chkEnableSelection.TabIndex = 2;
            this.chkEnableSelection.Text = "Enable party selection";
            this.chkEnableSelection.UseVisualStyleBackColor = true;
            this.chkEnableSelection.CheckedChanged += new System.EventHandler(this.chkEnableSelection_CheckedChanged);
            // 
            // UParty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkEnableSelection);
            this.Controls.Add(this.txbParty);
            this.Controls.Add(this.lblParty);
            this.Name = "UParty";
            this.Size = new System.Drawing.Size(462, 359);
            this.Controls.SetChildIndex(this.txt, 0);
            this.Controls.SetChildIndex(this.CommandBar, 0);
            this.Controls.SetChildIndex(this.lblParty, 0);
            this.Controls.SetChildIndex(this.txbParty, 0);
            this.Controls.SetChildIndex(this.chkEnableSelection, 0);
            this.Controls.SetChildIndex(this.lvw, 0);
            this.CommandBar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Scalable.Win.Controls.iTextBoxButton txbParty;
        private Scalable.Win.Controls.iLabel lblParty;
        private Scalable.Win.Controls.iCommandButton btnCancel;
        private Scalable.Win.Controls.iCommandButton btnSaveAndClose;
        private Scalable.Win.Controls.iCommandButton btnSaveAndNew;
        private Scalable.Win.Controls.iCommandButton btnSave;
        private Scalable.Win.Controls.iCommandButton btnDelete;
        private Scalable.Win.Controls.iCommandButton btnNew;
        private Scalable.Win.Controls.iCheckBox chkEnableSelection;
    }
}
