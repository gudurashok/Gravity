namespace Gravity.Root.Controls
{
    partial class UUserRole
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
            this.lblUserRoles = new Scalable.Win.Controls.iLabel();
            this.uUserRoleAssign = new Gravity.Root.Controls.URoles();
            this.iPanel1 = new Scalable.Win.Controls.iPanel();
            this.SuspendLayout();
            // 
            // txt
            // 
            this.txt.Location = new System.Drawing.Point(3, 2);
            this.txt.Size = new System.Drawing.Size(262, 20);
            // 
            // lvw
            // 
            this.lvw.Location = new System.Drawing.Point(3, 25);
            this.lvw.Size = new System.Drawing.Size(262, 133);
            this.lvw.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvw_ItemSelectionChanged);
            // 
            // CommandBar
            // 
            this.CommandBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CommandBar.Location = new System.Drawing.Point(159, 27);
            this.CommandBar.Size = new System.Drawing.Size(106, 130);
            this.CommandBar.Visible = false;
            // 
            // lblUserRoles
            // 
            this.lblUserRoles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblUserRoles.AutoSize = true;
            this.lblUserRoles.Location = new System.Drawing.Point(0, 165);
            this.lblUserRoles.Name = "lblUserRoles";
            this.lblUserRoles.Size = new System.Drawing.Size(59, 13);
            this.lblUserRoles.TabIndex = 10;
            this.lblUserRoles.Text = "&User Roles";
            // 
            // uUserRoleAssign
            // 
            this.uUserRoleAssign.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uUserRoleAssign.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uUserRoleAssign.Location = new System.Drawing.Point(2, 188);
            this.uUserRoleAssign.Name = "uUserRoleAssign";
            this.uUserRoleAssign.Size = new System.Drawing.Size(264, 148);
            this.uUserRoleAssign.TabIndex = 16;
            // 
            // iPanel1
            // 
            this.iPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.iPanel1.Location = new System.Drawing.Point(62, 172);
            this.iPanel1.Name = "iPanel1";
            this.iPanel1.Size = new System.Drawing.Size(205, 1);
            this.iPanel1.TabIndex = 17;
            // 
            // UUserRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.iPanel1);
            this.Controls.Add(this.uUserRoleAssign);
            this.Controls.Add(this.lblUserRoles);
            this.Name = "UUserRole";
            this.Size = new System.Drawing.Size(268, 338);
            this.Controls.SetChildIndex(this.CommandBar, 0);
            this.Controls.SetChildIndex(this.lvw, 0);
            this.Controls.SetChildIndex(this.txt, 0);
            this.Controls.SetChildIndex(this.lblUserRoles, 0);
            this.Controls.SetChildIndex(this.uUserRoleAssign, 0);
            this.Controls.SetChildIndex(this.iPanel1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Scalable.Win.Controls.iLabel lblUserRoles;
        private URoles uUserRoleAssign;
        private Scalable.Win.Controls.iPanel iPanel1;


    }
}
