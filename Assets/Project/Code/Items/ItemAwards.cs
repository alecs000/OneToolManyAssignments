using Assets.Code.Bank;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAwards : MonoBehaviour
{
    [SerializeField] private Coins coins;
    [SerializeField] private ComletedDefault[] comletedDefault;

    private void Start()
    {
        foreach (var item in comletedDefault)
        {
            item.AddObserver(GetReward);
        }
    }
    public void GetReward(ItemScriptableObject itemScriptableObject)
    {
        coins.Add(itemScriptableObject.Cost);
    }
    private void OnDestroy()
    {
        foreach (var item in comletedDefault)
        {
            item.RemoveObserver(GetReward);
        }
    }
}
