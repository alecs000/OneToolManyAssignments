using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfAFruit : MonoBehaviour
{
    [SerializeField] private GameObject wholeFruit;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<OutOfScreen>(out OutOfScreen border))
        {
            wholeFruit.SetActive(false);
        }
    }
}
