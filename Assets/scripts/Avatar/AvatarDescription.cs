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

    // private AudioClip avatarVoice;
    private AvatarType avatarType;

    public delegate void AvatarPicked(AvatarType avatarType);
    public event AvatarPicked OnAvatarPicked;

    public delegate void SoundClicked(AvatarType avatarType);
    public event SoundClicked OnSoundClicked;

    [SerializeField]
    private Button pickButton;

    [SerializeField]
    private Button soundButton;

    private void Start() {
        pickButton.onClick.AddListener(OnAvatarClicked);
        soundButton.onClick.AddListener(OnSoundButtonClicked);
    }

    public void Initialize(AvatarType type, AvatarInfo info)
    {
        avatarType = type;

        avatarIcon.sprite = info.icon;
        avatarName.text = string.Format("TIPE: {0}", info.avatarName);
        avatarDescription.text = info.description;
        // avatarVoice = info.voice;
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
