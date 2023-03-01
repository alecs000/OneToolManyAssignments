using Assets.Project.Code.Bank;
using TMPro;
using UnityEngine;

namespace Assets.Project.Code.UI
{
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
}