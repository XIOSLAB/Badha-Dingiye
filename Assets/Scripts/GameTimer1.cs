using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class GameTimer : MonoBehaviour
{
    public Text countDownText;
    public int startCountDown = 20;
    int currentCountDown;
    RectTransform rectTransform;
    bool gameIsPasued = false;
    AudioSource audioSource;
    public AudioClip timerAudioClip;
    public GameObject timeOutBoard;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        audioSource = GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        
    }
    public void StopTimer()
    {
        currentCountDown = 1;
        StopCoroutine(CountDownRoutine());
        rectTransform.DOScale(new Vector3(1f, 1f, 1f), .1f);
    }
    private IEnumerator CountDownRoutine()
    {
        while (currentCountDown > 0)
        {
            yield return new WaitForSeconds(1);

            if (gameIsPasued)
            {
                yield return null;
            }
            else
            {
                currentCountDown--;
                countDownText.text = currentCountDown.ToString();
                audioSource.PlayOneShot(timerAudioClip);
                rectTransform.DOScale(new Vector3(3f, 3f, 3f), .1f);
                rectTransform.DOScale(new Vector3(1f, 1f, 1f), .1f);
                if (currentCountDown <= 0)
                {
                    timeOutBoard.SetActive(true);
                }
            }
        }
    }
    public void ResetTime()
    {
        countDownText.text = currentCountDown.ToString();
        StartCoroutine(CountDownRoutine());
    }
}
