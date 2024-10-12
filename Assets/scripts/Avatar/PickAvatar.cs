using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarDescriptionsUI : MonoBehaviour
{
    [SerializeField]
    private AvatarDescription avatarDescriptionPrefab;

    [SerializeField]
    private Transform contentsParent;

    [SerializeField]
    private SerializableDictionary<AvatarType, AvatarInfo> avatarInfos;


    private AudioSource audioSourceComponent;
    private UINavigate navigateComponent;

    private void Awake()
    {
        Init();    
    }

    private void Init()
    {
        navigateComponent = GetComponent<UINavigate>();

        if (avatarDescriptionPrefab == null)
            return;

        foreach(SerializableKeyValuePair<AvatarType, AvatarInfo> info in avatarInfos.KeyValuePairs)
        {
            var descriptionGO = Instantiate(avatarDescriptionPrefab, contentsParent);
            descriptionGO.Initialize(info.Key, info.Value);

            descriptionGO.OnAvatarPicked += OnAvatarPicked;
            descriptionGO.OnSoundClicked += OnSoundClicked;
        }

        audioSourceComponent = GetComponent<AudioSource>();
    }

    private void OnAvatarPicked(AvatarType type)
    {
        Debug.LogFormat("Avatar Picked: {0}", type);

        navigateComponent.OnNext();
    }

    private void OnSoundClicked(AvatarType type)
    {
        Debug.LogFormat("Sound Clicked: {0}", type);
        if (avatarInfos.ContainsKey(type))
        {
            var sound = avatarInfos.Get(type).voice;
            audioSourceComponent.PlayOneShot(sound);
        }
    }
}
