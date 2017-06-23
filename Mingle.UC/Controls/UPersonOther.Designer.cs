namespace Mingle.UC.Controls
{
    partial class UPersonOther
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
            this.lblNickName = new Scalable.Win.Controls.iLabel();
            this.txtNickName = new Scalable.Win.Controls.iTextBox();
            this.cmbGender = new Scalable.Win.Controls.iComboBox();
            this.lblGender = new Scalable.Win.Controls.iLabel();
            this.lblBloodGroup = new Scalable.Win.Controls.iLabel();
            this.cmbBloodGroup = new Scalable.Win.Controls.iComboBox();
            this.gpbLanguages = new Scalable.Win.Controls.iGroupBox();
            this.uPartyLanguages = new Mingle.UC.Controls.UPartyLanguages();
            this.gpbRelations = new Scalable.Win.Controls.iGroupBox();
            this.uPartyRelations = new Mingle.UC.Controls.UPartyRelations();
            this.gpbLanguages.SuspendLayout();
            this.gpbRelations.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNickName
            // 
            this.lblNickName.AutoSize = true;
            this.lblNickName.Location = new System.Drawing.Point(3, 5);
            this.lblNickName.Name = "lblNickName";
            this.lblNickName.Size = new System.Drawing.Size(61, 13);
            this.lblNickName.TabIndex = 0;
            this.lblNickName.Text = "Nick name:";
            // 
            // txtNickName
            // 
            this.txtNickName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNickName.Location = new System.Drawing.Point(67, 2);
            this.txtNickName.Name = "txtNickName";
            this.txtNickName.Size = new System.Drawing.Size(84, 20);
            this.txtNickName.TabIndex = 1;
            // 
            // cmbGender
            // 
            this.cmbGender.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Location = new System.Drawing.Point(199, 2);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(86, 21);
            this.cmbGender.TabIndex = 3;
            this.cmbGender.SelectedIndexChanged += new System.EventHandler(this.cmb_SelectedIndexChanged);
            // 
            // lblGender
            // 
            this.lblGender.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(155, 5);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(45, 13);
            this.lblGender.TabIndex = 2;
            this.lblGender.Text = "Gender:";
            // 
            // lblBloodGroup
            // 
            this.lblBloodGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBloodGroup.AutoSize = true;
            this.lblBloodGroup.Location = new System.Drawing.Point(287, 5);
            this.lblBloodGroup.Name = "lblBloodGroup";
            this.lblBloodGroup.Size = new System.Drawing.Size(67, 13);
            this.lblBloodGroup.TabIndex = 4;
            this.lblBloodGroup.Text = "Blood group:";
            // 
            // cmbBloodGroup
            // 
            this.cmbBloodGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbBloodGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBloodGroup.FormattingEnabled = true;
            this.cmbBloodGroup.Location = new System.Drawing.Point(356, 2);
            this.cmbBloodGroup.Name = "cmbBloodGroup";
            this.cmbBloodGroup.Size = new System.Drawing.Size(73, 21);
            this.cmbBloodGroup.TabIndex = 5;
            this.cmbBloodGroup.SelectedIndexChanged += new System.EventHandler(this.cmb_SelectedIndexChanged);
            // 
            // gpbLanguages
            // 
            this.gpbLanguages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbLanguages.Controls.Add(this.uPartyLanguages);
            this.gpbLanguages.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbLanguages.Location = new System.Drawing.Point(3, 23);
            this.gpbLanguages.Name = "gpbLanguages";
            this.gpbLanguages.Size = new System.Drawing.Size(427, 142);
            this.gpbLanguages.TabIndex = 6;
            this.gpbLanguages.TabStop = false;
            this.gpbLanguages.Text = "Languages";
            // 
            // uPartyLanguages
            // 
            this.uPartyLanguages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uPartyLanguages.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uPartyLanguages.Location = new System.Drawing.Point(3, 16);
            this.uPartyLanguages.Name = "uPartyLanguages";
            this.uPartyLanguages.Size = new System.Drawing.Size(421, 123);
            this.uPartyLanguages.TabIndex = 0;
            // 
            // gpbRelations
            // 
            this.gpbRelations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbRelations.Controls.Add(this.uPartyRelations);
            this.gpbRelations.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbRelations.Location = new System.Drawing.Point(3, 167);
            this.gpbRelations.Name = "gpbRelations";
            this.gpbRelations.Size = new System.Drawing.Size(427, 143);
            this.gpbRelations.TabIndex = 7;
            this.gpbRelations.TabStop = false;
            this.gpbRelations.Text = "Relations";
            // 
            // uPartyRelations
            // 
            this.uPartyRelations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uPartyRelations.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uPartyRelations.Location = new System.Drawing.Point(3, 16);
            this.uPartyRelations.MinimumSize = new System.Drawing.Size(266, 128);
            this.uPartyRelations.Name = "uPartyRelations";
            this.uPartyRelations.Size = new System.Drawing.Size(421, 128);
            this.uPartyRelations.TabIndex = 0;
            // 
            // UPersonOther
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gpbRelations);
            this.Controls.Add(this.gpbLanguages);
            this.Controls.Add(this.cmbBloodGroup);
            this.Controls.Add(this.cmbGender);
            this.Controls.Add(this.lblBloodGroup);
            this.Controls.Add(this.txtNickName);
            this.Controls.Add(this.lblGender);
            this.Controls.Add(this.lblNickName);
            this.MinimumSize = new System.Drawing.Size(432, 312);
            this.Name = "UPersonOther";
            this.Size = new System.Drawing.Size(432, 312);
            this.gpbLanguages.ResumeLayout(false);
            this.gpbRelations.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Scalable.Win.Controls.iLabel lblNickName;
        private Scalable.Win.Controls.iTextBox txtNickName;
        private Scalable.Win.Controls.iComboBox cmbGender;
        private Scalable.Win.Controls.iLabel lblGender;
        private Scalable.Win.Controls.iLabel lblBloodGroup;
        private Scalable.Win.Controls.iComboBox cmbBloodGroup;
        private UPartyLanguages uPartyLanguages;
        private UPartyRelations uPartyRelations;
        private Scalable.Win.Controls.iGroupBox gpbLanguages;
        private Scalable.Win.Controls.iGroupBox gpbRelations;
    }
}
