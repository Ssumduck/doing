using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public enum RepeatType { none, daily, weekly, monthly, custom }

public class ToDo
{
    public DateTime date;
    public string todo;
    public RepeatType repeatType;

    public List<DateTime> completeDays;
    // RepeatType == custom 일때
    public List<DayOfWeek> repeatDays;

    public ToDo()
    {
        date = DateTime.Today;
        todo = "";
        repeatType = RepeatType.none;
        completeDays = new List<DateTime>();
        repeatDays = new List<DayOfWeek>();
    }

    public bool isToDoOfDay (DateTime checkDate)
    {
        switch(repeatType)
        {
            case RepeatType.none:
                return DateTime.Equals(checkDate.Date, date.Date);
            case RepeatType.daily:
                return true;
            case RepeatType.weekly:
                return checkDate.DayOfWeek == date.DayOfWeek;
            case RepeatType.monthly:
                return checkDate.Day == date.Day || (date.Day == 31 && isLastDayOfMonth(checkDate.Date) && isLastDayOfMonth(date.Date));
            case RepeatType.custom:
                return repeatDays.Contains(checkDate.DayOfWeek);
        }

        return false;
    }

    public bool isToDoDone (DateTime checkDate)
    {
        return completeDays.Contains(checkDate.Date);
    }

    public void CheckComplete(bool _isComplete, DateTime _date)
    {
        if (_isComplete && !completeDays.Contains(_date.Date))
            completeDays.Add(_date);
        else if (!_isComplete && completeDays.Contains(_date.Date))
            completeDays.Remove(_date);
    }

    bool isLastDayOfMonth(DateTime date)
    {
        Calendar cal = new KoreanCalendar();
        int year = cal.GetYear(date);
        int month = cal.GetMonth(date);
        int days = cal.GetDaysInMonth(year, month);

        return date.Day == days;
    }
}