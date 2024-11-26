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
    public static bool canMove = true; 
    public float speed = 10f;
    private Rigidbody rb;
   


    void OnEnable()
    {
        canMove = true;
        boothObj = GameObject.Find("SpawnLeft");
        newPosition = boothObj.transform.position;
        Alien = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canMove)
        {
            time += Time.deltaTime;
            float percentage = time / duration;
            Vector3 newPosition = rb.position + Vector3.left * speed * Time.fixedDeltaTime;
            // Move the box to the new position
            this.rb.MovePosition(newPosition);
        }
            
        

    }

}
