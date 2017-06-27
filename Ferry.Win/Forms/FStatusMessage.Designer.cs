namespace Ferry.Win.Forms
{
    partial class FStatusMessage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FStatusMessage));
            this.picWaitIndicator = new Scalable.Win.Controls.iPictureBox();
            this.pnlStart = new Scalable.Win.Controls.iPanel();
            this.lblMessage = new Scalable.Win.Controls.iLabel();
            ((System.ComponentModel.ISupportInitialize)(this.picWaitIndicator)).BeginInit();
            this.pnlStart.SuspendLayout();
            this.SuspendLayout();
            // 
            // picWaitIndicator
            // 
            this.picWaitIndicator.Image = ((System.Drawing.Image)(resources.GetObject("picWaitIndicator.Image")));
            this.picWaitIndicator.Location = new System.Drawing.Point(8, 35);
            this.picWaitIndicator.Margin = new System.Windows.Forms.Padding(4);
            this.picWaitIndicator.Name = "picWaitIndicator";
            this.picWaitIndicator.Size = new System.Drawing.Size(51, 49);
            this.picWaitIndicator.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picWaitIndicator.TabIndex = 7;
            this.picWaitIndicator.TabStop = false;
            // 
            // pnlStart
            // 
            this.pnlStart.Controls.Add(this.lblMessage);
            this.pnlStart.Location = new System.Drawing.Point(66, 35);
            this.pnlStart.Margin = new System.Windows.Forms.Padding(4);
            this.pnlStart.Name = "pnlStart";
            this.pnlStart.Size = new System.Drawing.Size(413, 49);
            this.pnlStart.TabIndex = 8;
            // 
            // lblMessage
            // 
            this.lblMessage.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.Blue;
            this.lblMessage.Location = new System.Drawing.Point(4, 14);
            this.lblMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(397, 21);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "Status message...";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FStatusMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 135);
            this.ControlBox = false;
            this.Controls.Add(this.picWaitIndicator);
            this.Controls.Add(this.pnlStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FStatusMessage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ferry: Creating company group";
            ((System.ComponentModel.ISupportInitialize)(this.picWaitIndicator)).EndInit();
            this.pnlStart.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Scalable.Win.Controls.iPictureBox picWaitIndicator;
        private Scalable.Win.Controls.iPanel pnlStart;
        private Scalable.Win.Controls.iLabel lblMessage;
    }
}