using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void SwitchPanel(GameObject gamin)
    {
        gameObject.SetActive(false);
        gamin.SetActive(true); 
    }
    public void play(int lvl){
        TimeManager.Day = lvl;
        SceneManager.LoadScene("Level");
    }
}
