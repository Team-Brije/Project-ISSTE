using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TimerPatienceUI : MonoBehaviour
{
    public Image _image;
    public TextMeshProUGUI time;
    public Animator _animator;
    [SerializeField] private Gradient timerGradient;
    private float count;
    public int id;
    public PatienceSystem timeLeft;
    public TimerPatienceUI timer1, timer2, timer3;
    public float initTime;

    private void Start()
    {
        _image = GetComponent<Image>();
        GetTime();
    }
    private void Update()
    {
        if (timeLeft.wait.Count != 0)
        {
            _image.fillAmount = (1/initTime) * (timeLeft.wait[id - 1] - timeLeft.waitSecs);
            time.text =(timeLeft.wait[id - 1] - timeLeft.waitSecs).ToString("F0");
        }
        if ((timeLeft.wait[id - 1] - timeLeft.waitSecs) <= 0) 
        { 
            GetTime(); 
        }
        time.color = timerGradient.Evaluate(_image.fillAmount);
        _image.color = timerGradient.Evaluate(_image.fillAmount);
    }

    private void GetTime()
    {
        initTime = timeLeft.wait[id - 1] - timeLeft.waitSecs;
    }

    public void PassTime()
    {
        if(id == 1) initTime = timer2.initTime;
        else if(id == 2) initTime = timer3.initTime;
        else if (id == 3) GetTime();
    }
}
