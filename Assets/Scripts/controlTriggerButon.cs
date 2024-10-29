using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlTriggerButon : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Buton"))
        {
            if (other.TryGetComponent<Animator>(out Animator anim))
            {
                anim.SetTrigger("Push");
            }
        }
    }
}
