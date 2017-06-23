namespace Synergy.UC.Controls
{
    partial class UReminders
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
            this.btnNew = new Scalable.Win.Controls.iCommandButton();
            this.btnEdit = new Scalable.Win.Controls.iCommandButton();
            this.btnDelete = new Scalable.Win.Controls.iCommandButton();
            this.uReminder = new Synergy.UC.Controls.UReminder();
            this.btnOpen = new Scalable.Win.Controls.iCommandButton();
            this.CommandBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt
            // 
            this.txt.Location = new System.Drawing.Point(2, 1);
            this.txt.Size = new System.Drawing.Size(313, 20);
            // 
            // lvw
            // 
            this.lvw.Location = new System.Drawing.Point(2, 23);
            this.lvw.Size = new System.Drawing.Size(313, 149);
            this.lvw.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.ListView_ItemSelectionChanged);
            this.lvw.DoubleClick += new System.EventHandler(this.lvw_DoubleClick);
            // 
            // CommandBar
            // 
            this.CommandBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CommandBar.Controls.Add(this.btnNew);
            this.CommandBar.Controls.Add(this.btnOpen);
            this.CommandBar.Controls.Add(this.btnDelete);
            this.CommandBar.Controls.Add(this.btnEdit);
            this.CommandBar.Location = new System.Drawing.Point(318, 1);
            this.CommandBar.Size = new System.Drawing.Size(66, 171);
            this.CommandBar.TabIndex = 3;
            // 
            // btnNew
            // 
            this.btnNew.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnNew.Location = new System.Drawing.Point(2, 2);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(60, 23);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "&New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Action = Scalable.Win.Enums.CommandBarAction.Open;
            this.btnEdit.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnEdit.Enabled = false;
            this.btnEdit.Location = new System.Drawing.Point(2, 26);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(60, 23);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "&Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Action = Scalable.Win.Enums.CommandBarAction.Open;
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(2, 50);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(60, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // uReminder
            // 
            this.uReminder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uReminder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uReminder.Enabled = false;
            this.uReminder.Location = new System.Drawing.Point(2, 174);
            this.uReminder.MaximumSize = new System.Drawing.Size(840, 70);
            this.uReminder.MinimumSize = new System.Drawing.Size(381, 70);
            this.uReminder.Name = "uReminder";
            this.uReminder.Size = new System.Drawing.Size(382, 70);
            this.uReminder.TabIndex = 2;
            // 
            // btnOpen
            // 
            this.btnOpen.Action = Scalable.Win.Enums.CommandBarAction.Open;
            this.btnOpen.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnOpen.Enabled = false;
            this.btnOpen.Location = new System.Drawing.Point(2, 74);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(60, 23);
            this.btnOpen.TabIndex = 3;
            this.btnOpen.Text = "&Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // UReminders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uReminder);
            this.MaximumSize = new System.Drawing.Size(840, 640);
            this.MinimumSize = new System.Drawing.Size(387, 153);
            this.Name = "UReminders";
            this.Size = new System.Drawing.Size(387, 246);
            this.Controls.SetChildIndex(this.uReminder, 0);
            this.Controls.SetChildIndex(this.CommandBar, 0);
            this.Controls.SetChildIndex(this.txt, 0);
            this.Controls.SetChildIndex(this.lvw, 0);
            this.CommandBar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Scalable.Win.Controls.iCommandButton btnNew;
        private Scalable.Win.Controls.iCommandButton btnEdit;
        private Scalable.Win.Controls.iCommandButton btnDelete;
        private UReminder uReminder;
        private Scalable.Win.Controls.iCommandButton btnOpen;
    }
}
