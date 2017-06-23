namespace Mingle.UC.Controls
{
    partial class UAddress
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
            this.txtStreet = new Scalable.Win.Controls.iTextBox();
            this.lblLandmark = new Scalable.Win.Controls.iLabel();
            this.lblStreet = new Scalable.Win.Controls.iLabel();
            this.lblCountry = new Scalable.Win.Controls.iLabel();
            this.lblPinCode = new Scalable.Win.Controls.iLabel();
            this.lblArea = new Scalable.Win.Controls.iLabel();
            this.lblCity = new Scalable.Win.Controls.iLabel();
            this.txtCity = new Scalable.Win.Controls.iTextBox();
            this.txtArea = new Scalable.Win.Controls.iTextBox();
            this.txtLandmark = new Scalable.Win.Controls.iTextBox();
            this.txtPinCode = new Scalable.Win.Controls.iTextBox();
            this.cmbCountry = new Scalable.Win.Controls.iComboBox();
            this.cmbState = new Scalable.Win.Controls.iComboBox();
            this.lblState = new Scalable.Win.Controls.iLabel();
            this.SuspendLayout();
            // 
            // txtStreet
            // 
            this.txtStreet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStreet.Location = new System.Drawing.Point(55, 3);
            this.txtStreet.Multiline = true;
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtStreet.Size = new System.Drawing.Size(358, 71);
            this.txtStreet.TabIndex = 1;
            this.txtStreet.Tag = "Street";
            // 
            // lblLandmark
            // 
            this.lblLandmark.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLandmark.AutoSize = true;
            this.lblLandmark.Location = new System.Drawing.Point(183, 79);
            this.lblLandmark.Name = "lblLandmark";
            this.lblLandmark.Size = new System.Drawing.Size(57, 13);
            this.lblLandmark.TabIndex = 4;
            this.lblLandmark.Text = "Landmar&k:";
            this.lblLandmark.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStreet
            // 
            this.lblStreet.AutoSize = true;
            this.lblStreet.Location = new System.Drawing.Point(3, 3);
            this.lblStreet.Name = "lblStreet";
            this.lblStreet.Size = new System.Drawing.Size(38, 13);
            this.lblStreet.TabIndex = 0;
            this.lblStreet.Text = "Street:";
            // 
            // lblCountry
            // 
            this.lblCountry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCountry.AutoSize = true;
            this.lblCountry.Location = new System.Drawing.Point(3, 123);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(46, 13);
            this.lblCountry.TabIndex = 10;
            this.lblCountry.Text = "Country:";
            this.lblCountry.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPinCode
            // 
            this.lblPinCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPinCode.AutoSize = true;
            this.lblPinCode.Location = new System.Drawing.Point(183, 123);
            this.lblPinCode.Name = "lblPinCode";
            this.lblPinCode.Size = new System.Drawing.Size(28, 13);
            this.lblPinCode.TabIndex = 12;
            this.lblPinCode.Text = "P&IN:";
            this.lblPinCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblArea
            // 
            this.lblArea.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblArea.AutoSize = true;
            this.lblArea.Location = new System.Drawing.Point(3, 79);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(32, 13);
            this.lblArea.TabIndex = 2;
            this.lblArea.Text = "A&rea:";
            this.lblArea.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCity
            // 
            this.lblCity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(3, 101);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(27, 13);
            this.lblCity.TabIndex = 6;
            this.lblCity.Text = "Cit&y:";
            this.lblCity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCity
            // 
            this.txtCity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCity.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtCity.Location = new System.Drawing.Point(55, 98);
            this.txtCity.MaxLength = 10;
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(122, 20);
            this.txtCity.TabIndex = 7;
            this.txtCity.Tag = "City";
            // 
            // txtArea
            // 
            this.txtArea.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtArea.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtArea.Location = new System.Drawing.Point(55, 76);
            this.txtArea.MaxLength = 10;
            this.txtArea.Name = "txtArea";
            this.txtArea.Size = new System.Drawing.Size(122, 20);
            this.txtArea.TabIndex = 3;
            this.txtArea.Tag = "Area";
            // 
            // txtLandmark
            // 
            this.txtLandmark.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLandmark.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtLandmark.Location = new System.Drawing.Point(248, 76);
            this.txtLandmark.MaxLength = 10;
            this.txtLandmark.Name = "txtLandmark";
            this.txtLandmark.Size = new System.Drawing.Size(166, 20);
            this.txtLandmark.TabIndex = 5;
            this.txtLandmark.Tag = "Landmark";
            // 
            // txtPinCode
            // 
            this.txtPinCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPinCode.InputFilterExpr = "[0-9]";
            this.txtPinCode.Location = new System.Drawing.Point(248, 121);
            this.txtPinCode.MaxLength = 10;
            this.txtPinCode.Name = "txtPinCode";
            this.txtPinCode.Size = new System.Drawing.Size(166, 20);
            this.txtPinCode.TabIndex = 13;
            this.txtPinCode.Tag = "PinCode";
            // 
            // cmbCountry
            // 
            this.cmbCountry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCountry.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCountry.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCountry.FormattingEnabled = true;
            this.cmbCountry.Location = new System.Drawing.Point(55, 120);
            this.cmbCountry.Name = "cmbCountry";
            this.cmbCountry.Size = new System.Drawing.Size(122, 21);
            this.cmbCountry.TabIndex = 11;
            // 
            // cmbState
            // 
            this.cmbState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbState.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbState.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbState.FormattingEnabled = true;
            this.cmbState.Location = new System.Drawing.Point(248, 98);
            this.cmbState.Name = "cmbState";
            this.cmbState.Size = new System.Drawing.Size(166, 21);
            this.cmbState.TabIndex = 9;
            // 
            // lblState
            // 
            this.lblState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(183, 101);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(35, 13);
            this.lblState.TabIndex = 8;
            this.lblState.Text = "State:";
            this.lblState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UAddress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbCountry);
            this.Controls.Add(this.lblCountry);
            this.Controls.Add(this.lblStreet);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.txtPinCode);
            this.Controls.Add(this.lblPinCode);
            this.Controls.Add(this.txtStreet);
            this.Controls.Add(this.cmbState);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.lblArea);
            this.Controls.Add(this.txtArea);
            this.Controls.Add(this.lblLandmark);
            this.Controls.Add(this.lblCity);
            this.Controls.Add(this.txtLandmark);
            this.Name = "UAddress";
            this.Size = new System.Drawing.Size(416, 145);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Scalable.Win.Controls.iTextBox txtStreet;
        private Scalable.Win.Controls.iLabel lblLandmark;
        private Scalable.Win.Controls.iLabel lblStreet;
        private Scalable.Win.Controls.iLabel lblCountry;
        private Scalable.Win.Controls.iLabel lblPinCode;
        private Scalable.Win.Controls.iLabel lblArea;
        private Scalable.Win.Controls.iLabel lblCity;
        private Scalable.Win.Controls.iLabel lblState;
        private Scalable.Win.Controls.iComboBox cmbState;
        private Scalable.Win.Controls.iTextBox txtPinCode;
        private Scalable.Win.Controls.iTextBox txtCity;
        private Scalable.Win.Controls.iTextBox txtArea;
        private Scalable.Win.Controls.iTextBox txtLandmark;
        private Scalable.Win.Controls.iComboBox cmbCountry;
    }
}
