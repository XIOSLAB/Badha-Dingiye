using DG.Tweening;
using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    public Text countDownText;
    public bool startCountDownOnEnable = true;
    public int countDownStartAt = 20;
    public int currentCountDown;
    RectTransform rectTransform;
    AudioSource audioSource;
    public AudioClip timerAudioClip;
    public GameObject timeOutBoard;
    public GameObject board;
    public bool timeOut = false;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        audioSource = GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        currentCountDown = countDownStartAt;
        if (!startCountDownOnEnable) { return; }
        StopCoroutine(CountDownRoutine());
        StartCoroutine(CountDownRoutine());
    }

    public void StartTimer()
    {
        currentCountDown = countDownStartAt;
        StopCoroutine(CountDownRoutine());
        StartCoroutine(CountDownRoutine());
    }
    private IEnumerator CountDownRoutine()
    {
        timeOut = false;

        countDownText.text = currentCountDown.ToString();
        while(currentCountDown > 0)
        {
            yield return new WaitForSeconds(1);

            currentCountDown--;
            countDownText.text = currentCountDown.ToString();
            audioSource.PlayOneShot(timerAudioClip);
            rectTransform.DOScale(new Vector3(3f, 3f, 3f), .1f);
            rectTransform.DOScale(new Vector3(1f, 1f, 1f), .1f);
            if (currentCountDown <= 0)
            {
                StopClock();
            }
        }
    }

    public void StopClock()
    {
        timeOut = true;
        board.SetActive(true);
        timeOutBoard.SetActive(true);
    }
    private void OnDisable()
    {
        timeOut = false;
    }
}
