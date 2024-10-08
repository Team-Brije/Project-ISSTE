using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeCorrect : MonoBehaviour
{
    public Material[] materials;
    public void corutinesxd(bool ticketstatus, bool stampap) {
        if (ticketstatus && stampap)
        {
            StartCoroutine(TiCorrect());
        }
        else if (!ticketstatus && !stampap)
        {
            StartCoroutine(TiCorrect());
        }
        else
        {
            StartCoroutine(TiNoCorrect());
        }
    }
    public IEnumerator TiCorrect()
    {
        gameObject.GetComponent<MeshRenderer>().material = materials[1];
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<MeshRenderer>().material = materials[0];
    }
    public IEnumerator TiNoCorrect()
    {
        gameObject.GetComponent<MeshRenderer>().material = materials[2];
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<MeshRenderer>().material = materials[0];
    }
}
