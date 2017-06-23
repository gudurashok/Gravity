namespace Scalable.Win.FormControls
{
    partial class UFormBase
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
            this.CommandBar = new Scalable.Win.Controls.iCommandBar();
            this.SuspendLayout();
            // 
            // CommandBar
            // 
            this.CommandBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CommandBar.BackColor = System.Drawing.SystemColors.Control;
            this.CommandBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CommandBar.Location = new System.Drawing.Point(-1, 67);
            this.CommandBar.Name = "CommandBar";
            this.CommandBar.Size = new System.Drawing.Size(93, 35);
            this.CommandBar.TabIndex = 15;
            // 
            // UFormBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CommandBar);
            this.Name = "UFormBase";
            this.ResumeLayout(false);

        }

        #endregion

        protected Scalable.Win.Controls.iCommandBar CommandBar;




    }
}
