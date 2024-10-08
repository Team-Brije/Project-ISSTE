using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectReset : MonoBehaviour
{
    public GameObject spawn;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Props") || other.CompareTag("TintaSello") || other.CompareTag("Ticket"))
        {
            other.gameObject.transform.position = spawn.transform.position;
        }
    }
}
