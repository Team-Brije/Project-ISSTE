using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicaTimeOut : MonoBehaviour
{
    public AudioSource mikumbia;
    void Start()
    {
        StartCoroutine(musicaTimeOutxd());
    }

    public IEnumerator musicaTimeOutxd(){
        yield return new WaitForSeconds(33);
        mikumbia.Play();
    }
}
