namespace Scalable.SpellChecker.Forms
{
    partial class FOptions
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
            this.CancelBtn = new System.Windows.Forms.Button();
            this.OkButton = new System.Windows.Forms.Button();
            this.optionsTabControl = new System.Windows.Forms.TabControl();
            this.generalTab = new System.Windows.Forms.TabPage();
            this.IgnoreHtmlCheck = new System.Windows.Forms.CheckBox();
            this.lbllabel1 = new System.Windows.Forms.Label();
            this.MaxSuggestions = new System.Windows.Forms.TextBox();
            this.IgnoreUpperCheck = new System.Windows.Forms.CheckBox();
            this.IgnoreDigitsCheck = new System.Windows.Forms.CheckBox();
            this.dictionaryTab = new System.Windows.Forms.TabPage();
            this.txtCopyright = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.versionsTab = new System.Windows.Forms.TabPage();
            this.assembliesListView = new System.Windows.Forms.ListView();
            this.assemblyColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.versionColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dateColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.optionsTabControl.SuspendLayout();
            this.generalTab.SuspendLayout();
            this.dictionaryTab.SuspendLayout();
            this.versionsTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Size = new System.Drawing.Size(367, 43);
            // 
            // picLogo
            // 
            this.picLogo.Location = new System.Drawing.Point(324, 2);
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(315, 39);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(287, 223);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 15;
            this.CancelBtn.Text = "&Cancel";
            // 
            // OkButton
            // 
            this.OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.Location = new System.Drawing.Point(199, 223);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 14;
            this.OkButton.Text = "&OK";
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // optionsTabControl
            // 
            this.optionsTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.optionsTabControl.Controls.Add(this.generalTab);
            this.optionsTabControl.Controls.Add(this.dictionaryTab);
            this.optionsTabControl.Controls.Add(this.versionsTab);
            this.optionsTabControl.Location = new System.Drawing.Point(4, 47);
            this.optionsTabControl.Name = "optionsTabControl";
            this.optionsTabControl.SelectedIndex = 0;
            this.optionsTabControl.Size = new System.Drawing.Size(362, 172);
            this.optionsTabControl.TabIndex = 13;
            // 
            // generalTab
            // 
            this.generalTab.Controls.Add(this.IgnoreHtmlCheck);
            this.generalTab.Controls.Add(this.lbllabel1);
            this.generalTab.Controls.Add(this.MaxSuggestions);
            this.generalTab.Controls.Add(this.IgnoreUpperCheck);
            this.generalTab.Controls.Add(this.IgnoreDigitsCheck);
            this.generalTab.Location = new System.Drawing.Point(4, 22);
            this.generalTab.Name = "generalTab";
            this.generalTab.Size = new System.Drawing.Size(354, 146);
            this.generalTab.TabIndex = 0;
            this.generalTab.Text = "General";
            // 
            // IgnoreHtmlCheck
            // 
            this.IgnoreHtmlCheck.Checked = true;
            this.IgnoreHtmlCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IgnoreHtmlCheck.Location = new System.Drawing.Point(32, 72);
            this.IgnoreHtmlCheck.Name = "IgnoreHtmlCheck";
            this.IgnoreHtmlCheck.Size = new System.Drawing.Size(296, 24);
            this.IgnoreHtmlCheck.TabIndex = 9;
            this.IgnoreHtmlCheck.Text = "Ignore HTML Tags";
            // 
            // lbllabel1
            // 
            this.lbllabel1.Location = new System.Drawing.Point(48, 112);
            this.lbllabel1.Name = "lbllabel1";
            this.lbllabel1.Size = new System.Drawing.Size(264, 16);
            this.lbllabel1.TabIndex = 8;
            this.lbllabel1.Text = "Maximum &Suggestion Count";
            // 
            // MaxSuggestions
            // 
            this.MaxSuggestions.Location = new System.Drawing.Point(24, 112);
            this.MaxSuggestions.MaxLength = 2;
            this.MaxSuggestions.Name = "MaxSuggestions";
            this.MaxSuggestions.Size = new System.Drawing.Size(24, 20);
            this.MaxSuggestions.TabIndex = 3;
            this.MaxSuggestions.Text = "25";
            // 
            // IgnoreUpperCheck
            // 
            this.IgnoreUpperCheck.Checked = true;
            this.IgnoreUpperCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IgnoreUpperCheck.Location = new System.Drawing.Point(32, 48);
            this.IgnoreUpperCheck.Name = "IgnoreUpperCheck";
            this.IgnoreUpperCheck.Size = new System.Drawing.Size(296, 24);
            this.IgnoreUpperCheck.TabIndex = 2;
            this.IgnoreUpperCheck.Text = "Ignore Words in all &Upper Case";
            // 
            // IgnoreDigitsCheck
            // 
            this.IgnoreDigitsCheck.Location = new System.Drawing.Point(32, 24);
            this.IgnoreDigitsCheck.Name = "IgnoreDigitsCheck";
            this.IgnoreDigitsCheck.Size = new System.Drawing.Size(296, 24);
            this.IgnoreDigitsCheck.TabIndex = 1;
            this.IgnoreDigitsCheck.Text = "Ignore Words with &Digits";
            // 
            // dictionaryTab
            // 
            this.dictionaryTab.Controls.Add(this.txtCopyright);
            this.dictionaryTab.Controls.Add(this.label1);
            this.dictionaryTab.Location = new System.Drawing.Point(4, 22);
            this.dictionaryTab.Name = "dictionaryTab";
            this.dictionaryTab.Size = new System.Drawing.Size(354, 146);
            this.dictionaryTab.TabIndex = 2;
            this.dictionaryTab.Text = "Dictionary";
            // 
            // txtCopyright
            // 
            this.txtCopyright.Location = new System.Drawing.Point(8, 32);
            this.txtCopyright.Multiline = true;
            this.txtCopyright.Name = "txtCopyright";
            this.txtCopyright.ReadOnly = true;
            this.txtCopyright.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCopyright.Size = new System.Drawing.Size(360, 112);
            this.txtCopyright.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Dictionary Copyright:";
            // 
            // versionsTab
            // 
            this.versionsTab.Controls.Add(this.assembliesListView);
            this.versionsTab.Location = new System.Drawing.Point(4, 22);
            this.versionsTab.Name = "versionsTab";
            this.versionsTab.Size = new System.Drawing.Size(354, 146);
            this.versionsTab.TabIndex = 3;
            this.versionsTab.Text = "Versions";
            // 
            // assembliesListView
            // 
            this.assembliesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.assemblyColumnHeader,
            this.versionColumnHeader,
            this.dateColumnHeader});
            this.assembliesListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.assembliesListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.assembliesListView.Location = new System.Drawing.Point(0, 0);
            this.assembliesListView.Name = "assembliesListView";
            this.assembliesListView.Size = new System.Drawing.Size(354, 146);
            this.assembliesListView.TabIndex = 5;
            this.assembliesListView.UseCompatibleStateImageBehavior = false;
            this.assembliesListView.View = System.Windows.Forms.View.Details;
            // 
            // assemblyColumnHeader
            // 
            this.assemblyColumnHeader.Text = "Module";
            this.assemblyColumnHeader.Width = 176;
            // 
            // versionColumnHeader
            // 
            this.versionColumnHeader.Text = "Version";
            this.versionColumnHeader.Width = 92;
            // 
            // dateColumnHeader
            // 
            this.dateColumnHeader.Text = "Date";
            this.dateColumnHeader.Width = 87;
            // 
            // FOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(367, 250);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.optionsTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FOptions";
            this.Text = "FOptions";
            this.Load += new System.EventHandler(this.FOptions_Load);
            this.Controls.SetChildIndex(this.pnlHeader, 0);
            this.Controls.SetChildIndex(this.optionsTabControl, 0);
            this.Controls.SetChildIndex(this.OkButton, 0);
            this.Controls.SetChildIndex(this.CancelBtn, 0);
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.optionsTabControl.ResumeLayout(false);
            this.generalTab.ResumeLayout(false);
            this.generalTab.PerformLayout();
            this.dictionaryTab.ResumeLayout(false);
            this.dictionaryTab.PerformLayout();
            this.versionsTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.TabControl optionsTabControl;
        private System.Windows.Forms.TabPage generalTab;
        private System.Windows.Forms.CheckBox IgnoreHtmlCheck;
        private System.Windows.Forms.Label lbllabel1;
        private System.Windows.Forms.TextBox MaxSuggestions;
        private System.Windows.Forms.CheckBox IgnoreUpperCheck;
        private System.Windows.Forms.CheckBox IgnoreDigitsCheck;
        private System.Windows.Forms.TabPage dictionaryTab;
        private System.Windows.Forms.TextBox txtCopyright;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage versionsTab;
        private System.Windows.Forms.ListView assembliesListView;
        private System.Windows.Forms.ColumnHeader assemblyColumnHeader;
        private System.Windows.Forms.ColumnHeader versionColumnHeader;
        private System.Windows.Forms.ColumnHeader dateColumnHeader;
    }
}