namespace Mingle.UC.Controls
{
    partial class UOrganizationOther
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
            this.txtAbbreviation = new Scalable.Win.Controls.iTextBox();
            this.lblAbbreviation = new Scalable.Win.Controls.iLabel();
            this.SuspendLayout();
            // 
            // txtAbbreviation
            // 
            this.txtAbbreviation.Location = new System.Drawing.Point(72, 2);
            this.txtAbbreviation.Name = "txtAbbreviation";
            this.txtAbbreviation.Size = new System.Drawing.Size(150, 20);
            this.txtAbbreviation.TabIndex = 14;
            // 
            // lblAbbreviation
            // 
            this.lblAbbreviation.AutoSize = true;
            this.lblAbbreviation.Location = new System.Drawing.Point(5, 5);
            this.lblAbbreviation.Name = "lblAbbreviation";
            this.lblAbbreviation.Size = new System.Drawing.Size(69, 13);
            this.lblAbbreviation.TabIndex = 13;
            this.lblAbbreviation.Text = "Abbreviation:";
            // 
            // UOrganizationOther
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtAbbreviation);
            this.Controls.Add(this.lblAbbreviation);
            this.Name = "UOrganizationOther";
            this.Size = new System.Drawing.Size(434, 171);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Scalable.Win.Controls.iTextBox txtAbbreviation;
        private Scalable.Win.Controls.iLabel lblAbbreviation;
    }
}
