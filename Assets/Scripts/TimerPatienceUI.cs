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
    public float count;
    public int id;
    public PatienceSystem timeLeft;
    public static bool isOnAnimation;

    private void Start()
    {
        _image = GetComponent<Image>();
    }
    private void Update()
    {
        if (timeLeft.wait.Count != 0 && !isOnAnimation)
        {
            _image.fillAmount = (1/timeLeft.wait[id-1]) * (timeLeft.wait[id-1] - timeLeft.waitSecs);
            time.text =(timeLeft.wait[id-1] - timeLeft.waitSecs).ToString("F0");
            if (timeLeft.wait[id-1] <= timeLeft.waitSecs) 
            {
                
            }
        }
        time.color = timerGradient.Evaluate(_image.fillAmount);
        _image.color = timerGradient.Evaluate(_image.fillAmount);
    }
}
