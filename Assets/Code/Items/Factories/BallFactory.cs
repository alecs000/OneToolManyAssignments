using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class BallFactory : GenericFactory <BallBehaviour>
{
    [SerializeField] private float yPosition;
    [SerializeField] private ParticleSystem ballExplosion;

    protected override IEnumerator Creating()
    {
        while (_isSpawn)
        {
            BallBehaviour ball = _pool.GetFreeElement();
            ball.SetExplasion(ballExplosion);
            ball.transform.position = new Vector2(Random.Range(Borders.MinPos.x, Borders.MaxPos.x), yPosition);
            yield return new WaitForSeconds(speedOfOccurrence);
        }
    }
}
