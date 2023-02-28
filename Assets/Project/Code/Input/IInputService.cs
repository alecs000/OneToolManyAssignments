using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public interface IInputService
{
    public event UnityAction<Vector3> PointerDown;
    public event UnityAction<Vector3> PointerUp;
    public event UnityAction<Vector3> PointerDrag;
}
