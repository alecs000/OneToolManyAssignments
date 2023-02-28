using UnityEngine;

public class UICanvasExecutor : MonoBehaviour
{
    [SerializeField] private SeparateUIElement[] SeparateUIElement; 
    private CanvasSetter _setter;
    
    private void Awake()
    {
        _setter = new();
    }
    public void MenuActivate(CanvasGroup SetPanel = null)
    {
        foreach (var item in SeparateUIElement)
        {
            item.FlyAway();
        }
        _setter.SetCanvasGroup(SetPanel);
        Time.timeScale = 0;
    }
    public void MenuDeactivate()
    {
        foreach (var item in SeparateUIElement)
        {
            item.FlyBack();
        }
        _setter.SetCanvasGroup(null);
        Time.timeScale = 1;
    }
}
