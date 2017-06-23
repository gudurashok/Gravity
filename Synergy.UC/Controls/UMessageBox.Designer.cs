namespace Synergy.UC.Controls
{
    partial class UMessageBox
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
            this.btnAcknowledgeAll = new Scalable.Win.Controls.iCommandButton();
            this.btnAcknowledge = new Scalable.Win.Controls.iCommandButton();
            this.btnDismiss = new Scalable.Win.Controls.iCommandButton();
            this.btnDismissAll = new Scalable.Win.Controls.iCommandButton();
            this.btnComment = new Scalable.Win.Controls.iCommandButton();
            this.CommandBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(410, 5);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(410, 5);
            // 
            // txt
            // 
            this.txt.Size = new System.Drawing.Size(487, 20);
            // 
            // lvw
            // 
            this.lvw.Size = new System.Drawing.Size(487, 228);
            // 
            // CommandBar
            // 
            this.CommandBar.Controls.Add(this.btnDismiss);
            this.CommandBar.Controls.Add(this.btnAcknowledge);
            this.CommandBar.Controls.Add(this.btnAcknowledgeAll);
            this.CommandBar.Controls.Add(this.btnDismissAll);
            this.CommandBar.Controls.Add(this.btnComment);
            this.CommandBar.Location = new System.Drawing.Point(-1, 255);
            this.CommandBar.Size = new System.Drawing.Size(494, 35);
            this.CommandBar.Controls.SetChildIndex(this.btnOK, 0);
            this.CommandBar.Controls.SetChildIndex(this.btnOpen, 0);
            this.CommandBar.Controls.SetChildIndex(this.btnComment, 0);
            this.CommandBar.Controls.SetChildIndex(this.btnDismissAll, 0);
            this.CommandBar.Controls.SetChildIndex(this.btnAcknowledgeAll, 0);
            this.CommandBar.Controls.SetChildIndex(this.btnAcknowledge, 0);
            this.CommandBar.Controls.SetChildIndex(this.btnDismiss, 0);
            // 
            // btnAcknowledgeAll
            // 
            this.btnAcknowledgeAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAcknowledgeAll.Enabled = false;
            this.btnAcknowledgeAll.Location = new System.Drawing.Point(250, 5);
            this.btnAcknowledgeAll.Name = "btnAcknowledgeAll";
            this.btnAcknowledgeAll.Size = new System.Drawing.Size(75, 23);
            this.btnAcknowledgeAll.TabIndex = 4;
            this.btnAcknowledgeAll.Text = "Ac&k All";
            this.btnAcknowledgeAll.UseVisualStyleBackColor = true;
            this.btnAcknowledgeAll.Click += new System.EventHandler(this.btnAcknowledgeAll_Click);
            // 
            // btnAcknowledge
            // 
            this.btnAcknowledge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAcknowledge.Enabled = false;
            this.btnAcknowledge.Location = new System.Drawing.Point(164, 5);
            this.btnAcknowledge.Name = "btnAcknowledge";
            this.btnAcknowledge.Size = new System.Drawing.Size(81, 23);
            this.btnAcknowledge.TabIndex = 3;
            this.btnAcknowledge.Text = "&Acknowledge";
            this.btnAcknowledge.UseVisualStyleBackColor = true;
            this.btnAcknowledge.Click += new System.EventHandler(this.btnAcknowledge_Click);
            // 
            // btnDismmiss
            // 
            this.btnDismiss.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDismiss.Location = new System.Drawing.Point(6, 5);
            this.btnDismiss.Name = "btnDismiss";
            this.btnDismiss.Size = new System.Drawing.Size(75, 23);
            this.btnDismiss.TabIndex = 1;
            this.btnDismiss.Text = "&Dismiss";
            this.btnDismiss.UseVisualStyleBackColor = true;
            this.btnDismiss.Click += new System.EventHandler(this.btnDismiss_Click);
            // 
            // btnDismissAll
            // 
            this.btnDismissAll.Action = Scalable.Win.Enums.CommandBarAction.Open;
            this.btnDismissAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDismissAll.Location = new System.Drawing.Point(85, 5);
            this.btnDismissAll.Name = "btnDismissAll";
            this.btnDismissAll.Size = new System.Drawing.Size(75, 23);
            this.btnDismissAll.TabIndex = 2;
            this.btnDismissAll.Text = "Di&smiss All";
            this.btnDismissAll.UseVisualStyleBackColor = true;
            this.btnDismissAll.Click += new System.EventHandler(this.btnDismissAll_Click);
            // 
            // btnComment
            // 
            this.btnComment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnComment.Enabled = false;
            this.btnComment.Location = new System.Drawing.Point(330, 5);
            this.btnComment.Name = "btnComment";
            this.btnComment.Size = new System.Drawing.Size(75, 23);
            this.btnComment.TabIndex = 4;
            this.btnComment.Text = "&Comment";
            this.btnComment.UseVisualStyleBackColor = true;
            this.btnComment.Click += new System.EventHandler(this.btnComment_Click);
            // 
            // UMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.MinimumSize = new System.Drawing.Size(492, 289);
            this.Name = "UMessageBox";
            this.Size = new System.Drawing.Size(492, 289);
            this.CommandBar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Scalable.Win.Controls.iCommandButton btnAcknowledgeAll;
        private Scalable.Win.Controls.iCommandButton btnDismiss;
        private Scalable.Win.Controls.iCommandButton btnAcknowledge;
        private Scalable.Win.Controls.iCommandButton btnDismissAll;
        private Scalable.Win.Controls.iCommandButton btnComment;
    }
}
