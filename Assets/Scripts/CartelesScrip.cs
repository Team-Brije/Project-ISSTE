using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartelesScrip : MonoBehaviour
{
    public GameObject timemangerobj;
    public GameObject carteles2;
    public GameObject carteles3;
    void Update()
    {
        if(timemangerobj.GetComponent<TimeManager>().CurDay != null){
            switch(timemangerobj.GetComponent<TimeManager>().CurDay.name){
                case "Day1":
                    carteles2.SetActive(false);
                    carteles3.SetActive(false);
                    Destroy(this);
                    break;
                case "Day2":
                    carteles3.SetActive(true);
                    carteles2.SetActive(false);
                    Destroy(this);
                    break;
                case "Day3":
                    carteles2.SetActive(true);
                    carteles3.SetActive(true);
                    Destroy(this);
                    break;
                case "Day4":
                    carteles2.SetActive(true);
                    carteles3.SetActive(true);
                    Destroy(this);
                    break;
                default:
                    carteles2.SetActive(true);
                    carteles3.SetActive(true);
                    Destroy(this);
                    break;
        }
        }
    }
}
