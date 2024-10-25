using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AvatarDescriptionsUI : MonoBehaviour
{
    [SerializeField]
    private Transform contentsParent;

    // [SerializeField]
    // private SerializableDictionary<AvatarType, AvatarInfo> avatarInfos;
    [SerializeField]
    private int childIndexOffset = 0;

    [SerializeField]
    private bool createToggles = false;


    private AudioSource audioSourceComponent;
    private UINavigate navigateComponent;

    [System.Serializable]
    public class AvatarPickEvent : UnityEvent<AvatarType> { }
    [SerializeField]
    private AvatarPickEvent onAvatarPickedEvent;
    private ToggleGroup toggleGroup;

    private void Start()
    {
        Init();    
    }

    private void Init()
    {
        navigateComponent = GetComponent<UINavigate>();

        var avatarDescriptionPrefab = createToggles? Settings.Instance.AvatarDescription_Toggle_Prefab
                                                    : Settings.Instance.AvatarDescription_Button_Prefab;

        if (avatarDescriptionPrefab == null)
            return;

        if (createToggles)
        {
            toggleGroup = gameObject.AddComponent<ToggleGroup>();
            toggleGroup.allowSwitchOff = false;
        }

        int index = 0;
        foreach(SerializableKeyValuePair<AvatarType, AvatarInfo> info in Settings.Instance.AvatarInfos.KeyValuePairs)
        {
            var descriptionGO = Instantiate(avatarDescriptionPrefab, contentsParent);
            descriptionGO.Initialize(info.Key, info.Value);

            if (childIndexOffset > 0)
            {
                descriptionGO.transform.SetSiblingIndex(childIndexOffset + index ++);
            }

            if (info.Value.icon)
            {
                descriptionGO.OnAvatarPicked += OnAvatarPicked;
                descriptionGO.OnSoundClicked += OnSoundClicked;
            }

            if (createToggles)
            {
                var toggleComponent = descriptionGO.GetComponent<Toggle>();
                toggleComponent.group = toggleGroup;

                if (info.Key == PlayerInfoManager.Instance.AvatarType)
                    toggleComponent.isOn = true;
            }
        }

        audioSourceComponent = GetComponent<AudioSource>();
    }

    private void OnAvatarPicked(AvatarType type)
    {
        Debug.LogFormat("Avatar Picked: {0}", type);

        // update avatar
        onAvatarPickedEvent.Invoke(type);

        // go for next
        if (navigateComponent)
            navigateComponent.OnNext();
    }

    private void OnSoundClicked(AvatarType type)
    {
        Debug.LogFormat("Sound Clicked: {0}", type);
        var avatarInfo = Settings.Instance.GetAvatarInfo(type);
        if (avatarInfo != null)
        {
            var sound = avatarInfo?.voice;
            audioSourceComponent.PlayOneShot(sound);
        }
    }
}
