using Assets.Code.Bank;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsShop : MonoBehaviour
{
    [SerializeField] private Coins coins;
    [SerializeField] private Background background;
    [SerializeField] private Product currentProduct;
    public bool TryBuy(BackgroundScriptableObject backgroundScriptableObject, Product sender)
    {
        if (coins.TryRemove(backgroundScriptableObject.Cost))
        {
            Equip(backgroundScriptableObject, sender);
            return true;
        }
        return false;
    }
    public void Equip(BackgroundScriptableObject backgroundScriptableObject, Product sender)
    {
        currentProduct.SetBought();
        currentProduct = sender;
        background.SetBacground(backgroundScriptableObject);
    }
}
