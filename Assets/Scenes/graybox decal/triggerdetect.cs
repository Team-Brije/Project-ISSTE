using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerdetect : MonoBehaviour
{
    public static GameObject objectPos;
    public static bool onObject;
    private void OnTriggerStay(Collider other)
    {
        objectPos = other.gameObject;
        onObject = true;
    }
    private void OnTriggerExit(Collider other)
    {
        objectPos = null;
    }
}
