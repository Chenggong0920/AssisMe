using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarSetupUI : MonoBehaviour
{
    public void OnAvatarPicked(AvatarType avatarType)
    {
        PlayerInfoManager.Instance.UpdateAvatarInfo(avatarType);
    }

    public void onAvatarNamedEvent(string avatarName)
    {
        PlayerInfoManager.Instance.UpdateAvatarInfo(avatarName);
    }
}
