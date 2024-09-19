using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class QueueSysem : MonoBehaviour
{
    public GameObject colliders;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Alien"))
        {
            AlienMOVEMENT.canMove = false;
            colliders.SetActive(true);
            print("uwu");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Alien"))
        {
            AlienMOVEMENT.canMove = true;
            colliders.SetActive(false);
            print("uwu");
        }
    }
    
}
