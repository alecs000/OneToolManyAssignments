using UnityEngine;

[CreateAssetMenu(fileName = "BackgroundScriptableObject", menuName = "ScriptableObjects/BackgroundScriptableObject")]
public class BackgroundScriptableObject : ScriptableObject
{
    [SerializeField] private int cost;
    [SerializeField] private Sprite spriteBackground;

    public Sprite SpriteBackground => spriteBackground;
    public int Cost => cost;
}
