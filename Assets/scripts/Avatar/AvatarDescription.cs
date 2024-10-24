using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AvatarDescription : MonoBehaviour
{
    [SerializeField]
    private Image avatarIcon;

    [SerializeField]
    private Text avatarName;

    [SerializeField]
    private Text avatarDescription;

    [SerializeField]
    private GameObject comingSoon;

    // private AudioClip avatarVoice;
    private AvatarType avatarType;

    public delegate void AvatarPicked(AvatarType avatarType);
    public event AvatarPicked OnAvatarPicked;

    public delegate void SoundClicked(AvatarType avatarType);
    public event SoundClicked OnSoundClicked;

    [SerializeField]
    private Button soundButton;

    private void Start() {
        
    }

    public void Initialize(AvatarType type, AvatarInfo info)
    {
        avatarType = type;

        avatarIcon.sprite = info.icon;

        bool isAvailable = info.icon != null;
        avatarIcon.gameObject.SetActive(isAvailable);

        // show/hide coming soon
        comingSoon.SetActive(!isAvailable);

        avatarName.text = string.Format("TIPE: {0}", info.avatarName);
        avatarDescription.text = info.description;
        // avatarVoice = info.voice;

        var buttonComponent = GetComponent<Button>();
        if (buttonComponent)
        {
            buttonComponent.onClick.AddListener(OnAvatarClicked);
        }

        var toggleComponent = GetComponent<Toggle>();
        if (toggleComponent)
        {
            toggleComponent.enabled = isAvailable;
            toggleComponent.onValueChanged.AddListener((value) =>
            {
                if (value)
                    OnAvatarPicked?.Invoke(avatarType);
            });
        }

        soundButton.onClick.AddListener(OnSoundButtonClicked);
    }

    public void OnSoundButtonClicked()
    {
        Debug.Log("OnSoundClicked");
        OnSoundClicked?.Invoke(avatarType);
    }

    public void OnAvatarClicked()
    {
        Debug.Log("OnAvatarClicked");
        OnAvatarPicked?.Invoke(avatarType);
    }
}
