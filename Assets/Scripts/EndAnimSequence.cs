using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndAnimSequence : MonoBehaviour
{
    public GameObject SpotLight;
    public Animator Hatch;
    public static bool gameOverSeq = false;
    public GameObject spawnerxd;
    void Awake()
    {
        SpotLight.SetActive(false);
        gameOverSeq = false;
    }
    private void Update() {
        if(gameOverSeq==true){
            gameOver();
        }
    }
    void gameOver(){
        StartCoroutine(GameOverAnim()); 
    }
    IEnumerator GameOverAnim(){
        SpotLight.SetActive(true);
        yield return new WaitForSeconds(2);
        Hatch.SetTrigger("Hatch");
        spawnerxd.SetActive(false);
    }

    private void OnDisable()
    {
        gameOverSeq = false;
    }
}
