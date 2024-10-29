using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSwithcer : MonoBehaviour
{
    public GameObject[] canvasxd;
    int index;
    void Start()
    {
        index = 0;
    }
    public void cambiarCanvas()
    {
        canvasxd[index].SetActive(false);
        if (index < 2)
        {
            index++;
            canvasxd[index].SetActive(true);
        }
        else if(index == 2)
        {
            index = 0;
            canvasxd[index].SetActive(true);
        }   
    }

}
