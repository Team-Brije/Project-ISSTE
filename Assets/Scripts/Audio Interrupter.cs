using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioInterrupter : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;
    public musicaTimeOut timeoutxd;
    bool hasPlayed;

    public void Start()
    {
        hasPlayed = false;
    }

    public void StopAudio()
    {
        if (audioSource.isPlaying && !hasPlayed)
        {
            hasPlayed = true;
            audioSource.Stop();
            audioSource.clip = clip; 
            audioSource.Play();
        }
    }

    public void startMusic()
    {
        if (timeoutxd.enabled)
        {
            timeoutxd.PlaySong();
        }
    }
}
