
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [Header("DocumentVariables")]
    [HideInInspector] public bool hasReservation;
    [HideInInspector] public bool hasXRay;
    [HideInInspector] public bool hasBlacklist;

    [Header("Date Variables")]
    [HideInInspector] public int day;
    [HideInInspector] public int month;
    [HideInInspector] public int year;

    [Header("Ticket Difficulty Variables")]

    [HideInInspector] public int poolSize;
    [HideInInspector] public int DayPercentage, MonthPercentage, YearPercentage;
    [HideInInspector] public int dayRange;
    [HideInInspector] public int monthRange;
    [HideInInspector] public int yearRange;

    [Header("Ticket Difficulty Variables")]
    [HideInInspector] public bool Hotel1;
    [HideInInspector] public bool Hotel2;
    [HideInInspector] public bool Hotel3;
    [HideInInspector] public bool Hotel4;


    public DayConfig dayConfigFile;

    private static DataManager instance;

    public static DataManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject dataManager = new GameObject();
                instance = dataManager.AddComponent<DataManager>();
                dataManager.name = "Data Manager Singleton";
            }
            return instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if(instance != null && instance != this) 
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }

        SetValues();

        DayPercentage = DayPercentage + 30;
        MonthPercentage = MonthPercentage + 30;
        YearPercentage = YearPercentage + 30;

        if (DayPercentage > 100)
        {
            DayPercentage -= 30;
        }
        if (MonthPercentage > 100)
        {
            MonthPercentage -= 30;
        }
        if (YearPercentage > 100)
        {
            YearPercentage -= 30;
        }
    }
    
    public void SetValues()
    {
        hasReservation = dayConfigFile.hasReservation;
        hasXRay = dayConfigFile.hasXRay;
        hasBlacklist = dayConfigFile.hasBlacklist;

        day = dayConfigFile.day;
        month = dayConfigFile.month;
        year = dayConfigFile.year;

        poolSize = dayConfigFile.poolSize;
        DayPercentage = dayConfigFile.DayPercentage;
        MonthPercentage = dayConfigFile.MonthPercentage;
        YearPercentage = dayConfigFile.YearPercentage;
        dayRange = dayConfigFile.dayRange;
        monthRange = dayConfigFile.monthRange;
        yearRange = dayConfigFile.yearRange;

        Hotel1 = dayConfigFile.Hotel1;
        Hotel2 = dayConfigFile.Hotel2;
        Hotel3 = dayConfigFile.Hotel3;
        Hotel4 = dayConfigFile.Hotel4;
    }


    public void ReceiveDay(DayConfig currentDay)
    {
        dayConfigFile = currentDay;

    }
}
