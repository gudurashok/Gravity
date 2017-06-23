namespace Mingle.UC.Controls
{
    partial class UPartyContactsAndProfessions
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
            this.gpbContacts = new Scalable.Win.Controls.iGroupBox();
            this.gpbProfessions = new Scalable.Win.Controls.iGroupBox();
            this.uPartyProfessions = new Mingle.UC.Controls.UPartyProfessions();
            this.uPartyContacts = new Mingle.UC.Controls.UPartyContacts();
            this.gpbContacts.SuspendLayout();
            this.gpbProfessions.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbContacts
            // 
            this.gpbContacts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbContacts.Controls.Add(this.uPartyContacts);
            this.gpbContacts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbContacts.Location = new System.Drawing.Point(3, 2);
            this.gpbContacts.Name = "gpbContacts";
            this.gpbContacts.Size = new System.Drawing.Size(409, 173);
            this.gpbContacts.TabIndex = 6;
            this.gpbContacts.TabStop = false;
            this.gpbContacts.Text = "Contacts";
            // 
            // gpbProfessions
            // 
            this.gpbProfessions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbProfessions.Controls.Add(this.uPartyProfessions);
            this.gpbProfessions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbProfessions.Location = new System.Drawing.Point(3, 178);
            this.gpbProfessions.Name = "gpbProfessions";
            this.gpbProfessions.Size = new System.Drawing.Size(409, 145);
            this.gpbProfessions.TabIndex = 7;
            this.gpbProfessions.TabStop = false;
            this.gpbProfessions.Text = "Professions";
            // 
            // uPartyProfessions
            // 
            this.uPartyProfessions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uPartyProfessions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uPartyProfessions.Location = new System.Drawing.Point(3, 16);
            this.uPartyProfessions.MinimumSize = new System.Drawing.Size(301, 106);
            this.uPartyProfessions.Name = "uPartyProfessions";
            this.uPartyProfessions.Size = new System.Drawing.Size(403, 126);
            this.uPartyProfessions.TabIndex = 5;
            // 
            // uPartyContacts
            // 
            this.uPartyContacts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uPartyContacts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uPartyContacts.Location = new System.Drawing.Point(3, 16);
            this.uPartyContacts.MinimumSize = new System.Drawing.Size(392, 154);
            this.uPartyContacts.Name = "uPartyContacts";
            this.uPartyContacts.Size = new System.Drawing.Size(403, 154);
            this.uPartyContacts.TabIndex = 0;
            // 
            // UPartyContactsAndProfessions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gpbProfessions);
            this.Controls.Add(this.gpbContacts);
            this.MinimumSize = new System.Drawing.Size(415, 325);
            this.Name = "UPartyContactsAndProfessions";
            this.Size = new System.Drawing.Size(415, 325);
            this.gpbContacts.ResumeLayout(false);
            this.gpbProfessions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Scalable.Win.Controls.iGroupBox gpbContacts;
        private UPartyContacts uPartyContacts;
        private Scalable.Win.Controls.iGroupBox gpbProfessions;
        private UPartyProfessions uPartyProfessions;
    }
}
