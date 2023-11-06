using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMoveSystem : MonoBehaviour
{
    public RectTransform player;
    public float moveSpeed;
    public int currentNode = 0;
    public int upComingQuiz = 0;
    public Ease ease;
    
    public RectTransform[] movePoints;
    public List<int> miniGameIndex;
    public UnityEvent begainGameEvent;
    public UnityEvent nodeEndEvent;
    public QuizManager quizManager;
    Tween moveTween;

    private void Start()
    {
        Move();
    }

    public void Move()
    {
        moveTween.Kill();
        moveTween = player.DOLocalMove(movePoints[currentNode].localPosition, moveSpeed* Vector2.Distance(player.localPosition, movePoints[currentNode].localPosition)).SetEase(ease);

        moveTween.OnComplete(() =>
        {
            if (miniGameIndex.Contains(currentNode))
            {
                begainGameEvent?.Invoke();
                quizManager.ShowQuiz(upComingQuiz);
                upComingQuiz++;
                return;
            }
            currentNode++;
            nodeEndEvent?.Invoke();
        });
        
    }
    public void DisableQuiz()
    {
        quizManager.DisableQuiz(upComingQuiz);
    }
    public void MoveNext()
    {
        currentNode = currentNode + 1;
        Move();
    }


}
