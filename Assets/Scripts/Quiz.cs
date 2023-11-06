using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    public GameObject rightAnswerBoard;
    public GameObject worngAnswerBoard;
    public int score = -5;
    public void RigthAnswer()
    {
        score = 10;
        worngAnswerBoard.gameObject.SetActive(false);
        rightAnswerBoard.gameObject.SetActive(true);

    }

    public void AddScore()
    {
        GameManager.instances.AddScore(score);
    }

}
