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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
