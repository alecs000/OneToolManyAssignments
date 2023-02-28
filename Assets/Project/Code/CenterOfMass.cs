using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterOfMass : MonoBehaviour
{
    [SerializeField] private Transform centerOfMass;
    private void Awake()
    {
        GetComponent<Rigidbody2D>().centerOfMass = Vector2.Scale(centerOfMass.localPosition, transform.localScale);
    }
}
