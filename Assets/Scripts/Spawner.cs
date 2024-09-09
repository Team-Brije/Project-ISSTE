using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float timer;
    public float timerset;
    public int Alienlimit;
    private bool Spawneractive = true;
   
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timerset && Spawneractive) 
        {
            spawnalien();
            timer = 0;
        }
        if(Alienlimit == 5)
        {
            Spawneractive= false;
            Stopspawn();
        }
        if (Alienlimit < 5)
        {
            Spawneractive = true;
            
        }   
        
    }
    public void spawnalien()
    {
        Debug.Log("Alien spawned");
        Alienlimit++;
        
    }
    public void Stopspawn()
    {
        Debug.Log("Alien limit reached");
        timer = 0;


    }
}
