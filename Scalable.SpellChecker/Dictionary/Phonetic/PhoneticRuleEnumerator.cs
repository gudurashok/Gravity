using System.Collections;

namespace Scalable.SpellChecker.Dictionary.Phonetic
{
    public class PhoneticRuleEnumerator : object, IEnumerator
    {
        private readonly IEnumerator _base;
        private readonly IEnumerable _local;

        public PhoneticRuleEnumerator(IEnumerable mappings)
        {
            _local = mappings;
            _base = _local.GetEnumerator();
        }

        public PhoneticRule Current
        {
            get { return ((PhoneticRule)(_base.Current)); }
        }

        object IEnumerator.Current
        {
            get { return _base.Current; }
        }

        public bool MoveNext()
        {
            return _base.MoveNext();
        }

        bool IEnumerator.MoveNext()
        {
            return _base.MoveNext();
        }

        public void Reset()
        {
            _base.Reset();
        }

        void IEnumerator.Reset()
        {
            _base.Reset();
        }
    }
}
