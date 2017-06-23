using Synergy.UC.Controls;

namespace Synergy.UC.Forms
{
    partial class FTask
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
            this.uTask = new Synergy.UC.Controls.UTask();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Size = new System.Drawing.Size(587, 43);
            // 
            // picLogo
            // 
            this.picLogo.Location = new System.Drawing.Point(723, 2);
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(714, 39);
            // 
            // uTask
            // 
            this.uTask.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uTask.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uTask.Location = new System.Drawing.Point(-1, 42);
            this.uTask.Name = "uTask";
            this.uTask.Size = new System.Drawing.Size(590, 339);
            this.uTask.TabIndex = 13;
            // 
            // FTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 380);
            this.Controls.Add(this.uTask);
            this.MinimumSize = new System.Drawing.Size(595, 366);
            this.Name = "FTask";
            this.Text = "FTask";
            this.Controls.SetChildIndex(this.pnlHeader, 0);
            this.Controls.SetChildIndex(this.uTask, 0);
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UTask uTask;
    }
}