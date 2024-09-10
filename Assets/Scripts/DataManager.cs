
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [Header("Date Variables")]
    public int day;
    public int month;
    public int year;

    [Header("Ticket Difficulty Variables")]

    public int poolSize;
    public int DayPercentage, MonthPercentage, YearPercentage;
    public int dayRange;
    public int monthRange;
    public int yearRange;


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
    
    public static void CheckTicket()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
