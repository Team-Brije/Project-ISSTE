using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class QueueSysem : MonoBehaviour
{
    public GameObject Ticket;
    public Transform Ticketpos;

    public Transform initialpos;

    BoxCollider BoxCollider;
    bool tpticket=true;

    private void Start()
    {
        initialpos = transform;
        BoxCollider = GetComponent<BoxCollider>();
        tpticket=true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Alien"))
        {
            AlienMOVEMENT.canMove = false;
            PatienceSystem.wait[0] += 15;
            if (tpticket){
            Ticket.transform.position = Ticketpos.transform.position;  
            tpticket=false;
            Ticket.SetActive(true);
            }
            print("uwu");
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
        Debug.Log("Gaming");
        gameObject.transform.position = new Vector3(initialpos.position.x, 0, initialpos.position.z);
    }

}
