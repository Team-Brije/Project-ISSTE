using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public int timer;
    public TextMeshProUGUI Temporizador;
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
        }
    }
}
