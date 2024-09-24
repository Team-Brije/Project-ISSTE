using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    //Variables for Day system
    public static int Day = 1;
    private int timer;
    private static   int begTime = 5 ;
    private int extraTime = 5;

    //Variables For Ui
    public TextMeshProUGUI Temporizador;
    public GameObject boton;
    public GameObject PlayButton;
    
    // Start is called before the first frame update
    void Start()
    {
        if (Day == 1)
        {

            timer = begTime;
        }else
        {
            begTime = begTime + extraTime;
            timer = begTime;
        }
        Temporizador.text = timer.ToString();
        Debug.Log(begTime);
        
    }

    public void TimerCountdown()
    {
        timer--;
        Temporizador.text = timer.ToString();

        PlayButton.SetActive(false);

        if (timer != 0)
        {
            Invoke(nameof(TimerCountdown), 1);
        }
        else
        {
            Debug.Log("Se acabo el dia");
            //timer = timer + extraTime;
            boton.SetActive(true);
            Day++;
            //SceneManager.LoadScene("Timer");

        }


    }
    public void Regresar()
    {
        //Invoke(nameof(TimerCountdown), 0);
        boton.SetActive(false);
        SceneManager.LoadScene("Timer");
    }

    public void Play()
    {
        TimerCountdown();
    }
}
