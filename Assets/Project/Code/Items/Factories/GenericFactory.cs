using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

public abstract class GenericFactory<T> : ComletedDefault where T : Component
{
    [SerializeField] protected T prefab;
    [SerializeField] protected int poolCount;
    [SerializeField] protected int speedOfOccurrence;

    protected PoolMono<T> _pool;
    protected bool _isSpawn = true;

    // Start is called before the first frame update
    private void Awake()
    {
        _pool = new PoolMono<T>(prefab, poolCount, this.transform);
    }
    protected virtual IEnumerator Creating()
    {
        yield break;
    }
    public void SwitchSpeed(int newSpeed)
    {
        speedOfOccurrence = newSpeed;
    }
}
