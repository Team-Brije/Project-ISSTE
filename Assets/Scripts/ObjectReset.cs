using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectReset : MonoBehaviour
{
    public GameObject spawn;
    public GameObject blackHole;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Props") || other.CompareTag("TintaSello") || other.CompareTag("Ticket"))
        {
            Instantiate(blackHole, other.transform.position, Quaternion.identity);
            if(other.gameObject.TryGetComponent<forBlackHoleEffect>(out forBlackHoleEffect bheffect)) bheffect.BlackHoleSpawn();
            other.gameObject.transform.position = spawn.transform.position;
        }
    }
}
