using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    public void SetBacground(BackgroundScriptableObject background)
    {
        spriteRenderer.sprite = background.SpriteBackground;
    }
}
