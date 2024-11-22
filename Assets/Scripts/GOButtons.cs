using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GOButtons : MonoBehaviour
{
    public void playAgain(){
        SceneManager.LoadScene("Level");
    }
    public void Menu(){
        SceneManager.LoadScene("MainMenu");
    }
}
