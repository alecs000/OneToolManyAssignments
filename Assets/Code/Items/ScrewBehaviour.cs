using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

delegate void OnScrewComplited();
public class ScrewBehaviour : MonoBehaviour, IInit<OnScrewComplited>
{
    [Header("Configurable values")]
    [SerializeField] private float unscrewTime = 0.3f;
    [SerializeField] private float rotateSpeed = 0.3f;
    [Header("Other")]
    [SerializeField] private AudioSource screwAudio;
    [SerializeField] private Rigidbody2D screwRigidbody;
    [SerializeField] private CircleCollider2D screwCollider;

    private event OnScrewComplited _onScrewComplited;
    private bool _isUnscrew;
    private bool _isStppedUnscrew;
    private void Start()
    {
    }
    private void OnMouseDown()
    {
        if (_isUnscrew)
            return;
        screwAudio.Play();
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
        _onScrewComplited?.Invoke();
        _isUnscrew = false;
        screwAudio.Stop();
        screwRigidbody.constraints = RigidbodyConstraints2D.None;
    }
    private void OnDisable()
    {
        _isStppedUnscrew = false;
        screwCollider.isTrigger = true;
        screwRigidbody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;


    }

    void IInit<OnScrewComplited>.Initialize(OnScrewComplited @delegate)
    {
        _onScrewComplited += @delegate;
    }

    void IInit<OnScrewComplited>.Deinitialize(OnScrewComplited @delegate)
    {
        _onScrewComplited += @delegate;
    }
}
