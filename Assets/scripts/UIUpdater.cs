using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Reflection.Emit;

public class UIUpdater : MonoBehaviour
{
    [SerializeField]
    private GameObject optionPrefab;

    [SerializeField]
    private GameObject nextScreen;

    [SerializeField]
    private CharacterOption[] characterOptions;

    [SerializeField]
    private bool OptionsForNext = false;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Init()
    {
        if (characterOptions == null || characterOptions.Length == 0 || optionPrefab == null)
            return;
            
        foreach(CharacterOption characterOption in characterOptions)
        {
            if (characterOption.options == null || characterOption.options.Length == 0 || characterOption.optionsParent == null)
                continue;

            foreach(String option in characterOption.options)
            {
                GameObject optionGO = Instantiate(optionPrefab, characterOption.optionsParent);
                TextMeshProUGUI text = optionGO.GetComponentInChildren<TextMeshProUGUI>();
                if (text) {
                    text.text = option;
                }
                // else
                {
                    Text label = optionGO.GetComponentInChildren<Text>();
                    if (label)
                        label.text = option;
                }

                if (OptionsForNext)
                {
                    Button btnComponent = optionGO.GetComponent<Button>();
                    if (btnComponent)
                        btnComponent.onClick.AddListener(onNext);
                }
            }
        }
    }

    public void onNext()
    {
        if( !nextScreen)
            return;

        gameObject.SetActive(false);
        nextScreen.SetActive(true);
    }
}
