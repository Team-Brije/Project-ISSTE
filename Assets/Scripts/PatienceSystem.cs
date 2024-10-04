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
    [SerializeField] private float waitTime;
    [SerializeField] private float maxWait;
    [SerializeField] private float minWait;
    bool gone;

    private void Start()
    {
        //queue.Add(gameObject);
        gameManager = FindAnyObjectByType<GameManager>();
        ticket = GameObject.FindGameObjectWithTag("Ticket");
        queue = FindAnyObjectByType<QueueSysem>();
        if (TimeManager.Day == 0)
        {
            maxWait = 40;
            minWait = 20;
        }
        waitTime = UnityEngine.Random.Range(minWait, maxWait);
    }


    void Update()
    {
        waitSecs += Time.deltaTime;
        if (waitSecs >= waitTime) 
        {
            gone = true;
            Fail();
        }
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
}
