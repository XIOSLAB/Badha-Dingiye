using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class ScaleTween : MonoBehaviour
{
    Tween scaleTween;
    RectTransform rectTransform;
    Vector2 startScale;
    public Vector2 endScale;
    public float duration;
    public bool doOnStart = true;

    public UnityEvent onScaleEndEvent;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        startScale = rectTransform.sizeDelta;

        if (doOnStart)
        {
            DoScale();
        }
    }

    public void DoScale()
    {
        scaleTween.Kill();

        scaleTween = rectTransform.DOScale(endScale,duration).SetEase(Ease.Linear);
        scaleTween.OnComplete(() => 
        {
            onScaleEndEvent?.Invoke();
        });
    }

}
