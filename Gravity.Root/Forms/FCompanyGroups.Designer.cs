namespace Gravity.Root.Forms
{
    partial class FCompanyGroups
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.uCompanyGroups = new Gravity.Root.Controls.UCompanyGroups();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Size = new System.Drawing.Size(292, 43);
            // 
            // picLogo
            // 
            this.picLogo.Location = new System.Drawing.Point(249, 2);
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(240, 39);
            this.lblTitle.Text = "Select desired company group";
            // 
            // uCompanyGroups
            // 
            this.uCompanyGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uCompanyGroups.Location = new System.Drawing.Point(0, 44);
            this.uCompanyGroups.Name = "uCompanyGroups";
            this.uCompanyGroups.Size = new System.Drawing.Size(292, 294);
            this.uCompanyGroups.TabIndex = 13;
            this.uCompanyGroups.OpenCoGroup += new System.EventHandler<Gravity.Root.Events.OpenCoGroupEventArgs>(this.uCompanyGroups_OpenCoGroup);
            // 
            // FCompanyGroups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(292, 337);
            this.Controls.Add(this.uCompanyGroups);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 371);
            this.Name = "FCompanyGroups";
            this.ShowInTaskbar = true;
            this.Text = "Company groups";
            this.Controls.SetChildIndex(this.uCompanyGroups, 0);
            this.Controls.SetChildIndex(this.pnlHeader, 0);
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Controls.UCompanyGroups uCompanyGroups;

    }
}