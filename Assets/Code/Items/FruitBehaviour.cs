using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitBehaviour : MonoBehaviour
{
    [SerializeField] private Rigidbody2D fruitRigidbody;

    public void ThrowFruit(Vector2 direction)
    {
        fruitRigidbody.AddForce(direction, ForceMode2D.Impulse);
    }
}
