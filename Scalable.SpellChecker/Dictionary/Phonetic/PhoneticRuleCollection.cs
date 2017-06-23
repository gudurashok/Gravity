using System;
using System.Collections;

namespace Scalable.SpellChecker.Dictionary.Phonetic
{
    [Serializable]
    public class PhoneticRuleCollection : CollectionBase
    {
        public PhoneticRuleCollection()
        {
        }

        public PhoneticRuleCollection(PhoneticRuleCollection value)
        {
            AddRange(value);
        }

        public PhoneticRuleCollection(PhoneticRule[] value)
        {
            AddRange(value);
        }

        public PhoneticRule this[int index]
        {
            get { return ((PhoneticRule)(List[index])); }
        }

        public int Add(PhoneticRule value)
        {
            return List.Add(value);
        }

        public void AddRange(PhoneticRule[] value)
        {
            for (var counter = 0; (counter < value.Length); counter = (counter + 1))
                Add(value[counter]);
        }

        public void AddRange(PhoneticRuleCollection value)
        {
            for (var counter = 0; (counter < value.Count); counter = (counter + 1))
                Add(value[counter]);
        }

        public bool Contains(PhoneticRule value)
        {
            return List.Contains(value);
        }

        public void CopyTo(PhoneticRule[] array, int index)
        {
            List.CopyTo(array, index);
        }

        public int IndexOf(PhoneticRule value)
        {
            return List.IndexOf(value);
        }

        public void Insert(int index, PhoneticRule value)
        {
            List.Insert(index, value);
        }

        public new PhoneticRuleEnumerator GetEnumerator()
        {
            return new PhoneticRuleEnumerator(this);
        }

        public void Remove(PhoneticRule value)
        {
            List.Remove(value);
        }
    }
}
