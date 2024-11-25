using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndAnimSequence : MonoBehaviour
{
    public GameObject SpotLight;
    public Animator Hatch;
    public static bool gameOverSeq = false;
    public GameObject spawnerxd;
    public GameObject player;
    public bool push;
    void Awake()
    {
        push = true;
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
        yield return new WaitForSeconds(1);
        spawnerxd.SetActive(false);
        player.transform.Translate(0, -0.1f, 0);
    }

    private void OnDisable()
    {
        gameOverSeq = false;
    }
}
