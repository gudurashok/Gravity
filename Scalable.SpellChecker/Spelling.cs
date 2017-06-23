using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using Scalable.SpellChecker.Dictionary;
using Scalable.SpellChecker.Forms;

namespace Scalable.SpellChecker
{
    [ToolboxBitmap(typeof(Spelling), "Spelling.bmp")]
    public class Spelling : Component
    {
        #region Global Regex
        // Regex are class scope and compiled to improve performance on reuse
        private readonly Regex _digitRegex = new Regex(@"^\d", RegexOptions.Compiled);
        private readonly Regex _htmlRegex = new Regex(@"</[c-g\d]+>|</[i-o\d]+>|</[a\d]+>|</[q-z\d]+>|<[cg]+[^>]*>|<[i-o]+[^>]*>|<[q-z]+[^>]*>|<[a]+[^>]*>|<(\[^\]*\|'[^']*'|[^'\>])*>", RegexOptions.IgnoreCase & RegexOptions.Compiled);
        private MatchCollection _htmlTags;
        private readonly Regex _letterRegex = new Regex(@"\D", RegexOptions.Compiled);
        private readonly Regex _upperRegex = new Regex(@"[^A-Z]", RegexOptions.Compiled);
        private readonly Regex _wordEx = new Regex(@"\b[A-Za-z0-9_'À-ÿ]+\b", RegexOptions.Compiled);
        private MatchCollection _words;
        #endregion

        #region private variables
        private Container _components;
        #endregion

        #region Events

        public event DeletedWordEventHandler DeletedWord;
        public event DoubledWordEventHandler DoubledWord;
        public event EndOfTextEventHandler EndOfText;
        public event IgnoredWordEventHandler IgnoredWord;
        public event MisspelledWordEventHandler MisspelledWord;
        public event ReplacedWordEventHandler ReplacedWord;

        public delegate void DeletedWordEventHandler(object sender, SpellingEventArgs e);
        public delegate void DoubledWordEventHandler(object sender, SpellingEventArgs e);
        public delegate void EndOfTextEventHandler(object sender, EventArgs e);
        public delegate void IgnoredWordEventHandler(object sender, SpellingEventArgs e);
        public delegate void MisspelledWordEventHandler(object sender, SpellingEventArgs e);
        public delegate void ReplacedWordEventHandler(object sender, ReplaceWordEventArgs e);

        protected virtual void OnDeletedWord(SpellingEventArgs e)
        {
            if (DeletedWord != null)
                DeletedWord(this, e);
        }

        protected virtual void OnDoubledWord(SpellingEventArgs e)
        {
            if (DoubledWord != null)
                DoubledWord(this, e);
        }

        protected virtual void OnEndOfText(EventArgs e)
        {
            if (EndOfText != null)
                EndOfText(this, e);
        }

        protected virtual void OnIgnoredWord(SpellingEventArgs e)
        {
            if (IgnoredWord != null)
                IgnoredWord(this, e);
        }

        protected virtual void OnMisspelledWord(SpellingEventArgs e)
        {
            if (MisspelledWord != null)
                MisspelledWord(this, e);
        }

        protected virtual void OnReplacedWord(ReplaceWordEventArgs e)
        {
            if (ReplacedWord != null)
                ReplacedWord(this, e);
        }

        #endregion

        #region Constructors

        public Spelling()
        {
            InitializeComponent();
        }

        public Spelling(IContainer container)
            : this()
        {
            container.Add(this);
        }

        #endregion

        #region private methods

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_components != null)
                    _components.Dispose();

