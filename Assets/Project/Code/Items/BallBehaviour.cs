using UnityEngine;

namespace Assets.Project.Code.Items
{
    public class BallBehaviour : MonoBehaviour
    {
        [SerializeField] private ItemScriptableObject ballScriptableObject;
        [Header("Configurable values")]
        [SerializeField] private float speed;
        [SerializeField] private float rotateSpeed;
        [Header("Other")]
        [SerializeField] private Rigidbody2D ballRigidbody;
        private AudioSource _audioBall;
        private ParticleSystem _ballExplosion;
        private ComletedDefault _comletedDefault;
        public void Construct(ParticleSystem ballExplosion, AudioSource audioBall, ComletedDefault comletedDefault)
        {
            _ballExplosion = ballExplosion;
            _audioBall = audioBall;
            _comletedDefault = comletedDefault;
        }
        private void OnMouseDown()
        {
            _audioBall.Play();
            _ballExplosion.transform.position = transform.position;
            _ballExplosion.Play();
            _comletedDefault.InvokeItemComplited(ballScriptableObject);
            gameObject.SetActive(false);
        }
        private void FixedUpdate()
        {
            ballRigidbody.velocity = Vector3.up * speed;
            if (ballRigidbody.rotation != 0)
            {
                ballRigidbody.AddTorque(-ballRigidbody.rotation * rotateSpeed);
            }
        }
    }
}