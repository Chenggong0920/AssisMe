using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SerializableDictionary<TKey, TValue>
{
    [SerializeField]
    private List<SerializableKeyValuePair<TKey, TValue>> keyValuePairs = new List<SerializableKeyValuePair<TKey, TValue>>();

    public void Add(TKey key, TValue value)
    {
        keyValuePairs.Add(new SerializableKeyValuePair<TKey, TValue>(key, value));
    }

    public TValue Get(TKey key)
    {
        foreach (var pair in keyValuePairs)
        {
            if (EqualityComparer<TKey>.Default.Equals(pair.Key, key))
            {
                return pair.Value;
            }
        }
        return default; // or throw an exception, or handle as needed
    }

    public bool ContainsKey(TKey key)
    {
        foreach (var pair in keyValuePairs)
        {
            if (EqualityComparer<TKey>.Default.Equals(pair.Key, key))
            {
                return true;
            }
        }
        return false;
    }

    public List<SerializableKeyValuePair<TKey, TValue>> KeyValuePairs => keyValuePairs;
}
