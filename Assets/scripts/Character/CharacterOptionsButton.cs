using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterOptionsButton : MonoBehaviour
{
    protected string value;
    public string Value
    {
        get => value;
    }

    public void Init(string value, bool startWithNumber = false)
    {
        this.value = value;

        if (startWithNumber)
            value = string.Format("{0}.{1}", transform.GetSiblingIndex() + 1, value);

        TextMeshProUGUI text = GetComponentInChildren<TextMeshProUGUI>();
        if (text) {
            text.text = value;
        }

        Text label = GetComponentInChildren<Text>();
        if (label)
            label.text = value;
    }

    public bool IsSelectedToggle()
    {
        var toggleComponent = GetComponent<Toggle>();
        return toggleComponent && toggleComponent.isOn;
    }
}
