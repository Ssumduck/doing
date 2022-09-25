using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefineClass
{
    public static string GetStringMonth(int months)
    {
        switch (months)
        {
            case 1:
                return "January";
            case 2:
                return "February";
            case 3:
                return "March";
            case 4:
                return "April";
            case 5:
                return "May";
            case 6:
                return "June";
            case 7:
                return "July";
            case 8:
                return "August";
            case 9:
                return "September";
            case 10:
                return "October";
            case 11:
                return "November";
            case 12:
                return "December";
        }
        return string.Empty;
    }

    public static string GetStringSimpleDay(DayOfWeek dayOfWeek)
    {
        switch (dayOfWeek)
        {
            case DayOfWeek.Friday:
                return "Fri";
            case DayOfWeek.Monday:
                return "Mon";
            case DayOfWeek.Saturday:
                return "Sat";
            case DayOfWeek.Sunday:
                return "Sun";
            case DayOfWeek.Thursday:
                return "Thu";
            case DayOfWeek.Tuesday:
                return "Tue";
            case DayOfWeek.Wednesday:
                return "Wed";
        }
        return string.Empty;
    }
}
