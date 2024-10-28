using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PurchaseOptionButton : CharacterOptionsButton
{
    public void Init(int price)
    {
        var s = string.Format("{0}円", price);
        base.Init(s);

        GetComponent<Button>().onClick.AddListener(() =>
        {
            TokenManager.Instance.OnPurchase(price);
        });
    }
}
