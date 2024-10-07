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
    public  static List<float> wait;

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
        Debug.Log(wait);
        waitSecs += Time.deltaTime;
        for (int i = 0; i < wait.Count; i++)
        {
            if (wait[i] >= waitTime && wait!=null)
            {
                wait.Remove(wait[i]);
                Fail();
                waitTime = UnityEngine.Random.Range(minWait, maxWait);
                wait[0] += 15;
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
        for (int i = 0; i < 3; i++)
        {
            waitTime = UnityEngine.Random.Range(minWait, maxWait);
            wait.Add(waitTime);
        }
    }
}