                // free form resources
                if (_suggestionForm != null)
                    _suggestionForm.Dispose();
            }
            base.Dispose(disposing);
        }

        private void CalculateWords()
        {
            // splits the text into words
            _words = _wordEx.Matches(_text.ToString());

            // remark html
            MarkHtml();
        }

        private bool CheckString(string characters)
        {
            if (_ignoreAllCapsWords && !_upperRegex.IsMatch(characters))
                return false;

            if (_ignoreWordsWithDigits && _digitRegex.IsMatch(characters))
                return false;

            if (!_letterRegex.IsMatch(characters))
                return false;

            if (_ignoreHtml)
            {
                var startIndex = _words[WordIndex].Index;
                return _htmlTags.Cast<Match>().All(item => startIndex < item.Index || startIndex > item.Index + item.Length - 1);
            }

            return true;
        }

        private void Initialize()
        {
            if (_dictionary == null)
                _dictionary = new WordDictionary();

            if (!_dictionary.Initialized)
                _dictionary.Initialize();

            if (_suggestionForm == null && _showDialog)
                _suggestionForm = new FSuggestion(this);
        }

        private void MarkHtml()
        {
            // splits the text into words
            _htmlTags = _htmlRegex.Matches(_text.ToString());
        }

        private void Reset()
        {
            _wordIndex = 0; // reset word index
            _replacementWord = "";
            _suggestions.Clear();
        }

        #endregion

        #region ISpell Near Miss Suggetion methods

        private void BadChar(ref ArrayList tempSuggestion)
        {
            for (var i = 0; i < CurrentWord.Length; i++)
            {
                var tempWord = new StringBuilder(CurrentWord);
                var tryme = Dictionary.TryCharacters.ToCharArray();
                foreach (var t in tryme)
                {
                    tempWord[i] = t;
                    if (!TestWord(tempWord.ToString()))
                        continue;

                    var ws = new Word();
                    ws.Text = tempWord.ToString().ToLower();
                    ws.EditDistance = EditDistance(CurrentWord, tempWord.ToString());

                    tempSuggestion.Add(ws);
                }
            }
        }

        private void ExtraChar(ref ArrayList tempSuggestion)
        {
            if (CurrentWord.Length <= 1)
                return;

            for (var i = 0; i < CurrentWord.Length; i++)
            {
                var tempWord = new StringBuilder(CurrentWord);
                tempWord.Remove(i, 1);

                if (!TestWord(tempWord.ToString()))
                    continue;

                var ws = new Word();
                ws.Text = tempWord.ToString().ToLower(CultureInfo.CurrentUICulture);
                ws.EditDistance = EditDistance(CurrentWord, tempWord.ToString());

                tempSuggestion.Add(ws);
            }
        }

        private void ForgotChar(ref ArrayList tempSuggestion)
        {
            var tryme = Dictionary.TryCharacters.ToCharArray();

            for (var i = 0; i <= CurrentWord.Length; i++)
            {
                foreach (var t in tryme)
                {
                    var tempWord = new StringBuilder(CurrentWord);

                    tempWord.Insert(i, t);
                    if (!TestWord(tempWord.ToString()))
                        continue;

                    var ws = new Word();
                    ws.Text = tempWord.ToString().ToLower();
                    ws.EditDistance = EditDistance(CurrentWord, tempWord.ToString());

                    tempSuggestion.Add(ws);
                }
            }
        }

        private void ReplaceChars(ref ArrayList tempSuggestion)
        {
            var replacementChars = Dictionary.ReplaceCharacters;
            foreach (var t in replacementChars)
            {
                var split = ((string)t).IndexOf(' ');
                var key = ((string)t).Substring(0, split);
                var replacement = ((string)t).Substring(split + 1);

                var pos = CurrentWord.IndexOf(key);
                while (pos > -1)
                {
                    var tempWord = CurrentWord.Substring(0, pos);
                    tempWord += replacement;
                    tempWord += CurrentWord.Substring(pos + key.Length);

                    if (TestWord(tempWord))
                    {
                        var ws = new Word();
                        ws.Text = tempWord.ToLower();
                        ws.EditDistance = EditDistance(CurrentWord, tempWord);

                        tempSuggestion.Add(ws);
                    }
                    pos = CurrentWord.IndexOf(key, pos + 1);
                }
            }
        }

        private void SwapChar(ref ArrayList tempSuggestion)
        {
            for (var i = 0; i < CurrentWord.Length - 1; i++)
            {
                var tempWord = new StringBuilder(CurrentWord);

                var swap = tempWord[i];
                tempWord[i] = tempWord[i + 1];
                tempWord[i + 1] = swap;

                if (!TestWord(tempWord.ToString()))
                    continue;

                var ws = new Word();
                ws.Text = tempWord.ToString().ToLower();
                ws.EditDistance = EditDistance(CurrentWord, tempWord.ToString());

                tempSuggestion.Add(ws);
            }
        }

        private void TwoWords(ref ArrayList tempSuggestion)
        {
            for (var i = 1; i < CurrentWord.Length - 1; i++)
            {
                var firstWord = CurrentWord.Substring(0, i);
                var secondWord = CurrentWord.Substring(i);

                if (!TestWord(firstWord) || !TestWord(secondWord))
                    continue;

                var tempWord = firstWord + " " + secondWord;

                var ws = new Word();
                ws.Text = tempWord.ToLower();
                ws.EditDistance = EditDistance(CurrentWord, tempWord);

                tempSuggestion.Add(ws);
            }
        }

        #endregion

        #region public methods

        public void DeleteWord()
        {
            if (_words == null || _words.Count == 0)
            {
                TraceWriter.TraceWarning("No Words to Delete");
                return;
            }

            var replacedWord = CurrentWord;
            var replacedIndex = WordIndex;

            var index = _words[replacedIndex].Index;
            var length = _words[replacedIndex].Length;

            // adjust length to remove extra white space after first word
            if (index == 0 && index + length < _text.Length && _text[index + length] == ' ')
                length++; //removing trailing space
            // adjust length to remove double white space
            else if (index > 0 && index + length < _text.Length && _text[index - 1] == ' ' && _text[index + length] == ' ')
                length++; //removing trailing space
            // adjust index to remove extra white space before punctuation
            else if (index > 0 && index + length < _text.Length && _text[index - 1] == ' ' && char.IsPunctuation(_text[index + length]))
            {
                index--;
                length++;
            }
            // adjust index to remove extra white space before last word
            else if (index > 0 && index + length == _text.Length && _text[index - 1] == ' ')
            {
                index--;
                length++;
            }

            var deletedWord = _text.ToString(index, length);
            _text.Remove(index, length);

            CalculateWords();
            OnDeletedWord(new SpellingEventArgs(deletedWord, replacedIndex, index));
        }

        public int EditDistance(string source, string target, bool positionPriority = true)
        {
            // i.e. 2-D array
            var matrix = Array.CreateInstance(typeof(int), source.Length + 1, target.Length + 1);

            // boundary conditions
            matrix.SetValue(0, 0, 0);

            for (var j = 1; j <= target.Length; j++)
            {
                // boundary conditions
                var val = (int)matrix.GetValue(0, j - 1);
                matrix.SetValue(val + 1, 0, j);
            }

            // outer loop
            for (var i = 1; i <= source.Length; i++)
            {
                // boundary conditions
                var val = (int)matrix.GetValue(i - 1, 0);
                matrix.SetValue(val + 1, i, 0);

                // inner loop
                for (var j = 1; j <= target.Length; j++)
                {
                    var diag = (int)matrix.GetValue(i - 1, j - 1);

                    if (source.Substring(i - 1, 1) != target.Substring(j - 1, 1))
                        diag++;

                    var deletion = (int)matrix.GetValue(i - 1, j);
                    var insertion = (int)matrix.GetValue(i, j - 1);
                    var match = Math.Min(deletion + 1, insertion + 1);
                    matrix.SetValue(Math.Min(diag, match), i, j);
                }//for j
            }//for i

            var dist = (int)matrix.GetValue(source.Length, target.Length);

            // extra edit on first and last chars
            if (positionPriority)
            {
                if (source[0] != target[0])
                    dist++;

                if (source[source.Length - 1] != target[target.Length - 1])
                    dist++;
            }

            return dist;
        }

        public int GetWordIndexFromTextIndex(int textIndex)
        {
            if (_words == null || _words.Count == 0 || textIndex < 1)
            {
                TraceWriter.TraceWarning("No words to get text index from.");
                return 0;
            }

            if (_words.Count == 1)
                return 0;

            var low = 0;
            var high = _words.Count - 1;

            // binary search
            while (low <= high)
            {
                var mid = (low + high) / 2;
                var wordStartIndex = _words[mid].Index;
                var wordEndIndex = _words[mid].Index + _words[mid].Length - 1;

                // add white space to end of word by finding the start of the next word
                if ((mid + 1) < _words.Count)
                    wordEndIndex = _words[mid + 1].Index - 1;

                if (textIndex < wordStartIndex)
                    high = mid - 1;
                else if (textIndex > wordEndIndex)
                    low = mid + 1;
                else if (wordStartIndex <= textIndex && textIndex <= wordEndIndex)
                    return mid;
            }

            // return last word if not found
            return _words.Count - 1;
        }

        public void IgnoreAllWord()
        {
            if (CurrentWord.Length == 0)
            {
                TraceWriter.TraceWarning("No current word");
                return;
            }

            // Add current word to ignore list
            _ignoreList.Add(CurrentWord);
            IgnoreWord();
        }

        public void IgnoreWord()
        {
            if (_words == null || _words.Count == 0 || CurrentWord.Length == 0)
            {
                TraceWriter.TraceWarning("No text or current word");
                return;
            }

            OnIgnoredWord(new SpellingEventArgs(CurrentWord, WordIndex, _words[WordIndex].Index));

            // increment Word Index to skip over this word
            _wordIndex++;
        }

        public void ReplaceAllWord()
        {
            if (CurrentWord.Length == 0)
            {
                TraceWriter.TraceWarning("No current word");
                return;
            }

            // if not in list and replacement word has length
            if (!_replaceList.ContainsKey(CurrentWord) && _replacementWord.Length > 0)
                _replaceList.Add(CurrentWord, _replacementWord);

            ReplaceWord();
        }

        public void ReplaceAllWord(string replacementWord)
        {
            ReplacementWord = replacementWord;
            ReplaceAllWord();
        }

        public void ReplaceWord()
        {
            if (_words == null || _words.Count == 0 || CurrentWord.Length == 0)
            {
                TraceWriter.TraceWarning("No text or current word");
                return;
            }

            if (_replacementWord.Length == 0)
            {
                DeleteWord();
                return;
            }

            var replacedWord = CurrentWord;
            var replacedIndex = WordIndex;

            var index = _words[replacedIndex].Index;
            var length = _words[replacedIndex].Length;

            _text.Remove(index, length);
            // if first letter upper case, match case for replacement word
            if (char.IsUpper(_words[replacedIndex].ToString(), 0))
                _replacementWord = _replacementWord.Substring(0, 1).ToUpper(CultureInfo.CurrentUICulture) + _replacementWord.Substring(1);

            _text.Insert(index, _replacementWord);
            CalculateWords();
            OnReplacedWord(new ReplaceWordEventArgs(_replacementWord, replacedWord, replacedIndex, index));
        }

        public void ReplaceWord(string replacementWord)
        {
            ReplacementWord = replacementWord;
            ReplaceWord();
        }

        public bool SpellCheck()
        {
            return SpellCheck(_wordIndex, WordCount - 1);
        }

        public bool SpellCheck(int startWordIndex)
        {
            _wordIndex = startWordIndex;
            return SpellCheck();
        }

        public bool SpellCheck(int startWordIndex, int endWordIndex)
        {
            if (startWordIndex > endWordIndex || _words == null || _words.Count == 0)
            {
                // make sure end index is not greater then word count
                OnEndOfText(EventArgs.Empty);	//raise event
                return false;
            }

            Initialize();
            var misspelledWord = false;
            for (var i = startWordIndex; i <= endWordIndex; i++)
            {
                _wordIndex = i;		// saving the current word index 
                var currentWord = CurrentWord;

                if (!CheckString(currentWord))
                    continue;

                if (!TestWord(currentWord))
                {
                    if (_replaceList.ContainsKey(currentWord))
                    {
                        ReplacementWord = _replaceList[currentWord].ToString();
                        ReplaceWord();
                    }
                    else if (!_ignoreList.Contains(currentWord))
                    {
                        misspelledWord = true;
                        OnMisspelledWord(new SpellingEventArgs(currentWord, i, _words[i].Index));		//raise event
                        break;
                    }
                }
                else if (i > 0 && _words[i - 1].Value == currentWord && (_words[i - 1].Index + _words[i - 1].Length + 1) == _words[i].Index)
                {
                    misspelledWord = true;
                    OnDoubledWord(new SpellingEventArgs(currentWord, i, _words[i].Index));		//raise event
                    break;
                }
            } // for

            if (_wordIndex >= _words.Count - 1 && !misspelledWord)
                OnEndOfText(EventArgs.Empty);	//raise event

            return misspelledWord;
        } // SpellCheck

        public bool SpellCheck(string text)
        {
            Text = text;
            return SpellCheck();
        }

        public bool SpellCheck(string text, int startWordIndex)
        {
            WordIndex = startWordIndex;
            Text = text;
            return SpellCheck();
        }

        public void Suggest(string word)
        {
            Text = word;
            if (!TestWord(word))
                Suggest();
        }

        public void Suggest()
        {
            // can't generate suggestions with out current word
            if (CurrentWord.Length == 0)
            {
                TraceWriter.TraceWarning("No current word");
                return;
            }

            Initialize();

            var tempSuggestion = new ArrayList();

            if ((_suggestionMode == SuggestionEnum.PhoneticNearMiss
                || _suggestionMode == SuggestionEnum.Phonetic)
                && _dictionary.PhoneticRules.Count > 0)
            {
                // generate phonetic code for possible root word
                var codes = new Hashtable();
                foreach (var tempCode in _dictionary.PossibleBaseWords.Cast<string>()
                                                    .Select(tempWord => _dictionary.PhoneticCode(tempWord))
                                                    .Where(tempCode => tempCode.Length > 0 && !codes.ContainsKey(tempCode)))
                    codes.Add(tempCode, tempCode);

                if (codes.Count > 0)
                {
                    // search root words for phonetic codes
                    foreach (Word word in _dictionary.BaseWords.Values)
                    {
                        if (!codes.ContainsKey(word.PhoneticCode))
                            continue;

                        var words = _dictionary.ExpandWord(word);
                        // add expanded words
                        foreach (string expandedWord in words)
                        {
                            var newWord = new Word();
                            newWord.Text = expandedWord;
                            newWord.EditDistance = EditDistance(CurrentWord, expandedWord);
                            tempSuggestion.Add(newWord);
                        }
                    }
                }

                TraceWriter.TraceVerbose("Suggestiongs Found with Phonetic Stratagy: {0}", tempSuggestion.Count);
            }

            if (_suggestionMode == SuggestionEnum.PhoneticNearMiss
                || _suggestionMode == SuggestionEnum.NearMiss)
            {
                // suggestions for a typical fault of spelling, that
                // differs with more, than 1 letter from the right form.
                ReplaceChars(ref tempSuggestion);

                // swap out each char one by one and try all the tryme
                // chars in its place to see if that makes a good word
                BadChar(ref tempSuggestion);

                // try omitting one char of word at a time
                ExtraChar(ref tempSuggestion);

                // try inserting a tryme character before every letter
                ForgotChar(ref tempSuggestion);

                // split the string into two pieces after every char
                // if both pieces are good words make them a suggestion
                TwoWords(ref tempSuggestion);

                // try swapping adjacent chars one by one
                SwapChar(ref tempSuggestion);
            }

            TraceWriter.TraceVerbose("Total Suggestiongs Found: {0}", tempSuggestion.Count);

            tempSuggestion.Sort();  // sorts by edit score
            _suggestions.Clear();

            foreach (var word in from object t in tempSuggestion select ((Word)t).Text)
            {
                // looking for duplicates
                if (!_suggestions.Contains(word))
                    _suggestions.Add(word);

                if (_suggestions.Count >= _maxSuggestions && _maxSuggestions > 0)
                    break;
            }

        } // suggest

        public bool TestWord(string word)
        {
            Initialize();
            TraceWriter.TraceVerbose("Testing Word: {0}", word);
            return Dictionary.Contains(word) || Dictionary.Contains(word.ToLower());
        }

        #endregion

        #region public properties

        private bool _alertComplete = true;
        private WordDictionary _dictionary;
        private bool _ignoreAllCapsWords = true;
        private bool _ignoreHtml = true;
        private readonly ArrayList _ignoreList = new ArrayList();
        private bool _ignoreWordsWithDigits;
        private int _maxSuggestions = 25;
        private readonly Hashtable _replaceList = new Hashtable();
        private string _replacementWord = "";
        private bool _showDialog = true;
        private FSuggestion _suggestionForm;
        private SuggestionEnum _suggestionMode = SuggestionEnum.PhoneticNearMiss;
        private readonly ArrayList _suggestions = new ArrayList();
        private StringBuilder _text = new StringBuilder();
        private int _wordIndex;

        public enum SuggestionEnum
        {
            PhoneticNearMiss,
            Phonetic,
            NearMiss
        }

        [Browsable(true)]
        [DefaultValue(true)]
        [CategoryAttribute("Options")]
        [Description("Display the 'Spell Check Complete' alert.")]
        public bool AlertComplete
        {
            get { return _alertComplete; }
            set { _alertComplete = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string CurrentWord
        {
            get { return _words == null || _words.Count == 0 ? string.Empty : _words[WordIndex].Value; }
        }

        [Browsable(true)]
        [CategoryAttribute("Dictionary")]
        [Description("The WordDictionary object to use when spell checking")]
        public WordDictionary Dictionary
        {
            get
            {
                if (!DesignMode && _dictionary == null)
                    _dictionary = new WordDictionary();

                return _dictionary;
            }
        }

        [DefaultValue(true)]
        [CategoryAttribute("Options")]
        [Description("Ignore words with all capital letters when spell checking")]
        public bool IgnoreAllCapsWords
        {
            get { return _ignoreAllCapsWords; }
            set { _ignoreAllCapsWords = value; }
        }

        [DefaultValue(true)]
        [CategoryAttribute("Options")]
        [Description("Ignore html tags when spell checking")]
        public bool IgnoreHtml
        {
            get { return _ignoreHtml; }
            set { _ignoreHtml = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ArrayList IgnoreList
        {
            get { return _ignoreList; }
        }

        [DefaultValue(false)]
        [CategoryAttribute("Options")]
        [Description("Ignore words with digits when spell checking")]
        public bool IgnoreWordsWithDigits
        {
            get { return _ignoreWordsWithDigits; }
            set { _ignoreWordsWithDigits = value; }
        }

        [DefaultValue(25)]
        [CategoryAttribute("Options")]
        [Description("The maximum number of suggestions to generate")]
        public int MaxSuggestions
        {
            get { return _maxSuggestions; }
            set { _maxSuggestions = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Hashtable ReplaceList
        {
            get { return _replaceList; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ReplacementWord
        {
            get { return _replacementWord; }
            set { _replacementWord = value.Trim(); }
        }

        [DefaultValue(true)]
        [CategoryAttribute("Options")]
        [Description("Determines if the spell checker should use its internal dialogs")]
        public bool ShowDialog
        {
            get { return _showDialog; }
            set
            {
                _showDialog = value;
                if (_showDialog && _suggestionForm != null)
                    _suggestionForm.AttachEvents();
                else if (_suggestionForm != null)
                    _suggestionForm.DetachEvents();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public FSuggestion SuggestionForm
        {
            get { return _suggestionForm ?? (_suggestionForm = new FSuggestion(this)); }
        }

        [DefaultValue(SuggestionEnum.PhoneticNearMiss)]
        [CategoryAttribute("Options")]
        [Description("The suggestion strategy to use when generating suggestions")]
        public SuggestionEnum SuggestionMode
        {
            get { return _suggestionMode; }
            set { _suggestionMode = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ArrayList Suggestions
        {
            get { return _suggestions; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Text
        {
            get { return _text.ToString(); }
            set
            {
                _text = new StringBuilder(value);
                CalculateWords();
                Reset();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int TextIndex
        {
            get { return _words == null || _words.Count == 0 ? 0 : _words[WordIndex].Index; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int WordCount
        {
            get { return _words == null ? 0 : _words.Count; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int WordIndex
        {
            get { return _words == null ? 0 : Math.Max(0, Math.Min(_wordIndex, (WordCount - 1))); }
            set { _wordIndex = value; }
        }

        #endregion

        #region Component Designer generated code

        private void InitializeComponent()
        {
            _components = new System.ComponentModel.Container();
        }

        #endregion
    }
}
