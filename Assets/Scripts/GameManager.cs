using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Date Variables")]
    public int day;
    public int month;
    public int year;

    [Header("Ticket Difficulty Variables")]

    public int dayNumbers;
    public int monthNumbers;
    public int yearNumbers;
    public int DayPercentage, MonthPercentage, YearPercentage;
    public int minimumDayValue, maximumDayValue;
    public int minimumMonthValue, maximumMonthValue;
    public int minimumYearValue, maximumYearValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public static void CheckTicket()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
