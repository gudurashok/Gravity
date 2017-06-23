using System.ComponentModel;

namespace Scalable.Win.Controls
{
    partial class iTextBoxButton
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(iTextBoxButton));
            this.Button = new Scalable.Win.Controls.iButton();
            this.TextBox = new Scalable.Win.Controls.iTextBox();
            this.SuspendLayout();
            // 
            // Button
            // 
            this.Button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Button.BackgroundImage")));
            this.Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Button.Location = new System.Drawing.Point(99, -1);
            this.Button.Name = "Button";
            this.Button.Size = new System.Drawing.Size(23, 21);
            this.Button.TabIndex = 0;
            this.Button.TabStop = false;
            this.Button.UseVisualStyleBackColor = true;
            // 
            // TextBox
            // 
            this.TextBox.Location = new System.Drawing.Point(0, 0);
            this.TextBox.Name = "TextBox";
            this.TextBox.Size = new System.Drawing.Size(98, 20);
            this.TextBox.TabIndex = 0;
            // 
            // iTextBoxButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Button);
            this.Controls.Add(this.TextBox);
            this.Name = "iTextBoxButton";
            this.Size = new System.Drawing.Size(123, 20);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public iTextBox TextBox;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public iButton Button;
    }
}
