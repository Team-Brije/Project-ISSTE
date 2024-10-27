using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forBlackHoleEffect : MonoBehaviour
{
    public GameObject blackHoleSpawn;
    public IEnumerator BlackHoleSpawnCor(){
        blackHoleSpawn.SetActive(true);
        yield return new WaitForSeconds(0.6f);
        blackHoleSpawn.SetActive(false);
    }

    public void BlackHoleSpawn(){
        blackHoleSpawn.SetActive(true);
    }
}
