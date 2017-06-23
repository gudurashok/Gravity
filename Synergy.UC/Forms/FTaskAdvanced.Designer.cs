using Synergy.UC.Controls;

namespace Synergy.UC.Forms
{
    partial class FTaskAdvanced
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
            this.uTaskAdvanced = new Synergy.UC.Controls.UTaskAdvanced();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Size = new System.Drawing.Size(494, 43);
            // 
            // picLogo
            // 
            this.picLogo.Location = new System.Drawing.Point(451, 2);
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(442, 39);
            // 
            // uTaskAdvanced
            // 
            this.uTaskAdvanced.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uTaskAdvanced.Location = new System.Drawing.Point(0, 44);
            this.uTaskAdvanced.MinimumSize = new System.Drawing.Size(329, 217);
            this.uTaskAdvanced.Name = "uTaskAdvanced";
            this.uTaskAdvanced.Size = new System.Drawing.Size(494, 281);
            this.uTaskAdvanced.TabIndex = 13;
            // 
            // FTaskAdvanced
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 325);
            this.Controls.Add(this.uTaskAdvanced);
            this.MinimumSize = new System.Drawing.Size(344, 302);
            this.Name = "FTaskAdvanced";
            this.Text = "FTaskAdvanced";
            this.Controls.SetChildIndex(this.uTaskAdvanced, 0);
            this.Controls.SetChildIndex(this.pnlHeader, 0);
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UTaskAdvanced uTaskAdvanced;
    }
}