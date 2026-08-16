using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code
{
    [Serializable]
    public class SerializedDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
    {
        [SerializeField] private List<SerializedDictionaryElement<TKey, TValue>> elements = new();
        
        public void OnBeforeSerialize()
        {
            elements.Clear();
            foreach (var pair in this)
            {
                elements.Add(new SerializedDictionaryElement<TKey, TValue>(pair.Key, pair.Value));
            }
        }

        public void OnAfterDeserialize()
        {
            Clear();
            foreach (var pair in this)
            {
                this[pair.Key] = pair.Value;
            }
        }
    }
}