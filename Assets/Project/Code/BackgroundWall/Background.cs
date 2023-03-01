using UnityEngine;

namespace Assets.Project.Code.BackgroundWall
{
    public class Background : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        public void SetBacground(BackgroundScriptableObject background)
        {
            spriteRenderer.sprite = background.SpriteBackground;
        }
    }
}