using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Alien/Alien Type", order = 1)]
public class Aliens : ScriptableObject
{
    public string[] AlienType;
    public string[] AlienName;
    public string[] Origin;
    public GameObject[] Model;
}


