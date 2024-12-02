using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playertpMenu : MonoBehaviour
{
    public GameObject playerxd;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("adsadasd");
        playerxd.transform.localPosition = new Vector3(0.09f, -0.24f, -0.006f);
        playerxd.transform.localEulerAngles = new Vector3(0, 42.27f, 0);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
