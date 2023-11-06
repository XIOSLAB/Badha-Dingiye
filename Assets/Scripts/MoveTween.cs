using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoveTween : MonoBehaviour
{
    [SerializeField] private bool activeOnEnable = true;
    [SerializeField][Range(0,2)] private float moveSpeed = 1f;
    public Vector3 movePosition;
    public Ease ease = Ease.Linear;
    Vector3 startPosition;
    RectTransform rectTransform;
    Tween moveIn, moveOut;
    public UnityEvent moveEndEvent;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void OnEnable()
    {
        if (!activeOnEnable) { return; }
        MoveIn();
    }

    public void MoveIn()
    {
        moveIn?.Kill();
        startPosition = rectTransform.localPosition;
        moveIn = rectTransform.DOLocalMove(movePosition, moveSpeed).SetEase(ease);

        moveIn.OnComplete(() => {
            moveEndEvent?.Invoke();
        });
    }

    
}
