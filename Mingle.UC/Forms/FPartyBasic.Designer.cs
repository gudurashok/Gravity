using Mingle.UC.Controls;

namespace Mingle.UC.Forms
{
    partial class FPartyBasic
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
            this.lblTitle2 = new System.Windows.Forms.Label();
            this.uParty = new Mingle.UC.Controls.UParty();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblTitle2);
            this.pnlHeader.Size = new System.Drawing.Size(632, 43);
            this.pnlHeader.Controls.SetChildIndex(this.lblTitle, 0);
            this.pnlHeader.Controls.SetChildIndex(this.lblTitle2, 0);
            this.pnlHeader.Controls.SetChildIndex(this.picLogo, 0);
            // 
            // picLogo
            // 
            this.picLogo.Location = new System.Drawing.Point(589, 2);
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(3, 3);
            this.lblTitle.Size = new System.Drawing.Size(580, 22);
            // 
            // lblTitle2
            // 
            this.lblTitle2.AutoSize = true;
            this.lblTitle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle2.ForeColor = System.Drawing.Color.Yellow;
            this.lblTitle2.Location = new System.Drawing.Point(3, 26);
            this.lblTitle2.Name = "lblTitle2";
            this.lblTitle2.Size = new System.Drawing.Size(117, 13);
            this.lblTitle2.TabIndex = 8;
            this.lblTitle2.Text = "Party basic information";
            this.lblTitle2.Visible = false;
            // 
            // uParty
            // 
            this.uParty.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uParty.Location = new System.Drawing.Point(0, 45);
            this.uParty.Name = "uParty";
            this.uParty.Size = new System.Drawing.Size(632, 401);
            this.uParty.TabIndex = 13;
            // 
            // FPartyBasic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 446);
            this.Controls.Add(this.uParty);
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "FPartyBasic";
            this.Text = "Party Basic Info";
            this.Controls.SetChildIndex(this.uParty, 0);
            this.Controls.SetChildIndex(this.pnlHeader, 0);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle2;
        private UParty uParty;
    }
}