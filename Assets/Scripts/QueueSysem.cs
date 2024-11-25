using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class QueueSysem : MonoBehaviour
{
    public GameObject Ticket;
    public Transform Ticketpos;
    public GameObject Reservation;
    public Transform Reservationpos;
    public GameObject ID;
    public Transform IDpos;
    DataManager manager;
    public Transform initialpos;
    public Blacklist blacklist;

    BoxCollider BoxCollider;
    bool tpticket=true;

    private void Start()
    {
        manager = DataManager.Instance;
        initialpos = transform;
        BoxCollider = GetComponent<BoxCollider>();
        tpticket=true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Alien"))
        {
            AlienMOVEMENT.canMove = false;
            if (tpticket){
                Ticket.transform.position = Ticketpos.transform.position;  
                Reservation.transform.position = Reservationpos.transform.position;
                ID.transform.position = IDpos.transform.position;
                tpticket =false;
                Ticket.SetActive(true);
                if (manager.hasReservation) { Reservation.SetActive(true); }
                if (manager.hasID) { ID.SetActive(true); }        
            }
            if(other.gameObject.TryGetComponent(out AlienGeneration alien))
            {
                if(manager.hasID)
                {
                    ID.GetComponent<ID>().nameText.text = alien._name;
                    blacklist.AlienName = alien._name;
                    ID.GetComponent<ID>().speciesText.text = alien.specie;
                    blacklist.species = alien.specie;
                    blacklist.UpdateValues();
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Alien"))
        {
            AlienMOVEMENT.canMove = true;
            tpticket = true;
            //colliders.SetActive(false);
        }
    }

    public void Lift()
    {
        StartCoroutine(LiftGate());
    }

    public IEnumerator LiftGate()
    {
        gameObject.transform.position = new Vector3 (initialpos.position.x,2,initialpos.position.z);
        yield return new WaitForSeconds(0.4f);
        gameObject.transform.position = new Vector3(initialpos.position.x, 0, initialpos.position.z);
    }

}
