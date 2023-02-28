using Assets.Code;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void ItemComplited(ItemScriptableObject itemScriptableObject);
public class ComletedDefault : MonoBehaviour, IEventInitializer<ItemComplited>
{
    protected event ItemComplited _itemComplited;
    public void RemoveObserver(ItemComplited @delegate)
    {
        _itemComplited += @delegate;
    }

    public void AddObserver(ItemComplited @delegate)
    {
        _itemComplited += @delegate;
    }
    public void InvokeItemComplited(ItemScriptableObject itemScriptableObject)
    {
        _itemComplited?.Invoke(itemScriptableObject);
    }
}
