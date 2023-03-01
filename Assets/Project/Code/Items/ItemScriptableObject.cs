using UnityEngine;

namespace Assets.Project.Code.Items
{
    [CreateAssetMenu(fileName = "ItemScriptableObject", menuName = "ScriptableObjects/ItemScriptableObject")]
    public class ItemScriptableObject : ScriptableObject
    {
        [SerializeField] private int cost;

        public int Cost => cost;
    }
}