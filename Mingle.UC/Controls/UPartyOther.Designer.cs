namespace Mingle.UC.Controls
{
    partial class UPartyOther
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
            this.uPersonOther = new Mingle.UC.Controls.UPersonOther();
            this.uOrganizationOther = new Mingle.UC.Controls.UOrganizationOther();
            this.SuspendLayout();
            // 
            // uPersonOther
            // 
            this.uPersonOther.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uPersonOther.Location = new System.Drawing.Point(1, 0);
            this.uPersonOther.MinimumSize = new System.Drawing.Size(432, 312);
            this.uPersonOther.Name = "uPersonOther";
            this.uPersonOther.Size = new System.Drawing.Size(472, 338);
            this.uPersonOther.TabIndex = 0;
            // 
            // uOrganizationOther
            // 
            this.uOrganizationOther.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uOrganizationOther.Location = new System.Drawing.Point(1, 0);
            this.uOrganizationOther.Name = "uOrganizationOther";
            this.uOrganizationOther.Size = new System.Drawing.Size(472, 338);
            this.uOrganizationOther.TabIndex = 0;
            // 
            // UPartyOther
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uOrganizationOther);
            this.Controls.Add(this.uPersonOther);
            this.Name = "UPartyOther";
            this.Size = new System.Drawing.Size(473, 338);
            this.ResumeLayout(false);

        }

        #endregion

        private UPersonOther uPersonOther;
        private UOrganizationOther uOrganizationOther;
    }
}
