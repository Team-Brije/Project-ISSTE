using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatienceSystem : MonoBehaviour
{
    public QueueSysem queue;
    private GameManager gameManager;
    public float waitSecs;
    public GameObject ticket;
     public static float waitTime;
     public static float maxWait;
    public  static float minWait;

    public static DayConfig dayConfigFile;

    bool gone;

    private void Start()
    {
        //queue.Add(gameObject);
        gameManager = FindAnyObjectByType<GameManager>();
        ticket = GameObject.FindGameObjectWithTag("Ticket");
        queue = FindAnyObjectByType<QueueSysem>();
        
        
    }


    void Update()
    {
        waitSecs += Time.deltaTime;
        if (waitSecs >= waitTime) 
        {
            gone = true;
            Fail();
        }

        Debug.Log("Min time: " + minWait);
        Debug.Log("Max time: " + maxWait);
        Debug.Log("Wait time: " + waitTime);

    }

    void Fail()
    {
        if (gone)
        {
            gone = false;
            Debug.Log("se fue");
            ticket.SetActive(false);
            gameManager.BadCheck();
            queue.Lift();
        }
    }
    public static void ReceiveDay(DayConfig currentDay)
    {
        dayConfigFile = currentDay;
        maxWait = dayConfigFile.maxTime;
        minWait = dayConfigFile.minTime;
        waitTime = UnityEngine.Random.Range(minWait, maxWait);

    }
}
