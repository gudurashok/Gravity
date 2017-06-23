namespace Scalable.SpellChecker
{
    public class ReplaceWordEventArgs : SpellingEventArgs
    {
        private readonly string _ReplacementWord;

        public ReplaceWordEventArgs(string replacementWord, string word, int wordIndex, int textIndex)
            : base(word, wordIndex, textIndex)
        {
            _ReplacementWord = replacementWord;
        }

        public string ReplacementWord
        {
            get { return _ReplacementWord; }
        }
    }
}
