using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Product : MonoBehaviour
{
    private const string ProductState = "ProductState";
    private const string Bought = "Bought";
    private const string Equipped = "Equipped";

    [SerializeField] private BackgroundScriptableObject backgroundScriptableObject;
    [SerializeField] private WallsShop wallsShop;
    [SerializeField] private TMP_Text costText;
    [SerializeField] private Image wallImage;
    [SerializeField] private GameObject BuyButton;
    [SerializeField] private GameObject equippedGameObject;
    [SerializeField] private GameObject boughtGameObject;


    // Start is called before the first frame update
    void Start()
    {
        costText.text = backgroundScriptableObject.Cost.ToString();
        wallImage.sprite = backgroundScriptableObject.SpriteBackground;
        if (PlayerPrefs.HasKey(ProductState))
        {
            string savedState = PlayerPrefs.GetString(ProductState);
            if (savedState == Bought)
            {
                SetBought();
            }
            if (savedState == Equipped)
            {
                SetEquipped();
            }
        }
    }
    public void TryBuy()
    {
        wallsShop.TryBuy(backgroundScriptableObject, this);
        SetEquipped();
    }
    public void SetEquipped()
    {
        PlayerPrefs.SetString(ProductState, Equipped);
        costText.gameObject.SetActive(false);
        wallsShop.Equip(backgroundScriptableObject, this);
        equippedGameObject.SetActive(true);
    }
    public void SetBought()
    {
        PlayerPrefs.SetString(ProductState, Bought);
        costText.gameObject.SetActive(false);
        boughtGameObject.SetActive(true);
    }
}
