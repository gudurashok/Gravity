using System;
using System.Collections;

namespace Scalable.SpellChecker.Dictionary.Affix
{
    [Serializable()]
    public class AffixEntryCollection : CollectionBase
    {
        public AffixEntryCollection()
        {
        }

        public AffixEntryCollection(AffixEntryCollection value)
        {
            AddRange(value);
        }

        public AffixEntryCollection(AffixEntry[] value)
        {
            AddRange(value);
        }

        public AffixEntry this[int index]
        {
            get { return ((AffixEntry)(List[index])); }
        }

        public int Add(AffixEntry value)
        {
            return List.Add(value);
        }

        public void AddRange(AffixEntry[] value)
        {
            for (var counter = 0; (counter < value.Length); counter = (counter + 1))
                Add(value[counter]);
        }

        public void AddRange(AffixEntryCollection value)
        {
            for (var counter = 0; (counter < value.Count); counter = (counter + 1))
                Add(value[counter]);
        }

        public bool Contains(AffixEntry value)
        {
            return List.Contains(value);
        }

        public void CopyTo(AffixEntry[] array, int index)
        {
            List.CopyTo(array, index);
        }

        public int IndexOf(AffixEntry value)
        {
            return List.IndexOf(value);
        }

        public void Insert(int index, AffixEntry value)
        {
            List.Insert(index, value);
        }

        public new AffixEntryEnumerator GetEnumerator()
        {
            return new AffixEntryEnumerator(this);
        }

        public void Remove(AffixEntry value)
        {
            List.Remove(value);
        }
    }

}
