using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

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

    public DayConfig CurDay;

    public GameObject spwnAlns;
    public GameObject ticket;
    public GameManager gameManager;
    public PatienceSystem patience;
    //day display
    public TextMeshProUGUI dia;
    




    // Start is called before the first frame update
    void Start()
    {
        ticket = GameObject.FindGameObjectWithTag("Ticket");
        //Temporizador.text = timer.ToString();
        Debug.Log(begTime);
        TimerCountdown();
        DaySelector();

        Invoke(nameof(SetData), 0.1f);
        
        gameManager = FindAnyObjectByType<GameManager>();


    }

    public void TimerCountdown()
    {
        if (playPressed == true)
        {

            timer--;

            SetData();

            //Temporizador.text = timer.ToString();

            spwnAlns.SetActive(true);


            if (timer != 0)
            {
                Invoke(nameof(TimerCountdown), 1);
            }
            else
            {
                Debug.Log("Se acabo el dia");
                //timer = timer + extraTime;
                //ticket.SetActive(false);
                PatienceSystem.start = false;
                boton.SetActive(true);
                spwnAlns.SetActive(false);
                Day++;
                AlienMOVEMENT.canMove = true;
                
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
        SceneManager.LoadScene("Level");
    }

    public void Play()
    {
        PlayButton.SetActive(false);
        playPressed = true;
        patience.wait.Clear();
        PatienceSystem.waitTime = UnityEngine.Random.Range(PatienceSystem.minWait, PatienceSystem.maxWait);
        patience.wait.Add(PatienceSystem.waitTime);
        PatienceSystem.waitTime = UnityEngine.Random.Range(PatienceSystem.minWait, PatienceSystem.maxWait);
        patience.wait.Add(PatienceSystem.waitTime);
        PatienceSystem.waitTime = UnityEngine.Random.Range(PatienceSystem.minWait, PatienceSystem.maxWait);
        patience.wait.Add(PatienceSystem.waitTime);
        PatienceSystem.start = true;
    }

    void DaySelector()
    {
        if (dayList.Length > 0)
        {
            CurDay = dayList[Day];
            timer = CurDay.Time;    
            DayConfig currentDay = dayList[Day];
            DataManager.Instance.ReceiveDay(currentDay);
            PatienceSystem.ReceiveDay(currentDay);
            dia.text = currentDay.day.ToString()+"/"+currentDay.month.ToString()+"/"+currentDay.year.ToString();

        }
    }

    void SetData()
    {
        var timespan = TimeSpan.FromSeconds(timer);
        var minutes = timespan.Minutes;
        var seconds = timespan.Seconds;

        if (seconds < 10) { Temporizador.text = minutes + ":0" + seconds; }
        else { Temporizador.text = minutes + ":" + seconds; }
    }
}
