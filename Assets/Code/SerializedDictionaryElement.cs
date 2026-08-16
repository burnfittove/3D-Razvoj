using System;
using UnityEngine;

namespace Code
{
    [Serializable]
    public class SerializedDictionaryElement<TKey, TValue>
    {
        public SerializedDictionaryElement(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }

        [SerializeField] public TKey Key;
        [SerializeField] public TValue Value;
    }
}