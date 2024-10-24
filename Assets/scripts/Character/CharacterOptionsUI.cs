using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Reflection.Emit;
using System.Linq;

public class CharacterOptionsUI : MonoBehaviour
{
    // [SerializeField]
    // private GameObject optionPrefab;

    // [SerializeField]
    // private GameObject nextScreen;

    // [SerializeField]
    // private CharacterOptions[] characterOptions;

    [SerializeField]
    private Transform optionsParent;


    [SerializeField]
    private bool OptionsForNext = false;

    [SerializeField]
    private UserInfoType userInfoType;

    [SerializeField]
    private bool startWithNumber = false;
    [SerializeField]
    private bool lastOption = false;

    private UINavigate navigateComponent;

    private List<CharacterOptionsButton> optionButtons = new List<CharacterOptionsButton>();

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    private void Init()
    {
        navigateComponent = GetComponent<UINavigate>();

        var characterOptions = Settings.Instance.GetCharacterOptions(userInfoType);
        if (characterOptions == null || characterOptions.Length == 0)
            return;

        foreach( var option in characterOptions)
        {
            var optionPrefab = Settings.Instance.GetOptionPrefab(option.type);
            if (optionPrefab == null)
            {
                Debug.LogErrorFormat("Option Prefab Not Found: {0} {1}", option.type, option.value);
                continue;
            }

            GameObject optionGO = Instantiate(optionPrefab, optionsParent);
            var optionButton = optionGO.AddComponent<CharacterOptionsButton>();
            optionButton.Init(option.value, startWithNumber);

            optionButtons.Add(optionButton);

            if (OptionsForNext)
            {
                Button btnComponent = optionGO.GetComponent<Button>();
                if (btnComponent)
                {
                    btnComponent.onClick.AddListener(() => 
                    {
                        onUserOptionSelected(option.value);
                    });
                }
            }
        }
    }

    private void onUserOptionSelected(string optionValue)
    {
        Debug.LogFormat("Option: {0} selected for {1}", optionValue, userInfoType);

        PlayerInfoManager.Instance.UpdatePlayerInfo(userInfoType, optionValue, lastOption);

        if (navigateComponent)
            navigateComponent.OnNext();
    }

    public void onNext()
    {
        List<string> selectedOptions = new List<string>();
        foreach (var optionButton in optionButtons)
        {
            if (optionButton.IsSelectedToggle())
            {
                selectedOptions.Add(optionButton.Value);
            }
        }

        var result = string.Join("・", selectedOptions);
        onUserOptionSelected(result);
    }
}
