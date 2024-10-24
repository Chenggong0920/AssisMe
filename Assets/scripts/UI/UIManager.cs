using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField]
    private GameObject LoginScreen;

    [SerializeField]
    private GameObject RegisterScreen;
    
    private ScreenManager screenManager;

    private void Awake() {
        Instance = this;

        screenManager = GetComponent<ScreenManager>();
    }

    public void OnStart()
    {
        if (PlayerInfoManager.Instance.IsSetupCompleted())
            OnHome();
        else
            RegisterScreen.SetActive(true);
    }

    public void OnLogin()
    {
        LoginScreen.SetActive(true);
    }

    public void OnHome()
    {
        screenManager.OpenScreen(Screen.Home);
    }

    public void OnNavigateButtonClicked(Screen screen)
    {
        screenManager.OpenScreen(screen);
    }
}
