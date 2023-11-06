using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Narrator : MonoBehaviour
{
    public AudioClip audioClip;
    public bool activeOnEnable = true;
    public bool stopOnDisable = true;
    public float waitStartTime;

    private void OnEnable()
    {
        StartCoroutine(PlayAudioRoutine());
    }

    private void OnDisable()
    {
        
        VoiceAudioManager.instance.StopAudio();
    }

    public void PlayAudio()
    {
        VoiceAudioManager.instance.PlayAudio(audioClip);
    }

    IEnumerator PlayAudioRoutine()
    {
        yield return new WaitForSeconds(waitStartTime);
        PlayAudio();
    }
}
