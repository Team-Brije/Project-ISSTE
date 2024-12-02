using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioGetter : MonoBehaviour
{
    AudioSource audiosource;
    DataManager manager;
    public musicaTimeOut Music;
    // Start is called before the first frame update
    void Start()
    {
        manager = DataManager.Instance;
        audiosource = GetComponent<AudioSource>();
        Invoke(nameof(GetAudio), 0.05f);
    }

    public void GetAudio()
    {
        audiosource.clip = manager.voiceline;
        audiosource.Play();
        Music.enabled = true;
    }
}
