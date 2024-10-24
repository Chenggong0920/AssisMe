using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuthManager : MonoBehaviour
{
    public void OnSignInGoogle()
    {
        OnSignInCompleted();
    }

    public void OnSignInApple()
    {
        OnSignInCompleted();
    }

    private void OnSignInCompleted()
    {
        UIManager.Instance.OnStart();
    }
}
