using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseOption : MonoBehaviour
{
    [SerializeField]
    private int tokenAmount;
    [SerializeField]
    private int price;

    [SerializeField]
    private Text label;

    [SerializeField]
    private PurchaseOptionButton button;

    private void Start() {
        label.text = string.Format("{0}トークン\n<size=32>約2時間のトーク</size>", tokenAmount);
        button.Init(price);
    }
}
