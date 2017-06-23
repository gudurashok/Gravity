namespace Synergy.UC.Forms
{
    partial class FSmsPad
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
            this.uSmsPad = new Synergy.UC.Controls.USmsPad();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Size = new System.Drawing.Size(447, 43);
            // 
            // picLogo
            // 
            this.picLogo.Location = new System.Drawing.Point(404, 2);
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(395, 39);
            // 
            // uSmsPad
            // 
            this.uSmsPad.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uSmsPad.Location = new System.Drawing.Point(0, 44);
            this.uSmsPad.MinimumSize = new System.Drawing.Size(306, 144);
            this.uSmsPad.Name = "uSmsPad";
            this.uSmsPad.Size = new System.Drawing.Size(446, 219);
            this.uSmsPad.TabIndex = 13;
            this.uSmsPad.CloseForm += new System.EventHandler(this.uSmsPad_CloseForm);
            // 
            // FSmsPad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 263);
            this.Controls.Add(this.uSmsPad);
            this.MinimumSize = new System.Drawing.Size(366, 266);
            this.Name = "FSmsPad";
            this.Text = "FSmsPad";
            this.Controls.SetChildIndex(this.uSmsPad, 0);
            this.Controls.SetChildIndex(this.pnlHeader, 0);
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.USmsPad uSmsPad;
    }
}