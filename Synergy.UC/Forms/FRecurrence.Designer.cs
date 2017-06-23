using Synergy.UC.Controls;

namespace Synergy.UC.Forms
{
    partial class FRecurrence
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
            this.uRecurrence = new Synergy.UC.Controls.URecurrence();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Size = new System.Drawing.Size(440, 43);
            // 
            // picLogo
            // 
            this.picLogo.Location = new System.Drawing.Point(557, 2);
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(548, 39);
            // 
            // uRecurrence
            // 
            this.uRecurrence.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uRecurrence.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uRecurrence.Location = new System.Drawing.Point(-1, 43);
            this.uRecurrence.Name = "uRecurrence";
            this.uRecurrence.Size = new System.Drawing.Size(442, 287);
            this.uRecurrence.TabIndex = 13;
            // 
            // FRecurrence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 329);
            this.Controls.Add(this.uRecurrence);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FRecurrence";
            this.Text = "FRecurrence";
            this.Controls.SetChildIndex(this.uRecurrence, 0);
            this.Controls.SetChildIndex(this.pnlHeader, 0);
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private URecurrence uRecurrence;
    }
}