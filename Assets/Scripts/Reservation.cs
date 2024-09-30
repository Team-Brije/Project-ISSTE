using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Reservation : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Data")]
    public List<int> possibleDates = new List<int>();
    public List<int> possibleMonths = new List<int>();
    public List<int> possibleYears = new List<int>();

    DataManager manager;

    bool isHotelCorrect;
    public bool isResCorrrect;


    public TextMeshPro dayText;
    public TextMeshPro monthText;
    public TextMeshPro yearText;
    public TextMeshPro hotelText;

    int day, month, year;

    enum Hotels { Hotel1, Hotel2, Hotel3, Hotel4 };

    Hotels hotels;
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

        int hotelnum = Random.Range(1, 4);

        if (hotelnum == 1) { hotels = Hotels.Hotel1; }
        if (hotelnum == 2) { hotels = Hotels.Hotel2; }
        if (hotelnum == 3) { hotels = Hotels.Hotel3; }
        if (hotelnum == 4) { hotels = Hotels.Hotel4; }
    }

    void GetDateAndCheck()
    {
        day = possibleDates[Random.Range(0, possibleDates.Count)];
        month = possibleMonths[Random.Range(0, possibleMonths.Count)];
        year = possibleYears[Random.Range(0, possibleYears.Count)];

        //Debug.Log("The random date was: " + day + "/" + month + "/" + year);
        if (hotels == Hotels.Hotel1 && manager.Hotel1) { isHotelCorrect = true; }
        else if (hotels == Hotels.Hotel2 && manager.Hotel2) { isHotelCorrect = true; }
        else if (hotels == Hotels.Hotel3 && manager.Hotel3) { isHotelCorrect = true; }
        else if (hotels == Hotels.Hotel4 && manager.Hotel4) { isHotelCorrect = true; }
        else { isHotelCorrect = false; }

        if (day == manager.day && month == manager.month && year == manager.year && isHotelCorrect)
        {
            Debug.Log("This Reservation is Correct");
            isResCorrrect = true;
        }
        else
        {
            Debug.Log("This Reservation is Inorrect");
            isResCorrrect = false;
        }

    }

    void DisplayData()
    {
        dayText.text = day.ToString();
        monthText.text = month.ToString();
        yearText.text = year.ToString();
        if (hotels == Hotels.Hotel1) { hotelText.text = "HOTEL 1"; }
        if (hotels == Hotels.Hotel2) { hotelText.text = "HOTEL 2"; }
        if (hotels == Hotels.Hotel3) { hotelText.text = "HOTEL 3"; }
        if (hotels == Hotels.Hotel4) { hotelText.text = "HOTEL 4"; }
    }

    public IEnumerator resetRigi()
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
    }

    public bool GetValue()
    {
        return isResCorrrect;
    }

}
