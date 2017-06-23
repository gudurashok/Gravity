namespace Insight.UC.Controls
{
    partial class UBillTerm
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
            this.btnSave = new Scalable.Win.Controls.iCommandButton();
            this.txtCode = new Scalable.Win.Controls.iTextBox();
            this.lblCode = new Scalable.Win.Controls.iLabel();
            this.ntbType = new Scalable.Win.Controls.iNumberTextBox();
            this.lblType = new Scalable.Win.Controls.iLabel();
            this.txtDescription = new Scalable.Win.Controls.iTextBox();
            this.lblDescription = new Scalable.Win.Controls.iLabel();
            this.txbDaybook = new Scalable.Win.Controls.iTextBoxButton();
            this.txtFormula = new Scalable.Win.Controls.iTextBox();
            this.ntbPercentage = new Scalable.Win.Controls.iNumberTextBox();
            this.lblPercentage = new Scalable.Win.Controls.iLabel();
            this.lblFormula = new Scalable.Win.Controls.iLabel();
            this.lblSign = new Scalable.Win.Controls.iLabel();
            this.lblDaybook = new Scalable.Win.Controls.iLabel();
            this.txtSign = new Scalable.Win.Controls.iTextBox();
            this.CommandBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // CommandBar
            // 
            this.CommandBar.Controls.Add(this.btnSave);
            this.CommandBar.Location = new System.Drawing.Point(-2, 92);
            this.CommandBar.Size = new System.Drawing.Size(349, 35);
            this.CommandBar.TabIndex = 14;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSave.Location = new System.Drawing.Point(136, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtCode
            // 
            this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCode.Location = new System.Drawing.Point(269, 2);
            this.txtCode.MaxLength = 1;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(74, 20);
            this.txtCode.TabIndex = 3;
            // 
            // lblCode
            // 
            this.lblCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(203, 6);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(38, 13);
            this.lblCode.TabIndex = 2;
            this.lblCode.Text = "&Code: ";
            // 
            // ntbType
            // 
            this.ntbType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ntbType.DisplayFormat = null;
            this.ntbType.Location = new System.Drawing.Point(63, 2);
            this.ntbType.Name = "ntbType";
            this.ntbType.Size = new System.Drawing.Size(133, 20);
            this.ntbType.TabIndex = 1;
            this.ntbType.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntbType.Value = 0D;
            this.ntbType.ValueFormat = null;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(1, 6);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(37, 13);
            this.lblType.TabIndex = 0;
            this.lblType.Text = "&Type: ";
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(63, 68);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(209, 20);
            this.txtDescription.TabIndex = 11;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(0, 72);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(66, 13);
            this.lblDescription.TabIndex = 10;
            this.lblDescription.Text = "&Description: ";
            // 
            // txbDaybook
            // 
            this.txbDaybook.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbDaybook.Location = new System.Drawing.Point(63, 46);
            this.txbDaybook.Name = "txbDaybook";
            this.txbDaybook.SearchProperty = "Name";
            this.txbDaybook.Size = new System.Drawing.Size(280, 20);
            this.txbDaybook.TabIndex = 9;
            // 
            // txtFormula
            // 
            this.txtFormula.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFormula.Location = new System.Drawing.Point(63, 24);
            this.txtFormula.Name = "txtFormula";
            this.txtFormula.Size = new System.Drawing.Size(133, 20);
            this.txtFormula.TabIndex = 5;
            // 
            // ntbPercentage
            // 
            this.ntbPercentage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ntbPercentage.DisplayFormat = null;
            this.ntbPercentage.Location = new System.Drawing.Point(269, 24);
            this.ntbPercentage.Name = "ntbPercentage";
            this.ntbPercentage.Size = new System.Drawing.Size(74, 20);
            this.ntbPercentage.TabIndex = 7;
            this.ntbPercentage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntbPercentage.Value = 0D;
            this.ntbPercentage.ValueFormat = "2.2";
            // 
            // lblPercentage
            // 
            this.lblPercentage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPercentage.AutoSize = true;
            this.lblPercentage.Location = new System.Drawing.Point(201, 28);
            this.lblPercentage.Name = "lblPercentage";
            this.lblPercentage.Size = new System.Drawing.Size(68, 13);
            this.lblPercentage.TabIndex = 6;
            this.lblPercentage.Text = "&Percentage: ";
            // 
            // lblFormula
            // 
            this.lblFormula.AutoSize = true;
            this.lblFormula.Location = new System.Drawing.Point(0, 28);
            this.lblFormula.Name = "lblFormula";
            this.lblFormula.Size = new System.Drawing.Size(50, 13);
            this.lblFormula.TabIndex = 4;
            this.lblFormula.Text = "&Formula: ";
            // 
            // lblSign
            // 
            this.lblSign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSign.AutoSize = true;
            this.lblSign.Location = new System.Drawing.Point(271, 70);
            this.lblSign.Name = "lblSign";
            this.lblSign.Size = new System.Drawing.Size(34, 13);
            this.lblSign.TabIndex = 12;
            this.lblSign.Text = "Si&gn: ";
            // 
            // lblDaybook
            // 
            this.lblDaybook.AutoSize = true;
            this.lblDaybook.Location = new System.Drawing.Point(0, 50);
            this.lblDaybook.Name = "lblDaybook";
            this.lblDaybook.Size = new System.Drawing.Size(56, 13);
            this.lblDaybook.TabIndex = 8;
            this.lblDaybook.Text = "&Daybook: ";
            // 
            // txtSign
            // 
            this.txtSign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSign.InputFilterExpr = "[+|\\-|*]";
            this.txtSign.Location = new System.Drawing.Point(301, 68);
            this.txtSign.MaxLength = 1;
            this.txtSign.Name = "txtSign";
            this.txtSign.Size = new System.Drawing.Size(42, 20);
            this.txtSign.TabIndex = 13;
            // 
            // UBillTerm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtSign);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.ntbType);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txbDaybook);
            this.Controls.Add(this.txtFormula);
            this.Controls.Add(this.ntbPercentage);
            this.Controls.Add(this.lblPercentage);
            this.Controls.Add(this.lblFormula);
            this.Controls.Add(this.lblSign);
            this.Controls.Add(this.lblDaybook);
            this.MaximumSize = new System.Drawing.Size(640, 126);
            this.MinimumSize = new System.Drawing.Size(346, 126);
            this.Name = "UBillTerm";
            this.Size = new System.Drawing.Size(346, 126);
            this.Controls.SetChildIndex(this.CommandBar, 0);
            this.Controls.SetChildIndex(this.lblDaybook, 0);
            this.Controls.SetChildIndex(this.lblSign, 0);
            this.Controls.SetChildIndex(this.lblFormula, 0);
            this.Controls.SetChildIndex(this.lblPercentage, 0);
            this.Controls.SetChildIndex(this.ntbPercentage, 0);
            this.Controls.SetChildIndex(this.txtFormula, 0);
            this.Controls.SetChildIndex(this.txbDaybook, 0);
            this.Controls.SetChildIndex(this.lblDescription, 0);
            this.Controls.SetChildIndex(this.txtDescription, 0);
            this.Controls.SetChildIndex(this.lblType, 0);
            this.Controls.SetChildIndex(this.ntbType, 0);
            this.Controls.SetChildIndex(this.lblCode, 0);
            this.Controls.SetChildIndex(this.txtCode, 0);
            this.Controls.SetChildIndex(this.txtSign, 0);
            this.CommandBar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Scalable.Win.Controls.iCommandButton btnSave;
        private Scalable.Win.Controls.iTextBox txtCode;
        private Scalable.Win.Controls.iLabel lblCode;
        private Scalable.Win.Controls.iNumberTextBox ntbType;
        private Scalable.Win.Controls.iLabel lblType;
        private Scalable.Win.Controls.iTextBox txtDescription;
        private Scalable.Win.Controls.iLabel lblDescription;
        private Scalable.Win.Controls.iTextBoxButton txbDaybook;
        private Scalable.Win.Controls.iTextBox txtFormula;
        private Scalable.Win.Controls.iNumberTextBox ntbPercentage;
        private Scalable.Win.Controls.iLabel lblPercentage;
        private Scalable.Win.Controls.iLabel lblFormula;
        private Scalable.Win.Controls.iLabel lblSign;
        private Scalable.Win.Controls.iLabel lblDaybook;
        private Scalable.Win.Controls.iTextBox txtSign;

    }
}
