using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    private ParticleSystem _ballExplosion;
    private void OnEnable()
    {
        
    }
    public void SetExplasion(ParticleSystem explosion)
    {
        _ballExplosion = explosion;
    }
    private void OnMouseDown()
    {
        _ballExplosion.transform.position = transform.position;
        _ballExplosion.Play();
    }
}
