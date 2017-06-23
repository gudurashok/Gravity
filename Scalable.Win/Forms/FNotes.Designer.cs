using Scalable.Win.FormControls;

namespace Scalable.Win.Forms
{
    partial class FNotes
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
            this.uNotes = new Scalable.Win.FormControls.UNotes();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Size = new System.Drawing.Size(394, 43);
            // 
            // picLogo
            // 
            this.picLogo.Location = new System.Drawing.Point(351, 2);
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(342, 39);
            // 
            // uNotes
            // 
            this.uNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uNotes.Location = new System.Drawing.Point(0, 44);
            this.uNotes.Name = "uNotes";
            this.uNotes.Size = new System.Drawing.Size(394, 258);
            this.uNotes.TabIndex = 13;
            this.uNotes.NotesSaved += new System.EventHandler(this.uNotes_NotesSaved);
            // 
            // FNotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 302);
            this.Controls.Add(this.uNotes);
            this.MinimumSize = new System.Drawing.Size(321, 271);
            this.Name = "FNotes";
            this.Text = "FNotes";
            this.Controls.SetChildIndex(this.uNotes, 0);
            this.Controls.SetChildIndex(this.pnlHeader, 0);
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UNotes uNotes;


    }
}