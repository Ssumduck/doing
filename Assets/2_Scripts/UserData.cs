using Newtonsoft.Json;
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
        if (PlayerPrefs.HasKey(JsonKey.MemoKey))
        {
            string json = PlayerPrefs.GetString(JsonKey.MemoKey);

            dicMemo = JsonConvert.DeserializeObject<Dictionary<DateTime, string>>(json);
        }
    }

    public void MemoSave()
    {
        string json = JsonConvert.SerializeObject(dicMemo);
        PlayerPrefs.SetString(JsonKey.MemoKey, json);
    }

    public Dictionary<DateTime, List<ToDo>> dicToDo = new Dictionary<DateTime, List<ToDo>>();
    public Dictionary<DateTime, string> dicMemo = new Dictionary<DateTime, string>();

    public static DateTime dateTime = new DateTime();
}
