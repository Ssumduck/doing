using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData
{
    static UserData instance;
    public static UserData Instance
    {
        get
        {
            if (instance == null)
                instance = new UserData();
            return instance;
        }
    }

    UserData()
    {
        // 초기화
    }

    public Dictionary<DateTime, List<ToDo>> dicToDo = new Dictionary<DateTime, List<ToDo>>();
    public Dictionary<DateTime, string> dicMemo = new Dictionary<DateTime, string>();

    public static DateTime dateTime = new DateTime();
}
