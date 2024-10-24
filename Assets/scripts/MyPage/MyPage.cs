using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyPage : MonoBehaviour
{
    [SerializeField]
    private Text remainingPoints;
    [SerializeField]
    private Text additionalPoints;
    [SerializeField]
    private Text usedPoints;
    [SerializeField]
    private Slider sliderPoints;

    [Header("Other Screens")]
    [SerializeField]
    private GameObject aboutScreen;

    [SerializeField]
    private GameObject updateInfoScreen;
    [SerializeField]
    private GameObject updateAvatarScreen;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    private void Init()
    {
        UpdatePoints(90, 20);
    }

    private void UpdatePoints(int additional, int used)
    {
        int remaining = additional - used;
        remainingPoints.text = string.Format("利用可能\n<size=100>{0}</size> トークン", remaining);
        additionalPoints.text = string.Format("追加分<size=66>\n{0}</size>トークン", additional);
        usedPoints.text = string.Format("利用分\n<size=66>{0}</size>トークン", used);

        sliderPoints.value = (float)remaining / additional;
    }

    public void OnAboutTokens()
    {
        gameObject.SetActive(false);
        aboutScreen.SetActive(true);
    }

    public void OnPurchaseToken()
    {

    }

    public void OnUpdateInfo()
    {
        gameObject.SetActive(false);
        updateInfoScreen.SetActive(true);
    }

    public void OnUpdateAvatar()
    {
        gameObject.SetActive(false);
        updateAvatarScreen.SetActive(true);
    }
}
