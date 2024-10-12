using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NameAvatar : MonoBehaviour
{
    [SerializeField]
    private RectTransform generatedNamesParent;

    [SerializeField]
    private GameObject namePrefab;

    private List<string> names = new List<string>
    {
        "ABC", "DEF", "GHI", "JKL", "MNO",
        "PQR", "STU", "VW", "XYZ"
    };

    // [SerializeField]
    // private RectTransform contents;
    // VerticalLayoutGroup namesLayout;

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

        foreach (string name in selectedNames)
        {
            GameObject optionGO = Instantiate(namePrefab, generatedNamesParent);
            TextMeshProUGUI text = optionGO.GetComponentInChildren<TextMeshProUGUI>();
            if (text) {
                text.text = name;
            }
            // else
            {
                Text label = optionGO.GetComponentInChildren<Text>();
                if (label)
                    label.text = name;
            }
        }

        // if (namesLayout == null)
        // {
        //     namesLayout = contents.GetComponent<VerticalLayoutGroup>();
        //     // LayoutRebuilder.ForceRebuildLayoutImmediate(contents);
        // }

        // // if (namesLayout != null)
        // {
        //     // LayoutRebuilder.ForceRebuildLayoutImmediate(generatedNamesParent);
        //     // LayoutRebuilder.ForceRebuildLayoutImmediate(contents);
        // }
    }
}
