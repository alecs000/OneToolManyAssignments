using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SeparateUIElement : MonoBehaviour
{
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private Vector2 moveToCenterOn;
    [SerializeField] private Vector2 positionOutOfScreen;
    [SerializeField] private float duration;
    private Vector2 _startPosition;
    private void Start()
    {
        _startPosition = rectTransform.anchoredPosition;
    }
    public void FlyAway()
    {
        var flyAway = DOTween.Sequence();
        flyAway.Append(rectTransform.DOAnchorPos(moveToCenterOn, duration / 3).SetRelative());
        flyAway.Append(rectTransform.DOAnchorPos(positionOutOfScreen, duration).SetRelative());
        flyAway.OnKill(()=> CanvasSetter.TurnOffCanvasGroup(canvasGroup));
    }
    public void FlyBack()
    {
        CanvasSetter.TurnOnCanvasGroup(canvasGroup);
        rectTransform.DOAnchorPos(_startPosition, duration);
    }
}
