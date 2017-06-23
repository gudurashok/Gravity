namespace Insight.UC.Controls
{
    partial class UFiscalDatePeriod
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
            this.dtpFinancialFrom = new Scalable.Win.Controls.iDateTimePicker();
            this.lblFinancialFrom = new Scalable.Win.Controls.iLabel();
            this.lblFinancialTo = new Scalable.Win.Controls.iLabel();
            this.dtpFinancialTo = new Scalable.Win.Controls.iDateTimePicker();
            this.dtpAssessmentTo = new Scalable.Win.Controls.iDateTimePicker();
            this.lblAssessment = new Scalable.Win.Controls.iLabel();
            this.dtpAssessmentFrom = new Scalable.Win.Controls.iDateTimePicker();
            this.lblAssessmentFrom = new Scalable.Win.Controls.iLabel();
            this.lblName = new Scalable.Win.Controls.iLabel();
            this.txtName = new Scalable.Win.Controls.iTextBox();
            this.CommandBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // CommandBar
            // 
            this.CommandBar.Controls.Add(this.btnSave);
            this.CommandBar.Location = new System.Drawing.Point(-1, 70);
            this.CommandBar.Size = new System.Drawing.Size(384, 36);
            this.CommandBar.TabIndex = 10;
            // 
            // btnSave
            // 
            this.btnSave.Action = Scalable.Win.Enums.CommandBarAction.Save;
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSave.Location = new System.Drawing.Point(154, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dtpFinancialFrom
            // 
            this.dtpFinancialFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFinancialFrom.Location = new System.Drawing.Point(94, 24);
            this.dtpFinancialFrom.Name = "dtpFinancialFrom";
            this.dtpFinancialFrom.Size = new System.Drawing.Size(96, 20);
            this.dtpFinancialFrom.TabIndex = 1;
            this.dtpFinancialFrom.Leave += new System.EventHandler(this.dtpFinancialFrom_Leave);
            // 
            // lblFinancialFrom
            // 
            this.lblFinancialFrom.AutoSize = true;
            this.lblFinancialFrom.Location = new System.Drawing.Point(3, 27);
            this.lblFinancialFrom.Name = "lblFinancialFrom";
            this.lblFinancialFrom.Size = new System.Drawing.Size(75, 13);
            this.lblFinancialFrom.TabIndex = 0;
            this.lblFinancialFrom.Text = "Financial from:";
            // 
            // lblFinancialTo
            // 
            this.lblFinancialTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFinancialTo.AutoSize = true;
            this.lblFinancialTo.Location = new System.Drawing.Point(204, 27);
            this.lblFinancialTo.Name = "lblFinancialTo";
            this.lblFinancialTo.Size = new System.Drawing.Size(64, 13);
            this.lblFinancialTo.TabIndex = 2;
            this.lblFinancialTo.Text = "Financial to:";
            // 
            // dtpFinancialTo
            // 
            this.dtpFinancialTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFinancialTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFinancialTo.Location = new System.Drawing.Point(283, 24);
            this.dtpFinancialTo.Name = "dtpFinancialTo";
            this.dtpFinancialTo.Size = new System.Drawing.Size(96, 20);
            this.dtpFinancialTo.TabIndex = 3;
            this.dtpFinancialTo.Leave += new System.EventHandler(this.dtpFinancialTo_Leave);
            // 
            // dtpAssessmentTo
            // 
            this.dtpAssessmentTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpAssessmentTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAssessmentTo.Location = new System.Drawing.Point(283, 46);
            this.dtpAssessmentTo.Name = "dtpAssessmentTo";
            this.dtpAssessmentTo.Size = new System.Drawing.Size(96, 20);
            this.dtpAssessmentTo.TabIndex = 7;
            // 
            // lblAssessment
            // 
            this.lblAssessment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAssessment.AutoSize = true;
            this.lblAssessment.Location = new System.Drawing.Point(204, 49);
            this.lblAssessment.Name = "lblAssessment";
            this.lblAssessment.Size = new System.Drawing.Size(78, 13);
            this.lblAssessment.TabIndex = 6;
            this.lblAssessment.Text = "Assessment to:";
            // 
            // dtpAssessmentFrom
            // 
            this.dtpAssessmentFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAssessmentFrom.Location = new System.Drawing.Point(94, 46);
            this.dtpAssessmentFrom.Name = "dtpAssessmentFrom";
            this.dtpAssessmentFrom.Size = new System.Drawing.Size(96, 20);
            this.dtpAssessmentFrom.TabIndex = 5;
            // 
            // lblAssessmentFrom
            // 
            this.lblAssessmentFrom.AutoSize = true;
            this.lblAssessmentFrom.Location = new System.Drawing.Point(3, 49);
            this.lblAssessmentFrom.Name = "lblAssessmentFrom";
            this.lblAssessmentFrom.Size = new System.Drawing.Size(89, 13);
            this.lblAssessmentFrom.TabIndex = 4;
            this.lblAssessmentFrom.Text = "Assessment from:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(3, 6);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 8;
            this.lblName.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.BackColor = System.Drawing.Color.White;
            this.txtName.Location = new System.Drawing.Point(94, 2);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(285, 20);
            this.txtName.TabIndex = 9;
            // 
            // UFiscalDatePeriod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblFinancialFrom);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.dtpAssessmentTo);
            this.Controls.Add(this.lblAssessmentFrom);
            this.Controls.Add(this.dtpFinancialFrom);
            this.Controls.Add(this.dtpAssessmentFrom);
            this.Controls.Add(this.lblFinancialTo);
            this.Controls.Add(this.lblAssessment);
            this.Controls.Add(this.dtpFinancialTo);
            this.MaximumSize = new System.Drawing.Size(640, 104);
            this.MinimumSize = new System.Drawing.Size(369, 102);
            this.Name = "UFiscalDatePeriod";
            this.Size = new System.Drawing.Size(382, 104);
            this.Controls.SetChildIndex(this.dtpFinancialTo, 0);
            this.Controls.SetChildIndex(this.lblAssessment, 0);
            this.Controls.SetChildIndex(this.lblFinancialTo, 0);
            this.Controls.SetChildIndex(this.dtpAssessmentFrom, 0);
            this.Controls.SetChildIndex(this.dtpFinancialFrom, 0);
            this.Controls.SetChildIndex(this.lblAssessmentFrom, 0);
            this.Controls.SetChildIndex(this.dtpAssessmentTo, 0);
            this.Controls.SetChildIndex(this.lblName, 0);
            this.Controls.SetChildIndex(this.txtName, 0);
            this.Controls.SetChildIndex(this.lblFinancialFrom, 0);
            this.Controls.SetChildIndex(this.CommandBar, 0);
            this.CommandBar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Scalable.Win.Controls.iCommandButton btnSave;
        private Scalable.Win.Controls.iDateTimePicker dtpFinancialFrom;
        private Scalable.Win.Controls.iLabel lblFinancialFrom;
        private Scalable.Win.Controls.iLabel lblFinancialTo;
        private Scalable.Win.Controls.iDateTimePicker dtpFinancialTo;
        private Scalable.Win.Controls.iDateTimePicker dtpAssessmentTo;
        private Scalable.Win.Controls.iLabel lblAssessment;
        private Scalable.Win.Controls.iDateTimePicker dtpAssessmentFrom;
        private Scalable.Win.Controls.iLabel lblAssessmentFrom;
        private Scalable.Win.Controls.iLabel lblName;
        private Scalable.Win.Controls.iTextBox txtName;
    }
}
