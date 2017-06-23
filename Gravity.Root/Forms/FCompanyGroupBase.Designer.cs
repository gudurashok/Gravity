namespace Gravity.Root.Forms
{
    partial class FCompanyGroupBase
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
            this.uCompanyGroup = new Gravity.Root.Controls.UCompanyGroup();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Size = new System.Drawing.Size(373, 43);
            // 
            // picLogo
            // 
            this.picLogo.Location = new System.Drawing.Point(330, 2);
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(322, 39);
            this.lblTitle.Text = "Enter Company Group Details";
            // 
            // uCompanyGroup
            // 
            this.uCompanyGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uCompanyGroup.Location = new System.Drawing.Point(0, 43);
            this.uCompanyGroup.Name = "uCompanyGroup";
            this.uCompanyGroup.Size = new System.Drawing.Size(373, 109);
            this.uCompanyGroup.TabIndex = 8;
            this.uCompanyGroup.CoGroupSaved += new System.EventHandler<Gravity.Root.Events.CoGroupSavedEventArgs>(this.uCompanyGroup_CoGroupSaved);
            // 
            // FCompanyGroupBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 151);
            this.Controls.Add(this.uCompanyGroup);
            this.MinimumSize = new System.Drawing.Size(381, 185);
            this.Name = "FCompanyGroupBase";
            this.Text = "Company groups";
            this.Controls.SetChildIndex(this.pnlHeader, 0);
            this.Controls.SetChildIndex(this.uCompanyGroup, 0);
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected Controls.UCompanyGroup uCompanyGroup;
    }
}