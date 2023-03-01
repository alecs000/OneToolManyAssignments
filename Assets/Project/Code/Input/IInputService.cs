using UnityEngine;
using UnityEngine.Events;

namespace Assets.Project.Code.Input
{
    public interface IInputService
    {
        public event UnityAction<Vector3> PointerDown;
        public event UnityAction<Vector3> PointerUp;
        public event UnityAction<Vector3> PointerDrag;
    }
}