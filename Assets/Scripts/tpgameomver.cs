using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tpgameomver : MonoBehaviour
{
    public GameObject xrtransform;
    // Start is called before the first frame update
    void Start()
    {
        xrtransform.transform.position = new Vector3(0.05f, -0.1f, 0);
        xrtransform.transform.eulerAngles = new Vector3(0, 62.93f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
