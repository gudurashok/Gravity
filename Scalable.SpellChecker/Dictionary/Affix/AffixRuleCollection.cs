using System;
using System.Collections;

namespace Scalable.SpellChecker.Dictionary.Affix
{
    public class AffixRuleCollection : IDictionary, ICloneable
    {
        #region "Constructors"

        public AffixRuleCollection()
        {
            InnerHash = new Hashtable();
        }

        public AffixRuleCollection(AffixRuleCollection original)
        {
            InnerHash = new Hashtable(original.InnerHash);
        }

        public AffixRuleCollection(IDictionary dictionary)
        {
            InnerHash = new Hashtable(dictionary);
        }

        public AffixRuleCollection(int capacity)
        {
            InnerHash = new Hashtable(capacity);
        }

        public AffixRuleCollection(IDictionary dictionary, float loadFactor)
        {
            InnerHash = new Hashtable(dictionary, loadFactor);
        }

        public AffixRuleCollection(IEqualityComparer equalityComparer)
        {
            InnerHash = new Hashtable(equalityComparer);
        }

        public AffixRuleCollection(int capacity, int loadFactor)
        {
            InnerHash = new Hashtable(capacity, loadFactor);
        }

        public AffixRuleCollection(IDictionary dictionary, IEqualityComparer equalityComparer)
        {
            InnerHash = new Hashtable(dictionary, equalityComparer);
        }

        public AffixRuleCollection(int capacity, IEqualityComparer equalityComparer)
        {
            InnerHash = new Hashtable(capacity, equalityComparer);
        }

        public AffixRuleCollection(IDictionary dictionary, float loadFactor, IEqualityComparer equalityComparer)
        {
            InnerHash = new Hashtable(dictionary, loadFactor, equalityComparer);
        }

        public AffixRuleCollection(int capacity, float loadFactor, IEqualityComparer equalityComparer)
        {
            InnerHash = new Hashtable(capacity, loadFactor, equalityComparer);
        }

        #endregion

        #region Implementation of IDictionary

        public AffixRuleEnumerator GetEnumerator()
        {
            return new AffixRuleEnumerator(this);
        }

        IDictionaryEnumerator IDictionary.GetEnumerator()
        {
            return new AffixRuleEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Remove(string key)
        {
            InnerHash.Remove(key);
        }

        void IDictionary.Remove(object key)
        {
            Remove((string)key);
        }

        public bool Contains(string key)
        {
            return InnerHash.Contains(key);
        }

        bool IDictionary.Contains(object key)
        {
            return Contains((string)key);
        }

        public void Clear()
        {
            InnerHash.Clear();
        }

        public void Add(string key, AffixRule value)
        {
            InnerHash.Add(key, value);
        }

        void IDictionary.Add(object key, object value)
        {
            Add((string)key, (AffixRule)value);
        }

        public bool IsReadOnly
        {
            get { return InnerHash.IsReadOnly; }
        }

        public AffixRule this[string key]
        {
            get { return (AffixRule)InnerHash[key]; }
            private set { InnerHash[key] = value; }
        }

        object IDictionary.this[object key]
        {
            get { return this[(string)key]; }
            set { this[(string)key] = (AffixRule)value; }
        }

        public ICollection Values
        {
            get { return InnerHash.Values; }
        }

        public ICollection Keys
        {
            get { return InnerHash.Keys; }
        }

        public bool IsFixedSize
        {
            get { return InnerHash.IsFixedSize; }
        }

        #endregion

        #region Implementation of ICollection

        public void CopyTo(Array array, int index)
        {
            InnerHash.CopyTo(array, index);
        }

        public bool IsSynchronized
        {
            get { return InnerHash.IsSynchronized; }
        }

        public int Count
        {
            get { return InnerHash.Count; }
        }

        public object SyncRoot
        {
            get { return InnerHash.SyncRoot; }
        }

        #endregion

        #region Implementation of ICloneable

        public AffixRuleCollection Clone()
        {
            var clone = new AffixRuleCollection();
            clone.InnerHash = (Hashtable)InnerHash.Clone();
            return clone;
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        #endregion

        #region "HashTable Methods"

        public bool ContainsKey(string key)
        {
            return InnerHash.ContainsKey(key);
        }

        public bool ContainsValue(AffixRule value)
        {
            return InnerHash.ContainsValue(value);
        }

        public static AffixRuleCollection Synchronized(AffixRuleCollection nonSync)
        {
            var sync = new AffixRuleCollection();
            sync.InnerHash = Hashtable.Synchronized(nonSync.InnerHash);
            return sync;
        }

        #endregion

        internal Hashtable InnerHash { get; private set; }
    }
}
