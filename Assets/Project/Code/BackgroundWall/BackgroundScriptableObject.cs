using UnityEngine;

namespace Assets.Project.Code.BackgroundWall
{
    [CreateAssetMenu(fileName = "BackgroundScriptableObject", menuName = "ScriptableObjects/BackgroundScriptableObject")]
    public class BackgroundScriptableObject : ScriptableObject
    {
        [SerializeField] private string nameBackground;

        [SerializeField] private int cost;
        [SerializeField] private Sprite spriteBackground;

        public string Name => nameBackground;
        public int Cost => cost;
        public Sprite SpriteBackground => spriteBackground;
    }
}