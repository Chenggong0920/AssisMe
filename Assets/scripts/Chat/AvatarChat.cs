using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class AvatarChat : MonoBehaviour
{
    [SerializeField]
    private Image icon;

    [SerializeField]
    private Text text;

    public void Init(string text, AvatarType avatarType = AvatarType.Standard1)
    {
        
    }
}
