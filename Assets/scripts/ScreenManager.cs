using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour
{
    public void OpenScreen(Screen screen)
    {
        string targetScene = null;
        switch (screen)
        {
            case Screen.Home:
                targetScene = "Home";
                break;

            case Screen.Call:
                // targetScene = "Call";
                break;

            case Screen.Chat:
                targetScene = "TextChat";
                break;
                
            case Screen.Reminders:
                targetScene = "Reminders";
                break;

            case Screen.MyPage:
                targetScene = "MyPage";
                break;
        }
        if (!string.IsNullOrEmpty(targetScene))
            SceneManager.LoadScene(targetScene);
    }
}