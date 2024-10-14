using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ID : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Data")]
    public List<int> possibleDates = new List<int>();
    public List<int> possibleMonths = new List<int>();
    public List<int> possibleYears = new List<int>();

    DataManager manager;

    public bool isIDCorrrect;

    public TextMeshPro DateText, nameText, speciesText;

    int day, month, year;

    private Coroutine corResetRig;
    // Start is called before the first frame update
    void OnEnable()
    {
        manager = DataManager.Instance;
        InitializeValues();
        AddWeight();
        GetDateAndCheck();
        DisplayData();
        if (corResetRig != null) { StopCoroutine(corResetRig); }
        StartCoroutine(resetRigi());
    }
    private void OnDestroy()
    {
        if (corResetRig != null) { StopCoroutine(corResetRig); }
        possibleDates.Clear();
        possibleMonths.Clear();
        possibleYears.Clear();
    }

    private void OnDisable()
    {
        if (corResetRig != null) { StopCoroutine(corResetRig); }
        possibleDates.Clear();
        possibleMonths.Clear();
        possibleYears.Clear();
    }

    void InitializeValues()
    {
        possibleDates.Clear();
        possibleMonths.Clear();
        possibleYears.Clear();

        for (int day = 0; day < manager.poolSize; day++)
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
                possibleDates[i] = Random.Range(1, 30);
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
                possibleMonths[i] = Random.Range(1, 12);
            }
        }

        for (int i = 1; i < possibleYears.Count; i++)
        {
            possibleYears[i] = manager.year + Random.Range(manager.yearRange * -1, manager.yearRange);
        }
    }

    void AddWeight()
    {
        int dayvalue = (manager.DayPercentage * manager.poolSize) / 150;
        int monthvalue = (manager.MonthPercentage * manager.poolSize) / 150;
        int yearvalue = (manager.YearPercentage * manager.poolSize) / 150;

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
        day = possibleDates[Random.Range(0, possibleDates.Count)];
        month = possibleMonths[Random.Range(0, possibleMonths.Count)];
        year = possibleYears[Random.Range(0, possibleYears.Count)];

        day += Random.Range(1, 5);
        day -= Random.Range(1, 5);

        month += Random.Range(1, 3);
        month -= Random.Range(1, 3);

        if (day > 30) { day = 30; }
        if (month > 12) { month = 12; }

        //Debug.Log("The random date was: " + day + "/" + month + "/" + year);
        System.DateTime IDdate = new System.DateTime(year, month, day);
        System.DateTime Todaysdate = new System.DateTime(manager.year, manager.month, manager.day);

        if (IDdate < Todaysdate)
        {
            Debug.Log("This ID is Incorrect");
            isIDCorrrect = false;
        }
        else
        {
            Debug.Log("This ID is Correct");
            isIDCorrrect = true;
        }

    }

    void DisplayData()
    {
        DateText.text = day.ToString() + "/" + month.ToString() + "/" + year.ToString();
    }

    public IEnumerator resetRigi()
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
    }

    public bool GetValue()
    {
        return isIDCorrrect;
    }

}
