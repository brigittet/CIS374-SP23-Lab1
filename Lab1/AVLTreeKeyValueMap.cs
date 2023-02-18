using System.Collections.Generic;
using DSA.DataStructures.Trees;
namespace Lab1
{
    //TODO
    public class AVLTreeKeyValueMap<TKey, TValue> : IKeyValueMap<TKey, TValue>
    {
        //public AVLTreeKeyValueMap()
        //{
        //}
        private AVLTreeMap<TKey, TValue> avlTreeMap = new AVLTreeMap<TKey, TValue>();

        public int Height => avlTreeMap.Height;

        public int Count => avlTreeMap.Count;

        public void Add(TKey key, TValue value)
        {
            avlTreeMap.Add(key, value);
        }

        public void Clear()
        {
            avlTreeMap.Clear();
        }

        public KeyValuePair<TKey, TValue> Get(TKey key)
        {
            TValue value;
            avlTreeMap.TryGetValue(key, out value);
            return new KeyValuePair<TKey, TValue>(key, value);
        }

        public bool Remove(TKey key)
        {
            if (avlTreeMap.ContainsKey(key))
            {
                avlTreeMap.Remove(key);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}