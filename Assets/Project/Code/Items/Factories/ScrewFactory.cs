using System.Collections;
using UnityEngine;

namespace Assets.Project.Code.Items.Factories
{
    public class ScrewFactory : GenericFactory<ScrewBehaviour>
    {
        [SerializeField] private AudioSource screwAudio;
        private void Start()
        {
            StartCoroutine(Creating());
        }
        protected override IEnumerator Creating()
        {
            while (_isSpawn)
            {
                ScrewBehaviour screw = _pool.GetFreeElement();
                screw.transform.position = Borders.GetRandomVectorInViewport();
                screw.Construct(screwAudio, this);
                yield return new WaitForSeconds(speedOfOccurrence);
            }
        }
    }
}