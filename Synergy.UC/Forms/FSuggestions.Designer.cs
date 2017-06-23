namespace Synergy.UC.Forms
{
    partial class FSuggestions
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
            this.uSuggestions = new Synergy.UC.Controls.USuggestions();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Size = new System.Drawing.Size(240, 43);
            // 
            // picLogo
            // 
            this.picLogo.Location = new System.Drawing.Point(197, 2);
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(188, 39);
            // 
            // uSuggestions
            // 
            this.uSuggestions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uSuggestions.Location = new System.Drawing.Point(0, 45);
            this.uSuggestions.Name = "uSuggestions";
            this.uSuggestions.Size = new System.Drawing.Size(240, 248);
            this.uSuggestions.TabIndex = 13;
            // 
            // FSuggestions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 292);
            this.Controls.Add(this.uSuggestions);
            this.MinimumSize = new System.Drawing.Size(248, 326);
            this.Name = "FSuggestions";
            this.Text = "FSuggestions";
            this.Controls.SetChildIndex(this.uSuggestions, 0);
            this.Controls.SetChildIndex(this.pnlHeader, 0);
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.USuggestions uSuggestions;
    }
}