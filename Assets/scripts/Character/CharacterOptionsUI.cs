using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Reflection.Emit;

public class CharacterOptionsUI : MonoBehaviour
{
    // [SerializeField]
    // private GameObject optionPrefab;

    // [SerializeField]
    // private GameObject nextScreen;

    [SerializeField]
    private CharacterOptions[] characterOptions;

    [SerializeField]
    private bool OptionsForNext = false;

    private UINavigate navigateComponent;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    private void Init()
    {
        navigateComponent = GetComponent<UINavigate>();

        if (characterOptions == null || characterOptions.Length == 0/* || optionPrefab == null*/)
            return;
            
        foreach(var characterOption in characterOptions)
        {
            if (characterOption.options == null || characterOption.options.Length == 0 || characterOption.optionsParent == null)
                continue;

            foreach(var option in characterOption.options)
            {
                var optionPrefab = UIManager.Instance.GetOptionPrefab(option.type);
                if (optionPrefab == null)
                {
                    Debug.LogErrorFormat("Option Prefab Not Found: {0} {1}", option.type, option.value);
                    continue;
                }

                GameObject optionGO = Instantiate(optionPrefab, characterOption.optionsParent);
                TextMeshProUGUI text = optionGO.GetComponentInChildren<TextMeshProUGUI>();
                if (text) {
                    text.text = option.value;
                }
                // else
                {
                    Text label = optionGO.GetComponentInChildren<Text>();
                    if (label)
                        label.text = option.value;
                }

                if (OptionsForNext)
                {
                    Button btnComponent = optionGO.GetComponent<Button>();
                    if (btnComponent)
                        btnComponent.onClick.AddListener(navigateComponent.OnNext);
                }
            }
        }
    }

    // public void onNext()
    // {
    //     if( !nextScreen)
    //         return;

    //     gameObject.SetActive(false);
    //     nextScreen.SetActive(true);
    // }
}
