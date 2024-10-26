using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Blacklist/Blacklist Config", order = 2)]
public class BlacklistVariables : ScriptableObject
{
    public string[] NAME_ONLY;
    public string[] SPECIES_ONLY;
    [Header("ESCRIBIR NOMBRE Y PLANETA EJ (Juan.Human)")]
    public string[] NAME_AND_SPECIES;
}
