using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class AvatarIcon : MonoBehaviour
{
    [SerializeField]
    private bool isChatIcon = false;

    // Start is called before the first frame update
    void Start()
    {
        var imageComponent = GetComponent<Image>();
        imageComponent.sprite = PlayerInfoManager.Instance.GetAvatarIcon(isChatIcon);
    }
}
