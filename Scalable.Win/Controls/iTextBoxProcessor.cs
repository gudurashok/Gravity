using System;
using System.Text;
using System.Windows.Forms;
using Scalable.Shared.Enums;
using Scalable.Win.Events;
using System.Text.RegularExpressions;
using System.Linq;
namespace Scalable.Win.Controls
{
    public class iTextBoxProcessor : ITextBoxBase
    {
        #region  Declarations

        private TextCaseStyle _currentCase;
        private string _originalText;
        private readonly ITextBoxBase _textBox;

        #endregion

        #region Properties

        public string Text
        {
            get { return _textBox.Text; }
            set { _textBox.Text = value; }
        }

        public int SelectionLength
        {
            get { return _textBox.SelectionLength; }
            set { _textBox.SelectionLength = value; }
        }

        public string InputFilterExpr { get; set; }
        public TextCaseStyle AutoCasing { get; set; }
        public event PicklistSearchEventHandler Search;

        #endregion

        #region Inherited Public Methods

        public void SelectAll()
        {
            _textBox.SelectAll();
        }

        public int SelectionStart
        {
            get { return _textBox.SelectionStart; }
            set { _textBox.SelectionStart = value; }
        }

        public void Select(int start, int length)
        {
            _textBox.Select(start, length);
        }

        #endregion

        #region Constructor

        public iTextBoxProcessor(ITextBoxBase textBox)
        {
            _textBox = textBox;
        }

        #endregion

        #region Event Handling

        public void ProcessOnEnter()
        {
            SelectAll();
            _originalText = Text;
        }

        public bool IsKeyCharValid(char ch)
        {
            if (ch == (char)Keys.Back)
                return true;

            var rgx = new Regex(InputFilterExpr, RegexOptions.RightToLeft);
            var matches = rgx.Matches(ch.ToString());
            return (matches.Count > 0);
        }

        public void ProcessOnKeyDown(KeyEventArgs e)
        {
            if (areCopyAndPasteKeys(e))
                return;

            if (e.KeyCode == Keys.Escape)
            {
                Text = _originalText;
                return;
            }

            if (e.Control && e.KeyCode == Keys.Back)
            {
                e.SuppressKeyPress = true;
                Text = "";
                return;
            }

            if (Text.Length == 0 || e.Alt)
                return;

            if (e.KeyCode == Keys.F2 && e.Modifiers == Keys.None)
            {
                toggleTextSelection();
                return;
            }

            if (e.KeyCode == Keys.F3)
            {
                //TODO: commented due to error in Proper Casing
                //if (AutoCasing != TextCaseStyle.Normal)
                //    return;

                if (e.Modifiers == Keys.Shift)
                {
                    Text = Text.ToUpper();
                    return;
                }

                if (string.IsNullOrWhiteSpace(_originalText))
                    _originalText = Text;

                setNextCaseStyle(e.Control);
                switchCase(getSwitchedCaseText());
            }
        }

        private bool areCopyAndPasteKeys(KeyEventArgs e)
        {
            return e.Control && !e.Alt && !e.Shift &&
                   (e.KeyCode == Keys.V || e.KeyCode == Keys.C);
        }

        #endregion

        #region Toggle Text Selection

        private void toggleTextSelection()
        {
            if (SelectionLength != Text.Length)
                SelectAll();
            else
                SelectionLength = 0;
        }

        #endregion

        #region Switch Character Case

        private void switchCase(string switchedText)
        {
            Text = switchedText;
            SelectionStart = Text.Length;
        }

        private string getSwitchedCaseText()
        {
            switch (_currentCase)
            {
                case TextCaseStyle.Normal:
                    return _originalText;
                case TextCaseStyle.Upper:
                    return Text.ToUpper();
                case TextCaseStyle.Lower:
                    return Text.ToLower();
                case TextCaseStyle.Proper:
                    return getProperCase();
                case TextCaseStyle.Title:
                    return string.Format("{0}{1}", Text.Substring(0, 1), Text.Substring(1).ToLower());
                default:
                    return Text;
            }
        }

        private string getProperCase()
        {
            var sb = new StringBuilder();

            foreach (var word in Text.Split(' '))
            {
                sb.Append(word.Length > 1
                              ? string.Format("{0}{1}", word.Substring(0, 1).ToUpper(), word.Substring(1))
                              : word.ToUpper());

                sb.Append(' ');
            }

            return sb.Remove(sb.Length - 1, 1).ToString();
        }

        private void setNextCaseStyle(bool backwards)
        {
            var style = (int)_currentCase;
            style += backwards ? -1 : +1;
            if (style > (int)TextCaseStyle.Title)
                style = 0;
            else if (style < 0)
                style = (int)TextCaseStyle.Title;

            _currentCase = (TextCaseStyle)style;
        }

        #endregion

        #region Auto Charater Casing

        public void PerformAutoCasing(KeyPressEventArgs e)
        {
            if (AutoCasing == TextCaseStyle.Normal)
            {
                _originalText = null;
                return;
            }

            if (AutoCasing == TextCaseStyle.Proper)
                return;

            e.KeyChar = changeCase(e.KeyChar);
        }

        private char changeCase(char c)
        {
            if (getCaseStyle() == CharacterCasing.Upper)
                return char.ToUpper(c);

            return char.ToLower(c);
        }

        private CharacterCasing getCaseStyle()
        {
            switch (AutoCasing)
            {
                case TextCaseStyle.Upper:
                    return CharacterCasing.Upper; // TODO: implement proper case
                //{
                //    if (SelectionStart != 0)
                //        return TextCaseStyle.Lower;
                //    else
                //        return TextCaseStyle.Lower;
                //}
                case TextCaseStyle.Title:
                    if (SelectionStart == 0)
                        return CharacterCasing.Upper;

                    return CharacterCasing.Lower;
                default:
                    return CharacterCasing.Normal;
            }
        }

        #endregion

        #region Auto Completion

        public void PerformAutoCompletion(KeyPressEventArgs e)
        {
            var oldText = getOldInputText();

            if (e.KeyChar == (char)Keys.Escape)
                e.KeyChar = (char)Keys.None;

            e.KeyChar = Char.ToUpper(e.KeyChar);
            var inputText = appendTypedKeyChar(e.KeyChar, oldText);
            if (inputText.Length == 0)
                Text = "";

            e.Handled = autoCompletionPerformed(inputText);
        }

        private string getOldInputText()
        {
            return Text.Substring(0, SelectionStart);
        }

        private string appendTypedKeyChar(char keyChar, string text)
        {
            if ((keyChar == (char)Keys.Back) && text.Length > 0)
                return text.Remove(text.Length - 1, 1);

            if ((keyChar == (char)Keys.Back))
                return text;

            return string.Concat(text, keyChar);
        }

        private bool autoCompletionPerformed(string inputText)
        {
            var args = new PicklistSearchEventArgs(inputText);
            OnSearch(args);

            if (args.Result == null)
                return false;

            Text = args.Result.Text; //.ToUpper(); //TODO: should do based on character casing. Nnot upper!!!
            highlightTextFound(inputText);
            return true;
        }

        protected virtual void OnSearch(PicklistSearchEventArgs e)
        {
            if (Search != null)
                Search(this, e);
        }

        private void highlightTextFound(string inputText)
        {
            Select(inputText.Length, Text.Length - inputText.Length);
        }

        #endregion
    }
}

