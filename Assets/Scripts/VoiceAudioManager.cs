using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VoiceAudioManager : MonoBehaviour
{
    public static VoiceAudioManager instance;
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (instance == null)
        {
            instance = this;
        }
    }

    public void PlayAudio(AudioClip audioClip)
    {
        audioSource.Stop();
        audioSource.PlayOneShot(audioClip);
    }
    public void StopAudio()
    {
        audioSource.Stop();
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
