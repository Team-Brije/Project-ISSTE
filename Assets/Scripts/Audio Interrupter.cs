using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioInterrupter : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;

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
}
