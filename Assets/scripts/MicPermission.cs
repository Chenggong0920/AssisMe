using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MicPermission : MonoBehaviour
{
    [SerializeField]
    private Button AllowButton;

    [SerializeField]
    private Button DeclineButton;

    private UINavigate navigateComponent;
    // Start is called before the first frame update
    void Start()
    {
        AllowButton.onClick.AddListener(OnPermissionGranted);
        DeclineButton.onClick.AddListener(OnPermissionDeclined);

        navigateComponent = GetComponent<UINavigate>();
    }

    private void OnPermissionGranted()
    {
        navigateComponent.OnNext();
    }

    private void OnPermissionDeclined()
    {
        navigateComponent.OnNext();
    }
}
