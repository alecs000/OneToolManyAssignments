using Assets.Project.Code.BackgroundWall;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Project.Code.UI.Shop
{
    public class Product : MonoBehaviour
    {
        private string ProductState => backgroundScriptableObject.Name;
        private const string Bought = "Bought";
        private const string Equipped = "Equipped";

        [SerializeField] private BackgroundScriptableObject backgroundScriptableObject;
        [SerializeField] private WallsShop wallsShop;
        [Header("UIElements")]
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
                    Equip();
                }
            }
        }
        public void TryBuy()
        {
            if (wallsShop.TryBuy(backgroundScriptableObject, this))
                SetEquipped();
        }
        public void Equip()
        {
            wallsShop.Equip(backgroundScriptableObject, this);
            SetEquipped();
        }
        public void SetEquipped()
        {
            PlayerPrefs.SetString(ProductState, Equipped);
            SetState(equippedGameObject);
        }
        public void SetBought()
        {
            PlayerPrefs.SetString(ProductState, Bought);
            SetState(boughtGameObject);
        }
        private void SetState(GameObject gameObjectState)
        {
            costText.gameObject.SetActive(false);
            BuyButton.SetActive(false);
            equippedGameObject.SetActive(false);
            boughtGameObject.SetActive(false);
            gameObjectState.SetActive(true);
        }
    }
}