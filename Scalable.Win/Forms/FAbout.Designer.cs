using Scalable.Win.FormControls;

namespace Scalable.Win.Forms
{
    partial class FAbout
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
            this.uAbout1 = new UAbout();
            this.SuspendLayout();
            // 
            // uAbout1
            // 
            this.uAbout1.BackColor = System.Drawing.Color.White;
            this.uAbout1.Location = new System.Drawing.Point(0, 3);
            this.uAbout1.Name = "uAbout1";
            this.uAbout1.Size = new System.Drawing.Size(446, 308);
            this.uAbout1.TabIndex = 0;
            // 
            // FAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(447, 313);
            this.ControlBox = false;
            this.Controls.Add(this.uAbout1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FAbout";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About Gravity";
            this.ResumeLayout(false);

        }

        #endregion

        private UAbout uAbout1;


    }
}