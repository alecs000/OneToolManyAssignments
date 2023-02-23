using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FruitFactory : GenericFactory<FruitBehaviour>
{
    [SerializeField] private float XPositionToLeft = -10;
    [SerializeField] private float YPosition;
    [SerializeField] private float spreadPosition;

    [SerializeField] private Vector2 flyDirectionFromLeft;
    [SerializeField] private float spreadForce;

    private void Start()
    {
       StartCoroutine(Creating());
    }
    protected override IEnumerator Creating()
    {
        while (_isSpawn)
        {
            FruitBehaviour fruit = _pool.GetFreeElement();
            float randomSpreadForce = Random.Range(-spreadForce, spreadForce);
            Vector2 force = new Vector2(randomSpreadForce + flyDirectionFromLeft.x, randomSpreadForce + flyDirectionFromLeft.y);
            float randomYPosition = Random.Range(YPosition - spreadPosition, YPosition + spreadPosition);
            if (Random.Range(0, 2) == 0)
            {
                fruit.transform.position = new Vector2(XPositionToLeft, randomYPosition);
                fruit.ThrowFruit(force);
            }
            else
            {
                fruit.transform.position = new Vector2(-XPositionToLeft, randomYPosition);
                fruit.ThrowFruit(new Vector2(-force.x, force.y));
            }
            yield return new WaitForSeconds(speedOfOccurrence);
        }
    }
}
