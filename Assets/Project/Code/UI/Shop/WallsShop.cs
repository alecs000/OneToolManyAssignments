using Assets.Project.Code.BackgroundWall;
using Assets.Project.Code.Bank;
using UnityEngine;

namespace Assets.Project.Code.UI.Shop
{
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
}