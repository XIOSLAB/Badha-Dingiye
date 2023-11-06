using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class OptionMatchingManager : MonoBehaviour
{
    public MatchOption[] leftMatchOption = null;
    public MatchOption[] allMatchOption = null;
    public string[] correctmatchIntex;
    public int correctAnswer = 0;
    public UnityEvent<int> OnMatchingComplete;
    public UnityEvent<int,int> scoreEvent;
    public void CheckIfAllOptionConnected()
    {
        correctAnswer = 0;
        for (int i = 0; i < leftMatchOption.Length; i++)
        {
            if (leftMatchOption[i].isConnected == true)
            {
                string matchIntex = leftMatchOption[i].optionIndex.ToString() + leftMatchOption[i].connectedOptionIndex.ToString();
                if (matchIntex == correctmatchIntex[i])
                {
                    correctAnswer++;
                    if (i == leftMatchOption.Length - 1)
                    {
                        OnMatchingComplete?.Invoke(correctAnswer);
                    }
                }
                if (i == leftMatchOption.Length - 1)
                {
                    OnMatchingComplete?.Invoke(correctAnswer);
                    foreach (MatchOption item in allMatchOption)
                    {
                        item.lineRenderer.enabled = false;
                    }
                }
                continue;
            }
            else
            {
                break;
            }
        }

        scoreEvent?.Invoke(correctAnswer, correctmatchIntex.Length);
    }
    public void ResetGame()
    {
        correctAnswer = 0;  
        foreach (MatchOption item in allMatchOption)
        {
            item.lineRenderer.SetPosition(1,Vector3.zero);
            item.lineRenderer.enabled = false;
            item.isConnected = true;
            item.connectedOptionIndex = -1;
        }
    }
}
