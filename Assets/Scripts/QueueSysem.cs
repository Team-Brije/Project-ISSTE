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

    private void Start()
    {
        initialpos = transform;
        BoxCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Alien"))
        {
            AlienMOVEMENT.canMove = false;
            Ticket.SetActive(true);
            Ticket.transform.position = Ticketpos.transform.position;  
            print("uwu");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Alien"))
        {
            AlienMOVEMENT.canMove = true;
            //colliders.SetActive(false);
            print("uwu");
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
