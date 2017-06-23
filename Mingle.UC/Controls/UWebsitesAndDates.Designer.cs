using System.Windows.Forms;

namespace Mingle.UC.Controls
{
    partial class UWebsitesAndDates
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
            this.gpbWebsites = new Scalable.Win.Controls.iGroupBox();
            this.gpbDates = new Scalable.Win.Controls.iGroupBox();
            this.uPartyDates = new Mingle.UC.Controls.UPartyDates();
            this.uPartyWebsites = new Mingle.UC.Controls.UPartyWebsites();
            this.gpbWebsites.SuspendLayout();
            this.gpbDates.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbWebsites
            // 
            this.gpbWebsites.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbWebsites.Controls.Add(this.uPartyWebsites);
            this.gpbWebsites.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbWebsites.Location = new System.Drawing.Point(3, 2);
            this.gpbWebsites.Name = "gpbWebsites";
            this.gpbWebsites.Size = new System.Drawing.Size(362, 157);
            this.gpbWebsites.TabIndex = 0;
            this.gpbWebsites.TabStop = false;
            this.gpbWebsites.Text = "Websites";
            // 
            // gpbDates
            // 
            this.gpbDates.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbDates.Controls.Add(this.uPartyDates);
            this.gpbDates.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbDates.Location = new System.Drawing.Point(3, 160);
            this.gpbDates.Name = "gpbDates";
            this.gpbDates.Size = new System.Drawing.Size(362, 110);
            this.gpbDates.TabIndex = 1;
            this.gpbDates.TabStop = false;
            this.gpbDates.Text = "Dates";
            // 
            // uPartyDates
            // 
            this.uPartyDates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uPartyDates.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uPartyDates.Location = new System.Drawing.Point(3, 16);
            this.uPartyDates.MinimumSize = new System.Drawing.Size(355, 92);
            this.uPartyDates.Name = "uPartyDates";
            this.uPartyDates.Size = new System.Drawing.Size(356, 92);
            this.uPartyDates.TabIndex = 0;
            // 
            // uPartyWebsites
            // 
            this.uPartyWebsites.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uPartyWebsites.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uPartyWebsites.Location = new System.Drawing.Point(3, 16);
            this.uPartyWebsites.MinimumSize = new System.Drawing.Size(355, 92);
            this.uPartyWebsites.Name = "uPartyWebsites";
            this.uPartyWebsites.Size = new System.Drawing.Size(356, 138);
            this.uPartyWebsites.TabIndex = 0;
            // 
            // UWebsitesAndDates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gpbDates);
            this.Controls.Add(this.gpbWebsites);
            this.Name = "UWebsitesAndDates";
            this.Size = new System.Drawing.Size(368, 271);
            this.gpbWebsites.ResumeLayout(false);
            this.gpbDates.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UPartyWebsites uPartyWebsites;
        private UPartyDates uPartyDates;
        private Scalable.Win.Controls.iGroupBox gpbWebsites;
        private Scalable.Win.Controls.iGroupBox gpbDates;

    }
}
