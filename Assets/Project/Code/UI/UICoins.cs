using Assets.Code.Bank;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UICoins : MonoBehaviour
{
    [SerializeField] private Coins coins;
    [SerializeField] private TMP_Text coinsText;
    private void Start()
    {
        coins.AddObserver(OnCoinsValueChange);
    }

    private void OnCoinsValueChange(int newValue)
    {
        coinsText.text = newValue.ToString();
    }
    private void OnDestroy()
    {
        coins.RemoveObserver(OnCoinsValueChange);
    }
}
