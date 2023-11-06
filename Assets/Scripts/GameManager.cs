using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instances;
    public int score;
    public int selectedCharacter;
    public Text scoreText;
    public Image[] character;
    public Image player;
    public Sprite boySprite;
    public Sprite girlSprite;
    public GameObject girl;
    public GameObject boy;
    public GameObject timeOutBoard;
    public Timer[] timer;
    private void Awake()
    {
        if (instances == null)
        {
            instances = this;
        }
    }
    private void Start()
    {
        score = 60;
        SetCharacter(selectedCharacter);
    }
    public void SetCharacter(int id)
    {
        girl.SetActive(false);
        boy.SetActive(false);
        selectedCharacter = id;
        if(selectedCharacter == 0)
        {
            girl.SetActive(true);
            foreach (Image item in character)
            {
                item.sprite = girlSprite;
            }
        }
        else
        {
            boy.SetActive(true);
            foreach (Image item in character)
            {
                item.sprite = boySprite;
            }
        }
    }

    public void AddScore(int scoreToAdd)
    {
        foreach (Timer timer in timer)
        {
            if (timer.timeOut)
            {
                timer.timeOut = false;
                return;
            }
        }

        int a = score;
        score = a + scoreToAdd;
        scoreText.text = score.ToString();
    }





    public void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
