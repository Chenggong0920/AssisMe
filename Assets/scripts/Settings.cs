using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public static Settings Instance;

    [SerializeField]
    private SerializableDictionary<OptionType, GameObject> optionPrefabs;

    [SerializeField]
    private SerializableDictionary<AvatarType, AvatarInfo> avatarInfos;

    public SerializableDictionary<AvatarType, AvatarInfo> AvatarInfos
    {
        get => avatarInfos;
    }

    [SerializeField]
    private SerializableDictionary<UserInfoType, CharacterOption[]> characterOptions;

    [SerializeField]
    private AvatarDescription avatarDescription_Button_Prefab;
    public AvatarDescription AvatarDescription_Button_Prefab
    {
        get => avatarDescription_Button_Prefab;
    }
    
    [SerializeField]
    private AvatarDescription avatarDescription_Toggle_Prefab;
    public AvatarDescription AvatarDescription_Toggle_Prefab
    {
        get => avatarDescription_Toggle_Prefab;
    }

    public GameObject GetOptionPrefab(OptionType optionType)
    {
        if (optionPrefabs.ContainsKey(optionType))
            return optionPrefabs.Get(optionType);

        return null;
    }

    public AvatarInfo? GetAvatarInfo(AvatarType type)
    {
        if (avatarInfos.ContainsKey(type))
            return avatarInfos.Get(type);

        return null;
    }

    public Sprite GetAvatarLoginImage(AvatarType type)
    {
        var avatarInfo = GetAvatarInfo(type);
        if (avatarInfo != null)
        {
            return avatarInfo?.loggedInImage;
        }

        return null;
    }

    public CharacterOption[] GetCharacterOptions(UserInfoType userInfoType)
    {
        if (characterOptions.ContainsKey(userInfoType))
            return characterOptions.Get(userInfoType);

        return null;
    }

    private void Awake() {
        Instance = this;
    }
}
