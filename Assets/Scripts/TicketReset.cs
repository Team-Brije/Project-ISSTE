using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicketReset : MonoBehaviour
{
    public QueueSysem queue;
    public Transform decalno;
    public Transform decalsi;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ticket")
        {
            other.gameObject.SetActive(false);
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
