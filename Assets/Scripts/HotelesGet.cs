using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HotelesGet : MonoBehaviour
{
    public TimeManager managerTime;
    public TextMeshPro currentText;
    // Start is called before the first frame update
    void Start()
    {
        if (managerTime.CurDay.hasReservation)
        {
            if (managerTime.CurDay.Hotel1) { currentText.text += "<br>Hotel 1 Avialiable"; }
            if (managerTime.CurDay.Hotel2) { currentText.text += "<br>Hotel 2 Avialiable"; }
            if (managerTime.CurDay.Hotel3) { currentText.text += "<br>Hotel 3 Avialiable"; }
            if (managerTime.CurDay.Hotel4) { currentText.text += "<br>Hotel 4 Avialiable"; }
            else
            {
                currentText.text += "<br>No Hotels Today";
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
