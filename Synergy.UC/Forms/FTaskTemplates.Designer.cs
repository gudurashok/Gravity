namespace Synergy.UC.Forms
{
    partial class FTaskTemplates
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
            this.uTaskTemplates = new Synergy.UC.Controls.UTaskTemplates();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Size = new System.Drawing.Size(284, 43);
            // 
            // picLogo
            // 
            this.picLogo.Location = new System.Drawing.Point(241, 2);
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(232, 39);
            // 
            // uTaskTemplates
            // 
            this.uTaskTemplates.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uTaskTemplates.Location = new System.Drawing.Point(0, 44);
            this.uTaskTemplates.MinimumSize = new System.Drawing.Size(276, 276);
            this.uTaskTemplates.Name = "uTaskTemplates";
            this.uTaskTemplates.Size = new System.Drawing.Size(284, 280);
            this.uTaskTemplates.TabIndex = 13;
            // 
            // FTaskTemplates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 324);
            this.Controls.Add(this.uTaskTemplates);
            this.MinimumSize = new System.Drawing.Size(292, 358);
            this.Name = "FTaskTemplates";
            this.Text = "FTaskTemplates";
            this.Controls.SetChildIndex(this.uTaskTemplates, 0);
            this.Controls.SetChildIndex(this.pnlHeader, 0);
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.UTaskTemplates uTaskTemplates;

    }
}