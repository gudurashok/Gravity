namespace Mingle.UC.Controls
{
    partial class UFullName
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
            this.txtLast = new Scalable.Win.Controls.iTextBox();
            this.txtMiddle = new Scalable.Win.Controls.iTextBox();
            this.txtFirst = new Scalable.Win.Controls.iTextBox();
            this.SuspendLayout();
            // 
            // txtLast
            // 
            this.txtLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLast.Location = new System.Drawing.Point(263, 0);
            this.txtLast.MaxLength = 50;
            this.txtLast.Name = "txtLast";
            this.txtLast.Size = new System.Drawing.Size(92, 20);
            this.txtLast.TabIndex = 2;
            this.txtLast.Tag = "Last";
            this.txtLast.Leave += new System.EventHandler(this.txtFullName_Leave);
            // 
            // txtMiddle
            // 
            this.txtMiddle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMiddle.Location = new System.Drawing.Point(211, 0);
            this.txtMiddle.MaxLength = 50;
            this.txtMiddle.Name = "txtMiddle";
            this.txtMiddle.Size = new System.Drawing.Size(51, 20);
            this.txtMiddle.TabIndex = 1;
            this.txtMiddle.Tag = "Middle";
            this.txtMiddle.Leave += new System.EventHandler(this.txtFullName_Leave);
            // 
            // txtFirst
            // 
            this.txtFirst.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFirst.Location = new System.Drawing.Point(0, 0);
            this.txtFirst.MaxLength = 50;
            this.txtFirst.Name = "txtFirst";
            this.txtFirst.Size = new System.Drawing.Size(210, 20);
            this.txtFirst.TabIndex = 0;
            this.txtFirst.Tag = "First";
            this.txtFirst.Leave += new System.EventHandler(this.txtFullName_Leave);
            // 
            // UFullName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtLast);
            this.Controls.Add(this.txtMiddle);
            this.Controls.Add(this.txtFirst);
            this.Name = "UFullName";
            this.Size = new System.Drawing.Size(356, 21);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Scalable.Win.Controls.iTextBox txtLast;
        private Scalable.Win.Controls.iTextBox txtMiddle;
        private Scalable.Win.Controls.iTextBox txtFirst;

    }
}
