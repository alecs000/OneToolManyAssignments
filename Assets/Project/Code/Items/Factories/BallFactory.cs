using System.Collections;
using UnityEngine;

namespace Assets.Project.Code.Items.Factories
{
    public class BallFactory : GenericFactory<BallBehaviour>
    {
        [SerializeField] private float yPosition;
        [SerializeField] private ParticleSystem ballExplosion;
        [SerializeField] private AudioSource ballAudio;
        private void Start()
        {
            StartCoroutine(Creating());
        }
        protected override IEnumerator Creating()
        {
            while (_isSpawn)
            {
                BallBehaviour ball = _pool.GetFreeElement();
                ball.transform.position = new Vector2(Random.Range(Borders.MinPos.x, Borders.MaxPos.x), yPosition);
                ball.Construct(ballExplosion, ballAudio, this);
                yield return new WaitForSeconds(speedOfOccurrence);
            }
        }
    }
}