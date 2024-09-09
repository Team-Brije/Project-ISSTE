using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatienceSystem : MonoBehaviour
{
    public static List<GameObject> queue = new List<GameObject>();
    public float waitSecs;
    [SerializeField] private float waitTime;
    public float maxWait;
    public float minWait;
    [SerializeField] private int position;

    private void Start()
    {
        queue.Add(gameObject);
        waitTime = UnityEngine.Random.Range(minWait, maxWait);
    }


    void Update()
    {
        position = queue.IndexOf(gameObject);
        waitSecs += Time.deltaTime;
        if (waitSecs >= waitTime) 
        {
            Fail();
        }
    }

    void Fail()
    {
        Debug.Log("se fue");
        queue.Remove(gameObject);
        Destroy(gameObject);
    }
}
