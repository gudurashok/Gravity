using System.Collections;

namespace Scalable.SpellChecker.Dictionary.Affix
{
    public class AffixRuleEnumerator : IDictionaryEnumerator
    {
        private readonly IDictionaryEnumerator _innerEnumerator;

        internal AffixRuleEnumerator(AffixRuleCollection enumerable)
        {
            _innerEnumerator = enumerable.InnerHash.GetEnumerator();
        }

        #region Implementation of IDictionaryEnumerator

        public string Key
        {
            get { return (string)_innerEnumerator.Key; }
        }

        object IDictionaryEnumerator.Key
        {
            get { return Key; }
        }

        public AffixRule Value
        {
            get { return (AffixRule)_innerEnumerator.Value; }
        }

        object IDictionaryEnumerator.Value
        {
            get { return Value; }
        }

        public DictionaryEntry Entry
        {
            get { return _innerEnumerator.Entry; }
        }

        #endregion

        #region Implementation of IEnumerator

        public void Reset()
        {
            _innerEnumerator.Reset();
        }

        public bool MoveNext()
        {
            return _innerEnumerator.MoveNext();
        }

        public object Current
        {
            get { return _innerEnumerator.Current; }
        }

        #endregion
    }
}
