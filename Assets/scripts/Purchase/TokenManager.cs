using UnityEngine;

public class TokenManager : MonoBehaviour
{
    [SerializeField]
    private int remainingTokens;

    public int RemainingTokens
    {
        get => remainingTokens;
    }

    public static TokenManager Instance;

    public delegate void TokenAmountUpdated();
    public TokenAmountUpdated OnTokenAmountUpdated;

    private void Awake() {
        Instance = this;
    }

    public void OnPurchase(int price)
    {
        OnPurchaseSuccess();
    }

    private void OnPurchaseSuccess()
    {
        if (OnTokenAmountUpdated != null)
            OnTokenAmountUpdated();
    }
}