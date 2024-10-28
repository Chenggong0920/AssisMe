using UnityEngine;
using UnityEngine.UI;

public class PurchaseScreen : MonoBehaviour
{
    [SerializeField]
    private Text remaingToken;

    private void Start() {
        TokenManager.Instance.OnTokenAmountUpdated += RefreshRemainingToken;

        RefreshRemainingToken();
    }

    private void OnDestroy() {
        TokenManager.Instance.OnTokenAmountUpdated -= RefreshRemainingToken;
    }

    private void RefreshRemainingToken()
    {
        remaingToken.text = string.Format("{0}", TokenManager.Instance.RemainingTokens);
    }
}