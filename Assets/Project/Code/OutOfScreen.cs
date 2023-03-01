using UnityEngine;

namespace Assets.Project.Code
{
    public class OutOfScreen : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            collision.gameObject.SetActive(false);
        }
    }
}