
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
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
    [HideInInspector] public List<bool> Hotels = new List<bool>();


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

        Hotels.Add(dayConfigFile.Hotel1);
        Hotels.Add(dayConfigFile.Hotel2);
        Hotels.Add(dayConfigFile.Hotel3);
        Hotels.Add(dayConfigFile.Hotel4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
