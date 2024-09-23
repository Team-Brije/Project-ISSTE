using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tintaActivate : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.TryGetComponent(out raycastStamp stamp))
        {
            Debug.Log("uwu");
            Debug.Log(other);
            stamp.tieneTinta = true;
        }
    }
}
