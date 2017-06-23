namespace Gravity.Root.Controls
{
    partial class UUserFeedback
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
            this.lblFeedbak = new Scalable.Win.Controls.iLabel();
            this.txtFeedback = new Scalable.Win.Controls.iTextBox();
            this.btnSend = new Scalable.Win.Controls.iButton();
            this.cmbFeedbackType = new Scalable.Win.Controls.iComboBox();
            this.lblFeedbackType = new Scalable.Win.Controls.iLabel();
            this.CommandBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // CommandBar
            // 
            this.CommandBar.Controls.Add(this.btnSend);
            this.CommandBar.Location = new System.Drawing.Point(-1, 134);
            this.CommandBar.Size = new System.Drawing.Size(253, 35);
            this.CommandBar.TabIndex = 4;
            // 
            // lblFeedbak
            // 
            this.lblFeedbak.AutoSize = true;
            this.lblFeedbak.Location = new System.Drawing.Point(3, 6);
            this.lblFeedbak.Name = "lblFeedbak";
            this.lblFeedbak.Size = new System.Drawing.Size(106, 13);
            this.lblFeedbak.TabIndex = 0;
            this.lblFeedbak.Text = "&Description:";
            // 
            // txtFeedback
            // 
            this.txtFeedback.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFeedback.Location = new System.Drawing.Point(3, 27);
            this.txtFeedback.Multiline = true;
            this.txtFeedback.Name = "txtFeedback";
            this.txtFeedback.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtFeedback.Size = new System.Drawing.Size(245, 101);
            this.txtFeedback.TabIndex = 3;
            // 
            // btnSend
            // 
            this.btnSend.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSend.Location = new System.Drawing.Point(88, 5);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "&Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // cmbFeedbackType
            // 
            this.cmbFeedbackType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFeedbackType.FormattingEnabled = true;
            this.cmbFeedbackType.Location = new System.Drawing.Point(142, 3);
            this.cmbFeedbackType.Name = "cmbFeedbackType";
            this.cmbFeedbackType.Size = new System.Drawing.Size(106, 21);
            this.cmbFeedbackType.TabIndex = 2;
            // 
            // lblFeedbackType
            // 
            this.lblFeedbackType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFeedbackType.AutoSize = true;
            this.lblFeedbackType.Location = new System.Drawing.Point(108, 6);
            this.lblFeedbackType.Name = "lblFeedbackType";
            this.lblFeedbackType.Size = new System.Drawing.Size(34, 13);
            this.lblFeedbackType.TabIndex = 1;
            this.lblFeedbackType.Text = "&Type:";
            // 
            // UUserFeedback
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblFeedbackType);
            this.Controls.Add(this.cmbFeedbackType);
            this.Controls.Add(this.txtFeedback);
            this.Controls.Add(this.lblFeedbak);
            this.Name = "UUserFeedback";
            this.Size = new System.Drawing.Size(251, 168);
            this.Controls.SetChildIndex(this.CommandBar, 0);
            this.Controls.SetChildIndex(this.lblFeedbak, 0);
            this.Controls.SetChildIndex(this.txtFeedback, 0);
            this.Controls.SetChildIndex(this.cmbFeedbackType, 0);
            this.Controls.SetChildIndex(this.lblFeedbackType, 0);
            this.CommandBar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Scalable.Win.Controls.iButton btnSend;
        private Scalable.Win.Controls.iLabel lblFeedbak;
        private Scalable.Win.Controls.iTextBox txtFeedback;
        private Scalable.Win.Controls.iComboBox cmbFeedbackType;
        private Scalable.Win.Controls.iLabel lblFeedbackType;
    }
}
