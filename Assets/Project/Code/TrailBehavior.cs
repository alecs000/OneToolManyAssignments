using Assets.Project.Code.Input;
using UnityEngine;
using Zenject;

namespace Assets.Project.Code
{
    public class TrailBehavior : MonoBehaviour
    {
        [SerializeField] private TrailRenderer trailRenderer;
        private IInputService _inputService;

        [Inject]
        public void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }
        private void Start()
        {
            _inputService.PointerDown += OnDown;

            _inputService.PointerDrag += OnDrag;

            _inputService.PointerUp += OnUp;
        }

        private void OnDown(Vector3 position)
        {
            transform.position = position;
            trailRenderer.enabled = true;
        }
        private void OnDrag(Vector3 position)
        {
            trailRenderer.enabled = true;
            transform.position = position;
        }

        private void OnUp(Vector3 position)
        {
            trailRenderer.enabled = false;
        }
    }
}