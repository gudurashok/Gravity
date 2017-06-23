using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Scalable.Win.Forms;

namespace Scalable.SpellChecker.Forms
{
    public partial class FSuggestion : FFormBase
    {
        private Spelling _spellChecker;

        public FSuggestion(Spelling spell)
        {
            InitializeComponent();
            Closing += SpellingForm_Closing;
            _spellChecker = spell;
            AttachEvents();
            setFormTitle();
        }

        private void setFormTitle()
        {
            Text = @"Spellcheck";
            lblTitle.Text = @"Suggestions for wrong spellings";
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            _spellChecker.Dictionary.Add(_spellChecker.CurrentWord);
            _spellChecker.SpellCheck();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Hide();
            if (Owner != null)
                Owner.Activate();
        }

        private void IgnoreAllButton_Click(object sender, EventArgs e)
        {
            _spellChecker.IgnoreAllWord();
            _spellChecker.SpellCheck();
        }

        private void IgnoreButton_Click(object sender, EventArgs e)
        {
            _spellChecker.IgnoreWord();
            _spellChecker.SpellCheck();
        }

        private void OptionsButton_Click(object sender, EventArgs e)
        {
            var options = new FOptions(ref _spellChecker);
            options.ShowDialog(this);

            if (options.DialogResult == DialogResult.OK)
                _spellChecker.SpellCheck();
        }

        private void ReplaceAllButton_Click(object sender, EventArgs e)
        {
            _spellChecker.ReplaceAllWord(ReplacementWord.Text);
            TextBeingChecked.Text = _spellChecker.Text;
            _spellChecker.SpellCheck();
        }

        private void ReplaceButton_Click(object sender, EventArgs e)
        {
            _spellChecker.ReplaceWord(ReplacementWord.Text);
            TextBeingChecked.Text = _spellChecker.Text;
            _spellChecker.SpellCheck();
        }

        private void SpellingForm_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            Hide();
            if (Owner != null) Owner.Activate();
        }

        private void SpellingForm_Load(object sender, EventArgs e)
        {
            TextBeingChecked.Text = _spellChecker.Text;
            statusPaneWord.Text = "";
            statusPaneCount.Text = @"Word: 0 of 0";
            statusPaneIndex.Text = @"Index: 0";
            SuggestionList.Items.Clear();
        }

        private void SuggestionList_DoubleClick(object sender, EventArgs e)
        {
            ReplaceButton_Click(sender, e);
        }

        private void SuggestionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SuggestionList.SelectedIndex >= 0)
                ReplacementWord.Text = SuggestionList.SelectedItem.ToString();
        }

        #region Spelling Events

        private void SpellChecker_DoubledWord(object sender, SpellingEventArgs e)
        {
            UpdateDisplay(_spellChecker.Text, e.Word, e.WordIndex, e.TextIndex);

            //turn off ignore all option on double word
            IgnoreAllButton.Enabled = false;
            ReplaceAllButton.Enabled = false;
            AddButton.Enabled = false;
        }

        private void SpellChecker_EndOfText(object sender, EventArgs e)
        {
            UpdateDisplay(_spellChecker.Text, "", 0, 0);

            if (_spellChecker.AlertComplete)
            {
                MessageBox.Show(this, @"Spell Check Complete.", @"Spell Check",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Hide();
            if (Owner != null) Owner.Activate();
        }

        private void SpellChecker_MisspelledWord(object sender, SpellingEventArgs e)
        {
            UpdateDisplay(_spellChecker.Text, e.Word, e.WordIndex, e.TextIndex);

            //turn on ignore all option
            IgnoreAllButton.Enabled = true;
            ReplaceAllButton.Enabled = true;

            //generate suggestions
            _spellChecker.Suggest();

            //display suggestions
            SuggestionList.Items.AddRange((string[])_spellChecker.Suggestions.ToArray(typeof(string)));
        }

        private void UpdateDisplay(string text, string word, int wordIndex, int textIndex)
        {
            //display form
            if (!Visible)
                Show();

            Activate();

            //set text context
            TextBeingChecked.ResetText();
            TextBeingChecked.SelectionColor = Color.Black;

            if (word.Length > 0)
            {
                //highlight current word
                TextBeingChecked.AppendText(text.Substring(0, textIndex));
                TextBeingChecked.SelectionColor = Color.Red;
                TextBeingChecked.AppendText(word);
                TextBeingChecked.SelectionColor = Color.Black;
                TextBeingChecked.AppendText(text.Substring(textIndex + word.Length));

                //set caret and scroll window
                TextBeingChecked.Select(textIndex, 0);
                TextBeingChecked.Focus();
                TextBeingChecked.ScrollToCaret();
            }
            else
            {
                TextBeingChecked.AppendText(text);
            }

            //update status bar
            statusPaneWord.Text = word;
            wordIndex++;  //WordIndex is 0 base, display is 1 based
            statusPaneCount.Text = string.Format("Word: {0} of {1}",
                wordIndex.ToString(), _spellChecker.WordCount.ToString(CultureInfo.CurrentUICulture));
            statusPaneIndex.Text = string.Format("Index: {0}", textIndex.ToString());

            //display suggestions
            SuggestionList.BeginUpdate();
            SuggestionList.SelectedIndex = -1;
            SuggestionList.Items.Clear();
            SuggestionList.EndUpdate();

            //reset replacement word
            ReplacementWord.Text = string.Empty;
            ReplacementWord.Focus();
        }

        internal void AttachEvents()
        {
            _spellChecker.MisspelledWord += SpellChecker_MisspelledWord;
            _spellChecker.DoubledWord += SpellChecker_DoubledWord;
            _spellChecker.EndOfText += SpellChecker_EndOfText;
        }

        internal void DetachEvents()
        {
            _spellChecker.MisspelledWord -= SpellChecker_MisspelledWord;
            _spellChecker.DoubledWord -= SpellChecker_DoubledWord;
            _spellChecker.EndOfText -= SpellChecker_EndOfText;
        }

        #endregion

    }
}
