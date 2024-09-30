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
    public static int Day = 0;
    private int timer;
    private static   int begTime = 5 ;
    private int extraTime = 5;

    private bool playPressed = false;

    //Variables For Ui
    public TextMeshProUGUI Temporizador;
    public GameObject boton;
    public GameObject PlayButton;

    public DayConfig[] dayList;
    
    // Start is called before the first frame update
    void Start()
    {
        if (Day == 0)
        {

            timer = begTime;
        }else
        {
            begTime = begTime + extraTime;
            timer = begTime;
        }
        Temporizador.text = timer.ToString();
        Debug.Log(begTime);

        TimerCountdown();
        DaySelector();


    }

    public void TimerCountdown()
    {
        if (playPressed == true)
        {
            timer--;
            Temporizador.text = timer.ToString();



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

        } else
        {
            Invoke(nameof(TimerCountdown), 1);
        }


    }
    public void Regresar()
    {
        //Invoke(nameof(TimerCountdown), 0);
        boton.SetActive(false);
        SceneManager.LoadScene("graybox");
    }

    public void Play()
    {
        PlayButton.SetActive(false);
        playPressed = true;
    }

    void DaySelector()
    {
        if (dayList.Length > 0)
        {
            DayConfig currentDay = dayList[Day];
            DataManager.Instance.ReceiveDay(currentDay);
        }
    }
}
