using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeMusic : MonoBehaviour
{
    int index;
    public AudioClip[] mikumbias;
    public AudioSource mikumbiasource;
    // Start is called before the first frame update
    void Start()
    {
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void aumentar()
    {
        if (index > 2)
        {
            index = 0;
            cambio();
        }
        else
        {
            index++;
            cambio();
        }
    }

    public void cambio()
    {
        switch (index)
        {
            case 0:
                mikumbiasource.clip = mikumbias[index];
                mikumbiasource.Play();
                break;
            case 1:
                mikumbiasource.clip = mikumbias[index];
                mikumbiasource.Play();
                break;
            case 2:
                mikumbiasource.Stop();
                break;
            default:
                break;
        }
    }
}
