using Assets.Project.Code.Input;
using UnityEngine;
using UnityEngine.Events;

public class MouseInput : MonoBehaviour, IInputService
{
    private Camera _camera;

    public event UnityAction<Vector3> PointerDown;
    public event UnityAction<Vector3> PointerUp;
    public event UnityAction<Vector3> PointerDrag;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            PointerDown?.Invoke(GetWorldPosition(Input.mousePosition));
        }

        if (Input.GetMouseButton(0))
        {
            PointerDrag?.Invoke(GetWorldPosition(Input.mousePosition));
        }

        if (Input.GetMouseButtonUp(0))
        {
            PointerUp?.Invoke(GetWorldPosition(Input.mousePosition));
        }
    }

    private Vector2 GetWorldPosition(Vector2 screenPosition)
    {
        return _camera.ScreenToWorldPoint(screenPosition);
    }
}
