using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfoManager : MonoBehaviour
{
    public static PlayerInfoManager Instance;
    
    [SerializeField]
    string userId;
    
    [SerializeField]
    UserInfo userInfo;
    public UserInfo UserInfo
    {
        get => userInfo;
    }

    [SerializeField]
    AvatarType avatarType;
    public AvatarType AvatarType
    {
        get => avatarType;
    }

    [SerializeField]
    string avatarName;
    public string AvatarName
    {
        get => avatarName;
    }

    private void Awake() {
        Instance = this;
    }

    private void Start() {
        LoadPlayerInfo();
    }

    public void UpdatePlayerInfo(UserInfo updatedUserInfo)
    {
        if (userInfo.Equals(updatedUserInfo))
        {
            Debug.Log("UpdatePlayerInfo -- no difference found -- ignoring");
            return;
        }

        userInfo = updatedUserInfo;
        SavePlayerInfo();
    }

    public void UpdatePlayerInfo(UserInfoType type, string value, bool shouldSave)
    {
        switch(type)
        {
            case UserInfoType.Gender:
                userInfo.Gender = value;
                break;
            case UserInfoType.Age:
                userInfo.Age = value;
                break;
            case UserInfoType.Occupation:
                userInfo.Occupation = value;
                break;
            case UserInfoType.Major:
                userInfo.Major = value;
                break;
            case UserInfoType.Future:
                userInfo.Future = value;
                break;
            case UserInfoType.Health:
                userInfo.Health = value;
                break;
            case UserInfoType.Hobby:
                userInfo.Hobby = value;
                break;
            case UserInfoType.Help:
                userInfo.Help = value;
                break;
        }

        if (shouldSave)
            SavePlayerInfo();
    }

    public void UpdateAvatarInfo(AvatarType updatedAvatarType, bool shouldSave = true)
    {
        if (avatarType == updatedAvatarType)
        {
            Debug.Log("UpdateAvatarInfo -- no difference found -- ignoring");
            return;
        }

        avatarType = updatedAvatarType;
        
        if (shouldSave)
            SavePlayerInfo();
    }

    public void UpdateAvatarInfo(string updatedAvatarName, bool shouldSave = true)
    {
        if (avatarName == updatedAvatarName)
        {
            Debug.Log("UpdateAvatarInfo -- no difference found -- ignoring");
            return;
        }

        avatarName = updatedAvatarName;

        if (shouldSave)
            SavePlayerInfo();
    }


    private void SavePlayerInfo()
    {
        PlayerPrefs.SetString("UserId", userId);

        string json = JsonUtility.ToJson(userInfo);
        PlayerPrefs.SetString("UserInfo", json);

        PlayerPrefs.SetInt("AvatarType", (int)avatarType);
        PlayerPrefs.SetString("AvatarName", avatarName);

        PlayerPrefs.Save(); // Save changes

        Debug.Log("Saved PlayerInfo");
    }

    private void LoadPlayerInfo()
    {
        userId = PlayerPrefs.GetString("UserId", "");

        if (PlayerPrefs.HasKey("UserInfo"))
        {
            string json = PlayerPrefs.GetString("UserInfo");
            userInfo = JsonUtility.FromJson<UserInfo>(json);
        }

        avatarType = (AvatarType)PlayerPrefs.GetInt("AvatarType", 0);
        avatarName = PlayerPrefs.GetString("AvatarName", "");

        Debug.Log("Loaded PlayerInfo");
    }

    public Sprite GetAvatarLoginImage()
    {
        var avatarInfo = Settings.Instance.GetAvatarInfo(AvatarType);
        if (avatarInfo != null)
        {
            return avatarInfo?.loggedInImage;
        }

        return null;
    }

    public Sprite GetAvatarIcon(bool isChatIcon)
    {
        var avatarInfo = Settings.Instance.GetAvatarInfo(AvatarType);
        if (avatarInfo != null)
        {
            return isChatIcon? avatarInfo?.chatIcon: avatarInfo?.icon;
        }

        return null;
    }

    public bool IsSetupCompleted()
    {
        return !userInfo.isEmpty();
    }
}
