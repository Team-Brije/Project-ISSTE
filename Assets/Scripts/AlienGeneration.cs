using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienGeneration : MonoBehaviour
{
    public Aliens aliendata;
    string name;
    string specie;
    GameObject model;
    public void alienRandomize()
    {
        int numName = Random.Range(0,aliendata.AlienName.Length);
        int numType = Random.Range(0,aliendata.AlienType.Length);
        int numModel = Random.Range(0, aliendata.Model.Length);
        

        
        name = aliendata.AlienName[numName];
        specie = aliendata.AlienType[numType];
        model = aliendata.Model[numModel];
    }
    private void OnEnable()
    {
        alienRandomize();
        Debug.Log(name);
        Debug.Log(specie);
        Instantiate(model,this.transform);


    }
   public void aliendespawn()
    {
        Destroy(this.transform.GetChild(0).gameObject);
    }
    private void OnDisable()
    {
        aliendespawn();
    }



}
