using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class NameAvatar : MonoBehaviour
{
    [SerializeField]
    private InputField inputName;

    [SerializeField]
    private RectTransform generatedNamesParent;

    [SerializeField]
    private Toggle namePrefab;
    [SerializeField]
    private ToggleGroup toggleGroup;

    [System.Serializable]
    public class AvatarNameEvent : UnityEvent<string> { }
    [SerializeField]
    private AvatarNameEvent onAvatarNamedEvent;

    private List<string> names = new List<string>
    {
        "ABC", "DEF", "GHI", "JKL", "MNO",
        "PQR", "STU", "VW", "XYZ"
    };

    private List<CharacterOptionsButton> optionButtons = new List<CharacterOptionsButton>();

    // Start is called before the first frame update
    void Start()
    {
        GenerateRandomNames();
    }

    public void OnGenerateClicked()
    {
        GenerateRandomNames();
    }

    private void GenerateRandomNames(int count = 3)
    {
        HashSet<string> selectedNames = new HashSet<string>();

        while (selectedNames.Count < count && selectedNames.Count < names.Count)
        {
            string randomName = names[Random.Range(0, names.Count)];
            selectedNames.Add(randomName);
        }

        // Loop through all child transforms and destroy them
        foreach (Transform child in generatedNamesParent)
        {
            Destroy(child.gameObject);
        }

        optionButtons.Clear();

        foreach (string name in selectedNames)
        {
            var optionToggle = Instantiate(namePrefab, generatedNamesParent);
            optionToggle.group = toggleGroup;
            
            var optionButton = optionToggle.gameObject.AddComponent<CharacterOptionsButton>();
            optionButton.Init(name);

            optionButtons.Add(optionButton);
        }
    }

    public void OnNext()
    {
        foreach (var optionButton in optionButtons)
        {
            if (optionButton.IsSelectedToggle())
            {
                onAvatarNamedEvent.Invoke(optionButton.Value);
                return;
            }
        }

        onAvatarNamedEvent.Invoke(inputName.text);
    }
}
