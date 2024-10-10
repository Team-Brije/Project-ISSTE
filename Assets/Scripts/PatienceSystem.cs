using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatienceSystem : MonoBehaviour
{
    public QueueSysem queue;
    private GameManager gameManager;
    public float waitSecs;
    public static float waitTime;

    public static float maxWait;
    public static float minWait;

    public static bool start = false;
    public List<float> wait;

    public static DayConfig dayConfigFile;
    public GameObject ticket;

    bool gone;

    private void Start()
    {
        //queue.Add(gameObject);
        gameManager = FindAnyObjectByType<GameManager>();
        queue = FindAnyObjectByType<QueueSysem>();
    }


    void Update()
    {
        if (start) waitSecs += Time.deltaTime;
        else waitSecs = 0;
        for (int i = 0; i < wait.Count; i++)
        {
            if (wait[i] <= waitSecs && wait!=null && start)
            {
                wait.Remove(wait[i]);
                Fail();
                waitTime = UnityEngine.Random.Range(minWait, maxWait);
                if (i == 0)
                {
                    ticket.SetActive(false);
                    if (ticket.TryGetComponent<Rigidbody>(out Rigidbody rb))
                    {
                        rb.velocity = Vector3.zero;
                    }
                    wait[0] += 15;
                    queue.Lift();
                }
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
        Debug.Log("se fue");
        gameManager.BadCheck();
    }
    public static void ReceiveDay(DayConfig currentDay)
    {
        dayConfigFile = currentDay;
        maxWait = dayConfigFile.maxTime;
        minWait = dayConfigFile.minTime;
    }
}
