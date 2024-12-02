using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicaTimeOut : MonoBehaviour
{
    public AudioSource mikumbia;
    public AudioSource Voice;
    void Start()
    {
        //StartCoroutine(musicaTimeOutxd());
    }

    private void Update()
    {
        if (Voice.isPlaying == false)
        {
            PlaySong();
        }
    }

    public void PlaySong()
    {
        mikumbia.Play();
        this.gameObject.GetComponent<changeMusic>().enabled = true;
        this.enabled = false;
    }

    /*public IEnumerator musicaTimeOutxd(){
        yield return new WaitForSeconds(33);
        mikumbia.Play();
    }*/
}
