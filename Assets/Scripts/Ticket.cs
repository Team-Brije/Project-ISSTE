
using System.Collections.Generic;
using UnityEngine;

public class Ticket : MonoBehaviour
{

    public List<int> possibleDates = new List<int>();
    public List<int> possibleMonths = new List<int>();
    public List<int> possibleYears = new List<int>();

    GameManager manager;
    
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        InitializeValues();
    }


    void InitializeValues()
    {

        possibleDates.Clear();
        possibleMonths.Clear();
        possibleYears.Clear();

        for (int day = 0; day < manager.dayNumbers;  day++)
        {
            possibleDates.Add(day);
        }
        for (int month = 0; month < manager.monthNumbers; month++)
        {
            possibleMonths.Add(month);
        }
        for (int year = 0; year < manager.yearNumbers; year++)
        {
            possibleYears.Add(year);
        }

        for (int i = 1; i < possibleDates.Count; i++)
        {
            possibleDates[i] = manager.day + Random.Range(manager.minimumDayValue, manager.maximumDayValue);
        }

        for (int i = 1; i < possibleMonths.Count; i++)
        {
            possibleMonths[i] = manager.month + Random.Range(manager.minimumMonthValue, manager.maximumMonthValue);
        }

        for (int i = 1; i < possibleYears.Count; i++)
        {
            possibleYears[i] = manager.year + Random.Range(manager.minimumYearValue, manager.maximumYearValue);
        }

        possibleDates[0] = manager.day;
        possibleMonths[0] = manager.month;
        possibleYears[0] = manager.year;

        
    }

    void AddWeight()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
