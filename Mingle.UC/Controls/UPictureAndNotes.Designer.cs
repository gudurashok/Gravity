namespace Mingle.UC.Controls
{
    partial class UPictureAndNotes
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
            this.pctPhoto = new Scalable.Win.Controls.iPictureBox();
            this.btnAdd = new Scalable.Win.Controls.iCommandButton();
            this.btnRemove = new Scalable.Win.Controls.iCommandButton();
            this.lblNotes = new Scalable.Win.Controls.iLabel();
            this.rtbNotes = new Scalable.Win.Controls.iRichTextBox();
            this.lblPicture = new Scalable.Win.Controls.iLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pctPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // pctPhoto
            // 
            this.pctPhoto.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pctPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctPhoto.Location = new System.Drawing.Point(4, 23);
            this.pctPhoto.Name = "pctPhoto";
            this.pctPhoto.Size = new System.Drawing.Size(120, 125);
            this.pctPhoto.TabIndex = 0;
            this.pctPhoto.TabStop = false;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.Green;
            this.btnAdd.Location = new System.Drawing.Point(79, 0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(22, 22);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.ForeColor = System.Drawing.Color.Red;
            this.btnRemove.Location = new System.Drawing.Point(102, 0);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(22, 22);
            this.btnRemove.TabIndex = 4;
            this.btnRemove.Text = "x";
            this.btnRemove.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(126, 5);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(38, 13);
            this.lblNotes.TabIndex = 0;
            this.lblNotes.Text = "Notes:";
            // 
            // rtbNotes
            // 
            this.rtbNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbNotes.Location = new System.Drawing.Point(126, 23);
            this.rtbNotes.Name = "rtbNotes";
            this.rtbNotes.ShowSelectionMargin = true;
            this.rtbNotes.Size = new System.Drawing.Size(200, 126);
            this.rtbNotes.TabIndex = 1;
            this.rtbNotes.Text = "";
            // 
            // lblPicture
            // 
            this.lblPicture.AutoSize = true;
            this.lblPicture.Location = new System.Drawing.Point(1, 5);
            this.lblPicture.Name = "lblPicture";
            this.lblPicture.Size = new System.Drawing.Size(43, 13);
            this.lblPicture.TabIndex = 2;
            this.lblPicture.Text = "Picture:";
            // 
            // UPictureAndNotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rtbNotes);
            this.Controls.Add(this.lblPicture);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.pctPhoto);
            this.MaximumSize = new System.Drawing.Size(840, 151);
            this.MinimumSize = new System.Drawing.Size(328, 151);
            this.Name = "UPictureAndNotes";
            this.Size = new System.Drawing.Size(328, 151);
            ((System.ComponentModel.ISupportInitialize)(this.pctPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Scalable.Win.Controls.iPictureBox pctPhoto;
        private Scalable.Win.Controls.iCommandButton btnAdd;
        private Scalable.Win.Controls.iCommandButton btnRemove;
        private Scalable.Win.Controls.iLabel lblNotes;
        private Scalable.Win.Controls.iRichTextBox rtbNotes;
        private Scalable.Win.Controls.iLabel lblPicture;

    }
}
