using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class AvatarLoginBackground : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var imageComponent = GetComponent<Image>();
        imageComponent.sprite = PlayerInfoManager.Instance.GetAvatarLoginImage();
    }
}
