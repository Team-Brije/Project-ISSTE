using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycastStamp : MonoBehaviour
{
    public static event Action<bool> OnInteract;

    public GameObject decalxd;
    public float distanceRay;
    public GameObject selloxd;
    Vector3 rxd;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward), out RaycastHit hitinfo, distanceRay))
        {
            Debug.Log("hay: "+hitinfo);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitinfo.distance, Color.red);
            decalxd.transform.position = hitinfo.point;
            decalxd.transform.rotation = selloxd.transform.rotation;
        }
        else
        {
            Debug.Log("no hay na: " + hitinfo.transform); Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitinfo.distance, Color.blue);
        }*/
    }

    public void activarSello(){
        if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward), out RaycastHit hitinfo, distanceRay))
        {
            Debug.Log("hay: "+hitinfo);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitinfo.distance, Color.red);
            decalxd.transform.position = hitinfo.point;
            decalxd.transform.rotation = selloxd.transform.rotation;
            //hitinfo.transform.gameObject.GetComponent<Ticket>().isTicketCorrrect;
            //if (hitinfo.transform.gameObject.CompareTag("")) ;
            Debug.Log(hitinfo.transform.gameObject.GetComponent<Ticket>().isTicketCorrrect);
            bool ticketstatus = hitinfo.transform.gameObject.GetComponent<Ticket>().isTicketCorrrect;
            OnInteract?.Invoke(ticketstatus);
        }
        else
        {
            Debug.Log("no hay na: " + hitinfo.transform); Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitinfo.distance, Color.blue);
        }

        
    }
}