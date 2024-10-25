using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateAvatar : MonoBehaviour
{
    [SerializeField]
    private InputField avatarName;

    private AvatarType avatarType;

    [SerializeField]
    private AvatarDescriptionsUI pickAvatarComponent;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    private void Init()
    {
        if (PlayerInfoManager.Instance == null)
            return;

        avatarName.text = PlayerInfoManager.Instance.AvatarName;
        avatarType = PlayerInfoManager.Instance.AvatarType;
    }

    public void OnAvatarSelected(AvatarType selectedAvatarType)
    {
        avatarType = selectedAvatarType;
    }

    private void OnDisable() {
        OnEditFinished();
    }

    public void OnEditFinished()
    {
        if (PlayerInfoManager.Instance == null)
            return;

        PlayerInfoManager.Instance.UpdateAvatarInfo(avatarType);
        PlayerInfoManager.Instance.UpdateAvatarInfo(avatarName.text);
    }
}
