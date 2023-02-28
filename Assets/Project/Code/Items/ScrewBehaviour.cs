using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScrewBehaviour : MonoBehaviour
{
    [SerializeField] private ItemScriptableObject screwScriptableObject;
    [Header("Configurable values")]
    [SerializeField] private float unscrewTime = 0.3f;
    [SerializeField] private float rotateSpeed = 0.3f;
    [Header("Other")]
    [SerializeField] private Rigidbody2D screwRigidbody;
    [SerializeField] private CircleCollider2D screwCollider;

    private AudioSource _screwAudio;

    private bool _isUnscrew = false;
    private bool _isStppedUnscrew;
    private ComletedDefault _comletedDefault;

    public void Construct(AudioSource screwAudio, ComletedDefault comletedDefault)
    {
        _screwAudio = screwAudio;
        _comletedDefault = comletedDefault;
    }
    private void OnMouseDown()
    {
        if (_isUnscrew)
            return;
        _screwAudio.Play();
        _isUnscrew = true;
        StartCoroutine(EndUnscrew());
        screwCollider.isTrigger = false;
    }
    private void OnMouseUp()
    {
        if (_isUnscrew)
        {
            _isUnscrew = false;
            _isStppedUnscrew = true;
            _screwAudio.Stop();
        }
    }
    private void FixedUpdate()
    {
        if (_isUnscrew)
        {
            screwRigidbody.MoveRotation(screwRigidbody.rotation+ rotateSpeed * Time.fixedDeltaTime);
        }
    }
    IEnumerator EndUnscrew()
    {
        yield return new WaitForSeconds(unscrewTime);
        if (_isStppedUnscrew)
        {
            _isStppedUnscrew = false;
            yield break;
        }
        TwistComplited();
    }
    private void TwistComplited()
    {
        _comletedDefault.InvokeItemComplited(screwScriptableObject);
        _isUnscrew = false;
        _screwAudio.Stop();
        screwRigidbody.constraints = RigidbodyConstraints2D.None;
    }
    private void OnDisable()
    {
        _isStppedUnscrew = false;
        screwCollider.isTrigger = true;
        screwRigidbody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
    }
}
