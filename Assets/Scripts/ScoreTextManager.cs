using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public struct FullScore
{
    public string titleText;
    public string beforeScore;
    public string afterScore;
}
[System.Serializable]
public struct SomeScore
{
    public string titleText;
    public string beforeScore;
    public string afterScore;
}

[System.Serializable]
public struct NoScore
{
    public string titleText;
    public string beforeScore;
    public string afterScore;
}


public class ScoreTextManager : MonoBehaviour
{
    public Text titleText;
    public Text scoreText;
    public int scorescoreMultiplier;

    public FullScore fullScore;
    public SomeScore someScore;
    public NoScore noScore;

    public void ShowScore(int score, int maxScore)
    {
        if(score <= 0)
        {
            titleText.text = noScore.titleText;
            scoreText.text = noScore.beforeScore +" "+ score* scorescoreMultiplier + " " + noScore.afterScore;
        }
        if (score >= maxScore)
        {
            titleText.text = fullScore.titleText;
            scoreText.text = fullScore.beforeScore + " " + score* scorescoreMultiplier + " " + fullScore.afterScore;
        }
        if(score > 0 &&  score < maxScore)
        {
            titleText.text = someScore.titleText;
            scoreText.text = someScore.beforeScore + " " + score* scorescoreMultiplier + " " + someScore.afterScore;
        }
    }

}
