using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicketReset : MonoBehaviour
{
    public static event Action<bool, bool, bool> OnInteract;


    public QueueSysem queue;
    public Transform decalno;
    public Transform decalsi;

    public GameObject botonCorrect;
    public PatienceSystem patienceSystem;
    public TimerPatienceUI ui1, ui2, ui3;

    public GameObject Reservation, ID;
    Collider boxCollider;
    DataManager manager;

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        manager = DataManager.Instance;
        boxCollider = gameObject.GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ticket")
        {
            bool ticketstatus = other.transform.gameObject.GetComponent<Ticket>().isTicketCorrrect;
            bool ticketcheck = other.transform.gameObject.GetComponent<Ticket>().hasTicketBeenChecked;
            bool StampAproved = other.transform.gameObject.GetComponent<Ticket>().lastStampUsed;

            OnInteract?.Invoke(ticketstatus, StampAproved, ticketcheck);
            botonCorrect.GetComponent<ColorChangeCorrect>().corutinesxd(ticketstatus,StampAproved);
            other.gameObject.SetActive(false);
            patienceSystem.wait.RemoveAt(0);
            patienceSystem.wait[0] += 15;
            PatienceSystem.waitTime = UnityEngine.Random.Range(PatienceSystem.minWait, PatienceSystem.maxWait);
            patienceSystem.wait.Add(PatienceSystem.waitTime + patienceSystem.waitSecs);
            ui1.PassTime();
            ui2.PassTime();
            ui3.PassTime();
            queue.Lift();
            boxCollider.enabled = false;
            //this.gameObject.SetActive(false);
            animator.SetTrigger("OUT");
            if (manager.hasReservation) { Reservation.SetActive(false); }
            if (manager.hasID) { ID.SetActive(false); }
            decalno.transform.parent = null;
            decalno.transform.position = new Vector3(99,99,99);
            decalsi.transform.parent = null;
            decalsi.transform.position = new Vector3(99,99,99);
            if(other.gameObject.TryGetComponent<Rigidbody>(out Rigidbody rb)){
                rb.velocity = Vector3.zero;
            }
            
        }
    }


    

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
