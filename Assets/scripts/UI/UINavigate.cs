using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UINavigate : MonoBehaviour
{
    [SerializeField]
    private GameObject nextScreen;

    public void OnNext()
    {
        if( !nextScreen)
            return;

        gameObject.SetActive(false);
        nextScreen.SetActive(true);
    }
}
