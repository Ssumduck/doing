using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData
{
    public Dictionary<DateTime, List<ToDo>> dicToDo;
    public Dictionary<DateTime, string> dicMemo;

    public static DateTime dateTime = new DateTime();
}
