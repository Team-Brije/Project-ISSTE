using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycastStamp : MonoBehaviour
{
    public static event Action<bool, bool, bool> OnInteract;

    public GameObject decalxd;
    public float distanceRay;
    public GameObject selloxd;
    public bool StampAproved;
    public bool tieneTinta;
    public Material[] materials;
    public GameObject selloDown;
    public Animator animator;
    public Collider TicketBucket;
    // Start is called before the first frame update
    void Start()
    {
        tieneTinta = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (tieneTinta)
        {
            selloDown.GetComponent<MeshRenderer>().material = materials[1];
            activarSello();
        }
    }

    public void activarSello(){
        if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.down), out RaycastHit hitinfo, distanceRay))
        {
            if (!(hitinfo.transform.gameObject.CompareTag("TintaSello")))
            {

                //Debug.Log("hay: "+hitinfo);
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hitinfo.distance, Color.red);
                decalxd.transform.position = hitinfo.point;
                decalxd.transform.rotation = selloxd.transform.rotation;
                decalxd.transform.parent = hitinfo.transform;
                ///hitinfo.transform.gameObject.GetComponent<Ticket>().isTicketCorrrect;
                //Debug.Log(hitinfo.transform.gameObject.GetComponent<Ticket>().isTicketCorrrect);
                if (hitinfo.transform.gameObject.CompareTag("Ticket"))
                {
                    //bool ticketstatus = hitinfo.transform.gameObject.GetComponent<Ticket>().isTicketCorrrect;
                    //bool ticketcheck = hitinfo.transform.gameObject.GetComponent<Ticket>().hasTicketBeenChecked;
                    //OnInteract?.Invoke(ticketstatus, StampAproved, ticketcheck);

                    bool ticketcheck = hitinfo.transform.gameObject.GetComponent<Ticket>().hasTicketBeenChecked;

                    if (!ticketcheck)
                    {
                        hitinfo.transform.gameObject.GetComponent<Ticket>().lastStampUsed = StampAproved;
                        hitinfo.transform.gameObject.GetComponent<Ticket>().hasTicketBeenChecked = true;
                        TicketBucket.enabled = true;
                        animator.SetTrigger("IN");
                    }

                }
                selloDown.GetComponent<MeshRenderer>().material = materials[0];
                tieneTinta = false;
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitinfo.distance, Color.blue);
        }

        
    }
}
