using UnityEngine;

namespace Assets.Project.Code
{
    public class CenterOfMass : MonoBehaviour
    {
        [SerializeField] private Transform centerOfMass;
        private void Awake()
        {
            GetComponent<Rigidbody2D>().centerOfMass = Vector2.Scale(centerOfMass.localPosition, transform.localScale);
        }
    }
}