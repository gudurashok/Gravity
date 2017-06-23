using System;

namespace Scalable.SpellChecker
{
    public class SpellingEventArgs : EventArgs
    {
        private readonly int _textIndex;
        private readonly string _word;
        private readonly int _wordIndex;

        public SpellingEventArgs(string word, int wordIndex, int textIndex)
        {
            _word = word;
            _wordIndex = wordIndex;
            _textIndex = textIndex;
        }

        public int TextIndex
        {
            get { return _textIndex; }
        }

        public string Word
        {
            get { return _word; }
        }

        public int WordIndex
        {
            get { return _wordIndex; }
        }

    }
}
