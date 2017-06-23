namespace Mingle.UC.Controls
{
    partial class UEmailsAndIMs
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
            this.Splitter = new Scalable.Win.Controls.iSplitContainer();
            this.gpbEmails = new Scalable.Win.Controls.iGroupBox();
            this.uPartyEmails = new Mingle.UC.Controls.UPartyEmails();
            this.gpbIMs = new Scalable.Win.Controls.iGroupBox();
            this.uPartyIMs = new Mingle.UC.Controls.UPartyIMs();
            ((System.ComponentModel.ISupportInitialize)(this.Splitter)).BeginInit();
            this.Splitter.Panel1.SuspendLayout();
            this.Splitter.Panel2.SuspendLayout();
            this.Splitter.SuspendLayout();
            this.gpbEmails.SuspendLayout();
            this.gpbIMs.SuspendLayout();
            this.SuspendLayout();
            // 
            // Splitter
            // 
            this.Splitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Splitter.Location = new System.Drawing.Point(0, 0);
            this.Splitter.Name = "Splitter";
            this.Splitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // Splitter.Panel1
            // 
            this.Splitter.Panel1.Controls.Add(this.gpbEmails);
            // 
            // Splitter.Panel2
            // 
            this.Splitter.Panel2.Controls.Add(this.gpbIMs);
            this.Splitter.Size = new System.Drawing.Size(434, 324);
            this.Splitter.SplitterDistance = 162;
            this.Splitter.SplitterWidth = 1;
            this.Splitter.TabIndex = 0;
            // 
            // gpbEmails
            // 
            this.gpbEmails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbEmails.Controls.Add(this.uPartyEmails);
            this.gpbEmails.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbEmails.Location = new System.Drawing.Point(3, 2);
            this.gpbEmails.Name = "gpbEmails";
            this.gpbEmails.Size = new System.Drawing.Size(428, 158);
            this.gpbEmails.TabIndex = 0;
            this.gpbEmails.TabStop = false;
            this.gpbEmails.Text = "Emails";
            // 
            // uPartyEmails
            // 
            this.uPartyEmails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uPartyEmails.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uPartyEmails.Location = new System.Drawing.Point(3, 16);
            this.uPartyEmails.Name = "uPartyEmails";
            this.uPartyEmails.Size = new System.Drawing.Size(422, 139);
            this.uPartyEmails.TabIndex = 0;
            // 
            // gpbIMs
            // 
            this.gpbIMs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbIMs.Controls.Add(this.uPartyIMs);
            this.gpbIMs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbIMs.Location = new System.Drawing.Point(3, 0);
            this.gpbIMs.Name = "gpbIMs";
            this.gpbIMs.Size = new System.Drawing.Size(428, 157);
            this.gpbIMs.TabIndex = 0;
            this.gpbIMs.TabStop = false;
            this.gpbIMs.Text = "Instant messengers";
            // 
            // uPartyIMs
            // 
            this.uPartyIMs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uPartyIMs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uPartyIMs.Location = new System.Drawing.Point(3, 16);
            this.uPartyIMs.MinimumSize = new System.Drawing.Size(378, 122);
            this.uPartyIMs.Name = "uPartyIMs";
            this.uPartyIMs.Size = new System.Drawing.Size(422, 138);
            this.uPartyIMs.TabIndex = 0;
            // 
            // UEmailsAndIMs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Splitter);
            this.MinimumSize = new System.Drawing.Size(358, 324);
            this.Name = "UEmailsAndIMs";
            this.Size = new System.Drawing.Size(434, 324);
            this.Splitter.Panel1.ResumeLayout(false);
            this.Splitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Splitter)).EndInit();
            this.Splitter.ResumeLayout(false);
            this.gpbEmails.ResumeLayout(false);
            this.gpbIMs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Scalable.Win.Controls.iSplitContainer Splitter;
        private UPartyEmails uPartyEmails;
        private UPartyIMs uPartyIMs;
        private Scalable.Win.Controls.iGroupBox gpbEmails;
        private Scalable.Win.Controls.iGroupBox gpbIMs;
    }
}
