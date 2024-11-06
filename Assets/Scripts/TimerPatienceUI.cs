using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TimerPatienceUI : MonoBehaviour
{
    public Image _image;
    [SerializeField] private Gradient timerGradient;
    public float count;
    public int id;
    public PatienceSystem timeLeft;

    private void Start()
    {
        _image = GetComponent<Image>();
    }
    private void Update()
    {
        if (id == 1 && timeLeft.wait.Count != 0)
        {
            _image.fillAmount = (timeLeft.wait[0] / 1) * (timeLeft.wait[0] - timeLeft.waitSecs);
        }
        if (id == 2 && timeLeft.wait.Count != 0)
        {
            _image.fillAmount = (timeLeft.wait[1] / 1) * (timeLeft.wait[0] - timeLeft.waitSecs);
        }
        if (id == 3 && timeLeft.wait.Count != 0)
        {
            _image.fillAmount = (timeLeft.wait[2]/1)*(timeLeft.wait[0] - timeLeft.waitSecs);
        }
        _image.color = timerGradient.Evaluate(_image.fillAmount);
    }
}
