using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class decalControl : MonoBehaviour
{

    public GameObject decalxd;
    public GameObject hitPos;
    public GameObject rotatioinpos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void decalPut()
    {
        Debug.Log("auisdhaiusdh");
        Debug.Log(triggerdetect.objectPos);
        if(triggerdetect.objectPos != null)
        {
            decalxd.transform.position = hitPos.transform.position;
            //decalxd.transform.localRotation = rotatioinpos.transform.localRotation;
            decalxd.transform.parent = triggerdetect.objectPos.transform;
        }
    }
}
