using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private void Awake()
    {
        raycastStamp.OnInteract += HandleTicket;
    }


    void HandleTicket(bool isTicketCorrect, bool isApprovedStamp)
    {
        if (isTicketCorrect && isApprovedStamp)
        {
            Debug.Log("GOOD :)");
        } else if (!isTicketCorrect && !isApprovedStamp)
        {
            Debug.Log("GOOD 2 :)");
        } else {
            Debug.Log("BAD :(");
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
