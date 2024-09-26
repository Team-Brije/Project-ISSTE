using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Day/Day Config", order = 1)]
public class DayConfig : ScriptableObject
{
    [Header("DocumentVariables")]
    public bool hasReservation;
    public bool hasXRay;
    public bool hasBlacklist;

    [Header("Date Variables")]
    public int day;
    public int month;
    public int year;

    [Header("Reservation Variables")]

    public bool Hotel1;
    public bool Hotel2;
    public bool Hotel3;
    public bool Hotel4;



    [Header("Ticket Difficulty Variables")]

    public int poolSize;
    public int DayPercentage, MonthPercentage, YearPercentage;
    public int dayRange;
    public int monthRange;
    public int yearRange;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
