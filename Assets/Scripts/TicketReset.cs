using System;
using System.Collections.Generic;
using UnityEngine;

public class TicketReset : MonoBehaviour
{
    public static event Action<bool, bool, bool> OnInteract;


    public QueueSysem queue;
    public Transform decalno;
    public Transform decalsi;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ticket")
        {
            bool ticketstatus = other.transform.gameObject.GetComponent<Ticket>().isTicketCorrrect;
            bool ticketcheck = other.transform.gameObject.GetComponent<Ticket>().hasTicketBeenChecked;
            bool StampAproved = other.transform.gameObject.GetComponent<Ticket>().lastStampUsed;

            OnInteract?.Invoke(ticketstatus, StampAproved, ticketcheck);

            other.gameObject.SetActive(false);
            PatienceSystem.wait.Remove(PatienceSystem.wait[0]);
            PatienceSystem.wait[0] += 15;
            queue.Lift();
            this.gameObject.SetActive(false);
            decalno.transform.parent = null;
            decalno.transform.position = new Vector3(99,99,99);
            decalsi.transform.parent = null;
            decalsi.transform.position = new Vector3(99,99,99);
            if(other.gameObject.TryGetComponent<Rigidbody>(out Rigidbody rb)){
                rb.velocity = Vector3.zero;
            }
            
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
