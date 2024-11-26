using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tintaActivate : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.TryGetComponent(out raycastStamp stamp))
        {
            stamp.tieneTinta = true;
        }
    }
}
