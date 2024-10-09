using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienPositionReset : MonoBehaviour
{
    public Transform resetPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.transform.position = resetPoint.position;
        other.gameObject.GetComponent<AlienGeneration>().aliendespawn();
        other.gameObject.GetComponent<AlienGeneration>().alienRandomize();
        Instantiate(other.gameObject.GetComponent<AlienGeneration>().model,other.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
