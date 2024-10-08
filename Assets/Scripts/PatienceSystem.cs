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
    public static float waitTime2;
    public static float waitTime3;

    public static float maxWait;
    public static float minWait;

    public static bool gotData = false;
    public static bool start = false;
    public List<float> wait;

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
        if (start)
        {
            wait.Add(waitTime);
            wait.Add(waitTime2);
            wait.Add(waitTime3);
        }
        if (gotData)waitSecs += Time.deltaTime;
        for (int i = 0; i < wait.Count; i++)
        {
            if (wait[i] <= waitSecs && wait!=null && gotData)
            {
                wait.Remove(wait[i]);
                //Fail();
                waitTime = UnityEngine.Random.Range(minWait, maxWait);
                //if(i==0)wait[0] += 15;
                wait.Add(waitTime + waitSecs);
            }
        }
    }

    private void OnApplicationQuit()
    {
        wait.Clear();
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
        waitTime2 = UnityEngine.Random.Range(minWait, maxWait);
        waitTime3 = UnityEngine.Random.Range(minWait, maxWait);
        gotData = true;
        start = true;
    }
}
