using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Scalable.SpellChecker.Controls
{
    public class SpellTextBox : RichTextBox
    {
        private Spelling _spellChecker;
        private bool _autoSpellCheck = true;
        private UnderlineColor _misspelledColor = UnderlineColor.Red;
        private UnderlineStyle _misspelledStyle = UnderlineStyle.UnderlineWave;

        private int _previousTextLength;
        private int _uncheckedWordIndex = -1;
        private int _currentWordIndex;

        public enum UnderlineColor
        {
            Default = 0x00,
            Blue = 0x10,
            Aqua = 0x20,
            Lime = 0x30,
            Fuchsia = 0x40,
            Red = 0x50,
            Yellow = 0x60,
            White = 0x70,
            Navy = 0x80,
            Teal = 0x90,
            Green = 0xa0,
            Purple = 0xb0,
            Maroon = 0xc0,
            Olive = 0xd0,
            Gray = 0xe0,
            Silver = 0xf0
        }

        public enum UnderlineStyle
        {
            Underline = 1,
            UnderlineDouble = 3,
            UnderlineDotted = 4,
            UnderlineDash = 5,
            UnderlineDashDot = 6,
            UnderlineDashDotDot = 7,
            UnderlineWave = 8,
            UnderlineThick = 9,
            UnderlineHairline = 10,
            UnderlineDoubleWave = 11,
            UnderlineHeavyWave = 12,
            UnderlineLongDash = 13,
            UnderlineThickDash = 14,
            UnderlineThickDashDot = 15,
            UnderlineThickDashDotDot = 16,
            UnderlineThickDotted = 17,
            UnderlineThickLongDash = 18
        }

        private void SpellChecker_MisspelledWord(object sender, SpellingEventArgs args)
        {
            TraceWriter.TraceVerbose("Misspelled Word:{0}", args.Word);

            var selectionStart = SelectionStart;
            var selectionLength = base.SelectionLength;

            Select(args.TextIndex, args.Word.Length);

            //NativeMethods.CHARFORMAT2 cf = new NativeMethods.CHARFORMAT2();
            //cf.cbSize = Marshal.SizeOf(cf);
            //cf.dwMask = NativeMethods.CFM_UNDERLINETYPE;
            //cf.bUnderlineType = (byte)MisspelledStyle;
            //cf.bUnderlineType |= (byte)MisspelledColor;

            //int result = NativeMethods.SendMessage(base.Handle,
            //    NativeMethods.EM_SETCHARFORMAT,
            //    NativeMethods.SCF_SELECTION | NativeMethods.SCF_WORD,
            //    ref cf);

            Select(selectionStart, selectionLength);
        }

        //private NativeMethods.CHARFORMAT2 GetCharFormat()
        //{
        //    NativeMethods.CHARFORMAT2 cf = new NativeMethods.CHARFORMAT2();
        //    cf.cbSize = Marshal.SizeOf(cf);
        //    int result = NativeMethods.SendMessage(base.Handle,
        //        NativeMethods.EM_GETCHARFORMAT,
        //        NativeMethods.SCF_SELECTION,
        //        ref cf);

        //    return cf;
        //}

        [Browsable(true)]
        [CategoryAttribute("Spell")]
        [Description("The Color to use to mark misspelled words")]
        [DefaultValue(UnderlineColor.Red)]
        public UnderlineColor MisspelledColor
        {
            get { return _misspelledColor; }
            set { _misspelledColor = value; }
        }

        /// <summary>
        ///     The Underline style used to mark misspelled words
        /// </summary>
        [Browsable(true)]
        [CategoryAttribute("Spell")]
        [Description("The underline style used to mark misspelled words")]
        [DefaultValue(UnderlineStyle.UnderlineWave)]
        public UnderlineStyle MisspelledStyle
        {
            get { return _misspelledStyle; }
            set { _misspelledStyle = value; }
        }

        //[Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public Color SelectionBackColor
        //{
        //    get
        //    {
        //        NativeMethods.CHARFORMAT2 cf = this.GetCharFormat();
        //        return ColorTranslator.FromOle(cf.crBackColor);
        //    }
        //    set
        //    {
        //        NativeMethods.CHARFORMAT2 cf = new NativeMethods.CHARFORMAT2();
        //        cf.cbSize = Marshal.SizeOf(cf);
        //        cf.dwMask = NativeMethods.CFM_BACKCOLOR;
        //        cf.crBackColor = ColorTranslator.ToWin32(value);

        //        int result = NativeMethods.SendMessage(base.Handle,
        //            NativeMethods.EM_SETCHARFORMAT,
        //            NativeMethods.SCF_SELECTION,
        //            ref cf);
        //    }
        //}

        [Browsable(true)]
        [CategoryAttribute("Spell")]
        [Description("Automatically mark misspelled words")]
        [DefaultValue(true)]
        public bool AutoSpellCheck
        {
            get { return _autoSpellCheck; }
            set { _autoSpellCheck = value; }
        }

        [Browsable(true)]
        [CategoryAttribute("Spell")]
        [Description("The Spelling Object to use when checking words")]
        public Spelling SpellChecker
        {
            get { return _spellChecker; }
            set
            {
                if (value == null) 
                    return;

                _spellChecker = value;
                _spellChecker.MisspelledWord += SpellChecker_MisspelledWord;
            }
        }


        protected override void OnTextChanged(EventArgs e)
        {
            // get change size
            var changeSize = Text.Length - _previousTextLength;
            _previousTextLength = Text.Length;

            // sync spell checker text with text box text
            _spellChecker.Text = base.Text;

            var currentPosition = SelectionStart;

            // get indexs
            var previousWordIndex = _spellChecker.GetWordIndexFromTextIndex(currentPosition - changeSize);
            _currentWordIndex = _spellChecker.GetWordIndexFromTextIndex(currentPosition);

            // set current word to spell check
            _spellChecker.WordIndex = previousWordIndex;

            // get the end index of previous word with out white space
            var wordEndIndex = _spellChecker.TextIndex + _spellChecker.CurrentWord.Length;

            TraceWriter.TraceVerbose("ChangeSize:{0}; PreviousWord:{1}; CurrentWord:{2}; Position:{3}; WordEnd:{4};",
                changeSize, previousWordIndex, _currentWordIndex, currentPosition, wordEndIndex);

            if (previousWordIndex != _currentWordIndex || wordEndIndex < currentPosition)
            {
                // if word indexs not equal, spell check all words from previousWordIndex to CurrentWordIndex
                // or if word indexs equal, spell check if caret in white space
                MarkMisspelledWords(previousWordIndex, _currentWordIndex);
                _uncheckedWordIndex = -1;
            }
            else
            {
                _uncheckedWordIndex = previousWordIndex;
            }

            base.OnTextChanged(e);
        }

        protected override void OnSelectionChanged(EventArgs e)
        {
            _currentWordIndex = _spellChecker.GetWordIndexFromTextIndex(SelectionStart);
            if (_uncheckedWordIndex != -1 && _currentWordIndex != _uncheckedWordIndex)
            {
                // if uncheck word index not equal current word index, spell check uncheck word
                MarkMisspelledWords(_uncheckedWordIndex, _uncheckedWordIndex);
                _uncheckedWordIndex = -1;
            }
            base.OnSelectionChanged(e);
        }

        private void MarkMisspelledWords()
        {
            MarkMisspelledWords(0, _spellChecker.WordCount - 1);
        }

        private void MarkMisspelledWords(int startWordIndex, int endWordIndex)
        {
            TraceWriter.TraceVerbose("Mark Misspelled Words {0} to {1}", startWordIndex, endWordIndex);

            ////optimize by disabling event messages
            //var eventMask = NativeMethods.SendMessage(Handle, NativeMethods.EM_SETEVENTMASK, 0, 0);
            
            //optimize by disabling redraw
            NativeMethods.SendMessage(Handle, NativeMethods.WM_SETREDRAW, 0, 0);

            //save selection	
            var selectStart = SelectionStart;
            var selectLength = base.SelectionLength;

            //save show dialog value
            var dialog = SpellChecker.ShowDialog;

            //disable show dialog to prevent dialogs on spell check
            SpellChecker.ShowDialog = false;

            //spell check all words in range
            while (SpellChecker.SpellCheck(startWordIndex, endWordIndex))
                startWordIndex++;

            //restore show dialog value
            SpellChecker.ShowDialog = dialog;

            //restore selection
            Select(selectStart, selectLength);

            ////restore event messages
            //eventMask = NativeMethods.SendMessage(Handle, NativeMethods.EM_SETEVENTMASK, 0, eventMask);
        
            //restore redraw
            NativeMethods.SendMessage(Handle, NativeMethods.WM_SETREDRAW, 1, 0); 
        }
    }
}
