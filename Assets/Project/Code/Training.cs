using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
