using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Day/Day Config", order = 1)]
public class DayConfig : ScriptableObject
{
    [Header("DocumentVariables")]
    public bool hasReservation;
    public bool hasID;
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

    [Header("Time Management")]
    public int Time;

    [Header("Patience Range")]
    public float minTime;
    public float maxTime;

    [Header("Blacklist Scriptable Object")]
    public BlacklistVariables blacklist;

    [Header("Audio at Start")]
    public AudioClip voiceline;
}
