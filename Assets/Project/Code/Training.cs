using Assets.Project.Code.UI;
using UnityEngine;

namespace Assets.Project.Code
{
    public class Training : MonoBehaviour
    {
        private const string IsFirstTime = "IsFirstTime";
        [SerializeField] private CanvasGroup training;
        [SerializeField] private UICanvasExecutor uICanvasExecutor;
        private void Start()
        {
            if (!PlayerPrefs.HasKey(IsFirstTime))
            {
                uICanvasExecutor.MenuActivate(training);
                PlayerPrefs.SetInt(IsFirstTime, 1);
            }
        }
    }
}