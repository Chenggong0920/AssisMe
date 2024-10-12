using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField]
    private SerializableDictionary<OptionType, GameObject> optionPrefabs;

    // public SerializableDictionary<OptionType, GameObject> OptionPrefabs
    // {
    //     get => optionPrefabs;
    // }

    private void Awake() {
        Instance = this;
    }

    public GameObject GetOptionPrefab(OptionType optionType)
    {
        if (optionPrefabs.ContainsKey(optionType))
            return optionPrefabs.Get(optionType);

        return null;
    }
}
