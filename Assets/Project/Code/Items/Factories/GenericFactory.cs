using System.Collections;
using UnityEngine;

namespace Assets.Project.Code.Items.Factories
{
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
            _pool = new PoolMono<T>(prefab, poolCount, transform);
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
}