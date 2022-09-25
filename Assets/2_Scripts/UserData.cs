﻿using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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

    //UserData()
    //{
    //    // 초기화
    //    if (PlayerPrefs.HasKey(JsonKey.MemoKey))
    //    {
    //        string json = PlayerPrefs.GetString(JsonKey.MemoKey);

    //        json = Main.Instance.memoLoad.text;

    //        dicMemo = JsonConvert.DeserializeObject<Dictionary<DateTime, string>>(json);
    //    }
    //}

    UserData()
    {
        // 초기화
        if (DefineClass.ReadStringFromFile(SaveType.Memo) != null)
        {
            string json = DefineClass.ReadStringFromFile(SaveType.Memo);
            Debug.Log($"jsonLoad : {json}");
            dicMemo = JsonConvert.DeserializeObject<Dictionary<DateTime, string>>(json);
        }else
        {
#if UNITY_EDITOR
            Debug.LogError("dicMemo is null !!");
#endif
        }
    }

    public void MemoSave()
    {
        string json = JsonConvert.SerializeObject(dicMemo);
        DefineClass.WriteStringToFile(json, SaveType.Memo);
    }

    //public void MemoSave()
    //{
    //    string json = JsonConvert.SerializeObject(dicMemo);
    //    PlayerPrefs.SetString(JsonKey.MemoKey, json);
    //}

    public void AddToDo(ToDo toDoData)
    {
        if (dicToDo.ContainsKey(toDoData.date) == false)
            dicToDo.Add(toDoData.date, new List<ToDo>());

        dicToDo[toDoData.date].Add(toDoData);
    }


    public Dictionary<DateTime, List<ToDo>> dicToDo = new Dictionary<DateTime, List<ToDo>>();
    public Dictionary<DateTime, string> dicMemo = new Dictionary<DateTime, string>();

    public static DateTime dateTime = new DateTime();
}
