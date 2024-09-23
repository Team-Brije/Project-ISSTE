
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ticket : MonoBehaviour
{

    public List<int> possibleDates = new List<int>();
    public List<int> possibleMonths = new List<int>();
    public List<int> possibleYears = new List<int>();

    DataManager manager;

    public bool isTicketCorrrect;
    public bool hasTicketBeenChecked;
    public bool lastStampUsed;

    public TextMeshPro dayText;
    public TextMeshPro monthText;
    public TextMeshPro yearText;

    int day, month, year;
    
    // Start is called before the first frame update
    void OnEnable()
    {
        manager = DataManager.Instance;
        InitializeValues();
        AddWeight();
        GetDateAndCheck();
        DisplayData();
        StartCoroutine(resetRigi());
    }


    void InitializeValues()
    {
        possibleDates.Clear();
        possibleMonths.Clear();
        possibleYears.Clear();
        hasTicketBeenChecked = false;

        for (int day = 0; day < manager.poolSize;  day++)
        {
            possibleDates.Add(day);
        }
        for (int month = 0; month < manager.poolSize; month++)
        {
            possibleMonths.Add(month);
        }
        for (int year = 0; year < manager.poolSize; year++)
        {
            possibleYears.Add(year);
        }

        for (int i = 1; i < possibleDates.Count; i++)
        {
            int num = Random.Range(manager.dayRange * -1, manager.dayRange);
            if (num > 0 && num < 32)
            {
                possibleDates[i] = num;
            }
            else
            {
                possibleDates[i] = Random.Range(1,30);
            }
        }

        for (int i = 1; i < possibleMonths.Count; i++)
        {
            int num = Random.Range(manager.monthRange * -1, manager.monthRange);
            if (num > 0 && num < 13)
            {
                possibleMonths[i] = num;
            }
            else
            {
                possibleMonths[i] = Random.Range(1,12);
            }
        }

        for (int i = 1; i < possibleYears.Count; i++)
        {
            possibleYears[i] = manager.year + Random.Range(manager.yearRange * -1, manager.yearRange);
        }    
    }

    void AddWeight()
    {
        int dayvalue = (manager.DayPercentage * manager.poolSize) / 100;
        int monthvalue = (manager.MonthPercentage * manager.poolSize) / 100;
        int yearvalue = (manager.YearPercentage * manager.poolSize) / 100;


        for (int i = 0; i < dayvalue; i++)
        {
            possibleDates[i] = manager.day;
        }
        for (int i = 0; i < monthvalue; i++)
        {
            possibleMonths[i] = manager.month;
        }
        for (int i = 0; i < yearvalue; i++)
        {
            possibleYears[i] = manager.year;
        }

        
    }

    void GetDateAndCheck()
    {
        day = possibleDates[Random.Range(0,possibleDates.Count)];
        month = possibleMonths[Random.Range(0, possibleMonths.Count)];
        year = possibleYears[Random.Range(0, possibleYears.Count)];

        //Debug.Log("The random date was: " + day + "/" + month + "/" + year);

        if (day == manager.day && month == manager.month && year == manager.year)
        {
            Debug.Log("This Ticket would be correct");
            isTicketCorrrect = true;
        }
        else
        {
            Debug.Log("This Ticket would be incorrect");
            isTicketCorrrect = false;
        }
    }

    void DisplayData()
    {
        dayText.text = day.ToString();
        monthText.text = month.ToString();
        yearText.text = year.ToString();
    }

    public IEnumerator resetRigi(){
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
    }
}
