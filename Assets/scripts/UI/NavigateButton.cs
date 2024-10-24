using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NavigateButton : MonoBehaviour
{
    [SerializeField]
    private Screen targetScreen;

    Button buttonComponent;

    private void Awake()
    {
        buttonComponent = GetComponent<Button>();
        
        if (buttonComponent)
            buttonComponent.onClick.AddListener(OnClicked);
    }

    private void OnDestroy() {
        if (buttonComponent)
            buttonComponent.onClick.RemoveAllListeners();
    }

    private void OnClicked()
    {
        if (UIManager.Instance)
            UIManager.Instance.OnNavigateButtonClicked(targetScreen);
    }
}
