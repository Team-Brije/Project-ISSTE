using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playertpMenu : MonoBehaviour
{
    public GameObject playerxd;
    // Start is called before the first frame update
    void Start()
    {
        playerxd.transform.position = new Vector3(0.18f, -0.88f, 4.29f);
        playerxd.transform.rotation = new Quaternion(0, 163.7f, 0, 0);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
