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
    public GameObject Alienmodel;
    public Transform spawner;
    AlienGeneration alienGeneration;

    
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
        Alienmodel = alienGeneration.model;
        Instantiate(Alienmodel, spawner);
        Alienlimit++;
        
    }
    public void Stopspawn()
    {
        Debug.Log("Alien limit reached");
        timer = 0;


    }
   
}
