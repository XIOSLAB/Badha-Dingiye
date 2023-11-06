using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    public GameObject[] quizs;


    public void ShowQuiz(int quizId)
    {
        for (int i = 0; i < quizs.Length; i++)
        {
            quizs[i].SetActive(false);
        }
        quizs[quizId].SetActive(true);
    }
    public void DisableQuiz(int quizId)
    {
        quizs[quizId-1].SetActive(false);
    }
}
