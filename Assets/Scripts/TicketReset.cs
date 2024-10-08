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
    public Material[] materials;

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
            if (ticketstatus)
            {
                StartCoroutine(TiCorrect());
            }
            else
            {
                StartCoroutine(TiNoCorrect());
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

    public IEnumerator TiCorrect()
    {
        botonCorrect.GetComponent<MeshRenderer>().material = materials[1];
        yield return new WaitForSeconds(1);
        botonCorrect.GetComponent<MeshRenderer>().material = materials[0];
    }
    public IEnumerator TiNoCorrect()
    {
        botonCorrect.GetComponent<MeshRenderer>().material = materials[2];
        yield return new WaitForSeconds(1);
        botonCorrect.GetComponent<MeshRenderer>().material = materials[0];
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
