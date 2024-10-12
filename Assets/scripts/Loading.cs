using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loading : MonoBehaviour
{
    [SerializeField]
    private float nextAfter = 3f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadingCoroutine());
    }

    IEnumerator LoadingCoroutine()
    {   
        yield return new WaitForSeconds(nextAfter);

        GetComponent<UINavigate>().OnNext();
    }
}
