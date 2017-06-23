namespace Scalable.Win.Forms
{
    partial class FTimeCalendar
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
            this.uTimeCalender = new Scalable.Win.FormControls.UTimeCalendar();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Size = new System.Drawing.Size(228, 43);
            // 
            // picLogo
            // 
            this.picLogo.Location = new System.Drawing.Point(185, 2);
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(176, 39);
            // 
            // uTimeCalender
            // 
            this.uTimeCalender.Location = new System.Drawing.Point(0, 44);
            this.uTimeCalender.Name = "uTimeCalender";
            this.uTimeCalender.Size = new System.Drawing.Size(227, 184);
            this.uTimeCalender.TabIndex = 13;
            this.uTimeCalender.DateTimeSelected += new System.EventHandler<Scalable.Win.Events.DateTimeEventArgs>(this.uTimeCalender_DateTimeSelected);
            // 
            // FTimeCalendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(228, 228);
            this.Controls.Add(this.uTimeCalender);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(234, 252);
            this.MinimumSize = new System.Drawing.Size(234, 252);
            this.Name = "FTimeCalendar";
            this.Text = "Date and Time Selection";
            this.Controls.SetChildIndex(this.uTimeCalender, 0);
            this.Controls.SetChildIndex(this.pnlHeader, 0);
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FormControls.UTimeCalendar uTimeCalender;
    }
}