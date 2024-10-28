using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UpdateUserInfo : MonoBehaviour
{
    [SerializeField]
    private InputField nickName;
    // [SerializeField]
    // private Text gender;
    // [SerializeField]
    // private Text age;
    // [SerializeField]
    // private Text occupation;
    // [SerializeField]
    // private Text major;
    // [SerializeField]
    // private Text future;
    // [SerializeField]
    // private Text health;
    // [SerializeField]
    // private Text hobby;
    // [SerializeField]
    // private Text help;

    private UserInfo userInfo;

    private CharacterOptionsUpdateButton[] optionButtons;


    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    private void Init()
    {
        if (PlayerInfoManager.Instance == null)
            return;

        userInfo = PlayerInfoManager.Instance.UserInfo;
        
        nickName.text = userInfo.Nickname;
        // age.text = userInfo.Age;
        // occupation.text = userInfo.Occupation;
        // major.text = userInfo.Major;
        // future.text = userInfo.Future;
        // hobby.text = userInfo.Hobby;

        optionButtons = GetComponentsInChildren<CharacterOptionsUpdateButton>();

        foreach(var optionButton in optionButtons)
        {
            optionButton.Init(userInfo.GetValue(optionButton.Type));
        }
        // gender.text = userInfo.Gender;
        // help.text = userInfo.Help;
    }

    private void OnDisable() {
        OnEditFinished();
    }

    public void OnEditFinished()
    {
        if (PlayerInfoManager.Instance == null)
            return;

        userInfo.Nickname = nickName.text;
        // userInfo.Age = age.text;
        // userInfo.Occupation = occupation.text;
        // userInfo.Major = major.text;
        // userInfo.Future = future.text;
        // userInfo.Hobby = hobby.text;

        foreach(var optionButton in optionButtons)
        {
            userInfo.SetValue(optionButton.Type, optionButton.Value);
        }

        // userInfo.Gender = gender.text;
        // userInfo.Help = help.text;

        PlayerInfoManager.Instance.UpdatePlayerInfo(userInfo);
    }
}
