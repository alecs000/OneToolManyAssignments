using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class FruitBehaviour : MonoBehaviour
{
    [SerializeField] private ItemScriptableObject fruitScriptableObject;

    [SerializeField] private Rigidbody2D fruitRigidbody;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private PolygonCollider2D polygonCollider2D;
    [SerializeField] private Rigidbody2D[] fruitHalves;
    [SerializeField] private GameObject fruitWhole;

    private bool _isPressed;
    private AudioSource[] _fruitAudio;
    private IInputService _inputService;
    private ComletedDefault _comletedDefault;

    private void OnDown(Vector3 position)
    {
        _isPressed = true;
    }

    private void OnUp(Vector3 position)
    {
        _isPressed = false;
    }
    public void Construct(AudioSource[] fruitAudio, IInputService inputService, ComletedDefault comletedDefault)
    {
        _fruitAudio = fruitAudio;
        _inputService = inputService;
        _comletedDefault = comletedDefault;
        _inputService.PointerDown += OnDown;
        _inputService.PointerUp += OnUp;
    }
    public void ThrowFruit(Vector2 direction)
    {
        fruitRigidbody.AddForce(direction, ForceMode2D.Impulse);
    }
    private void OnMouseEnter()
    {
        if (_isPressed)
        {
            foreach (var fruit in fruitHalves)
            {
                fruit.gameObject.SetActive(true);
                fruit.AddForce(new Vector2(Random.Range(50, 400), Random.Range(50, 400)));
            }
            fruitRigidbody.gravityScale = 0;
            spriteRenderer.enabled = false;
            polygonCollider2D.enabled = false;
            _comletedDefault.InvokeItemComplited(fruitScriptableObject);
        }
    }
    private void OnDisable()
    {
        fruitRigidbody.gravityScale = 1;
        spriteRenderer.enabled = true;
        polygonCollider2D.enabled = true;
        foreach (var fruit in fruitHalves)
        {
            fruit.gameObject.SetActive(false);
            fruit.transform.localPosition = Vector3.zero;
        }
    }
}
