using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public int Day = 1;
    public int timer;
    public TextMeshProUGUI Temporizador;
    public GameObject boton;
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(TimerCountdown), 0);
        
    }

    public void TimerCountdown()
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
            timer = timer + 30;
            boton.SetActive(true);
        }

        
    }
    public void Regresar()
    {
        Invoke(nameof(TimerCountdown), 0);
        boton.SetActive(false);
    }
}
