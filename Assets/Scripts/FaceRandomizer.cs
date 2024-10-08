using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceRandomizer : MonoBehaviour
{
    public GameObject facecube;
    public Aliens aliendata;
    Material faces;
    public void facerandom(){

        int numFace = Random.Range(0, aliendata.Faces.Length);
        faces = aliendata.Faces[numFace];
        facecube.GetComponent<MeshRenderer>().material = faces;
    }
    private void OnEnable()
    {
        facerandom();
    }

}
