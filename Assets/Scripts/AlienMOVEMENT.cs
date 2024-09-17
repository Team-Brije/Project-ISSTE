using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AlienMOVEMENT : MonoBehaviour
{
    public float time = 0.0f;
    public static Vector3 newPosition;
    public float duration;
    public Vector3 booth;
    public Vector3 Alien;
    public GameObject boothObj;

 
    void Start()
    {
        boothObj = GameObject.Find("SpawnLeft");
        newPosition = boothObj.transform.position;
        Alien = transform.position;
       
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        float percentage = time / duration;
        transform.position = Vector3.Lerp(Alien, newPosition , percentage);
    }
   
}
