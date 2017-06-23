namespace Scalable.SpellChecker.Forms
{
    partial class FSuggestion
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
            this.AddButton = new System.Windows.Forms.Button();
            this.OptionsButton = new System.Windows.Forms.Button();
            this.TextLabel = new System.Windows.Forms.Label();
            this.SuggestionsLabel = new System.Windows.Forms.Label();
            this.ReplaceLabel = new System.Windows.Forms.Label();
            this.ReplacementWord = new System.Windows.Forms.TextBox();
            this.TextBeingChecked = new System.Windows.Forms.RichTextBox();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.ReplaceAllButton = new System.Windows.Forms.Button();
            this.IgnoreAllButton = new System.Windows.Forms.Button();
            this.ReplaceButton = new System.Windows.Forms.Button();
            this.IgnoreButton = new System.Windows.Forms.Button();
            this.SuggestionList = new System.Windows.Forms.ListBox();
            this.statusPaneIndex = new System.Windows.Forms.StatusBarPanel();
            this.statusPaneCount = new System.Windows.Forms.StatusBarPanel();
            this.statusPaneWord = new System.Windows.Forms.StatusBarPanel();
            this.spellStatus = new System.Windows.Forms.StatusBar();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusPaneIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusPaneCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusPaneWord)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Size = new System.Drawing.Size(435, 43);
            // 
            // picLogo
            // 
            this.picLogo.Location = new System.Drawing.Point(392, 2);
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(383, 39);
            // 
            // AddButton
            // 
            this.AddButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AddButton.Location = new System.Drawing.Point(357, 123);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 23);
            this.AddButton.TabIndex = 21;
            this.AddButton.Text = "&Add";
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // OptionsButton
            // 
            this.OptionsButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.OptionsButton.Location = new System.Drawing.Point(357, 210);
            this.OptionsButton.Name = "OptionsButton";
            this.OptionsButton.Size = new System.Drawing.Size(75, 23);
            this.OptionsButton.TabIndex = 24;
            this.OptionsButton.Text = "&Options";
            this.OptionsButton.Click += new System.EventHandler(this.OptionsButton_Click);
            // 
            // TextLabel
            // 
            this.TextLabel.AutoSize = true;
            this.TextLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.TextLabel.Location = new System.Drawing.Point(2, 49);
            this.TextLabel.Name = "TextLabel";
            this.TextLabel.Size = new System.Drawing.Size(107, 13);
            this.TextLabel.TabIndex = 13;
            this.TextLabel.Text = "Text Being Checked:";
            // 
            // SuggestionsLabel
            // 
            this.SuggestionsLabel.AutoSize = true;
            this.SuggestionsLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.SuggestionsLabel.Location = new System.Drawing.Point(2, 179);
            this.SuggestionsLabel.Name = "SuggestionsLabel";
            this.SuggestionsLabel.Size = new System.Drawing.Size(68, 13);
            this.SuggestionsLabel.TabIndex = 17;
            this.SuggestionsLabel.Text = "S&uggestions:";
            // 
            // ReplaceLabel
            // 
            this.ReplaceLabel.AutoSize = true;
            this.ReplaceLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ReplaceLabel.Location = new System.Drawing.Point(2, 139);
            this.ReplaceLabel.Name = "ReplaceLabel";
            this.ReplaceLabel.Size = new System.Drawing.Size(72, 13);
            this.ReplaceLabel.TabIndex = 14;
            this.ReplaceLabel.Text = "Replace &with:";
            // 
            // ReplacementWord
            // 
            this.ReplacementWord.Location = new System.Drawing.Point(3, 155);
            this.ReplacementWord.Name = "ReplacementWord";
            this.ReplacementWord.Size = new System.Drawing.Size(348, 20);
            this.ReplacementWord.TabIndex = 16;
            // 
            // TextBeingChecked
            // 
            this.TextBeingChecked.BackColor = System.Drawing.SystemColors.Window;
            this.TextBeingChecked.DetectUrls = false;
            this.TextBeingChecked.Location = new System.Drawing.Point(3, 65);
            this.TextBeingChecked.Name = "TextBeingChecked";
            this.TextBeingChecked.ReadOnly = true;
            this.TextBeingChecked.Size = new System.Drawing.Size(348, 72);
            this.TextBeingChecked.TabIndex = 15;
            this.TextBeingChecked.TabStop = false;
            this.TextBeingChecked.Text = "";
            // 
            // CancelBtn
            // 
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.CancelBtn.Location = new System.Drawing.Point(357, 239);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 25;
            this.CancelBtn.Text = "&Cancel";
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // ReplaceAllButton
            // 
            this.ReplaceAllButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ReplaceAllButton.Location = new System.Drawing.Point(357, 181);
            this.ReplaceAllButton.Name = "ReplaceAllButton";
            this.ReplaceAllButton.Size = new System.Drawing.Size(75, 23);
            this.ReplaceAllButton.TabIndex = 23;
            this.ReplaceAllButton.Text = "Replace A&ll";
            this.ReplaceAllButton.Click += new System.EventHandler(this.ReplaceAllButton_Click);
            // 
            // IgnoreAllButton
            // 
            this.IgnoreAllButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.IgnoreAllButton.Location = new System.Drawing.Point(357, 94);
            this.IgnoreAllButton.Name = "IgnoreAllButton";
            this.IgnoreAllButton.Size = new System.Drawing.Size(75, 23);
            this.IgnoreAllButton.TabIndex = 20;
            this.IgnoreAllButton.Text = "I&gnore All";
            this.IgnoreAllButton.Click += new System.EventHandler(this.IgnoreAllButton_Click);
            // 
            // ReplaceButton
            // 
            this.ReplaceButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ReplaceButton.Location = new System.Drawing.Point(357, 152);
            this.ReplaceButton.Name = "ReplaceButton";
            this.ReplaceButton.Size = new System.Drawing.Size(75, 23);
            this.ReplaceButton.TabIndex = 22;
            this.ReplaceButton.Text = "&Replace";
            this.ReplaceButton.Click += new System.EventHandler(this.ReplaceButton_Click);
            // 
            // IgnoreButton
            // 
            this.IgnoreButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.IgnoreButton.Location = new System.Drawing.Point(357, 65);
            this.IgnoreButton.Name = "IgnoreButton";
            this.IgnoreButton.Size = new System.Drawing.Size(75, 23);
            this.IgnoreButton.TabIndex = 19;
            this.IgnoreButton.Text = "&Ignore";
            this.IgnoreButton.Click += new System.EventHandler(this.IgnoreButton_Click);
            // 
            // SuggestionList
            // 
            this.SuggestionList.Location = new System.Drawing.Point(3, 195);
            this.SuggestionList.Name = "SuggestionList";
            this.SuggestionList.Size = new System.Drawing.Size(348, 95);
            this.SuggestionList.TabIndex = 18;
            this.SuggestionList.SelectedIndexChanged += new System.EventHandler(this.SuggestionList_SelectedIndexChanged);
            this.SuggestionList.DoubleClick += new System.EventHandler(this.SuggestionList_DoubleClick);
            // 
            // statusPaneIndex
            // 
            this.statusPaneIndex.Name = "statusPaneIndex";
            this.statusPaneIndex.Text = "Index: 0";
            this.statusPaneIndex.Width = 80;
            // 
            // statusPaneCount
            // 
            this.statusPaneCount.Name = "statusPaneCount";
            this.statusPaneCount.Text = "Word: 0 of 0";
            // 
            // statusPaneWord
            // 
            this.statusPaneWord.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.statusPaneWord.Name = "statusPaneWord";
            this.statusPaneWord.Width = 242;
            // 
            // spellStatus
            // 
            this.spellStatus.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.spellStatus.Location = new System.Drawing.Point(0, 293);
            this.spellStatus.Name = "spellStatus";
            this.spellStatus.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusPaneWord,
            this.statusPaneCount,
            this.statusPaneIndex});
            this.spellStatus.ShowPanels = true;
            this.spellStatus.Size = new System.Drawing.Size(435, 16);
            this.spellStatus.TabIndex = 26;
            // 
            // FSuggestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 309);
            this.Controls.Add(this.spellStatus);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.OptionsButton);
            this.Controls.Add(this.TextLabel);
            this.Controls.Add(this.SuggestionsLabel);
            this.Controls.Add(this.ReplaceLabel);
            this.Controls.Add(this.ReplacementWord);
            this.Controls.Add(this.TextBeingChecked);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.ReplaceAllButton);
            this.Controls.Add(this.IgnoreAllButton);
            this.Controls.Add(this.ReplaceButton);
            this.Controls.Add(this.IgnoreButton);
            this.Controls.Add(this.SuggestionList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FSuggestion";
            this.Text = "FSuggestion";
            this.Load += new System.EventHandler(this.SpellingForm_Load);
            this.Controls.SetChildIndex(this.SuggestionList, 0);
            this.Controls.SetChildIndex(this.IgnoreButton, 0);
            this.Controls.SetChildIndex(this.ReplaceButton, 0);
            this.Controls.SetChildIndex(this.IgnoreAllButton, 0);
            this.Controls.SetChildIndex(this.ReplaceAllButton, 0);
            this.Controls.SetChildIndex(this.CancelBtn, 0);
            this.Controls.SetChildIndex(this.TextBeingChecked, 0);
            this.Controls.SetChildIndex(this.ReplacementWord, 0);
            this.Controls.SetChildIndex(this.ReplaceLabel, 0);
            this.Controls.SetChildIndex(this.SuggestionsLabel, 0);
            this.Controls.SetChildIndex(this.TextLabel, 0);
            this.Controls.SetChildIndex(this.OptionsButton, 0);
            this.Controls.SetChildIndex(this.AddButton, 0);
            this.Controls.SetChildIndex(this.spellStatus, 0);
            this.Controls.SetChildIndex(this.pnlHeader, 0);
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusPaneIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusPaneCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusPaneWord)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button OptionsButton;
        private System.Windows.Forms.Label TextLabel;
        private System.Windows.Forms.Label SuggestionsLabel;
        private System.Windows.Forms.Label ReplaceLabel;
        private System.Windows.Forms.TextBox ReplacementWord;
        private System.Windows.Forms.RichTextBox TextBeingChecked;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button ReplaceAllButton;
        private System.Windows.Forms.Button IgnoreAllButton;
        private System.Windows.Forms.Button ReplaceButton;
        private System.Windows.Forms.Button IgnoreButton;
        private System.Windows.Forms.ListBox SuggestionList;
        private System.Windows.Forms.StatusBarPanel statusPaneIndex;
        private System.Windows.Forms.StatusBarPanel statusPaneCount;
        private System.Windows.Forms.StatusBarPanel statusPaneWord;
        private System.Windows.Forms.StatusBar spellStatus;
    }
}