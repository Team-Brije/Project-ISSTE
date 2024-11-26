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
            if (managerTime.CurDay.Hotel1) { currentText.text += "Open<br>"; } else { currentText.text += "Closed<br>"; }
            if (managerTime.CurDay.Hotel2) { currentText.text += "Open<br>"; } else { currentText.text += "Closed<br>"; }
            if (managerTime.CurDay.Hotel3) { currentText.text += "Open<br>"; } else { currentText.text += "Closed<br>"; }
            if (managerTime.CurDay.Hotel4) { currentText.text += "Open"; } else { currentText.text += "Closed"; }
        }
        else
            {
                currentText.text += "Closed<br>Closed<br>Closed<br>Closed";
            }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
