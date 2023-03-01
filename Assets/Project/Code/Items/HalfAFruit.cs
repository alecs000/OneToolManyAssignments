using UnityEngine;

namespace Assets.Project.Code.Items
{
    public class HalfAFruit : MonoBehaviour
    {
        [SerializeField] private GameObject wholeFruit;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out OutOfScreen border))
            {
                wholeFruit.SetActive(false);
            }
        }
    }
}