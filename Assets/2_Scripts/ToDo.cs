using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RepeatType { none, daily, weekly, monthly, custom }

public class ToDo
{
    public DateTime date;
    public string todo;
    public RepeatType repeatType;

    // RepeatType == custom 일때
    public List<DayOfWeek> repeatDays;

    public ToDo()
    {
        date = DateTime.Today;
        todo = "";
        repeatType = RepeatType.none;
        repeatDays = new List<DayOfWeek>();
    }
}
